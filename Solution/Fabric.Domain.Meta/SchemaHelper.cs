// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 9:20:47 PM

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
				case "AppAppUsesEmailEmail": return new SchemaHelperRel(s.Rels[0]);
				case "AppAppDefinesMemberMember": return new SchemaHelperRel(s.Rels[1]);
				case "MemberMemberHasMemberTypeAssignMemberTypeAssign": return new SchemaHelperRel(s.Rels[2]);
				case "MemberMemberHasHistoricMemberTypeAssignMemberTypeAssign": return new SchemaHelperRel(s.Rels[3]);
				case "MemberMemberCreatesArtifactArtifact": return new SchemaHelperRel(s.Rels[4]);
				case "MemberMemberCreatesMemberTypeAssignMemberTypeAssign": return new SchemaHelperRel(s.Rels[5]);
				case "MemberMemberCreatesFactorFactor": return new SchemaHelperRel(s.Rels[6]);
				case "UserUserUsesEmailEmail": return new SchemaHelperRel(s.Rels[7]);
				case "UserUserDefinesMemberMember": return new SchemaHelperRel(s.Rels[8]);
				case "FactorFactorUsesPrimaryArtifactArtifact": return new SchemaHelperRel(s.Rels[9]);
				case "FactorFactorUsesRelatedArtifactArtifact": return new SchemaHelperRel(s.Rels[10]);
				case "FactorFactorDescriptorRefinesPrimaryWithArtifactArtifact": return new SchemaHelperRel(s.Rels[11]);
				case "FactorFactorDescriptorRefinesRelatedWithArtifactArtifact": return new SchemaHelperRel(s.Rels[12]);
				case "FactorFactorDescriptorRefinesTypeWithArtifactArtifact": return new SchemaHelperRel(s.Rels[13]);
				case "FactorFactorVectorUsesAxisArtifactArtifact": return new SchemaHelperRel(s.Rels[14]);
				case "OauthAccessOauthAccessUsesAppApp": return new SchemaHelperRel(s.Rels[15]);
				case "OauthAccessOauthAccessUsesUserUser": return new SchemaHelperRel(s.Rels[16]);
				case "OauthDomainOauthDomainUsesAppApp": return new SchemaHelperRel(s.Rels[17]);
				case "OauthGrantOauthGrantUsesAppApp": return new SchemaHelperRel(s.Rels[18]);
				case "OauthGrantOauthGrantUsesUserUser": return new SchemaHelperRel(s.Rels[19]);
				case "OauthScopeOauthScopeUsesAppApp": return new SchemaHelperRel(s.Rels[20]);
				case "OauthScopeOauthScopeUsesUserUser": return new SchemaHelperRel(s.Rels[21]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRels() {
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
		public static SchemaHelperNode GetNode(string pName) {
			var s = SchemaInstance;

			switch ( pName ) {
				case "Node": return new SchemaHelperNode(s.Nodes[0]); //
				case "NodeForAction": return new SchemaHelperNode(s.Nodes[1]); //Weaver.Schema.WeaverNodeSchema
				case "Artifact": return new SchemaHelperNode(s.Nodes[2]); //Weaver.Schema.WeaverNodeSchema
				case "App": return new SchemaHelperNode(s.Nodes[3]); //Weaver.Schema.WeaverNodeSchema
				case "Class": return new SchemaHelperNode(s.Nodes[4]); //Weaver.Schema.WeaverNodeSchema
				case "Email": return new SchemaHelperNode(s.Nodes[5]); //Weaver.Schema.WeaverNodeSchema
				case "Instance": return new SchemaHelperNode(s.Nodes[6]); //Weaver.Schema.WeaverNodeSchema
				case "Member": return new SchemaHelperNode(s.Nodes[7]); //
				case "MemberTypeAssign": return new SchemaHelperNode(s.Nodes[8]); //Weaver.Schema.WeaverNodeSchema
				case "Url": return new SchemaHelperNode(s.Nodes[9]); //Weaver.Schema.WeaverNodeSchema
				case "User": return new SchemaHelperNode(s.Nodes[10]); //Weaver.Schema.WeaverNodeSchema
				case "Factor": return new SchemaHelperNode(s.Nodes[11]); //Weaver.Schema.WeaverNodeSchema
				case "OauthAccess": return new SchemaHelperNode(s.Nodes[12]); //Weaver.Schema.WeaverNodeSchema
				case "OauthDomain": return new SchemaHelperNode(s.Nodes[13]); //Weaver.Schema.WeaverNodeSchema
				case "OauthGrant": return new SchemaHelperNode(s.Nodes[14]); //Weaver.Schema.WeaverNodeSchema
				case "OauthScope": return new SchemaHelperNode(s.Nodes[15]); //Weaver.Schema.WeaverNodeSchema
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetNodes() {
			return new List<string> {
				"Node",
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

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static IList<WeaverNodeSchema> GetNodeSchemaListForWeaver() {
			if ( WeaverNodeSchemaList == null ) {
				WeaverNodeSchemaList = new List<WeaverNodeSchema> {
					GetNodeSchemaForWeaver("Node"),
					GetNodeSchemaForWeaver("NodeForAction"),
					GetNodeSchemaForWeaver("Artifact"),
					GetNodeSchemaForWeaver("App"),
					GetNodeSchemaForWeaver("Class"),
					GetNodeSchemaForWeaver("Email"),
					GetNodeSchemaForWeaver("Instance"),
					GetNodeSchemaForWeaver("Member"),
					GetNodeSchemaForWeaver("MemberTypeAssign"),
					GetNodeSchemaForWeaver("Url"),
					GetNodeSchemaForWeaver("User"),
					GetNodeSchemaForWeaver("Factor"),
					GetNodeSchemaForWeaver("OauthAccess"),
					GetNodeSchemaForWeaver("OauthDomain"),
					GetNodeSchemaForWeaver("OauthGrant"),
					GetNodeSchemaForWeaver("OauthScope"),
				};
			}

			return WeaverNodeSchemaList;
		}*/

	}

}