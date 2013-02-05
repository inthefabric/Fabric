using System;
using Fabric.Api.Dto;

namespace Fabric.Api.Common {

	/*================================================================================================*/
	public class ParameterException : Exception {

		public FabError Error { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ParameterException(string pType, string pMessage) : base(pType+" / "+pMessage) {
			Error = new FabError();
			Error.Type = pType;
			Error.Message = pMessage;
		}

	}

}