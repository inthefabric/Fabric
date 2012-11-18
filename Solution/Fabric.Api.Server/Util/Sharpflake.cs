using System;
using System.Collections.Generic;

namespace Fabric.Api.Server.Util {

	//idea from: https://github.com/twitter/snowflake

	/*================================================================================================*/
	public class Sharpflake {

		public enum SequenceKey {
			App = 1,
			Artifact,
			Crowd,
			Factor,
			User //and many more...
		}

		public const int ServerId = 0; //0 to 1023

		private static long LastMilli = 0;
		private readonly static Dictionary<SequenceKey, SharpflakeSequence> Sequence = BuildSequence();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<SequenceKey, SharpflakeSequence> BuildSequence() {
			var seq = new Dictionary<SequenceKey, SharpflakeSequence>();

			foreach ( SequenceKey key in Enum.GetValues(typeof(SequenceKey)) ) {
				seq[key] = new SharpflakeSequence();
			}

			return seq;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static long GetMilli() {
			//milliseconds since Jan 1, 2012
			//this will overflow 41 bits in year 2071 (69 years)
			
			long m = (DateTime.Now.AddYears(-2011).Ticks/10000L);

			if ( m < LastMilli ) {
				throw new Exception("Clock moved backwards; rejecting requests for the next "+
					(LastMilli-m)+"ms. "+m+" / "+LastMilli);
			}

			LastMilli = m;
			return m;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long GetId(SequenceKey pKey) {
			long m = GetMilli();
			return (m << 22) + (ServerId << 12) + Sequence[pKey].NextIndex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetIdStr(SequenceKey pKey) {
			long m = GetMilli();
			return Convert.ToString(m, 2) + "." + Convert.ToString(ServerId, 2) + "." +
				Convert.ToString(Sequence[pKey].NextIndex, 2);
		}

	}
	
	/*================================================================================================*/
	internal class SharpflakeSequence {

		private long vLastMilli;
		private int vIndex; // 0 to 4095

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int NextIndex {
			get {
				long m = Sharpflake.GetMilli();

				if ( m > vLastMilli ) {
					vLastMilli = m;
					vIndex = 0;
				}
				else if ( ++vIndex >= 4096 ) {
					SpinUntilNextMilli();
					vIndex = 0;
				}

				return vIndex;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SpinUntilNextMilli() {
			long m = Sharpflake.GetMilli();

			while ( m <= vLastMilli ) {
				m = Sharpflake.GetMilli();
			}

			vLastMilli = m;
		}

	}

}