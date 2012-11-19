using Weaver;

namespace Fabric.Domain {

	/*================================================================================================*/
	public class FabricQuery : WeaverQuery {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabricQuery() : base(new Root()) {
			/*
			 
			>>> Get all App 99 users that have a MemberTypeId > 2:
			
			var x = Root
				.OutHasApps.ToApp
					.Has<App>(a => a.AppId, WeaverFuncHasOp.EqualTo, 99)
				.InMembersUses.FromMember
					.As<Member>("m")
				.OutHasMemberTypeAssign.ToMemberTypeAssign
				.OutUsesMemberType.ToMemberType
					.Has<MemberType>(mt => mt.MemberTypeId, WeaverFuncHasOp.GreaterThan, 2)
					.Back<Member>("m")
				.OutUsesUser.ToUser;
			
			>>> Possible API path:
			
			/OutHasApps/Where(AppId;EqualTo;99)/InMembersUse/As(m)/OutHasMemberTypeAssign ...
				...	/OutUsesMemberType/Where(MemberTypeId|GreaterThan|2)/Back(m)/OutUsesUser
			
			*/
		}

		/*--------------------------------------------------------------------------------------------*/
		public Root Root { get { return (Root)BaseNode; } }

	}

}