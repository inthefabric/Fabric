using System;
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

		/*--------------------------------------------------------------------------------------------* /
		public static IList<IVertexSchema> GetApiVertices() {
			IList<Type> types = GetVertexTypes();
			var verts = new List<IVertexSchema>();
			var subMap = new HashSet<string>();

			foreach ( Type t in types ) {
				var vert = GetVertex(t);
				verts.Add(vert);

				IList<ApiProperty> props = GetVertexApiProperties(vert);

				foreach ( ApiProperty prop in props ) {
					if ( prop.SubObjectOf == null || subMap.Contains(prop.SubObjectOf) ) {
						continue;
					}

					subMap.Add(prop.SubObjectOf);
				}
			}

			return verts;
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
				.Select(pi => (DomainProperty)pi.GetValue(pVertex, null))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<ApiProperty> GetVertexApiProperties(IVertexSchema pVertex) {
			Type apt = typeof(ApiProperty);

			return pVertex
				.GetType()
				.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.PropertyType.IsSubclassOf(apt))
				.Select(pi => (ApiProperty)pi.GetValue(pVertex, null))
				.ToList();
		}

	}

	
	/*================================================================================================* /
	public static class SchemaUtilApiVertex<TDomType, TApiType> {

		public ApiProperty<TApiType> Vertex { get; internal set; }
		public IList<ApiProperty> Props { get; internal set; }
		public IList<PropertyMapping<TDomType, TApiType>> Maps { get; internal set; }

	}*/

}