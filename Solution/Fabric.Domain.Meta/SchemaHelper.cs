// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/10/2013 12:55:32 PM

using System.Collections.Generic;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRelTypes() {
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
		public static SchemaHelperRel GetRel(string pName) {
			var s = SchemaInstance;

			switch ( pName ) {
				case "AppUsesEmail": return new SchemaHelperRel(s.Rels[0]);
				case "AppDefinesMember": return new SchemaHelperRel(s.Rels[1]);
				case "MemberHasMemberTypeAssign": return new SchemaHelperRel(s.Rels[2]);
				case "MemberHasHistoricMemberTypeAssign": return new SchemaHelperRel(s.Rels[3]);
				case "MemberCreatesArtifact": return new SchemaHelperRel(s.Rels[4]);
				case "MemberCreatesMemberTypeAssign": return new SchemaHelperRel(s.Rels[5]);
				case "MemberCreatesFactor": return new SchemaHelperRel(s.Rels[6]);
				case "UserUsesEmail": return new SchemaHelperRel(s.Rels[7]);
				case "UserDefinesMember": return new SchemaHelperRel(s.Rels[8]);
				case "FactorUsesPrimaryArtifact": return new SchemaHelperRel(s.Rels[9]);
				case "FactorUsesRelatedArtifact": return new SchemaHelperRel(s.Rels[10]);
				case "FactorDescriptorRefinesPrimaryWithArtifact": return new SchemaHelperRel(s.Rels[11]);
				case "FactorDescriptorRefinesRelatedWithArtifact": return new SchemaHelperRel(s.Rels[12]);
				case "FactorDescriptorRefinesTypeWithArtifact": return new SchemaHelperRel(s.Rels[13]);
				case "FactorVectorUsesAxisArtifact": return new SchemaHelperRel(s.Rels[14]);
				case "OauthAccessUsesApp": return new SchemaHelperRel(s.Rels[15]);
				case "OauthAccessUsesUser": return new SchemaHelperRel(s.Rels[16]);
				case "OauthDomainUsesApp": return new SchemaHelperRel(s.Rels[17]);
				case "OauthGrantUsesApp": return new SchemaHelperRel(s.Rels[18]);
				case "OauthGrantUsesUser": return new SchemaHelperRel(s.Rels[19]);
				case "OauthScopeUsesApp": return new SchemaHelperRel(s.Rels[20]);
				case "OauthScopeUsesUser": return new SchemaHelperRel(s.Rels[21]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRels() {
			return new List<string> {
				"AppUsesEmail",
				"AppDefinesMember",
				"MemberHasMemberTypeAssign",
				"MemberHasHistoricMemberTypeAssign",
				"MemberCreatesArtifact",
				"MemberCreatesMemberTypeAssign",
				"MemberCreatesFactor",
				"UserUsesEmail",
				"UserDefinesMember",
				"FactorUsesPrimaryArtifact",
				"FactorUsesRelatedArtifact",
				"FactorDescriptorRefinesPrimaryWithArtifact",
				"FactorDescriptorRefinesRelatedWithArtifact",
				"FactorDescriptorRefinesTypeWithArtifact",
				"FactorVectorUsesAxisArtifact",
				"OauthAccessUsesApp",
				"OauthAccessUsesUser",
				"OauthDomainUsesApp",
				"OauthGrantUsesApp",
				"OauthGrantUsesUser",
				"OauthScopeUsesApp",
				"OauthScopeUsesUser",
			};
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static SchemaHelperNode GetNode(string pName) {
			var s = SchemaInstance;

			switch ( pName ) {
				case "NodeForAction": return new SchemaHelperNode(s.Nodes[0]);
				case "Artifact": return new SchemaHelperNode(s.Nodes[1]);
				case "App": return new SchemaHelperNode(s.Nodes[2]);
				case "Class": return new SchemaHelperNode(s.Nodes[3]);
				case "Email": return new SchemaHelperNode(s.Nodes[4]);
				case "Instance": return new SchemaHelperNode(s.Nodes[5]);
				case "Member": return new SchemaHelperNode(s.Nodes[6]);
				case "MemberTypeAssign": return new SchemaHelperNode(s.Nodes[7]);
				case "Url": return new SchemaHelperNode(s.Nodes[8]);
				case "User": return new SchemaHelperNode(s.Nodes[9]);
				case "Factor": return new SchemaHelperNode(s.Nodes[10]);
				case "OauthAccess": return new SchemaHelperNode(s.Nodes[11]);
				case "OauthDomain": return new SchemaHelperNode(s.Nodes[12]);
				case "OauthGrant": return new SchemaHelperNode(s.Nodes[13]);
				case "OauthScope": return new SchemaHelperNode(s.Nodes[14]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetNodes() {
			return new List<string> {
				"NodeForAction",
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

	}

}