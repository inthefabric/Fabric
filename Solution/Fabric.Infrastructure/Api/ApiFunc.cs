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
		public static T NewPathFromIndex<T>(T pVertexWithId) where T : class, IVertex, new() {
			return Weave.Inst.Graph.V.ExactIndex(pVertexWithId.GetTypeIdProp<T>(),
				pVertexWithId.GetTypeId());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IWeaverQuery NewVertexQuery<T>(T pVertexWithId) where T : class, IVertex, new() {
			return NewPathFromIndex(pVertexWithId).ToQuery();
		}

	}

}