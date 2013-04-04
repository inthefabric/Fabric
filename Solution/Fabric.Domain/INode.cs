﻿using Weaver.Interfaces;
using System;
using System.Linq.Expressions;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface INode : IWeaverNode {

		int FabType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		long GetTypeId();
		Expression<Func<T, object>> GetTypeIdProp<T>() where T : INode;
		
	}

}