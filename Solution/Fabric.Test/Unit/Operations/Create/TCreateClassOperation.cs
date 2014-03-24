using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateClassOperation : TCreateOperationBase<
												Class, FabClass, CreateFabClass, CreateClassOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabClass pCre) {
			pCre.Name = "Test Name";
			pCre.Disamb = "Test Disamb";
			pCre.Note = "Test Note";

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<Class> alias = new WeaverVarAlias<Class>("test");

			MockTasks
				.Setup(x => x.FindDuplicateClass(build, pCre.Name.ToLower(), pCre.Disamb.ToLower()))
				.Callback(CheckCallIndex("FindDuplicateClass"));
			
			MockTasks
				.Setup(x => x.AddClass(build, ItIsVert<Class>(VertId), out alias))
				.Callback(CheckCallIndex("AddClass"));
			
			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<Class>(VertId), 
					It.Is<CreateFabClass>(c => c.CreatedByMemberId == MemId),
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