using System;
using Fabric.Infrastructure;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabError : IFabDto {

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
		public void Fill(IDbDto pDbDto) {}

	}

}