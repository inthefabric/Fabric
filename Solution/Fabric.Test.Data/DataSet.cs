using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public class DataSet {

		public IList<WeaverQuery> Indexes { get; private set; }
		public IList<IDataNode> Nodes { get; private set; }
		public IList<IDataNodeIndex> NodeToIndexes { get; private set; }
		public bool IsForTesting { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataSet(bool pIsForTesting) {
			Indexes = new List<WeaverQuery>();
			Nodes = new List<IDataNode>();
			NodeToIndexes = new List<IDataNodeIndex>();
			IsForTesting = pIsForTesting;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddIndex(WeaverQuery pQuery) {
			Indexes.Add(pQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool AddNodeAndIndex<T>(T pDomainNode, Expression<Func<T,object>> pIndexValueFunc,
															bool pIsForTesting) where T : IWeaverNode {
			if ( !IsForTesting && pIsForTesting ) { return false; }
			DataNode<T> n = DataNode.Create(pDomainNode, pIsForTesting);
			DataNodeIndex<T> ni = DataNodeIndex.Create(n, pIndexValueFunc);
			AddNode(n);
			AddNodeToIndex(ni);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataNode<T> AddNode<T>(DataNode<T> pNode) where T : IWeaverNode {
			if ( !IsForTesting && pNode.IsForTesting ) { return pNode; }
			Nodes.Add(pNode);
			return pNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataNodeIndex<T> AddNodeToIndex<T>(DataNodeIndex<T> pNodeToIndex) where T : IWeaverNode {
			if ( !IsForTesting && pNodeToIndex.IsForTesting ) { return pNodeToIndex; }
			NodeToIndexes.Add(pNodeToIndex);
			return pNodeToIndex;
		}

	}

}