using System;
using System.Reflection;
using Fabric.Domain;
using Weaver;
using Weaver.Items;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class Setup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataSet SetupAll(bool pIsForTesting) {
			var ds = new DataSet(pIsForTesting);
			SetupAddNodeIndexes(ds);
			SetupAddNodes(ds, pIsForTesting);
			return ds;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAddNodeIndexes(DataSet pSet) {
			Type[] types = Assembly.GetAssembly(typeof(Root)).GetTypes();
			Type nodeType = typeof(WeaverNode);

			foreach ( Type t in types ) {
				if ( t.IsAbstract ) { continue; }
				if ( !nodeType.IsAssignableFrom(t) ) { continue; }
				pSet.AddIndex(WeaverTasks.AddNodeIndex(t.Name));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAddNodes(DataSet pSet, bool pIsForTesting) {
			SetupTypes.SetupAll(pSet);
			SetupUsers.SetupAll(pSet);
			SetupOauth.SetupAll(pSet);
			SetupObjects.SetupAll(pSet);
			SetupFactors.SetupAll(pSet);
		}

	}

}