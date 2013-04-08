using System;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class BaseType<TEnum> : IBaseType where TEnum : struct, IConvertible {

		public byte Id { get; private set; }
		public TEnum EnumId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BaseType(TEnum pEnumId, string pName, string pDesc) {
			EnumId = pEnumId;
			Id = pEnumId.ToByte(null);
			Name = pName;
			Description = pDesc;
		}

	}

}