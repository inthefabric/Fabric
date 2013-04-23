namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class MemberType : BaseType<MemberTypeId> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberType(MemberTypeId pEnumId, string pName, string pDesc) :
																		base(pEnumId, pName, pDesc) {}

	}

}