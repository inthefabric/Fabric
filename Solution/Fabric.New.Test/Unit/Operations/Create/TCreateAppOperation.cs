using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateAppOperation :TCreateOperationBase<
														App, FabApp, CreateFabApp, CreateAppOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabApp pCre) {
			pCre.Name = "Test Name";
			pCre.Secret = "12345678901234567890123456789012";

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<App> alias = new WeaverVarAlias<App>("test");

			MockTasks
				.Setup(x => x.FindDuplicateAppNameKey(build, ItIsVert<App>(VertId)))
				.Callback(CheckCallIndex("FindDuplicateAppNameKey"));
			
			MockTasks
				.Setup(x => x.AddApp(build, ItIsVert<App>(VertId), out alias))
				.Callback(CheckCallIndex("AddApp"));
			
			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<App>(VertId), 
					It.Is<CreateFabApp>(c => c.CreatedByMemberId == MemId),
					It.Is<IWeaverVarAlias<Artifact>>(a => a.Name == alias.Name)
				))
				.Callback(CheckCallIndex("AddArtifactCreatedByMember"));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return true;
		}

	}

}