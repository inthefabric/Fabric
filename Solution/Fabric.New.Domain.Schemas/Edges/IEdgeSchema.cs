﻿using System;
using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public interface IEdgeSchema {

		string NameDom { get; }
		string NameApi { get; }
		string NameDb { get; }
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
		string GetClassNameDom();

		/*--------------------------------------------------------------------------------------------*/
		string GetClassNameApi();

		/*--------------------------------------------------------------------------------------------*/
		string GetPropNameDom(bool pPlural=false);

		/*--------------------------------------------------------------------------------------------*/
		string GetPropNameApi(bool pPlural=false);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetOutgoingWeaverEdgeConn();

		/*--------------------------------------------------------------------------------------------*/
		string GetIncomingWeaverEdgeConn();

	}

}