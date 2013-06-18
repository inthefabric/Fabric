using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Vertices {

	/*================================================================================================*/
	[TestFixture]
	public class TVertexSteps {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void TestStep<T>(string pStepName, string pTypeIdProp, 
														Func<IPath, T> pNewStep) where T : IVertexStep {
			string[] availSteps;
			bool isRoot = (pStepName == "Root");
			bool isArtifact = (pStepName == "Artifact");

			bool found = StepUtil.VertexStepMap.TryGetValue(pStepName, out availSteps);
			Assert.True(found, pStepName+" is not an accepted VertexStep name.");

			IPath p = new Mock<IPath>().Object;
			IVertexStep step = pNewStep(p);
			Assert.AreEqual(pTypeIdProp, step.TypeIdName, "Incorrect TypeIdName.");

			////

			const string fabDom = "Fabric.Domain";
			Object domObj = Activator.CreateInstance(fabDom, fabDom+"."+pStepName).Unwrap();
			Assert.True((domObj is IVertex), "Incorrect domain type: '"+domObj.GetType().Name+"'.");
			Assert.AreEqual(isRoot, (step is IFinalStep), "Incorrect IFinalStep usage.");

			if ( isRoot ) {
				Assert.AreEqual(false, step.TypeIdIsLong, "Incorrect TypeIdListLong.");
				Assert.True(((IFinalStep)step).UseLocalData, "Incorrect UseLocalData.");
			}
			else {
				IVertex domVertex = (IVertex)domObj;
				PropertyInfo vertexIdProp = domVertex.GetType().GetProperty(pStepName+"Id");
				//Assert.AreEqual(vertexIdProp.PropertyType == typeof(long), step.TypeIdIsLong,
				//	"Incorrect TypeIdIsLong.");
			}

			////

			var expectSteps = new List<string>();
			List<string> expectFuncs = FuncRegistry.GetAvailableFuncs(step, true, true);

			foreach ( string a in availSteps ) {
				expectSteps.Add(a);

				var mockPath = new Mock<IPath>();
				step = pNewStep(mockPath.Object);
				string text = a.Substring(1); //remove leading slash char
				TestNextStep(step, text, mockPath);
			}

			try {
				p = new Mock<IPath>().Object;
				step = pNewStep(p);
				IStep next = step.GetNextStep("fake");
				Assert.Fail("Expected 'fake' step to fail.");
			}
			catch ( Exception ex ) {
				Assert.NotNull(ex);
			}

			////

			p = new Mock<IPath>().Object;
			step = pNewStep(p);

			Assert.NotNull(step.AvailableLinks, "AvailableLinks should be filled.");
			Assert.AreEqual(expectSteps.Count, step.AvailableLinks.Count,
				"Incorrect AvailableLinks length.");

			for ( int i = 0 ; i < step.AvailableLinks.Count ; ++i ) {
				Assert.AreEqual(expectSteps[i], step.AvailableLinks[i].Uri,
					"Incorrect AvailableLinks["+i+"].");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestNextStep(IVertexStep pStep, string pStepText, Mock<IPath> pMockPath) {
			pStep.SetDataAndUpdatePath(new StepData("first"));

			IStep next = pStep.GetNextStep(pStepText);
			Assert.NotNull(next, "GetNextStep result should not be null.");

			var lowerSt = pStepText.ToLower();
			var lowerTn = next.DtoType.Name.Substring(3).ToLower(); //remove 'Fab'
			Assert.AreNotEqual(-1, lowerSt.IndexOf(lowerTn),
				"Next step '"+pStepText+"' does not contain expected name '"+lowerTn+"'.");

			Times t = Times.Exactly(pStep is RootStep ? 2 : 1);
			pMockPath.Verify(x => x.AddSegment(It.IsAny<IVertexStep>(), It.IsAny<string>()), t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void TotalVertexStepKeys() {
			Assert.AreEqual(9, StepUtil.VertexStepMap.Keys.Count, "Incorrect VertexStepMap.Keys.Count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactStep() {
			TestStep("Artifact", PropDbName.Artifact_ArtifactId, tn => new ArtifactStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppStep() {
			TestStep("App", PropDbName.Artifact_ArtifactId, tn => new AppStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ClassStep() {
			TestStep("Class", PropDbName.Artifact_ArtifactId, tn => new ClassStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void InstanceStep() {
			TestStep("Instance", PropDbName.Artifact_ArtifactId, tn => new InstanceStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberStep() {
			TestStep("Member", PropDbName.Member_MemberId, tn => new MemberStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberTypeAssignStep() {
			TestStep("MemberTypeAssign", PropDbName.MemberTypeAssign_MemberTypeAssignId, tn => new MemberTypeAssignStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UrlStep() {
			TestStep("Url", PropDbName.Artifact_ArtifactId, tn => new UrlStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UserStep() {
			TestStep("User", PropDbName.Artifact_ArtifactId, tn => new UserStep(tn));
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorStep() {
			TestStep("Factor", PropDbName.Factor_FactorId, tn => new FactorStep(tn));
		}

	}

}