﻿using System;
using System.Collections.Generic;
using System.Threading;
using Fabric.Domain;

namespace Fabric.Infrastructure {

	//idea from: https://github.com/twitter/snowflake

	/*================================================================================================*/
	public static class Sharpflake {

		//Skip: 1 bit (IDs type signed long/Int64)
		//Millis: 43 bits
		//Server: 12 bits
		//Sequence: 8 bits

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
				Log.Debug("Clock moved backwards; sleeping for the next "+(LastMilli-m)+"ms...");
				Thread.Sleep((int)(LastMilli-m+1));
				return GetMilli();
				//throw new Exception("Clock moved backwards; rejecting requests for the next "+
				//	(LastMilli-m)+"ms. "+m+" / "+LastMilli);
			}

			LastMilli = m;
			return m;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static SharpflakeSequence GetSequence<T>() where T : INode {
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
		public static long GetId<T>() where T : INode {
			long m = GetMilli();
			return (m << 20) + (ServerId << 8) + GetSequence<T>().NextIndex;
		}

		/*--------------------------------------------------------------------------------------------* /
		public static string GetIdStr<T>() where T : INode {
			long m = GetMilli();
			return Convert.ToString(m<<20, 2) + "." + Convert.ToString(ServerId<<8, 2) + "." +
				Convert.ToString(GetSequence<T>().NextIndex, 2);
		}*/

	}
	
	/*================================================================================================*/
	internal class SharpflakeSequence {

		private long vLastMilli;
		private int vIndex; // 0 to 255

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int NextIndex {
			get {
				long m = Sharpflake.GetMilli();

				if ( m > vLastMilli ) {
					vLastMilli = m;
					vIndex = 0;
				}
				else if ( ++vIndex >= 256 ) {
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