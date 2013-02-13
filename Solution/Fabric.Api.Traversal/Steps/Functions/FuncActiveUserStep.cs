using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Traversal;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveUser", IsInternal=true)]
	public class FuncActiveUserStep : FuncStep, IFinalStep {

		private static string QueryStart;
		private static string QueryEnd;
		
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncActiveUserStep(IPath pPath) : base(pPath) {
			if ( QueryStart == null ) {
				IWeaverQuery q = ApiFunc.NewPathFromIndex(new User { UserId = 999 }).End();
				string script = q.Script;
				int idIndex = script.IndexOf("999");
				
				QueryStart = script.Substring(2, idIndex-2); //remove "g."
				QueryEnd = script.Substring(idIndex+3);
				QueryEnd = QueryEnd.Substring(0, QueryEnd.Length-1);
			}
			
			Path.AddSegment(this, QueryStart+Path.UserId+QueryEnd);
			ProxyStep = new UserStep(Path);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType {
			get { return typeof(FabUser); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(0);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}