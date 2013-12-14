using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateEmailOperation :TCreateOperationBase<
											Email, FabVertex, CreateFabEmail, CreateEmailOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabEmail pCre) {
			pCre.Address = "testName@Address.com";
			pCre.Code = "12345678901234567890123456789012";
			pCre.Verified = false;
			pCre.UsedByArtifactId = 1641346431;

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<Email> alias = new WeaverVarAlias<Email>("test");

			MockTasks
				.Setup(x => x.AddEmail(build, ItIsVert<Email>(VertId), out alias))
				.Callback(CheckCallIndex("AddEmail"));
			
			MockTasks
				.Setup(x => x.AddEmailUsedByArtifact(
					build,
					ItIsVert<Email>(VertId),
					It.Is<CreateFabEmail>(c => c.UsedByArtifactId == pCre.UsedByArtifactId),
					It.Is<IWeaverVarAlias<Email>>(a => a.Name == alias.Name)
				))
				.Callback(CheckCallIndex("AddEmailUsedByArtifact"));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return true;
		}

	}

}