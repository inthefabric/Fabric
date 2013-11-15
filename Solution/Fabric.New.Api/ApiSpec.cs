using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.New.Api.Lang;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public static class ApiSpec {

		public readonly static FabSpec Spec = BuildSpec();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabSpec BuildSpec() {
			var s = new FabSpec();
			s.Enums = BuildSpecEnums();
			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecEnum> BuildSpecEnums() {
			var enums = new List<FabSpecEnum>();
			var types = typeof(VertexType).Assembly.GetTypes();

			foreach ( Type t in types ) {
				if ( typeof(EnumObject).IsAssignableFrom(t) ) {
					enums.Add(BuildSpecEnum(t));
				}
			}

			return enums;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecEnum BuildSpecEnum(Type pType) {
			EnumObject obj = (EnumObject)Activator.CreateInstance(pType);
			IList<EnumItem> items = (obj.ToList() ?? new List<EnumItem>());

			var e = new FabSpecEnum();
			e.Name = pType.Name;
			e.Description = ApiLang.Text<EnumText>(e.Name);
			e.Properties = BuildSpecEnumProps(e, items.FirstOrDefault());

			if ( pType != typeof(EnumObject) ) {
				e.Extends = pType.BaseType.Name;
				e.Items = new List<Dictionary<string, object>>();

				foreach ( EnumItem item in items ) {
					e.Items.Add(BuildSpecEnumItem(item));
				}
			}

			return e;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObjectProp> BuildSpecEnumProps(FabSpecEnum pEnum, EnumItem pItem) {
			var enumProps = new List<FabSpecObjectProp>();

			if ( pItem == null ) {
				pItem = new EnumItem();
			}

			PropertyInfo[] props = pItem.GetType().GetProperties(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

			foreach ( PropertyInfo pi in props ) {
				var p = new FabSpecObjectProp();
				p.Name = pi.Name;
				p.Description = ApiLang.Text<EnumPropText>(pEnum.Name+"_"+p.Name);
				p.Type = ApiLang.TypeName(pi.PropertyType);
				enumProps.Add(p);
			}

			return enumProps;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, object> BuildSpecEnumItem(EnumItem pItem) {
			PropertyInfo[] props = pItem.GetType().GetProperties();
			var map = new Dictionary<string, object>();

			foreach ( PropertyInfo pi in props ) {
				object val = pi.GetValue(pItem, null);

				if ( val == null || (val as string) == "" ) {
					continue;
				}

				map.Add(pi.Name, val);
			}

			return map;
		}

	}

}