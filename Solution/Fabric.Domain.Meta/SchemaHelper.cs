// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/4/2013 5:12:47 PM

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
				"Replaces",
				"RefinesPrimaryWith",
				"RefinesRelatedWith",
				"RefinesTypeWith",
				"UsesAxis",
				"RaisesToExp",
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
				case "MemberTypeAssignUsesMemberType": return new SchemaHelperRel(s.Rels[7]);
				case "UserUsesEmail": return new SchemaHelperRel(s.Rels[8]);
				case "UserDefinesMember": return new SchemaHelperRel(s.Rels[9]);
				case "FactorUsesPrimaryArtifact": return new SchemaHelperRel(s.Rels[10]);
				case "FactorUsesRelatedArtifact": return new SchemaHelperRel(s.Rels[11]);
				case "FactorUsesFactorAssertion": return new SchemaHelperRel(s.Rels[12]);
				case "FactorReplacesFactor": return new SchemaHelperRel(s.Rels[13]);
				case "FactorUsesDescriptor": return new SchemaHelperRel(s.Rels[14]);
				case "FactorUsesDirector": return new SchemaHelperRel(s.Rels[15]);
				case "FactorUsesEventor": return new SchemaHelperRel(s.Rels[16]);
				case "FactorUsesIdentor": return new SchemaHelperRel(s.Rels[17]);
				case "FactorUsesLocator": return new SchemaHelperRel(s.Rels[18]);
				case "FactorUsesVector": return new SchemaHelperRel(s.Rels[19]);
				case "DescriptorUsesDescriptorType": return new SchemaHelperRel(s.Rels[20]);
				case "DescriptorRefinesPrimaryWithArtifact": return new SchemaHelperRel(s.Rels[21]);
				case "DescriptorRefinesRelatedWithArtifact": return new SchemaHelperRel(s.Rels[22]);
				case "DescriptorRefinesTypeWithArtifact": return new SchemaHelperRel(s.Rels[23]);
				case "DirectorUsesDirectorType": return new SchemaHelperRel(s.Rels[24]);
				case "DirectorUsesPrimaryDirectorAction": return new SchemaHelperRel(s.Rels[25]);
				case "DirectorUsesRelatedDirectorAction": return new SchemaHelperRel(s.Rels[26]);
				case "EventorUsesEventorType": return new SchemaHelperRel(s.Rels[27]);
				case "EventorUsesEventorPrecision": return new SchemaHelperRel(s.Rels[28]);
				case "IdentorUsesIdentorType": return new SchemaHelperRel(s.Rels[29]);
				case "LocatorUsesLocatorType": return new SchemaHelperRel(s.Rels[30]);
				case "VectorUsesAxisArtifact": return new SchemaHelperRel(s.Rels[31]);
				case "VectorUsesVectorType": return new SchemaHelperRel(s.Rels[32]);
				case "VectorUsesVectorUnit": return new SchemaHelperRel(s.Rels[33]);
				case "VectorUsesVectorUnitPrefix": return new SchemaHelperRel(s.Rels[34]);
				case "VectorTypeUsesVectorRange": return new SchemaHelperRel(s.Rels[35]);
				case "VectorRangeUsesVectorRangeLevel": return new SchemaHelperRel(s.Rels[36]);
				case "VectorUnitDerivedDefinesVectorUnit": return new SchemaHelperRel(s.Rels[37]);
				case "VectorUnitDerivedRaisesToExpVectorUnit": return new SchemaHelperRel(s.Rels[38]);
				case "VectorUnitDerivedUsesVectorUnitPrefix": return new SchemaHelperRel(s.Rels[39]);
				case "OauthAccessUsesApp": return new SchemaHelperRel(s.Rels[40]);
				case "OauthAccessUsesUser": return new SchemaHelperRel(s.Rels[41]);
				case "OauthDomainUsesApp": return new SchemaHelperRel(s.Rels[42]);
				case "OauthGrantUsesApp": return new SchemaHelperRel(s.Rels[43]);
				case "OauthGrantUsesUser": return new SchemaHelperRel(s.Rels[44]);
				case "OauthScopeUsesApp": return new SchemaHelperRel(s.Rels[45]);
				case "OauthScopeUsesUser": return new SchemaHelperRel(s.Rels[46]);
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
				"MemberTypeAssignUsesMemberType",
				"UserUsesEmail",
				"UserDefinesMember",
				"FactorUsesPrimaryArtifact",
				"FactorUsesRelatedArtifact",
				"FactorUsesFactorAssertion",
				"FactorReplacesFactor",
				"FactorUsesDescriptor",
				"FactorUsesDirector",
				"FactorUsesEventor",
				"FactorUsesIdentor",
				"FactorUsesLocator",
				"FactorUsesVector",
				"DescriptorUsesDescriptorType",
				"DescriptorRefinesPrimaryWithArtifact",
				"DescriptorRefinesRelatedWithArtifact",
				"DescriptorRefinesTypeWithArtifact",
				"DirectorUsesDirectorType",
				"DirectorUsesPrimaryDirectorAction",
				"DirectorUsesRelatedDirectorAction",
				"EventorUsesEventorType",
				"EventorUsesEventorPrecision",
				"IdentorUsesIdentorType",
				"LocatorUsesLocatorType",
				"VectorUsesAxisArtifact",
				"VectorUsesVectorType",
				"VectorUsesVectorUnit",
				"VectorUsesVectorUnitPrefix",
				"VectorTypeUsesVectorRange",
				"VectorRangeUsesVectorRangeLevel",
				"VectorUnitDerivedDefinesVectorUnit",
				"VectorUnitDerivedRaisesToExpVectorUnit",
				"VectorUnitDerivedUsesVectorUnitPrefix",
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
				case "NodeForType": return new SchemaHelperNode(s.Nodes[0]);
				case "NodeForAction": return new SchemaHelperNode(s.Nodes[1]);
				case "Artifact": return new SchemaHelperNode(s.Nodes[2]);
				case "App": return new SchemaHelperNode(s.Nodes[3]);
				case "Class": return new SchemaHelperNode(s.Nodes[4]);
				case "Email": return new SchemaHelperNode(s.Nodes[5]);
				case "Instance": return new SchemaHelperNode(s.Nodes[6]);
				case "Member": return new SchemaHelperNode(s.Nodes[7]);
				case "MemberType": return new SchemaHelperNode(s.Nodes[8]);
				case "MemberTypeAssign": return new SchemaHelperNode(s.Nodes[9]);
				case "Url": return new SchemaHelperNode(s.Nodes[10]);
				case "User": return new SchemaHelperNode(s.Nodes[11]);
				case "Factor": return new SchemaHelperNode(s.Nodes[12]);
				case "FactorAssertion": return new SchemaHelperNode(s.Nodes[13]);
				case "FactorElementNode": return new SchemaHelperNode(s.Nodes[14]);
				case "Descriptor": return new SchemaHelperNode(s.Nodes[15]);
				case "DescriptorType": return new SchemaHelperNode(s.Nodes[16]);
				case "Director": return new SchemaHelperNode(s.Nodes[17]);
				case "DirectorType": return new SchemaHelperNode(s.Nodes[18]);
				case "DirectorAction": return new SchemaHelperNode(s.Nodes[19]);
				case "Eventor": return new SchemaHelperNode(s.Nodes[20]);
				case "EventorType": return new SchemaHelperNode(s.Nodes[21]);
				case "EventorPrecision": return new SchemaHelperNode(s.Nodes[22]);
				case "Identor": return new SchemaHelperNode(s.Nodes[23]);
				case "IdentorType": return new SchemaHelperNode(s.Nodes[24]);
				case "Locator": return new SchemaHelperNode(s.Nodes[25]);
				case "LocatorType": return new SchemaHelperNode(s.Nodes[26]);
				case "Vector": return new SchemaHelperNode(s.Nodes[27]);
				case "VectorType": return new SchemaHelperNode(s.Nodes[28]);
				case "VectorRange": return new SchemaHelperNode(s.Nodes[29]);
				case "VectorRangeLevel": return new SchemaHelperNode(s.Nodes[30]);
				case "VectorUnit": return new SchemaHelperNode(s.Nodes[31]);
				case "VectorUnitPrefix": return new SchemaHelperNode(s.Nodes[32]);
				case "VectorUnitDerived": return new SchemaHelperNode(s.Nodes[33]);
				case "OauthAccess": return new SchemaHelperNode(s.Nodes[34]);
				case "OauthDomain": return new SchemaHelperNode(s.Nodes[35]);
				case "OauthGrant": return new SchemaHelperNode(s.Nodes[36]);
				case "OauthScope": return new SchemaHelperNode(s.Nodes[37]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetNodes() {
			return new List<string> {
				"NodeForType",
				"NodeForAction",
				"Artifact",
				"App",
				"Class",
				"Email",
				"Instance",
				"Member",
				"MemberType",
				"MemberTypeAssign",
				"Url",
				"User",
				"Factor",
				"FactorAssertion",
				"FactorElementNode",
				"Descriptor",
				"DescriptorType",
				"Director",
				"DirectorType",
				"DirectorAction",
				"Eventor",
				"EventorType",
				"EventorPrecision",
				"Identor",
				"IdentorType",
				"Locator",
				"LocatorType",
				"Vector",
				"VectorType",
				"VectorRange",
				"VectorRangeLevel",
				"VectorUnit",
				"VectorUnitPrefix",
				"VectorUnitDerived",
				"OauthAccess",
				"OauthDomain",
				"OauthGrant",
				"OauthScope",
			};
		}

	}

}