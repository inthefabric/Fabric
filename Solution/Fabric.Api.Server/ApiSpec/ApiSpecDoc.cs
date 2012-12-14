using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

namespace Fabric.Api.Server.ApiSpec {

	/*================================================================================================*/
	public partial class ApiSpecDoc {

		public string ApiVersion { get; set; }
		public ApiSpecApiResponse ApiResponse { get; set; }
		public List<ApiSpecDto> DtoList { get; set; }
		public List<ApiSpecPathFunc> PathFunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecDoc() {
			ApiVersion = ApiModule.ApiVersion;
			ApiResponse = new ApiSpecApiResponse();
			DtoList = BuildDtoList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Dictionary<string,ApiSpecProperty> ReflectProps<T>() {
			PropertyInfo[] props = typeof(T).GetProperties();
			var results = new Dictionary<string,ApiSpecProperty>();

			foreach ( PropertyInfo pi in props ) {
				var specProp = new ApiSpecProperty();
				specProp.Name = pi.Name;
				specProp.Type = FabricUtil.GetTypeDisplayName(pi.PropertyType);
				results.Add(pi.Name, specProp);
			}

			return results;
		}

	}

	/*================================================================================================*/
	public class ApiSpecApiResponse : ApiSpecDto {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecApiResponse() {
			Name = typeof(FabResponse).Name;
			Abstract = "The API response wrapper; contains the Data payload and other metadata.";
			Description = "TODO";

			Dictionary<string,ApiSpecProperty> propMap = ApiSpecDoc.ReflectProps<FabResponse>();
			PropertyList = propMap.Values.ToList();
		}

	}
	
	/*================================================================================================*/
	public class ApiSpecPathFunc {

		public List<ApiSpecProperty> ParameterList { get; set; }

	}

	/*================================================================================================*/
	public class ApiSpecDto {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Abstract { get; set; }
		public string Description { get; set; }
		public List<ApiSpecProperty> PropertyList { get; set; }
		public List<ApiSpecLink> LinkList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiSpecDto() {
			PropertyList = new List<ApiSpecProperty>();
			LinkList = new List<ApiSpecLink>();
		}

	}

	/*================================================================================================*/
	public class ApiSpecProperty {

		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public bool? IsCaseInsensitive { get; set; }
		public bool? IsNullable { get; set; }
		public bool? IsPrimaryKey { get; set; }
		public bool? IsTimestamp { get; set; }
		public bool? IsUnique { get; set; }

		public int? Len { get; set; }
		public int? LenMax { get; set; }
		public int? LenMin { get; set; }
		public string ValidRegex { get; set; }

	}

	/*================================================================================================*/
	public class ApiSpecLink {

		public string Name { get; set; }
		public bool IsOutgoing { get; set; }
		public string FromDto { get; set; }
		public string FromDtoConn { get; set; }
		public string Verb { get; set; }
		public string ToDto { get; set; }
		public string ToDtoConn { get; set; }

	}

}