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