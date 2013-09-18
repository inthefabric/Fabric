using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure;

namespace Fabric.Api.Meta {

	/*================================================================================================*/
	public static class SpecBuilderCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecValue(string pTypeName, string pPropName, FabSpecValue pValue) {
			Log.Debug("FILL CUSTOM: "+pTypeName+"."+pPropName);
			switch ( pTypeName+"."+pPropName ) {

				case "Eventor.Year":
					FactorEventorYear(pValue);
					break;

				case "Eventor.Month":
					FactorEventorMonth(pValue);
					break;

				case "Eventor.Day":
					FactorEventorDay(pValue);
					break;

				case "Eventor.Hour":
					FactorEventorHour(pValue);
					break;

				case "Eventor.Minute":
					FactorEventorMinute(pValue);
					break;

				case "Eventor.Second":
					FactorEventorSecond(pValue);
					break;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecDtoProp(string pTypeName, string pPropName, FabSpecObjectProp pProp){
			FillSpecValue(pTypeName, pPropName, pProp);

			switch ( pTypeName+"."+pPropName ) {

				case "Eventor.Year":
					FactorEventorYear(pProp);
					break;

				case "Eventor.Month":
					FactorEventorMonth(pProp);
					break;

				case "Eventor.Day":
					FactorEventorDay(pProp);
					break;

				case "Eventor.Hour":
					FactorEventorHour(pProp);
					break;

				case "Eventor.Minute":
					FactorEventorMinute(pProp);
					break;
				case "Eventor.Second":
					FactorEventorSecond(pProp);
					break;
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FactorEventorYear(FabSpecValue pValue) {
			pValue.Min = -100000000000;
			pValue.Max = 100000000000;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FactorEventorMonth(FabSpecValue pValue) {
			pValue.IsOptional = true;
			pValue.Min = 1;
			pValue.Max = 12;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FactorEventorDay(FabSpecValue pValue) {
			pValue.IsOptional = true;
			pValue.Min = 1;
			pValue.Max = 31;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FactorEventorHour(FabSpecValue pValue) {
			pValue.IsOptional = true;
			pValue.Min = 0;
			pValue.Max = 23;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FactorEventorMinute(FabSpecValue pValue) {
			pValue.IsOptional = true;
			pValue.Min = 0;
			pValue.Max = 59;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FactorEventorSecond(FabSpecValue pValue) {
			pValue.IsOptional = true;
			pValue.Min = 0;
			pValue.Max = 59;
		}

	}

}