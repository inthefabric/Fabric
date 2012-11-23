using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Test.Data.Setups;
using NUnit.Framework;
using Weaver;

namespace Fabric.Test {

	/*================================================================================================*/
	[TestFixture]
	public class DataTests {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetupIndexes() {
			List<WeaverQuery> queries = Setup.SetupIndexes();

			foreach ( WeaverQuery q in queries ) {
				string json = FabricUtil.WeaverQueryToJson(q);
				Console.WriteLine(json);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetupTypesAll() {
			IList<ISetupNode> nodes = SetupTypes.SetupAll();

			foreach ( ISetupNode n in nodes ) {
				string json = FabricUtil.WeaverQueryToJson(n.AddQuery);
				Console.WriteLine(json);
			}
		}

	}

}