using Fabric.Infrastructure;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public interface IFabNode {

		long NodeId { get; set; }

		//string BaseUri { get; set; }
		//string NodeUri { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Fill(DbDto pDbDto);

	}

}