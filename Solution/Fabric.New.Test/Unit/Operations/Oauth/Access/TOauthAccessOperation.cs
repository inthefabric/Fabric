using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;
using Fabric.New.Operations;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Access;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Oauth.Access {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;
		private Mock<IOauthAccessTasks> vMockTasks;

		private string vGrantType;
		private string vClientId;
		private string vSecret;
		private string vCode;
		private string vRefresh;
		private string vRedirUri;
		private OauthAccessOperation vOper;
		private FabOauthAccess vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>();

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vMockTasks = new Mock<IOauthAccessTasks>(MockBehavior.Strict);

			vGrantType = OauthAccessOperation.GrantTypeAc;
			vClientId = "123";
			vSecret = "abcdefgh12345678ABCDEFGH12345678";
			vCode = "12345678ABCDEFGH12345678abcdefgh";
			vRefresh = "zyxwvuts12345678ABCDEFGH12345678";
			vRedirUri = "http://my.redirect.uri/TEST";

			vOper = new OauthAccessOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecute() {
			vExecuteResult = vOper.Execute(vMockOpCtx.Object, vMockTasks.Object, vGrantType, 
				vClientId, vSecret, vCode, vRefresh, vRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertFault(AccessErrors pError, AccessErrorDescs pDesc) {
			var oe = new OauthException(null, null);

			vMockTasks
				.Setup(x => x.NewFault(pError, pDesc))
				.Returns(oe);

			OauthException thrown = TestUtil.Throws<OauthException>(DoExecute);
			Assert.AreEqual(oe, thrown, "Incorrect thrown OauthException.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// All modes
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AllErrGrantCode() {
			vGrantType = "invalid";
			AssertFault(AccessErrors.unsupported_grant_type, AccessErrorDescs.BadGrantType);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(OauthAccessOperation.GrantTypeAc, null)]
		[TestCase(OauthAccessOperation.GrantTypeAc, "")]
		[TestCase(OauthAccessOperation.GrantTypeCc, null)]
		[TestCase(OauthAccessOperation.GrantTypeCc, "")]
		[TestCase(OauthAccessOperation.GrantTypeRt, null)]
		[TestCase(OauthAccessOperation.GrantTypeRt, "")]
		public void AllErrClientSecret(string pGrantType, string pSecret) {
			vGrantType = pGrantType;
			vSecret = pSecret;
			AssertFault(AccessErrors.invalid_request, AccessErrorDescs.NoClientSecret);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(OauthAccessOperation.GrantTypeAc, null)]
		[TestCase(OauthAccessOperation.GrantTypeAc, "")]
		[TestCase(OauthAccessOperation.GrantTypeCc, null)]
		[TestCase(OauthAccessOperation.GrantTypeCc, "")]
		[TestCase(OauthAccessOperation.GrantTypeRt, null)]
		[TestCase(OauthAccessOperation.GrantTypeRt, "")]
		public void AllErrRedirectUri(string pGrantType, string pRedirUri) {
			vRedirUri = pRedirUri;
			AssertFault(AccessErrors.invalid_request, AccessErrorDescs.NoRedirUri);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// Access Code
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void AcErrNoCode(string pCode) {
			vGrantType = OauthAccessOperation.GrantTypeAc;
			vCode = pCode;
			AssertFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcErrBadCode() {
			vGrantType = OauthAccessOperation.GrantTypeAc;
			
			vMockTasks
				.Setup(x => x.GetMemberByGrant(vMockData.Object, vCode))
				.Returns((OauthMember)null);

			AssertFault(AccessErrors.invalid_grant, AccessErrorDescs.BadCode);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcErrRedirMismatch() {
			vGrantType = OauthAccessOperation.GrantTypeAc;

			var om = new OauthMember();
			om.Member = new Member();
			om.Member.OauthGrantRedirectUri = "mismatch";

			vMockTasks
				.Setup(x => x.GetMemberByGrant(vMockData.Object, vCode))
				.Returns(om);

			AssertFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcSuccess() {
			vGrantType = OauthAccessOperation.GrantTypeAc;

			var om = new OauthMember();
			om.AppId = 12344162346;
			om.Member = new Member();
			om.Member.OauthGrantRedirectUri = vRedirUri.ToLower();

			var fabOa = new FabOauthAccess();

			vMockTasks
				.Setup(x => x.GetMemberByGrant(vMockData.Object, vCode))
				.Returns(om);

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, om.AppId, vSecret))
				.Returns(new App());

			vMockTasks
				.Setup(x => x.AddAccess(vMockOpCtx.Object, om.Member, false))
				.Returns(fabOa);

			DoExecute();
			Assert.AreEqual(fabOa, vExecuteResult, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// RefreshToken
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		public void RtErrNoRefresh(string pRefresh) {
			vGrantType = OauthAccessOperation.GrantTypeRt;
			vRefresh = pRefresh;
			AssertFault(AccessErrors.invalid_request, AccessErrorDescs.NoRefresh);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RtErrBadRefresh() {
			vGrantType = OauthAccessOperation.GrantTypeRt;

			vMockTasks
				.Setup(x => x.GetMemberByRefresh(vMockData.Object, vRefresh))
				.Returns((OauthMember)null);

			AssertFault(AccessErrors.invalid_request, AccessErrorDescs.BadRefresh);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RtSuccess() {
			vGrantType = OauthAccessOperation.GrantTypeRt;

			var om = new OauthMember();
			om.AppId = 12344162346;

			var fabOa = new FabOauthAccess();

			vMockTasks
				.Setup(x => x.GetMemberByRefresh(vMockData.Object, vRefresh))
				.Returns(om);

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, om.AppId, vSecret))
				.Returns(new App());

			vMockTasks
				.Setup(x => x.AddAccess(vMockOpCtx.Object, om.Member, false))
				.Returns(fabOa);

			DoExecute();
			Assert.AreEqual(fabOa, vExecuteResult, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// Client Credentials
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("x")]
		[TestCase("0")]
		[TestCase("-1")]
		public void CcErrNoCode(string pClientId) {
			vGrantType = OauthAccessOperation.GrantTypeCc;
			vClientId = pClientId;
			AssertFault(AccessErrors.invalid_client, AccessErrorDescs.NoClientId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("invalid")]
		[TestCase("http:/asdf.com")]
		[TestCase("http::/asdf.com")]
		[TestCase("http//asdf.com")]
		public void CcErrBadRedirUri(string pUri) {
			vGrantType = OauthAccessOperation.GrantTypeCc;
			vRedirUri = pUri;
			AssertFault(AccessErrors.invalid_grant, AccessErrorDescs.BadRedirUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("this|is|a|test")]
		public void CcErrRedirMismatch(string pAppDomains) {
			vGrantType = OauthAccessOperation.GrantTypeCc;

			var app = new App { OauthDomains = pAppDomains };

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, long.Parse(vClientId), vSecret))
				.Returns(app);

			AssertFault(AccessErrors.invalid_grant, AccessErrorDescs.RedirMismatch);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CcSuccess() {
			vGrantType = OauthAccessOperation.GrantTypeCc;

			var app = new App { OauthDomains = "test|my.redirect.uri|another" };
			var mem = new Member();
			var fabOa = new FabOauthAccess();

			vMockTasks
				.Setup(x => x.GetApp(vMockData.Object, long.Parse(vClientId), vSecret))
				.Returns(app);

			vMockTasks
				.Setup(x => x.GetDataProvMemberByApp(vMockData.Object, long.Parse(vClientId)))
				.Returns(mem);

			vMockTasks
				.Setup(x => x.AddAccess(vMockOpCtx.Object, mem, true))
				.Returns(fabOa);

			DoExecute();
			Assert.AreEqual(fabOa, vExecuteResult, "Incorrect result.");
		}

	}

}