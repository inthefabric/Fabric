using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Util;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class ApiToDomain {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabAppCustom(App pDomain, CreateFabApp pApi) {
			//TODO: FromCreateFabAppCustom
			throw new NotImplementedException();
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
			//TODO: FromCreateFabUserCustom
			pDomain.Password = DataUtil.HashPassword(pApi.Password);
			throw new NotImplementedException();
		}

	}

}