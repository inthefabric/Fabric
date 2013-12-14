using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Util;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Util {

	/*================================================================================================*/
	[TestFixture]
	public class TTraversalUtil {

		//These tests are rather brittle. Adding/removing any "rules" will make them break.

		private const int TotalRuleCount = 206;
		private const int ArtifactRuleCount = 14;
		private const int ClassRuleCount = 9;
		private const int FactorRuleCount = 31;
		private const int TravMemberRuleCount = 3;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAllTravRules() {
			IList<TravRule> result = TraversalUtil.GetTravRules();
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(TotalRuleCount, result.Count, "Incorrect result count.");

			for ( int i = 0 ; i < result.Count ; i++ ) {
				Assert.NotNull(result[i], "Result["+i+"] should be filled.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabArtifact), ArtifactRuleCount)]
		[TestCase(typeof(FabClass), ClassRuleCount)]
		[TestCase(typeof(FabFactor), FactorRuleCount)]
		[TestCase(typeof(FabTravMemberRoot), TravMemberRuleCount)]
		public void GetTravRules(Type pType, int pExpectCount) {
			IList<TravRule> result = TraversalUtil.GetTravRules(pType);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pExpectCount, result.Count, "Incorrect result count.");

			for ( int i = 0 ; i < result.Count ; i++ ) {
				Assert.NotNull(result[i], "Result["+i+"] should be filled.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabArtifact), ArtifactRuleCount)]
		[TestCase(typeof(FabClass), ClassRuleCount)]
		[TestCase(typeof(FabFactor), FactorRuleCount)]
		[TestCase(typeof(FabTravMemberRoot), TravMemberRuleCount)]
		public void GetFabTravSteps(Type pType, int pExpectCount) {
			IList<FabTravStep> result = TraversalUtil.GetFabTravSteps(pType);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pExpectCount, result.Count, "Incorrect result count.");

			for ( int i = 0 ; i < result.Count ; i++ ) {
				Assert.NotNull(result[i], "Result["+i+"] should be filled.");
			}
		}

	}

}