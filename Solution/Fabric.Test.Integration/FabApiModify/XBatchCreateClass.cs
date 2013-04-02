using System.Collections.Generic;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Modify;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;
using ServiceStack.Text;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XBatchCreateClass : XBaseModifyFunc {
		
		private IList<FabBatchNewClass> vClasses;
		private string vClassesJson;

		private IList<FabBatchResult> vResults;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vClasses = new List<FabBatchNewClass>(new[] {
				new FabBatchNewClass { 
					BatchId = 100, Name = "Test1", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 101, Name = "Test2", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 102, Name = "Test3", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 103, Name = "Test4", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 104, Name = "Test5", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 110, Name = null, Disamb = "1234", Note = "This is my note." }, //null
				new FabBatchNewClass { 
					BatchId = 111, Name = "Test2a", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 112, Name = "Test3a", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 113, Name = "Test4a", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 114, Name = "Test5a", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 120, Name = "Test1b", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 121, Name = "Test2", Disamb = "1234", Note = "This is my note." }, //dup
				new FabBatchNewClass { 
					BatchId = 122, Name = "Test3b", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 123, Name = "Test4b", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 124, Name = "Test5b", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 130, Name = "Test1c", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 131, Name = "Test2c", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 132, Name = "Test3c", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 133, Name = "Test4c", Disamb = "1234", Note = "This is my note." },
				new FabBatchNewClass { 
					BatchId = 134, Name = "Test5c", Disamb = "1234", Note = "This is my note." }
			});

			vClassesJson = vClasses.ToJson();

			ApiCtx.SetAppUserId((long)AppGal, (long)UserZach);
			//vExpectMemberId = (long)SetupUsers.MemberId.GalZach;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateClassBatch(Tasks, vClassesJson);
			vResults = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;
			
			TestGo();

			Assert.NotNull(vResults, "Results should not be null.");
			
			////

			foreach ( FabBatchResult res in vResults ) {
				if ( res.Error != null ) {
					Log.Debug(res.BatchId+": "+res.Error.Name+" ("+res.Error.Code+"): "+
						res.Error.Message);
					continue;
				}

				Log.Debug(res.BatchId+": "+res.ResultId);
			}

			NewNodeCount = 1*(vClasses.Count-2); //skip 2 items with intentional errors
			NewRelCount = 2*(vClasses.Count-2);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrClassesNull() {
			vClassesJson = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}

	}

}