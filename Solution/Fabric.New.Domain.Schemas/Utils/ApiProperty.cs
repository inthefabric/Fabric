using System;

namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class ApiProperty {

		public const string ValidCodeRegex = 
			@"^[a-zA-Z0-9]*$";

		public const string ValidUserRegex = 
			@"^[a-zA-Z0-9_]*$";

		public const string ValidTitleRegex = 
			@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\"+"/!@#$%&=_,:;'\"<>~]*$";

		public const string ValidOauthDomainRegexp =
			@"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$";

		public Type DataType { get; private set; }
		public string Name { get; private set; }
		public bool CanSet { get; internal set; }
		public bool CanModify { get; private set; }

		public bool IsUnique { get; internal set; }
		public bool IsNullable { get; internal set; }
		public bool ToLowerCase { get; internal set; }
		public int? LenMin { get; internal set; }
		public int? LenMax { get; internal set; }
		public string ValidRegex { get; internal set; }
		public Type FromEnum { get; internal set; }
		public string SubObjectOf { get; internal set; }
		//TODO: custom validation


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiProperty(string pName, bool pCanSet, bool pCanModify, Type pDataType) {
			Name = pName;
			CanSet = pCanSet;
			CanModify = pCanModify;
			DataType = pDataType;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetDataTypeName() {
			string end = (IsNullable ? "?" : "");

			switch ( DataType.Name ) {
				case "String":
					return "string";

				case "Boolean":
					return "bool"+end;

				case "Byte":
					return "byte"+end;

				case "Int32":
					return "int"+end;

				case "Int64":
					return "long"+end;

				case "Single":
					return "float"+end;

				case "Double":
					return "double"+end;

				default:
					return null;
			}
		}

	}

	/*================================================================================================*/
	public class ApiProperty<T> : ApiProperty {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiProperty(string pName, bool pCanSet, bool pCanModify) :
														base(pName, pCanSet, pCanModify, typeof(T)) {}

	}

}