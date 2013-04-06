using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabSpecObject : FabObject {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Description { get; set; }
		public bool IsBaseClass { get; set; }
		public List<FabSpecObjectProp> Properties { get; set; }
		public List<FabSpecTravLink> TraversalLinks { get; set; }
		public List<string> TraversalFunctions { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}