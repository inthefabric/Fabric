using System.Collections.Generic;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestStep : Step<TestFabNode> {

		public static readonly List<string> TestAvailLinks = new List<string> {
			 "Test1", "TEST2"
		};

		public const string SegmentText = "testStep(x)";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, SegmentText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override List<string> AvailableLinks { get { return TestAvailLinks; } }


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