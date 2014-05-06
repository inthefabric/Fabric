using Fabric.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Query {

	/*================================================================================================*/
	public interface ITxBuilder {

		IWeaverTransaction Transaction { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IWeaverTransaction Finish();

		/*--------------------------------------------------------------------------------------------*/
		IWeaverTransaction Finish(IWeaverVarAlias pFinalOutput);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void RegisterVarWithTxBuilder(IWeaverVarAlias pVar);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void GetVertex<T>(long pVertexId, out IWeaverVarAlias<T> pVertexVar) where T : Vertex, new();
		
		/*--------------------------------------------------------------------------------------------*/
		void GetVertex<T>(T pVertex, out IWeaverVarAlias<T> pVertexVar) where T : Vertex, new();

		/*--------------------------------------------------------------------------------------------*/
		void GetVertexByDatabaseId<T>(T pVertex, out IWeaverVarAlias<T> pVertexVar,
														string pVarName=null) where T : IVertex, new();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddVertex<T>(T pVertex, out IWeaverVarAlias<T> pNewVertexVar) where T : IVertex;

		/*--------------------------------------------------------------------------------------------*/
		void AddEdge<TEdge>(IWeaverVarAlias pFromVar, TEdge pEdge, IWeaverVarAlias pToVar)
																	where TEdge : IWeaverEdge, new();

	}

}