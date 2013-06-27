using System.Collections.Generic;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IElementWithId {

		string Id { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void FillWithData(IDictionary<string, string> pData);

	}

}