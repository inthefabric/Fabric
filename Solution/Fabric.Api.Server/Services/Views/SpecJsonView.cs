using Fabric.Api.Dto;
using ServiceStack.Text;

namespace Fabric.Api.Server.Services.Views {

	/*================================================================================================*/
	public class SpecJsonView {

		private const string TotalMsJson = "\"TotalMs\":";

		private readonly FabResponse vFabResp;
		private readonly string vSpecJson;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecJsonView(FabResponse pResp, string pSpecJson) {
			vFabResp = pResp;
			vSpecJson = pSpecJson;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetContent() {
			vFabResp.Data = "{DATA}";
			vFabResp.DataLen = vSpecJson.Length;

			string wrap = vFabResp.ToJson().Replace("\"{DATA}\"", vSpecJson);
			vFabResp.Data = vSpecJson;
			vFabResp.Complete(); //last possible moment

			return wrap.Replace(TotalMsJson+"0", TotalMsJson+vFabResp.TotalMs);
		}

	}

}