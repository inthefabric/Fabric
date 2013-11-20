using System;
using Fabric.New.Domain.Schemas.Edges;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class EdgeProperty {

		public enum SortType {
			None,
			Asc,
			Desc
		};

		public string Name { get; private set; }
		public string DbName { get; private set; }
		public Type DataType { get; private set; }
		public Type ApiDataType { get; private set; }
		public SortType Sort { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, Type pDataType, Type pApiDataType) {
			Name = pName;
			DbName = pDbName;
			DataType = pDataType;
			ApiDataType = pApiDataType;
			Sort = SortType.None;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract IEdgeSchema GetEdgeToDomainProp();
		public abstract DomainProperty GetDomainProp();
		public abstract ApiProperty GetApiProp();


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

		/*--------------------------------------------------------------------------------------------*/
		public string GetApiDataTypeName() {
			switch ( ApiDataType.Name ) {
				case "Byte":
					return "byte";

				case "Int64":
					return "long";

				case "Single":
					return "float";

				default:
					return null;
			}
		}

	}


	/*================================================================================================*/
	public class EdgeProperty<TToVert, TDataType, TApiDataType> : EdgeProperty 
																		where TToVert : IVertexSchema {

		private readonly Func<TToVert, DomainProperty<TDataType>> vDomPropFunc;
		private readonly Func<TToVert, ApiProperty<TApiDataType>> vApiPropFunc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, 
						Func<TToVert, DomainProperty<TDataType>> pDomPropFunc,
						Func<TToVert, ApiProperty<TApiDataType>> pApiPropFunc) : 
						base(pName, pDbName, typeof(TDataType), typeof(TApiDataType)) {
			vDomPropFunc = pDomPropFunc;
			vApiPropFunc = pApiPropFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IEdgeSchema GetEdgeToDomainProp() {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override DomainProperty GetDomainProp() {
			return vDomPropFunc(SchemaUtil.GetVertex<TToVert>());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override ApiProperty GetApiProp() {
			return vApiPropFunc(SchemaUtil.GetVertex<TToVert>());
		}

	}


	/*================================================================================================*/
	public class EdgeProperty<TToVert, TEdge, TDataType, TApiDataType> : EdgeProperty 
											where TToVert : IVertexSchema where TEdge : IEdgeSchema {

		private readonly Func<TEdge, DomainProperty<TDataType>> vEdgeDomPropFunc;
		private readonly Func<TEdge, ApiProperty<TApiDataType>> vEdgeApiPropFunc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName,
										Func<TEdge, DomainProperty<TDataType>> pEdgeDomPropFunc,
										Func<TEdge, ApiProperty<TApiDataType>> pEdgeApiPropFunc) :
										base(pName, pDbName, typeof(TDataType), typeof(TApiDataType)) {
			vEdgeDomPropFunc = pEdgeDomPropFunc;
			vEdgeApiPropFunc = pEdgeApiPropFunc;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override IEdgeSchema GetEdgeToDomainProp() {
			return SchemaUtil.GetEdge<TEdge>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override DomainProperty GetDomainProp() {
			return vEdgeDomPropFunc((TEdge)GetEdgeToDomainProp());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override ApiProperty GetApiProp() {
			return vEdgeApiPropFunc((TEdge)GetEdgeToDomainProp());
		}

	}

}