using System;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabError : FabDto {

		public int Code { get; set; }
		public string CodeName { get; set; }
		public string Type { get; set; }
		public string Message { get; set; }
		

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
		public override void Fill(IDbDto pDbDto) {}

	}

}