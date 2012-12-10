using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Infrastructure;
using ServiceStack.Text;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiResponseJson {

		private const string TotalMsJson = "\"TotalMs\":";

		private readonly ApiQueryInfo vInfo;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiResponseJson(ApiQueryInfo pInfo) {
			vInfo = pInfo;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetContent() {
			var build = GetType()
				.GetMethod("BuildTypedJson", (BindingFlags.NonPublic | BindingFlags.Instance))
				.MakeGenericMethod(new[] { vInfo.DtoType });

			string data = (string)build.Invoke(this, new object[] {});
			
			vInfo.Resp.Data = "{DATA}";
			vInfo.Resp.DataLen = data.Length;

			string wrap = vInfo.Resp.ToJson().Replace("\"{DATA}\"", data);
			vInfo.Resp.Data = data;
			vInfo.Resp.Complete(); //last possible moment
			return wrap.Replace(TotalMsJson+"0", TotalMsJson+vInfo.Resp.TotalMs);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildTypedJson<T>() where T : FabNode {
			if ( vInfo.DtoList == null ) {
				if ( vInfo.NonDtoText == null ) {
					return "{}";
				}

				return "{\"Text\":\""+FabricUtil.JsonUnquote(vInfo.NonDtoText)+"\"}";
			}

			if ( vInfo.IsSingleDto ) {
				T n = (T)Activator.CreateInstance(vInfo.DtoType);
				n.Fill(vInfo.DtoList[0]);
				return n.ToJson();
			}

			var nodeList = new List<T>();

			foreach ( DbDto dbDto in vInfo.DtoList ) {
				T n = (T)Activator.CreateInstance(vInfo.DtoType);
				n.Fill(dbDto);
				nodeList.Add(n);
			}

			return nodeList.ToJson();
		}

	}

}