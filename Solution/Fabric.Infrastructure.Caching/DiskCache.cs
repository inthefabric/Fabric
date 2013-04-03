using System;
using System.IO;
using CSharpTest.Net.Collections;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public abstract class DiskCache<TKey, TVal> : IDiskCache<TKey, TVal> {

		private BPlusTree<TKey, TVal> Map { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void BuildMap(BPlusTree<TKey, TVal>.OptionsV2 pOptions) {
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			dir = Path.Combine(dir, "Fabric");

			pOptions.FileName = Path.Combine(dir, GetType().Name);
			Log.Debug(GetType().Name+" File: "+pOptions.FileName);

			Map = new BPlusTree<TKey, TVal>(pOptions);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool ContainsKey(TKey pKey) {
			return Map.ContainsKey(pKey);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Add(TKey pKey, TVal pVal) {
			Map.Add(pKey, pVal);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddOrUpdate(TKey pKey, TVal pVal) {
			Map[pKey] = pVal;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TVal Get(TKey pKey) {
			return Map[pKey];
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool Remove(TKey pKey) {
			return Map.Remove(pKey);
		}

	}

}