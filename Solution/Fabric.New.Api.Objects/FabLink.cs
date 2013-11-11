namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public abstract class FabLink : FabElement {

		public string FromType { get; set; }
		public string ToType { get; set; }

	}


	/*================================================================================================*/
	public abstract class FabLink<TFrom, TTo> : FabLink where TFrom : FabObject where TTo : FabObject {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabLink() {
			FromType = typeof(TFrom).Name;
			ToType = typeof(TTo).Name;
		}

	}

}