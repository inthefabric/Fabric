using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public static class ApiContextDataExt {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IDataResult Execute(this IOperationContext pApiCtx, IWeaverScript pWeaverScript,
																						string pName) {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute(pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T Get<T>(this IOperationContext pApiCtx, IWeaverScript pWeaverScript,
								string pName) where T : class, IElement, new() {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute(pName).ToElement<T>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IList<T> GetList<T>(this IOperationContext pApiCtx, IWeaverScript pWeaverScript,
								string pName) where T : class, IElement, new() {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute(pName).ToElementList<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T GetVertexById<T>(this IOperationContext pApiCtx, long pVertexId)
																	where T : Vertex, new() {
			T item = pApiCtx.Cache.Memory.FindVertex<T>(pVertexId);

			if ( item != null ) {
				return item;
			}

			item = new T();
			item.VertexId = pVertexId;

			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(item).ToQuery();
			item = pApiCtx.NewData().AddQuery(q).Execute("GetVertexById").ToElement<T>();

			if ( item == null ) {
				pApiCtx.Cache.Memory.RemoveVertex<T>(pVertexId);
			}
			else {
				pApiCtx.Cache.Memory.AddVertex(item);
			}

			return item;
		}

	}

}