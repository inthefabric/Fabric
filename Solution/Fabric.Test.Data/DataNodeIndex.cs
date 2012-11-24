using System;
using System.Linq.Expressions;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataNodeIndex {

		string IndexName { get; }
		bool IsForTesting { get; }
		WeaverQuery AddToIndexQuery { get; }

	}

	/*================================================================================================*/
	public class DataNodeIndex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static IList<DataNodeIndex<T>> Create<T>(IList<DataNode<T>> pNodes,
									Expression<Func<T, object>> pIndexValueFunc) where T : IWeaverNode {
			var list = new List<DataNodeIndex<T>>();

			foreach ( DataNode<T> node in pNodes ) {
				list.Add(new DataNodeIndex<T>(node, pIndexValueFunc));
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static DataNodeIndex<T> Create<T>(DataNode<T> pNode,
									Expression<Func<T, object>> pIndexValueFunc) where T : IWeaverNode {
			return new DataNodeIndex<T>(pNode, pIndexValueFunc);
		}

	}

	/*================================================================================================*/
	public class DataNodeIndex<T> : IDataNodeIndex where T : IWeaverNode {

		public string IndexName { get; private set; }
		public Expression<Func<T, object>> IndexValueFunc { get; private set; }
		public bool IsForTesting { get; private set; }
		public WeaverQuery AddToIndexQuery { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataNodeIndex(DataNode<T> pNode, Expression<Func<T, object>> pIndexValueFunc) {
			IndexName = typeof(T).Name+"Id";
			IndexValueFunc = pIndexValueFunc;
			IsForTesting = pNode.IsForTesting;
			AddToIndexQuery = WeaverQuery.AddNodeToIndex(IndexName, pNode.NodeT, pIndexValueFunc);
		}

	}

}