using System;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Meta {

	/*================================================================================================*/
	public class FabMetaVersion : FabObject {

		public string Version { get; private set; }
		public int Major { get; private set; }
		public int Minor { get; private set; }
		public int Patch { get; private set; }
		public string Revision { get; private set; }

		public long Timestamp { get; private set; }
		public int Year { get; private set; }
		public int Month { get; private set; }
		public int Day { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetBuild(int pMajor, int pMinor, int pPatch, string pRevision) {
			Major = pMajor;
			Minor = pMinor;
			Patch = pPatch;
			Revision = pRevision;
			Version = Major+"."+Minor+"."+Patch+"."+Revision;

			var d = DateTime.UtcNow;
			Timestamp = d.Ticks;
			Year = d.Year;
			Month = d.Month;
			Day = d.Day;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}