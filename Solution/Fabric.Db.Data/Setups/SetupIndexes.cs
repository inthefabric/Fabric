// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/7/2013 11:54:55 PM

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static partial class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {

			//VERTICES

			//Node
			pSet.AddIndexQuery(BuildGroup("N", 2));
			pSet.AddIndexQuery(BuildKey("N", "N_FT", "Integer", true));

			//NodeForAction
			pSet.AddIndexQuery(BuildGroup("NA", 3));
			pSet.AddIndexQuery(BuildKey("NA", "NA_Pe", "Long", false));
			pSet.AddIndexQuery(BuildKey("NA", "NA_No", "String", false));

			//Artifact
			pSet.AddIndexQuery(BuildGroup("A", 4));
			pSet.AddIndexQuery(BuildKey("A", "A_AId", "Long", true));
			pSet.AddIndexQuery(BuildKey("A", "A_Cr", "Long", false));

			//App
			pSet.AddIndexQuery(BuildGroup("Ap", 5));
			pSet.AddIndexQuery(BuildKey("Ap", "Ap_Na", "String", false));
			pSet.AddIndexQuery(BuildKey("Ap", "Ap_Se", "String", false));

			//Class
			pSet.AddIndexQuery(BuildGroup("Cl", 6));
			pSet.AddIndexQuery(BuildKey("Cl", "Cl_Na", "String", false));
			pSet.AddIndexQuery(BuildKey("Cl", "Cl_Di", "String", false));
			pSet.AddIndexQuery(BuildKey("Cl", "Cl_No", "String", false));

			//Email
			pSet.AddIndexQuery(BuildGroup("E", 7));
			pSet.AddIndexQuery(BuildKey("E", "E_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("E", "E_Ad", "String", false));
			pSet.AddIndexQuery(BuildKey("E", "E_Co", "String", false));
			pSet.AddIndexQuery(BuildKey("E", "E_Cr", "Long", false));
			pSet.AddIndexQuery(BuildKey("E", "E_Ve", "Long", false));

			//Instance
			pSet.AddIndexQuery(BuildGroup("In", 8));
			pSet.AddIndexQuery(BuildKey("In", "In_Na", "String", false));
			pSet.AddIndexQuery(BuildKey("In", "In_Di", "String", false));
			pSet.AddIndexQuery(BuildKey("In", "In_No", "String", false));

			//Member
			pSet.AddIndexQuery(BuildGroup("M", 9));
			pSet.AddIndexQuery(BuildKey("M", "M_Id", "Long", true));

			//MemberTypeAssign
			pSet.AddIndexQuery(BuildGroup("MTA", 10));
			pSet.AddIndexQuery(BuildKey("MTA", "MTA_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("MTA", "MTA_Mt", "Byte", true));

			//Url
			pSet.AddIndexQuery(BuildGroup("Ur", 11));
			pSet.AddIndexQuery(BuildKey("Ur", "Ur_Na", "String", false));
			pSet.AddIndexQuery(BuildKey("Ur", "Ur_Ab", "String", false));

			//User
			pSet.AddIndexQuery(BuildGroup("U", 12));
			pSet.AddIndexQuery(BuildKey("U", "U_Na", "String", false));
			pSet.AddIndexQuery(BuildKey("U", "U_Pa", "String", false));

			//Factor
			pSet.AddIndexQuery(BuildGroup("F", 13));
			pSet.AddIndexQuery(BuildKey("F", "F_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("F", "F_Fa", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_Df", "Boolean", false));
			pSet.AddIndexQuery(BuildKey("F", "F_Cr", "Long", false));
			pSet.AddIndexQuery(BuildKey("F", "F_Dl", "Long", false));
			pSet.AddIndexQuery(BuildKey("F", "F_Co", "Long", false));
			pSet.AddIndexQuery(BuildKey("F", "F_No", "String", false));
			pSet.AddIndexQuery(BuildKey("F", "F_DeT", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_DiT", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_DiP", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_DiR", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_EvT", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_EvP", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_EvD", "Long", false));
			pSet.AddIndexQuery(BuildKey("F", "F_IdT", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_IdV", "String", false));
			pSet.AddIndexQuery(BuildKey("F", "F_LoT", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_LoX", "Double", false));
			pSet.AddIndexQuery(BuildKey("F", "F_LoY", "Double", false));
			pSet.AddIndexQuery(BuildKey("F", "F_LoZ", "Double", false));
			pSet.AddIndexQuery(BuildKey("F", "F_VeT", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_VeU", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_VeP", "Byte", true));
			pSet.AddIndexQuery(BuildKey("F", "F_VeV", "Long", false));

			//OauthAccess
			pSet.AddIndexQuery(BuildGroup("OA", 14));
			pSet.AddIndexQuery(BuildKey("OA", "OA_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("OA", "OA_To", "String", false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_Re", "String", false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_Ex", "Long", false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_CO", "Boolean", false));

			//OauthDomain
			pSet.AddIndexQuery(BuildGroup("OD", 15));
			pSet.AddIndexQuery(BuildKey("OD", "OD_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("OD", "OD_Do", "String", false));

			//OauthGrant
			pSet.AddIndexQuery(BuildGroup("OG", 16));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Re", "String", false));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Co", "String", false));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Ex", "Long", false));

			//OauthScope
			pSet.AddIndexQuery(BuildGroup("OS", 17));
			pSet.AddIndexQuery(BuildKey("OS", "OS_Id", "Long", true));
			pSet.AddIndexQuery(BuildKey("OS", "OS_Al", "Boolean", false));
			pSet.AddIndexQuery(BuildKey("OS", "OS_Cr", "Long", false));
	
			//EDGES

			//AppUsesEmail
			pSet.AddIndexQuery(BuildLabel("Ap-U-E", false, true, new [] {
				"Ap_Na",
				"Ap_Se",
				"E_Id",
				"E_Ad",
				"E_Co",
				"E_Cr",
				"E_Ve"
			}));

			//AppDefinesMember
			pSet.AddIndexQuery(BuildLabel("Ap-D-M", true, false, new [] {
				"Ap_Na",
				"Ap_Se",
				"M_Id"
			}));

			//MemberHasMemberTypeAssign
			pSet.AddIndexQuery(BuildLabel("M-H-MTA", true, true, new [] {
				"M_Id",
				"MTA_Id",
				"MTA_Mt"
			}));

			//MemberHasHistoricMemberTypeAssign
			pSet.AddIndexQuery(BuildLabel("M-HH-MTA", true, false, new [] {
				"M_Id",
				"MTA_Id",
				"MTA_Mt"
			}));

			//MemberCreatesArtifact
			pSet.AddIndexQuery(BuildLabel("M-C-A", true, false, new [] {
				"M_Id",
				"A_AId",
				"A_Cr"
			}));

			//MemberCreatesMemberTypeAssign
			pSet.AddIndexQuery(BuildLabel("M-C-MTA", true, false, new [] {
				"M_Id",
				"MTA_Id",
				"MTA_Mt"
			}));

			//MemberCreatesFactor
			pSet.AddIndexQuery(BuildLabel("M-C-F", true, false, new [] {
				"M_Id",
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV"
			}));

			//UserUsesEmail
			pSet.AddIndexQuery(BuildLabel("U-U-E", false, true, new [] {
				"U_Na",
				"U_Pa",
				"E_Id",
				"E_Ad",
				"E_Co",
				"E_Cr",
				"E_Ve"
			}));

			//UserDefinesMember
			pSet.AddIndexQuery(BuildLabel("U-D-M", true, false, new [] {
				"U_Na",
				"U_Pa",
				"M_Id"
			}));

			//FactorUsesPrimaryArtifact
			pSet.AddIndexQuery(BuildLabel("F-UP-A", false, true, new [] {
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV",
				"A_AId",
				"A_Cr"
			}));

			//FactorUsesRelatedArtifact
			pSet.AddIndexQuery(BuildLabel("F-UR-A", false, true, new [] {
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV",
				"A_AId",
				"A_Cr"
			}));

			//FactorDescriptorRefinesPrimaryWithArtifact
			pSet.AddIndexQuery(BuildLabel("F-DRP-A", false, true, new [] {
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV",
				"A_AId",
				"A_Cr"
			}));

			//FactorDescriptorRefinesRelatedWithArtifact
			pSet.AddIndexQuery(BuildLabel("F-DRR-A", false, true, new [] {
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV",
				"A_AId",
				"A_Cr"
			}));

			//FactorDescriptorRefinesTypeWithArtifact
			pSet.AddIndexQuery(BuildLabel("F-DRT-A", false, true, new [] {
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV",
				"A_AId",
				"A_Cr"
			}));

			//FactorVectorUsesAxisArtifact
			pSet.AddIndexQuery(BuildLabel("F-VUA-A", false, true, new [] {
				"F_Id",
				"F_Fa",
				"F_Df",
				"F_Cr",
				"F_Dl",
				"F_Co",
				"F_No",
				"F_DeT",
				"F_DiT",
				"F_DiP",
				"F_DiR",
				"F_EvT",
				"F_EvP",
				"F_EvD",
				"F_IdT",
				"F_IdV",
				"F_LoT",
				"F_LoX",
				"F_LoY",
				"F_LoZ",
				"F_VeT",
				"F_VeU",
				"F_VeP",
				"F_VeV",
				"A_AId",
				"A_Cr"
			}));

			//OauthAccessUsesApp
			pSet.AddIndexQuery(BuildLabel("OA-U-Ap", false, true, new [] {
				"OA_Id",
				"OA_To",
				"OA_Re",
				"OA_Ex",
				"OA_CO",
				"Ap_Na",
				"Ap_Se"
			}));

			//OauthAccessUsesUser
			pSet.AddIndexQuery(BuildLabel("OA-U-U", false, true, new [] {
				"OA_Id",
				"OA_To",
				"OA_Re",
				"OA_Ex",
				"OA_CO",
				"U_Na",
				"U_Pa"
			}));

			//OauthDomainUsesApp
			pSet.AddIndexQuery(BuildLabel("OD-U-Ap", false, true, new [] {
				"OD_Id",
				"OD_Do",
				"Ap_Na",
				"Ap_Se"
			}));

			//OauthGrantUsesApp
			pSet.AddIndexQuery(BuildLabel("OG-U-Ap", false, true, new [] {
				"OG_Id",
				"OG_Re",
				"OG_Co",
				"OG_Ex",
				"Ap_Na",
				"Ap_Se"
			}));

			//OauthGrantUsesUser
			pSet.AddIndexQuery(BuildLabel("OG-U-U", false, true, new [] {
				"OG_Id",
				"OG_Re",
				"OG_Co",
				"OG_Ex",
				"U_Na",
				"U_Pa"
			}));

			//OauthScopeUsesApp
			pSet.AddIndexQuery(BuildLabel("OS-U-Ap", false, true, new [] {
				"OS_Id",
				"OS_Al",
				"OS_Cr",
				"Ap_Na",
				"Ap_Se"
			}));

			//OauthScopeUsesUser
			pSet.AddIndexQuery(BuildLabel("OS-U-U", false, true, new [] {
				"OS_Id",
				"OS_Al",
				"OS_Cr",
				"U_Na",
				"U_Pa"
			}));
		}

	}

}