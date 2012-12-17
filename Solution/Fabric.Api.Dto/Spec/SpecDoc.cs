using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.Api.Dto.Spec.Lang;
using Fabric.Infrastructure;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {

		public string ApiVersion { get; set; }
		public SpecApiResponse ApiResponse { get; set; }
		public List<SpecDto> DtoList { get; set; }
		public List<SpecPathFunc> PathFunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecDoc() {
			ApiResponse = new SpecApiResponse();
			DtoList = BuildDtoList();
			DtoList.Insert(0, GetSpecDtoFabNode());
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Dictionary<string,SpecProperty> ReflectProps<T>() {
			PropertyInfo[] props = typeof(T).GetProperties();
			var results = new Dictionary<string,SpecProperty>();

			foreach ( PropertyInfo pi in props ) {
				var specProp = new SpecProperty();
				specProp.Name = pi.Name;
				specProp.Type = FabricUtil.GetTypeDisplayName(pi.PropertyType);
				specProp.Description = GetDtoPropText(typeof(T).Name.Substring(3)+"_"+pi.Name);
				results.Add(pi.Name, specProp);
			}

			return results;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoText(string pName) {
			string s = DtoText.ResourceManager.GetString(pName);
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetDtoPropText(string pName) {
			string s = DtoPropText.ResourceManager.GetString(pName);
			return (s ?? "MISSING:"+pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public SpecDto GetSpecDto(string pName) {
			foreach ( SpecDto dto in DtoList ) {
				if ( dto.Name == pName ) { return dto; }
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private SpecDto GetSpecDtoFabNode() {
			var sd = new SpecDto();
			sd.Name = typeof(FabNode).Name;
			sd.Description = GetDtoText(sd.Name.Substring(3));
			sd.Abstract = sd.Description.Substring(0, sd.Description.IndexOf('.')+1);

			Dictionary<string, SpecProperty> propMap = ReflectProps<FabNode>();
			sd.PropertyList = propMap.Values.ToList();
			return sd;
		}

	}

}