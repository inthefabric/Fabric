// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/18/2012 4:31:26 PM

using System.Collections.Generic;

namespace Fabric.Infrastructure.Domain {

	/*================================================================================================*/
	public static partial class SchemaHelper {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRelTypes() {
			return new List<string> {
				"Contains",
				"Has",
				"Uses",
				"Defines",
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
				case "RootContainsArtifact": return new SchemaHelperRel(s.Rels[1]);
				case "RootContainsArtifactType": return new SchemaHelperRel(s.Rels[2]);
				case "RootContainsCrowd": return new SchemaHelperRel(s.Rels[3]);
				case "RootContainsCrowdian": return new SchemaHelperRel(s.Rels[4]);
				case "RootContainsCrowdianType": return new SchemaHelperRel(s.Rels[5]);
				case "RootContainsCrowdianTypeAssign": return new SchemaHelperRel(s.Rels[6]);
				case "RootContainsEmail": return new SchemaHelperRel(s.Rels[7]);
				case "RootContainsLabel": return new SchemaHelperRel(s.Rels[8]);
				case "RootContainsMember": return new SchemaHelperRel(s.Rels[9]);
				case "RootContainsMemberType": return new SchemaHelperRel(s.Rels[10]);
				case "RootContainsMemberTypeAssign": return new SchemaHelperRel(s.Rels[11]);
				case "RootContainsThing": return new SchemaHelperRel(s.Rels[12]);
				case "RootContainsUrl": return new SchemaHelperRel(s.Rels[13]);
				case "RootContainsUser": return new SchemaHelperRel(s.Rels[14]);
				case "RootContainsFactor": return new SchemaHelperRel(s.Rels[15]);
				case "RootContainsFactorAssertion": return new SchemaHelperRel(s.Rels[16]);
				case "RootContainsDescriptor": return new SchemaHelperRel(s.Rels[17]);
				case "RootContainsDescriptorType": return new SchemaHelperRel(s.Rels[18]);
				case "RootContainsDirector": return new SchemaHelperRel(s.Rels[19]);
				case "RootContainsDirectorType": return new SchemaHelperRel(s.Rels[20]);
				case "RootContainsDirectorAction": return new SchemaHelperRel(s.Rels[21]);
				case "RootContainsEventor": return new SchemaHelperRel(s.Rels[22]);
				case "RootContainsEventorType": return new SchemaHelperRel(s.Rels[23]);
				case "RootContainsEventorPrecision": return new SchemaHelperRel(s.Rels[24]);
				case "RootContainsIdentor": return new SchemaHelperRel(s.Rels[25]);
				case "RootContainsIdentorType": return new SchemaHelperRel(s.Rels[26]);
				case "RootContainsLocator": return new SchemaHelperRel(s.Rels[27]);
				case "RootContainsLocatorType": return new SchemaHelperRel(s.Rels[28]);
				case "RootContainsVector": return new SchemaHelperRel(s.Rels[29]);
				case "RootContainsVectorType": return new SchemaHelperRel(s.Rels[30]);
				case "RootContainsVectorRange": return new SchemaHelperRel(s.Rels[31]);
				case "RootContainsVectorRangeLevel": return new SchemaHelperRel(s.Rels[32]);
				case "RootContainsVectorUnit": return new SchemaHelperRel(s.Rels[33]);
				case "RootContainsVectorUnitPrefix": return new SchemaHelperRel(s.Rels[34]);
				case "RootContainsVectorUnitDerived": return new SchemaHelperRel(s.Rels[35]);
				case "RootContainsOauthAccess": return new SchemaHelperRel(s.Rels[36]);
				case "RootContainsOauthDomain": return new SchemaHelperRel(s.Rels[37]);
				case "RootContainsOauthGrant": return new SchemaHelperRel(s.Rels[38]);
				case "RootContainsOauthScope": return new SchemaHelperRel(s.Rels[39]);
				case "AppHasArtifact": return new SchemaHelperRel(s.Rels[40]);
				case "AppUsesEmail": return new SchemaHelperRel(s.Rels[41]);
				case "AppDefinesMember": return new SchemaHelperRel(s.Rels[42]);
				case "ArtifactUsesArtifactType": return new SchemaHelperRel(s.Rels[43]);
				case "CrowdHasArtifact": return new SchemaHelperRel(s.Rels[44]);
				case "CrowdDefinesCrowdian": return new SchemaHelperRel(s.Rels[45]);
				case "CrowdianHasCrowdianTypeAssign": return new SchemaHelperRel(s.Rels[46]);
				case "CrowdianHasHistoricCrowdianTypeAssign": return new SchemaHelperRel(s.Rels[47]);
				case "CrowdianTypeAssignUsesCrowdianType": return new SchemaHelperRel(s.Rels[48]);
				case "LabelHasArtifact": return new SchemaHelperRel(s.Rels[49]);
				case "MemberHasMemberTypeAssign": return new SchemaHelperRel(s.Rels[50]);
				case "MemberHasHistoricMemberTypeAssign": return new SchemaHelperRel(s.Rels[51]);
				case "MemberCreatesArtifact": return new SchemaHelperRel(s.Rels[52]);
				case "MemberCreatesMemberTypeAssign": return new SchemaHelperRel(s.Rels[53]);
				case "MemberCreatesFactor": return new SchemaHelperRel(s.Rels[54]);
				case "MemberTypeAssignUsesMemberType": return new SchemaHelperRel(s.Rels[55]);
				case "ThingHasArtifact": return new SchemaHelperRel(s.Rels[56]);
				case "UrlHasArtifact": return new SchemaHelperRel(s.Rels[57]);
				case "UserHasArtifact": return new SchemaHelperRel(s.Rels[58]);
				case "UserCreatesCrowdianTypeAssign": return new SchemaHelperRel(s.Rels[59]);
				case "UserDefinesCrowdian": return new SchemaHelperRel(s.Rels[60]);
				case "UserUsesEmail": return new SchemaHelperRel(s.Rels[61]);
				case "UserDefinesMember": return new SchemaHelperRel(s.Rels[62]);
				case "FactorUsesPrimaryArtifact": return new SchemaHelperRel(s.Rels[63]);
				case "FactorUsesRelatedArtifact": return new SchemaHelperRel(s.Rels[64]);
				case "FactorUsesFactorAssertion": return new SchemaHelperRel(s.Rels[65]);
				case "FactorReplacesFactor": return new SchemaHelperRel(s.Rels[66]);
				case "FactorUsesDescriptor": return new SchemaHelperRel(s.Rels[67]);
				case "FactorUsesDirector": return new SchemaHelperRel(s.Rels[68]);
				case "FactorUsesEventor": return new SchemaHelperRel(s.Rels[69]);
				case "FactorUsesIdentor": return new SchemaHelperRel(s.Rels[70]);
				case "FactorUsesLocator": return new SchemaHelperRel(s.Rels[71]);
				case "FactorUsesVector": return new SchemaHelperRel(s.Rels[72]);
				case "DescriptorUsesDescriptorType": return new SchemaHelperRel(s.Rels[73]);
				case "DescriptorRefinesPrimaryWithArtifact": return new SchemaHelperRel(s.Rels[74]);
				case "DescriptorRefinesRelatedWithArtifact": return new SchemaHelperRel(s.Rels[75]);
				case "DescriptorRefinesTypeWithArtifact": return new SchemaHelperRel(s.Rels[76]);
				case "DirectorUsesDirectorType": return new SchemaHelperRel(s.Rels[77]);
				case "DirectorUsesPrimaryDirectorAction": return new SchemaHelperRel(s.Rels[78]);
				case "DirectorUsesRelatedDirectorAction": return new SchemaHelperRel(s.Rels[79]);
				case "EventorUsesEventorType": return new SchemaHelperRel(s.Rels[80]);
				case "EventorUsesEventorPrecision": return new SchemaHelperRel(s.Rels[81]);
				case "IdentorUsesIdentorType": return new SchemaHelperRel(s.Rels[82]);
				case "LocatorUsesLocatorType": return new SchemaHelperRel(s.Rels[83]);
				case "VectorUsesAxisArtifact": return new SchemaHelperRel(s.Rels[84]);
				case "VectorUsesVectorType": return new SchemaHelperRel(s.Rels[85]);
				case "VectorUsesVectorUnit": return new SchemaHelperRel(s.Rels[86]);
				case "VectorUsesVectorUnitPrefix": return new SchemaHelperRel(s.Rels[87]);
				case "VectorTypeUsesVectorRange": return new SchemaHelperRel(s.Rels[88]);
				case "VectorRangeUsesVectorRangeLevel": return new SchemaHelperRel(s.Rels[89]);
				case "VectorUnitDerivedDefinesVectorUnit": return new SchemaHelperRel(s.Rels[90]);
				case "VectorUnitDerivedRaisesToExpVectorUnit": return new SchemaHelperRel(s.Rels[91]);
				case "VectorUnitDerivedUsesVectorUnitPrefix": return new SchemaHelperRel(s.Rels[92]);
				case "OauthAccessUsesApp": return new SchemaHelperRel(s.Rels[93]);
				case "OauthAccessUsesUser": return new SchemaHelperRel(s.Rels[94]);
				case "OauthDomainUsesApp": return new SchemaHelperRel(s.Rels[95]);
				case "OauthGrantUsesApp": return new SchemaHelperRel(s.Rels[96]);
				case "OauthGrantUsesUser": return new SchemaHelperRel(s.Rels[97]);
				case "OauthScopeUsesApp": return new SchemaHelperRel(s.Rels[98]);
				case "OauthScopeUsesUser": return new SchemaHelperRel(s.Rels[99]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetRels() {
			return new List<string> {
				"RootContainsApp",
				"RootContainsArtifact",
				"RootContainsArtifactType",
				"RootContainsCrowd",
				"RootContainsCrowdian",
				"RootContainsCrowdianType",
				"RootContainsCrowdianTypeAssign",
				"RootContainsEmail",
				"RootContainsLabel",
				"RootContainsMember",
				"RootContainsMemberType",
				"RootContainsMemberTypeAssign",
				"RootContainsThing",
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
				"AppHasArtifact",
				"AppUsesEmail",
				"AppDefinesMember",
				"ArtifactUsesArtifactType",
				"CrowdHasArtifact",
				"CrowdDefinesCrowdian",
				"CrowdianHasCrowdianTypeAssign",
				"CrowdianHasHistoricCrowdianTypeAssign",
				"CrowdianTypeAssignUsesCrowdianType",
				"LabelHasArtifact",
				"MemberHasMemberTypeAssign",
				"MemberHasHistoricMemberTypeAssign",
				"MemberCreatesArtifact",
				"MemberCreatesMemberTypeAssign",
				"MemberCreatesFactor",
				"MemberTypeAssignUsesMemberType",
				"ThingHasArtifact",
				"UrlHasArtifact",
				"UserHasArtifact",
				"UserCreatesCrowdianTypeAssign",
				"UserDefinesCrowdian",
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
				case "ArtifactOwnerNode": return new SchemaHelperNode(s.Nodes[2]);
				case "Root": return new SchemaHelperNode(s.Nodes[3]);
				case "App": return new SchemaHelperNode(s.Nodes[4]);
				case "Artifact": return new SchemaHelperNode(s.Nodes[5]);
				case "ArtifactType": return new SchemaHelperNode(s.Nodes[6]);
				case "Crowd": return new SchemaHelperNode(s.Nodes[7]);
				case "Crowdian": return new SchemaHelperNode(s.Nodes[8]);
				case "CrowdianType": return new SchemaHelperNode(s.Nodes[9]);
				case "CrowdianTypeAssign": return new SchemaHelperNode(s.Nodes[10]);
				case "Email": return new SchemaHelperNode(s.Nodes[11]);
				case "Label": return new SchemaHelperNode(s.Nodes[12]);
				case "Member": return new SchemaHelperNode(s.Nodes[13]);
				case "MemberType": return new SchemaHelperNode(s.Nodes[14]);
				case "MemberTypeAssign": return new SchemaHelperNode(s.Nodes[15]);
				case "Thing": return new SchemaHelperNode(s.Nodes[16]);
				case "Url": return new SchemaHelperNode(s.Nodes[17]);
				case "User": return new SchemaHelperNode(s.Nodes[18]);
				case "Factor": return new SchemaHelperNode(s.Nodes[19]);
				case "FactorAssertion": return new SchemaHelperNode(s.Nodes[20]);
				case "FactorElementNode": return new SchemaHelperNode(s.Nodes[21]);
				case "Descriptor": return new SchemaHelperNode(s.Nodes[22]);
				case "DescriptorType": return new SchemaHelperNode(s.Nodes[23]);
				case "Director": return new SchemaHelperNode(s.Nodes[24]);
				case "DirectorType": return new SchemaHelperNode(s.Nodes[25]);
				case "DirectorAction": return new SchemaHelperNode(s.Nodes[26]);
				case "Eventor": return new SchemaHelperNode(s.Nodes[27]);
				case "EventorType": return new SchemaHelperNode(s.Nodes[28]);
				case "EventorPrecision": return new SchemaHelperNode(s.Nodes[29]);
				case "Identor": return new SchemaHelperNode(s.Nodes[30]);
				case "IdentorType": return new SchemaHelperNode(s.Nodes[31]);
				case "Locator": return new SchemaHelperNode(s.Nodes[32]);
				case "LocatorType": return new SchemaHelperNode(s.Nodes[33]);
				case "Vector": return new SchemaHelperNode(s.Nodes[34]);
				case "VectorType": return new SchemaHelperNode(s.Nodes[35]);
				case "VectorRange": return new SchemaHelperNode(s.Nodes[36]);
				case "VectorRangeLevel": return new SchemaHelperNode(s.Nodes[37]);
				case "VectorUnit": return new SchemaHelperNode(s.Nodes[38]);
				case "VectorUnitPrefix": return new SchemaHelperNode(s.Nodes[39]);
				case "VectorUnitDerived": return new SchemaHelperNode(s.Nodes[40]);
				case "OauthAccess": return new SchemaHelperNode(s.Nodes[41]);
				case "OauthDomain": return new SchemaHelperNode(s.Nodes[42]);
				case "OauthGrant": return new SchemaHelperNode(s.Nodes[43]);
				case "OauthScope": return new SchemaHelperNode(s.Nodes[44]);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IList<string> GetNodes() {
			return new List<string> {
				"NodeForType",
				"NodeForAction",
				"ArtifactOwnerNode",
				"Root",
				"App",
				"Artifact",
				"ArtifactType",
				"Crowd",
				"Crowdian",
				"CrowdianType",
				"CrowdianTypeAssign",
				"Email",
				"Label",
				"Member",
				"MemberType",
				"MemberTypeAssign",
				"Thing",
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