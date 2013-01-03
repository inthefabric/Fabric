using Weaver.Interfaces;
using System;
using System.Linq.Expressions;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface INode : IWeaverNode {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		long GetTypeId();
		Expression<Func<INode, object>> GetTypeIdProp();
		
	}

}