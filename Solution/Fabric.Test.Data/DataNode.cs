using System;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataNode {

		INode Node { get; }
		Type NodeType { get; }
		bool IsForTesting { get; }
		IWeaverQuery AddQuery { get; }

	}

	/*================================================================================================*/
	public class DataNode {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> Create<T>(T pNode, bool pIsForTest) where T : INode {
			return new DataNode<T>(pNode, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataNode<T> : IDataNode where T : INode {

		public T NodeT { get; private set; }
		public Type NodeType { get; private set; }
		public INode Node { get; private set; }

		public bool IsForTesting { get; private set; }
		public IWeaverQuery AddQuery { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataNode(T pNode, bool pIsForTesting) {
			Node = pNode;
			NodeT = pNode;
			NodeType = typeof(T);
			IsForTesting = pIsForTesting;
			AddQuery = WeaverTasks.AddNode(pNode);
		}

	}

}