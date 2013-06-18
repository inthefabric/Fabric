using System.Collections.Generic;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public class FabRoot : FabVertex {

		protected override long TypeId { get { return 0; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string, string> pData) {}
		
	}

}