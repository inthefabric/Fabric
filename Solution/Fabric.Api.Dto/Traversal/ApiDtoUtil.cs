// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/28/2013 8:32:40 AM

using System;
using Fabric.Infrastructure.Data;
using ServiceStack.Text;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public static class ApiDtoUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IFabVertex ToVertex(IDataDto pDto) {
			switch ( pDto.Class ) {
				case "Artifact": return ToVertex<FabArtifact>(pDto);
				case "App": return ToVertex<FabApp>(pDto);
				case "Class": return ToVertex<FabClass>(pDto);
				case "Instance": return ToVertex<FabInstance>(pDto);
				case "Member": return ToVertex<FabMember>(pDto);
				case "MemberTypeAssign": return ToVertex<FabMemberTypeAssign>(pDto);
				case "Url": return ToVertex<FabUrl>(pDto);
				case "User": return ToVertex<FabUser>(pDto);
				case "Factor": return ToVertex<FabFactor>(pDto);
				default: throw new Exception("Unknown DbDto class: "+pDto.Class);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string ToVertexJson(IDataDto pDto) {
			switch ( pDto.Class ) {
				case "Artifact": return ToVertexJson<FabArtifact>(pDto);
				case "App": return ToVertexJson<FabApp>(pDto);
				case "Class": return ToVertexJson<FabClass>(pDto);
				case "Instance": return ToVertexJson<FabInstance>(pDto);
				case "Member": return ToVertexJson<FabMember>(pDto);
				case "MemberTypeAssign": return ToVertexJson<FabMemberTypeAssign>(pDto);
				case "Url": return ToVertexJson<FabUrl>(pDto);
				case "User": return ToVertexJson<FabUser>(pDto);
				case "Factor": return ToVertexJson<FabFactor>(pDto);
				default: throw new Exception("Unknown IDataDto class: "+pDto.Class);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static T ToVertex<T>(IDataDto pDto) where T : IFabVertex, new() {
			var vertex = new T();
			vertex.Fill(pDto);
			return vertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ToVertexJson<T>(IDataDto pDto) where T : IFabVertex, new() {
			var vertex = new T();
			vertex.Fill(pDto);
			return vertex.ToJson();
		}

	}

}