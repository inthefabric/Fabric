﻿using System;
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
using Fabric.Infrastructure.Api;
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

		private static List<string> ObjectNames;
		private static List<FabSpecDto> Objects;
		private static List<FabSpecService> Services;
		private static Dictionary<string, Assembly> AssemblyMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDoc() {
			ObjectNames = new List<string>();
			var objectAssembly = Assembly.GetAssembly(typeof(FabDto));

			foreach ( Type t in objectAssembly.GetTypes() ) {
				if ( t.FullName == null ) { continue; }
				if ( t.Name.Substring(0, 3) != "Fab" ) { continue; }

				string name = t.FullName.Replace("Fabric.Api.Dto.", "");

				if ( name.IndexOf('.') == -1 && t != typeof(FabResponse) ) {
					name = "Traversal."+name;
				}

				ObjectNames.Add(name);
			}

			////

			var resp = new FabSpecDto();
			resp.Name = typeof(FabResponse).Name;
			resp.Description = GetDtoText(resp.Name.Substring(3));
			resp.Properties = ReflectProps(typeof(FabResponse));

			Objects = new List<FabSpecDto>();
			Objects.Add(resp);

			foreach ( Type t in objectAssembly.GetTypes() ) {
				if ( t.IsInterface || t.IsAbstract ) { continue; }
				if ( !typeof(IFabDto).IsAssignableFrom(t) ) { continue; }

				FabSpecDto sd = GetSpecDto(t);
				Objects.Add(sd);

				if ( t.Namespace == SpecDtoNamespace ) {
					sd.Description = null;

					foreach ( FabSpecDtoProp p in sd.Properties ) {
						p.Description = null;
					}
				}
			}

			Objects.Sort((a, b) => string.Compare(a.Name, b.Name));

			////

			AssemblyMap = new Dictionary<string, Assembly>();
			AssemblyMap.Add("Oauth", Assembly.GetAssembly(typeof(OauthAccessBase)));
			AssemblyMap.Add("Modify", Assembly.GetAssembly(typeof(CreateApp)));
			AssemblyMap.Add("Traversal", Assembly.GetAssembly(typeof(PathSegment)));
			AssemblyMap.Add("Spec", Assembly.GetAssembly(typeof(SpecDoc)));

			////

			Services = new List<FabSpecService>();
			var home = new FabHome(true);

			foreach ( FabService svc in home.Services ) {
				Services.Add(GetSpecService(svc));
			}

			//TODO: load links and availablefunctions for Traversal
			//TODO: load ServiceOpParams
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabSpec GetFabSpec() {
			var fs = new FabSpec();
			fs.Objects = Objects;
			fs.Services = Services;
			return fs;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string FormatResourceString(string pName, string pText) {
			return (pText == null ? "MISSING:"+pName : FormatMarkup(pText));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static string GetServiceText(string pName) {
			string s = ServiceText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoText(string pName) {
			string s = DtoText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoPropText(string pName) {
			string s = DtoPropText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoLinkText(string pName) {
			string s = DtoLinkText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static string GetFuncText(string pName) {
			string s = FuncText.ResourceManager.GetString(pName);
			return FormatResourceString(pName, s);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetFuncParamText(string pName) {
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

			foreach ( FabServiceOperation svcOp in pService.Operations ) {
				ss.Operations.Add(GetSpecServiceOperation(ss, svcOp));
			}

			Assembly assembly = AssemblyMap[ss.Name];

			foreach ( Type t in assembly.GetTypes() ) {
				if ( t.GetCustomAttributes(typeof(FuncAttribute), false).Length == 0 ) {
					continue;
				}

				ss.Functions.Add(GetSpecFunc(t));
			}

			ss.Functions.Sort((a, b) => string.Compare(a.Name, b.Name));
			ss.Operations.Sort((a, b) => string.Compare(a.Name, b.Name));
			return ss;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabSpecServiceOperation GetSpecServiceOperation(
											FabSpecService pService, FabServiceOperation pServiceOp) {
			var sso = new FabSpecServiceOperation();
			sso.Name = pServiceOp.Name;
			sso.Uri = pServiceOp.Uri;
			sso.Method = pServiceOp.Method;
			sso.ReturnType = pServiceOp.ReturnType;
			sso.Description = "MISSING";

			Assembly assembly = AssemblyMap[pService.Name];

			foreach ( Type t in assembly.GetTypes() ) {
				object[] ops = t.GetCustomAttributes(typeof(ServiceOpAttribute), false);

				if ( ops.Length == 0 ) {
					continue;
				}

				ServiceOpAttribute att = (ServiceOpAttribute)ops[0];
				string attKey = att.Method+" "+att.ServiceUri+att.ServiceOperationUri;
				string ssoKey = sso.Method+" "+pService.Uri+sso.Uri;
				//Log.Debug("ATT: "+attKey+" [vs] "+ssoKey);

				if ( attKey != ssoKey ) {
					continue;
				}

				if ( att.ReturnType.Name != sso.ReturnType ) {
					throw new FabPreventedFault("ServiceOperation ReturnType mismatch: "+
						att.ReturnType.Name+" vs. "+sso.ReturnType);
				}

				sso.Parameters = GetSpecServiceOperationParams(sso, t);
			}

			return sso;
		}

		/*--------------------------------------------------------------------------------------------*/
		private List<FabSpecServiceOperationParam> GetSpecServiceOperationParams(
												FabSpecServiceOperation pServiceOp, Type pSvcOpClass) {
			FieldInfo[] fields = pSvcOpClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			var list = new List<FabSpecServiceOperationParam>();

			foreach ( FieldInfo field in fields ) {
				object[] opParams = field.GetCustomAttributes(typeof(ServiceOpParamAttribute), false);

				if ( opParams.Length == 0 ) {
					continue;
				}

				ServiceOpParamAttribute att = (ServiceOpParamAttribute)opParams[0];

				var p = new FabSpecServiceOperationParam();
				SpecBuilder.FillSpecValue(att.DomainClass.Name, att.DomainPropertyName, p);
				p.Name = att.Name;
				p.ParamType = att.ParamType+"";
				p.Type = SchemaHelperProp.GetTypeName(field.FieldType);
				p.IsRequired = att.IsRequired;
				p.Description = "MISSING:"+pServiceOp.Name+"_"+p.Name;
				list.Add(p);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabSpecDto GetSpecDto(Type pType) {

			var sd = new FabSpecDto();
			sd.Name = pType.Name;

			string n = sd.Name.Substring(3);
			sd.Description = GetDtoText(n);

			if ( pType != typeof(FabDto) ) {
				sd.Extends = typeof(FabDto).Name;
			}

			sd.Properties = ReflectProps(pType);
			SpecBuilder.FillSpecDtoFuncs(n, sd);
			SpecBuilder.FillSpecDtoLinks(n, sd);
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

				string n = pType.Name.Substring(3);

				var specProp = new FabSpecDtoProp();
				specProp.Name = (dpa == null ? pi.Name : dpa.DisplayName);
				specProp.Type = SchemaHelperProp.GetTypeName(pi.PropertyType);
				specProp.Description = GetDtoPropText(n+"_"+pi.Name);
				SpecBuilder.FillSpecDtoProp(n, pi.Name, specProp); //overwrites in most cases
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
				p.Name = fpa.DisplayName;
				p.Description = GetFuncParamText((fpa.FuncResxKey ?? resxKey)+"_"+pi.Name);
				p.Index = fpa.ParamIndex;
				p.Type = SchemaHelperProp.GetTypeName(pi.PropertyType);
				p.Min = fpa.Min;
				p.Max = fpa.Max;
				p.IsRequired = fpa.IsRequired;
				p.UsesQueryString = fpa.UsesQueryString;
				func.Parameters.Add(p);
			}

			func.Parameters.Sort((a, b) => (a.Index > b.Index ? 1 : (a.Index == b.Index ? 0 : -1)));
			return func;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string FormatMarkup(string pText) {
			pText = pText+"";

			for ( int i = 0 ; i < ObjectNames.Count ; ++i ) {
				string dto = ObjectNames[i];
				pText = FindSmartLinks(pText, dto, true);
				pText = FindSmartLinks(pText, dto, false);
			}

			return pText;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string FindSmartLinks(string pText, string pDtoNameAndPath, bool pFabMode) {
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
				string link = "[["+m.Captures[0]+"|Object|"+dtoName+"]]";
				pos = m.Index+(link.Length-m.Length);
				pText = pText.Remove(m.Index, m.Length);
				pText = pText.Insert(m.Index, link);
			}

			return pText;
		}

	}

}