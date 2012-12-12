using System.Collections.Generic;
using Fabric.Api.Dto;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestFabNode : FabNode {

		protected override long TypeId { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string, string> pData) {}

	}

}