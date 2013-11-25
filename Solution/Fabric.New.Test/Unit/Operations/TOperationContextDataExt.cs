using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Operations;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationContextDataExt {

		private static readonly Logger Log = Logger.Build<TOperationContextDataExt>();

		/*private const string MemberForOauthToken =
			"g.V('"+DbName.Vert.OauthAccess.Token+"',_P)"+
				".has('"+DbName.Vert.OauthAccess.Expires+"',Tokens.T.gt,_P)"+
			".outE('oaam').inV;";*/


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			var mockAcc = MockDataAccess.Create(mda => Log.Debug("HERE!"));

			var mockFac = new Mock<IDataAccessFactory>();
			mockFac.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
				.Returns(mockAcc.Object);

			var oc = new OperationContext(mockFac.Object, null, null, x => null);

			IWeaverQuery q = new WeaverQuery();
			q.FinalizeQuery("g.v(1)");

			var mockCtx = new Mock<IOperationContext>();
			mockCtx.Object.Execute(q, "TEST");
		}

		/*--------------------------------------------------------------------------------------------* /
		private void OnExecuteGetMember(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			string expect = TestUtil.InsertParamIndexes(MemberForOauthToken, "_P");

			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParams(cmd.Params, "_P", new List<object> { vToken, vExpire });
		}*/

	}

}