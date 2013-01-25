using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Nodes {

	/*================================================================================================*/
	[TestFixture]
	public class TNodeSteps {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void TestStep<T>(string pStepName, Func<Path, T> pNewStep) where T : INodeStep {
			string[] availSteps;
			bool isRoot = (pStepName == "Root");

			bool found = StepUtil.NodeStepMap.TryGetValue(pStepName, out availSteps);
			Assert.True(found, pStepName+" is not an accepted NodeStep name.");

			INodeStep step = pNewStep(new Path());
			Assert.AreEqual(pStepName+"Id", step.TypeIdName, "Incorrect TypeIdName.");

			////

			const string fabDom = "Fabric.Domain";
			Object domObj = Activator.CreateInstance(fabDom, fabDom+"."+pStepName).Unwrap();
			Assert.True((domObj is Node), "Incorrect domain type: '"+domObj.GetType().Name+"'.");
			Assert.AreEqual(isRoot, (step is IFinalStep), "Incorrect IFinalStep usage.");

			if ( isRoot ) {
				Assert.AreEqual(false, step.TypeIdIsLong, "Incorrect TypeIdListLong.");
				Assert.True(((IFinalStep)step).UseLocalData, "Incorrect UseLocalData.");
			}
			else {
				Node domNode = (Node)domObj;
				PropertyInfo nodeIdProp = domNode.GetType().GetProperty(pStepName+"Id");
				Assert.AreEqual(nodeIdProp.PropertyType == typeof(long), step.TypeIdIsLong,
					"Incorrect TypeIdIsLong.");
			}

			////

			var expectSteps = new List<string>();
			List<string> expectFuncs = FuncRegistry.GetAvailableFuncs(step, true);

			foreach ( string a in availSteps ) {
				expectSteps.Add(a);

				step = pNewStep(new Path());
				string text = a.Substring(1); //remove leading slash char
				TestNextStep(step, text);
			}

			try {
				step = pNewStep(new Path());
				IStep next = step.GetNextStep("fake");
				Assert.Fail("Expected 'fake' step to fail.");
			}
			catch ( Exception ex ) {
				Assert.NotNull(ex);
			}

			////
			
			step = pNewStep(new Path());

			Assert.NotNull(step.AvailableLinks, "AvailableLinks should be filled.");
			Assert.AreEqual(expectSteps.Count, step.AvailableLinks.Count,
				"Incorrect AvailableLinks length.");

			for ( int i = 0 ; i < step.AvailableLinks.Count ; ++i ) {
				Assert.AreEqual(expectSteps[i], step.AvailableLinks[i].Uri,
					"Incorrect AvailableLinks["+i+"].");
			}

			if ( !isRoot ) {
				step = pNewStep(new Path());
				IInRootContains rc = (step as IInRootContains);
				Assert.NotNull(rc, "All non-Root NodeSteps must implement IInRootContains.");

				RootStep rs = rc.InRootContains;
				Assert.NotNull(rs, "InRootContains result should not be null.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestNextStep(INodeStep pStep, string pStepText) {
			pStep.SetDataAndUpdatePath(new StepData("first"));
			string origPathScript = pStep.Path.Script;
			int origPathSegCount = pStep.Path.Segments.Count;

			IStep next = pStep.GetNextStep(pStepText);
			Assert.NotNull(next, "GetNextStep result should not be null.");

			var lowerSt = pStepText.ToLower();
			var lowerTn = next.DtoType.Name.Substring(3).ToLower(); //remove 'Fab'
			Assert.AreNotEqual(-1, lowerSt.IndexOf(lowerTn),
				"Next step '"+pStepText+"' does not contain expected name '"+lowerTn+"'.");

			Assert.Less((origPathScript+".").Length, next.Path.Script.Length,
				"Not enough characters were added to Path.Script.");
			Assert.AreEqual(origPathSegCount+1, next.Path.Segments.Count,
				"Incorrect Path.Segment count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void TotalNodeStepKeys() {
			Assert.AreEqual(31, StepUtil.NodeStepMap.Keys.Count, "Incorrect NodeStepMap.Keys.Count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RootStep() {
			TestStep("Root", p => new RootStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppStep() {
			TestStep("App", p => new AppStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactStep() {
			TestStep("Artifact", p => new ArtifactStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactTypeStep() {
			TestStep("ArtifactType", p => new ArtifactTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void CrowdStep() {
			TestStep("Crowd", p => new CrowdStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void CrowdianStep() {
			TestStep("Crowdian", p => new CrowdianStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void CrowdianTypeStep() {
			TestStep("CrowdianType", p => new CrowdianTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void CrowdianTypeAssignStep() {
			TestStep("CrowdianTypeAssign", p => new CrowdianTypeAssignStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void EmailStep() {
			TestStep("Email", p => new EmailStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void LabelStep() {
			TestStep("Label", p => new LabelStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberStep() {
			TestStep("Member", p => new MemberStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberTypeStep() {
			TestStep("MemberType", p => new MemberTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberTypeAssignStep() {
			TestStep("MemberTypeAssign", p => new MemberTypeAssignStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ThingStep() {
			TestStep("Thing", p => new ThingStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UrlStep() {
			TestStep("Url", p => new UrlStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UserStep() {
			TestStep("User", p => new UserStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorStep() {
			TestStep("Factor", p => new FactorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorAssertionStep() {
			TestStep("FactorAssertion", p => new FactorAssertionStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DescriptorStep() {
			TestStep("Descriptor", p => new DescriptorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DescriptorTypeStep() {
			TestStep("DescriptorType", p => new DescriptorTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DirectorStep() {
			TestStep("Director", p => new DirectorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DirectorTypeStep() {
			TestStep("DirectorType", p => new DirectorTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DirectorActionStep() {
			TestStep("DirectorAction", p => new DirectorActionStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorStep() {
			TestStep("Eventor", p => new EventorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorTypeStep() {
			TestStep("EventorType", p => new EventorTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorPrecisionStep() {
			TestStep("EventorPrecision", p => new EventorPrecisionStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void IdentorStep() {
			TestStep("Identor", p => new IdentorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void IdentorTypeStep() {
			TestStep("IdentorType", p => new IdentorTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LocatorStep() {
			TestStep("Locator", p => new LocatorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LocatorTypeStep() {
			TestStep("LocatorType", p => new LocatorTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorStep() {
			TestStep("Vector", p => new VectorStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorTypeStep() {
			TestStep("VectorType", p => new VectorTypeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorRangeStep() {
			TestStep("VectorRange", p => new VectorRangeStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorRangeLevelStep() {
			TestStep("VectorRangeLevel", p => new VectorRangeLevelStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorUnitStep() {
			TestStep("VectorUnit", p => new VectorUnitStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorUnitPrefixStep() {
			TestStep("VectorUnitPrefix", p => new VectorUnitPrefixStep(p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorUnitDerivedStep() {
			TestStep("VectorUnitDerived", p => new VectorUnitDerivedStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthAccessStep() {
			TestStep("OauthAccess", p => new OauthAccessStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthDomainStep() {
			TestStep("OauthDomain", p => new OauthDomainStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthGrantStep() {
			TestStep("OauthGrant", p => new OauthGrantStep(p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthScopeStep() {
			TestStep("OauthScope", p => new OauthScopeStep(p));
		}*/

	}

}