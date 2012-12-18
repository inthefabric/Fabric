namespace Fabric.Infrastructure.Domain {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		private static Schema SchemaInner;
		
		public static Schema SchemaInstance {
			get { 
				if ( SchemaInner == null ) { SchemaInner = new Schema(); }
				return SchemaInner;
			}
		}

	}

}