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

		public enum SortType {
			None,
			Asc,
			Desc
		};

		public string NameDom { get; private set; }
		public string NameApi { get; private set; }
		public string NameDb { get; private set; }
		public Type FromVertexType { get; private set; }
		public Type ToVertexType { get; private set; }
		public EdgeQuantity Quantity { get; private set; }
		public SortType Sort { get; internal set; }

		public DomainProperty<long> ToVertexId { get; private set; }
		public ApiProperty<long> FabToVertexId { get; private set; }
		public string SubObjectOf { get; protected set; }
		public Type CreateFromOtherDirection { get; protected set; }
		public bool CreateInternal { get; protected set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected EdgeSchema(Type pOutVertexType, Type pInVertexType, EdgeQuantity pQuantity) {
			FromVertexType = pOutVertexType;
			ToVertexType = pInVertexType;
			Quantity = pQuantity;
			Sort = SortType.None;

			ToVertexId = new DomainProperty<long>("VertexId", "N/A");
			ToVertexId.IsUnique = true;

			FabToVertexId = new ApiProperty<long>("VertexId");
			FabToVertexId.IsUnique = true;
			FabToVertexId.CreateAccess = Access.Internal;
			FabToVertexId.TraversalHas = Matching.Exact;
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
		public string GetClassNameApi(bool pWithId=true) {
			string name = GetFromVertex().Names.Api+GetPropNameApi();

			if ( !pWithId ) {
				name = name.Substring(0, name.Length-2);
			}

			return name;
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
		protected EdgeProperty<TTo, TDataType, TApiDataType> Prop<TDataType, TApiDataType>(
						string pName, string pDbName, Func<TTo, DomainProperty<TDataType>> pDomPropFunc,
						Func<TTo, ApiProperty<TApiDataType>> pApiPropFunc) {
			return new EdgeProperty<TTo, TDataType, TApiDataType>(
				pName, NameDb+"_"+pDbName, pDomPropFunc, pApiPropFunc);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected EdgeProperty<TTo, TEdge, long, long> PropFromEdge<TEdge>(string pName, string pDbName)
																			where TEdge : EdgeSchema {
			return new EdgeProperty<TTo, TEdge, long, long>(
				pName, NameDb+"_"+pDbName, (x => x.ToVertexId), (x => x.FabToVertexId));
		}

	}

}