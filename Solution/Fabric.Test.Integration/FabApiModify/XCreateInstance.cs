﻿using Fabric.Api.Modify;
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

			Artifact newArtifact = GetNode<Artifact>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newArtifact, "New Artifact was not created.");
			
			NodeConnections conn = GetNodeConnections(newInstance);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsInstance, Root>(false, 0);
			conn.AssertRel<InstanceHasArtifact, Artifact>(true, newArtifact.ArtifactId);
			
			conn = GetNodeConnections(newArtifact);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<InstanceHasArtifact, Instance>(false, newInstance.InstanceId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, vExpectMemberId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.Instance);

			NewNodeCount = 2;
			NewRelCount = 5;
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

	}

}