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
		public IList<VertexConnectionRel> OutRels { get; private set; }
		public IList<VertexConnectionRel> InRels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexConnections(IVertexWithId pVertex, IApiDataAccess pData) {
			Vertex = pVertex;
			DataAccess = pData;

			TargetVertices = new List<IDbDto>();
			OutRels = new List<VertexConnectionRel>();
			InRels = new List<VertexConnectionRel>();

			if ( DataAccess.ResultDtoList == null ) {
				return;
			}

			foreach ( IDbDto dbDto in DataAccess.ResultDtoList ) {
				if ( dbDto.Item == DbDto.ItemType.Vertex ) {
					TargetVertices.Add(dbDto);
				}
			}

			foreach ( IDbDto dbDto in DataAccess.ResultDtoList ) {
				if ( dbDto.Item == DbDto.ItemType.Rel ) {
					AddRel(dbDto);
				}
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AssertRelCount(int pIncoming, int pOutgoing) {
			string end = " count for "+Vertex.GetType().Name+".";
			Assert.AreEqual(pIncoming, InRels.Count, "Incorrect InRels"+end);
			Assert.AreEqual(pOutgoing, OutRels.Count, "Incorrect OutRels"+end);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertRelCount<TRel>(bool pIsOutgoing, int pCount) where TRel : IWeaverEdge {
			IList<VertexConnectionRel> rels = (pIsOutgoing ? OutRels : InRels);
			int count = 0;

			foreach ( VertexConnectionRel rel in rels ) {
				if ( rel.Rel.Class != RelDbName.TypeMap[typeof(TRel)] ) {
					continue;
				}

				count++;
			}

			Assert.AreEqual(pCount, count, "Incorrect "+(pIsOutgoing ? "Out" : "In")+"Rel ["+
				typeof(TRel).Name+"] count for "+Vertex.GetType().Name+".");

		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertRel<TRel, TVertex>(bool pIsOutgoing, long pTargetId, string pIdProperty=null)
													where TRel : IWeaverEdge where TVertex : IVertexWithId {
			IList<VertexConnectionRel> rels = (pIsOutgoing ? OutRels : InRels);

			foreach ( VertexConnectionRel rel in rels ) {
				if ( rel.Rel.Class != RelDbName.TypeMap[typeof(TRel)] ) {
					continue;
				}

				if ( pIdProperty == null && rel.TargetVertex.Class != typeof(TVertex).Name ) {
					continue;
				}

				string prop = (pIdProperty ?? PropDbName.StrTypeIdMap[rel.TargetVertex.Class]);
				string targId = rel.TargetVertex.Data[prop];

				if ( long.Parse(targId) != pTargetId ) {
					continue;
				}

				return;
			}

			Assert.Fail((pIsOutgoing ? "Out" : "In")+"Rel ["+typeof(TRel).Name+"+"+typeof(TVertex).Name+
				"] was not found for "+Vertex.GetType().Name+".");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddRel(IDbDto pDbDto) {
			if ( pDbDto.OutVertexId == Vertex.Id ) {
				var rel = new VertexConnectionRel(pDbDto, true, GetTargetVertex(pDbDto.InVertexId));
				OutRels.Add(rel);
			}
			else {
				var rel = new VertexConnectionRel(pDbDto, false, GetTargetVertex(pDbDto.OutVertexId));
				InRels.Add(rel);
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

			foreach ( VertexConnectionRel rel in OutRels ) {
				s += "\n\t* "+rel;
			}

			foreach ( VertexConnectionRel rel in InRels ) {
				s += "\n\t* "+rel;
			}

			return s;
		}

	}

}