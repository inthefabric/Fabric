using System.Collections.Generic;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IItemWithId {

		string Id { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void FillWithData(IDictionary<string, string> pData);

	}

}