using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Interfaces;

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
		public static T NewPathFromType<T>() where T : class, INode, new() {
			return Weave.Inst.BeginPath<T>(x => x.FabType, 
				(byte)NodeFabTypeUtil.TypeMap[typeof(T)]).BaseNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T NewPathFromVar<T>(IWeaverVarAlias<T> pVar, bool pCopyItem)
																		where T : class, INode, new() {
			return Weave.Inst.BeginPath(pVar, pCopyItem).BaseNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T NewPathFromIndex<T>(T pNodeWithId) where T : class, INode, new() {
			return Weave.Inst.BeginPath(pNodeWithId.GetTypeIdProp<T>(),
				pNodeWithId.GetTypeId()).BaseNode;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IWeaverQuery NewNodeQuery<T>(T pNodeWithId) where T : class, INode, new() {
			return NewPathFromIndex(pNodeWithId).End();
		}

	}

}