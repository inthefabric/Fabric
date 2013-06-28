using System.Collections.Generic;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabSpecServiceOperation : FabObject {

		public string Name { get; set; }
		public string Uri { get; set; }
		public string Method { get; set; }
		public string ReturnType { get; set; }
		public string Description { get; set; }

		public string RequiredAuth { get; set; }
		public string AuthMemberOwns { get; set; }
		public List<FabSpecServiceOperationParam> Parameters { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}

}