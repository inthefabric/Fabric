﻿using System;
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

		public string NameDom { get; private set; }
		public string NameApi { get; private set; }
		public string NameDb { get; private set; }
		public Type FromVertexType { get; private set; }
		public Type ToVertexType { get; private set; }
		public EdgeQuantity Quantity { get; private set; }

		public DomainProperty<long> ToVertexId { get; private set; }
		public Access CreateToVertexId { get; protected set; }
		public string SubObjectOf { get; protected set; }
		public Type CreateFromOtherDirection { get; protected set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected EdgeSchema(Type pOutVertexType, Type pInVertexType, EdgeQuantity pQuantity) {
			FromVertexType = pOutVertexType;
			ToVertexType = pInVertexType;
			Quantity = pQuantity;

			ToVertexId = new DomainProperty<long>("VertexId", "N/A");
			CreateToVertexId = Access.Internal;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void SetNames(string pNameDomain, string pNameDb, string pNameApi=null) {
			NameDom = pNameDomain;
			NameDb = GetFromVertex().Names.Database+pNameDb+GetToVertex().Names.Database;
			NameApi = (pNameApi ?? pNameDomain);
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
		public bool GetIsOptional() {
			return (Quantity == EdgeQuantity.ZeroOrOne || Quantity == EdgeQuantity.ZeroOrMore);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool GetIsMultiple() {
			return (Quantity == EdgeQuantity.ZeroOrMore);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetClassNameDom() {
			return GetFromVertex().Names.Domain+GetPropNameDom();
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetClassNameApi() {
			return GetFromVertex().Names.Api+GetPropNameApi();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public string GetPropNameDom(bool pPlural=false) {
			NameProvider np = GetToVertex().Names;
			return NameDom+(pPlural ? np.DomainPlural : np.Domain);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetPropNameApi(bool pPlural=false) {
			NameProvider np = GetToVertex().Names;
			return NameApi+(pPlural ? np.ApiPlural : np.Api).Substring(3)+"Id";
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetPropNameLink() {
			NameProvider np = GetToVertex().Names;
			return NameApi+(GetIsMultiple() ? np.ApiPlural : np.Api).Substring(3);
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
		protected EdgeProperty<TTo, TDataType> Prop<TDataType>(string pName, string pDbName, 
													Func<TTo, DomainProperty<TDataType>> pDomPropFunc) {
			return new EdgeProperty<TTo, TDataType>(pName, NameDb+"."+pDbName, pDomPropFunc);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected EdgeProperty<TTo, TEdge, long> PropFromEdge<TEdge>(string pName, string pDbName)
																			where TEdge : EdgeSchema {
			return new EdgeProperty<TTo, TEdge, long>(pName, NameDb+"."+pDbName, (x => x.ToVertexId));
		}

	}

}