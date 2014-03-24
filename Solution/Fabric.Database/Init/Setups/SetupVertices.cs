using System;
using Fabric.New.Domain;

namespace Fabric.New.Database.Init.Setups {

	/*================================================================================================*/
	public class SetupVertices {

		protected DataSet Data { get; private set; }
		protected bool IsForTestingOnly { get; set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupVertices(DataSet pData) {
			Data = pData;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void AddVertex<T>(T pVertex, SetupVertexId pId) where T : Vertex {
			pVertex.VertexId = (long)pId;
			pVertex.Timestamp = Data.SetupTimestamp;
			
			Data.AddVertex(
				DataVertex.Create(pVertex, IsForTestingOnly)
			);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected void AddArtifact<T>(T pArtifact, SetupArtifactId pId,
													SetupMemberId? pCreatorId=null) where T : Artifact {
			AddVertex(pArtifact, (SetupVertexId)(long)pId);

			if ( pCreatorId == null ) {
				return;
			}

			AddArtifactCreator(pId, (SetupMemberId)pCreatorId);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected void AddArtifactCreator(SetupArtifactId pId, SetupMemberId pCreatorId) {
			Artifact a = Data.GetVertex<Artifact>((long)pId);
			Member m = Data.GetVertex<Member>((long)pCreatorId);

			var mca = new MemberCreatesArtifact();
			mca.Timestamp = a.Timestamp;
			mca.VertexType = a.VertexType;

			AddEdge(m, mca, a);
			AddEdge(a, new ArtifactCreatedByMember(), m);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddEdge<TFrom, TEdge, TTo>(TFrom pOutVertex, TEdge pEdge, TTo pInVertex)
										where TFrom : IVertex where TEdge : IEdge where TTo : IVertex {
			if ( pEdge.OutVertexType != typeof(TFrom) ) {
				throw new Exception("Incorrect TFrom.");
			}

			if ( pEdge.InVertexType != typeof(TTo) ) {
				throw new Exception("Incorrect TTo.");
			}

			Data.AddEdge(
				DataEdge.Create(pOutVertex,  pEdge, pInVertex, IsForTestingOnly)
			);
		}

	}

}