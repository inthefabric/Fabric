using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public abstract class ApiFunc<TReturn> : ApiFunc, IApiFunc<TReturn> {

		public IApiContext Context { get; private set; }


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

	}

	/*================================================================================================*/
	public class ApiFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Root NewPathFromRoot() {
			return WeaverTasks.BeginPath(new Root()).BaseNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T NewPathFromIndex<T>(T pNodeWithId) where T : class, INode, new() {
			return WeaverTasks.BeginPath(typeof(T).Name, pNodeWithId.GetTypeIdProp<T>(),
				pNodeWithId.GetTypeId()).BaseNode;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IWeaverQuery NewNodeQuery<T>(T pNodeWithId) where T : class, INode, new() {
			return NewPathFromIndex(pNodeWithId).End();
		}

	}

}