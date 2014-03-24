using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateOauthAccessOperation :TCreateOperationBase<
							OauthAccess, FabVertex, CreateFabOauthAccess, CreateOauthAccessOperation> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ExecuteSetup(CreateFabOauthAccess pCre) {
			pCre.Token = "12345678901234567890123456789012";
			pCre.Refresh= "ABcd5678901234567890123456789012";
			pCre.Expires = 13461234623;
			pCre.AuthenticatesMemberId = 1641346431;

			ICreateOperationBuilder build = MockBuild.Object;
			IWeaverVarAlias<OauthAccess> alias = new WeaverVarAlias<OauthAccess>("test");

			MockTasks
				.Setup(x => x.AddOauthAccess(build, ItIsVert<OauthAccess>(VertId), out alias))
				.Callback(CheckCallIndex("AddOauthAccess"));
			
			MockTasks
				.Setup(x => x.AddOauthAccessAuthenticatesMember(
					build,
					ItIsVert<OauthAccess>(VertId),
					It.Is<CreateFabOauthAccess>(
						c => c.AuthenticatesMemberId == pCre.AuthenticatesMemberId),
					It.Is<IWeaverVarAlias<OauthAccess>>(a => a.Name == alias.Name)
				))
				.Callback(CheckCallIndex("AddOauthAccessAuthenticatesMember"));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ValidationErrorIsOutOfRange() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool HasInternalResult() {
			return true;
		}

	}

}