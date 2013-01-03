using System;
using Fabric.Domain;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class TxBuilderVar<T> : ITxBuilderVar<T> where T : INode { //TEST: TxBuilderVar

		public IWeaverVarAlias Alias { get; private set; }
		public Type VarType { get; private set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TxBuilderVar(IWeaverVarAlias pAlias) {
			Alias = pAlias;
			VarType = typeof(T);
		}

	}

}