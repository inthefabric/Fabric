using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess<T> : ApiDataAccess, IApiDataAccess<T> where T : IElementWithId, new() {

		public IList<T> TypedResultList { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript,
				IDictionary<string, IWeaverQueryVal> pParams=null) : base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :base(pContext, pScripted){}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Execute() {
			base.Execute();

			IList<IGraphElement> elems = Result.GetGraphElementsAt(0);
			TypedResultList = new List<T>();
			
			foreach ( IGraphElement elem in elems ) {
				TypedResultList.Add(new DbDto(elem).ToItem<T>());
			}
		}

	}

}