using System;
using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationAuth {

		private static readonly Logger Log = Logger.Build<TOperationAuth>();

		private const string MemberForOauthToken =
			"g.V('"+DbName.Vert.OauthAccess.Token+"',_P)"+
				".has('"+DbName.Vert.OauthAccess.Expires+"',Tokens.T.gt,_P)"+
			".outE('oaam').inV;";

		private string vToken;
		private long vExpire;
		private long vMemId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vToken = "sdfajasldiuf239";
			vExpire = 1020304045060;
			vMemId = 42363462346;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var oa = new OperationAuth(() => (IDataAccess)null, () => 0);
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
			Member mem = null;

			if ( pMemType != null ) {
				mem = new Member();
				mem.VertexId = vMemId;
				mem.MemberType = (byte)pMemType;
			}

			var mockAcc = MockDataAccess.Create(OnExecuteGetMember);
			mockAcc.MockResult.SetupToElement(mem);

			var oa = new OperationAuth(() => mockAcc.Object, () => vExpire);

			TestUtil.CheckThrows<FabOauthFault>(!pSuccess, () => oa.SetOauthToken(vToken));
			Assert.AreEqual(mem, oa.ActiveMember, "Incorrect ActiveMember.");

			if ( mem == null ) {
				Assert.Null(oa.ActiveMemberId, "ActiveMemberId should be null.");
			}
			else {
				Assert.AreEqual(mem.VertexId, oa.ActiveMemberId, "Incorrect ActiveMemberId.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetOauthTokenDuplicate() {
			Member mem = new Member { MemberType = (byte)MemberType.Id.Admin };

			var mockAcc = MockDataAccess.Create(OnExecuteGetMember);
			mockAcc.MockResult.SetupToElement(mem);

			var oa = new OperationAuth(() => mockAcc.Object, () => vExpire);
			oa.SetOauthToken(vToken);
			TestUtil.Throws<Exception>(() => oa.SetOauthToken("duplicate"));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetOauthTokenNull() {
			var oa = new OperationAuth(() => null, () => 123);
			oa.SetOauthToken(null);
			Assert.Null(oa.ActiveMember, "ActiveMember should be null.");
			Assert.Null(oa.ActiveMemberId, "ActiveMemberId should be null.");
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