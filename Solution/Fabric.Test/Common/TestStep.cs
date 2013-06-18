using System.Collections.Generic;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestStep : Step<TestFabVertex> {

		public static readonly List<IStepLink> TestAvailLinks = new List<IStepLink> {
			new StepLink("Test", "SomeVertex", true, "/PathToSomeVertex"),
			new StepLink("TEST2", "OtherVertex", false, "/PathToOtherVertex")
		};

		public const string SegmentText = "testStep(x)";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestStep(IPath pPath) : base(pPath) {
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