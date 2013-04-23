using System.Collections.Generic;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestNodeStep : NodeStep<TestFabNode> {

		public static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Class", true, "/HasClass")
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestNodeStep(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "TestNodeStepId"; } }
		public override bool TypeIdIsLong { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks { get { return AvailNodeLinks; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "HasClass": return new ClassStep(Path);
			}

			return null;
		}

	}

}