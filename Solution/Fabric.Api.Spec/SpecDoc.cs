using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Modify;
using Fabric.Api.Oauth;
using Fabric.Api.Spec.Lang;
using Fabric.Api.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {

		private const string DtoNamespace = "Fabric.Api.Dto.";
		private const string OauthDtoNamespace = DtoNamespace+"Oauth";
		private const string ModDtoNamespace = DtoNamespace+"Modify";
		private const string TravDtoNamespace = DtoNamespace+"Traversal";
		private const string SpecDtoNamespace = DtoNamespace+"Spec";

		private readonly List<string> vDtoNames;
		private readonly List<FabSpecDto> vDtoList;
		private readonly List<FabSpecService> vServiceList;
		private readonly Dictionary<string, Assembly> vAssemblyMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDoc() {
			vDtoNames = new List<string>();

			foreach ( Type t in Assembly.GetAssembly(typeof(FabDto)).GetTypes() ) {
				if ( t.FullName == null ) { continue; }
				if ( t.Name.Substring(0, 3) != "Fab" ) { continue; }

				string name = t.FullName.Replace("Fabric.Api.Dto.", "");

				if ( name.IndexOf('.') == -1 && t != typeof(FabResponse) ) {
					name = "Traversal."+name;
				}

				vDtoNames.Add(name);
			}

			////

			var specFabResp = new FabSpecDto();
			specFabResp.Name = typeof(FabResponse).Name;
			specFabResp.Description = GetDtoText(specFabResp.Name.Substring(3));
			specFabResp.Properties = ReflectProps(typeof(FabResponse));

			vDtoList = new List<FabSpecDto>();
			vDtoList.Add(specFabResp);
			vDtoList.Add(GetSpecDto(typeof(FabDto)));
			vDtoList.Add(GetSpecDto(typeof(FabError)));
			vDtoList.Add(GetSpecDto(typeof(FabHome)));
			vDtoList.Add(GetSpecDto(typeof(FabService)));
			vDtoList.Add(GetSpecDto(typeof(FabServiceOperation)));

			////

			vAssemblyMap = new Dictionary<string, Assembly>();
			vAssemblyMap.Add("Oauth", Assembly.GetAssembly(typeof(OauthAccessBase)));
			vAssemblyMap.Add("Modify", Assembly.GetAssembly(typeof(CreateApp)));
			vAssemblyMap.Add("Traversal", Assembly.GetAssembly(typeof(PathSegment)));
			vAssemblyMap.Add("Spec", Assembly.GetAssembly(typeof(SpecDoc)));

			////

			vServiceList = new List<FabSpecService>();
			var home = new FabHome(true);

			foreach ( FabService svc in home.Services ) {
				vServiceList.Add(GetSpecService(svc));
			}

			//TODO: load links and availablefunctions for Traversal
			//TODO: load ServiceOpParams
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabSpec GetFabSpec() {
			var fs = new FabSpec();
			fs.DtoList = vDtoList;
			fs.Services = vServiceList;
			return fs;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string FormatResourceString(string pName, string pText) {
			return (pText == null ? "MISSING:"+pName : FormatMarkup(pText));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetServiceText(string pName) {
			string s = ServiceText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetDtoText(string pName) {
			string s = DtoText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetDtoPropText(string pName) {
			string s = DtoPropText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetDtoLinkText(string pName) {
			string s = DtoLinkText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetFuncText(string pName) {
			string s = FuncText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetFuncParamText(string pName) {
			string s = FuncParamText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabSpecService GetSpecService(FabService pService) {
			var ss = new FabSpecService();
			ss.Name = pService.Name;
			ss.Uri = pService.Uri;
			ss.ResponseWrapper = (ss.Uri == FabHome.OauthUri ? null : typeof(FabResponse).Name);
			ss.Abstract = GetServiceText(pService.Name+"Abstract");
			ss.Description = GetServiceText(pService.Name+"Desc");

			////

			string dtoNamespace;

			switch ( ss.Name ) {
				case "Traversal": dtoNamespace = TravDtoNamespace; break;
				case "Modify": dtoNamespace = ModDtoNamespace; break;
				case "Oauth": dtoNamespace = OauthDtoNamespace; break;
				case "Spec": dtoNamespace = SpecDtoNamespace; break;
				default: throw new FabPreventedFault("Unknown service name: '"+ss.Name+"'.");
			}

			foreach ( FabServiceOperation svcOp in pService.Operations ) {
				var sso = new FabSpecServiceOperation();
				sso.Name = svcOp.Name;
				sso.Uri = svcOp.Uri;
				sso.Method = svcOp.Method;
				sso.Description = "MISSING";
				ss.Operations.Add(sso);
			}

			////

			var dtoAssembly = Assembly.GetAssembly(typeof(FabDto));

			foreach ( Type dtoType in dtoAssembly.GetTypes() ) {
				if ( dtoType.IsInterface || dtoType.IsAbstract ) { continue; }
				if ( !typeof(IFabDto).IsAssignableFrom(dtoType) ) { continue; }
				if ( dtoType.Namespace != dtoNamespace ) { continue; }
				ss.Objects.Add(GetSpecDto(dtoType));
			}

			////

			Assembly assembly = vAssemblyMap[ss.Name];

			foreach ( Type t in assembly.GetTypes() ) {
				if ( t.GetCustomAttributes(typeof(FuncAttribute), false).Length == 0 ) {
					continue;
				}

				ss.Functions.Add(GetSpecFunc(t));
			}

			////

			ss.Objects.Sort((a, b) => string.Compare(a.Name, b.Name));
			ss.Functions.Sort((a, b) => string.Compare(a.Name, b.Name));
			ss.Operations.Sort((a, b) => string.Compare(a.Name, b.Name));
			return ss;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabSpecDto GetSpecDto(Type pType) {
			var sd = new FabSpecDto();
			sd.Name = pType.Name;
			sd.Description = GetDtoText(sd.Name.Substring(3));

			if ( pType != typeof(FabDto) ) {
				sd.Extends = typeof(FabDto).Name;
			}

			sd.Properties = ReflectProps(pType);
			return sd;
		}

		/*--------------------------------------------------------------------------------------------*/
		private List<FabSpecDtoProp> ReflectProps(Type pType) {
			PropertyInfo[] props = pType.GetProperties(
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
				specProp.Description = GetDtoPropText(pType.Name.Substring(3)+"_"+pi.Name);
				results.Add(pi.Name, specProp);
			}

			List<FabSpecDtoProp> list = results.Values.ToList();
			list.Sort((a, b) => string.Compare(a.Name, b.Name));
			return list;
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
			func.Parameters = new List<FabSpecFuncParam>();

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
				func.Parameters.Add(p);
			}

			func.Parameters.Sort((a, b) => (a.Index > b.Index ? 1 : (a.Index == b.Index ? 0 : -1)));
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