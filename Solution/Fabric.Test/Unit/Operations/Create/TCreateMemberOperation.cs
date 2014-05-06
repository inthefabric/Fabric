using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateMemberOperation :TCreateOperationBase<
														Member, FabMember, CreateFabMember, CreateMemberOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		protected override void ExecuteSetup(CreateFabMember pCre) {
			pCre.DefinedByAppId = 4362346234;
			pCre.DefinedByUserId = 6326234;
			pCre.Type = (byte)MemberType.Id.Staff;

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<Member> alias = new WeaverVarAlias<Member>("test");

			MockTasks
				.Setup(x => x.FindDuplicateMember(build, pCre.DefinedByUserId, pCre.DefinedByAppId))
				.Callback(CheckCallIndex("FindDuplicateMemberNameKey"));
			
			MockTasks
				.Setup(x => x.AddMember(build, ItIsVert<Member>(VertId), out alias))
				.Callback(CheckCallIndex("AddMember"));
			
			MockTasks
				.Setup(x => x.AddMemberDefinedByApp(
					build,
					ItIsVert<Member>(VertId), 
					It.Is<CreateFabMember>(c => c.DefinedByAppId == pCre.DefinedByAppId),
					alias
				))
				.Callback(CheckCallIndex("AddMemberDefinedByApp"));

			MockTasks
				.Setup(x => x.AddMemberDefinedByUser(
					build,
					ItIsVert<Member>(VertId),
					It.Is<CreateFabMember>(c => c.DefinedByUserId == pCre.DefinedByUserId),
					alias
				))
				.Callback(CheckCallIndex("AddMemberDefinedByUser"));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ValidationErrorIsOutOfRange() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return false;
		}

	}

}