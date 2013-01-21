using System.Collections.Generic;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Paths;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestStep : Step<TestFabNode> {

		public static readonly List<IStepLink> TestAvailLinks = new List<IStepLink> {
			new StepLink("Test", "SomeNode", true, "/PathToSomeNode"),
			new StepLink("TEST2", "OtherNode", false, "/PathToOtherNode")
		};

		public const string SegmentText = "testStep(x)";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, SegmentText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks { get { return TestAvailLinks; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "test1": return new ArtifactStep(Path);
				case "test2": return new FactorStep(Path);
			}

			return base.GetLink(pData);
		}

	}

}