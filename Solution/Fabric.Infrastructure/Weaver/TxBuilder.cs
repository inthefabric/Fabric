using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class TxBuilder { //TEST: TxBuilder

		public IWeaverTransaction Transaction { get; private set; }

		private readonly HashSet<ITxBuilderVar> vVarHash;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder() {
			Transaction = new WeaverTransaction();
			vVarHash = new HashSet<ITxBuilderVar>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction Finish() {
			Transaction.Finish(WeaverTransaction.ConclusionType.Success, null);
			return Transaction;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void VerifyVar(ITxBuilderVar pVar) {
			if ( !vVarHash.Contains(pVar) ) {
				throw new Exception("No matching ITxBuilderVar found.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void GetRoot(out ITxBuilderVar<Root> pRootVar) {
			IWeaverVarAlias root;

			IWeaverQuery q = WeaverTasks.BeginPath(new Root()).BaseNode.End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out root);
			Transaction.AddQuery(q);

			pRootVar = new TxBuilderVar<Root>(root);
			vVarHash.Add(pRootVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void GetNode<T>(T pNodeWithId, out ITxBuilderVar<T> pNodeVar)
																		where T : class, INode, new() {
			IWeaverVarAlias node;

			IWeaverQuery q = WeaverTasks.BeginPath(typeof(T).Name, pNodeWithId.GetTypeIdProp<T>(),
				pNodeWithId.GetTypeId()).BaseNode.End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out node);
			Transaction.AddQuery(q);

			pNodeVar = new TxBuilderVar<T>(node);
			vVarHash.Add(pNodeVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T, TRootRel>(T pNode, ITxBuilderVar<Root> pRootVar, 
				out ITxBuilderVar<T> pNewNodeVar) where T : INode where TRootRel : IWeaverRel, new() {
			VerifyVar(pRootVar);

			IWeaverVarAlias newNode;

			IWeaverQuery q = WeaverTasks.AddNode(pNode);
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out newNode);
			Transaction.AddQuery(q);

			pNewNodeVar = new TxBuilderVar<T>(newNode);
			vVarHash.Add(pNewNodeVar);

			////
			
			Transaction.AddQuery(
				WeaverTasks.AddNodeToIndex(typeof(T).Name, newNode, pNode.GetTypeIdProp<T>())
			);

			AddRel<TRootRel>(pRootVar, pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T, TRootRel>(T pNode, out ITxBuilderVar<Root> pRootVar,
				out ITxBuilderVar<T> pNewNodeVar) where T : INode where TRootRel : IWeaverRel, new() {
			GetRoot(out pRootVar);
			AddNode<T, TRootRel>(pNode, pRootVar, out pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel<TRel>(ITxBuilderVar pFromVar, ITxBuilderVar pToVar)
																		where TRel : IWeaverRel, new() {
			var rel = new TRel();

			VerifyVar(pFromVar);
			VerifyVar(pToVar);

			if ( rel.FromNodeType != pFromVar.VarType ) {
				throw new Exception("Invalid From VarType: '"+pFromVar.VarType.Name+"', expected "+
					"'"+rel.FromNodeType.Name+"'.");
			}

			if ( rel.ToNodeType != pToVar.VarType ) {
				throw new Exception("Invalid To VarType: '"+pToVar.VarType.Name+"', expected "+
					"'"+rel.ToNodeType.Name+"'.");
			}

			Transaction.AddQuery(
				WeaverTasks.AddRel(pFromVar.Alias, rel, pToVar.Alias)
			);
		}
		
	}

}