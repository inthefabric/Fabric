using System;
using Weaver.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class FabricPropSchema : WeaverPropSchema {

		public string EnumName { get; set; }
		public bool? SubObjIsOptional { get; set; }
		public bool? IndexWithTitan { get; set; }
		public bool? IndexWithElasticSearch { get; set; }
		public bool IsVertexCentricIndex { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabricPropSchema(string pName, string pDbName, Type pType) : 
																		base(pName, pDbName, pType) {}

	}

}