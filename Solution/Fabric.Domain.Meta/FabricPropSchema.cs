using System;
using Weaver.Core.Schema;
using Weaver.Titan.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class FabricPropSchema : WeaverTitanPropSchema {

		public string EnumName { get; set; }
		public bool? SubObjIsOptional { get; set; }
		public bool ToLowerCase { get; set; }

		public WeaverVertexSchema VertexSchema { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabricPropSchema(string pName, string pDbName, Type pType) : 
																		base(pName, pDbName, pType) {}

	}

}