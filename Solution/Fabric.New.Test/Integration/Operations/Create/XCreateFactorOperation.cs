using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateFactorOperation : XCreateOperation<Factor> {

		private CreateFabFactor vCreateFactor;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateFactor = new CreateFabFactor();
			vCreateFactor.AssertionType = (byte)FactorAssertion.Id.Opinion;
			vCreateFactor.IsDefining = true;
			vCreateFactor.Note = "My Note";
			vCreateFactor.UsesPrimaryArtifactId = (long)SetupUserId.Zach;
			vCreateFactor.UsesRelatedArtifactId = (long)SetupClassId.Art;

			vCreateFactor.Descriptor = new CreateFabDescriptor();
			vCreateFactor.Descriptor.Type = (byte)DescriptorType.Id.IsAnInstanceOf;

			vCreateFactor.Descriptor.RefinesPrimaryWithArtifactId = (long)SetupClassId.Attendance;
			vCreateFactor.Descriptor.RefinesRelatedWithArtifactId = (long)SetupClassId.Digital;
			vCreateFactor.Descriptor.RefinesTypeWithArtifactId = (long)SetupClassId.Evolution;

			vCreateFactor.Director = new CreateFabDirector();
			vCreateFactor.Director.Type = (byte)DirectorType.Id.DefinedPath;
			vCreateFactor.Director.PrimaryAction = (byte)DirectorAction.Id.Learn;
			vCreateFactor.Director.RelatedAction = (byte)DirectorAction.Id.Read;

			vCreateFactor.Eventor = new CreateFabEventor();
			vCreateFactor.Eventor.Type = (byte)EventorType.Id.Occur;
			vCreateFactor.Eventor.Year = 2000;
			vCreateFactor.Eventor.Month = 11;
			vCreateFactor.Eventor.Day = 29;
			vCreateFactor.Eventor.Hour = 11;
			vCreateFactor.Eventor.Minute = 51;
			vCreateFactor.Eventor.Second = 52;

			vCreateFactor.Identor = new CreateFabIdentor();
			vCreateFactor.Identor.Type = (byte)IdentorType.Id.Key;
			vCreateFactor.Identor.Value = "MyIdentorVal";

			vCreateFactor.Locator = new CreateFabLocator();
			vCreateFactor.Locator.Type = (byte)LocatorType.Id.EarthCoord;
			vCreateFactor.Locator.ValueX = 1.234;
			vCreateFactor.Locator.ValueY = 12.3456;
			vCreateFactor.Locator.ValueZ = 123.4567;

			vCreateFactor.Vector = new CreateFabVector();
			vCreateFactor.Vector.Type = (byte)VectorType.Id.FullLong;
			vCreateFactor.Vector.Unit = (byte)VectorUnit.Id.Metre;
			vCreateFactor.Vector.UnitPrefix = (byte)VectorUnitPrefix.Id.Kilo;
			vCreateFactor.Vector.Value = 21464;
			vCreateFactor.Vector.UsesAxisArtifactId = (long)SetupClassId.Excitement;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Factor ExecuteOperation() {
			var op = new CreateFactorOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Factor result = ExecuteOperation();

			Assert.AreNotEqual(0, result.Id, "Incorrect Id.");
			Assert.AreNotEqual(0, result.VertexType, "Incorrect VertexType.");
			Assert.AreNotEqual(0, result.Timestamp, "Incorrect Timestamp.");
			Assert.AreEqual(vCreateFactor.AssertionType, result.AssertionType,
				"Incorrect AssertionType.");
			Assert.AreEqual(vCreateFactor.IsDefining, result.IsDefining, "Incorrect IsDefining.");
			Assert.AreEqual(vCreateFactor.Note, result.Note, "Incorrect Note.");

			Assert.NotNull(vCreateFactor.Descriptor, "Descriptor should be filled.");
			Assert.AreEqual(vCreateFactor.Descriptor.Type, result.DescriptorType,
				"Incorrect DescriptorType.");

			Assert.NotNull(vCreateFactor.Director, "Director should be filled.");
			Assert.AreEqual(vCreateFactor.Director.Type, result.DirectorType,
				"Incorrect DirectorType.");
			Assert.AreEqual(vCreateFactor.Director.PrimaryAction, result.DirectorPrimaryAction,
				"Incorrect DirectorPrimaryAction.");
			Assert.AreEqual(vCreateFactor.Director.RelatedAction, result.DirectorRelatedAction,
				"Incorrect DirectorRelatedAction.");

			Assert.NotNull(vCreateFactor.Eventor, "Eventor should be filled.");
			var e = vCreateFactor.Eventor;
			var edt = DataUtil.EventorTimesToLong(e.Year, e.Month, e.Day, e.Hour, e.Minute, e.Second);
			Assert.AreEqual(e.Type, result.EventorType, "Incorrect EventorType.");
			Assert.AreEqual(edt, result.EventorDateTime, "Incorrect EventorDateTime.");

			Assert.NotNull(vCreateFactor.Identor, "Identor should be filled.");
			Assert.AreEqual(vCreateFactor.Identor.Type, result.IdentorType, "Incorrect IdentorType.");
			Assert.AreEqual(vCreateFactor.Identor.Value, result.IdentorValue, "Incorrect IdentorValue.");

			Assert.NotNull(vCreateFactor.Locator, "Locator should be filled.");
			Assert.AreEqual(vCreateFactor.Locator.Type, result.LocatorType, "Incorrect LocatorType.");
			Assert.AreEqual(vCreateFactor.Locator.ValueX, result.LocatorValueX,
				"Incorrect LocatorValueX.");
			Assert.AreEqual(vCreateFactor.Locator.ValueY, result.LocatorValueY,
				"Incorrect LocatorValueY.");
			Assert.AreEqual(vCreateFactor.Locator.ValueZ, result.LocatorValueZ,
				"Incorrect LocatorValueZ.");

			Assert.NotNull(vCreateFactor.Vector, "Vector should be filled.");
			Assert.AreEqual(vCreateFactor.Vector.Type, result.VectorType, "Incorrect VectorType.");
			Assert.AreEqual(vCreateFactor.Vector.Unit, result.VectorUnit, "Incorrect VectorUnit.");
			Assert.AreEqual(vCreateFactor.Vector.UnitPrefix, result.VectorUnitPrefix,
				"Incorrect VectorUnitPrefix.");
			Assert.AreEqual(vCreateFactor.Vector.Value, result.VectorValue, "Incorrect VectorValue.");

			IWeaverStepAs<Factor> facAlias;
			long facId = result.VertexId;

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Factor>(x => x.VertexId, facId)
				.As(out facAlias)

				.CreatedByMember.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateFactor.CreatedByMemberId)
				.CreatesFactors.ToFactor
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, facId)

				.UsesPrimaryArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateFactor.UsesPrimaryArtifactId)
				.UsedAsPrimaryByFactors.ToFactor
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, facId)

				.UsesRelatedArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateFactor.UsesRelatedArtifactId)
				.UsedAsRelatedByFactors.ToFactor
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, facId)

				.DescriptorRefinesPrimaryWithArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo,
						vCreateFactor.Descriptor.RefinesPrimaryWithArtifactId)
					.Back(facAlias)

				.DescriptorRefinesRelatedWithArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo,
						vCreateFactor.Descriptor.RefinesRelatedWithArtifactId)
					.Back(facAlias)

				.DescriptorRefinesTypeWithArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo,
						vCreateFactor.Descriptor.RefinesTypeWithArtifactId)
					.Back(facAlias)

				.VectorUsesAxisArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo,
						vCreateFactor.Vector.UsesAxisArtifactId)
					.Back(facAlias)

				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 10;
			SetNewElementQuery(verify);

			//TODO: add checks for VCI properties in the "NewElementQuery" queries
		}

	}

}