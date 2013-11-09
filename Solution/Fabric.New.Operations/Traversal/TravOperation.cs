using System.Collections.Generic;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravOperation : ITravOperation {

		protected IOperationContext OpCtx { get; set; }
		protected string Path { get; set; }
		protected IList<ITravPathStep> PathSteps { get; set; }
		protected string Script { get; set; }

		private FabObject vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			OpCtx = pOpCtx;
			Path = pPath;
			PathSteps = new List<ITravPathStep>();

			string p = pPath.Replace("%20", " ").TrimEnd(new[] { '/' });
			string[] parts = (p.Length > 0 ? p.Split('/') : new string[0]);

			for ( int i = 0 ; i < parts.Length ; i++ ) {
				PathSteps.Add(new TravPathStep(i, parts[i]));
			}

			Script = "g.";
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabObject GetResult() {
			return vResult;
		}

	}

}