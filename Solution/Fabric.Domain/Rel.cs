using System.Collections.Generic;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract class Rel<TFrom, TType, TTo> : WeaverRel<TFrom,TType,TTo>, IRel
																	where TFrom : IWeaverNode, new()
																	where TType : IWeaverRelType, new()
																	where TTo : IWeaverNode, new() {

		public string ToNodeId { get; set; }
		public string FromNodeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithData(IDictionary<string, string> pData) {}

	}

}