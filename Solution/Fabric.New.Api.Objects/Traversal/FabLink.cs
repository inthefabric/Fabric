﻿using System;

namespace Fabric.New.Api.Objects.Traversal {

	/*================================================================================================*/
	public abstract class FabLink : FabElement {

		public string FromType { get; set; }
		public string ToType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabLink(Type pFromType, Type pToType) {
			FromType = pFromType.Name;
			ToType = pFromType.Name;
		}

	}

}