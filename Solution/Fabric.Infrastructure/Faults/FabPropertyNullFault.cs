namespace Fabric.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabPropertyNullFault : FabFault {
		
		public string Name { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPropertyNullFault(string pName) : base(Code.PropertyNullFault, "") {
			Name = pName;
			AppendMessage("Property '"+Name+"' cannot be null.");
		}

	}

}