using System;
using Weaver.Titan.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class FabricPropSchema : WeaverTitanPropSchema {

		public string EnumName { get; set; }
		public bool? SubObjIsOptional { get; set; }
		public bool IsVertexCentricIndex { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabricPropSchema(string pName, string pDbName, Type pType) : 
																		base(pName, pDbName, pType) {}

	}

}