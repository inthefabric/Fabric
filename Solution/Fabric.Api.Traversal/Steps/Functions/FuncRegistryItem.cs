using System;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public class FuncRegistryItem {

		public Type FuncType { get; set; }
		public string Command { get; set; }
		public string Uri { get; set; }
		public Func<Path, IFuncStep> New { get; set; }
		public Func<Type, bool> Allow { get; set; }

	}

}