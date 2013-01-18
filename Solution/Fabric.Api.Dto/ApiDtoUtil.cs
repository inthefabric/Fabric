// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/18/2013 4:27:06 PM

using System;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public static class ApiDtoUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string ToDtoJson(DbDto pDbDto) {
			switch ( pDbDto.Class ) {
				case "Root": return ToDtoJson<FabRoot>(pDbDto);
				case "App": return ToDtoJson<FabApp>(pDbDto);
				case "Artifact": return ToDtoJson<FabArtifact>(pDbDto);
				case "ArtifactType": return ToDtoJson<FabArtifactType>(pDbDto);
				case "Crowd": return ToDtoJson<FabCrowd>(pDbDto);
				case "Crowdian": return ToDtoJson<FabCrowdian>(pDbDto);
				case "CrowdianType": return ToDtoJson<FabCrowdianType>(pDbDto);
				case "CrowdianTypeAssign": return ToDtoJson<FabCrowdianTypeAssign>(pDbDto);
				case "Label": return ToDtoJson<FabLabel>(pDbDto);
				case "Member": return ToDtoJson<FabMember>(pDbDto);
				case "MemberType": return ToDtoJson<FabMemberType>(pDbDto);
				case "MemberTypeAssign": return ToDtoJson<FabMemberTypeAssign>(pDbDto);
				case "Thing": return ToDtoJson<FabThing>(pDbDto);
				case "Url": return ToDtoJson<FabUrl>(pDbDto);
				case "User": return ToDtoJson<FabUser>(pDbDto);
				case "Factor": return ToDtoJson<FabFactor>(pDbDto);
				case "FactorAssertion": return ToDtoJson<FabFactorAssertion>(pDbDto);
				case "Descriptor": return ToDtoJson<FabDescriptor>(pDbDto);
				case "DescriptorType": return ToDtoJson<FabDescriptorType>(pDbDto);
				case "Director": return ToDtoJson<FabDirector>(pDbDto);
				case "DirectorType": return ToDtoJson<FabDirectorType>(pDbDto);
				case "DirectorAction": return ToDtoJson<FabDirectorAction>(pDbDto);
				case "Eventor": return ToDtoJson<FabEventor>(pDbDto);
				case "EventorType": return ToDtoJson<FabEventorType>(pDbDto);
				case "EventorPrecision": return ToDtoJson<FabEventorPrecision>(pDbDto);
				case "Identor": return ToDtoJson<FabIdentor>(pDbDto);
				case "IdentorType": return ToDtoJson<FabIdentorType>(pDbDto);
				case "Locator": return ToDtoJson<FabLocator>(pDbDto);
				case "LocatorType": return ToDtoJson<FabLocatorType>(pDbDto);
				case "Vector": return ToDtoJson<FabVector>(pDbDto);
				case "VectorType": return ToDtoJson<FabVectorType>(pDbDto);
				case "VectorRange": return ToDtoJson<FabVectorRange>(pDbDto);
				case "VectorRangeLevel": return ToDtoJson<FabVectorRangeLevel>(pDbDto);
				case "VectorUnit": return ToDtoJson<FabVectorUnit>(pDbDto);
				case "VectorUnitPrefix": return ToDtoJson<FabVectorUnitPrefix>(pDbDto);
				case "VectorUnitDerived": return ToDtoJson<FabVectorUnitDerived>(pDbDto);
				default: throw new Exception("Unknown DbDto class: "+pDbDto.Class);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ToDtoJson<T>(DbDto pDbDto) where T : IFabNode, new() {
			var node = new T();
			node.Fill(pDbDto);
			return node.ToJson();
		}

	}

}