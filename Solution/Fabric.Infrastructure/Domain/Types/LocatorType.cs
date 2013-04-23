namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public class LocatorType : BaseType<LocatorTypeId> {

		public double MinX { get; private set; }
		public double MaxX { get; private set; }
		public double MinY { get; private set; }
		public double MaxY { get; private set; }
		public double MinZ { get; private set; }
		public double MaxZ { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorType(LocatorTypeId pEnumId, string pName, string pDesc, double pMinX,double pMaxX,
				double pMinY, double pMaxY, double pMinZ, double pMaxZ) : base(pEnumId, pName, pDesc) {
			MinX = pMinX;
			MaxX = pMaxX;
			MinY = pMinY;
			MaxY = pMaxY;
			MinZ = pMinZ;
			MaxZ = pMaxZ;
		}

	}

}