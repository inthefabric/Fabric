﻿using System;
using System.Collections.Generic;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Cache;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Operations;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationAuth {

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
			var oa = new OperationAuth(null, () => (IDataAccess)null, () => 0);
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
		public void SetOauthTokenAndExecuteOauth(MemberType.Id? pMemType, bool pSuccess) {
			const int expInSec = 99;
			Member mem = null;

			if ( pMemType != null ) {
				mem = new Member();
				mem.VertexId = vMemId;
				mem.MemberType = (byte)pMemType;
				mem.OauthGrantExpires = new DateTime(vExpire).AddSeconds(expInSec).Ticks;
			}

			var mockAcc = MockDataAccess.Create(OnExecuteGetMember);
			mockAcc.MockResult.SetupToElement(mem);

			var mockCache = new Mock<IMemCache>(MockBehavior.Strict);
			mockCache.Setup(x => x.FindOauthMember(vToken)).Returns((Member)null);
			mockCache.Setup(x => x.AddOauthMember(vToken, mem, expInSec));

			var oa = new OperationAuth(mockCache.Object, () => mockAcc.Object, () => vExpire);
			oa.SetOauthToken(vToken);

			TestUtil.CheckThrows<FabOauthFault>(!pSuccess, oa.ExecuteOauth);

			if ( pSuccess ) {
				Assert.AreEqual(mem.VertexId, oa.ActiveMemberId, "Incorrect ActiveMemberId.");
				mockCache.Verify(x => x.AddOauthMember(vToken, mem, expInSec), Times.Once);
			}
			else {
				Assert.Null(oa.ActiveMemberId, "ActiveMemberId should be null.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetOauthTokenAndExecuteCached() {
			var mem = new Member();
			mem.VertexId = 12523;
			mem.MemberType = (byte)MemberType.Id.Member;

			var mockCache = new Mock<IMemCache>(MockBehavior.Strict);
			mockCache.Setup(x => x.FindOauthMember(vToken)).Returns(mem);

			var oa = new OperationAuth(mockCache.Object, () => null, () => 0);
			oa.SetOauthToken(vToken);

			oa.ExecuteOauth();

			Assert.AreEqual(mem.VertexId, oa.ActiveMemberId, "Incorrect ActiveMemberId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetOauthTokenDuplicate() {
			Member mem = new Member { MemberType = (byte)MemberType.Id.Admin };

			var mockAcc = MockDataAccess.Create(OnExecuteGetMember);
			mockAcc.MockResult.SetupToElement(mem);

			var oa = new OperationAuth(null, () => mockAcc.Object, () => vExpire);
			oa.SetOauthToken(vToken);
			TestUtil.Throws<Exception>(() => oa.SetOauthToken("duplicate"));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetOauthTokenNull() {
			var oa = new OperationAuth(null, () => null, () => 123);
			oa.SetOauthToken(null);
			Assert.Null(oa.ActiveMemberId, "ActiveMemberId should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteGetMember(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			string expect = TestUtil.InsertParamIndexes(MemberForOauthToken, "_P");

			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParams(cmd.Params, "_P", new List<object> { vToken, vExpire });
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetCookieUserId() {
			const long userId = 1234325;

			var oa = new OperationAuth(null, () => (IDataAccess)null, () => 0);
			oa.SetCookieUserId(userId);

			Assert.AreEqual(userId, oa.CookieUserId, "Incorrect CookieUserId.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetFabricActiveMember() {
			var oa = new OperationAuth(null, () => (IDataAccess)null, () => 0);
			oa.SetFabricActiveMember();

			Assert.AreEqual((long)SetupMemberId.FabFabData, oa.ActiveMemberId,
				"Incorrect ActiveMemberId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetFabricActiveMemberErrAlreadySet() {
			var oa = new OperationAuth(null, () => (IDataAccess)null, () => 0);
			oa.SetFabricActiveMember();

			TestUtil.Throws<Exception>(oa.SetFabricActiveMember);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RemoveFabricActiveMember() {
			var oa = new OperationAuth(null, () => (IDataAccess)null, () => 0);
			oa.SetFabricActiveMember();
			oa.RemoveFabricActiveMember();

			Assert.Null(oa.ActiveMemberId, "ActiveMemberId should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RemoveFabricActiveMemberErrNotSet() {
			var oa = new OperationAuth(null, () => (IDataAccess)null, () => 0);

			TestUtil.Throws<Exception>(oa.RemoveFabricActiveMember);
		}

	}

}