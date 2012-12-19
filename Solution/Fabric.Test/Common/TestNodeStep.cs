using System.Collections.Generic;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestNodeStep : NodeStep<TestFabNode> {

		public static readonly List<string> AvailNodeSteps = new List<string> {
			 "HasThing"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestNodeStep(Path pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "TestNodeStepId"; } }
		public override bool TypeIdIsLong { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public override List<string> AvailableSteps { get { return AvailNodeSteps; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "HasThing": return new ThingStep(true, Path);
			}

			return null;
		}

	}

}