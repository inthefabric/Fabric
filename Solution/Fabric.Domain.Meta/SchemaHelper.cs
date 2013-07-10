// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 3:25:39 PM

using System.Collections.Generic;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetEdgeTypes() {
			return new List<string> {
				"Uses",
				"Defines",
				"Has",
				"HasHistoric",
				"Creates",
				"UsesPrimary",
				"UsesRelated",
				"DescriptorRefinesPrimaryWith",
				"DescriptorRefinesRelatedWith",
				"DescriptorRefinesTypeWith",
				"VectorUsesAxis",
			};
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static SchemaHelperEdge GetEdge(string pName) {
			var s = SchemaInstance;

			switch ( pName ) {
				case "AppAppUsesEmailEmail": return new SchemaHelperEdge(s.Edges[0]);
				case "AppAppDefinesMemberMember": return new SchemaHelperEdge(s.Edges[1]);
				case "MemberMemberHasMemberTypeAssignMemberTypeAssign": return new SchemaHelperEdge(s.Edges[2]);
				case "MemberMemberHasHistoricMemberTypeAssignMemberTypeAssign": return new SchemaHelperEdge(s.Edges[3]);
				case "MemberMemberCreatesArtifactArtifact": return new SchemaHelperEdge(s.Edges[4]);
				case "MemberMemberCreatesMemberTypeAssignMemberTypeAssign": return new SchemaHelperEdge(s.Edges[5]);
				case "MemberMemberCreatesFactorFactor": return new SchemaHelperEdge(s.Edges[6]);
				case "UserUserUsesEmailEmail": return new SchemaHelperEdge(s.Edges[7]);
				case "UserUserDefinesMemberMember": return new SchemaHelperEdge(s.Edges[8]);
				case "FactorFactorUsesPrimaryArtifactArtifact": return new SchemaHelperEdge(s.Edges[9]);
				case "FactorFactorUsesRelatedArtifactArtifact": return new SchemaHelperEdge(s.Edges[10]);
				case "FactorFactorDescriptorRefinesPrimaryWithArtifactArtifact": return new SchemaHelperEdge(s.Edges[11]);
				case "FactorFactorDescriptorRefinesRelatedWithArtifactArtifact": return new SchemaHelperEdge(s.Edges[12]);
				case "FactorFactorDescriptorRefinesTypeWithArtifactArtifact": return new SchemaHelperEdge(s.Edges[13]);
				case "FactorFactorVectorUsesAxisArtifactArtifact": return new SchemaHelperEdge(s.Edges[14]);
				case "OauthAccessOauthAccessUsesAppApp": return new SchemaHelperEdge(s.Edges[15]);
				case "OauthAccessOauthAccessUsesUserUser": return new SchemaHelperEdge(s.Edges[16]);
				case "OauthDomainOauthDomainUsesAppApp": return new SchemaHelperEdge(s.Edges[17]);
				case "OauthGrantOauthGrantUsesAppApp": return new SchemaHelperEdge(s.Edges[18]);
				case "OauthGrantOauthGrantUsesUserUser": return new SchemaHelperEdge(s.Edges[19]);
				case "OauthScopeOauthScopeUsesAppApp": return new SchemaHelperEdge(s.Edges[20]);
				case "OauthScopeOauthScopeUsesUserUser": return new SchemaHelperEdge(s.Edges[21]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetEdges() {
			return new List<string> {
				"AppAppUsesEmailEmail",
				"AppAppDefinesMemberMember",
				"MemberMemberHasMemberTypeAssignMemberTypeAssign",
				"MemberMemberHasHistoricMemberTypeAssignMemberTypeAssign",
				"MemberMemberCreatesArtifactArtifact",
				"MemberMemberCreatesMemberTypeAssignMemberTypeAssign",
				"MemberMemberCreatesFactorFactor",
				"UserUserUsesEmailEmail",
				"UserUserDefinesMemberMember",
				"FactorFactorUsesPrimaryArtifactArtifact",
				"FactorFactorUsesRelatedArtifactArtifact",
				"FactorFactorDescriptorRefinesPrimaryWithArtifactArtifact",
				"FactorFactorDescriptorRefinesRelatedWithArtifactArtifact",
				"FactorFactorDescriptorRefinesTypeWithArtifactArtifact",
				"FactorFactorVectorUsesAxisArtifactArtifact",
				"OauthAccessOauthAccessUsesAppApp",
				"OauthAccessOauthAccessUsesUserUser",
				"OauthDomainOauthDomainUsesAppApp",
				"OauthGrantOauthGrantUsesAppApp",
				"OauthGrantOauthGrantUsesUserUser",
				"OauthScopeOauthScopeUsesAppApp",
				"OauthScopeOauthScopeUsesUserUser",
			};
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static SchemaHelperVertex GetVertex(string pName) {
			var s = SchemaInstance;

			switch ( pName ) {
				case "Vertex": return new SchemaHelperVertex(s.Vertices[0]);
				case "VertexForAction": return new SchemaHelperVertex(s.Vertices[1]);
				case "Artifact": return new SchemaHelperVertex(s.Vertices[2]);
				case "App": return new SchemaHelperVertex(s.Vertices[3]);
				case "Class": return new SchemaHelperVertex(s.Vertices[4]);
				case "Email": return new SchemaHelperVertex(s.Vertices[5]);
				case "Instance": return new SchemaHelperVertex(s.Vertices[6]);
				case "Member": return new SchemaHelperVertex(s.Vertices[7]);
				case "MemberTypeAssign": return new SchemaHelperVertex(s.Vertices[8]);
				case "Url": return new SchemaHelperVertex(s.Vertices[9]);
				case "User": return new SchemaHelperVertex(s.Vertices[10]);
				case "Factor": return new SchemaHelperVertex(s.Vertices[11]);
				case "OauthAccess": return new SchemaHelperVertex(s.Vertices[12]);
				case "OauthDomain": return new SchemaHelperVertex(s.Vertices[13]);
				case "OauthGrant": return new SchemaHelperVertex(s.Vertices[14]);
				case "OauthScope": return new SchemaHelperVertex(s.Vertices[15]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetVertices() {
			return new List<string> {
				"Vertex",
				"VertexForAction",
				"Artifact",
				"App",
				"Class",
				"Email",
				"Instance",
				"Member",
				"MemberTypeAssign",
				"Url",
				"User",
				"Factor",
				"OauthAccess",
				"OauthDomain",
				"OauthGrant",
				"OauthScope",
			};
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRootLinks() {
			return new List<string> {
				"Artifact",
				"App",
				"Class",
				"Instance",
				"Member",
				"MemberTypeAssign",
				"Url",
				"User",
				"Factor",
			};
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static SchemaHelperProp GetProp(string pName) {
			var s = SchemaInstance;
			
			switch ( pName ) {
				case "N_FT": return new SchemaHelperProp(s.Props[0]);
				case "NA_Pe": return new SchemaHelperProp(s.Props[1]);
				case "NA_No": return new SchemaHelperProp(s.Props[2]);
				case "A_AId": return new SchemaHelperProp(s.Props[3]);
				case "A_Cr": return new SchemaHelperProp(s.Props[4]);
				case "Ap_Na": return new SchemaHelperProp(s.Props[5]);
				case "Ap_NK": return new SchemaHelperProp(s.Props[6]);
				case "Ap_Se": return new SchemaHelperProp(s.Props[7]);
				case "Cl_Na": return new SchemaHelperProp(s.Props[8]);
				case "Cl_NK": return new SchemaHelperProp(s.Props[9]);
				case "Cl_Di": return new SchemaHelperProp(s.Props[10]);
				case "Cl_No": return new SchemaHelperProp(s.Props[11]);
				case "E_Id": return new SchemaHelperProp(s.Props[12]);
				case "E_Ad": return new SchemaHelperProp(s.Props[13]);
				case "E_Co": return new SchemaHelperProp(s.Props[14]);
				case "E_Cr": return new SchemaHelperProp(s.Props[15]);
				case "E_Ve": return new SchemaHelperProp(s.Props[16]);
				case "In_Na": return new SchemaHelperProp(s.Props[17]);
				case "In_Di": return new SchemaHelperProp(s.Props[18]);
				case "In_No": return new SchemaHelperProp(s.Props[19]);
				case "M_Id": return new SchemaHelperProp(s.Props[20]);
				case "MTA_Id": return new SchemaHelperProp(s.Props[21]);
				case "MTA_Mt": return new SchemaHelperProp(s.Props[22]);
				case "Ur_Na": return new SchemaHelperProp(s.Props[23]);
				case "Ur_Ab": return new SchemaHelperProp(s.Props[24]);
				case "U_Na": return new SchemaHelperProp(s.Props[25]);
				case "U_NK": return new SchemaHelperProp(s.Props[26]);
				case "U_Pa": return new SchemaHelperProp(s.Props[27]);
				case "F_Id": return new SchemaHelperProp(s.Props[28]);
				case "F_Fa": return new SchemaHelperProp(s.Props[29]);
				case "F_Df": return new SchemaHelperProp(s.Props[30]);
				case "F_Cr": return new SchemaHelperProp(s.Props[31]);
				case "F_Dl": return new SchemaHelperProp(s.Props[32]);
				case "F_Co": return new SchemaHelperProp(s.Props[33]);
				case "F_No": return new SchemaHelperProp(s.Props[34]);
				case "F_DeT": return new SchemaHelperProp(s.Props[35]);
				case "F_DiT": return new SchemaHelperProp(s.Props[36]);
				case "F_DiP": return new SchemaHelperProp(s.Props[37]);
				case "F_DiR": return new SchemaHelperProp(s.Props[38]);
				case "F_EvT": return new SchemaHelperProp(s.Props[39]);
				case "F_EvP": return new SchemaHelperProp(s.Props[40]);
				case "F_EvD": return new SchemaHelperProp(s.Props[41]);
				case "F_IdT": return new SchemaHelperProp(s.Props[42]);
				case "F_IdV": return new SchemaHelperProp(s.Props[43]);
				case "F_LoT": return new SchemaHelperProp(s.Props[44]);
				case "F_LoX": return new SchemaHelperProp(s.Props[45]);
				case "F_LoY": return new SchemaHelperProp(s.Props[46]);
				case "F_LoZ": return new SchemaHelperProp(s.Props[47]);
				case "F_VeT": return new SchemaHelperProp(s.Props[48]);
				case "F_VeU": return new SchemaHelperProp(s.Props[49]);
				case "F_VeP": return new SchemaHelperProp(s.Props[50]);
				case "F_VeV": return new SchemaHelperProp(s.Props[51]);
				case "OA_Id": return new SchemaHelperProp(s.Props[52]);
				case "OA_To": return new SchemaHelperProp(s.Props[53]);
				case "OA_Re": return new SchemaHelperProp(s.Props[54]);
				case "OA_Ex": return new SchemaHelperProp(s.Props[55]);
				case "OA_CO": return new SchemaHelperProp(s.Props[56]);
				case "OD_Id": return new SchemaHelperProp(s.Props[57]);
				case "OD_Do": return new SchemaHelperProp(s.Props[58]);
				case "OG_Id": return new SchemaHelperProp(s.Props[59]);
				case "OG_Re": return new SchemaHelperProp(s.Props[60]);
				case "OG_Co": return new SchemaHelperProp(s.Props[61]);
				case "OG_Ex": return new SchemaHelperProp(s.Props[62]);
				case "OS_Id": return new SchemaHelperProp(s.Props[63]);
				case "OS_Al": return new SchemaHelperProp(s.Props[64]);
				case "OS_Cr": return new SchemaHelperProp(s.Props[65]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetProps() {
			return new List<string> {
				"N_FT",
				"NA_Pe",
				"NA_No",
				"A_AId",
				"A_Cr",
				"Ap_Na",
				"Ap_NK",
				"Ap_Se",
				"Cl_Na",
				"Cl_NK",
				"Cl_Di",
				"Cl_No",
				"E_Id",
				"E_Ad",
				"E_Co",
				"E_Cr",
				"E_Ve",
				"In_Na",
				"In_Di",
				"In_No",
				"M_Id",
				"MTA_Id",
				"MTA_Mt",
				"Ur_Na",
				"Ur_Ab",
				"U_Na",
				"U_NK",
				"U_Pa",
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
				"OA_Id",
				"OA_To",
				"OA_Re",
				"OA_Ex",
				"OA_CO",
				"OD_Id",
				"OD_Do",
				"OG_Id",
				"OG_Re",
				"OG_Co",
				"OG_Ex",
				"OS_Id",
				"OS_Al",
				"OS_Cr",
			};
		}

	}

}