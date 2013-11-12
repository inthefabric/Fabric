using System.Collections.Generic;
using Fabric.New.Api.Objects;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class MenuExecutor<TObj> : FabResponseExecutor<TObj> where TObj : FabObject, new() {

		private readonly TObj vObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MenuExecutor(IApiRequest pApiReq, TObj pObject) : base(pApiReq) {
			vObj = pObject;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<TObj> GetResponse() {
			return new List<TObj> { vObj };
		}

	}

}