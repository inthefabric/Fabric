using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;
using Weaver.Core.Util;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveUser", IsInternal=true)]
	public class ActiveUserFunc : Func, IFinalStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ActiveUserFunc(IPath pPath) : base(pPath) {
			string prop = WeaverUtil.GetPropertyDbName<User>(x => x.ArtifactId);
			string idParam = Path.AddParam(new WeaverQueryVal(Path.UserId));
			Path.AddSegment(this, "V('"+prop+"',"+idParam+")");
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