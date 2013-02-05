using System;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class ServiceOpAttribute : Attribute {

		public string ServiceUri { get; set; }
		public string Method { get; set; }
		public string ServiceOperationUri { get; set; }
		public Type ReturnType { get; set; }
		public string ResxKey { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ServiceOpAttribute(string pServiceUri, string pMethod, 
													string pServiceOperationUri, Type pReturnType) {
			ServiceUri = pServiceUri;
			Method = pMethod;
			ServiceOperationUri = pServiceOperationUri;
			ReturnType = pReturnType;
		}

	}

}