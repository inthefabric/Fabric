using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Api.Spec.Lang;
using Fabric.Infrastructure.Domain;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {

		public string ApiVersion { get; set; }
		public SpecApiResponse ApiResponse { get; set; }
		public List<SpecDto> DtoList { get; set; }
		public List<SpecFunc> FunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDoc() {
			ApiResponse = new SpecApiResponse();
			DtoList = BuildDtoList();
			DtoList.Insert(0, GetSpecDto<FabNode>());
			DtoList.Add(GetSpecDto<FabOauth>());
			DtoList.Add(GetSpecDto<FabOauthAccess>());
			DtoList.Add(GetSpecDto<FabOauthError>());
			DtoList.Add(GetSpecDto<FabOauthLogin>());
			DtoList.Add(GetSpecDto<FabOauthLogout>());
			DtoList.Add(GetSpecDto<FabError>());

			////

			FunctionList = new List<SpecFunc>();
			Assembly a = Assembly.GetAssembly(typeof(FuncBackStep));

			foreach ( Type t in a.GetTypes() ) {
				if ( t.GetCustomAttributes(typeof(FuncAttribute), false).Length == 0 ) {
					continue;
				}

				FunctionList.Add(new SpecFunc(t));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Dictionary<string,SpecDtoProp> ReflectProps<T>() {
			PropertyInfo[] props = typeof(T).GetProperties();
			var results = new Dictionary<string,SpecDtoProp>();

			foreach ( PropertyInfo pi in props ) {
				object[] dpaList = pi.GetCustomAttributes(typeof(DtoPropAttribute), true);
				DtoPropAttribute dpa = (dpaList.Length > 0 ? (DtoPropAttribute)dpaList[0] : null);

				var specProp = new SpecDtoProp();
				specProp.Name = (dpa == null ? pi.Name : dpa.DisplayName);
				specProp.Type = SchemaHelperProp.GetTypeName(pi.PropertyType);
				specProp.Description = GetDtoPropText(typeof(T).Name.Substring(3)+"_"+pi.Name);
				results.Add(pi.Name, specProp);
			}

			return results;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoText(string pName) {
			string s = DtoText.ResourceManager.GetString(pName);
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoPropText(string pName) {
			string s = DtoPropText.ResourceManager.GetString(pName);
			return (s ?? "MISSING:"+pName);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static string GetFuncText(string pName) {
			string s = FuncText.ResourceManager.GetString(pName);
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetFuncParamText(string pName) {
			string s = FuncParamText.ResourceManager.GetString(pName);
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public SpecDto GetSpecDto(string pName) {
			foreach ( SpecDto dto in DtoList ) {
				if ( dto.Name == pName ) { return dto; }
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private SpecDto GetSpecDto<T>() {
			var sd = new SpecDto();
			sd.Name = typeof(T).Name;
			sd.Description = GetDtoText(sd.Name.Substring(3));
			sd.Abstract = sd.Description.Substring(0, sd.Description.IndexOf('.')+1);

			Dictionary<string, SpecDtoProp> propMap = ReflectProps<T>();
			sd.PropertyList = propMap.Values.ToList();
			return sd;
		}

	}

}