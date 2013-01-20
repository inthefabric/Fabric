﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

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
			Transaction.FinishWithoutStartStop();
			return Transaction;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void VerifyVar(IWeaverVarAlias pVar) {
			if ( pVar == null || !vVarHash.Contains(pVar) ) {
				throw new Exception("No matching IWeaverVarAlias found.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void GetRoot(out IWeaverVarAlias<Root> pRootVar) {
			pRootVar = new WeaverVarAlias<Root>(Transaction);

			IWeaverQuery q = WeaverTasks.BeginPath<Root>(x => x.RootId, 0)
				.BaseNode.ToNodeVar(pRootVar).End();
			Transaction.AddQuery(q);
			vVarHash.Add(pRootVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void GetNode<T>(T pNodeWithId, out IWeaverVarAlias<T> pNodeVar)
																		where T : class, INode, new() {
			pNodeVar = new WeaverVarAlias<T>(Transaction);

			IWeaverQuery q = WeaverTasks.BeginPath(pNodeWithId.GetTypeIdProp<T>(),
				pNodeWithId.GetTypeId()).BaseNode.ToNodeVar(pNodeVar).End();
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T, TRootRel>(T pNode, IWeaverVarAlias<Root> pRootVar, 
				out IWeaverVarAlias<T> pNewNodeVar) where T : INode where TRootRel : IWeaverRel, new() {
			VerifyVar(pRootVar);

			IWeaverQuery q = WeaverTasks.AddNode(pNode);
			q = WeaverTasks.StoreQueryResultAsVar<T>(Transaction, q, out pNewNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNewNodeVar);

			////
			
			/*Transaction.AddQuery(
				WeaverTasks.AddNodeToIndex(typeof(T).Name, pNewNodeVar, pNode.GetTypeIdProp<T>())
			);*/

			AddRel<TRootRel>(pRootVar, pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T, TRootRel>(T pNode, out IWeaverVarAlias<Root> pRootVar,
				out IWeaverVarAlias<T> pNewNodeVar) where T : INode where TRootRel : IWeaverRel, new() {
			GetRoot(out pRootVar);
			AddNode<T, TRootRel>(pNode, pRootVar, out pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel<TRel>(IWeaverVarAlias pFromVar, IWeaverVarAlias pToVar)
																		where TRel : IWeaverRel, new() {
			VerifyVar(pFromVar);
			VerifyVar(pToVar);
			
			Transaction.AddQuery(
				WeaverTasks.AddRel(pFromVar, new TRel(), pToVar)
			);
		}
		
	}

}