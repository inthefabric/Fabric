using System;
using Fabric.New.Domain;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class ApiToDomain {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromFabFactorCustom(Factor pDomain, FabFactor pApi) {
			if ( pApi.Eventor != null ) {
				FromFabFactorEventor(pDomain, pApi.Eventor);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static void FromFabFactorEventor(Factor pDomain, FabEventor pEventor) {
			long t = pEventor.Year*DomainToApi.SecPerYear;

			if ( pEventor.Month != null ) {
				t += (byte)pEventor.Month*DomainToApi.SecPerMonth; //do not add 1
			}

			if ( pEventor.Day != null ) {
				t += (byte)pEventor.Day*DomainToApi.SecPerDay; //do not add 1
			}

			if ( pEventor.Hour != null ) {
				t += ((byte)pEventor.Hour+1)*DomainToApi.SecPerHour;
			}

			if ( pEventor.Minute != null ) {
				t += ((byte)pEventor.Minute+1)*DomainToApi.SecPerMin;
			}

			if ( pEventor.Second != null ) {
				t += ((byte)pEventor.Second+1);
			}

			pDomain.EventorDateTime = t;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromFabVertexCustom(Vertex pDomain, FabVertex pApi) {
			long ticks = (long)(pApi.Timestamp*TimeSpan.TicksPerSecond);
			pDomain.Timestamp = ticks+DomainToApi.UnixEpoch.Ticks;
		}

	}

}