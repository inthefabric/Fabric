using System.Collections.Generic;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestVertexStep : VertexStep<TestFabVertex> {

		public static readonly List<IStepLink> AvailVertexLinks = new List<IStepLink> {
			new StepLink("Has", "Class", true, "/HasClass")
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestVertexStep(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "TestVertexStepId"; } }
		public override bool TypeIdIsLong { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks { get { return AvailVertexLinks; } }


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