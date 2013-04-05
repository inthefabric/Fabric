using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateFactor : XBaseModifyFunc {

		private long vPrimArtId;
		private long vRelArtId;
		private long vAssertId;
		private bool vIsDefining;
		private string vNote;

		private long vExpectMemberId;
		private Factor vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vPrimArtId = (long)SetupArtifacts.ArtifactId.App_KinPhoGal;
			vRelArtId = (long)SetupArtifacts.ArtifactId.User_Ellie;
			vAssertId = (long)FactorAssertionId.Guess;
			vIsDefining = true;
			vNote = "note here";

			ApiCtx.SetAppUserId((long)AppGal, (long)UserZach);
			vExpectMemberId = (long)SetupUsers.MemberId.GalZach;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateFactor(Tasks, vPrimArtId, vRelArtId, vAssertId, vIsDefining, vNote);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;
			
			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Factor newFactor = GetNode<Factor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newFactor, "New Factor was not created.");
			Assert.AreEqual(newFactor.FactorId, vResult.FactorId, "Incorrect Result.FactorId.");

			string artId = typeof(Artifact).Name+"Id";

			NodeConnections conn = GetNodeConnections(newFactor);
			conn.AssertRelCount(1, 3);
			conn.AssertRel<MemberCreatesFactor, Member>(false, vExpectMemberId);
			conn.AssertRel<FactorUsesPrimaryArtifact, Artifact>(true, vPrimArtId, artId);
			conn.AssertRel<FactorUsesRelatedArtifact, Artifact>(true, vRelArtId, artId);
			conn.AssertRel<FactorUsesFactorAssertion, FactorAssertion>(true, vAssertId);
			
			NewNodeCount = 1;
			NewRelCount = 4;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumFactorAsserts+1)]
		public void ErrAssertIdRange(long pId) {
			vAssertId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryArtifactIdValue() {
			vPrimArtId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRelatedArtifactIdValue() {
			vRelArtId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAssertIdRange() {
			vAssertId = 0;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(257)]
		public void ErrNameLength(int pLength) {
			vNote = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryArtifactNotFound() {
			vPrimArtId = 9999;
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRelatedArtifactNotFound() {
			vRelArtId = 9999;
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}