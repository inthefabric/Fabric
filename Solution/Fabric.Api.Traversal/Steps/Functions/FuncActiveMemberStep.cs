using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Traversal;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveMember", IsInternal=true)]
	public class FuncActiveMemberStep : FuncStep, IFinalStep {

		private static string QueryStart;
		private static string QueryMid;
		private static string QueryEnd;
		
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncActiveMemberStep(Path pPath) : base(pPath) {
			if ( QueryStart == null ) {
				IWeaverQuery q = 
					ApiFunc.NewPathFromIndex(new User { UserId = 888 })
						.DefinesMemberList.ToMember
						.InAppDefines.FromApp
						.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, (long)999)
						.End();
				
				string script = q.Script;
				int userIdIndex = script.IndexOf("888");
				int appIdIndex = script.IndexOf("999");
				
				QueryStart = script.Substring(2, userIdIndex-2); //remove "g."
				QueryMid = script.Substring(userIdIndex+3, appIdIndex-userIdIndex-3);
				QueryEnd = script.Substring(appIdIndex+3);
				QueryEnd = QueryEnd.Substring(0, QueryEnd.Length-1)+".back(3)";
			}
			
			Path.AddSegment(this, QueryStart+Path.UserId+QueryMid+Path.AppId+QueryEnd);
			ProxyStep = new MemberStep(Path);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType {
			get { return typeof(FabMember); }
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