using System;

namespace Fabric.Domain.Meta.Vertices.Tools {

	/*================================================================================================*/
	public class ApiProperty<T> {

		public string Name { get; private set; }
		public bool CanSet { get; internal set; }
		public bool CanModify { get; private set; }

		public bool IsUnique { get; internal set; }
		public bool IsNullable { get; internal set; }
		public int? Len { get; internal set; }
		public int? LenMin { get; internal set; }
		public int? LenMax { get; internal set; }
		public int? Min { get; internal set; }
		public int? Max { get; internal set; }
		public string ValidRegex { get; internal set; }
		public Type FromEnum { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiProperty(string pName, bool pCanSet, bool pCanModify) {
			Name = pName;
			CanSet = pCanSet;
			CanModify = pCanModify;
		}

	}

}