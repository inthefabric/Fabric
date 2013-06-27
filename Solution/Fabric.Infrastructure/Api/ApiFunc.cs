using System;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public abstract class ApiFunc<TReturn> : IApiFunc<TReturn> {

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

}