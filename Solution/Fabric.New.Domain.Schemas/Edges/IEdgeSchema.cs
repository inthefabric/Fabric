using System;
using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public interface IEdgeSchema {

		NameProvider Names { get; }
		string TypeName { get; }
		Type FromVertexType { get; }
		Type ToVertexType { get; }
		EdgeSchema.EdgeQuantity Quantity { get; }

		DomainProperty<long> ToVertexId { get; }
		Access CreateToVertexId { get; }
		string SubObjectOf { get; }
		bool CreateFromOtherDirection { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IVertexSchema GetFromVertex();

		/*--------------------------------------------------------------------------------------------*/
		IVertexSchema GetToVertex();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetOutgoingWeaverEdgeConn();

		/*--------------------------------------------------------------------------------------------*/
		string GetIncomingWeaverEdgeConn();

	}

}