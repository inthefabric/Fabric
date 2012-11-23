using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.Domain;
using Weaver;
using Weaver.Items;

namespace Fabric.Test.Data.Setups {

	/*================================================================================================*/
	public class Setup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static List<WeaverQuery> SetupIndexes() {
			Type[] types = Assembly.GetAssembly(typeof(Root)).GetTypes();
			Type nodeType = typeof(WeaverNode);
			var queries = new List<WeaverQuery>();

			foreach ( Type t in types ) {
				if ( t.IsAbstract ) { continue; }
				if ( !nodeType.IsAssignableFrom(t) ) { continue; }
				queries.Add(WeaverQuery.AddNodeIndex(t.Name));
			}

			return queries;
		}

	}

}