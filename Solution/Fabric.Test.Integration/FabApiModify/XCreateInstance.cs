using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateInstance : XBaseModifyFunc {
		
		private string vName;
		private string vDisamb;
		private string vNote;

		private long vExpectMemberId;
		private Instance vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			
			vName = "Name here";
			vDisamb = "Disamb here";
			vNote = "My note here.";

			ApiCtx.SetAppUserId((long)AppGal, (long)UserZach);
			vExpectMemberId = (long)SetupUsers.MemberId.GalZach;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateInstance(Tasks, vName, vDisamb, vNote);
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
			
			Instance newInstance = GetNode<Instance>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newInstance, "New Instance was not created.");
			Assert.AreEqual(newInstance.InstanceId, vResult.InstanceId, "Incorrect Result.InstanceId.");

			NodeConnections conn = GetNodeConnections(newInstance);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, vExpectMemberId);

			NewNodeCount = 1;
			NewRelCount = 1;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(129)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test`")]
		public void ErrNameInvalid(string pName) {
			vName = pName;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(129)]
		public void ErrDisambLength(int pLength) {
			vDisamb = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test`")]
		public void ErrDisambInvalid(string pDisamb) {
			vDisamb = pDisamb;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(257)]
		public void ErrNoteLength(int pLength) {
			vNote = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

	}

}