using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using ServiceStack.Text;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Cache {

	/*================================================================================================*/
	public class ClassNameCache : IClassNameCache { //TEST: ClassNameCache

		//TODO: run this in a background thread

		private readonly IApiContext vApiCtx;
		private IDictionary<string, IList<long>> vDupMap { get; set; }
		private readonly int vNameLen;
		private readonly int vDisambLen;
		private readonly object vLock;
		private bool vLoadComplete;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassNameCache(IApiContext pApiCtx, int pNameLen, int pDisambLen) {
			if ( vDupMap != null ) {
				return;
			}

			vDupMap = new Dictionary<string, IList<long>>();
			vApiCtx = pApiCtx;
			vNameLen = pNameLen;
			vDisambLen = pDisambLen;
			vLock = new object();

			Log.Info(pApiCtx.ContextId, "CLASS", "Starting class name cache ("+
				pNameLen+", "+pDisambLen+")...");

			var thr = new Thread(LoadClasses);
			thr.IsBackground = true;
			thr.Start();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void LoadClasses() {
			Log.Info(vApiCtx.ContextId, "CLASS", "Started background thread.");

			long t = DateTime.UtcNow.Ticks;
			int i = 0;
			const int step = 100;

			while ( true ) {
				IWeaverTransaction tx = new WeaverTransaction();
				
				IWeaverFuncAs<Class> col0Var;
				IWeaverFuncAs<Class> col1Var;
				IWeaverFuncAs<Class> col2Var;

				IWeaverTableVarAlias tableVar;

				tx.AddQuery(
					WeaverTasks.InitTableVar(tx, out tableVar)
				);

				var cols = new WeaverTableColumns();
				cols.AddPropertyColumn<Class>(x => x.ClassId);
				cols.AddPropertyColumn<Class>(x => x.Name); //, ".substring(0,"+vNameLen+")");
				cols.AddPropertyColumn<Class>(x => x.Disamb); //, ".substring(0,"+vDisambLen+")");

				Class classPath = 
					ApiFunc.NewPathFromRoot()
					.ContainsClassList.ToClass
						.As(out col2Var)
						.As(out col1Var)
						.As(out col0Var)
					.Limit(i, i+step)
					.Table(tableVar, cols)
						.Iterate();

				col0Var.Label = "c";
				col1Var.Label = "n";
				col2Var.Label = "d";

				tx.AddQuery(classPath.End());
				tx.FinishWithoutStartStop(tableVar);
				IApiDataAccess data = vApiCtx.DbData("GetClassList", tx);
				int n = data.GetTextListCount();

				if ( n == 0 ) {
					break;
				}

				int count = AddToMap(data);

				Log.Info(vApiCtx.ContextId, "CLASS", " * Cached "+n+" Classes ("+
					(i+n)+" total), with "+count+" new keys ["+
					((DateTime.UtcNow.Ticks-t)/10000/1000.0)+" sec]");

				i += step;
			}

			Log.Info(vApiCtx.ContextId, "CLASS", "Class cache completed, with "+
				vDupMap.Keys.Count+" total keys");

			foreach ( KeyValuePair<string, IList<long>> pair in vDupMap ) {
				if ( pair.Value.Count < 10 ) {
					continue;
				}

				Log.Info(vApiCtx.ContextId, "CLASS", " * Warning: cache key '"+pair.Key+"' contains "+
					pair.Value.Count+" ClassId values.");
			}

			vLoadComplete = true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private int AddToMap(IApiDataAccess pClassData) {
			int count = 0;
			int n = pClassData.GetTextListCount();

			for ( int i = 0 ; i < n ; ++i ) {
				string rowData = pClassData.GetStringResultAt(i);
				IDictionary<string, string> row = 
					JsonSerializer.DeserializeFromString<IDictionary<string, string>>(rowData);
				count += AddToMap(int.Parse(row["c"]), row["n"], row["d"]);
			}

			return count;
		}

		/*--------------------------------------------------------------------------------------------*/
		private int AddToMap(long pClassId, string pName, string pDisamb) {
			int count = 0;
			string key = GetMapKey(pName, pDisamb);
			Log.Debug("Class "+pClassId+": \t"+key);

			lock ( vLock ) {
				if ( !vDupMap.ContainsKey(key) ) {
					vDupMap.Add(key, new List<long>());
					count++;
				}

				vDupMap[key].Add(pClassId);
			}

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
		public bool IsLoadComplete() {
			return vLoadComplete;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AddClass(IApiContext pApiCtx, long pClassId, string pName, string pDisamb) {
			int count = AddToMap(pClassId, pName, pDisamb);
			Log.Info(pApiCtx.ContextId, "CLASS", "Class added to cache, with "+count+
				" key(s) added, and "+vDupMap.Keys.Count+" keys total");
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<long> GetClassIds(IApiContext pApiCtx, string pName, string pDisamb) {
			string key = GetMapKey(pName, pDisamb);
			IList<long> list = (vDupMap.ContainsKey(key) ? vDupMap[key].ToList() : null);

			Log.Info(pApiCtx.ContextId, "CLASS", "Found "+(list == null ? 0 : list.Count)+
				" ClassId values for key '"+key+"'");

			return list;
		}

	}

}