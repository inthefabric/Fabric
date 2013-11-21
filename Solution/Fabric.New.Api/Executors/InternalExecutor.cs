using Fabric.New.Api.Interfaces;
using Fabric.New.Operations.Internal;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class InternalExecutor<T> : BasicExecutor<object> where T : IInternalOperation, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InternalExecutor(IApiRequest pApiReq) : base(pApiReq) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override object GetResponse() {
			var o = new T();
			o.Perform(ApiReq.OpCtx, ApiReq.GetQueryValue("pass"));
			return o.GetResult();
		}

	}

}