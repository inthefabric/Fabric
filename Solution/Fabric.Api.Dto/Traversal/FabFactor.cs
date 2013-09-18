using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public partial class FabFactor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		partial void FillResultDataHook(IDictionary<string,string> pData) {
			string val;

			if ( pData.TryGetValue(PropDbName.Factor_Eventor_DateTime, out val) ) {
				BuildEventorTimes(long.Parse(val));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		partial void FillWithVertexHook(Factor pVertex) {
			if ( pVertex.Eventor_DateTime != null ) {
				BuildEventorTimes((long)pVertex.Eventor_DateTime);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void BuildEventorTimes(long pDateTime) {
			if ( Eventor == null ) {
				Eventor = new FabEventor();
			}

			long y;
			byte? mo, d, h, mi, s;

			FabricUtil.EventorLongToTimes(pDateTime, out y, out mo, out d, out h, out mi, out s);

			Eventor.Year = y;
			Eventor.Month = mo;
			Eventor.Day = d;
			Eventor.Hour = h;
			Eventor.Minute = mi;
			Eventor.Second = s;
		}
		
	}

}