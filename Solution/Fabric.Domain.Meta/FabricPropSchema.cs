using System;
using Weaver.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class FabricPropSchema : WeaverPropSchema {

		public string EnumName { get; set; }
		public bool? SubObjIsOptional { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabricPropSchema(string pName, string pDbName, Type pType) : 
																		base(pName, pDbName, pType) {}

	}

}