using System;
using Fabric.New.Infrastructure.Data;
using Weaver.Core.Elements;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class DbToApi {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabElement FromDbDto(IDataDto pDto) {
			return (pDto.VertexType != null ? FromDbDtoV(pDto) : FromDbDtoE(pDto));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillElement(IDataDto pDto, WeaverElement pDom) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static T GetValue<T>(IDataDto pDto, string pName,
														Func<string, T> pConvert, bool pRequired) {
			if ( !pDto.Properties.ContainsKey(pName) ) {
				if ( pRequired ) {
					throw new Exception("Required IDataDto property is missing: "+
						pDto.VertexType+"."+pName);
				}

				return default(T);
			}

			return pConvert(pDto.Properties[pName]);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static bool ConvertBool(string pValue) {
			switch ( pValue.ToLower() ) {
				case "true":
					return true;
				case "false":
					return false;
			}

			throw new Exception("Invalid IDataDto bool value: "+pValue);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string GetString(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, (x => x), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static long GetLong(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, long.Parse, pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static long? GetNullableLong(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, (x => (long?)long.Parse(x)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static byte GetByte(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, byte.Parse, pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static byte? GetNullableByte(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, (x => (byte?)byte.Parse(x)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------* /
		private static double GetDouble(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, double.Parse, pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static double? GetNullableDouble(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, (x => (double?)double.Parse(x)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool GetBool(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, ConvertBool, pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool? GetNullableBool(IDataDto pDto, string pName, bool pRequired) {
			return GetValue(pDto, pName, (x => (bool?)ConvertBool(x)), pRequired);
		}

	}

}