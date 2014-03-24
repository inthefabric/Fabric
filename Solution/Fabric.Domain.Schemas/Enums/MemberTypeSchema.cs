namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class MemberTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeSchema() : base("MemberType") {
			AddItem(1, "None", "None", "The User is not associated with this App.");
			AddItem(2, "Request", "Request", "The user would like to become a member of this App.");
			AddItem(3, "Invite", "Invite", "The User has been invited to become a member of this App.");
			AddItem(4, "Member", "Member", "The User is a member of this App.");
			AddItem(5, "Staff", "Staff", "The User is a staff member of this App.");
			AddItem(6, "Admin", "Admin", "The User is an administrator of this App.");
			AddItem(7, "Owner", "Owner", "The User owns this App.");
			AddItem(8, "DataProv", "Data Provider", "The User has a special membership that allows it to interact with Fabric on behalf of the App.");
		}

	}

}