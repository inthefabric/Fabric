using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Weaver.Interfaces;
using Fabric.Infrastructure.Api;
using Fabric.Domain;
using Weaver;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveApp")]
	public class FuncActiveAppStep : FuncStep, IFinalStep {

		private static string QueryStart;
		private static string QueryEnd;
		
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncActiveAppStep(Path pPath) : base(pPath) {
			if ( QueryStart == null ) {
				IWeaverQuery q = ApiFunc.NewPathFromIndex(new App { AppId = 999 }).End();
				string script = q.Script;
				int idIndex = script.IndexOf("999");
				
				QueryStart = script.Substring(0, idIndex);
				QueryEnd = script.Substring(idIndex+3);
				QueryEnd = QueryEnd.Substring(0, QueryEnd.Length-1);
			}
			
			Path.AddSegment(this, QueryStart+Path.AppId+QueryEnd);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType {
			get { return typeof(FabApp); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			if ( Data.Params != null && Data.Params.Length != 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamCount, this,
					"Zero parameters required.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}