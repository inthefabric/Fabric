using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	[TestFixture]
	public class TTravPathData {

		private const string RawPath6 = "test/this/path/with/six(1,2,3,4,5,6)/segments";
		private static readonly string[] RawPath6Segments = new[] { 
			"test", "this", "path", "with", "six(1,2,3,4,5,6)", "segments" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(1234)]
		public void New(int? pMemberId) {
			var d = new TravPathData(RawPath6, pMemberId);

			Assert.AreEqual(pMemberId, d.MemberId, "Incorrect MemberId.");
			Assert.AreEqual(6, d.Items.Count, "Incorrect Items.Count.");

			for ( int i = 0 ; i < d.Items.Count ; ++i ) {
				Assert.AreEqual(RawPath6Segments[i], d.Items[i].RawText,
					"Incorrect Items["+i+"].RawPath.");
			}

			Assert.AreEqual(0, d.Aliases.Count, "Incorrect Aliases.Count.");
			Assert.AreEqual(0, d.Backs.Count, "Incorrect Backs.Count.");
			Assert.AreEqual(1, d.Types.Count, "Incorrect Types.Count.");
			Assert.AreEqual(typeof(FabTravRoot), d.Types[0], "Incorrect Types[0].");
			Assert.AreEqual(0, d.CurrIndex, "Incorrect CurrIndex.");
			Assert.AreEqual(typeof(FabTravRoot), d.CurrType, "Incorrect CurrType.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabArtifact), typeof(FabClass), typeof(FabClass))]
		[TestCase(typeof(FabClass), typeof(FabArtifact), typeof(FabClass))]
		[TestCase(typeof(FabArtifact), typeof(FabFactor), typeof(FabFactor))]
		[TestCase(typeof(FabFactor), typeof(FabArtifact), typeof(FabArtifact))]
		public void UpdateCurrentType(Type pTypeA, Type pTypeB, Type pExpectType) {
			var d = new TravPathData("");
			d.UpdateCurrentType(pTypeA);
			Type resultA = d.CurrType;
			d.UpdateCurrentType(pTypeB);
			Type resultB = d.CurrType;

			Assert.AreEqual(pTypeA, resultA, "Incorrect Result A.");
			Assert.AreEqual(pExpectType, resultB, "Incorrect Result A.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void IncrementCurrentIndex() {
			const int incA = 5;
			const int incB = 3;

			var d = new TravPathData("");
			d.IncrementCurrentIndex(incA);
			int resultA = d.CurrIndex;
			d.IncrementCurrentIndex(incB);
			int resultB = d.CurrIndex;

			Assert.AreEqual(incA, resultA, "Incorrect Result A.");
			Assert.AreEqual(incA+incB, resultB, "Incorrect Result A.");
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

			var d = new TravPathData("");

			d.AddScript(scriptA);
			d.AddScript(scriptB);
			d.AddParam(param0Val);
			d.AddScript(scriptC);

			IWeaverQuery result = d.BuildQuery();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(script, result.Script, "Incorrect script.");
			Assert.NotNull(result.Params, "Params should be filled.");
			Assert.AreEqual(1, result.Params.Count, "Incorrect Params count.");
			Assert.AreEqual(param0Val, result.Params[param0].RawText, "Incorrect Param[0] RawText.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabArtifact), typeof(FabArtifact), true)]
		[TestCase(typeof(FabArtifact), typeof(FabApp), true)]
		[TestCase(typeof(FabApp), typeof(FabArtifact), false)]
		[TestCase(typeof(FabArtifact), typeof(FabFactor), false)]
		[TestCase(typeof(FabVertex), typeof(FabArtifact), true)]
		[TestCase(typeof(FabVertex), typeof(FabFactor), true)]
		[TestCase(typeof(FabClass), typeof(FabApp), false)]
		public void IsSameTypeOrSubclass(Type pBase, Type pSub, bool pExpectResult) {
			bool result = TravPathData.IsSameTypeOrSubclass(pBase, pSub);
			Assert.AreEqual(pExpectResult, result, "Incorrect result.");
		}

	}

}