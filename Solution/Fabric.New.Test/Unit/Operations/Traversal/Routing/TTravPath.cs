using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Operations.Traversal.Routing;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	[TestFixture]
	public class TTravPath {

		private static readonly Logger Log = Logger.Build<TTravPath>();

		private const string RawPath6 = "test/this/path/with/six(1,2,3,4,5,6)/segments";
		private static readonly string[] RawPath6Segments = new[] { 
			"test", "this", "path", "with", "six(1,2,3,4,5,6)", "segments" };

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(1234)]
		public void New(int? pMemberId) {
			const string rawText = "Path/Text/Here(99)";

			var tp = new TravPath(rawText, pMemberId);

			Assert.AreEqual(pMemberId, tp.MemberId, "Incorrect MemberId.");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1)]
		[TestCase(3)]
		[TestCase(6)]
		[TestCase(8)]
		public void GetFirstSteps(int pCount) {
			int expectCount = Math.Min(6, pCount);

			var tp = new TravPath(RawPath6);
			IList<ITravPathItem> result = tp.GetFirstSteps(pCount);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(expectCount, result.Count, "Incorrect result count.");

			for ( int i = 0 ; i < expectCount ; ++i ) {
				Assert.AreEqual(RawPath6Segments[i], result[i].RawText, "Incorrect RawText @ "+i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, 2)]
		[TestCase(2, 1)]
		[TestCase(3, 3)]
		[TestCase(5, 1)]
		public void ConsumeStepsTwice(int pCountA, int pCountB) {
			var tp = new TravPath(RawPath6);

			IList<ITravPathItem> resultA = tp.ConsumeSteps(pCountA, typeof(FabArtifact));
			IList<ITravPathItem> resultB = tp.ConsumeSteps(pCountB, typeof(FabArtifact));

			Assert.NotNull(resultA, "Result should be filled.");
			Assert.NotNull(resultB, "Result should be filled.");
			Assert.AreEqual(pCountA, resultA.Count, "Incorrect result count.");
			Assert.AreEqual(pCountB, resultB.Count, "Incorrect result count.");

			for ( int i = 0 ; i < pCountA ; ++i ) {
				Assert.AreEqual(RawPath6Segments[i], resultA[i].RawText, "Incorrect RawText @ "+i);
			}

			for ( int i = 0 ; i < pCountB ; ++i ) {
				int j = i+pCountA;
				Assert.AreEqual(RawPath6Segments[j], resultB[i].RawText, "Incorrect RawText @ "+j);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetCurrentType() {
			var tp = new TravPath(RawPath6);
			Type result = tp.GetCurrentType();
			Assert.AreEqual(typeof(FabTravRoot), result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabArtifact), typeof(FabClass), typeof(FabClass))]
		[TestCase(typeof(FabClass), typeof(FabArtifact), typeof(FabClass))]
		[TestCase(typeof(FabArtifact), typeof(FabFactor), typeof(FabFactor))]
		[TestCase(typeof(FabFactor), typeof(FabArtifact), typeof(FabArtifact))]
		public void ConsumeStepsAndGetCurrentType(Type pTypeA, Type pTypeB, Type pExpectType) {
			var tp = new TravPath(RawPath6);

			tp.ConsumeSteps(1, pTypeA);
			Type resultA = tp.GetCurrentType();

			tp.ConsumeSteps(1, pTypeB);
			Type resultB = tp.GetCurrentType();

			Assert.AreEqual(pTypeA, resultA, "Incorrect resultA.");
			Assert.AreEqual(pExpectType, resultB, "Incorrect resultB.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1)]
		[TestCase(6)]
		public void ConsumeStepsAndGetNextStep(int pCount) {
			var tp = new TravPath(RawPath6);
			tp.ConsumeSteps(pCount, typeof(FabFactor));
			ITravPathItem result = tp.GetNextStep();

			if ( pCount >= RawPath6Segments.Length ) {
				Assert.Null(result, "Result should be null.");
				return;
			}

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(RawPath6Segments[pCount], result.RawText, "Incorrect Result.RawText.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, 1)]
		[TestCase(1, 5)]
		[TestCase(4, 2)]
		[TestCase(4, 3)]
		public void ConsumeStepsAndGetNextSteps(int pConsumeCount, int pGetCount) {
			var tp = new TravPath(RawPath6);
			tp.ConsumeSteps(pConsumeCount, typeof(FabFactor));
			IList<ITravPathItem> result = tp.GetSteps(pGetCount);

			if ( pConsumeCount+pGetCount > RawPath6Segments.Length ) {
				Assert.Null(result, "Result should be null.");
				return;
			}

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pGetCount, result.Count, "Incorrect result count.");

			for ( int i = 0 ; i < pGetCount ; ++i ) {
				int j = pConsumeCount+i;
				Assert.AreEqual(RawPath6Segments[j], result[i].RawText, "Incorrect RawText @ "+i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabTravRoot), false, true)]
		[TestCase(typeof(FabTravRoot), true, true)]
		[TestCase(typeof(FabTravAppRoot), false, false)]
		[TestCase(typeof(FabTravAppRoot), true, false)]
		public void IsAcceptableType(Type pType, bool pExact, bool pExpectResult) {
			var tp = new TravPath("");
			bool result = tp.IsAcceptableType(pType, pExact);
			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void ConsumeStepsAndIsAcceptableType(bool pExact) {
			var tp = new TravPath("");
			tp.ConsumeSteps(0, typeof(FabClass));
			bool result = tp.IsAcceptableType(typeof(FabArtifact), pExact);
			Assert.AreEqual(!pExact, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabArtifact), typeof(FabArtifact), true)]
		[TestCase(typeof(FabArtifact), typeof(FabApp), true)]
		[TestCase(typeof(FabApp), typeof(FabArtifact), false)]
		[TestCase(typeof(FabArtifact), typeof(FabFactor), false)]
		[TestCase(typeof(FabVertex), typeof(FabArtifact), true)]
		[TestCase(typeof(FabVertex), typeof(FabFactor), true)]
		[TestCase(typeof(FabClass), typeof(FabApp), false)]
		public void IsSameTypeOrSubclass(Type pBase, Type pSub, bool pExpectResult) {
			bool result = TravPath.IsSameTypeOrSubclass(pBase, pSub);
			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddScriptAndAddParamsAndBuildQuery() {
			const string scriptA = ".test";
			const string scriptB = ".this";
			const string param0 = "_P0";
			const string param0Val = "now";
			const string scriptC = ".path("+param0+")";
			const string script = "g.V"+scriptA+scriptB+scriptC+";";

			var tp = new TravPath("");
			
			tp.AddScript(scriptA);
			tp.AddScript(scriptB);
			tp.AddParam(param0Val);
			tp.AddScript(scriptC);

			IWeaverQuery result = tp.BuildQuery();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(script, result.Script, "Incorrect script.");
			Assert.NotNull(result.Params, "Params should be filled.");
			Assert.AreEqual(1, result.Params.Count, "Incorrect Params count.");
			Assert.AreEqual(param0Val, result.Params[param0].RawText, "Incorrect Param[0] RawText.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddAliasAndHasAlias() {
			const string aliasA = "a";
			const string aliasB = "B";

			var tp = new TravPath("");
			tp.AddAlias(aliasA);
			tp.AddAlias(aliasB);

			bool resultA = tp.HasAlias(aliasA);
			bool resultB = tp.HasAlias(aliasB);
			bool resultC = tp.HasAlias("C");

			Assert.True(resultA, "Incorrect resultA.");
			Assert.True(resultB, "Incorrect resultB.");
			Assert.False(resultC, "Incorrect resultC.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, 1, true)]
		[TestCase(0, 2, false)]
		[TestCase(3, 1, true)]
		[TestCase(3, 0, false)]
		[TestCase(3, 2, false)]
		public void AddAliasAndConsumeStepsAndDoesBackTouchAs(
													int pConsumeA, int pConsumeB, bool pExpectResult) {
			const string aliasA = "a";

			var tp = new TravPath(RawPath6);
			tp.ConsumeSteps(pConsumeA, typeof(FabFactor));
			tp.AddAlias(aliasA);
			tp.ConsumeSteps(pConsumeB, typeof(FabFactor));
			bool result = tp.DoesBackTouchAs(aliasA);

			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddAliasAndConsumeStepsAndAddBackToAliasAndGetCurrentType() {
			const string aliasA = "a";

			var tp = new TravPath(RawPath6);
			tp.ConsumeSteps(2, typeof(FabFactor));
			tp.AddAlias(aliasA);
			tp.ConsumeSteps(2, typeof(FabApp));
			tp.AddBackToAlias(aliasA);
			Type result = tp.GetCurrentType();

			Assert.AreEqual(typeof(FabFactor), result, "Incorrect result.");
		}

	}

}