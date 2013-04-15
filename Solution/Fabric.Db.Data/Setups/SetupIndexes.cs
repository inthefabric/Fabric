// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/15/2013 11:26:45 AM

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static partial class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			pSet.AddIndexQuery(BuildKey("FabType", "FabType", "Integer", true));
			//pSet.AddIndexQuery(BuildKey("Shared", "Name", "String", false));
			//pSet.AddIndexQuery(BuildKey("Shared", "Created", "Long", false));
			//pSet.AddIndexQuery(BuildKey("Shared", "Disamb", "String", false));
			//pSet.AddIndexQuery(BuildKey("Shared", "Note", "String", false));
			//pSet.AddIndexQuery(BuildKey("Shared", "Code", "String", false));
			//pSet.AddIndexQuery(BuildKey("Shared", "Expires", "Long", false));
	
			//Artifact Vertex

			//pSet.AddIndexQuery(BuildGroup("Artifact", 2));
			pSet.AddIndexQuery(BuildKey("Artifact", "ArtifactId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("Artifact", "Created", "Long", false));
	
			//App Vertex

			//pSet.AddIndexQuery(BuildGroup("App", 3));
			pSet.AddIndexQuery(BuildKey("App", "AppId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("App", "Name", "String", false));
			//pSet.AddIndexQuery(BuildKey("App", "Secret", "String", false));
	
			//Class Vertex

			//pSet.AddIndexQuery(BuildGroup("Class", 4));
			pSet.AddIndexQuery(BuildKey("Class", "ClassId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("Class", "Name", "String", false));
			//pSet.AddIndexQuery(BuildKey("Class", "Disamb", "String", false));
			//pSet.AddIndexQuery(BuildKey("Class", "Note", "String", false));
	
			//Email Vertex

			//pSet.AddIndexQuery(BuildGroup("Email", 5));
			pSet.AddIndexQuery(BuildKey("Email", "EmailId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("Email", "Address", "String", false));
			//pSet.AddIndexQuery(BuildKey("Email", "Code", "String", false));
			//pSet.AddIndexQuery(BuildKey("Email", "Created", "Long", false));
			//pSet.AddIndexQuery(BuildKey("Email", "Verified", "Long", false));
	
			//Instance Vertex

			//pSet.AddIndexQuery(BuildGroup("Instance", 6));
			pSet.AddIndexQuery(BuildKey("Instance", "InstanceId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("Instance", "Name", "String", false));
			//pSet.AddIndexQuery(BuildKey("Instance", "Disamb", "String", false));
			//pSet.AddIndexQuery(BuildKey("Instance", "Note", "String", false));
	
			//Member Vertex

			//pSet.AddIndexQuery(BuildGroup("Member", 7));
			pSet.AddIndexQuery(BuildKey("Member", "MemberId", "Long", true));
	
			//MemberTypeAssign Vertex

			//pSet.AddIndexQuery(BuildGroup("MemberTypeAssign", 8));
			pSet.AddIndexQuery(BuildKey("MemberTypeAssign", "MemberTypeAssignId", "Long", true));
			pSet.AddIndexQuery(BuildKey("MemberTypeAssign", "MemberTypeId", "Integer", true));
	
			//Url Vertex

			//pSet.AddIndexQuery(BuildGroup("Url", 9));
			pSet.AddIndexQuery(BuildKey("Url", "UrlId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("Url", "Name", "String", false));
			//pSet.AddIndexQuery(BuildKey("Url", "AbsoluteUrl", "String", false));
	
			//User Vertex

			//pSet.AddIndexQuery(BuildGroup("User", 10));
			pSet.AddIndexQuery(BuildKey("User", "UserId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("User", "Name", "String", false));
			//pSet.AddIndexQuery(BuildKey("User", "Password", "String", false));
	
			//Factor Vertex

			//pSet.AddIndexQuery(BuildGroup("Factor", 11));
			pSet.AddIndexQuery(BuildKey("Factor", "FactorId", "Long", true));
			pSet.AddIndexQuery(BuildKey("Factor", "FactorAssertionId", "Integer", true));
			//pSet.AddIndexQuery(BuildKey("Factor", "IsDefining", "Boolean", false));
			//pSet.AddIndexQuery(BuildKey("Factor", "Created", "Long", false));
			//pSet.AddIndexQuery(BuildKey("Factor", "Deleted", "Long", false));
			//pSet.AddIndexQuery(BuildKey("Factor", "Completed", "Long", false));
			//pSet.AddIndexQuery(BuildKey("Factor", "Note", "String", false));
			pSet.AddIndexQuery(BuildKey("Factor", "Descriptor_TypeId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Director_TypeId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Director_PrimaryActionId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Director_RelatedActionId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Eventor_TypeId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Eventor_PrecisionId", "Integer", true));
			//pSet.AddIndexQuery(BuildKey("Factor", "Eventor_DateTime", "Long", false));
			pSet.AddIndexQuery(BuildKey("Factor", "Identor_TypeId", "Integer", true));
			//pSet.AddIndexQuery(BuildKey("Factor", "Identor_Value", "String", false));
			pSet.AddIndexQuery(BuildKey("Factor", "Locator_TypeId", "Integer", true));
			//pSet.AddIndexQuery(BuildKey("Factor", "Locator_ValueX", "Double", false));
			//pSet.AddIndexQuery(BuildKey("Factor", "Locator_ValueY", "Double", false));
			//pSet.AddIndexQuery(BuildKey("Factor", "Locator_ValueZ", "Double", false));
			pSet.AddIndexQuery(BuildKey("Factor", "Vector_TypeId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Vector_UnitId", "Integer", true));
			pSet.AddIndexQuery(BuildKey("Factor", "Vector_UnitPrefixId", "Integer", true));
			//pSet.AddIndexQuery(BuildKey("Factor", "Vector_Value", "Long", false));
	
			//OauthAccess Vertex

			//pSet.AddIndexQuery(BuildGroup("OauthAccess", 12));
			pSet.AddIndexQuery(BuildKey("OauthAccess", "OauthAccessId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("OauthAccess", "Token", "String", false));
			//pSet.AddIndexQuery(BuildKey("OauthAccess", "Refresh", "String", false));
			//pSet.AddIndexQuery(BuildKey("OauthAccess", "Expires", "Long", false));
			//pSet.AddIndexQuery(BuildKey("OauthAccess", "IsClientOnly", "Boolean", false));
	
			//OauthDomain Vertex

			//pSet.AddIndexQuery(BuildGroup("OauthDomain", 13));
			pSet.AddIndexQuery(BuildKey("OauthDomain", "OauthDomainId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("OauthDomain", "Domain", "String", false));
	
			//OauthGrant Vertex

			//pSet.AddIndexQuery(BuildGroup("OauthGrant", 14));
			pSet.AddIndexQuery(BuildKey("OauthGrant", "OauthGrantId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("OauthGrant", "RedirectUri", "String", false));
			//pSet.AddIndexQuery(BuildKey("OauthGrant", "Code", "String", false));
			//pSet.AddIndexQuery(BuildKey("OauthGrant", "Expires", "Long", false));
	
			//OauthScope Vertex

			//pSet.AddIndexQuery(BuildGroup("OauthScope", 15));
			pSet.AddIndexQuery(BuildKey("OauthScope", "OauthScopeId", "Long", true));
			//pSet.AddIndexQuery(BuildKey("OauthScope", "Allow", "Boolean", false));
			//pSet.AddIndexQuery(BuildKey("OauthScope", "Created", "Long", false));
	
			//Edges

			pSet.AddIndexQuery(BuildLabel("AppUsesEmail", false, true,
				new [] {
					"App_AppId",
					"Email_EmailId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("AppDefinesMember", true, false,
				new [] {
					"App_AppId",
					"Member_MemberId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("MemberHasMemberTypeAssign", true, true,
				new [] {
					"Member_MemberId",
					"MemberTypeAssign_MemberTypeAssignId",
					"MemberTypeAssign_MemberTypeId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("MemberHasHistoricMemberTypeAssign", true, false,
				new [] {
					"Member_MemberId",
					"MemberTypeAssign_MemberTypeAssignId",
					"MemberTypeAssign_MemberTypeId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("MemberCreatesArtifact", true, false,
				new [] {
					"Member_MemberId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("MemberCreatesMemberTypeAssign", true, false,
				new [] {
					"Member_MemberId",
					"MemberTypeAssign_MemberTypeAssignId",
					"MemberTypeAssign_MemberTypeId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("MemberCreatesFactor", true, false,
				new [] {
					"Member_MemberId",
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("UserUsesEmail", false, true,
				new [] {
					"User_UserId",
					"Email_EmailId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("UserDefinesMember", true, false,
				new [] {
					"User_UserId",
					"Member_MemberId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("FactorUsesPrimaryArtifact", false, true,
				new [] {
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("FactorUsesRelatedArtifact", false, true,
				new [] {
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("FactorDescriptorRefinesPrimaryWithArtifact", false, true,
				new [] {
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("FactorDescriptorRefinesRelatedWithArtifact", false, true,
				new [] {
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("FactorDescriptorRefinesTypeWithArtifact", false, true,
				new [] {
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("FactorVectorUsesAxisArtifact", false, true,
				new [] {
					"Factor_FactorId",
					"Factor_FactorAssertionId",
					"Factor_Descriptor_TypeId",
					"Factor_Director_TypeId",
					"Factor_Director_PrimaryActionId",
					"Factor_Director_RelatedActionId",
					"Factor_Eventor_TypeId",
					"Factor_Eventor_PrecisionId",
					"Factor_Identor_TypeId",
					"Factor_Locator_TypeId",
					"Factor_Vector_TypeId",
					"Factor_Vector_UnitId",
					"Factor_Vector_UnitPrefixId",
					"Artifact_ArtifactId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthAccessUsesApp", false, true,
				new [] {
					"OauthAccess_OauthAccessId",
					"App_AppId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthAccessUsesUser", false, true,
				new [] {
					"OauthAccess_OauthAccessId",
					"User_UserId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthDomainUsesApp", false, true,
				new [] {
					"OauthDomain_OauthDomainId",
					"App_AppId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthGrantUsesApp", false, true,
				new [] {
					"OauthGrant_OauthGrantId",
					"App_AppId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthGrantUsesUser", false, true,
				new [] {
					"OauthGrant_OauthGrantId",
					"User_UserId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthScopeUsesApp", false, true,
				new [] {
					"OauthScope_OauthScopeId",
					"App_AppId"
				}
			));

			pSet.AddIndexQuery(BuildLabel("OauthScopeUsesUser", false, true,
				new [] {
					"OauthScope_OauthScopeId",
					"User_UserId"
				}
			));
		}

	}

}