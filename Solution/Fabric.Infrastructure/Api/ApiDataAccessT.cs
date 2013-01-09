using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess<T> : ApiDataAccess, IApiDataAccess<T> where T : INodeWithId, new() {

		public T TypedResult { get; private set; }
		public IList<T> TypedResultList { get; private set; }



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript,
						IDictionary<string, string> pParams=null) : base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :base(pContext, pScripted){}


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