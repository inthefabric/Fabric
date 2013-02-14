using Fabric.Api.Common;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;

namespace Fabric.Api.Services.Views {

	/*================================================================================================*/
	public class TraversalJsonView : IView {

		private readonly TraversalModel vInfo;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalJsonView(TraversalModel pInfo) {
			vInfo = pInfo;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetContent() {
			string data;

			if ( vInfo.Error != null ) {
				data = vInfo.Error.ToJson();
			}
			else {
				data = BuildJson();
			}
			
			vInfo.Resp.Data = "{DATA}";
			vInfo.Resp.DataLen = data.Length;

			string wrap = vInfo.Resp.ToJson().Replace("\"{DATA}\"", data);
			vInfo.Resp.Data = data;
			vInfo.Resp.Complete(); //last possible moment

			return wrap.Replace(FabRespJsonView.TotalMsJson+"0",
				FabRespJsonView.TotalMsJson+vInfo.Resp.TotalMs);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildJson() {
			if ( vInfo.DtoList == null ) {
				return "[]"; //"{\"Text\":\""+FabricUtil.JsonUnquote(vInfo.NonDtoText)+"\"}";
			}

			var json = "";

			foreach ( DbDto dbDto in vInfo.DtoList ) {
				json += (json == "" ? "" : ",")+ApiDtoUtil.ToDtoJson(dbDto);
			}

			return "["+json+"]";
		}

	}

}