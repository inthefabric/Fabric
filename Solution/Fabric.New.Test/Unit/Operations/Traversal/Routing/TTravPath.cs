using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	[TestFixture]
	public class TTravPath {

		private Mock<ITravPathData> vMockData;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<ITravPathData>(MockBehavior.Strict);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static List<ITravPathItem> GetMockItems(int pCount) {
			var items = new List<ITravPathItem>();

			for ( int i = 0 ; i < pCount ; ++i ) {
				var mockItem = new Mock<ITravPathItem>(MockBehavior.Strict);
				mockItem.SetupGet(x => x.StepIndex).Returns(i);
				items.Add(mockItem.Object);
			}

			return items;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void CheckItemList(IList<ITravPathItem> pItems, int pStartI) {
			for ( int i = 0 ; i < pItems.Count ; ++i ) {
				Assert.AreEqual(pStartI+i, pItems[i].StepIndex, "Incorrect Item["+i+"].StepIndex.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void CheckItem(ITravPathItem pItem, int pStartI) {
			Assert.AreEqual(pStartI, pItem.StepIndex, "Incorrect Item.StepIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(1234)]
		public void MemberId(int? pMemberId) {
			vMockData.SetupGet(x => x.MemberId).Returns(pMemberId);
			var tp = new TravPath(vMockData.Object);
			Assert.AreEqual(pMemberId, tp.MemberId, "Incorrect MemberId.");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1)]
		[TestCase(3)]
		[TestCase(6)]
		[TestCase(8)]
		public void GetFirstSteps(int pCount) {
			vMockData.SetupGet(x => x.Items).Returns(GetMockItems(6));

			int expectCount = Math.Min(6, pCount);

			var tp = new TravPath(vMockData.Object);
			IList<ITravPathItem> result = tp.GetFirstSteps(pCount);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(expectCount, result.Count, "Incorrect result count.");
			CheckItemList(result, 0);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, false)]
		[TestCase(1, false)]
		[TestCase(5, false)]
		[TestCase(6, true)]
		public void GetNextStep(int pCurrIndex, bool pNull) {
			vMockData.SetupGet(x => x.Items).Returns(GetMockItems(6));
			vMockData.SetupGet(x => x.CurrIndex).Returns(pCurrIndex);

			var tp = new TravPath(vMockData.Object);
			ITravPathItem result = tp.GetNextStep();

			if ( pNull ) {
				Assert.Null(result, "Result should be null.");
				return;
			}

			Assert.NotNull(result, "Result should be filled.");
			CheckItem(result, pCurrIndex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, 1, false)]
		[TestCase(2, 4, false)]
		[TestCase(2, 5, true)]
		[TestCase(3, 2, false)]
		[TestCase(5, 1, false)]
		[TestCase(6, 1, true)]
		public void GetSteps(int pCurrIndex, int pCount, bool pNull) {
			vMockData.SetupGet(x => x.Items).Returns(GetMockItems(6));
			vMockData.SetupGet(x => x.CurrIndex).Returns(pCurrIndex);

			var tp = new TravPath(vMockData.Object);
			IList<ITravPathItem> result = tp.GetSteps(pCount);

			if ( pNull ) {
				Assert.Null(result, "Result should be null.");
				return;
			}

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pCount, result.Count, "Incorrect result count.");
			CheckItemList(result, pCurrIndex);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabTravRoot), false, true)]
		[TestCase(typeof(FabTravRoot), true, true)]
		[TestCase(typeof(FabTravAppRoot), false, false)]
		[TestCase(typeof(FabTravAppRoot), true, false)]
		public void IsAcceptableType(Type pType, bool pExact, bool pExpectResult) {
			vMockData.SetupGet(x => x.Items).Returns(GetMockItems(6));
			vMockData.SetupGet(x => x.CurrType).Returns(typeof(FabTravRoot));

			var tp = new TravPath(vMockData.Object);
			bool result = tp.IsAcceptableType(pType, pExact);
			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, 1)]
		[TestCase(2, 4)]
		[TestCase(3, 2)]
		[TestCase(5, 1)]
		public void ConsumeSteps(int pCurrIndex, int pCount) {
			var types = new List<Type>();
			Type currType = typeof(FabArtifact);
			Type newType = typeof(FabFactor);

			vMockData.SetupGet(x => x.Items).Returns(GetMockItems(6));
			vMockData.SetupGet(x => x.CurrIndex).Returns(pCurrIndex);
			vMockData.SetupGet(x => x.CurrType).Returns(currType);
			vMockData.SetupGet(x => x.Types).Returns(types);
			vMockData.Setup(x => x.UpdateCurrentType(newType));
			vMockData.Setup(x => x.IncrementCurrentIndex(pCount));

			var tp = new TravPath(vMockData.Object);
			IList<ITravPathItem> result = tp.ConsumeSteps(pCount, newType);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pCount, result.Count, "Incorrect result count.");
			CheckItemList(result, pCurrIndex);

			Assert.AreEqual(pCount, types.Count, "Incorrect types.count.");

			foreach ( Type type in types ) {
				Assert.AreEqual(currType, type, "Incorrect types list.");
			}

			vMockData.Verify(x => x.UpdateCurrentType(newType), Times.Once);
			vMockData.Verify(x => x.IncrementCurrentIndex(pCount), Times.Once);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddScript() {
			const string script = "My script";
			vMockData.Setup(x => x.AddScript(script));

			var tp = new TravPath(vMockData.Object);
			tp.AddScript(script);

			vMockData.Verify(x => x.AddScript(script), Times.Once);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddParam() {
			object param = "My script";
			const string paramName = "_P0";
			vMockData.Setup(x => x.AddParam(param)).Returns(paramName);

			var tp = new TravPath(vMockData.Object);
			string result = tp.AddParam(param);

			Assert.AreEqual(paramName, result, "Incorrect result.");
			vMockData.Verify(x => x.AddParam(param), Times.Once);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddAlias() {
			const string alias = "a";
			const int currIndex = 123;
			var aliases = new Dictionary<string, int>();

			vMockData.SetupGet(x => x.CurrIndex).Returns(currIndex);
			vMockData.SetupGet(x => x.Aliases).Returns(aliases);

			var tp = new TravPath(vMockData.Object);
			tp.AddAlias(alias);

			Assert.AreEqual(1, aliases.Keys.Count, "Incorrect alias keys count.");
			Assert.AreEqual(currIndex, aliases[alias], "Incorrect alias index.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddBackToAlias() {
			const string alias = "a";
			const int asIndex = 1;
			const int currIndex = 4;
			Type asType = typeof(FabFactor);

			var types = new List<Type>(new[] { null, asType });

			var backs = new Dictionary<string, int>();

			var aliases = new Dictionary<string, int>();
			aliases.Add(alias, asIndex);
			
			vMockData.SetupGet(x => x.CurrIndex).Returns(currIndex);
			vMockData.SetupGet(x => x.Aliases).Returns(aliases);
			vMockData.SetupGet(x => x.Backs).Returns(backs);
			vMockData.SetupGet(x => x.Types).Returns(types);
			vMockData.Setup(x => x.UpdateCurrentType(asType));

			var tp = new TravPath(vMockData.Object);
			tp.AddBackToAlias(alias);

			Assert.AreEqual(1, backs.Keys.Count, "Incorrect back keys count.");
			Assert.AreEqual(currIndex, backs[alias], "Incorrect back index.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("a", true)]
		[TestCase("b", false)]
		public void HasAlias(string pTryAlias, bool pExpectResult) {
			var aliases = new Dictionary<string, int>();
			aliases.Add("a", 0);

			vMockData.SetupGet(x => x.Aliases).Returns(aliases);

			var tp = new TravPath(vMockData.Object);
			bool result = tp.HasAlias(pTryAlias);

			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(5, false)]
		[TestCase(6, true)]
		[TestCase(7, false)]
		public void DoesBackTouchAs(int pCurrIndex, bool pExpectResult) {
			const string alias = "a";

			var aliases = new Dictionary<string, int>();
			aliases.Add(alias, 5);

			vMockData.SetupGet(x => x.CurrIndex).Returns(pCurrIndex);
			vMockData.SetupGet(x => x.Aliases).Returns(aliases);

			var tp = new TravPath(vMockData.Object);
			bool result = tp.DoesBackTouchAs(alias);

			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------* /
		[TestCase(...)]
		public void AllowBackToAlias(...) {} //TODO: TTravPath.AllowBackToAlias()
		*/

	}

}