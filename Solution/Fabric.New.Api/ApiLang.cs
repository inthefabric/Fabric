using System;
using System.Collections.Generic;
using System.Resources;
using System.Text.RegularExpressions;
using Fabric.New.Api.Lang;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public static class ApiLang {

		private readonly static IDictionary<Type, ResourceManager> ResourceMap = BuildResourceMap();
		private readonly static IList<string> ObjectNames = new List<string>(); //TODO: set names


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, ResourceManager> BuildResourceMap() {
			var map = new Dictionary<Type, ResourceManager>();
			map.Add(typeof(ServiceText), ServiceText.ResourceManager);
			map.Add(typeof(DtoText), DtoText.ResourceManager);
			map.Add(typeof(DtoPropText), DtoPropText.ResourceManager);
			map.Add(typeof(DtoLinkText), DtoLinkText.ResourceManager);
			map.Add(typeof(FuncText), FuncText.ResourceManager);
			map.Add(typeof(FuncParamText), FuncParamText.ResourceManager);
			map.Add(typeof(ServiceOpText), ServiceOpText.ResourceManager);
			map.Add(typeof(ServiceOpParamText), ServiceOpParamText.ResourceManager);
			map.Add(typeof(EnumText), EnumText.ResourceManager);
			map.Add(typeof(EnumPropText), EnumPropText.ResourceManager);
			return map;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string Text<T>(string pName) {
			string text = ResourceMap[typeof(T)].GetString(pName);
			return (text == null ? "MISSING:"+pName : FormatMarkup(text));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string TypeName(Type pType) {
			if ( pType.IsArray ) {
				return TypeName(pType.GetElementType())+"[]";
			}

			if ( pType.IsGenericType ) {
				Type gt = pType.GetGenericTypeDefinition();

				if ( gt == typeof(List<>) || gt == typeof(IList<>) ) {
					return TypeName(pType.GetGenericArguments()[0])+"[]";
				}

				if ( gt == typeof(Nullable<>) ) {
					return TypeName(pType.GetGenericArguments()[0])+"?";
				}

				if ( gt == typeof(Dictionary<,>) ) {
					return "object";
				}
			}

			if ( pType == typeof(string) ) {
				return "string";
			}

			if ( pType == typeof(bool) ) {
				return "bool";
			}

			if ( pType == typeof(byte) ) {
				return "byte";
			}

			if ( pType == typeof(int) ) {
				return "int";
			}

			if ( pType == typeof(long) ) {
				return "long";
			}

			if ( pType == typeof(double) ) {
				return "double";
			}

			if ( pType == typeof(float) ) {
				return "float";
			}

			if ( pType.IsEnum ) {
				string full = (pType.FullName ?? "");
				int b = full.LastIndexOf('+');
				int a = full.LastIndexOf('.', b)+1;

				if ( a != -1 && b != -1 ) {
					return full.Substring(a, b-a);
				}
			}

			if ( pType.Name.IndexOf("Fab") == 0 || pType.Name.IndexOf("CreateFab") == 0 ) {
				return pType.Name;
			}

			return "MISSING:"+pType.FullName;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string FormatMarkup(string pText) {
			pText = pText+"";

			foreach ( string dto in ObjectNames ) {
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