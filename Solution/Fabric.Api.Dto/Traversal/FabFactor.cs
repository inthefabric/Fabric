using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public partial class FabFactor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		partial void FillResultDataHook(IDictionary<string,string> pData) {
		}

		/*--------------------------------------------------------------------------------------------*/
		partial void FillWithVertexHook(Factor pVertex) {
			if ( pVertex.Eventor_DateTime != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				
				long y;
				byte? mo, d, h, mi, s;

				FabricUtil.EventorLongToTimes((long)pVertex.Eventor_DateTime,
					out y, out mo, out d, out h, out mi, out s);

				Eventor.Year = y;
				Eventor.Month = mo;
				Eventor.Day = d;
				Eventor.Hour = h;
				Eventor.Minute = mi;
				Eventor.Second = s;
			}
		}
		
	}

}