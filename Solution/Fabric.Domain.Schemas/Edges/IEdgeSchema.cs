﻿using System;
using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public interface IEdgeSchema {

		string NameDom { get; }
		string NameApi { get; }
		string NameDb { get; }
		Type FromVertexType { get; }
		Type ToVertexType { get; }
		EdgeSchema.EdgeQuantity Quantity { get; }

		DomainProperty<long> ToVertexId { get; }
		ApiProperty<long> FabToVertexId { get; }
		string SubObjectOf { get; }
		Type CreateFromOtherDirection { get; }
		bool CreateInternal { get; }
		EdgeSchema.SortType Sort { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IVertexSchema GetFromVertex();

		/*--------------------------------------------------------------------------------------------*/
		IVertexSchema GetToVertex();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool GetIsOptional();

		/*--------------------------------------------------------------------------------------------*/
		bool GetIsMultiple();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetClassNameDom();

		/*--------------------------------------------------------------------------------------------*/
		string GetClassNameApi(bool pWithId=true);

		/*--------------------------------------------------------------------------------------------*/
		string GetPropNameDom(bool pPlural=false);

		/*--------------------------------------------------------------------------------------------*/
		string GetPropNameApi(bool pPlural=false);

		/*--------------------------------------------------------------------------------------------*/
		string GetPropNameLink();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetOutgoingWeaverEdgeConn();

		/*--------------------------------------------------------------------------------------------*/
		string GetIncomingWeaverEdgeConn();

	}

}