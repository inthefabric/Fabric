using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddAccess {

		protected long vAppId;
		protected long? vUserId;
		protected int vExpireSec;
		protected bool vClientOnly;

		protected TestApiContext vContext;

		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAppId = (long)SetupUsers.AppId.KinPhoGal;
			vUserId = (long)SetupUsers.UserId.Penny;
			vExpireSec = 3600;
			vClientOnly = false;

			vContext = new TestApiContext();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo() {
			return new AddAccess(vAppId, vUserId, vExpireSec, vClientOnly).Go(vContext);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void Success(bool pClientOnly) {
			vClientOnly = pClientOnly;

			if ( vClientOnly ) {
				vUserId = null;
			}
			
			FabOauthAccess result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
		}

	}

}