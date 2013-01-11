using Fabric.Infrastructure;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver;

namespace Fabric.Test.Integration {

	/*================================================================================================*/
	public class IntegTestBase {

		protected TestApiContext Context { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			Log.Debug("SetUp");
			Context = new TestApiContext();
			TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TearDown]
		public void TearDown() {
			Log.Debug("TearDown");
			var q = new WeaverQuery();
			q.FinalizeQuery("g.V.each{g.removeVertex(it)};g.loadGraphSON('data/FabricTestFull.json')");
			Context.DbData("ResetDatabase", q);

			TestTearDown();
			Context = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void TestSetUp() {}
		protected virtual void TestTearDown() {}

	}

}