namespace Fabric.New.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabMetaVersion : FabObject {

		public string Version { get; private set; }
		public int Major { get; private set; }
		public int Minor { get; private set; }
		public int Patch { get; private set; }
		public string Revision { get; private set; }

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
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetDate(int pYear, int pMonth, int pDay) {
			Year = pYear;
			Month = pMonth;
			Day = pDay;
		}

	}

}