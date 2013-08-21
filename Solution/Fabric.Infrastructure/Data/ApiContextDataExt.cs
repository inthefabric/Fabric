using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public static class ApiContextDataExt {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IDataResult Execute(this IApiContext pApiCtx, IWeaverScript pWeaverScript,
																						string pName) {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute(pName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T Get<T>(this IApiContext pApiCtx, IWeaverScript pWeaverScript,
						string pName="default") where T : class, IWeaverElement, IElementWithId, new() {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute(pName).ToElement<T>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IList<T> GetList<T>(this IApiContext pApiCtx, IWeaverScript pWeaverScript,
						string pName="default") where T : class, IWeaverElement, IElementWithId, new() {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute(pName).ToElementList<T>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T GetVertexById<T>(this IApiContext pApiCtx, long pTypeId)
														where T : class, IVertex, IVertexWithId, new() {
			T item = pApiCtx.Cache.Memory.FindVertex<T>(pTypeId);

			if ( item != null ) {
				return item;
			}

			item = new T();
			item.SetTypeId(pTypeId);

			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(item).ToQuery();
			item = pApiCtx.NewData().AddQuery(q).Execute("GetVertexById").ToElement<T>();

			if ( item == null ) {
				pApiCtx.Cache.Memory.RemoveVertex<T>(pTypeId);
			}
			else {
				pApiCtx.Cache.Memory.AddVertex(item);
			}

			return item;
		}

	}

}