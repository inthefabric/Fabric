using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.New.Domain;
using Weaver.Core;
using Weaver.Core.Graph;
using Weaver.Titan.Elements;

namespace Fabric.New.Infrastructure.Query {

	/*================================================================================================*/
	public static class Weave {

		public static readonly WeaverInstance Inst = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static WeaverInstance Init() {
			Type[] types = Assembly.GetAssembly(typeof(App)).GetTypes();
			var vertTypes = new List<Type>();
			var edgeTypes = new List<Type>();

			foreach ( Type t in types ) {
				object[] atts = t.GetCustomAttributes(typeof(WeaverTitanVertexAttribute), false);

				if ( atts.Length > 0 ) {
					vertTypes.Add(t);
				}

				atts = t.GetCustomAttributes(typeof(WeaverTitanEdgeAttribute), false);

				if ( atts.Length > 0 ) {
					edgeTypes.Add(t);
				}
			}

			return new WeaverInstance(vertTypes, edgeTypes);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T ExactIndex<T>(this IWeaverAllVertices pAllVert, T pVertex) 
																			where T : Vertex, new() {
			return pAllVert.ExactIndex<T>((x => x.VertexId), pVertex.VertexId);
		}

	}

}