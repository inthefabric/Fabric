using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations;
using Fabric.New.Test.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationAccess {

		private static readonly Logger Log = Logger.Build<TOperationAccess>();

		private const string MemberForOauthToken =
			"g.V('"+DbName.Vert.OauthAccess.Token+"',_P)"+
				".has('"+DbName.Vert.OauthAccess.Expires+"',Tokens.T.gt,_P)"+
			".outE('oaam').inV;";

		private string vToken;
		private long vExpire;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var oa = new OperationAccess(() => (IDataAccess)null, () => 0);
			Assert.Null(oa.ActiveMember, "ActiveMember should be null.");
			Assert.Null(oa.ActiveMemberId, "ActiveMemberId should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, false)]
		[TestCase(MemberType.Id.None, false)]
		[TestCase(MemberType.Id.Invite, false)]
		[TestCase(MemberType.Id.Request, false)]
		[TestCase(MemberType.Id.Admin, true)]
		[TestCase(MemberType.Id.DataProv, true)]
		[TestCase(MemberType.Id.Member, true)]
		[TestCase(MemberType.Id.Owner, true)]
		[TestCase(MemberType.Id.Staff, true)]
		public void SetOauthToken(MemberType.Id? pMemType, bool pSuccess) {
			vToken = "sdfajasldiuf239";
			vExpire = 1020304045060;
			Member mem = (pMemType == null ? null : new Member { MemberType = (byte)pMemType });

			var mockAcc = MockDataAccess.Create(OnExecuteGetMember);
			mockAcc.MockResult.SetupToElement(mem);

			var oa = new OperationAccess(() => mockAcc.Object, () => vExpire);

			TestUtil.CheckThrows<FabOauthFault>(!pSuccess, () => oa.SetOauthToken(vToken));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteGetMember(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			string expect = TestUtil.InsertParamIndexes(MemberForOauthToken, "_P");

			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParams(cmd.Params, "_P", new List<object> { vToken, vExpire });
		}

	}

}