using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess<T> : ApiDataAccess, IApiDataAccess<T> where T : INode, new() {

		public T TypedResult { get; private set; }
		public List<T> TypedResultList { get; private set; }



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(ApiContext pContext, string pScript,
						IDictionary<string, string> pParams=null) : base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(ApiContext pContext, IWeaverQuery pQuery) : base(pContext, pQuery) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Execute() {
			base.Execute();

			if ( ResultDto != null ) {
				TypedResult = ResultDto.ToNode<T>();
			}
			else if ( ResultDtoList != null ) {
				TypedResultList = new List<T>();

				foreach ( DbDto dbDto in ResultDtoList ) {
					TypedResultList.Add(dbDto.ToNode<T>());
				}
			}
		}

	}

}