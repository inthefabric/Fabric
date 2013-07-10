using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;
using Weaver.Core.Util;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveApp", IsInternal=true)]
	public class ActiveAppFunc : Func, IFinalStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ActiveAppFunc(IPath pPath) : base(pPath) {
			string prop = WeaverUtil.GetPropertyDbName<App>(x => x.ArtifactId);
			string idParam = Path.AddParam(new WeaverQueryVal(Path.AppId));
			Path.AddSegment(this, "V('"+prop+"',"+idParam+")");
			ProxyStep = new AppStep(Path);
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