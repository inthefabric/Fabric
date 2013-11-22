using System;

namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class ApiProperty {

		public const string ValidEmailRegex = @"^(([^<>()[\]\\.,;:\s@\""]+" 
			+ @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@" 
			+ @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}" 
			+ @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+" 
			+ @"[a-zA-Z]{2,}))$";

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

		public Access GetAccess { get; internal set; }
		public Access CreateAccess { get; internal set; }
		public Access ModifyAccess { get; internal set; }

		public bool IsUnique { get; internal set; }
		public bool IsNullable { get; internal set; }
		public bool ToLowerCase { get; internal set; }
		public long? Min { get; internal set; }
		public long? Max { get; internal set; }
		public int? LenMin { get; internal set; }
		public int? LenMax { get; internal set; }
		public string ValidRegex { get; internal set; }
		public string FromEnum { get; internal set; }
		public string SubObjectOf { get; internal set; }
		public bool CustomValidation { get; internal set; }
		public Matching TraversalEntry { get; internal set; }
		public Matching TraversalHas { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiProperty(string pName, Type pDataType) {
			Name = pName;
			GetAccess = Access.Internal;
			CreateAccess = Access.Internal;
			ModifyAccess = Access.Internal;
			DataType = pDataType;
			TraversalEntry = Matching.Implicit;
			TraversalHas = Matching.Implicit;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		internal void SetOpenAccess() {
			GetAccess = Access.All;
			CreateAccess = Access.All;
			ModifyAccess = Access.CreatorUserAndApp;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal void SetOpenUnmodAccess() {
			GetAccess = Access.All;
			CreateAccess = Access.All;
			ModifyAccess = Access.None;
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

		/*--------------------------------------------------------------------------------------------*/
		public bool IsTraversalHasExact() {
			if ( TraversalHas == Matching.Exact ) {
				return true;
			}

			if ( TraversalHas != Matching.Implicit ) {
				return false;
			}

			return (FromEnum != null || DataType == typeof(string) || DataType == typeof(bool));
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool IsSpecInternal(Access pLevel) {
			return (pLevel == Access.None || pLevel == Access.Internal);
		}

	}

	/*================================================================================================*/
	public class ApiProperty<T> : ApiProperty {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiProperty(string pName) : base(pName, typeof(T)) {}

	}

}