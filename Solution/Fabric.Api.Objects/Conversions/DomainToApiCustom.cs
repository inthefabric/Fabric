﻿using Fabric.Api.Objects.Meta;
using Fabric.Domain;
using Fabric.Infrastructure.Util;

namespace Fabric.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class DomainToApi {
		

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
			long y;
			byte? mo, d, h, min, s;
			DataUtil.EventorLongToTimes(pDateTime, out y, out mo, out d, out h, out min, out s);

			pApi.Eventor.Year = y;
			pApi.Eventor.Month = mo;
			pApi.Eventor.Day = d;
			pApi.Eventor.Hour = h;
			pApi.Eventor.Minute = min;
			pApi.Eventor.Second = s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromVertexCustom(FabVertex pApi, Vertex pDomain) {
			pApi.Timestamp = FabMetaTime.GetTimestamp(pDomain.Timestamp);
		}

	}

}