using Fabric.Domain;
using Weaver;

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