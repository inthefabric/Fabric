// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/13/2013 10:28:47 PM

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
		public static SchemaHelperRel GetEdge(string pName) {
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
		/*--------------------------------------------------------------------------------------------* /
		public static IList<WeaverVertexSchema> GetVertexSchemaListForWeaver() {
			if ( WeaverVertexSchemaList == null ) {
				WeaverVertexSchemaList = new List<WeaverVertexSchema> {
					GetVertexSchemaForWeaver("Vertex"),
					GetVertexSchemaForWeaver("VertexForAction"),
					GetVertexSchemaForWeaver("Artifact"),
					GetVertexSchemaForWeaver("App"),
					GetVertexSchemaForWeaver("Class"),
					GetVertexSchemaForWeaver("Email"),
					GetVertexSchemaForWeaver("Instance"),
					GetVertexSchemaForWeaver("Member"),
					GetVertexSchemaForWeaver("MemberTypeAssign"),
					GetVertexSchemaForWeaver("Url"),
					GetVertexSchemaForWeaver("User"),
					GetVertexSchemaForWeaver("Factor"),
					GetVertexSchemaForWeaver("OauthAccess"),
					GetVertexSchemaForWeaver("OauthDomain"),
					GetVertexSchemaForWeaver("OauthGrant"),
					GetVertexSchemaForWeaver("OauthScope"),
				};
			}

			return WeaverVertexSchemaList;
		}*/

	}

}