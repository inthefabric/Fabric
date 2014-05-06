using System;
using System.Collections.Generic;
using System.Resources;
using Fabric.Api.Lang;
using Fabric.Api.Objects;

namespace Fabric.Api {

	/*================================================================================================*/
	public static class ApiLang {

		private readonly static IDictionary<Type, ResourceManager> ResourceMap = BuildResourceMap();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, ResourceManager> BuildResourceMap() {
			var map = new Dictionary<Type, ResourceManager>();
			map.Add(typeof(DtoText), DtoText.ResourceManager);
			map.Add(typeof(DtoPropText), DtoPropText.ResourceManager);
			map.Add(typeof(EnumText), EnumText.ResourceManager);
			map.Add(typeof(EnumPropText), EnumPropText.ResourceManager);
			map.Add(typeof(ServiceText), ServiceText.ResourceManager);
			map.Add(typeof(ServiceOpText), ServiceOpText.ResourceManager);
			map.Add(typeof(ServiceOpParamText), ServiceOpParamText.ResourceManager);
			map.Add(typeof(StepText), StepText.ResourceManager);
			map.Add(typeof(StepParamText), StepParamText.ResourceManager);
			return map;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string Text<T>(string pName) {
			string text = ResourceMap[typeof(T)].GetString(pName);
			text = (text == null ? "MISSING:"+pName : SmartLinks.Convert(text));
			return text.Replace("\r\n", "\n");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string TypeName(Type pType) {
			if ( pType.IsArray ) {
				return TypeName(pType.GetElementType())+"[]";
			}

			if ( pType.IsGenericType ) {
				Type gt = pType.GetGenericTypeDefinition();
				Type arg = pType.GetGenericArguments()[0];

				if ( gt == typeof(List<>) || gt == typeof(IList<>) ) {
					return TypeName(arg)+"[]";
				}

				if ( gt == typeof(Nullable<>) ) {
					return TypeName(arg)+"?";
				}

				if ( gt == typeof(Dictionary<,>) ) {
					return "object";
				}

				if ( gt == typeof(FabResponse<>) ) {
					return gt.Name.Split(new[] { '`' })[0]+"<"+TypeName(arg)+">";
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

	}

}