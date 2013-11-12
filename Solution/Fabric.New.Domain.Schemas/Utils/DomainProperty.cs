using System;

namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class DomainProperty {

		public Type DataType { get; private set; }
		public string Name { get; private set; }
		public string DbName { get; private set; }

		public bool IsUnique { get; internal set; }
		public bool IsNullable { get; internal set; }
		public bool ToLowerCase { get; internal set; }
		public bool IsIndexed { get; internal set; }
		public bool IsElastic { get; internal set; }
		public DomainProperty ExactIndexVia { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DomainProperty(string pName, string pDbName, Type pDataType) {
			Name = pName;
			DbName = pDbName;
			DataType = pDataType;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetCapitalizedDataTypeName() {
			string name = GetDataTypeName();

			if ( name == null ) {
				return null;
			}

			name = name.Trim(new[] { '?' });

			return (IsNullable && name != "string" ? "Nullable" : "")+
				name.Substring(0, 1).ToUpper()+name.Substring(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool DataTypeNameHasQuestionMark() {
			string name = GetDataTypeName();
			return (name.Substring(name.Length-1, 1) == "?");
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetDataTypeName() {
			return GetDataTypeName(DataType, IsNullable);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDataTypeName(Type pType, bool pNullable=false) {
			string end = (pNullable ? "?" : "");

			switch ( pType.Name ) {
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
					return pType.Name;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetTitanTypeName() {
			switch ( DataType.Name ) {
				case "Boolean":
					return "Boolean";

				case "Byte":
					return "Byte";

				case "Int32":
					return "Integer";

				case "Int64":
				case "DateTime":
					return "Long";

				case "Single":
					return "Float";

				case "Double":
					return "Double";

				default:
					return DataType.Name;
			}
		}

	}


	/*================================================================================================*/
	public class DomainProperty<T> : DomainProperty {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DomainProperty(string pName, string pDbName) : base(pName, pDbName, typeof(T)) {}

	}

}