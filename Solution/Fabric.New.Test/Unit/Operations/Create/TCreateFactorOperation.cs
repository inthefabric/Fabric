using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateFactorOperation :
					TCreateVertexOperation<Factor, FabFactor, CreateFabFactor, CreateFactorOperation> {

		private static readonly Logger Log = Logger.Build<TCreateFactorOperation>();

		private const int GetMemberCmdId = 2;
		private const int GetPrimaryCmdId = 5;
		private const int GetRelatedCmdId = 8;

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
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetMemberCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetPrimaryCmdId, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetRelatedCmdId, 0)).Returns(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
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

			pCondCmdId = SetupEdgePair("creByMem", pCondCmdId, 0, vMemId,
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

			pCondCmdId = SetupEdgePair("usesPrim", pCondCmdId, 1, vCreateObj.UsesPrimaryArtifactId,
				DbName.Edge.FactorUsesPrimaryArtifactName,DbName.Edge.ArtifactUsedAsPrimaryByFactorName,
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

			pCondCmdId = SetupEdgePair("usesRel", pCondCmdId, 2, vCreateObj.UsesRelatedArtifactId,
				DbName.Edge.FactorUsesRelatedArtifactName,DbName.Edge.ArtifactUsedAsRelatedByFactorName,
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
			ExecuteNo<Member>(GetMemberCmdId, vMemId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoPrimary() {
			ExecuteNo<Artifact>(GetPrimaryCmdId, vCreateObj.UsesPrimaryArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteNoRelated() {
			ExecuteNo<Artifact>(GetRelatedCmdId, vCreateObj.UsesRelatedArtifactId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void ExecuteNo<T>(int pCmdId, long pId) {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(pCmdId, 0)).Returns(0);
			CreateFactorOperation c = BuildCreateVerify();
			FabNotFoundFault f = TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
			Assert.Less(-1, f.Message.IndexOf(typeof(T).Name), "Incorrect Message type.");
			Assert.Less(-1, f.Message.IndexOf("Id="+pId), "Incorrect Message Id value.");
		}

	}

}