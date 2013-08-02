using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

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

			OauthAccess clearOa = GetVertex<OauthAccess>((long)pClearedAccessId);
			Assert.NotNull(clearOa, "Target OauthAccess is missing.");
			Assert.NotNull(clearOa.Token, "Target OauthAccess must have a Token value.");
			Assert.NotNull(clearOa.Refresh, "Target OauthAccess must have a Refresh value.");

			int tokenCount = CountTokens();

			////

			FabOauthAccess result = TestGo();
			Assert.NotNull(result, "Result should be filled.");

			OauthAccess newOa = GetVertexByProp<OauthAccess>(x => x.Token, "'"+result.AccessToken+"'");
			Assert.NotNull(newOa, "New OauthAccess was not created.");

			VertexConnections conn = GetVertexConnections(newOa);
			conn.AssertEdgeCount(0, (vClientOnly ? 1 : 2));

			if ( vClientOnly ) {
				conn.AssertEdge<OauthAccessUsesApp, App>(true, vAppId);
			}
			else {
				Assert.NotNull(vUserId, "vUserId cannot be null.");
				conn.AssertEdge<OauthAccessUsesApp, App>(true, vAppId);
				conn.AssertEdge<OauthAccessUsesUser, User>(true, (long)vUserId);
			}

			////

			clearOa = GetVertex<OauthAccess>((long)pClearedAccessId);
			Assert.NotNull(clearOa, "Target OauthAccess was deleted.");
			Assert.Null(clearOa.Token, "Target OauthAccess.Token was not cleared.");
			Assert.Null(clearOa.Refresh, "Target OauthAccess.Refresh was not cleared.");

			int updatedTokenCount = CountTokens();
			Assert.AreEqual(tokenCount+1, updatedTokenCount, "Incorrect updated Token count.");

			NewVertexCount = 1;
			NewEdgeCount = (vClientOnly ? 1 : 2);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private int CountTokens() {
			IWeaverQuery q = GetVertexByPropQuery<OauthAccess>(
				".hasNot('"+PropDbName.OauthAccess_Token+"').count()");
			return ApiCtx.ExecuteForTest(q).ToIntAt(0, 0);
		}

	}

}