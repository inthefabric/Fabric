using System;

namespace Fabric.New.Operations.Traversal.Links {

	/*================================================================================================*/
	public interface ITravLink {

		string Name { get; }
		Type ToObject { get; }
		bool ToOne { get; }

	}

}