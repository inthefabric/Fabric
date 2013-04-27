using System;
using System.Collections.Generic;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Db {

	/*================================================================================================*/
	public static class RexConnCommand {

		public const String Session = "session";
		public const String Query = "query";
		public const String Config = "config";

	}


	/*================================================================================================*/
	public static class RexConnSessionAction {

		public const String Start = "start";
		public const String Close = "close";
		public const String Commit = "commit";
		public const String Rollback = "rollback";

	}


	/*================================================================================================*/
	public static class RexConnConfigSetting {

		public const String Debug = "debug";
		public const String Pretty = "pretty";

	}

	
	/*================================================================================================*/
	public class RexConnTcpRequest {

		public String ReqId { get; set; }
		public String SessId { get; set; }
		public IList<RexConnTcpRequestCommand> CmdList { get; set; }
		
	}


	/*================================================================================================*/
	public class RexConnTcpRequestCommand {

		public String Cmd { get; set; }
		public IList<String> Args { get; set; }

	}


	/*================================================================================================*/
	public class RexConnTcpResponse {

		public String ReqId { get; set; }
		public String SessId { get; set; }
		public long Timer { get; set; }
		public String Err { get; set; }
		public IList<RexConnTcpResponseCommand> CmdList { get; set; }

	}


	/*================================================================================================*/
	public class RexConnTcpResponseCommand {

		public long Timer { get; set; }
		public IList<JsonObject> Results { get; set; }
		public String Err { get; set; }

	}

}