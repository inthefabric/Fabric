// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/16/2013 11:55:44 PM

using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Weaver {

	// ReSharper disable InconsistentNaming

	/*================================================================================================*/
	public static class NodeDbName {

		public const string Node = "N";
		public const string NodeForAction = "NA";
		public const string Artifact = "A";
		public const string App = "Ap";
		public const string Class = "Cl";
		public const string Email = "E";
		public const string Instance = "In";
		public const string Member = "M";
		public const string MemberTypeAssign = "MTA";
		public const string Url = "Ur";
		public const string User = "U";
		public const string Factor = "F";
		public const string OauthAccess = "OA";
		public const string OauthDomain = "OD";
		public const string OauthGrant = "OG";
		public const string OauthScope = "OS";

		public static IDictionary<Type, string> TypeMap;
		public static IDictionary<string, string> NameMap;
		private static readonly bool IsInit = Init();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool Init() {
			TypeMap = new Dictionary<Type, string>();
			NameMap = new Dictionary<string, string>();
			
			TypeMap.Add(typeof(Node), Node);
			NameMap.Add("Node", Node);

			TypeMap.Add(typeof(NodeForAction), NodeForAction);
			NameMap.Add("NodeForAction", NodeForAction);

			TypeMap.Add(typeof(Artifact), Artifact);
			NameMap.Add("Artifact", Artifact);

			TypeMap.Add(typeof(App), App);
			NameMap.Add("App", App);

			TypeMap.Add(typeof(Class), Class);
			NameMap.Add("Class", Class);

			TypeMap.Add(typeof(Email), Email);
			NameMap.Add("Email", Email);

			TypeMap.Add(typeof(Instance), Instance);
			NameMap.Add("Instance", Instance);

			TypeMap.Add(typeof(Member), Member);
			NameMap.Add("Member", Member);

			TypeMap.Add(typeof(MemberTypeAssign), MemberTypeAssign);
			NameMap.Add("MemberTypeAssign", MemberTypeAssign);

			TypeMap.Add(typeof(Url), Url);
			NameMap.Add("Url", Url);

			TypeMap.Add(typeof(User), User);
			NameMap.Add("User", User);

			TypeMap.Add(typeof(Factor), Factor);
			NameMap.Add("Factor", Factor);

			TypeMap.Add(typeof(OauthAccess), OauthAccess);
			NameMap.Add("OauthAccess", OauthAccess);

			TypeMap.Add(typeof(OauthDomain), OauthDomain);
			NameMap.Add("OauthDomain", OauthDomain);

			TypeMap.Add(typeof(OauthGrant), OauthGrant);
			NameMap.Add("OauthGrant", OauthGrant);

			TypeMap.Add(typeof(OauthScope), OauthScope);
			NameMap.Add("OauthScope", OauthScope);

			return true;
		}

	}


	/*================================================================================================*/
	public static class PropDbName {

		public const string Node_FabType = "N_FT";

		public const string NodeForAction_Performed = "NA_Pe";
		public const string NodeForAction_Note = "NA_No";

		public const string Artifact_ArtifactId = "A_AId";
		public const string Artifact_Created = "A_Cr";

		public const string App_AppId = "Ap_Id";
		public const string App_Name = "Ap_Na";
		public const string App_Secret = "Ap_Se";

		public const string Class_ClassId = "Cl_Id";
		public const string Class_Name = "Cl_Na";
		public const string Class_Disamb = "Cl_Di";
		public const string Class_Note = "Cl_No";

		public const string Email_EmailId = "E_Id";
		public const string Email_Address = "E_Ad";
		public const string Email_Code = "E_Co";
		public const string Email_Created = "E_Cr";
		public const string Email_Verified = "E_Ve";

		public const string Instance_InstanceId = "In_Id";
		public const string Instance_Name = "In_Na";
		public const string Instance_Disamb = "In_Di";
		public const string Instance_Note = "In_No";

		public const string Member_MemberId = "M_Id";

		public const string MemberTypeAssign_MemberTypeAssignId = "MTA_Id";
		public const string MemberTypeAssign_MemberTypeId = "MTA_Mt";

		public const string Url_UrlId = "Ur_Id";
		public const string Url_Name = "Ur_Na";
		public const string Url_AbsoluteUrl = "Ur_Ab";

		public const string User_UserId = "U_Id";
		public const string User_Name = "U_Na";
		public const string User_Password = "U_Pa";

		public const string Factor_FactorId = "F_Id";
		public const string Factor_FactorAssertionId = "F_Fa";
		public const string Factor_IsDefining = "F_Df";
		public const string Factor_Created = "F_Cr";
		public const string Factor_Deleted = "F_Dl";
		public const string Factor_Completed = "F_Co";
		public const string Factor_Note = "F_No";
		public const string Factor_Descriptor_TypeId = "F_DeT";
		public const string Factor_Director_TypeId = "F_DiT";
		public const string Factor_Director_PrimaryActionId = "F_DiP";
		public const string Factor_Director_RelatedActionId = "F_DiR";
		public const string Factor_Eventor_TypeId = "F_EvT";
		public const string Factor_Eventor_PrecisionId = "F_EvP";
		public const string Factor_Eventor_DateTime = "F_EvD";
		public const string Factor_Identor_TypeId = "F_IdT";
		public const string Factor_Identor_Value = "F_IdV";
		public const string Factor_Locator_TypeId = "F_LoT";
		public const string Factor_Locator_ValueX = "F_LoX";
		public const string Factor_Locator_ValueY = "F_LoY";
		public const string Factor_Locator_ValueZ = "F_LoZ";
		public const string Factor_Vector_TypeId = "F_VeT";
		public const string Factor_Vector_UnitId = "F_VeU";
		public const string Factor_Vector_UnitPrefixId = "F_VeP";
		public const string Factor_Vector_Value = "F_VeV";

		public const string OauthAccess_OauthAccessId = "OA_Id";
		public const string OauthAccess_Token = "OA_To";
		public const string OauthAccess_Refresh = "OA_Re";
		public const string OauthAccess_Expires = "OA_Ex";
		public const string OauthAccess_IsClientOnly = "OA_CO";

		public const string OauthDomain_OauthDomainId = "OD_Id";
		public const string OauthDomain_Domain = "OD_Do";

		public const string OauthGrant_OauthGrantId = "OG_Id";
		public const string OauthGrant_RedirectUri = "OG_Re";
		public const string OauthGrant_Code = "OG_Co";
		public const string OauthGrant_Expires = "OG_Ex";

		public const string OauthScope_OauthScopeId = "OS_Id";
		public const string OauthScope_Allow = "OS_Al";
		public const string OauthScope_Created = "OS_Cr";


		public static IDictionary<Type, string> TypeIdMap;
		public static IDictionary<string, string> StrTypeIdMap;
		private static readonly bool IsInit = Init();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool Init() {
			TypeIdMap = new Dictionary<Type, string>();
			StrTypeIdMap = new Dictionary<string, string>();
			
			TypeIdMap.Add(typeof(Artifact), Artifact_ArtifactId);
			StrTypeIdMap.Add("Artifact", Artifact_ArtifactId);

			TypeIdMap.Add(typeof(App), App_AppId);
			StrTypeIdMap.Add("App", App_AppId);

			TypeIdMap.Add(typeof(Class), Class_ClassId);
			StrTypeIdMap.Add("Class", Class_ClassId);

			TypeIdMap.Add(typeof(Email), Email_EmailId);
			StrTypeIdMap.Add("Email", Email_EmailId);

			TypeIdMap.Add(typeof(Instance), Instance_InstanceId);
			StrTypeIdMap.Add("Instance", Instance_InstanceId);

			TypeIdMap.Add(typeof(Member), Member_MemberId);
			StrTypeIdMap.Add("Member", Member_MemberId);

			TypeIdMap.Add(typeof(MemberTypeAssign), MemberTypeAssign_MemberTypeAssignId);
			StrTypeIdMap.Add("MemberTypeAssign", MemberTypeAssign_MemberTypeAssignId);

			TypeIdMap.Add(typeof(Url), Url_UrlId);
			StrTypeIdMap.Add("Url", Url_UrlId);

			TypeIdMap.Add(typeof(User), User_UserId);
			StrTypeIdMap.Add("User", User_UserId);

			TypeIdMap.Add(typeof(Factor), Factor_FactorId);
			StrTypeIdMap.Add("Factor", Factor_FactorId);

			TypeIdMap.Add(typeof(OauthAccess), OauthAccess_OauthAccessId);
			StrTypeIdMap.Add("OauthAccess", OauthAccess_OauthAccessId);

			TypeIdMap.Add(typeof(OauthDomain), OauthDomain_OauthDomainId);
			StrTypeIdMap.Add("OauthDomain", OauthDomain_OauthDomainId);

			TypeIdMap.Add(typeof(OauthGrant), OauthGrant_OauthGrantId);
			StrTypeIdMap.Add("OauthGrant", OauthGrant_OauthGrantId);

			TypeIdMap.Add(typeof(OauthScope), OauthScope_OauthScopeId);
			StrTypeIdMap.Add("OauthScope", OauthScope_OauthScopeId);

			return true;
		}

	}


	/*================================================================================================*/
	public static class RelDbName {

		public const string AppUsesEmail = "Ap-U-E";
		public const string AppDefinesMember = "Ap-D-M";
		public const string MemberHasMemberTypeAssign = "M-H-MTA";
		public const string MemberHasHistoricMemberTypeAssign = "M-HH-MTA";
		public const string MemberCreatesArtifact = "M-C-A";
		public const string MemberCreatesMemberTypeAssign = "M-C-MTA";
		public const string MemberCreatesFactor = "M-C-F";
		public const string UserUsesEmail = "U-U-E";
		public const string UserDefinesMember = "U-D-M";
		public const string FactorUsesPrimaryArtifact = "F-UP-A";
		public const string FactorUsesRelatedArtifact = "F-UR-A";
		public const string FactorDescriptorRefinesPrimaryWithArtifact = "F-DRP-A";
		public const string FactorDescriptorRefinesRelatedWithArtifact = "F-DRR-A";
		public const string FactorDescriptorRefinesTypeWithArtifact = "F-DRT-A";
		public const string FactorVectorUsesAxisArtifact = "F-VUA-A";
		public const string OauthAccessUsesApp = "OA-U-Ap";
		public const string OauthAccessUsesUser = "OA-U-U";
		public const string OauthDomainUsesApp = "OD-U-Ap";
		public const string OauthGrantUsesApp = "OG-U-Ap";
		public const string OauthGrantUsesUser = "OG-U-U";
		public const string OauthScopeUsesApp = "OS-U-Ap";
		public const string OauthScopeUsesUser = "OS-U-U";

		public static IDictionary<Type, string> TypeMap;
		private static readonly bool IsInit = Init();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool Init() {
			TypeMap = new Dictionary<Type, string>();
			
			TypeMap.Add(typeof(AppUsesEmail), AppUsesEmail);
			TypeMap.Add(typeof(AppDefinesMember), AppDefinesMember);
			TypeMap.Add(typeof(MemberHasMemberTypeAssign), MemberHasMemberTypeAssign);
			TypeMap.Add(typeof(MemberHasHistoricMemberTypeAssign), MemberHasHistoricMemberTypeAssign);
			TypeMap.Add(typeof(MemberCreatesArtifact), MemberCreatesArtifact);
			TypeMap.Add(typeof(MemberCreatesMemberTypeAssign), MemberCreatesMemberTypeAssign);
			TypeMap.Add(typeof(MemberCreatesFactor), MemberCreatesFactor);
			TypeMap.Add(typeof(UserUsesEmail), UserUsesEmail);
			TypeMap.Add(typeof(UserDefinesMember), UserDefinesMember);
			TypeMap.Add(typeof(FactorUsesPrimaryArtifact), FactorUsesPrimaryArtifact);
			TypeMap.Add(typeof(FactorUsesRelatedArtifact), FactorUsesRelatedArtifact);
			TypeMap.Add(typeof(FactorDescriptorRefinesPrimaryWithArtifact), FactorDescriptorRefinesPrimaryWithArtifact);
			TypeMap.Add(typeof(FactorDescriptorRefinesRelatedWithArtifact), FactorDescriptorRefinesRelatedWithArtifact);
			TypeMap.Add(typeof(FactorDescriptorRefinesTypeWithArtifact), FactorDescriptorRefinesTypeWithArtifact);
			TypeMap.Add(typeof(FactorVectorUsesAxisArtifact), FactorVectorUsesAxisArtifact);
			TypeMap.Add(typeof(OauthAccessUsesApp), OauthAccessUsesApp);
			TypeMap.Add(typeof(OauthAccessUsesUser), OauthAccessUsesUser);
			TypeMap.Add(typeof(OauthDomainUsesApp), OauthDomainUsesApp);
			TypeMap.Add(typeof(OauthGrantUsesApp), OauthGrantUsesApp);
			TypeMap.Add(typeof(OauthGrantUsesUser), OauthGrantUsesUser);
			TypeMap.Add(typeof(OauthScopeUsesApp), OauthScopeUsesApp);
			TypeMap.Add(typeof(OauthScopeUsesUser), OauthScopeUsesUser);

			return true;
		}

	}

	// ReSharper restore InconsistentNaming

}
