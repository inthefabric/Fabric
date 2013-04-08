namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class EventorType : BaseType<EventorTypeId> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorType(EventorTypeId pEnumId, string pName, string pDesc) :
																		base(pEnumId, pName, pDesc) {}

	}

}