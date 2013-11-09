using System;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Links {

	/*================================================================================================*/
	public class TravLink<T> : ITravLink where T : FabObject {

		public string Name { get; private set; }
		public Type ToObject { get; private set; }
		public bool ToOne { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravLink(string pName, bool pToOne) {
			Name = pName;
			ToObject = typeof(T);
			ToOne = pToOne;
		}

	}

}