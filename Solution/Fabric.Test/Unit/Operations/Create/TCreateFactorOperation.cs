using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using ServiceStack.Text;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateFactorOperation :TCreateOperationBase<
											Factor, FabFactor, CreateFabFactor, CreateFactorOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabFactor pCre) {
			pCre.AssertionType = (byte)FactorAssertion.Id.Opinion;
			pCre.IsDefining = true;
			pCre.Note = "My Note";
			pCre.UsesPrimaryArtifactId = 12961924;
			pCre.UsesRelatedArtifactId = 36373527463;

			pCre.Descriptor = new CreateFabDescriptor();
			pCre.Descriptor.Type = (byte)DescriptorType.Id.IsAnInstanceOf;

			pCre.Descriptor.RefinesPrimaryWithArtifactId = 9876544;
			pCre.Descriptor.RefinesRelatedWithArtifactId = 453453;
			pCre.Descriptor.RefinesTypeWithArtifactId = 3735727;

			pCre.Director = new CreateFabDirector();
			pCre.Director.Type = 9;
			pCre.Director.PrimaryAction = 8;
			pCre.Director.RelatedAction = 7;

			pCre.Eventor = new CreateFabEventor();
			pCre.Eventor.Type = 6;
			pCre.Eventor.Year = 2000;
			pCre.Eventor.Month = 11;
			pCre.Eventor.Day = 29;
			pCre.Eventor.Hour = 11;
			pCre.Eventor.Minute = 51;
			pCre.Eventor.Second = 52;

			pCre.Identor = new CreateFabIdentor();
			pCre.Identor.Type = 13;
			pCre.Identor.Value = "MyIdentorVal";

			pCre.Locator = new CreateFabLocator();
			pCre.Locator.Type = 22;
			pCre.Locator.ValueX = 1.234;
			pCre.Locator.ValueY = 12.3456;
			pCre.Locator.ValueZ = 123.4567;

			pCre.Vector = new CreateFabVector();
			pCre.Vector.Type = 2;
			pCre.Vector.Unit = 3;
			pCre.Vector.UnitPrefix = 4;
			pCre.Vector.Value = 21464;
			pCre.Vector.UsesAxisArtifactId = 3235723;

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<Factor> alias = new WeaverVarAlias<Factor>("test");

			MockTasks
				.Setup(x => x.AddFactor(build, ItIsVert<Factor>(VertId), out alias))
				.Callback(CheckCallIndex("AddFactor"));
			MockTasks.Verify();
			MockTasks
				.Setup(x => x.AddFactorCreatedByMember(
					build,
					ItIsVert<Factor>(VertId), 
					It.Is<CreateFabFactor>(c => c.CreatedByMemberId == MemId),
					alias
				))
				.Callback(CheckCallIndex("AddArtifactCreatedByMember"));

			MockTasks
				.Setup(x => x.AddFactorDescriptorRefinesPrimaryWithArtifact(
					build,
					ItIsVert<Factor>(VertId),
					It.Is<CreateFabFactor>(c => c.Descriptor.RefinesPrimaryWithArtifactId == 
							pCre.Descriptor.RefinesPrimaryWithArtifactId),
					alias
				))
				.Callback(CheckCallIndex("AddFactorDescriptorRefinesPrimaryWithArtifact"));

			MockTasks
				.Setup(x => x.AddFactorDescriptorRefinesRelatedWithArtifact(
					build,
					ItIsVert<Factor>(VertId),
					It.Is<CreateFabFactor>(c => c.Descriptor.RefinesRelatedWithArtifactId == 
							pCre.Descriptor.RefinesRelatedWithArtifactId),
					alias
				))
				.Callback(CheckCallIndex("AddFactorDescriptorRefinesRelatedWithArtifact"));
			
			MockTasks
				.Setup(x => x.AddFactorDescriptorRefinesTypeWithArtifact(
					build,
					ItIsVert<Factor>(VertId),
					It.Is<CreateFabFactor>(c => c.Descriptor.RefinesTypeWithArtifactId == 
							pCre.Descriptor.RefinesTypeWithArtifactId),
					alias
				))
				.Callback(CheckCallIndex("AddFactorDescriptorRefinesTypeWithArtifact"));

			MockTasks
				.Setup(x => x.AddFactorUsesPrimaryArtifact(
					build,
					ItIsVert<Factor>(VertId),
					It.Is<CreateFabFactor>(c => c.UsesPrimaryArtifactId == pCre.UsesPrimaryArtifactId),
					alias
				))
				.Callback(CheckCallIndex("AddFactorUsesPrimaryArtifact"));

			MockTasks
				.Setup(x => x.AddFactorUsesRelatedArtifact(
					build,
					ItIsVert<Factor>(VertId),
					It.Is<CreateFabFactor>(c => c.UsesRelatedArtifactId == pCre.UsesRelatedArtifactId),
					alias
				))
				.Callback(CheckCallIndex("AddFactorUsesRelatedArtifact"));

			MockTasks
				.Setup(x => x.AddFactorVectorUsesAxisArtifact(
					build,
					ItIsVert<Factor>(VertId),
					It.Is<CreateFabFactor>(c => c.Vector.UsesAxisArtifactId == 
							pCre.Vector.UsesAxisArtifactId),
					alias
				))
				.Callback(CheckCallIndex("AddFactorVectorUsesAxisArtifact"));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ValidationErrorIsOutOfRange() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorSameArtifact() {
			var cre = new CreateFabFactor();
			cre.AssertionType = (byte)FactorAssertion.Id.Opinion;
			cre.UsesPrimaryArtifactId = 12961924;
			cre.UsesRelatedArtifactId = cre.UsesPrimaryArtifactId;

			MockBuild.Setup(x => x.StartSession());

			var co = new CreateFactorOperation();

			TestUtil.Throws<FabPropertyValueFault>(() =>
				co.Execute(MockOpCtx.Object, MockBuild.Object, MockTasks.Object, cre.ToJson())
			);
		}

	}

}