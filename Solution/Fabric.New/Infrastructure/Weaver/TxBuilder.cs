using System;
using System.Collections.Generic;
using Fabric.New.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Titan;

namespace Fabric.New.Infrastructure.Weaver {

	/*================================================================================================*/
	public class TxBuilder {

		public IWeaverTransaction Transaction { get; private set; }
		public IList<IWeaverScript> Scripts { get; private set; }

		private readonly HashSet<IWeaverVarAlias> vVarHash;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder() {
			Transaction = new WeaverTransaction();
			Scripts = new List<IWeaverScript>();
			vVarHash = new HashSet<IWeaverVarAlias>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction Finish() {
			Transaction.Finish();
			return Transaction;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction Finish(IWeaverVarAlias pFinalOutput) {
			VerifyVar(pFinalOutput);
			Transaction.Finish(pFinalOutput);
			return Transaction;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void RegisterVarWithTxBuilder(IWeaverVarAlias pVar) {
			vVarHash.Add(pVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void VerifyVar(IWeaverVarAlias pVar) {
			if ( pVar == null || !vVarHash.Contains(pVar) ) {
				throw new Exception("No matching IWeaverVarAlias found with name '"+
					(pVar == null ? "<NULL>" : pVar.Name)+"'.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetNextVarName() {
			return "_V"+vVarHash.Count;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void GetVertex<T>(long pVertexId, out IWeaverVarAlias<T> pVertexVar) 
																			where T : IVertex, new() {
			IWeaverQuery q = Weave.Inst.Graph.V
				.ExactIndex<T>((x => x.VertexId), pVertexId).Next()
				.ToQuery();

			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pVertexVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
			vVarHash.Add(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void GetVertex<T>(T pVertex, out IWeaverVarAlias<T> pVertexVar) where T : IVertex, new(){
			GetVertex(pVertex.VertexId, out pVertexVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void GetVertexByDatabaseId<T>(T pVertex, out IWeaverVarAlias<T> pVertexVar,
														string pVarName=null) where T : IVertex, new() {
			IWeaverQuery q = Weave.Inst.Graph.V.Id<T>(pVertex.Id).ToQuery();
			string varName = (pVarName ?? GetNextVarName());
			q = WeaverQuery.StoreResultAsVar(varName, q, out pVertexVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
			vVarHash.Add(pVertexVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddVertex<T>(T pVertex, out IWeaverVarAlias<T> pNewVertexVar) where T : IVertex {
			IWeaverQuery q = Weave.Inst.Graph.AddVertex(pVertex);
			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pNewVertexVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
			vVarHash.Add(pNewVertexVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddEdge<TEdge>(IWeaverVarAlias pFromVar, TEdge pEdge, IWeaverVarAlias pToVar)
																	where TEdge : IWeaverEdge, new() {
			VerifyVar(pFromVar);
			VerifyVar(pToVar);

			IWeaverQuery q = Weave.Inst.Graph.AddEdge(pFromVar, pEdge, pToVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
		}

	}

}