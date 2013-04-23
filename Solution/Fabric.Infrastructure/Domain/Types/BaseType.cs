using System;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class BaseType : IBaseType {

		public byte Id { get; private set; }
		public string EnumId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BaseType(byte pId, string pEnumId, string pName, string pDesc) {
			Id = pId;
			EnumId = pEnumId;
			Name = pName;
			Description = pDesc;
		}

	}

	/*================================================================================================*/
	public class BaseType<TEnum> : BaseType where TEnum : struct, IConvertible {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BaseType(TEnum pEnumId, string pName, string pDesc) :
												base(pEnumId.ToByte(null), pEnumId+"", pName, pDesc) {}

	}

}