using System;
using System.Collections.Generic;
using System.Threading;
using Fabric.Domain;

namespace Fabric.Infrastructure.Query {

	//idea from: https://github.com/twitter/snowflake

	/*================================================================================================*/
	public static class Sharpflake {

		public const int MilliBitCount = 43;
		public const int ServerBitCount = 12;
		public const int SequenceBitCount = 8;

		public const int MilliBitIndex = 1; //Skip 1 bit (IDs type signed long/Int64)
		public const int ServerBitIndex = MilliBitIndex+MilliBitCount;
		public const int SequenceBitIndex = ServerBitIndex+ServerBitCount;
		
		public const int SequenceMax = (1 << SequenceBitCount);

		private const int ServerId = 0; //0 to 4095

		private static long LastMilli;
		private static readonly Dictionary<Type, SharpflakeSequence> Sequence = 
			new Dictionary<Type, SharpflakeSequence>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long GetMilli() {
			//milliseconds since Jan 1, 2012
			//this will overflow 43 bits in year 2290 (278.9 years)
			
			long m = (DateTime.UtcNow.AddYears(-2011).Ticks/10000L);

			if ( m < LastMilli ) {
				//Log.Debug("Clock moved backwards; sleeping for the next "+(LastMilli-m)+"ms...");
				Thread.Sleep((int)(LastMilli-m+1));
				return GetMilli();
			}

			LastMilli = m;
			return m;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static SharpflakeSequence GetSequence<T>() where T : IVertex {
			Type t = typeof(T);

			lock ( Sequence ) {
				if ( !Sequence.ContainsKey(t) ) {
					Sequence.Add(t, new SharpflakeSequence());
				}
			}

			return Sequence[t];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static long GetId<T>() where T : IVertex {
			SharpflakeSequence seq = GetSequence<T>();
			long m;
			int i = seq.GetNextIndex(out m);
			return (m << 20) + (ServerId << 8) + i;
		}

	}
	
	/*================================================================================================*/
	internal class SharpflakeSequence {

		private long vLastMilli;
		private int vIndex;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int GetNextIndex(out long pMilli) {
			long m;
			int i;

			lock ( this ) {
				m = Sharpflake.GetMilli();

				if ( m > vLastMilli ) {
					vLastMilli = m;
					vIndex = 0;
				}
				else if ( ++vIndex >= Sharpflake.SequenceMax ) {
					m = SpinUntilNextMilli();
					vIndex = 0;
				}

				i = vIndex; //capture value before leaving the lock
			}

			pMilli = m;
			return i;
		}

		/*--------------------------------------------------------------------------------------------*/
		private long SpinUntilNextMilli() {
			long m = Sharpflake.GetMilli();

			while ( m <= vLastMilli ) {
				m = Sharpflake.GetMilli();
			}

			vLastMilli = m;
			return m;
		}

	}

}