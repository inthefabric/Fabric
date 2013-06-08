// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/8/2013 2:11:06 PM

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static partial class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {

			//VERTICES

			//Node
			pSet.AddIndexQuery(BuildGroup("N", 2));
			pSet.AddIndexQuery(BuildKey("N", "N_FT", "Byte", false, false));

			//NodeForAction
			pSet.AddIndexQuery(BuildGroup("NA", 3));
			pSet.AddIndexQuery(BuildKey("NA", "NA_Pe", "Long", false, false));
			pSet.AddIndexQuery(BuildKey("NA", "NA_No", "String", false, false));

			//Artifact
			pSet.AddIndexQuery(BuildGroup("A", 4));
			pSet.AddIndexQuery(BuildKey("A", "A_AId", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("A", "A_Cr", "Long", false, true));

			//App
			pSet.AddIndexQuery(BuildGroup("Ap", 5));
			pSet.AddIndexQuery(BuildKey("Ap", "Ap_Na", "String", false, true));
			pSet.AddIndexQuery(BuildKey("Ap", "Ap_Se", "String", false, false));

			//Class
			pSet.AddIndexQuery(BuildGroup("Cl", 6));
			pSet.AddIndexQuery(BuildKey("Cl", "Cl_Na", "String", false, true));
			pSet.AddIndexQuery(BuildKey("Cl", "Cl_Di", "String", false, true));
			pSet.AddIndexQuery(BuildKey("Cl", "Cl_No", "String", false, false));

			//Email
			pSet.AddIndexQuery(BuildGroup("E", 7));
			pSet.AddIndexQuery(BuildKey("E", "E_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("E", "E_Ad", "String", false, false));
			pSet.AddIndexQuery(BuildKey("E", "E_Co", "String", false, false));
			pSet.AddIndexQuery(BuildKey("E", "E_Cr", "Long", false, false));
			pSet.AddIndexQuery(BuildKey("E", "E_Ve", "Long", false, false));

			//Instance
			pSet.AddIndexQuery(BuildGroup("In", 8));
			pSet.AddIndexQuery(BuildKey("In", "In_Na", "String", false, true));
			pSet.AddIndexQuery(BuildKey("In", "In_Di", "String", false, true));
			pSet.AddIndexQuery(BuildKey("In", "In_No", "String", false, false));

			//Member
			pSet.AddIndexQuery(BuildGroup("M", 9));
			pSet.AddIndexQuery(BuildKey("M", "M_Id", "Long", true, false));

			//MemberTypeAssign
			pSet.AddIndexQuery(BuildGroup("MTA", 10));
			pSet.AddIndexQuery(BuildKey("MTA", "MTA_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("MTA", "MTA_Mt", "Byte", false, false));

			//Url
			pSet.AddIndexQuery(BuildGroup("Ur", 11));
			pSet.AddIndexQuery(BuildKey("Ur", "Ur_Na", "String", false, true));
			pSet.AddIndexQuery(BuildKey("Ur", "Ur_Ab", "String", false, true));

			//User
			pSet.AddIndexQuery(BuildGroup("U", 12));
			pSet.AddIndexQuery(BuildKey("U", "U_Na", "String", false, true));
			pSet.AddIndexQuery(BuildKey("U", "U_Pa", "String", false, false));

			//Factor
			pSet.AddIndexQuery(BuildGroup("F", 13));
			pSet.AddIndexQuery(BuildKey("F", "F_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("F", "F_Fa", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_Df", "Boolean", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_Cr", "Long", false, true));
			pSet.AddIndexQuery(BuildKey("F", "F_Dl", "Long", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_Co", "Long", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_No", "String", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_DeT", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_DiT", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_DiP", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_DiR", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_EvT", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_EvP", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_EvD", "Long", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_IdT", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_IdV", "String", true, true));
			pSet.AddIndexQuery(BuildKey("F", "F_LoT", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_LoX", "Double", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_LoY", "Double", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_LoZ", "Double", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_VeT", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_VeU", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_VeP", "Byte", false, false));
			pSet.AddIndexQuery(BuildKey("F", "F_VeV", "Long", false, false));

			//OauthAccess
			pSet.AddIndexQuery(BuildGroup("OA", 14));
			pSet.AddIndexQuery(BuildKey("OA", "OA_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_To", "String", true, false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_Re", "String", true, false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_Ex", "Long", false, false));
			pSet.AddIndexQuery(BuildKey("OA", "OA_CO", "Boolean", false, false));

			//OauthDomain
			pSet.AddIndexQuery(BuildGroup("OD", 15));
			pSet.AddIndexQuery(BuildKey("OD", "OD_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("OD", "OD_Do", "String", false, false));

			//OauthGrant
			pSet.AddIndexQuery(BuildGroup("OG", 16));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Re", "String", false, false));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Co", "String", true, false));
			pSet.AddIndexQuery(BuildKey("OG", "OG_Ex", "Long", false, false));

			//OauthScope
			pSet.AddIndexQuery(BuildGroup("OS", 17));
			pSet.AddIndexQuery(BuildKey("OS", "OS_Id", "Long", true, false));
			pSet.AddIndexQuery(BuildKey("OS", "OS_Al", "Boolean", false, false));
			pSet.AddIndexQuery(BuildKey("OS", "OS_Cr", "Long", false, false));
	
			//EDGES

			//AppUsesEmail
			pSet.AddIndexQuery(BuildLabel("Ap-U-E", false, true, 
				new [] {
					""
				},
				new [] {
					"Ap_Na",
					"Ap_Se",
					"E_Id",
					"E_Ad",
					"E_Co",
					"E_Cr",
					"E_Ve"
				}
			));

			//AppDefinesMember
			pSet.AddIndexQuery(BuildLabel("Ap-D-M", true, false, 
				new [] {
					""
				},
				new [] {
					"Ap_Na",
					"Ap_Se",
					"M_Id"
				}
			));

			//MemberHasMemberTypeAssign
			pSet.AddIndexQuery(BuildLabel("M-H-MTA", true, true, 
				new [] {
					""
				},
				new [] {
					"M_Id",
					"MTA_Id",
					"MTA_Mt"
				}
			));

			//MemberHasHistoricMemberTypeAssign
			pSet.AddIndexQuery(BuildLabel("M-HH-MTA", true, false, 
				new [] {
					""
				},
				new [] {
					"M_Id",
					"MTA_Id",
					"MTA_Mt"
				}
			));

			//MemberCreatesArtifact
			pSet.AddIndexQuery(BuildLabel("M-C-A", true, false, 
				new [] {
					""
				},
				new [] {
					"M_Id",
					"A_AId",
					"A_Cr"
				}
			));

			//MemberCreatesMemberTypeAssign
			pSet.AddIndexQuery(BuildLabel("M-C-MTA", true, false, 
				new [] {
					""
				},
				new [] {
					"M_Id",
					"MTA_Id",
					"MTA_Mt"
				}
			));

			//MemberCreatesFactor
			pSet.AddIndexQuery(BuildLabel("M-C-F", true, false, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//UserUsesEmail
			pSet.AddIndexQuery(BuildLabel("U-U-E", false, true, 
				new [] {
					""
				},
				new [] {
					"U_Na",
					"U_Pa",
					"E_Id",
					"E_Ad",
					"E_Co",
					"E_Cr",
					"E_Ve"
				}
			));

			//UserDefinesMember
			pSet.AddIndexQuery(BuildLabel("U-D-M", true, false, 
				new [] {
					""
				},
				new [] {
					"U_Na",
					"U_Pa",
					"M_Id"
				}
			));

			//FactorUsesPrimaryArtifact
			pSet.AddIndexQuery(BuildLabel("F-UP-A", false, true, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//FactorUsesRelatedArtifact
			pSet.AddIndexQuery(BuildLabel("F-UR-A", false, true, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//FactorDescriptorRefinesPrimaryWithArtifact
			pSet.AddIndexQuery(BuildLabel("F-DRP-A", false, true, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//FactorDescriptorRefinesRelatedWithArtifact
			pSet.AddIndexQuery(BuildLabel("F-DRR-A", false, true, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//FactorDescriptorRefinesTypeWithArtifact
			pSet.AddIndexQuery(BuildLabel("F-DRT-A", false, true, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//FactorVectorUsesAxisArtifact
			pSet.AddIndexQuery(BuildLabel("F-VUA-A", false, true, 
				new [] {
					""
				},
				new [] {
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
				}
			));

			//OauthAccessUsesApp
			pSet.AddIndexQuery(BuildLabel("OA-U-Ap", false, true, 
				new [] {
					""
				},
				new [] {
					"OA_Id",
					"OA_To",
					"OA_Re",
					"OA_Ex",
					"OA_CO",
					"Ap_Na",
					"Ap_Se"
				}
			));

			//OauthAccessUsesUser
			pSet.AddIndexQuery(BuildLabel("OA-U-U", false, true, 
				new [] {
					""
				},
				new [] {
					"OA_Id",
					"OA_To",
					"OA_Re",
					"OA_Ex",
					"OA_CO",
					"U_Na",
					"U_Pa"
				}
			));

			//OauthDomainUsesApp
			pSet.AddIndexQuery(BuildLabel("OD-U-Ap", false, true, 
				new [] {
					""
				},
				new [] {
					"OD_Id",
					"OD_Do",
					"Ap_Na",
					"Ap_Se"
				}
			));

			//OauthGrantUsesApp
			pSet.AddIndexQuery(BuildLabel("OG-U-Ap", false, true, 
				new [] {
					""
				},
				new [] {
					"OG_Id",
					"OG_Re",
					"OG_Co",
					"OG_Ex",
					"Ap_Na",
					"Ap_Se"
				}
			));

			//OauthGrantUsesUser
			pSet.AddIndexQuery(BuildLabel("OG-U-U", false, true, 
				new [] {
					""
				},
				new [] {
					"OG_Id",
					"OG_Re",
					"OG_Co",
					"OG_Ex",
					"U_Na",
					"U_Pa"
				}
			));

			//OauthScopeUsesApp
			pSet.AddIndexQuery(BuildLabel("OS-U-Ap", false, true, 
				new [] {
					""
				},
				new [] {
					"OS_Id",
					"OS_Al",
					"OS_Cr",
					"Ap_Na",
					"Ap_Se"
				}
			));

			//OauthScopeUsesUser
			pSet.AddIndexQuery(BuildLabel("OS-U-U", false, true, 
				new [] {
					""
				},
				new [] {
					"OS_Id",
					"OS_Al",
					"OS_Cr",
					"U_Na",
					"U_Pa"
				}
			));
		}

	}

}