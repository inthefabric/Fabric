﻿using System;

namespace Fabric.Infrastructure.Api.Faults {
	
	/*================================================================================================*/
	public abstract class FabFault : Exception {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFault(string pMessage) : base(pMessage) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override string Message { get { return base.Message; } }

	}

}