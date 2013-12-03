using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class CreateExecutor<TDom, TApi, TOp> : FabResponseExecutor<TApi>
														where TDom : Vertex
														where TApi : FabVertex
														where TOp : ICreateOperation<TDom,TApi>, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateExecutor(IApiRequest pApiReq) : base(pApiReq) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<TApi> GetResponse() {
			string json = ApiReq.GetFormValue("Data");

			if ( json == null ) {
				throw new FabArgumentMissingFault("Data");
			}

			var o = new TOp();
			o.Create(ApiReq.OpCtx, new TxBuilder(), json);
			o.Execute();
			return new List<TApi> { o.GetResult() };
		}

	}

}