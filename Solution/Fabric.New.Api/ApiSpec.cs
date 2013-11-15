using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Fabric.New.Api.Lang;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Spec;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public static class ApiSpec {

		public readonly static FabSpec Spec = BuildSpec();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabSpec BuildSpec() {
			FabMetaVersion v = BaseModule.Version;

			var s = new FabSpec();
			s.BuildVersion = v.Version;
			s.BuildYear = v.Year;
			s.BuildMonth = v.Month;
			s.BuildDay = v.Day;
			s.Objects = BuildObjects();
			s.Enums = BuildEnums();
			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObject> BuildObjects() {
			var objs = new List<FabSpecObject>();
			var types = typeof(FabObject).Assembly.GetTypes();

			foreach ( Type t in types ) {
				if ( !typeof(FabObject).IsAssignableFrom(t) ) {
					continue;
				}

				if ( HasAttribute<SpecInternalAttribute>(t) ) {
					continue;
				}

				objs.Add(BuildObject(t));
			}

			return objs;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecObject BuildObject(Type pType) {
			var o = new FabSpecObject();
			o.Name = pType.Name;
			o.Extends = pType.BaseType.Name;

			if ( o.Name.IndexOf("CreateFab") == 0 ) {
				o.Description = "Contains the data needed to create a new "+o.Name;
			}
			else if ( o.Name.IndexOf("FabSpec") == 0 ) {
				o.Description = null;
			}
			else {
				o.Description = ApiLang.Text<DtoText>(o.Name.Substring(3)); //remove "Fab"
			}

			o.Properties = BuildObjectProps(o.Name, pType, (o.Description == null));
			return o;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObjectProp> BuildObjectProps(
														string pObjName, Type pType, bool pSkipText) {
			var objProps = new List<FabSpecObjectProp>();

			PropertyInfo[] props = pType.GetProperties(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

			foreach ( PropertyInfo pi in props ) {
				if ( HasAttribute<SpecInternalAttribute>(pi) ) {
					continue;
				}

				objProps.Add(BuildObjectProp(pObjName, pi, pSkipText));
			}

			return objProps;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecObjectProp BuildObjectProp(
												string pObjName, PropertyInfo pProp, bool pSkipText) {
			DataMemberAttribute dataMem = GetAttribute<DataMemberAttribute>(pProp);
			
			var p = new FabSpecObjectProp();
			p.Name = (dataMem == null ? pProp.Name : dataMem.Name);
			p.Type = ApiLang.TypeName(pProp.PropertyType);

			if ( !pSkipText && pObjName.IndexOf("CreateFab") != 0 ) {
				p.Description = ApiLang.Text<DtoPropText>(pObjName.Substring(3)+"_"+pProp.Name);
			}

			////
			
			SpecLenAttribute specLen = GetAttribute<SpecLenAttribute>(pProp);
			SpecRegexAttribute specReg = GetAttribute<SpecRegexAttribute>(pProp);
			SpecUniqueAttribute specUni = GetAttribute<SpecUniqueAttribute>(pProp);
			SpecToLowerCaseAttribute specLow = GetAttribute<SpecToLowerCaseAttribute>(pProp);
			SpecFromEnumAttribute specEnum = GetAttribute<SpecFromEnumAttribute>(pProp);

			if ( HasAttribute<SpecOptionalAttribute>(pProp) ) {
				p.IsOptional = true;
			}

			if ( specLen != null ) {
				p.LenMin = specLen.Min;
				p.LenMax = specLen.Max;
			}

			if ( specReg != null ) {
				p.ValidRegex = specReg.Pattern;
			}

			if ( specUni != null ) {
				p.IsUnique = true;
			}

			if ( specLow != null ) {
				p.ToLowerCase = true;
			}

			if ( specEnum != null ) {
				p.Enum = specEnum.Name;
			}

			return p;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecEnum> BuildEnums() {
			var enums = new List<FabSpecEnum>();
			var types = typeof(VertexType).Assembly.GetTypes();

			foreach ( Type t in types ) {
				if ( typeof(EnumObject).IsAssignableFrom(t) ) {
					enums.Add(BuildEnum(t));
				}
			}

			return enums;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecEnum BuildEnum(Type pType) {
			EnumObject obj = (EnumObject)Activator.CreateInstance(pType);
			IList<EnumItem> items = (obj.ToList() ?? new List<EnumItem>());

			var e = new FabSpecEnum();
			e.Name = pType.Name;
			e.Description = ApiLang.Text<EnumText>(e.Name);
			e.Properties = BuildEnumProps(e.Name, items.FirstOrDefault());

			if ( pType != typeof(EnumObject) ) {
				e.Extends = pType.BaseType.Name;
				e.Items = new List<Dictionary<string, object>>();

				foreach ( EnumItem item in items ) {
					e.Items.Add(BuildEnumItem(item));
				}
			}

			return e;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObjectProp> BuildEnumProps(string pEnumName, EnumItem pItem) {
			var enumProps = new List<FabSpecObjectProp>();

			if ( pItem == null ) {
				pItem = new EnumItem();
			}

			PropertyInfo[] props = pItem.GetType().GetProperties(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

			foreach ( PropertyInfo pi in props ) {
				var p = new FabSpecObjectProp();
				p.Name = pi.Name;
				p.Description = ApiLang.Text<EnumPropText>(pEnumName+"_"+p.Name);
				p.Type = ApiLang.TypeName(pi.PropertyType);
				enumProps.Add(p);
			}

			return enumProps;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, object> BuildEnumItem(EnumItem pItem) {
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool HasAttribute<T>(MemberInfo pType) where T : Attribute {
			return (GetAttribute<T>(pType) != null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static T GetAttribute<T>(MemberInfo pType) where T : Attribute {
			object[] atts = pType.GetCustomAttributes(typeof(T), true);
			return (atts.Length == 0 ? default(T) : (T)atts[0]);
		}

	}

}