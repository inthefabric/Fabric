using System.Collections.Generic;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Infrastructure.Paths;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestNodeStep : NodeStep<TestFabNode> {

		public static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Thing", true, "/HasThing")
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestNodeStep(Path pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "TestNodeStepId"; } }
		public override bool TypeIdIsLong { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks { get { return AvailNodeLinks; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "HasThing": return new ThingStep(Path);
			}

			return null;
		}

	}

}