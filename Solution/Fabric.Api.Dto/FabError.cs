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
		public static FabError FromException(Exception pEx) {
			var e = new FabError();
			e.Code = 0;
			e.CodeName = "UnexpectedError";
			e.Type = pEx.GetType().Name;
			e.Message = pEx.Message;
			return e;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}