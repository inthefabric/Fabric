using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Pipe;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public class TxBuilder { //TEST: TxBuilder

		public IWeaverTransaction Transaction { get; private set; }

		private readonly HashSet<IWeaverVarAlias> vVarHash;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder() {
			Transaction = new WeaverTransaction();
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
		public void GetNode<T>(T pNodeWithId, out IWeaverVarAlias<T> pNodeVar)
																		where T : class, INode, new() {
			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(
				pNodeWithId.GetTypeIdProp<T>(), pNodeWithId.GetTypeId()).Next().ToQuery();
			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void GetNodeByNodeId<T>(T pNodeWithNodeId, out IWeaverVarAlias<T> pNodeVar)
																		where T : class, INode, new() {
			IWeaverQuery q = Weave.Inst.Graph.V.Id<T>(pNodeWithNodeId.Id).ToQuery();
			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T>(T pNode, out IWeaverVarAlias<T> pNewNodeVar) where T : class, INode {
			IWeaverQuery q = Weave.Inst.Graph.AddVertex(pNode);
			q = WeaverQuery.StoreResultAsVar(GetNextVarName(), q, out pNewNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel<TRel>(IWeaverVarAlias pFromVar, IWeaverVarAlias pToVar)
																	where TRel : IWeaverEdge, new() {
			VerifyVar(pFromVar);
			VerifyVar(pToVar);

			Transaction.AddQuery(
				Weave.Inst.Graph.AddEdge(pFromVar, new TRel(), pToVar)
			);
		}

	}

}