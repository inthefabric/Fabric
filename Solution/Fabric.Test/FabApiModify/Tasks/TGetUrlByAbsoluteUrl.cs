using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUrlByAbsoluteUrl : TModifyTasks {

		private const string Query = "g.V('"+PropDbName.Url_AbsoluteUrl+"',_P0);";

		private string vAbsoluteUrl;
		private Url vUrlResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.DUPlicate.com";
			vUrlResult = new Url();

			var mockRes = new Mock<IDataResult>();
			mockRes.Setup(x => x.ToElement<Url>()).Returns(vUrlResult);

			MockDataList.Add(MockDataAccess.Create(OnExecute, mockRes));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAbsoluteUrl.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Url result = Tasks.GetUrlByAbsoluteUrl(MockApiCtx.Object, vAbsoluteUrl);

			AssertDataExecution();
			Assert.AreEqual(vUrlResult, result, "Incorrect Result.");
		}

	}

}