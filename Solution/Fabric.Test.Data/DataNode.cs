using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataNode {

		IWeaverNode Node { get; }
		bool IsForTesting { get; }
		WeaverQuery AddQuery { get; }

	}

	/*================================================================================================*/
	public class DataNode {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> Create<T>(T pNode) where T : IWeaverNode {
			return Create(pNode, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> CreateTest<T>(T pNode) where T : IWeaverNode {
			return Create(pNode, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static DataNode<T> Create<T>(T pNode, bool pIsForTest) where T : IWeaverNode {
			return new DataNode<T>(pNode, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataNode<T> : IDataNode where T : IWeaverNode {

		public T NodeT { get; private set; }
		public IWeaverNode Node { get; private set; }

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