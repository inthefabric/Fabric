using System;
using Fabric.New.Domain.Schemas.Edges;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class EdgeProperty {

		public string Name { get; private set; }
		public string DbName { get; private set; }
		public Type DataType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, Type pDataType) {
			Name = pName;
			DbName = pDbName;
			DataType = pDataType;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract IEdgeSchema GetEdgeToDomainProp();
		public abstract DomainProperty GetDomainProp();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string GetDataTypeName() {
			switch ( DataType.Name ) {
				case "Byte":
					return "byte";

				case "Int64":
					return "long";

				default:
					return null;
			}
		}

	}


	/*================================================================================================*/
	public class EdgeProperty<TToVert, TDataType> : EdgeProperty where TToVert : IVertexSchema {

		private readonly Func<TToVert, DomainProperty<TDataType>> vDomPropFunc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, 
						Func<TToVert, DomainProperty<TDataType>> pDomPropFunc) : 
						base(pName, pDbName, typeof(TDataType)) {
			vDomPropFunc = pDomPropFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IEdgeSchema GetEdgeToDomainProp() {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override DomainProperty GetDomainProp() {
			return vDomPropFunc(SchemaUtil.GetVertex<TToVert>());
		}

	}


	/*================================================================================================*/
	public class EdgeProperty<TToVert, TEdge, TDataType> : EdgeProperty 
											where TToVert : IVertexSchema where TEdge : IEdgeSchema {

		private readonly Func<TToVert, TEdge> vEdgeFunc;
		private readonly Func<TEdge, DomainProperty<TDataType>> vEdgeDomPropFunc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName,
											Func<TToVert, TEdge> pEdgeFunc, 
											Func<TEdge, DomainProperty<TDataType>> pEdgeDomPropFunc) :
											base(pName, pDbName, typeof(TDataType)) {
			vEdgeFunc = pEdgeFunc;
			vEdgeDomPropFunc = pEdgeDomPropFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IEdgeSchema GetEdgeToDomainProp() {
			return vEdgeFunc(SchemaUtil.GetVertex<TToVert>());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override DomainProperty GetDomainProp() {
			return vEdgeDomPropFunc((TEdge)GetEdgeToDomainProp());
		}

	}

}