using Weaver;
using Weaver.Interfaces;

namespace Fabric.Test.Data.Setups {

	/*================================================================================================*/
	public interface  ISetupNode {

		bool IsCore { get; }
		WeaverQuery AddQuery { get; }

	}

	/*================================================================================================*/
	public class SetupNode {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static SetupNode<T> Create<T>(T pNode, bool pIsCore) where T : IWeaverItem {
			return new SetupNode<T>(pNode, pIsCore);
		}

	}

	/*================================================================================================*/
	public class SetupNode<T> : ISetupNode where T : IWeaverItem {

		public T Node { get; private set; }
		public bool IsCore { get; private set; }
		public WeaverQuery AddQuery { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupNode(T pNode, bool pIsCore) {
			Node = pNode;
			IsCore = pIsCore;
			AddQuery = WeaverQuery.AddNode(pNode);
		}

	}

}