﻿using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Weaver;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveUser", IsInternal=true)]
	public class FuncActiveUserStep : FuncStep, IFinalStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncActiveUserStep(IPath pPath) : base(pPath) {
			string prop = WeaverUtil.GetPropertyName<User>(x => x.UserId);
			string idParam = Path.AddParam(new WeaverQueryVal(Path.UserId));
			Path.AddSegment(this, "V('"+prop+"',"+idParam+")[0]");
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