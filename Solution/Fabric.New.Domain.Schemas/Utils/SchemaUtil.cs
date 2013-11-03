using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Utils {
	
	/*================================================================================================*/
	public static class SchemaUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<Type> GetVertexTypes() {
			Type vt = typeof(VertexSchema);

			return vt.Assembly
				.GetTypes()
				.Where(x => x.IsSubclassOf(vt) || x == vt)
				.OrderBy(x => x.Name)
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<IVertexSchema> GetVertexSchemas() {
			return GetVertexTypes()
				.Select(GetVertex)
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IVertexSchema GetVertexParent(IVertexSchema pVertex) {
			Type type = pVertex.GetType().BaseType;
			return (type == typeof(Object) ? null : GetVertex(type));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IVertexSchema GetVertex(Type pVertexType) {
			return (IVertexSchema)Activator.CreateInstance(pVertexType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<DomainProperty> GetVertexDomainProperties(IVertexSchema pVertex) {
			Type dpt = typeof(DomainProperty);

			return pVertex
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(dpt))
				.Select(x => (DomainProperty)x.GetValue(pVertex, null))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<ApiProperty> GetVertexApiProperties(IVertexSchema pVertex,
												bool pSkipSubObjects=false, bool pCreateMode=false) {
			Type apt = typeof(ApiProperty);

			return pVertex
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(apt))
				.Select(x => (ApiProperty)x.GetValue(pVertex, null))
				.Where(x => (!pSkipSubObjects || x.SubObjectOf == null))
				.Where(x => (!pCreateMode || x.CreateAccess != Access.None))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IDictionary<string, IList<ApiProperty>> 
													GetVertexApiPropertySubMap(IVertexSchema pVertex) {
			IList<ApiProperty> props = GetVertexApiProperties(pVertex);
			var subMap = new Dictionary<string, IList<ApiProperty>>();

			foreach ( ApiProperty ap in props ) {
				if ( ap.SubObjectOf == null ) {
					continue;
				}

				if ( !subMap.ContainsKey(ap.SubObjectOf) ) {
					subMap.Add(ap.SubObjectOf, new List<ApiProperty>());
				}

				subMap[ap.SubObjectOf].Add(ap);
			}

			return subMap;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IDictionary<ApiProperty, PropertyMapping> 
													GetVertexApiPropertyMaps(IVertexSchema pVertex) {
			Type pmt = typeof(PropertyMapping);

			return pVertex
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(pmt))
				.Select(x => (PropertyMapping)x.GetValue(pVertex, null))
				.ToDictionary(x => x.Api, x => x);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IDictionary<DomainProperty, IList<PropertyMapping>>
								GetVertexDomainPropertyMaps(IVertexSchema pVertex, bool pCreateMode) {
			Type pmt = typeof(PropertyMapping);

			IEnumerable<PropertyMapping> propMaps = pVertex
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(pmt))
				.Select(x => (PropertyMapping)x.GetValue(pVertex, null))
				.Where(x => (!pCreateMode || x.Api.CreateAccess != Access.None));

			var map = new Dictionary<DomainProperty, IList<PropertyMapping>>();

			foreach ( PropertyMapping pm in propMaps ) {
				if ( !map.ContainsKey(pm.Domain) ) {
					map.Add(pm.Domain, new List<PropertyMapping>());
				}

				map[pm.Domain].Add(pm);
			}

			return map;
		}

	}

}