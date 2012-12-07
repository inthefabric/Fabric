﻿namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public class Path {

		public string Script { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Path() {
			Script = "";
		}

		/*--------------------------------------------------------------------------------------------*/
		public Path Add(string pScript) {
			Script += (Script.Length == 0 ? "" : ".")+pScript;
			return this;
		}

	}

}