﻿using System;

namespace Fabric.Infrastructure.Spec {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class SpecFromEnumAttribute : Attribute {
		
		public string Name { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecFromEnumAttribute(string pName) {
			Name = pName;
		}

	}

}