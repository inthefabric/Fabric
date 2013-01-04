using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessClientDataProv : TOauthAccessClientCred {

		private string vDataProvId;
		private long vDataProvIdLong;

		private User vUserResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vDataProvIdLong = 9797;
			vDataProvId = vDataProvIdLong+"";

			vUserResult = new User();
			vUserResult.UserId = vDataProvIdLong;

			vMockTasks
				.Setup(x => x.GetDataProv(vAppId, vDataProvIdLong, vMockCtx.Object))
				.Returns(vUserResult);

			vMockTasks
				.Setup(x => x.AddAccess(vAppId, vDataProvIdLong, 3600, false, vMockCtx.Object))
				.Returns(vAccessResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GrantType { get { return "client_dataprov"; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			InnerTestGo();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess InnerTestGo() {
			var func = new OauthAccessClientDataProv(
				vGrantType, vRedirUri, vClientSecret, vClientId, vDataProvId, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public override void Success() {
			FabOauthAccess result = InnerTestGo();
			Assert.AreEqual(vAccessResult, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("x")]
		[TestCase("0")]
		[TestCase("-1")]
		public void ErrDataProvId(string pDataProvId) {
			vDataProvId = pDataProvId;
			CheckOauthEx(TestGo, AccessErrors.invalid_client, AccessErrorDescs.NoDataProvId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullDataProvUser() {
			vUserResult = null;

			vMockTasks
				.Setup(x => x.GetDataProv(vAppId, vDataProvIdLong, vMockCtx.Object))
				.Returns(vUserResult);

			CheckOauthEx(TestGo, AccessErrors.unauthorized_client, AccessErrorDescs.BadDataProvId);
		}

	}

}