using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public static class ApiContextDataExt {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T Get<T>(this IApiContext pApiCtx, IWeaverQuery pQuery)
												where T : class, IWeaverElement, IElementWithId, new() {
			return pApiCtx.NewData().AddQuery(pQuery).Execute().ToElement<T>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IList<T> GetList<T>(this IApiContext pApiCtx, IWeaverQuery pQuery)
												where T : class, IWeaverElement, IElementWithId, new() {
			return pApiCtx.NewData().AddQuery(pQuery).Execute().ToElementList<T>();
		}

	}

}