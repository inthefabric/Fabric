using System;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Funcs {

	/*================================================================================================*/
	public class TravFunc<T> : ITravFunc where T : FabObject {

		public string Name { get; private set; }
		public Type ForObject { get; private set; }
		public string ForLink { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravFunc(string pName, string pForLink=null) {
			Name = pName;
			ForObject = typeof(T);
			ForLink = pForLink;
		}

	}

}