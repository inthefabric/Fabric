using System;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public abstract class ApiFunc<TReturn> : IApiFunc<TReturn> {

		public IApiContext Context { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiFunc() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TReturn Go(IApiContext pContext) {
			Context = pContext;
			ValidateParams();
			return Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ValidateParams();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract TReturn Execute();



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Root NewPathFromRoot() {
			return WeaverTasks.BeginPath(new Root()).BaseNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T NewPathFromIndex<T>(Expression<Func<T,object>> pFunc, long pId)
														where T : class, IWeaverItemIndexable, new() {
			return WeaverTasks.BeginPath(typeof(T).Name, pFunc, pId).BaseNode;
		}

	}

}