using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUrlOperation :TCreateOperationBase<
														Url, FabUrl, CreateFabUrl, CreateUrlOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabUrl pCre) {
			pCre.Name = "Test Name";
			pCre.FullPath = "http://test.FullPath.com";

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<Url> alias = new WeaverVarAlias<Url>("test");

			MockTasks
				.Setup(x => x.FindDuplicateUrlFullPath(build, ItIsVert<Url>(VertId)))
				.Callback(CheckCallIndex("FindDuplicateUrlFullPath"));
			
			MockTasks
				.Setup(x => x.AddUrl(build, ItIsVert<Url>(VertId), out alias))
				.Callback(CheckCallIndex("AddUrl"));
			
			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<Url>(VertId), 
					It.Is<CreateFabUrl>(c => c.CreatedByMemberId == MemId),
					It.Is<IWeaverVarAlias<Artifact>>(a => a.Name == alias.Name)
				))
				.Callback(CheckCallIndex("AddArtifactCreatedByMember"));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return false;
		}

	}

}