using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
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

			vOutUrlVar = GetTxVar<Url>("URL");
			vResultUrl = new Url();

			MockTasks
				.Setup(x => x.TxAddUrl(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vAbsoluteUrl,
						vName,
						It.IsAny<IWeaverVarAlias<Root>>(),
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

			string expectPartial = 
				"g.V('RootId',0)[0].each{_V0=g.v(it)};"+
				"g.V('MemberId',"+ApiCtxMember.MemberId+"L)[0].each{_V1=g.v(it)};"+
				"URL;";

			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
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
			MockValidator.Verify(x => x.UserName(vName, CreateUrl.NameParam), Times.Once());

			IWeaverVarAlias<Artifact> artVar;

			MockTasks
				.Verify(x => x.TxAddArtifact<Url, UrlHasArtifact>(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						ArtifactTypeId.Url,
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutUrlVar,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out artVar
					),
					Times.Once()
				);
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
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
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