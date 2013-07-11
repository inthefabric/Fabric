﻿using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateUrl : XBaseModifyFunc {
		
		private string vPath;
		private string vName;

		private long vExpectMemberId;
		private Url vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			
			vPath = "http://www.mywebsite.com";
			vName = "My Web Site";

			ApiCtx.SetAppUserId((long)AppGal, (long)UserZach);
			vExpectMemberId = (long)SetupUsers.MemberId.GalZach;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateUrl(Tasks, vPath, vName);
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
			
			Url newUrl = GetVertex<Url>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newUrl, "New Url was not created.");
			Assert.AreEqual(newUrl.ArtifactId, vResult.ArtifactId, "Incorrect Result.ArtifactId.");

			VertexConnections conn = GetVertexConnections(newUrl);
			conn.AssertEdgeCount(1, 0);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, vExpectMemberId);

			NewVertexCount = 1;
			NewEdgeCount = 1;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPathNull() {
			vPath = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(2049)]
		public void ErrPathLength(int pLength) {
			vPath = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPathDuplicate() {
			vPath = "HTTP://zachkinstner.COM";
			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameNull() {
			vName = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(129)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

	}

}