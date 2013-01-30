using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAddAccess : IntegTestBase {

		private long vAppId;
		private long? vUserId;
		private int vExpireSec;
		private bool vClientOnly;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = -1;
			vUserId = -1;
			vExpireSec = 3600;
			vClientOnly = false;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo() {
			return new AddAccess(vAppId, vUserId, vExpireSec, vClientOnly).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, SetupOauth.OauthAccessId.GalZach)]
		[TestCase(AppGal, UserEllie, SetupOauth.OauthAccessId.GalEllie_Past)]
		[TestCase(AppGal, UserGal, SetupOauth.OauthAccessId.GalGalData)]
		[TestCase(AppGal, null, SetupOauth.OauthAccessId.Gal)]
		[TestCase(AppBook, null, SetupOauth.OauthAccessId.Book)]
		public void Go(SetupUsers.AppId pAppId, SetupUsers.UserId? pUserId,
														SetupOauth.OauthAccessId pClearedAccessId) {
			vClientOnly = (pUserId == null);
			vAppId = (long)pAppId;
			vUserId = (pUserId == null ? (long?)null : (long)pUserId);

			////

			OauthAccess clearOa = GetNode<OauthAccess>((long)pClearedAccessId);
			Assert.NotNull(clearOa, "Target OauthAccess is missing.");
			Assert.NotNull(clearOa.Token, "Target OauthAccess must have a Token value.");
			Assert.NotNull(clearOa.Refresh, "Target OauthAccess must have a Refresh value.");

			int tokenCount = CountTokens();

			////

			FabOauthAccess result = TestGo();
			Assert.NotNull(result, "Result should be filled.");

			OauthAccess newOa = GetNodeByProp<OauthAccess>(x => x.Token, "'"+result.AccessToken+"'");
			Assert.NotNull(newOa, "New OauthAccess was not created.");

			NodeConnections conn = GetNodeConnections(newOa);
			conn.AssertRelCount(1, (vClientOnly ? 1 : 2));
			conn.AssertRel<RootContainsOauthAccess, Root>(false, 0);

			if ( vClientOnly ) {
				conn.AssertRel<OauthAccessUsesApp, App>(true, vAppId);
			}
			else {
				Assert.NotNull(vUserId, "vUserId cannot be null.");
				conn.AssertRel<OauthAccessUsesApp, App>(true, vAppId);
				conn.AssertRel<OauthAccessUsesUser, User>(true, (long)vUserId);
			}

			////

			clearOa = GetNode<OauthAccess>((long)pClearedAccessId);
			Assert.NotNull(clearOa, "Target OauthAccess was deleted.");
			Assert.AreEqual("", clearOa.Token, "Target OauthAccess.Token was not cleared.");
			Assert.AreEqual("", clearOa.Refresh, "Target OauthAccess.Refresh was not cleared.");

			int updatedTokenCount = CountTokens();
			Assert.AreEqual(tokenCount+1, updatedTokenCount, "Incorrect updated Token count.");

			NewNodeCount = 1;
			NewRelCount = (vClientOnly ? 2 : 3);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private int CountTokens() {
			IWeaverQuery q = WeaverTasks.BeginPath<Root>(x => x.RootId, 0).BaseNode
				.ContainsOauthAccessList.ToOauthAccess
					.Has(x => x.Token, WeaverFuncHasOp.EqualTo, "")
					.Count()
				.End();

			IApiDataAccess data = ApiCtx.DbData("TEST.CountTokens", q);
			return int.Parse(data.Result.Text);
		}

	}

}