using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUserOperation :	TCreateOperationBase<
													User, FabUser, CreateFabUser, CreateUserOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabUser pCre) {
			pCre.Name = "TestName";
			pCre.Password = "123456789";

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<User> alias = new WeaverVarAlias<User>("test");

			MockTasks
				.Setup(x => x.FindDuplicateUserNameKey(build, ItIsVert<User>(VertId)))
				.Callback(CheckCallIndex("FindDuplicateUserNameKey"));
			
			MockTasks
				.Setup(x => x.AddUser(build, ItIsVert<User>(VertId), out alias))
				.Callback(CheckCallIndex("AddUser"));
			
			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<User>(VertId), 
					It.Is<CreateFabUser>(c => c.CreatedByMemberId == MemId),
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