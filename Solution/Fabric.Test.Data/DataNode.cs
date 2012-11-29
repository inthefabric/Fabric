using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataNode {

		INode Node { get; }
		bool IsForTesting { get; }
		WeaverQuery AddQuery { get; }

	}

	/*================================================================================================*/
	public class DataNode {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> Create<T>(T pNode) where T : INode {
			return Create(pNode, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> CreateTest<T>(T pNode) where T : INode {
			return Create(pNode, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> Create<T>(T pNode, bool pIsForTest) where T : INode {
			return new DataNode<T>(pNode, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataNode<T> : IDataNode where T : INode {

		public T NodeT { get; private set; }
		public INode Node { get; private set; }

		public bool IsForTesting { get; private set; }
		public WeaverQuery AddQuery { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataNode(T pNode, bool pIsForTesting) {
			Node = pNode;
			NodeT = pNode;
			IsForTesting = pIsForTesting;
			AddQuery = WeaverQuery.AddNode(pNode);
		}

	}

}