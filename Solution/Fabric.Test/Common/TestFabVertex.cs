using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestFabVertex : FabVertex {

		protected override long TypeId { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string, string> pData) {}

	}

}