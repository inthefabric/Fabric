using System;
using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public abstract class EdgeSchema : IEdgeSchema {

		public enum EdgeQuantity {
			One,
			ZeroOrOne,
			ZeroOrMore,
		};

		public NameProvider Names { get; protected set; }
		public string TypeName { get; internal set; }
		public Type FromVertexType { get; private set; }
		public Type ToVertexType { get; private set; }
		public EdgeQuantity Quantity { get; private set; }

		public DomainProperty<long> ToVertexId { get; private set; }
		public Access CreateToVertexId { get; protected set; }
		public string SubObjectOf { get; protected set; }
		public bool CreateFromOtherDirection { get; protected set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected EdgeSchema(Type pOutVertexType, Type pInVertexType, EdgeQuantity pQuantity) {
			FromVertexType = pOutVertexType;
			ToVertexType = pInVertexType;
			Quantity = pQuantity;

			ToVertexId = new DomainProperty<long>("VertexId", "N/A");
			CreateToVertexId = Access.Internal;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IVertexSchema GetFromVertex() {
			return SchemaUtil.GetVertex(FromVertexType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVertexSchema GetToVertex() {
			return SchemaUtil.GetVertex(ToVertexType);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetOutgoingWeaverEdgeConn() {
			//On the edge's "outgoing" vertex...

			switch ( Quantity ) {
				case EdgeQuantity.One:
					//...there is ONE of this edge type
					return "OutOne";

				case EdgeQuantity.ZeroOrOne:
					//...there is ZERO OR ONE of this edge type
					return "OutZeroOrOne";

				case EdgeQuantity.ZeroOrMore:
					//...there is ZERO OR MORE of this edge type
					return "OutZeroOrMore";
			}

			return "UNKNOWN";
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetIncomingWeaverEdgeConn() {
			//On the edge's "incoming" vertex...
			
			//...this doesn't apply to Fabric, because all edges are uni-directional.
			return "InZeroOrMore";
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