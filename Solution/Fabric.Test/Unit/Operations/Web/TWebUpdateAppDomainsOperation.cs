using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Operations;
using Fabric.Operations.Web;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Web {

	/*================================================================================================*/
	[TestFixture]
	public class TWebUpdateAppDomainsOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private App vApp;
		private WebUpdateAppDomainsOperation vOper;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vApp = new App();
			vApp.VertexId = 1234125;

			vMockData = new Mock<IOperationData>(MockBehavior.Strict);
			vMockData.Setup(x => x.GetVertexById<App>(vApp.VertexId)).Returns(vApp);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vOper = new WebUpdateAppDomainsOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SetupUpdateQuery(string pExpectDomains) {
			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{"+
						"it.setProperty('"+DbName.Vert.App.OauthDomains+"',_P);"+
					"};";

			var expectParams = new List<object> {
				vApp.VertexId,
				pExpectDomains
			};

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "Web-UpdateAppDomains"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(vApp);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, "new.com", "new.com")]
		[TestCase("", "new.com", "new.com")]
		[TestCase("justOne.com", "andAnother.com", "justOne.com|andAnother.com")]
		[TestCase("first.com|sec.com|third.com", "4.com", "first.com|sec.com|third.com|4.com")]
		public void SuccessAdd(string pAppDomains, string pNewDomain, string pExpectDomains) {
			vApp.OauthDomains = pAppDomains;
			SetupUpdateQuery(pExpectDomains);

			App result = vOper.ExecuteAdd(vMockOpCtx.Object, vApp.VertexId, pNewDomain);

			Assert.AreEqual(vApp, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, "new", null)]
		[TestCase("", "new", "")]
		[TestCase("justOne.com|andAnother.com", "andAnother.com", "justOne.com")]
		[TestCase("justOne.com|andAnother.com", "justOne.com", "andAnother.com")]
		[TestCase("first.com|sec.com|third.com|4.com", "4.com", "first.com|sec.com|third.com")]
		[TestCase("first.com|sec.com|third.com|4.com", "first.com", "sec.com|third.com|4.com")]
		[TestCase("first.com|sec.com|third.com|4.com", "sec.com", "first.com|third.com|4.com")]
		public void SuccessRemove(string pAppDomains, string pNewDomain, string pExpectDomains) {
			vApp.OauthDomains = pAppDomains;
			SetupUpdateQuery(pExpectDomains);

			App result = vOper.ExecuteRemove(vMockOpCtx.Object, vApp.VertexId, pNewDomain);

			Assert.AreEqual(vApp, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("a|b|c|d", "e")]
		[TestCase("a|b|c|d|ee", "e")]
		[TestCase("a|b|c|d|e", "ee")]
		[TestCase("a|b|c", "ab")]
		[TestCase("a|b|c", "B")]
		public void ErrDomainNotFound(string pAppDomains, string pNewDomain) {
			vApp.OauthDomains = pAppDomains;

			TestUtil.Throws<FabPropertyValueFault>(() => 
				vOper.ExecuteRemove(vMockOpCtx.Object, vApp.VertexId, pNewDomain));
		}

	}

}