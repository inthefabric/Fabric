using System;
using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public abstract class EdgeSchema {

		public enum EdgeQuantity {
			One,
			ZeroOrOne,
			Many,
		};

		public NameProvider Names { get; protected set; }
		public Type FromVertexType { get; private set; }
		public Type ToVertexType { get; private set; }
		public EdgeQuantity Quantity { get; private set; }

		public DomainProperty<long> ToVertexId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected EdgeSchema(Type pOutVertexType, Type pInVertexType, EdgeQuantity pQuantity) {
			FromVertexType = pOutVertexType;
			ToVertexType = pInVertexType;
			Quantity = pQuantity;

			ToVertexId = new DomainProperty<long>("VertexId", "N/A");
		}

	}


	/*================================================================================================*/
	public class EdgeSchema<TOut, TIn> : EdgeSchema
										where TOut : IVertexSchema where TIn : IVertexSchema, new() {

		protected TIn InVertex { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeSchema(EdgeQuantity pQuantity) : base(typeof(TOut), typeof(TIn), pQuantity) {
			InVertex = new TIn();
		}

	}

}