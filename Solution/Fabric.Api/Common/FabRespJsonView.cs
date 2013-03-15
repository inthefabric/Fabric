﻿using Fabric.Api.Dto;
using Fabric.Api.Services.Views;
using ServiceStack.Text;

namespace Fabric.Api.Common {

	/*================================================================================================*/
	public class FabRespJsonView : IView {

		public const string TotalMsJson = "\"TotalMs\":";

		private readonly FabResponse vFabResp;
		private readonly string vDataJson;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabRespJsonView(FabResponse pResp, string pSpecJson) {
			vFabResp = pResp;
			vDataJson = pSpecJson;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetContent() {
			string wrap;
			
			if ( vDataJson != null ) {
				vFabResp.Data = "{DATA}";
				vFabResp.DataLen = vDataJson.Length;
				wrap = vFabResp.ToJson().Replace("\"{DATA}\"", vDataJson);
			}
			else {
				wrap = vFabResp.ToJson();
			}
			
			vFabResp.Data = vDataJson;
			vFabResp.Complete(); //last possible moment

			return wrap.Replace(TotalMsJson+"0", TotalMsJson+vFabResp.TotalMs);
		}

	}

}