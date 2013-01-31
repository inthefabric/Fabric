using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateClass : XBaseModifyFunc {
		
		private string vName;
		private string vDisamb;
		private string vNote;

		private long vExpectMemberId;
		private Class vResult;
		
	
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
			var func = new CreateClass(Tasks, vName, vDisamb, vNote);
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
			
			Class newClass = GetNode<Class>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newClass, "New Class was not created.");
			Assert.AreEqual(newClass.ClassId, vResult.ClassId, "Incorrect Result.ClassId.");

			Artifact newArtifact = GetNode<Artifact>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newArtifact, "New Artifact was not created.");
			
			NodeConnections conn = GetNodeConnections(newClass);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsClass, Root>(false, 0);
			conn.AssertRel<ClassHasArtifact, Artifact>(true, newArtifact.ArtifactId);
			
			conn = GetNodeConnections(newArtifact);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<ClassHasArtifact, Class>(false, newClass.ClassId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, vExpectMemberId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.Class);

			NewNodeCount = 2;
			NewRelCount = 5;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameNull() {
			vName = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
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
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
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
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(257)]
		public void ErrNoteLength(int pLength) {
			vNote = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("human", null)]
		[TestCase("LOCATION", "GeoGraphiCal")]
		public void ErrNameDisambDuplicate(string pName, string pDisamb) {
			vName = pName;
			vDisamb = pDisamb;
			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}

	}

}