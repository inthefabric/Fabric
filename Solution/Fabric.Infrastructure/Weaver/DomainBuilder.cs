using System;
using Fabric.Domain;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class DomainBuilder<T> where T : class, IVertex, new() { //TEST: DomainBuilder

		public TxBuilder TxBuild { get; private set; }
		public T Vertex { get; private set; }

		public IWeaverVarAlias<T> VertexVar { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(TxBuilder pTx, T pVertex) {
			TxBuild = pTx;
			Vertex = pVertex;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(TxBuilder pTx) : this(pTx, new T()) {}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddVertex() {
			IWeaverVarAlias<T> vertexVar;
			TxBuild.AddVertex(Vertex, out vertexVar);
			VertexVar = vertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetVertexVar(IWeaverVarAlias<T> pVertexVar) {
			if ( VertexVar != null ) {
				throw new Exception("VertexVar is already set.");
			}

			VertexVar = pVertexVar;
			TxBuild.RegisterVarWithTxBuilder(VertexVar);
		}
		
	}

}