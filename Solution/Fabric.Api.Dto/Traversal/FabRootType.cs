using System.Collections.Generic;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public abstract class FabRootType : FabVertex {

		protected override long TypeId { get { return 0; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string, string> pData) { }

	}


	/*================================================================================================*/
	public class FabRootType<T> : FabRootType where T : IFabVertex {

	}

}