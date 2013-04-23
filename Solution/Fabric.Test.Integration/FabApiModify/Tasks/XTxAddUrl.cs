using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddUrl : XModifyTasks {

		//Check for duplicate URL occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://www.web.com", "Web Page")]
		public void Success(string pAbsoluteUrl, string pName) {
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Url> urlVar;
			var mem = new Member { MemberId = (long)SetupUsers.MemberId.GalZach };

			TxBuild.GetNode(mem, out memVar);
			Tasks.TxAddUrl(ApiCtx, TxBuild, pAbsoluteUrl, pName, memVar, out urlVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddUrl", TxBuild.Transaction);

			////

			Url newUrl = GetNode<Url>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newUrl, "New Url was not created.");
			Assert.AreNotEqual(0, newUrl.UrlId, "Incorrect UrlId.");
			Assert.AreEqual(pAbsoluteUrl, newUrl.AbsoluteUrl, "Incorrect AbsolueUrl.");
			Assert.AreEqual(pName, newUrl.Name, "Incorrect Name.");

			NodeConnections conn = GetNodeConnections(newUrl);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}