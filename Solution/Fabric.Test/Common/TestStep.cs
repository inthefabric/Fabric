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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestStep(Path pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		public override List<string> AvailableLinks { get { return TestAvailLinks; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "test1": return new ArtifactStep(true, Path);
				case "test2": return new FactorStep(true, Path);
			}

			return base.GetLink(pData);
		}

	}

}