﻿using System;

namespace Fabric.Infrastructure.Spec {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class SpecRegexAttribute : Attribute {

		public string Pattern { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecRegexAttribute(string pPattern) {
			Pattern = pPattern;
		}

	}

}