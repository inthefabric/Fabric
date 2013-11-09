using System.Security.Cryptography;
using System.Text;
using Fabric.New.Domain;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class ApiToDomain {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabAppCustom(App pDomain, CreateFabApp pApi) {
			//TODO: FromCreateFabAppCustom
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabFactorCustom(Factor pDomain, CreateFabFactor pApi) {
			if ( pApi.Eventor != null ) {
				FromCreateFabFactorEventor(pDomain, pApi.Eventor);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabFactorEventor(Factor pDomain, CreateFabEventor pEventor) {
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
		private static void FromCreateFabUserCustom(User pDomain, CreateFabUser pApi) {
			//TODO: FromCreateFabUserCustom
			pDomain.Password = HashPassword(pApi.Password);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string HashPassword(string pPassword) {
			//var hash = new SHA512Managed(); //64 byte hash
			var hash = new MD5CryptoServiceProvider(); //16 byte hash
			byte[] bytes = hash.ComputeHash(Encoding.Unicode.GetBytes(pPassword));
			var sb = new StringBuilder();

			for ( int i = 0 ; i < 16 ; i++ ) {
				sb.Append(bytes[i].ToString("x2"));
			}

			return sb.ToString();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		private static void FromFabVertexCustom(Vertex pDomain, FabVertex pApi) {
			long ticks = (long)(pApi.Timestamp*TimeSpan.TicksPerSecond);
			pDomain.Timestamp = ticks+DomainToApi.UnixEpoch.Ticks;
		}*/

	}

}