using System;

namespace Fabric.Domain.Meta.Vertices.Tools {

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

			return (IsNullable && name != "string" ? "Nullable" : "")+
				name.Substring(0, 1).ToUpper()+name.Substring(1);
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