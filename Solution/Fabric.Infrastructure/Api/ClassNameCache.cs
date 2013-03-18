using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ClassNameCache : IClassNameCache { //TEST: ClassNameCache

		private IDictionary<string, IList<long>> vDupMap { get; set; }
		private int vNameLen;
		private int vDisambLen;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassNameCache(IApiContext pApiCtx, int pNameLen, int pDisambLen) {
			if ( vDupMap != null ) {
				return;
			}

			vDupMap = new Dictionary<string, IList<long>>();
			vNameLen = pNameLen;
			vDisambLen = pDisambLen;

			////

			Log.Info(pApiCtx.ContextId, "CLASS", "Starting class name cache ("+
				pNameLen+", "+pDisambLen+")...");

			long t = DateTime.UtcNow.Ticks;
			int i = 0;
			const int step = 1000;

			while ( true ) {
				IWeaverQuery q = 
					ApiFunc.NewPathFromRoot()
					.ContainsClassList.ToClass
					.Limit(i, i+step)
					.End();

				IList<Class> list = pApiCtx.DbList<Class>("GetClassList", q);

				if ( list == null || list.Count == 0 ) {
					break;
				}

				int count = AddToMap(list);

				Log.Info(pApiCtx.ContextId, "CLASS", " * Cached "+list.Count+" Classes ("+
					(i+list.Count)+" total), with "+count+" new keys ["+
					((DateTime.UtcNow.Ticks-t)/10000/1000.0)+" sec]");

				i += step;
			}

			Log.Info(pApiCtx.ContextId, "CLASS", "Class cache completed, with "+
				vDupMap.Keys.Count+" total keys");

			foreach ( KeyValuePair<string, IList<long>> pair in vDupMap ) {
				if ( pair.Value.Count < 10 ) {
					continue;
				}

				Log.Info(pApiCtx.ContextId, "CLASS", " * Warning: cache key '"+pair.Key+"' contains "+
					pair.Value.Count+" ClassId values.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private int AddToMap(IList<Class> pClassList) {
			int count = 0;

			foreach ( Class c in pClassList ) {
				count += AddToMap(c);
			}

			return count;
		}

		/*--------------------------------------------------------------------------------------------*/
		private int AddToMap(Class pClass) {
			int count = 0;
			string key = GetMapKey(pClass.Name, pClass.Disamb);

			if ( !vDupMap.ContainsKey(key) ) {
				vDupMap.Add(key, new List<long>());
				count++;
			}

			vDupMap[key].Add(pClass.ClassId);
			return count;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetMapKey(string pName, string pDisamb) {
			string name = pName.ToLower();
			string dis = (pDisamb == null ? "" : "|"+pDisamb.ToLower());

			return name.Substring(0, Math.Min(vNameLen, name.Length))+
				dis.Substring(0, Math.Min(vDisambLen+1, dis.Length));
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddClass(IApiContext pApiCtx, Class pClass) {
			int count = AddToMap(pClass);
			Log.Info(pApiCtx.ContextId, "CLASS", "Class added to cache, with "+count+
				" key(s) added, and "+vDupMap.Keys.Count+" keys total");
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<long> GetClassIds(string pName, string pDisamb) {
			string key = GetMapKey(pName, pDisamb);
			return (vDupMap.ContainsKey(key) ? vDupMap[key].ToList() : null);
		}

	}

}