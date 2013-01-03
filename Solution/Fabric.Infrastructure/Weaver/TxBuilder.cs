using System.Collections.Generic;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class TxBuilder { //TEST: TxBuilder

		public IWeaverTransaction Transaction { get; private set; }

		private readonly IDictionary<string, IWeaverVarAlias> vVarMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder() {
			Transaction = new WeaverTransaction();
			vVarMap = new Dictionary<string, IWeaverVarAlias>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverVarAlias GetVarAlias(string pVarKey) {
			return vVarMap[pVarKey];
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction Finish() {
			Transaction.Finish(WeaverTransaction.ConclusionType.Success, null);
			return Transaction;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void GetRoot(string pVarKey) {
			IWeaverVarAlias rootNode;

			IWeaverQuery q = WeaverTasks.BeginPath(new Root()).BaseNode.End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out rootNode);
			vVarMap.Add(pVarKey, rootNode);
			Transaction.AddQuery(q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void GetNode<T>(T pNodeWithId, string pVarKey) where T : class, INode, new() {
			IWeaverVarAlias node;

			IWeaverQuery q = WeaverTasks.BeginPath<T>(typeof(T).Name, pNodeWithId.GetTypeIdProp<T>(),
				pNodeWithId.GetTypeId()).BaseNode.End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out node);
			vVarMap.Add(pVarKey, node);
			Transaction.AddQuery(q);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T, TRootRel>(T pNode, string pNewNodeKey, string pRootKey)
													where T : INode where TRootRel : IWeaverRel, new() {
			IWeaverVarAlias newNode;

			IWeaverQuery q = WeaverTasks.AddNode(pNode);
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out newNode);
			vVarMap.Add(pNewNodeKey, newNode);
			Transaction.AddQuery(q);
			
			Transaction.AddQuery(
				WeaverTasks.AddNodeToIndex(typeof(T).Name, newNode, pNode.GetTypeIdProp<T>())
			);

			GetRoot(pRootKey);
			AddRel<TRootRel>(pRootKey, pNewNodeKey);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel<TRel>(string pFromVarKey, string pToVarKey) where TRel : IWeaverRel, new() {
			Transaction.AddQuery(
				WeaverTasks.AddRel(GetVarAlias(pFromVarKey), new TRel(), GetVarAlias(pToVarKey))
			);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddKnownToNodeRel<T, TRel>(T pNodeWithId, string pGetNodeKey, string pKnownNodeKey) 
										where T : class, INode, new() where TRel : IWeaverRel, new() {
			GetNodeAndAddRel<T,TRel>(pNodeWithId, pGetNodeKey, pKnownNodeKey, true);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AddNodeToKnownRel<T, TRel>(T pNodeWithId, string pGetNodeKey, string pKnownNodeKey) 
										where T : class, INode, new() where TRel : IWeaverRel, new() {
			GetNodeAndAddRel<T,TRel>(pNodeWithId, pGetNodeKey, pKnownNodeKey, false);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void GetNodeAndAddRel<T, TRel>(T pNodeWithId,
									string pGetNodeKey, string pKnownNodeKey, bool pFromKnown) 
									where T : class, INode, new() where TRel : IWeaverRel, new() {
			GetNode(pNodeWithId, pGetNodeKey);
			
			if ( pFromKnown ) {
				AddRel<TRel>(pKnownNodeKey, pGetNodeKey);
			}
			else {
				AddRel<TRel>(pGetNodeKey, pKnownNodeKey);
			}
		}
		
	}

}