using System;
using System.IO;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class TestCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestCache() {
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			dir = Path.Combine(dir, "Fabric");

			BPlusTree<string, long>.OptionsV2 opt = new BPlusTree<string, long>.OptionsV2(
				PrimitiveSerializer.String, PrimitiveSerializer.Int64, StringComparer.Ordinal);
			opt.CreateFile = CreatePolicy.IfNeeded;
			opt.FileName = Path.Combine(dir, "TestCache");
			opt.StoragePerformance = StoragePerformance.CommitToDisk;
			//opt.TransactionLogLimit = 100 * 1024 * 1024; // 100 MB
			//opt.CalcBTreeOrder(10, 16);

			Log.Debug("TestCache File: "+opt.FileName);

			using ( var map = new BPlusTree<string, long>(opt) ) {
				map.Add("foo", 1234567);
				Log.Debug("FIND: "+map["foo"]);
			}
		}

	}

}