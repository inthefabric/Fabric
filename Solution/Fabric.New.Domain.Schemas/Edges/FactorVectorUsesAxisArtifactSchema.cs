﻿using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorVectorUsesAxisArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorVectorUsesAxisArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			SetNames("VectorUsesAxis", "a", "UsesAxis");
			CreateToVertexId = Access.All;
			SubObjectOf = "FabVector";
		}

	}

}