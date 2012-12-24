using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Weaver;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess<T> : ApiDataAccess where T : INode, new() {

		public T TypedResult { get; private set; }
		public List<T> TypedResultList { get; private set; }



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(ApiContext pContext, string pScript,
						IDictionary<string, string> pParams=null) : base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(ApiContext pContext, WeaverQuery pQuery) : base(pContext, pQuery) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Execute() {
			base.Execute();

			if ( ResultDto != null ) {
				TypedResult = BuildTypedResult(ResultDto);
			}
			else if ( ResultDtoList != null ) {
				TypedResultList = new List<T>();

				foreach ( DbDto dbDto in ResultDtoList ) {
					TypedResultList.Add(BuildTypedResult(dbDto));
				}
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static T BuildTypedResult(DbDto pDbDto) {
			if ( pDbDto.Id == null ) {
				throw new FabArgumentNullFault("DbDto.Id");
			}

			T result = new T();
			result.Id = (long)pDbDto.Id;

			Type resultType = typeof(T);

			foreach ( string key in pDbDto.Data.Keys ) {
				resultType.GetProperty(key).SetValue(result, pDbDto.Data[key], null);
			}

			return result;
		}

	}

}