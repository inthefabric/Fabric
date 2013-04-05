// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/4/2013 5:12:46 PM

using System;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public static class ApiDtoUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IFabNode ToDto(DbDto pDbDto) {
			switch ( pDbDto.Class ) {
				case "Artifact": return ToDto<FabArtifact>(pDbDto);
				case "App": return ToDto<FabApp>(pDbDto);
				case "Class": return ToDto<FabClass>(pDbDto);
				case "Instance": return ToDto<FabInstance>(pDbDto);
				case "Member": return ToDto<FabMember>(pDbDto);
				case "MemberType": return ToDto<FabMemberType>(pDbDto);
				case "MemberTypeAssign": return ToDto<FabMemberTypeAssign>(pDbDto);
				case "Url": return ToDto<FabUrl>(pDbDto);
				case "User": return ToDto<FabUser>(pDbDto);
				case "Factor": return ToDto<FabFactor>(pDbDto);
				case "FactorAssertion": return ToDto<FabFactorAssertion>(pDbDto);
				case "Descriptor": return ToDto<FabDescriptor>(pDbDto);
				case "DescriptorType": return ToDto<FabDescriptorType>(pDbDto);
				case "Director": return ToDto<FabDirector>(pDbDto);
				case "DirectorType": return ToDto<FabDirectorType>(pDbDto);
				case "DirectorAction": return ToDto<FabDirectorAction>(pDbDto);
				case "Eventor": return ToDto<FabEventor>(pDbDto);
				case "EventorType": return ToDto<FabEventorType>(pDbDto);
				case "EventorPrecision": return ToDto<FabEventorPrecision>(pDbDto);
				case "Identor": return ToDto<FabIdentor>(pDbDto);
				case "IdentorType": return ToDto<FabIdentorType>(pDbDto);
				case "Locator": return ToDto<FabLocator>(pDbDto);
				case "LocatorType": return ToDto<FabLocatorType>(pDbDto);
				case "Vector": return ToDto<FabVector>(pDbDto);
				case "VectorType": return ToDto<FabVectorType>(pDbDto);
				case "VectorRange": return ToDto<FabVectorRange>(pDbDto);
				case "VectorRangeLevel": return ToDto<FabVectorRangeLevel>(pDbDto);
				case "VectorUnit": return ToDto<FabVectorUnit>(pDbDto);
				case "VectorUnitPrefix": return ToDto<FabVectorUnitPrefix>(pDbDto);
				case "VectorUnitDerived": return ToDto<FabVectorUnitDerived>(pDbDto);
				default: throw new Exception("Unknown DbDto class: "+pDbDto.Class);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string ToDtoJson(DbDto pDbDto) {
			switch ( pDbDto.Class ) {
				case "Artifact": return ToDtoJson<FabArtifact>(pDbDto);
				case "App": return ToDtoJson<FabApp>(pDbDto);
				case "Class": return ToDtoJson<FabClass>(pDbDto);
				case "Instance": return ToDtoJson<FabInstance>(pDbDto);
				case "Member": return ToDtoJson<FabMember>(pDbDto);
				case "MemberType": return ToDtoJson<FabMemberType>(pDbDto);
				case "MemberTypeAssign": return ToDtoJson<FabMemberTypeAssign>(pDbDto);
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
		private static T ToDto<T>(DbDto pDbDto) where T : IFabNode, new() {
			var node = new T();
			node.Fill(pDbDto);
			return node;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ToDtoJson<T>(DbDto pDbDto) where T : IFabNode, new() {
			var node = new T();
			node.Fill(pDbDto);
			return node.ToJson();
		}

	}

}