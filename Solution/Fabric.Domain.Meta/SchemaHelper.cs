// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/2/2013 1:27:08 PM

using System.Collections.Generic;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRelTypes() {
			return new List<string> {
				"Contains",
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
				case "RootContainsApp": return new SchemaHelperRel(s.Rels[0]);
				case "RootContainsClass": return new SchemaHelperRel(s.Rels[1]);
				case "RootContainsEmail": return new SchemaHelperRel(s.Rels[2]);
				case "RootContainsInstance": return new SchemaHelperRel(s.Rels[3]);
				case "RootContainsMember": return new SchemaHelperRel(s.Rels[4]);
				case "RootContainsMemberType": return new SchemaHelperRel(s.Rels[5]);
				case "RootContainsMemberTypeAssign": return new SchemaHelperRel(s.Rels[6]);
				case "RootContainsUrl": return new SchemaHelperRel(s.Rels[7]);
				case "RootContainsUser": return new SchemaHelperRel(s.Rels[8]);
				case "RootContainsFactor": return new SchemaHelperRel(s.Rels[9]);
				case "RootContainsFactorAssertion": return new SchemaHelperRel(s.Rels[10]);
				case "RootContainsDescriptor": return new SchemaHelperRel(s.Rels[11]);
				case "RootContainsDescriptorType": return new SchemaHelperRel(s.Rels[12]);
				case "RootContainsDirector": return new SchemaHelperRel(s.Rels[13]);
				case "RootContainsDirectorType": return new SchemaHelperRel(s.Rels[14]);
				case "RootContainsDirectorAction": return new SchemaHelperRel(s.Rels[15]);
				case "RootContainsEventor": return new SchemaHelperRel(s.Rels[16]);
				case "RootContainsEventorType": return new SchemaHelperRel(s.Rels[17]);
				case "RootContainsEventorPrecision": return new SchemaHelperRel(s.Rels[18]);
				case "RootContainsIdentor": return new SchemaHelperRel(s.Rels[19]);
				case "RootContainsIdentorType": return new SchemaHelperRel(s.Rels[20]);
				case "RootContainsLocator": return new SchemaHelperRel(s.Rels[21]);
				case "RootContainsLocatorType": return new SchemaHelperRel(s.Rels[22]);
				case "RootContainsVector": return new SchemaHelperRel(s.Rels[23]);
				case "RootContainsVectorType": return new SchemaHelperRel(s.Rels[24]);
				case "RootContainsVectorRange": return new SchemaHelperRel(s.Rels[25]);
				case "RootContainsVectorRangeLevel": return new SchemaHelperRel(s.Rels[26]);
				case "RootContainsVectorUnit": return new SchemaHelperRel(s.Rels[27]);
				case "RootContainsVectorUnitPrefix": return new SchemaHelperRel(s.Rels[28]);
				case "RootContainsVectorUnitDerived": return new SchemaHelperRel(s.Rels[29]);
				case "RootContainsOauthAccess": return new SchemaHelperRel(s.Rels[30]);
				case "RootContainsOauthDomain": return new SchemaHelperRel(s.Rels[31]);
				case "RootContainsOauthGrant": return new SchemaHelperRel(s.Rels[32]);
				case "RootContainsOauthScope": return new SchemaHelperRel(s.Rels[33]);
				case "AppUsesEmail": return new SchemaHelperRel(s.Rels[34]);
				case "AppDefinesMember": return new SchemaHelperRel(s.Rels[35]);
				case "MemberHasMemberTypeAssign": return new SchemaHelperRel(s.Rels[36]);
				case "MemberHasHistoricMemberTypeAssign": return new SchemaHelperRel(s.Rels[37]);
				case "MemberCreatesArtifact": return new SchemaHelperRel(s.Rels[38]);
				case "MemberCreatesMemberTypeAssign": return new SchemaHelperRel(s.Rels[39]);
				case "MemberCreatesFactor": return new SchemaHelperRel(s.Rels[40]);
				case "MemberTypeAssignUsesMemberType": return new SchemaHelperRel(s.Rels[41]);
				case "UserUsesEmail": return new SchemaHelperRel(s.Rels[42]);
				case "UserDefinesMember": return new SchemaHelperRel(s.Rels[43]);
				case "FactorUsesPrimaryArtifact": return new SchemaHelperRel(s.Rels[44]);
				case "FactorUsesRelatedArtifact": return new SchemaHelperRel(s.Rels[45]);
				case "FactorUsesFactorAssertion": return new SchemaHelperRel(s.Rels[46]);
				case "FactorReplacesFactor": return new SchemaHelperRel(s.Rels[47]);
				case "FactorUsesDescriptor": return new SchemaHelperRel(s.Rels[48]);
				case "FactorUsesDirector": return new SchemaHelperRel(s.Rels[49]);
				case "FactorUsesEventor": return new SchemaHelperRel(s.Rels[50]);
				case "FactorUsesIdentor": return new SchemaHelperRel(s.Rels[51]);
				case "FactorUsesLocator": return new SchemaHelperRel(s.Rels[52]);
				case "FactorUsesVector": return new SchemaHelperRel(s.Rels[53]);
				case "DescriptorUsesDescriptorType": return new SchemaHelperRel(s.Rels[54]);
				case "DescriptorRefinesPrimaryWithArtifact": return new SchemaHelperRel(s.Rels[55]);
				case "DescriptorRefinesRelatedWithArtifact": return new SchemaHelperRel(s.Rels[56]);
				case "DescriptorRefinesTypeWithArtifact": return new SchemaHelperRel(s.Rels[57]);
				case "DirectorUsesDirectorType": return new SchemaHelperRel(s.Rels[58]);
				case "DirectorUsesPrimaryDirectorAction": return new SchemaHelperRel(s.Rels[59]);
				case "DirectorUsesRelatedDirectorAction": return new SchemaHelperRel(s.Rels[60]);
				case "EventorUsesEventorType": return new SchemaHelperRel(s.Rels[61]);
				case "EventorUsesEventorPrecision": return new SchemaHelperRel(s.Rels[62]);
				case "IdentorUsesIdentorType": return new SchemaHelperRel(s.Rels[63]);
				case "LocatorUsesLocatorType": return new SchemaHelperRel(s.Rels[64]);
				case "VectorUsesAxisArtifact": return new SchemaHelperRel(s.Rels[65]);
				case "VectorUsesVectorType": return new SchemaHelperRel(s.Rels[66]);
				case "VectorUsesVectorUnit": return new SchemaHelperRel(s.Rels[67]);
				case "VectorUsesVectorUnitPrefix": return new SchemaHelperRel(s.Rels[68]);
				case "VectorTypeUsesVectorRange": return new SchemaHelperRel(s.Rels[69]);
				case "VectorRangeUsesVectorRangeLevel": return new SchemaHelperRel(s.Rels[70]);
				case "VectorUnitDerivedDefinesVectorUnit": return new SchemaHelperRel(s.Rels[71]);
				case "VectorUnitDerivedRaisesToExpVectorUnit": return new SchemaHelperRel(s.Rels[72]);
				case "VectorUnitDerivedUsesVectorUnitPrefix": return new SchemaHelperRel(s.Rels[73]);
				case "OauthAccessUsesApp": return new SchemaHelperRel(s.Rels[74]);
				case "OauthAccessUsesUser": return new SchemaHelperRel(s.Rels[75]);
				case "OauthDomainUsesApp": return new SchemaHelperRel(s.Rels[76]);
				case "OauthGrantUsesApp": return new SchemaHelperRel(s.Rels[77]);
				case "OauthGrantUsesUser": return new SchemaHelperRel(s.Rels[78]);
				case "OauthScopeUsesApp": return new SchemaHelperRel(s.Rels[79]);
				case "OauthScopeUsesUser": return new SchemaHelperRel(s.Rels[80]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRels() {
			return new List<string> {
				"RootContainsApp",
				"RootContainsClass",
				"RootContainsEmail",
				"RootContainsInstance",
				"RootContainsMember",
				"RootContainsMemberType",
				"RootContainsMemberTypeAssign",
				"RootContainsUrl",
				"RootContainsUser",
				"RootContainsFactor",
				"RootContainsFactorAssertion",
				"RootContainsDescriptor",
				"RootContainsDescriptorType",
				"RootContainsDirector",
				"RootContainsDirectorType",
				"RootContainsDirectorAction",
				"RootContainsEventor",
				"RootContainsEventorType",
				"RootContainsEventorPrecision",
				"RootContainsIdentor",
				"RootContainsIdentorType",
				"RootContainsLocator",
				"RootContainsLocatorType",
				"RootContainsVector",
				"RootContainsVectorType",
				"RootContainsVectorRange",
				"RootContainsVectorRangeLevel",
				"RootContainsVectorUnit",
				"RootContainsVectorUnitPrefix",
				"RootContainsVectorUnitDerived",
				"RootContainsOauthAccess",
				"RootContainsOauthDomain",
				"RootContainsOauthGrant",
				"RootContainsOauthScope",
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
				case "Root": return new SchemaHelperNode(s.Nodes[2]);
				case "Artifact": return new SchemaHelperNode(s.Nodes[3]);
				case "App": return new SchemaHelperNode(s.Nodes[4]);
				case "Class": return new SchemaHelperNode(s.Nodes[5]);
				case "Email": return new SchemaHelperNode(s.Nodes[6]);
				case "Instance": return new SchemaHelperNode(s.Nodes[7]);
				case "Member": return new SchemaHelperNode(s.Nodes[8]);
				case "MemberType": return new SchemaHelperNode(s.Nodes[9]);
				case "MemberTypeAssign": return new SchemaHelperNode(s.Nodes[10]);
				case "Url": return new SchemaHelperNode(s.Nodes[11]);
				case "User": return new SchemaHelperNode(s.Nodes[12]);
				case "Factor": return new SchemaHelperNode(s.Nodes[13]);
				case "FactorAssertion": return new SchemaHelperNode(s.Nodes[14]);
				case "FactorElementNode": return new SchemaHelperNode(s.Nodes[15]);
				case "Descriptor": return new SchemaHelperNode(s.Nodes[16]);
				case "DescriptorType": return new SchemaHelperNode(s.Nodes[17]);
				case "Director": return new SchemaHelperNode(s.Nodes[18]);
				case "DirectorType": return new SchemaHelperNode(s.Nodes[19]);
				case "DirectorAction": return new SchemaHelperNode(s.Nodes[20]);
				case "Eventor": return new SchemaHelperNode(s.Nodes[21]);
				case "EventorType": return new SchemaHelperNode(s.Nodes[22]);
				case "EventorPrecision": return new SchemaHelperNode(s.Nodes[23]);
				case "Identor": return new SchemaHelperNode(s.Nodes[24]);
				case "IdentorType": return new SchemaHelperNode(s.Nodes[25]);
				case "Locator": return new SchemaHelperNode(s.Nodes[26]);
				case "LocatorType": return new SchemaHelperNode(s.Nodes[27]);
				case "Vector": return new SchemaHelperNode(s.Nodes[28]);
				case "VectorType": return new SchemaHelperNode(s.Nodes[29]);
				case "VectorRange": return new SchemaHelperNode(s.Nodes[30]);
				case "VectorRangeLevel": return new SchemaHelperNode(s.Nodes[31]);
				case "VectorUnit": return new SchemaHelperNode(s.Nodes[32]);
				case "VectorUnitPrefix": return new SchemaHelperNode(s.Nodes[33]);
				case "VectorUnitDerived": return new SchemaHelperNode(s.Nodes[34]);
				case "OauthAccess": return new SchemaHelperNode(s.Nodes[35]);
				case "OauthDomain": return new SchemaHelperNode(s.Nodes[36]);
				case "OauthGrant": return new SchemaHelperNode(s.Nodes[37]);
				case "OauthScope": return new SchemaHelperNode(s.Nodes[38]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetNodes() {
			return new List<string> {
				"NodeForType",
				"NodeForAction",
				"Root",
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