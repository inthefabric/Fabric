using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Query;
using NUnit.Framework;

namespace Fabric.Test.Unit.Infrastructure.Query {

	/*================================================================================================*/
	[TestFixture]
	public class TSharpflake {

		private static readonly Logger Log = Logger.Build<TSharpflake>();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(2)]
		[TestCase(5)]
		[TestCase(8)]
		public void UniqueIds(int pMaxParallel) {
			var map = new Dictionary<long, int>();
			int count = 0;
			var opt = new ParallelOptions { MaxDegreeOfParallelism = pMaxParallel };

			Parallel.For(0, 100000, opt, (i, state) => {
				long id = Sharpflake.GetId<Vertex>();

				lock ( map ) {
					if ( map.ContainsKey(id) ) {
						Assert.Fail("Duplicate ID '"+id+"' at index '"+count+"'.");
					}

					map.Add(id, count);
					++count;
				}
			});

			/*foreach ( long id in map.Keys ) {
				Log.Debug("ID: "+id+" / "+GetIdComponentString(id, true)+" / "+
					GetIdComponentString(id, false));
			}*/
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static long[] GetIdComponents(long pId) {
			long t = (pId >> 20);
			long t2 = (t << 20);
			long s = ((pId-t2) >> 8);
			long s2 = (s << 8);
			return new [] { t, s, (pId-t2-s2) };
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetIdComponentString(long pId, bool pBinary) {
			long[] c = GetIdComponents(pId);

			if ( !pBinary ) {
				return c[0]+"."+c[1]+"."+c[2];
			}

			string tStr = Convert.ToString(c[0], 2);
			string sStr = Convert.ToString(c[1], 2);
			string qStr = Convert.ToString(c[2], 2);
			return tStr+"."+sStr.PadLeft(12, '0')+"."+qStr.PadLeft(8, '0');
		}

	}

}