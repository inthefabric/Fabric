﻿using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XChangeMemberType : XBaseWebFunc {

		private long vAppId;
		private long vAssigningMemberId;
		private long vMemberId;
		private long vMemberTypeId;
		
		private SuccessResult vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vAppId = (long)AppGal;
			vAssigningMemberId = (long)SetupUsers.MemberId.GalZach;
			vMemberId = (long)SetupUsers.MemberId.GalMel;
			vMemberTypeId = (long)MemberTypeId.Admin;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeMemberType(
				Tasks, vAppId, vAssigningMemberId, vMemberId, vMemberTypeId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Result.Success should not be null.");

			////

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			Assert.AreNotEqual(0, newMta.MemberTypeAssignId, "Incorrect MemberTypeAssignId.");

			NodeConnections conn = GetNodeConnections(newMta);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMemberTypeAssign, Root>(false, 0);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, vAssigningMemberId);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, vMemberId);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true, vMemberTypeId);

			NewNodeCount = 1;
			NewRelCount = 4;
		}

				
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppIdValue() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberIdValue() {
			vMemberId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAssigningMemberIdValue() {
			vAssigningMemberId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumMemberTypes+1)]
		public void ErrMemberTypeIdValue(long pMemTypeId) {
			vMemberTypeId = pMemTypeId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}