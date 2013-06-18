// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 9:59:19 PM

using System;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public static class ApiDtoUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IFabVertex ToDto(DbDto pDbDto) {
			switch ( pDbDto.Class ) {
				case "Artifact": return ToDto<FabArtifact>(pDbDto);
				case "App": return ToDto<FabApp>(pDbDto);
				case "Class": return ToDto<FabClass>(pDbDto);
				case "Instance": return ToDto<FabInstance>(pDbDto);
				case "Member": return ToDto<FabMember>(pDbDto);
				case "MemberTypeAssign": return ToDto<FabMemberTypeAssign>(pDbDto);
				case "Url": return ToDto<FabUrl>(pDbDto);
				case "User": return ToDto<FabUser>(pDbDto);
				case "Factor": return ToDto<FabFactor>(pDbDto);
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
				case "MemberTypeAssign": return ToDtoJson<FabMemberTypeAssign>(pDbDto);
				case "Url": return ToDtoJson<FabUrl>(pDbDto);
				case "User": return ToDtoJson<FabUser>(pDbDto);
				case "Factor": return ToDtoJson<FabFactor>(pDbDto);
				default: throw new Exception("Unknown DbDto class: "+pDbDto.Class);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static T ToDto<T>(DbDto pDbDto) where T : IFabVertex, new() {
			var vertex = new T();
			vertex.Fill(pDbDto);
			return vertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ToDtoJson<T>(DbDto pDbDto) where T : IFabVertex, new() {
			var vertex = new T();
			vertex.Fill(pDbDto);
			return vertex.ToJson();
		}

	}

}