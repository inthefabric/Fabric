using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public abstract class FabObject : IFabObject {

		public string FabType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabObject() {
			FabType = GetType().Name;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract void Fill(IDbDto pDbDto);

	}

}