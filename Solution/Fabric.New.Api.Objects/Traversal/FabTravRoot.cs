﻿namespace Fabric.New.Api.Objects.Traversal {

	/*================================================================================================*/
	public class FabTravRoot : FabObject {}

	/*================================================================================================*/
	public abstract class FabTravRoot<T> : FabTravRoot where T : FabVertex {}

}