using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Nodes {

	/*================================================================================================*/
	[TestFixture]
	public class TNodeSteps {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void TestStep<T>(string pStepName, Func<bool, Path, T> pNewStep) where T : INodeStep {
			string[] availSteps;
			bool isRoot = (pStepName == "Root");

			bool found = StepUtil.NodeStepMap.TryGetValue(pStepName, out availSteps);
			Assert.True(found, pStepName+" is not an accepted NodeStep name.");

			INodeStep step = pNewStep(false, new Path());
			Assert.AreEqual(pStepName+"Id", step.TypeIdName, "Incorrect TypeIdName.");

			////

			const string fabDom = "Fabric.Domain";
			Object domObj = Activator.CreateInstance(fabDom, fabDom+"."+pStepName).Unwrap();
			Assert.True((domObj is Node), "Incorrect domain type: '"+domObj.GetType().Name+"'.");

			if ( isRoot ) {
				Assert.AreEqual(false, step.TypeIdIsLong, "Incorrect TypeIdListLong.");
			}
			else {
				Node domNode = (Node)domObj;
				PropertyInfo nodeIdProp = domNode.GetType().GetProperty(pStepName+"Id");
				Assert.AreEqual(nodeIdProp.PropertyType == typeof(long), step.TypeIdIsLong,
					"Incorrect TypeIdIsLong.");
			}

			Assert.AreEqual(isRoot, (step is IFinalStep), "Incorrect IFinalStep usage.");

			////

			var expectSteps = new List<string>();
			List<string> expectFuncs = FuncRegistry.GetAvailableFuncs(step, true);

			foreach ( string a in availSteps ) {
				expectSteps.Add(a);

				step = pNewStep(false, new Path());
				string text = a.Substring(1); //remove leading slash char
				TestNextStep(step, text);
			}

			try {
				step = pNewStep(false, new Path());
				IStep next = step.GetNextStep("fake");
				Assert.Fail("Expected 'fake' step to fail.");
			}
			catch ( Exception ex ) {
				Assert.NotNull(ex);
			}

			////
			
			step = pNewStep(false, new Path());
			Assert.AreEqual(expectSteps, step.AvailableLinks, "Incorrect AvailableLinks.");

			if ( !isRoot ) {
				step = pNewStep(false, new Path());
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
			Assert.AreEqual(36, StepUtil.NodeStepMap.Keys.Count, "Incorrect NodeStepMap.Keys.Count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RootStep() {
			TestStep("Root", (tn, p) => new RootStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppStep() {
			TestStep("App", (tn, p) => new AppStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactStep() {
			TestStep("Artifact", (tn, p) => new ArtifactStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactTypeStep() {
			TestStep("ArtifactType", (tn, p) => new ArtifactTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CrowdStep() {
			TestStep("Crowd", (tn, p) => new CrowdStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CrowdianStep() {
			TestStep("Crowdian", (tn, p) => new CrowdianStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CrowdianTypeStep() {
			TestStep("CrowdianType", (tn, p) => new CrowdianTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CrowdianTypeAssignStep() {
			TestStep("CrowdianTypeAssign", (tn, p) => new CrowdianTypeAssignStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void EmailStep() {
			TestStep("Email", (tn, p) => new EmailStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LabelStep() {
			TestStep("Label", (tn, p) => new LabelStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberStep() {
			TestStep("Member", (tn, p) => new MemberStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberTypeStep() {
			TestStep("MemberType", (tn, p) => new MemberTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberTypeAssignStep() {
			TestStep("MemberTypeAssign", (tn, p) => new MemberTypeAssignStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ThingStep() {
			TestStep("Thing", (tn, p) => new ThingStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UrlStep() {
			TestStep("Url", (tn, p) => new UrlStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UserStep() {
			TestStep("User", (tn, p) => new UserStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorStep() {
			TestStep("Factor", (tn, p) => new FactorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorAssertionStep() {
			TestStep("FactorAssertion", (tn, p) => new FactorAssertionStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DescriptorStep() {
			TestStep("Descriptor", (tn, p) => new DescriptorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DescriptorTypeStep() {
			TestStep("DescriptorType", (tn, p) => new DescriptorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DirectorStep() {
			TestStep("Director", (tn, p) => new DirectorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DirectorTypeStep() {
			TestStep("DirectorType", (tn, p) => new DirectorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DirectorActionStep() {
			TestStep("DirectorAction", (tn, p) => new DirectorActionStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorStep() {
			TestStep("Eventor", (tn, p) => new EventorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorTypeStep() {
			TestStep("EventorType", (tn, p) => new EventorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorPrecisionStep() {
			TestStep("EventorPrecision", (tn, p) => new EventorPrecisionStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void IdentorStep() {
			TestStep("Identor", (tn, p) => new IdentorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void IdentorTypeStep() {
			TestStep("IdentorType", (tn, p) => new IdentorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LocatorStep() {
			TestStep("Locator", (tn, p) => new LocatorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LocatorTypeStep() {
			TestStep("LocatorType", (tn, p) => new LocatorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorStep() {
			TestStep("Vector", (tn, p) => new VectorStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorTypeStep() {
			TestStep("VectorType", (tn, p) => new VectorTypeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorRangeStep() {
			TestStep("VectorRange", (tn, p) => new VectorRangeStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorRangeLevelStep() {
			TestStep("VectorRangeLevel", (tn, p) => new VectorRangeLevelStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorUnitStep() {
			TestStep("VectorUnit", (tn, p) => new VectorUnitStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorUnitPrefixStep() {
			TestStep("VectorUnitPrefix", (tn, p) => new VectorUnitPrefixStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VectorUnitDerivedStep() {
			TestStep("VectorUnitDerived", (tn, p) => new VectorUnitDerivedStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthAccessStep() {
			TestStep("OauthAccess", (tn, p) => new OauthAccessStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthDomainStep() {
			TestStep("OauthDomain", (tn, p) => new OauthDomainStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthGrantStep() {
			TestStep("OauthGrant", (tn, p) => new OauthGrantStep(tn, p));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void OauthScopeStep() {
			TestStep("OauthScope", (tn, p) => new OauthScopeStep(tn, p));
		}*/

	}

}