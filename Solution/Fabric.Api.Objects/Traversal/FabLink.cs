using System;

namespace Fabric.Api.Objects.Traversal {

	/*================================================================================================*/
	public abstract class FabLink : FabElement {

		public string FromType { get; set; }
		public string ToType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabLink(Type pFromType, Type pToType) {
			FromType = pFromType.Name;
			ToType = pToType.Name;
		}

	}

}