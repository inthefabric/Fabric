using System;
using System.Collections.Generic;
using System.Reflection;
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
			var e = new FabSpecEnum();
			e.Name = pType.Name;
			e.Description = "TODO";

			if ( pType == typeof(EnumObject) ) {
				return e;
			}

			e.Extends = pType.BaseType.Name;
			e.Items = new List<Dictionary<string, object>>();

			EnumObject obj = (EnumObject)Activator.CreateInstance(pType);
			IList<EnumItem> items = obj.ToList();

			foreach ( EnumItem item in items ) {
				e.Items.Add(BuildSpecEnumItem(item));
			}

			return e;
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