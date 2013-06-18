using System;
using System.Linq.Expressions;
using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface INode : IWeaverVertex {

		byte FabType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		long GetTypeId();
		void SetTypeId(long pTypeId);

		/*--------------------------------------------------------------------------------------------*/
		Expression<Func<T, object>> GetTypeIdProp<T>() where T : INode;
		
	}

}