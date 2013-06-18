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
		/*--------------------------------------------------------------------------------------------*/
		public static T NewPathFromIndex<T>(T pNodeWithId) where T : class, INode, new() {
			return Weave.Inst.Graph.V.ExactIndex(pNodeWithId.GetTypeIdProp<T>(),
				pNodeWithId.GetTypeId());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IWeaverQuery NewNodeQuery<T>(T pNodeWithId) where T : class, INode, new() {
			return NewPathFromIndex(pNodeWithId).ToQuery();
		}

	}

}