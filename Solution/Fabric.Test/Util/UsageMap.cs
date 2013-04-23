using System.Collections.Generic;
using NUnit.Framework;

namespace Fabric.Test.Util {

	/*================================================================================================*/
	public class UsageMap {

		private readonly Dictionary<string, int> vMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UsageMap() {
			vMap = new Dictionary<string, int>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Increment(string pKey) {
			if ( vMap.ContainsKey(pKey) ) {
				vMap[pKey]++;
				return;
			}

			vMap.Add(pKey, 1);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AssertUses(string pKey, int pUses) {
			int uses = 0;

			if ( vMap.ContainsKey(pKey) ) {
				uses = vMap[pKey];
			}

			Assert.AreEqual(pUses, uses, "Incorrect usage count for key '"+pKey+"'.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AssertNoOverallUses() {
			Assert.AreEqual(0, vMap.Keys.Count, "There should be no usage keys.");
		}

	}

}