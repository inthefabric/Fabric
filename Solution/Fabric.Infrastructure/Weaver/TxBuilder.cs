using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class TxBuilder {

		private const string VarPrefix = "TxB_";

		public IWeaverTransaction Transaction { get; private set; }

		private IDictionary<string, IWeaverVarAlias> vVarMap;


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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void GetRoot(string pVarKey) {
			IWeaverVarAlias rootNode;

			IWeaverQuery q = WeaverTasks.BeginPath(new Root()).BaseNode.End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out rootNode);
			vVarMap.Add(pVarKey, rootNode);
			Transaction.AddQuery(q);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T, TRootRel>(T pNode, string pVarKey, Expression<Func<T,object>> pTypeId)
												where T : INode where TRootRel : IWeaverRel, new() {
			IWeaverVarAlias newNode;

			IWeaverQuery q = WeaverTasks.AddNode(pNode);
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out newNode);
			vVarMap.Add(pVarKey, newNode);
			Transaction.AddQuery(q);

			WeaverTasks.AddNodeToIndex(typeof(T).Name, newNode, pTypeId);
			Transaction.AddQuery(q);

			// Root relationship

			const string rootVarKey = VarPrefix+"root";
			GetRoot(rootVarKey);
			AddRel(rootVarKey, new TRootRel(), pVarKey);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel(string pFromVarKey, IWeaverRel pRel, string pToVarKey) {
			Transaction.AddQuery(
				WeaverTasks.AddRel(GetVarAlias(pFromVarKey), pRel, GetVarAlias(pToVarKey))
			);
		}
		
	}

}