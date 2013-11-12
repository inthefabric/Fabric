namespace Fabric.New.Api.Objects.Traversal {

	/*================================================================================================*/
	public abstract class FabLink : FabElement {

		public string FromType { get; set; }
		public string ToType { get; set; }

	}


	/*================================================================================================*/
	public abstract class FabLink<TFrom, TTo> : FabLink where TFrom : FabVertex where TTo : FabVertex {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabLink() {
			FromType = typeof(TFrom).Name;
			ToType = typeof(TTo).Name;
		}

	}

}