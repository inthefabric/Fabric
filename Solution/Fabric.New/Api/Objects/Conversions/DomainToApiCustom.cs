using System;
using Fabric.New.Domain;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class DomainToApi {
		
		internal const int SecPerMin = (60+1);
		internal const int SecPerHour = SecPerMin*(60+1);
		internal const int SecPerDay = SecPerHour*(24+1);
		internal const int SecPerMonth = SecPerDay*(31+1);
		internal const int SecPerYear = SecPerMonth*(12+1); //38,698,400 sec; allows +/- 238 billion yrs

		internal static readonly DateTime UnixEpoch = 
			new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromAppCustom(FabApp pApi, App pDomain) {
			//TODO: FromAppCustom
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromFactorCustom(FabFactor pApi, Factor pDomain) {
			if ( pDomain.DirectorType == null ) {
				pApi.Director = null;
			}

			if ( pDomain.EventorType == null ) {
				pApi.Eventor = null;
			}
			else if ( pDomain.EventorDateTime != null ) {
				FromFactorFillEventorDateTime(pApi, (long)pDomain.EventorDateTime);
			}

			if ( pDomain.IdentorType == null ) {
				pApi.Identor = null;
			}

			if ( pDomain.LocatorType == null ) {
				pApi.Locator = null;
			}

			if ( pDomain.VectorType == null ) {
				pApi.Vector = null;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromFactorFillEventorDateTime(FabFactor pApi, long pDateTime) {
			long mod = pDateTime%SecPerYear;
			long dt = mod;

			pApi.Eventor.Year = (pDateTime-mod)/SecPerYear;
			pApi.Eventor.Month = EventorExtractTime(dt, SecPerMonth, 0, out dt);
			pApi.Eventor.Day = EventorExtractTime(dt, SecPerDay, 0, out dt);
			pApi.Eventor.Hour = EventorExtractTime(dt, SecPerHour, -1, out dt);
			pApi.Eventor.Minute = EventorExtractTime(dt, SecPerMin, -1, out dt);
			pApi.Eventor.Second = (dt == 0 ? null : (byte?)(dt-1));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static byte? EventorExtractTime(long pDateTime, int pSecs, int pOffset,
																				out long pNewDateTime) {
			long mod = pDateTime%pSecs;
			pNewDateTime = mod;
			long diff = (pDateTime-mod);

			if ( diff == 0 ) {
				return null;
			}

			byte val = (byte)(diff/pSecs);
			return (byte?)(val+pOffset);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromUserCustom(FabUser pApi, User pDomain) {
			//TODO: FromUserCustom
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromVertexCustom(FabVertex pApi, Vertex pDomain) {
			pApi.IdStr = pDomain.Id+"";
			pApi.Timestamp = (float)(new DateTime(pDomain.Timestamp)-UnixEpoch).TotalSeconds;
		}

	}

}