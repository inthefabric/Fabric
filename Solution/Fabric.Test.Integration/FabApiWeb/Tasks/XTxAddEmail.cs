using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddEmail : XWebTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test@test.com")]
		public void Success(string pAddress) {
			IWeaverVarAlias<Email> emailVar;

			Tasks.TxAddEmail(ApiCtx, TxBuild, pAddress, out emailVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddEmail", TxBuild.Transaction);

			////

			Email newEmail = GetVertex<Email>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newEmail, "New Email was not created.");
			Assert.AreEqual(pAddress, newEmail.Address, "Incorrect Address.");
			Assert.AreEqual(32, newEmail.Code.Length, "Incorrect Code length.");
			Assert.AreNotEqual(0, newEmail.Created, "Incorrect Created.");
			Assert.Null(newEmail.Verified, "Incorrect Verified.");
			
			VertexConnections conn = GetVertexConnections(newEmail);
			conn.AssertEdgeCount(0, 0);

			NewVertexCount = 1;
			NewEdgeCount = 0;
		}

	}

}