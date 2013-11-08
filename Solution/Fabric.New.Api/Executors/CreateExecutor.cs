using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Operations.Create;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class CreateExecutor<TObj, TOper> : FabResponseExecutor<TObj>
										where TObj : FabObject where TOper : ICreateOperation, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateExecutor(IApiRequest pApiReq) : base(pApiReq) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<TObj> GetResponse() {
			string json = ApiReq.GetFormValue("data");

			//TODO: CreateExecutor: throw fault on missing data

			var o = new TOper();
			o.Create(ApiReq.ApiCtx, json);

			var list = new List<TObj>();
			list.Add((TObj)o.GetResult());
			return list;
		}

	}

}