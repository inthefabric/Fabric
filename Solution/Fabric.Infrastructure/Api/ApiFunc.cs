using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public abstract class ApiFunc<TReturn> : ApiFunc, IApiFunc<TReturn> {

		public IApiContext ApiCtx { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TReturn Go(IApiContext pContext) {
			ApiCtx = pContext;
			ValidateParams();
			return Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ValidateParams();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract TReturn Execute();

		/*--------------------------------------------------------------------------------------------*/
		protected void SetApiCtx(IApiContext pApiCtx) {
			if ( ApiCtx != null ) {
				throw new Exception("ApiCtx is already set: "+ApiCtx.ContextId);
			}

			ApiCtx = pApiCtx;
		}

	}

	/*================================================================================================*/
	public class ApiFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static T NewPathFromVar<T>(IWeaverVarAlias<T> pVar, bool pCopyItem)
																		where T : class, INode, new() {
			return Weave.Inst.BeginPath(pVar, pCopyItem).BaseVertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T NewPathFromIndex<T>(T pNodeWithId) where T : class, INode<T>, new() {
			return Weave.Inst.Graph.V.ExactIndex(pNodeWithId.GetTypeIdProp(),
				pNodeWithId.GetTypeId());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IWeaverQuery NewNodeQuery<T>(T pNodeWithId) where T : class, INode<T>, new() {
			return NewPathFromIndex(pNodeWithId).ToQuery();
		}

	}

}