using Fabric.New.Api.Objects;
using Fabric.New.Domain;
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
	public class TCreateInstanceOperation :	TCreateOperationBase<
								Instance, FabInstance, CreateFabInstance, CreateInstanceOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabInstance pCre) {
			pCre.Name = "Test Name";
			pCre.Disamb = "Test Disamb";
			pCre.Note = "Test Note";

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<Instance> alias = new WeaverVarAlias<Instance>("test");

			MockTasks
				.Setup(x => x.AddInstance(build, ItIsVert<Instance>(VertId), out alias))
				.Callback(CheckCallIndex("AddInstance"));
			
			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<Instance>(VertId), 
					It.Is<CreateFabInstance>(c => c.CreatedByMemberId == MemId),
					It.Is<IWeaverVarAlias<Artifact>>(a => a.Name == alias.Name)
				))
				.Callback(CheckCallIndex("AddArtifactCreatedByMember"));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public override void ValidationError() {
			var cre = new CreateFabInstance();
			cre.Name = new string('x', 999);

			var co = new CreateInstanceOperation();

			TestUtil.Throws<FabPropertyLengthFault>(() =>
				co.Execute(MockOpCtx.Object, null, null, cre.ToJson())
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorDisambWithoutName() {
			var cre = new CreateFabInstance();
			cre.Disamb = "Can't be non-null!";

			MockBuild.Setup(x => x.StartSession());

			var co = new CreateInstanceOperation();

			TestUtil.Throws<FabPropertyValueFault>(() =>
				co.Execute(MockOpCtx.Object, MockBuild.Object, MockTasks.Object, cre.ToJson())
			);
		}

	}

}