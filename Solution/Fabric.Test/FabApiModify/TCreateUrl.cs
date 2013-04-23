using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUrl : TBaseModifyFunc {

		private string vAbsoluteUrl;
		private string vName;

		private IWeaverVarAlias<Url> vOutUrlVar;
		private Url vResultUrl;
		private Url vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.mywebsite.com";
			vName = "My Web Site";

			vOutUrlVar = GetTxVar<Url>("AU");
			vResultUrl = new Url();

			MockTasks
				.Setup(x => x.TxAddUrl(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vAbsoluteUrl,
						vName,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out vOutUrlVar
					)
				);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			MockApiCtx
				.Setup(x => x.DbSingle<Url>("CreateUrlTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateUrlTx(q));

			SetUpMember(1, 2, new Member { MemberId = 234623 });
		}

		/*--------------------------------------------------------------------------------------------*/
		private Url CreateUrlTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = 
				"_V0=g.V('"+PropDbName.Member_MemberId+"',_TP0).next();"+
				"AU;";

			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", ApiCtxMember.MemberId);
			return vResultUrl;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateUrl(MockTasks.Object, vAbsoluteUrl, vName);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.AreEqual(vResultUrl, vResult, "Incorrect Result.");

			MockValidator.Verify(x => x.UrlAbsoluteUrl(vAbsoluteUrl,
				CreateUrl.AbsoluteUrlParam), Times.Once());
			MockValidator.Verify(x => x.UrlName(vName, CreateUrl.NameParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x")]
		[TestCase("://")]
		[TestCase("x://")]
		[TestCase("http://")]
		[TestCase("http//")]
		[TestCase("http:/")]
		[TestCase("http//:www.test.com")]
		public void ErrInvalidUrl(string pUrl) {
			vAbsoluteUrl = pUrl;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateUrl() {
			MockTasks
				.Setup(x => x.GetUrlByAbsoluteUrl(MockApiCtx.Object, vAbsoluteUrl))
				.Returns(new Url());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			SetUpMember(1, 2, null);
			TestUtil.CheckThrows<FabMembershipFault>(true, TestGo);
		}

	}

}