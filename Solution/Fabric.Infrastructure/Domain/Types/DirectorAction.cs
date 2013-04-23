namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class DirectorAction : BaseType<DirectorActionId> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorAction(DirectorActionId pEnumId, string pName, string pDesc) :
																		base(pEnumId, pName, pDesc) {}

	}

}