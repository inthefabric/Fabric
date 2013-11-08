namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public class FabError : FabObject {

		public int Code { get; set; }
		public string Name { get; set; }
		public string Message { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public override void Fill(IDataDto pDto) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static FabError ForInternalServerError() {
			var e = new FabError();
			e.Code = (int)FabFault.Code.InternalError;
			e.Name = FabFault.Code.InternalError+"";
			e.Message = "An internal server error occurred.";
			return e;
		}

		/*--------------------------------------------------------------------------------------------* /
		public static FabError ForFault(FabFault pFault) {
			var e = new FabError();
			e.Code = (int)pFault.ErrCode;
			e.Name = pFault.ErrCode+"";
			e.Message = pFault.Message;
			return e;
		}*/

	}

}