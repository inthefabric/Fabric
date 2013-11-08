using System.Collections.Generic;
using Weaver.Core.Elements;

namespace Fabric.New.Domain {

	/*================================================================================================*/
	public interface IVertex : IWeaverVertex {

		long VertexId { get; set; }
		long Timestamp { get; set; }
		byte VertexType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Fill(IDictionary<string, string> pData);

	}

}