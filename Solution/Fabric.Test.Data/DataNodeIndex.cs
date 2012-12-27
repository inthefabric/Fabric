using System;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataNodeIndex {

		string IndexName { get; }
		bool IsForTesting { get; }
		IWeaverQuery AddToIndexQuery { get; }

	}

	/*================================================================================================*/
	public class DataNodeIndex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataNodeIndex<T> Create<T>(DataNode<T> pNode,
									Expression<Func<T, object>> pIndexValueFunc) where T : INode {
			return new DataNodeIndex<T>(pNode, pIndexValueFunc);
		}

	}

	/*================================================================================================*/
	public class DataNodeIndex<T> : IDataNodeIndex where T : INode {

		public string IndexName { get; private set; }
		public Expression<Func<T, object>> IndexValueFunc { get; private set; }
		public bool IsForTesting { get; private set; }

		private readonly DataNode<T> vDataNode;
		private IWeaverQuery vAddToIndexQuery;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataNodeIndex(DataNode<T> pNode, Expression<Func<T, object>> pIndexValueFunc) {
			IndexName = typeof(T).Name;
			IndexValueFunc = pIndexValueFunc;
			IsForTesting = pNode.IsForTesting;

			vDataNode = pNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery AddToIndexQuery {
			get {
				if ( vAddToIndexQuery == null ) {
					vAddToIndexQuery = WeaverTasks.AddNodeToIndex(
						IndexName, vDataNode.NodeT, IndexValueFunc);
				}

				return vAddToIndexQuery;
			}
		}

	}

}