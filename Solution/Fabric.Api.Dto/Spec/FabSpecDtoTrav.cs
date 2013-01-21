using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDtoTrav : FabSpecDto {

		public List<FabSpecDtoTravLink> LinkList { get; set; }
		public List<string> FunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabSpecDtoTrav() {
			LinkList = new List<FabSpecDtoTravLink>();
			FunctionList = new List<string>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}