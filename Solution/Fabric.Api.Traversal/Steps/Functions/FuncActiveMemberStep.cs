using System;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveMember", IsInternal=true)]
	public class FuncActiveMemberStep : FuncStep, IFinalStep {

		private static string Script;
		private static string UserParam;
		private static string AppParam;
		
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncActiveMemberStep(IPath pPath) : base(pPath) {
			if ( Script == null ) {
				IWeaverQuery q = Weave.Inst.Graph
					.V.ExactIndex<User>(x => x.ArtifactId, 0)
					.DefinesMemberList.ToMember
					.InAppDefines.FromApp
						.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, (long)0)
					.ToQuery();

				Script = q.Script
					.Substring(2, q.Script.Length-3)+ //remove "g." and final ";"
					".back(3)[0]"; //return to Member step

				UserParam = q.Params.Keys.ToList()[0];
				AppParam = q.Params.Keys.ToList()[1];
			}

			string up = Path.AddParam(new WeaverQueryVal(Path.UserId));
			string ap = Path.AddParam(new WeaverQueryVal(Path.AppId));
			Path.AddSegment(this, Script.Replace(UserParam, up).Replace(AppParam, ap));
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