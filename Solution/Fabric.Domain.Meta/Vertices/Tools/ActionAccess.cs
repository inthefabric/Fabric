using System;

namespace Fabric.Domain.Meta.Vertices.Tools {

	/*================================================================================================*/
	public class ActionAccess {

		public bool Creator { get; internal set; }
		public bool AppDataProvider { get; internal set; }
		public bool CustomRules { get; internal set; }

	}

}