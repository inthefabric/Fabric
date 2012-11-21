using Weaver;

namespace Fabric.Domain {

	/*================================================================================================*/
	public class FabricQuery : WeaverPath<Root> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabricQuery() : base(new Root()) {
			/*
			 
			>>> Get all App 99 users that have a MemberTypeId > 2:
			
			var x = Root
				.OutContainsApps.ToApp
					.Has<App>(a => a.AppId, WeaverFuncHasOp.EqualTo, 99)
				.InMembersUses.FromMember
					.As<Member>("m")
				.OutHasMemberTypeAssign.ToMemberTypeAssign
				.OutUsesMemberType.ToMemberType
					.Has<MemberType>(mt => mt.MemberTypeId, WeaverFuncHasOp.GreaterThan, 2)
					.Back<Member>("m")
				.OutUsesUser.ToUser;
			
			>>> Possible API path:
			
			/OutContainsApps/Has(AppId,EqualTo,99)/InMembersUse/As(m)/OutHasMemberTypeAssign ...
				...	/OutUsesMemberType/Has(MemberTypeId,GreaterThan,2)/Back(m)/OutUsesUser
			
			/ContainsApps/Has(AppId,EQ,99)/MembersUse/As(m)/HasMemberTypeAssign ...
				...	/UsesMemberType/Has(MemberTypeId,GT,2)/Back(m)/UsesUser
			
			*/
		}

		/*--------------------------------------------------------------------------------------------*/
		public Root Root { get { return BaseNode; } }

	}

}