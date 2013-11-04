using System;
using Fabric.New.Domain.Schemas.Edges;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class EdgeProperty {

		public string Name { get; internal set; }
		public string DbName { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName) {
			Name = pName;
			DbName = pDbName;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract EdgeSchema GetEdgeToDomainProp();
		public abstract DomainProperty GetDomainProp();

	}


	/*================================================================================================*/
	public class EdgeProperty<TToVert, TDataType> : EdgeProperty where TToVert : IVertexSchema {

		private readonly Func<TToVert, DomainProperty<TDataType>> vDomPropFunc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, 
						Func<TToVert, DomainProperty<TDataType>> pDomPropFunc) : base(pName, pDbName) {
			vDomPropFunc = pDomPropFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override EdgeSchema GetEdgeToDomainProp() {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override DomainProperty GetDomainProp() {
			return vDomPropFunc(SchemaUtil.GetVertex<TToVert>());
		}

	}


	/*================================================================================================*/
	public class EdgeProperty<TToVert, TEdge, TDataType> : EdgeProperty 
												where TToVert : IVertexSchema where TEdge : EdgeSchema {

		private readonly Func<TToVert, TEdge> vEdgeFunc;
		private readonly Func<TEdge, DomainProperty<TDataType>> vEdgeDomPropFunc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName,
											Func<TToVert, TEdge> pEdgeFunc, 
											Func<TEdge, DomainProperty<TDataType>> pEdgeDomPropFunc) :
											base(pName, pDbName) {
			vEdgeFunc = pEdgeFunc;
			vEdgeDomPropFunc = pEdgeDomPropFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override EdgeSchema GetEdgeToDomainProp() {
			return vEdgeFunc(SchemaUtil.GetVertex<TToVert>());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override DomainProperty GetDomainProp() {
			return vEdgeDomPropFunc((TEdge)GetEdgeToDomainProp());
		}

	}

}