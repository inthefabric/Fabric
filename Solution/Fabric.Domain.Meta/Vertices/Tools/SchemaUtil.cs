﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fabric.Domain.Meta.Vertices.Tools {
	
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
		public static IList<IVertexSchema> GetVertexSchemas(bool pSkipInternal=false) {
			return GetVertexTypes()
				.Select(GetVertex)
				.Where(x => (!pSkipInternal || !x.IsInternal))
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
		public static IList<ApiProperty> GetVertexApiProperties(
													IVertexSchema pVertex, bool pSkipSubObjects=false) {
			Type apt = typeof(ApiProperty);

			return pVertex
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(apt))
				.Select(x => (ApiProperty)x.GetValue(pVertex, null))
				.Where(x => (!pSkipSubObjects || x.SubObjectOf == null))
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

	}

}