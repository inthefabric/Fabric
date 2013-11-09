using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.New.Domain.Schemas.Edges;
using Fabric.New.Domain.Schemas.Enums;
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
		public static T GetVertex<T>() where T : IVertexSchema {
			return (T)GetVertex(typeof(T));
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<Type> GetEdgeTypes() {
			Type et = typeof(EdgeSchema);

			return et.Assembly
				.GetTypes()
				.Where(x => x.IsSubclassOf(et) && x.Name.IndexOf(et.Name) != 0)
				.OrderBy(x => x.Name)
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<IEdgeSchema> GetEdgeSchemas() {
			return GetEdgeTypes()
				.Select(GetEdge)
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<IEdgeSchema> GetEdgeSchemasForVertex(
														IVertexSchema pVertex, bool pCreateMode=false) {
			Type vt = pVertex.GetType();

			return GetEdgeSchemas()
				.Where(x => x.FromVertexType == vt)
				.Where(x => (!pCreateMode || 
					(x.CreateToVertexId != Access.None && x.CreateFromOtherDirection == null)))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IEdgeSchema GetReverseEdgeSchema(IVertexSchema pVertex, IEdgeSchema pEdge) {
			Type vt = pVertex.GetType();
			Type et = pEdge.GetType();

			return GetEdgeSchemas()
				.Where(x => x.ToVertexType == vt)
				.Where(x => (x.CreateToVertexId != Access.None && x.CreateFromOtherDirection == et))
				.Take(1)
				.SingleOrDefault();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T GetEdge<T>() where T : IEdgeSchema {
			return (T)GetEdge(typeof(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IEdgeSchema GetEdge(Type pEdgeType) {
			return (IEdgeSchema)Activator.CreateInstance(pEdgeType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetEdgeTypeNames() {
			var edges = GetEdgeSchemas();
			var typeNames = new HashSet<string>();

			foreach ( IEdgeSchema es in edges ) {
				if ( !typeNames.Contains(es.NameDom) ) {
					typeNames.Add(es.NameDom);
				}
			}

			return typeNames.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<EdgeProperty> GetEdgeProperties(IEdgeSchema pEdge) {
			Type ept = typeof(EdgeProperty);

			return pEdge
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(ept))
				.Select(x => (EdgeProperty)x.GetValue(pEdge, null))
				.ToList();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<Type> GetEnumTypes() {
			Type et = typeof(EnumSchema);

			return et.Assembly
				.GetTypes()
				.Where(x => x.IsSubclassOf(et))
				.OrderBy(x => x.Name)
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<IEnumSchema> GetEnumSchemas() {
			return GetEnumTypes()
				.Select(GetEnum)
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T GetEnum<T>() where T : IEnumSchema {
			return (T)GetEnum(typeof(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IEnumSchema GetEnum(Type pEnumType) {
			return (IEnumSchema)Activator.CreateInstance(pEnumType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<PropertyInfo> GetEnumItemProperties(IEnumSchema pEdge) {
			return pEdge
				.Items[0]
				.GetType()
				.GetProperties()
				//.Where(x => x.DeclaringType != typeof(EnumItemSchema))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetEnumItemPropertyRef(PropertyInfo pProp) {
			object er = pProp
				.GetCustomAttributes(typeof(EnumRefAttribute), false)
				.FirstOrDefault();

			return (er == null ? null : ((EnumRefAttribute)er).EnumType);
		}

	}

}