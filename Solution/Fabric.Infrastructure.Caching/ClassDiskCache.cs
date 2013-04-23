using System;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class ClassDiskCache : DiskCache<string, long>, IClassDiskCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassDiskCache(string pDiskCacheName, bool pForTesting) {
			var opt = new BPlusTree<string, long>.OptionsV2(
				PrimitiveSerializer.String, PrimitiveSerializer.Int64, StringComparer.Ordinal);
			opt.CreateFile = CreatePolicy.IfNeeded;
			opt.StoragePerformance = StoragePerformance.CommitToDisk;

			if ( pForTesting ) {
				opt.CreateFile = CreatePolicy.Always;
				//opt.StoragePerformance = StoragePerformance.Fastest;
			}

			BuildMap(pDiskCacheName, opt);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetMapKey(string pName, string pDisamb) {
			return pName.ToLower()+(pDisamb == null ? "" : "`|`"+pDisamb.ToLower());
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddClass(long pClassId, string pName, string pDisamb) {
			DateTime t = DateTime.UtcNow;
			string key = GetMapKey(pName, pDisamb);
			Add(key, pClassId);
			//Log.Debug("ClassDiskCache.AddClass: "+(DateTime.UtcNow-t).TotalMilliseconds+"ms / "+key);
		}

		/*--------------------------------------------------------------------------------------------*/
		public long? FindClassId(string pName, string pDisamb) {
			DateTime t = DateTime.UtcNow;
			string key = GetMapKey(pName, pDisamb);
			long? result = (ContainsKey(key) ? Get(key) : (long?)null);
			//Log.Debug("ClassDiskCache.FindClassId: "+(DateTime.UtcNow-t).TotalMilliseconds+"ms / "+
			//	key+" / "+result);
			return result;
		}

	}

}