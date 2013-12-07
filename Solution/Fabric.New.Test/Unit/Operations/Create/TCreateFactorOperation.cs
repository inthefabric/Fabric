using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateFactorOperation :
					TCreateVertexOperation<Factor, FabFactor, CreateFabFactor, CreateFactorOperation> {

		protected static readonly Logger Log = Logger.Build<TCreateFactorOperation>();

		protected static int vGetMemberCmdId = 2;
		protected static int vGetPrimaryCmdId = 5;
		protected static int vGetRelatedCmdId = 8;

		private long vMemId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();
			vMemId = 123456;

			vCreateObj.AssertionType = (byte)FactorAssertion.Id.Opinion;
			vCreateObj.IsDefining = true;
			vCreateObj.Note = "My Note";
			vCreateObj.UsesPrimaryArtifactId = 12961924;
			vCreateObj.UsesRelatedArtifactId = 36373527463;

			vCreateObj.Descriptor = new CreateFabDescriptor();
			vCreateObj.Descriptor.Type = (byte)DescriptorType.Id.IsAnInstanceOf;

			SetupAddVertexResultAt(1);
			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(vMemId);
			
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(vGetMemberCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(vGetPrimaryCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(vGetRelatedCmdId, 0)).Returns(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			SetupAddFactor(pCondCmdId);
			pCondCmdId = SetupCreatedBy(pCondCmdId, 0);
			pCondCmdId = SetupUses(pCondCmdId, 1);
			return pCondCmdId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void SetupAddFactor(string pCondCmdId) {
			AddCommand("addFactor", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.Factor.AssertionType+":_P,"+
						DbName.Vert.Factor.IsDefining+":_P,"+
						DbName.Vert.Factor.Note+":_P,"+
						DbName.Vert.Factor.DescriptorType+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.AssertionType,
					vCreateObj.IsDefining,
					vCreateObj.Note,
					vCreateObj.Descriptor.Type,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.Factor
				}),
				Cache = true
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		protected string SetupCreatedBy(string pCondCmdId, int pIndex) {
			pCondCmdId = SetupEdgePair("creByMem", pCondCmdId, pIndex, vMemId,
				DbName.Edge.FactorCreatedByMemberName, DbName.Edge.MemberCreatesFactorName,
				new[] {
					DbName.Edge.MemberCreatesFactor.Timestamp,
					DbName.Edge.MemberCreatesFactor.DescriptorType,
					DbName.Edge.MemberCreatesFactor.PrimaryArtifactId,
					DbName.Edge.MemberCreatesFactor.RelatedArtifactId
				},
				new object[] {
					vExpectDomResult.Timestamp,
					vCreateObj.Descriptor.Type,
					vCreateObj.UsesPrimaryArtifactId,
					vCreateObj.UsesRelatedArtifactId
				}
			);

			return pCondCmdId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected string SetupUses(string pCondCmdId, int pIndex) {
			pCondCmdId = SetupEdgePair("usesPrim", pCondCmdId, pIndex,
				vCreateObj.UsesPrimaryArtifactId,
				DbName.Edge.FactorUsesPrimaryArtifactName,
				DbName.Edge.ArtifactUsedAsPrimaryByFactorName,
				new[] {
					DbName.Edge.ArtifactUsedAsPrimaryByFactor.Timestamp,
					DbName.Edge.ArtifactUsedAsPrimaryByFactor.DescriptorType,
					DbName.Edge.ArtifactUsedAsPrimaryByFactor.RelatedArtifactId
				},
				new object[] {
					vExpectDomResult.Timestamp,
					vCreateObj.Descriptor.Type,
					vCreateObj.UsesRelatedArtifactId
				}
			);

			pCondCmdId = SetupEdgePair("usesRel", pCondCmdId, pIndex+1,
				vCreateObj.UsesRelatedArtifactId,
				DbName.Edge.FactorUsesRelatedArtifactName,
				DbName.Edge.ArtifactUsedAsRelatedByFactorName,
				new[] {
					DbName.Edge.ArtifactUsedAsRelatedByFactor.Timestamp,
					DbName.Edge.ArtifactUsedAsRelatedByFactor.DescriptorType,
					DbName.Edge.ArtifactUsedAsRelatedByFactor.PrimaryArtifactId
				},
				new object[] {
					vExpectDomResult.Timestamp,
					vCreateObj.Descriptor.Type,
					vCreateObj.UsesPrimaryArtifactId
				}
			);

			return pCondCmdId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Logger GetLogger() {
			return Log;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsInternalGetResult() {
			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexType.Id GetVertexTypeId() {
			return VertexType.Id.Factor;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ValidateArtifactIdMatch() {
			vCreateObj.UsesPrimaryArtifactId = vCreateObj.UsesRelatedArtifactId;
			TestUtil.Throws<FabPropertyValueFault>(() => BuildCreateVerify());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoMember() {
			ExecuteNo<Member>(vGetMemberCmdId, vMemId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoPrimary() {
			ExecuteNo<Artifact>(vGetPrimaryCmdId, vCreateObj.UsesPrimaryArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoRelated() {
			ExecuteNo<Artifact>(vGetRelatedCmdId, vCreateObj.UsesRelatedArtifactId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void ExecuteNo<T>(int pCmdId, long pId) {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(pCmdId, 0)).Returns(0);
			CreateFactorOperation c = BuildCreateVerify();
			FabNotFoundFault f = TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
			Assert.Less(-1, f.Message.IndexOf(typeof(T).Name), "Incorrect Message type.");
			Assert.Less(-1, f.Message.IndexOf("Id="+pId), "Incorrect Message Id value.");
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TCreateFactorOperationMax : TCreateFactorOperation {

		private const int GetRefPrimCmdId = 5;
		private const int GetRefRelCmdId = 7;
		private const int GetRefTypeCmdId = 9;
		private const int GetAxisCmdId = 17;

		private const long RefPrimArtId = 12451262;
		private const long RefRelArtId = 25724724;
		private const long RefTypeArtId = 85435345;
		private const long AxisArtId = 34753457;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			vGetMemberCmdId = 2;
			vGetPrimaryCmdId = 11;
			vGetRelatedCmdId = 14;

			base.SetUpInner();

			vCreateObj.Descriptor.RefinesPrimaryWithArtifactId = RefPrimArtId;
			vCreateObj.Descriptor.RefinesRelatedWithArtifactId = RefRelArtId;
			vCreateObj.Descriptor.RefinesTypeWithArtifactId = RefTypeArtId;

			vCreateObj.Director = new CreateFabDirector();
			vCreateObj.Director.Type = 9;
			vCreateObj.Director.PrimaryAction = 8;
			vCreateObj.Director.RelatedAction = 7;

			vCreateObj.Eventor = new CreateFabEventor();
			vCreateObj.Eventor.Type = 6;
			vCreateObj.Eventor.Year = 2000;
			vCreateObj.Eventor.Month = 11;
			vCreateObj.Eventor.Day = 29;
			vCreateObj.Eventor.Hour = 11;
			vCreateObj.Eventor.Minute = 51;
			vCreateObj.Eventor.Second = 52;

			vCreateObj.Identor = new CreateFabIdentor();
			vCreateObj.Identor.Type = 13;
			vCreateObj.Identor.Value = "MyIdentorVal";

			vCreateObj.Locator = new CreateFabLocator();
			vCreateObj.Locator.Type = 22;
			vCreateObj.Locator.ValueX = 1.234;
			vCreateObj.Locator.ValueY = 12.3456;
			vCreateObj.Locator.ValueZ = 123.4567;

			vCreateObj.Vector = new CreateFabVector();
			vCreateObj.Vector.Type = 2;
			vCreateObj.Vector.Unit = 3;
			vCreateObj.Vector.UnitPrefix = 4;
			vCreateObj.Vector.Value = 21464;
			vCreateObj.Vector.UsesAxisArtifactId = AxisArtId;

			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetRefPrimCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetRefRelCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetRefTypeCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetAxisCmdId, 0)).Returns(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			SetupAddFactor(pCondCmdId);
			pCondCmdId = SetupCreatedBy(pCondCmdId, 0);
			pCondCmdId = SetupEdgeSingle("refPrim", pCondCmdId, 1, RefPrimArtId,
				DbName.Edge.FactorDescriptorRefinesPrimaryWithArtifactName);
			pCondCmdId = SetupEdgeSingle("refRel", pCondCmdId, 2, RefRelArtId,
				DbName.Edge.FactorDescriptorRefinesRelatedWithArtifactName);
			pCondCmdId = SetupEdgeSingle("refType", pCondCmdId, 3, RefTypeArtId,
				DbName.Edge.FactorDescriptorRefinesTypeWithArtifactName);
			pCondCmdId = SetupUses(pCondCmdId, 4);
			pCondCmdId = SetupEdgeSingle("axis", pCondCmdId, 6, AxisArtId,
				DbName.Edge.FactorVectorUsesAxisArtifactName);
			return pCondCmdId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupAddFactor(string pCondCmdId) {
			AddCommand("addFactor", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.Factor.AssertionType+":_P,"+
						DbName.Vert.Factor.IsDefining+":_P,"+
						DbName.Vert.Factor.Note+":_P,"+

						DbName.Vert.Factor.DescriptorType+":_P,"+

						DbName.Vert.Factor.DirectorType+":_P,"+
						DbName.Vert.Factor.DirectorPrimaryAction+":_P,"+
						DbName.Vert.Factor.DirectorRelatedAction+":_P,"+

						DbName.Vert.Factor.EventorType+":_P,"+
						DbName.Vert.Factor.EventorDateTime+":_P,"+

						DbName.Vert.Factor.IdentorType+":_P,"+
						DbName.Vert.Factor.IdentorValue+":_P,"+

						DbName.Vert.Factor.LocatorType+":_P,"+
						DbName.Vert.Factor.LocatorValueX+":_P,"+
						DbName.Vert.Factor.LocatorValueY+":_P,"+
						DbName.Vert.Factor.LocatorValueZ+":_P,"+

						DbName.Vert.Factor.VectorType+":_P,"+
						DbName.Vert.Factor.VectorUnit+":_P,"+
						DbName.Vert.Factor.VectorUnitPrefix+":_P,"+
						DbName.Vert.Factor.VectorValue+":_P,"+

						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.AssertionType,
					vCreateObj.IsDefining,
					vCreateObj.Note,

					vCreateObj.Descriptor.Type,

					vCreateObj.Director.Type,
					vCreateObj.Director.PrimaryAction,
					vCreateObj.Director.RelatedAction,

					vCreateObj.Eventor.Type,
					DataUtil.EventorTimesToLong(
						vCreateObj.Eventor.Year,
						vCreateObj.Eventor.Month,
						vCreateObj.Eventor.Day,
						vCreateObj.Eventor.Hour,
						vCreateObj.Eventor.Minute,
						vCreateObj.Eventor.Second
					),

					vCreateObj.Identor.Type,
					vCreateObj.Identor.Value,

					vCreateObj.Locator.Type,
					vCreateObj.Locator.ValueX,
					vCreateObj.Locator.ValueY,
					vCreateObj.Locator.ValueZ,

					vCreateObj.Vector.Type,
					vCreateObj.Vector.Unit,
					vCreateObj.Vector.UnitPrefix,
					vCreateObj.Vector.Value,
					
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.Factor
				}),
				Cache = true
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoRefPrim() {
			ExecuteNo<Artifact>(GetRefPrimCmdId, RefPrimArtId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoRefRel() {
			ExecuteNo<Artifact>(GetRefRelCmdId, RefRelArtId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoRefType() {
			ExecuteNo<Artifact>(GetRefTypeCmdId, RefTypeArtId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoAxis() {
			ExecuteNo<Artifact>(GetAxisCmdId, AxisArtId);
		}

	}

}