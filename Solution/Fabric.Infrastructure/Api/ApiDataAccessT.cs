using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess<T> : ApiDataAccess, IApiDataAccess<T> where T : IItemWithId, new() {

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

			if ( Result.DbDtos == null ) {
				return;
			}

			TypedResultList = new List<T>();
			
			foreach ( DbDto dbDto in Result.DbDtos ) {
				TypedResultList.Add(dbDto.ToItem<T>());
			}
		}

	}

}