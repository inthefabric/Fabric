using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class CreateExecutor<TObj, TOper> : FabResponseExecutor<TObj>
										where TObj : FabObject where TOper : ICreateOperation, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateExecutor(IApiRequest pApiReq) : base(pApiReq) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<TObj> GetResponse() {
			string json = ApiReq.GetFormValue("Data");

			if ( json == null ) {
				throw new FabArgumentMissingFault("Data");
			}

			var o = new TOper();
			o.Create(ApiReq.OpCtx, new TxBuilder(), json);

			var list = new List<TObj>();
			list.Add((TObj)o.GetResult());
			return list;
		}

	}

}