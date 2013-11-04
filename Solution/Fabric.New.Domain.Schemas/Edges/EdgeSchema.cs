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
	public class EdgeSchema<TFrom, TTo> : EdgeSchema
												where TFrom : IVertexSchema where TTo : IVertexSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected EdgeSchema(EdgeQuantity pQuantity) : base(typeof(TFrom), typeof(TTo), pQuantity) {}

		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty<TTo, TDataType> Prop<TDataType>(string pName, string pDbName, 
													Func<TTo, DomainProperty<TDataType>> pDomPropFunc) {
			return new EdgeProperty<TTo, TDataType>(pName, pDbName, pDomPropFunc);
		}

		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty<TTo, TEdge, TDataType> Prop<TEdge, TDataType>(string pName, string pDbName,
					Func<TTo, TEdge> pEdgeFunc, Func<TEdge, DomainProperty<TDataType>> pEdgeDomPropFunc)
					where TEdge : EdgeSchema {
			return new EdgeProperty<TTo, TEdge, TDataType>(pName, pDbName, pEdgeFunc, pEdgeDomPropFunc);
		}

	}

}