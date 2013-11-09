﻿using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class ArtifactSchema : VertexSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactSchema() {
			Names = new NameProvider("Artifact", "Artifacts", "a");
		}

	}

}