using System;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabError : FabObject {

		public int Code { get; set; }
		public string CodeName { get; set; }
		public string Type { get; set; }
		public string Message { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabError ForInternalServerError() {
			var e = new FabError();
			e.Code = 0;
			e.CodeName = "InternalError";
			e.Type = typeof(Exception).Name;
			e.Message = "An internal server error occurred.";
			return e;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabError ForFault(FabFault pFault) {
			var e = new FabError();
			e.Code = (int)pFault.ErrCode;
			e.CodeName = pFault.ErrCode+"";
			e.Type = pFault.GetType().Name;
			e.Message = pFault.Message;
			return e;
		}


	}

}