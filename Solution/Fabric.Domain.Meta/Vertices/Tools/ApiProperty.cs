using System;

namespace Fabric.Domain.Meta.Vertices.Tools {

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
		public int? Len { get; internal set; }
		public int? LenMin { get; internal set; }
		public int? LenMax { get; internal set; }
		public int? Min { get; internal set; }
		public int? Max { get; internal set; }
		public string ValidRegex { get; internal set; }
		public Type FromEnum { get; internal set; }
		public string SubObjectOf { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiProperty(string pName, bool pCanSet, bool pCanModify, Type pDataType) {
			Name = pName;
			CanSet = pCanSet;
			CanModify = pCanModify;
			DataType = pDataType;
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