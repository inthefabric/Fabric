using System;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class ClassDiskCache : DiskCache<string, long>, IClassDiskCache {

		public static readonly ClassDiskCache Instance = new ClassDiskCache();
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private ClassDiskCache() {
			var opt = new BPlusTree<string, long>.OptionsV2(
				PrimitiveSerializer.String, PrimitiveSerializer.Int64, StringComparer.Ordinal);
			opt.CreateFile = CreatePolicy.IfNeeded;
			opt.StoragePerformance = StoragePerformance.CommitToDisk;

			BuildMap(opt);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetMapKey(string pName, string pDisamb) {
			return pName.ToLower()+(pDisamb == null ? "" : "`|`"+pDisamb.ToLower());
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddClass(long pClassId, string pName, string pDisamb) {
			string key = GetMapKey(pName, pDisamb);
			Add(key, pClassId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public long GetClassId(string pName, string pDisamb) {
			return Get(GetMapKey(pName, pDisamb));
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool ContainsClass(string pName, string pDisamb) {
			return ContainsKey(GetMapKey(pName, pDisamb));
		}

	}

}