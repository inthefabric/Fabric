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
		public static void Execute(this IApiContext pApiCtx, IWeaverScript pWeaverScript) {
			pApiCtx.NewData().AddQuery(pWeaverScript).Execute();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T Get<T>(this IApiContext pApiCtx, IWeaverScript pWeaverScript)
												where T : class, IWeaverElement, IElementWithId, new() {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute().ToElement<T>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IList<T> GetList<T>(this IApiContext pApiCtx, IWeaverScript pWeaverScript)
												where T : class, IWeaverElement, IElementWithId, new() {
			return pApiCtx.NewData().AddQuery(pWeaverScript).Execute().ToElementList<T>();
		}

	}

}