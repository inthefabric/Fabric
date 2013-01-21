using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Oauth.Functions;
using Fabric.Api.Spec.Functions;
using Fabric.Api.Spec.Lang;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {

		private readonly FabSpecDto vFabResp;

		private readonly List<FabSpecDto> vTravDtoList;
		private readonly List<FabSpecFunc> vTravFuncList;

		private readonly List<FabSpecDto> vOauthDtoList;
		private readonly List<FabSpecFunc> vOauthFuncList;

		private readonly List<FabSpecDto> vSpecDtoList;
		private readonly List<FabSpecFunc> vSpecFuncList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDoc() {
			vFabResp = new FabSpecDto();
			vFabResp.Name = typeof(FabResponse).Name;
			vFabResp.Description = GetDtoText(vFabResp.Name.Substring(3));

			Dictionary<string, FabSpecDtoProp> propMap = ReflectProps<FabResponse>();
			vFabResp.PropertyList = propMap.Values.ToList();

			////

			vTravDtoList = BuildDtoList();
			vTravDtoList.Insert(0, GetSpecDto<FabDto>());
			vTravDtoList.Insert(0, GetSpecDto<FabNode>());
			vTravDtoList.Add(GetSpecDto<FabError>());

			vTravFuncList = new List<FabSpecFunc>();
			Assembly a = Assembly.GetAssembly(typeof(FuncBackStep));

			foreach ( Type t in a.GetTypes() ) {
				if ( t.GetCustomAttributes(typeof(FuncAttribute), false).Length == 0 ) {
					continue;
				}

				vTravFuncList.Add(GetSpecFunc(t));
			}

			////
			
			vOauthDtoList = new List<FabSpecDto>();
			vOauthDtoList.Add(GetSpecDto<FabOauth>(true));
			vOauthDtoList.Add(GetSpecDto<FabOauthAccess>(true));
			vOauthDtoList.Add(GetSpecDto<FabOauthError>(true));
			vOauthDtoList.Add(GetSpecDto<FabOauthLogin>(true));
			vOauthDtoList.Add(GetSpecDto<FabOauthLogout>(true));

			vOauthFuncList = new List<FabSpecFunc>();
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtStep), "/AccessToken"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtacStep), "/AccessTokenAuthCode"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtrStep), "/AccessTokenRefresh"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtccStep), "/AccessTokenClientCredentials"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtcdStep), "/AccessTokenClientDataProv"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthLoginStep), "/"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthLogoutStep), "/Logout"));

			////
			
			vSpecDtoList = new List<FabSpecDto>();
			vSpecDtoList.Add(GetSpecDto<FabSpec>(true));
			vSpecDtoList.Add(GetSpecDto<FabSpecDto>(true));
			vSpecDtoList.Add(GetSpecDto<FabSpecDtoLink>(true));
			vSpecDtoList.Add(GetSpecDto<FabSpecDtoProp>(true));
			vSpecDtoList.Add(GetSpecDto<FabSpecFunc>(true));
			vSpecDtoList.Add(GetSpecDto<FabSpecFuncParam>(true));

			vSpecFuncList = new List<FabSpecFunc>();
			vSpecFuncList.Add(GetSpecFunc(typeof(FuncSpecStep), "/"));
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabSpec GetFabSpec() {
			var fs = new FabSpec();
			fs.ApiResponse = vFabResp;

			fs.TraversalService = new FabSpecService();
			fs.TraversalService.Name = "TODO";
			fs.TraversalService.Description = "TODO";
			fs.TraversalService.Uri = "/Root";
			fs.TraversalService.DtoList = vTravDtoList;
			fs.TraversalService.FunctionList = vTravFuncList;

			fs.OauthService = new FabSpecService();
			fs.OauthService.Name = "TODO";
			fs.OauthService.Description = "TODO";
			fs.OauthService.Uri = "/Oauth";
			fs.OauthService.DtoList = vOauthDtoList;
			fs.OauthService.FunctionList = vOauthFuncList;

			fs.SpecService = new FabSpecService();
			fs.SpecService.Name = "TODO";
			fs.SpecService.Description = "TODO";
			fs.SpecService.Uri = "/Spec";
			fs.SpecService.DtoList = vSpecDtoList;
			fs.SpecService.FunctionList = vSpecFuncList;

			return fs;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
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

		/*--------------------------------------------------------------------------------------------* /
		public FabSpecDto GetSpecDto(string pName) {
			foreach ( FabSpecDto dto in vDtoList ) {
				if ( dto.Name == pName ) { return dto; }
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabSpecDto GetSpecDto<T>(bool pNoLinksFuncs=false) where T : FabDto {
			var sd = new FabSpecDto();
			sd.Name = typeof(T).Name;
			sd.Description = GetDtoText(sd.Name.Substring(3));

			if ( typeof(T) != typeof(FabDto) ) {
				sd.Extends = typeof(FabDto).Name;
			}

			Dictionary<string, FabSpecDtoProp> propMap = ReflectProps<T>();
			sd.PropertyList = propMap.Values.ToList();

			if ( pNoLinksFuncs ) {
				sd.LinkList = null;
				sd.FunctionList = null;
				return sd;
			}

			List<string> availFuncs = FuncRegistry.GetAvailableFuncs(typeof(T), true);
			sd.FunctionList = new List<string>();
		
			foreach ( string funcUri in availFuncs ) {
				sd.FunctionList.Add(funcUri.Substring(1));
			}

			return sd;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, FabSpecDtoProp> ReflectProps<T>() {
			PropertyInfo[] props = typeof(T).GetProperties();
			var results = new Dictionary<string, FabSpecDtoProp>();

			foreach ( PropertyInfo pi in props ) {
				object[] dpaList = pi.GetCustomAttributes(typeof(DtoPropAttribute), true);
				DtoPropAttribute dpa = (dpaList.Length > 0 ? (DtoPropAttribute)dpaList[0] : null);

				var specProp = new FabSpecDtoProp();
				specProp.Name = (dpa == null ? pi.Name : dpa.DisplayName);
				specProp.Type = SchemaHelperProp.GetTypeName(pi.PropertyType);
				specProp.Description = GetDtoPropText(typeof(T).Name.Substring(3)+"_"+pi.Name);
				results.Add(pi.Name, specProp);
			}

			return results;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabSpecFunc GetSpecFunc(Type pFuncType, string pUri=null) {
			var fa = (FuncAttribute)pFuncType.GetCustomAttributes(typeof(FuncAttribute), false)[0];

			var func = new FabSpecFunc();
			func.Name = fa.Name;
			func.ReturnType = (fa.ReturnType == null ? null : fa.ReturnType.Name);
			string resxKey = (fa.ResxKey ?? func.Name);
			func.Description = GetFuncText(resxKey);
			func.Uri = pUri;
			func.ParameterList = new List<FabSpecFuncParam>();

			PropertyInfo[] props = pFuncType.GetProperties();

			foreach ( PropertyInfo pi in props ) {
				object[] fpaList = pi.GetCustomAttributes(typeof(FuncParamAttribute), true);
				if ( fpaList.Length == 0 ) { continue; }
				FuncParamAttribute fpa = (FuncParamAttribute)fpaList[0];
				
				var p = new FabSpecFuncParam();
				p.Name = pi.Name;
				p.Description = GetFuncParamText((fpa.FuncResxKey ?? resxKey)+"_"+p.Name);
				p.Index = fpa.ParamIndex;
				p.Type = SchemaHelperProp.GetTypeName(pi.PropertyType);
				p.Min = fpa.Min;
				p.Max = fpa.Max;
				p.IsRequired = fpa.IsRequired;
				p.DisplayName = fpa.DisplayName;
				p.UsesQueryString = fpa.UsesQueryString;
				func.ParameterList.Add(p);
			}

			func.ParameterList.Sort((a, b) => (a.Index > b.Index ? 1 : (a.Index == b.Index ? 0 : -1)));
			return func;
		}

	}

}