using System;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class BaseType<TEnum> where TEnum : struct, IComparable, IFormattable, IConvertible {

		public TEnum EnumId { get; private set; }
		public byte ByteId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BaseType(TEnum pEnumId, string pName, string pDesc) {
			EnumId = pEnumId;
			ByteId = (byte)(object)pEnumId;
			Name = pName;
			Description = pDesc;
		}

	}

}