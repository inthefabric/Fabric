using Fabric.Api.Modify;
using Fabric.Db.Data;
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
	public class XCreateUrl : XBaseModifyFunc {
		
		private string vAbsoluteUrl;
		private string vName;

		private long vExpectMemberId;
		private Url vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			
			vAbsoluteUrl = "http://www.mywebsite.com";
			vName = "My Web Site";

			ApiCtx.SetAppUserId((long)AppGal, (long)UserZach);
			vExpectMemberId = (long)SetupUsers.MemberId.GalZach;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateUrl(Tasks, vAbsoluteUrl, vName);
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
			
			Url newUrl = GetNode<Url>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newUrl, "New Url was not created.");
			Assert.AreEqual(newUrl.UrlId, vResult.UrlId, "Incorrect Result.UrlId.");

			Artifact newArtifact = GetNode<Artifact>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newArtifact, "New Artifact was not created.");
			
			NodeConnections conn = GetNodeConnections(newUrl);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsUrl, Root>(false, 0);
			conn.AssertRel<UrlHasArtifact, Artifact>(true, newArtifact.ArtifactId);
			
			conn = GetNodeConnections(newArtifact);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<UrlHasArtifact, Url>(false, newUrl.UrlId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, vExpectMemberId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.Url);

			NewNodeCount = 2;
			NewRelCount = 5;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAbsoluteUrlNull() {
			vAbsoluteUrl = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(2049)]
		public void ErrAbsoluteUrlLength(int pLength) {
			vAbsoluteUrl = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAbsoluteUrlDuplicate() {
			vAbsoluteUrl = "HTTP://zachkinstner.COM";
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
		[TestCase(129)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

	}

}