using System;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class ServiceOpAttribute : Attribute {

		public string ServiceUri { get; private set; }
		public string Method { get; private set; }
		public string ServiceOperationUri { get; private set; }
		public Type ReturnType { get; private set; }

		public string ResxKey { get; set; }
		public ServiceAuthType Auth { get; set; }
		public Type AuthMemberOwns { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ServiceOpAttribute(string pServiceUri, string pMethod, 
													string pServiceOperationUri, Type pReturnType) {
			ServiceUri = pServiceUri;
			Method = pMethod;
			ServiceOperationUri = pServiceOperationUri;
			ReturnType = pReturnType;
			Auth = ServiceAuthType.None;
		}

	}

}