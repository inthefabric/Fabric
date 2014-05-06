namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class LocatorTypeSchema : EnumSchema {

		//When converted to strings, these reduced bounds won't cause Java/Gremlin overflow issues
		public const double DoubleMin = double.MinValue+1E+294;
		public const double DoubleMax = double.MaxValue-1E+294;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeSchema() : base("LocatorType") {
			AddCoord(1, "EarthCoord", "Earth Coordinate",
				"A coordinate position on Earth.Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).");
			
			AddCoord(2, "MoonCoord", "Moon Coordinate",
				"A coordinate position on Earth's Moon.Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).");

			AddCoord(3, "MarsCoord", "Mars Coordinate",
				"A coordinate position on Mars.Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).");
			
			AddItem(4, "RelPos1D", "Relative Position 1D",
				"A one-dimensional position, using X=Time. A position is relative to the Artifact's dimensions. For example, X=0.25 represents a position (starting from the origin) that is 25% of the distance to the maximum X dimension.",
				DoubleMin, DoubleMax, 0, 0, 0, 0);
			
			AddItem(5, "RelPos2D", "Relative Position 2D",
				"A two-dimensional position, using X=Width and Y=Height. A position is relative to the Artifact's dimensions. For example, X=0.25 represents a position (starting from the origin) that is 25% of the distance to the maximum X dimension.",
				DoubleMin, DoubleMax, DoubleMin, DoubleMax, 0, 0);
			
			AddItem(6, "RelPos3D", "Relative Position 3D",
				"A three-dimensional position, using X, Y, and Z axes. A position is relative to the Artifact's dimensions. For example, X=0.25 represents a position (starting from the origin) that is 25% of the distance to the maximum X dimension.",
				DoubleMin, DoubleMax, DoubleMin, DoubleMax, DoubleMin, DoubleMax);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddItem(byte pId, string pEnumId, string pName, string pDesc, double pMinX,
								double pMaxX, double pMinY, double pMaxY, double pMinZ, double pMaxZ) {
			Items.Add(new LocatorTypeItemSchema(
				pId, pEnumId, pName, pDesc, pMinX, pMaxX, pMinY, pMaxY, pMinZ, pMaxZ));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddCoord(byte pId, string pEnumId, string pName, string pDesc) {
			AddItem(pId, pEnumId, pName,
				pDesc+"Coordinates use X=Longitude, Y=Latitude, and Z=Elevation "+
				"(in metres).", -180, 180, -90, 90, DoubleMin, DoubleMax);
		}

	}

	
	/*================================================================================================*/
	public class LocatorTypeItemSchema : EnumItemSchema {

		public double MinX { get; private set; }
		public double MaxX { get; private set; }
		public double MinY { get; private set; }
		public double MaxY { get; private set; }
		public double MinZ { get; private set; }
		public double MaxZ { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeItemSchema(byte pId, string pEnumId, string pName, string pDesc, double pMinX,
								double pMaxX, double pMinY, double pMaxY, double pMinZ, double pMaxZ) :
			base(pId, pEnumId, pName, pDesc) {
			MinX = pMinX;
			MaxX = pMaxX;
			MinY = pMinY;
			MaxY = pMaxY;
			MinZ = pMinZ;
			MaxZ = pMaxZ;
		}

	}

}