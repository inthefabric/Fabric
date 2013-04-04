using System;
using System.IO;
using CSharpTest.Net.Collections;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public abstract class DiskCache<TKey, TVal> : IDiskCache<TKey, TVal> {

		private BPlusTree<TKey, TVal> vMap { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void BuildMap(BPlusTree<TKey, TVal>.OptionsV2 pOptions, bool pForTesting) {
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			dir = Path.Combine(dir, "Fabric");

			pOptions.FileName = Path.Combine(dir, GetType().Name+(pForTesting ? "Test" : ""));
			Log.Debug(GetType().Name+" File: "+pOptions.FileName);

			vMap = new BPlusTree<TKey, TVal>(pOptions);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool ContainsKey(TKey pKey) {
			return vMap.ContainsKey(pKey);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Add(TKey pKey, TVal pVal) {
			vMap.Add(pKey, pVal);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddOrUpdate(TKey pKey, TVal pVal) {
			vMap[pKey] = pVal;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TVal Get(TKey pKey) {
			return vMap[pKey];
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool Remove(TKey pKey) {
			return vMap.Remove(pKey);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Dispose() {
			vMap.Dispose();
		}

	}

}