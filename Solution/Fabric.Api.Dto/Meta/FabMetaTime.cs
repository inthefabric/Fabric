using System;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabMetaTime : FabObject {

		private static readonly DateTime UnixEpoch =
			new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public int Year { get; private set; }
		public int Month { get; private set; }
		public int Day { get; private set; }
		public int Hour { get; private set; }
		public int Minute { get; private set; }
		public int Second { get; private set; }
		public double Millisecond { get; private set; }

		public long Ticks { get; private set; }
		public long Unix { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMetaTime() {
			var d = DateTime.UtcNow;
			
			Year = d.Year;
			Month = d.Month;
			Day = d.Day;
			Hour = d.Hour;
			Minute = d.Minute;
			Second = d.Second;
			Millisecond = d.Millisecond + (d.Ticks % 10000)/10000.0;

			Ticks = d.Ticks;
			Unix = (long)(DateTime.UtcNow-UnixEpoch).TotalMilliseconds;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}

}