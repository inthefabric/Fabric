using System;
using Fabric.Domain;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public interface ITxBuilderVar {

		IWeaverVarAlias Alias { get; }
		Type VarType { get; }

	}


	/*================================================================================================*/
	public interface ITxBuilderVar<T> : ITxBuilderVar where T : INode {

	}

}