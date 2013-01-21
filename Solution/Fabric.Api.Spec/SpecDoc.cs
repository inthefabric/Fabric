using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Oauth.Functions;
using Fabric.Api.Spec.Functions;
using Fabric.Api.Spec.Lang;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {

		private readonly FabSpecDto vFabResp;
		private readonly List<string> vDtoNames;

		private readonly List<FabSpecDto> vTravDtoList;
		private readonly List<FabSpecFunc> vTravFuncList;

		private readonly List<FabSpecDto> vOauthDtoList;
		private readonly List<FabSpecFunc> vOauthFuncList;

		private readonly List<FabSpecDto> vSpecDtoList;
		private readonly List<FabSpecFunc> vSpecFuncList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDoc() {
			vDtoNames = new List<string>();

			foreach ( Type t in Assembly.GetAssembly(typeof(FabDto)).GetTypes() ) {
				if ( t.FullName == null ) {
					continue;
				}

				if ( t.Name.Substring(0, 3) != "Fab" ) {
					continue;
				}

				string name = t.FullName.Replace("Fabric.Api.Dto.", "");

				if ( name.IndexOf('.') == -1 && t != typeof(FabResponse) ) {
					name = "Traversal."+name;
				}

				vDtoNames.Add(name);
			}

			////

			vFabResp = new FabSpecDto();
			vFabResp.Name = typeof(FabResponse).Name;
			vFabResp.Description = GetDtoText(vFabResp.Name.Substring(3));

			Dictionary<string, FabSpecDtoProp> propMap = ReflectProps<FabResponse>();
			vFabResp.PropertyList = propMap.Values.ToList();

			////

			vTravDtoList = BuildDtoList();
			vTravDtoList.Insert(0, GetSpecDto<FabNode>());
			vTravDtoList.Insert(0, GetSpecDto<FabDto>());
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
			vOauthDtoList.Add(GetSpecDto<FabOauth>());
			vOauthDtoList.Add(GetSpecDto<FabOauthAccess>());
			vOauthDtoList.Add(GetSpecDto<FabOauthError>());
			vOauthDtoList.Add(GetSpecDto<FabOauthLogin>());
			vOauthDtoList.Add(GetSpecDto<FabOauthLogout>());

			vOauthFuncList = new List<FabSpecFunc>();
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAt), "/AccessToken"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtac), "/AccessTokenAuthCode"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtr), "/AccessTokenRefresh"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtcc), "/AccessTokenClientCredentials"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthAtcd), "/AccessTokenClientDataProv"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthLogin), "/"));
			vOauthFuncList.Add(GetSpecFunc(typeof(FuncOauthLogout), "/Logout"));

			////
			
			vSpecDtoList = new List<FabSpecDto>();
			vSpecDtoList.Add(GetSpecDto<FabSpec>());
			vSpecDtoList.Add(GetSpecDto<FabSpecDto>());
			vSpecDtoList.Add(GetSpecDto<FabSpecDtoLink>());
			vSpecDtoList.Add(GetSpecDto<FabSpecDtoProp>());
			vSpecDtoList.Add(GetSpecDto<FabSpecFunc>());
			vSpecDtoList.Add(GetSpecDto<FabSpecFuncParam>());

			foreach ( FabSpecDto sd in vSpecDtoList ) {
				sd.Description = null;

				foreach ( FabSpecDtoProp p in sd.PropertyList ) {
					p.Description = null;
				}
			}

			vSpecFuncList = new List<FabSpecFunc>();
			vSpecFuncList.Add(GetSpecFunc(typeof(FuncSpec), "/"));
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabSpec GetFabSpec() {
			var fs = new FabSpec();
			fs.ApiResponse = vFabResp;

			fs.TraversalService = new FabSpecService();
			fs.TraversalService.Name = GetServiceText("Traversal");
			fs.TraversalService.Description = GetServiceText("TraversalDesc");
			fs.TraversalService.Uri = "/Root";
			fs.TraversalService.DtoList = vTravDtoList;
			fs.TraversalService.FunctionList = vTravFuncList;

			fs.OauthService = new FabSpecService();
			fs.OauthService.Name = GetServiceText("Oauth");
			fs.OauthService.Description = GetServiceText("OauthDesc");
			fs.OauthService.Uri = "/Oauth";
			fs.OauthService.DtoList = vOauthDtoList;
			fs.OauthService.FunctionList = vOauthFuncList;

			fs.SpecService = new FabSpecService();
			fs.SpecService.Name = GetServiceText("Spec");
			fs.SpecService.Description = GetServiceText("SpecDesc");
			fs.SpecService.Uri = "/Spec";
			fs.SpecService.DtoList = vSpecDtoList;
			fs.SpecService.FunctionList = vSpecFuncList;

			return fs;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string GetServiceText(string pName) {
			string s = ServiceText.ResourceManager.GetString(pName);
			if ( s != null ) { s = FormatMarkup(s); }
			return (s ?? "MISSING:"+pName);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetDtoText(string pName) {
			string s = DtoText.ResourceManager.GetString(pName);
			if ( s != null ) { s = FormatMarkup(s); }
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetDtoPropText(string pName) {
			string s = DtoPropText.ResourceManager.GetString(pName);
			if ( s != null ) { s = FormatMarkup(s); }
			return (s ?? "MISSING:"+pName);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetFuncText(string pName) {
			string s = FuncText.ResourceManager.GetString(pName);
			if ( s != null ) { s = FormatMarkup(s); }
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetFuncParamText(string pName) {
			string s = FuncParamText.ResourceManager.GetString(pName);
			if ( s != null ) { s = FormatMarkup(s); }
			return (s ?? "MISSING:"+pName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabSpecDto GetSpecDto<T>() where T : FabDto {
			var sd = new FabSpecDto();
			sd.Name = typeof(T).Name;
			sd.Description = GetDtoText(sd.Name.Substring(3));

			if ( typeof(T) != typeof(FabDto) ) {
				sd.Extends = typeof(FabDto).Name;
			}

			Dictionary<string, FabSpecDtoProp> propMap = ReflectProps<T>();
			sd.PropertyList = propMap.Values.ToList();
			return sd;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Dictionary<string, FabSpecDtoProp> ReflectProps<T>() {
			PropertyInfo[] props = typeof(T).GetProperties(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			var results = new Dictionary<string, FabSpecDtoProp>();

			foreach ( PropertyInfo pi in props ) {
				object[] dpaList = pi.GetCustomAttributes(typeof(DtoPropAttribute), true);
				DtoPropAttribute dpa = (dpaList.Length > 0 ? (DtoPropAttribute)dpaList[0] : null);

				if ( dpa != null && dpa.IsInternal ) {
					continue;
				}

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
				object[] fpaList = pi.GetCustomAttributes(typeof(FuncParamAttribute), false);
				
				if ( fpaList.Length == 0 ) {
					continue;
				}

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string FormatMarkup(string pText) {
			pText = pText+"";

			for ( int i = 0 ; i < vDtoNames.Count ; ++i ) {
				string dto = vDtoNames[i];
				pText = FindSmartLinks(pText, dto, true);
				pText = FindSmartLinks(pText, dto, false);
			}

			return pText;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string FindSmartLinks(string pText, string pDtoNameAndPath, bool pFabMode) {
			int dotI = pDtoNameAndPath.LastIndexOf('.');
			string dtoName = (dotI == -1 ? pDtoNameAndPath : pDtoNameAndPath.Substring(dotI+1));
			string item = dtoName.Substring(pFabMode ? 0 : 3); //remove "Fab"
			var re = new Regex(@"\b"+item+@"(\b|s\b|es\b)"); //ends normally, or with 's' or 'es'
			int pos = 0;

			while ( true ) {
				Match m = re.Match(pText, pos);
				if ( !m.Success ) { break; }

				//ensure the match is not within a link.

				//int anchorI = HtmlText.LastIndexOf("<a href", m.Index, m.Index-pos);
				int anchorI = pText.LastIndexOf("[[", m.Index, m.Index-pos);

				if ( anchorI != -1 ) {
					//int anchorEndI = HtmlText.IndexOf("</a>", anchorI+7);
					int anchorEndI = pText.IndexOf("]]", anchorI+7);

					if ( anchorEndI > m.Index ) {
						pos = anchorEndI;
						continue;
					}
				}

				//ensure the match does not use the escape character

				if ( m.Index > 0 && pText[m.Index-1] == '!' ) {
					pText = pText.Remove(m.Index-1, 1);
					pos = m.Index+m.Length-1;
					continue;
				}

				//replace the match with a link

				//string link = "<a href='"+DocsUtil.DtosUrl+pDtoName+"'>"+m.Captures[0]+"</a>";
				string link = "[["+m.Captures[0]+"|Dto|"+pDtoNameAndPath+"]]";
				pos = m.Index+(link.Length-m.Length);
				pText = pText.Remove(m.Index, m.Length);
				pText = pText.Insert(m.Index, link);
			}

			return pText;
		}

	}

}