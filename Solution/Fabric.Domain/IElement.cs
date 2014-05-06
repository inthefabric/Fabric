using System.Collections.Generic;
using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IElement : IWeaverElement {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Fill(IDictionary<string, string> pData);

	}

}