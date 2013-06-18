using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver.Core.Elements;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class VertexConnections {

		public IVertexWithId Vertex { get; private set; }
		public IApiDataAccess DataAccess { get; private set; }

		public IList<IDbDto> TargetVertices { get; private set; }
		public IList<VertexConnectionEdge> OutEdges { get; private set; }
		public IList<VertexConnectionEdge> InEdges { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexConnections(IVertexWithId pVertex, IApiDataAccess pData) {
			Vertex = pVertex;
			DataAccess = pData;

			TargetVertices = new List<IDbDto>();
			OutEdges = new List<VertexConnectionEdge>();
			InEdges = new List<VertexConnectionEdge>();

			if ( DataAccess.ResultDtoList == null ) {
				return;
			}

			foreach ( IDbDto dbDto in DataAccess.ResultDtoList ) {
				if ( dbDto.Item == DbDto.ItemType.Vertex ) {
					TargetVertices.Add(dbDto);
				}
			}

			foreach ( IDbDto dbDto in DataAccess.ResultDtoList ) {
				if ( dbDto.Item == DbDto.ItemType.Edge ) {
					AddEdge(dbDto);
				}
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AssertEdgeCount(int pIncoming, int pOutgoing) {
			string end = " count for "+Vertex.GetType().Name+".";
			Assert.AreEqual(pIncoming, InEdges.Count, "Incorrect InEdges"+end);
			Assert.AreEqual(pOutgoing, OutEdges.Count, "Incorrect OutEdges"+end);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertEdgeCount<TEdge>(bool pIsOutgoing, int pCount) where TEdge : IWeaverEdge {
			IList<VertexConnectionEdge> edges = (pIsOutgoing ? OutEdges : InEdges);
			int count = 0;

			foreach ( VertexConnectionEdge edge in edges ) {
				if ( edge.Edge.Class != EdgeDbName.TypeMap[typeof(TEdge)] ) {
					continue;
				}

				count++;
			}

			Assert.AreEqual(pCount, count, "Incorrect "+(pIsOutgoing ? "Out" : "In")+"Edge ["+
				typeof(TEdge).Name+"] count for "+Vertex.GetType().Name+".");

		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertEdge<TEdge, TVertex>(bool pIsOutgoing, long pTargetId, string pIdProperty=null)
													where TEdge : IWeaverEdge where TVertex : IVertexWithId {
			IList<VertexConnectionEdge> edges = (pIsOutgoing ? OutEdges : InEdges);

			foreach ( VertexConnectionEdge edge in edges ) {
				if ( edge.Edge.Class != EdgeDbName.TypeMap[typeof(TEdge)] ) {
					continue;
				}

				if ( pIdProperty == null && edge.TargetVertex.Class != typeof(TVertex).Name ) {
					continue;
				}

				string prop = (pIdProperty ?? PropDbName.StrTypeIdMap[edge.TargetVertex.Class]);
				string targId = edge.TargetVertex.Data[prop];

				if ( long.Parse(targId) != pTargetId ) {
					continue;
				}

				return;
			}

			Assert.Fail((pIsOutgoing ? "Out" : "In")+"Edge ["+typeof(TEdge).Name+"+"+typeof(TVertex).Name+
				"] was not found for "+Vertex.GetType().Name+".");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddEdge(IDbDto pDbDto) {
			if ( pDbDto.OutVertexId == Vertex.Id ) {
				var edge = new VertexConnectionEdge(pDbDto, true, GetTargetVertex(pDbDto.InVertexId));
				OutEdges.Add(edge);
			}
			else {
				var edge = new VertexConnectionEdge(pDbDto, false, GetTargetVertex(pDbDto.OutVertexId));
				InEdges.Add(edge);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private IDbDto GetTargetVertex(string pVertexId) {
			if ( pVertexId == null ) {
				throw new Exception("VertexId cannot be null.");
			}

			foreach ( IDbDto n in TargetVertices ) {
				if ( n.Id == pVertexId ) {
					return n;
				}
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			string s = Vertex.GetType().Name+"["+Vertex.Id+", "+Vertex.GetTypeId()+"]";

			foreach ( VertexConnectionEdge edge in OutEdges ) {
				s += "\n\t* "+edge;
			}

			foreach ( VertexConnectionEdge edge in InEdges ) {
				s += "\n\t* "+edge;
			}

			return s;
		}

	}

}