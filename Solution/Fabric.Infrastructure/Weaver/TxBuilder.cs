using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Titan;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public class TxBuilder { //TEST: TxBuilder

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
		public void GetVertex<T>(T pVertexWithId, out IWeaverVarAlias<T> pVertexVar)
																		where T : class, IVertex, new() {
			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(
				pVertexWithId.GetTypeIdProp<T>(), pVertexWithId.GetTypeId()).Next().ToQuery();
			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pVertexVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
			vVarHash.Add(pVertexVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void GetVertexByVertexId<T>(T pVertexWithVertexId, out IWeaverVarAlias<T> pVertexVar,
												string pVarName=null) where T : class, IVertex, new() {
			IWeaverQuery q = Weave.Inst.Graph.V.Id<T>(pVertexWithVertexId.Id).ToQuery();
			string varName = (pVarName ?? GetNextVarName());
			q = WeaverQuery.StoreResultAsVar(varName, q, out pVertexVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
			vVarHash.Add(pVertexVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddVertex<T>(T pVertex, out IWeaverVarAlias<T> pNewVertexVar) where T : class, IVertex {
			IWeaverQuery q = Weave.Inst.Graph.AddVertex(pVertex);
			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pNewVertexVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
			vVarHash.Add(pNewVertexVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddEdge<TEdge>(IWeaverVarAlias pFromVar, IWeaverVarAlias pToVar)
																	where TEdge : IWeaverEdge, new() {
			VerifyVar(pFromVar);
			VerifyVar(pToVar);

			IWeaverQuery q = Weave.Inst.TitanGraph().AddEdgeVci(pFromVar, new TEdge(), pToVar);
			Transaction.AddQuery(q);
			Scripts.Add(q);
		}

	}

}