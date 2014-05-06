using Fabric.Domain;
using Fabric.Infrastructure.Util;

namespace Fabric.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class ApiToDomain {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabAppCustom(App pDomain, CreateFabApp pApi) {
			pDomain.Name = pApi.Name;
			pDomain.NameKey = pApi.Name.ToLower();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabClassCustom(Class pDomain, CreateFabClass pApi) {
			pDomain.Name = pApi.Name;
			pDomain.NameKey = pApi.Name.ToLower();
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
			pDomain.EventorDateTime = DataUtil.EventorTimesToLong(pEventor.Year, pEventor.Month, 
				pEventor.Day, pEventor.Hour, pEventor.Minute, pEventor.Second);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabUserCustom(User pDomain, CreateFabUser pApi) {
			pDomain.Name = pApi.Name;
			pDomain.NameKey = pApi.Name.ToLower();
			pDomain.Password = DataUtil.HashPassword(pApi.Password);
		}

	}

}