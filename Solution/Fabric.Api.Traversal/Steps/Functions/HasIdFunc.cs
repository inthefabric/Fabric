﻿using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IHasIdFunc : IFunc, IFinalStep {
		
		long Id { get; }

	}


	/*================================================================================================*/
	[Func("HasId")]
	public class HasIdFunc : Func, IHasIdFunc {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public HasIdFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "has");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(1);

			////

			Id = ParamAt<long>(0);

			if ( Id == 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Cannot be 0.", 0);
			}

			////

			ProxyStep = Path.GetSegmentBeforeLast(1).Step;
			IVertexStep ns;

			if ( ProxyStep is IFunc ) {
				ns = (IVertexStep)((IFunc)ProxyStep).ProxyStep;
			}
			else {
				ns = (IVertexStep)ProxyStep;
			}

			string pp = Path.AddParam(new WeaverQueryVal(ns.TypeIdName));
			string ip = Path.AddParam(new WeaverQueryVal(Id));
			Path.AppendToCurrentSegment("("+pp+",Tokens.T.eq,"+ip+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			return true;
		}

	}

}