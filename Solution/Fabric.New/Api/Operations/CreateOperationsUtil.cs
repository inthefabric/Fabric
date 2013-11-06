using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure;
using Fabric.New.Infrastructure.Weaver;
using ServiceStack.Text;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Api.Operations {

	/*================================================================================================*/
	public static class CreateOperationsUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static TDom ConvertInput<TCre, TDom>(string pJson, Func<TCre, TDom> pConvert, 
									out TCre pInput) where TCre : CreateFabObject where TDom : IVertex {
			pInput = JsonSerializer.DeserializeFromString<TCre>(pJson);
			pInput.Validate();

			TDom dom = pConvert(pInput);
			dom.VertexId = Sharpflake.GetId<Vertex>();
			dom.Timestamp = DateTime.UtcNow.Ticks;
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void VerifyVertex<T>(object pApiCtx, long pVertexId) where T : IVertex {
			//TODO: CreateOperationsUtil.VerifyVertex()
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void AddEdge<TFrom, TEdge, TTo>(TxBuilder pTxBuild, object pApiCtx, 
												IWeaverVarAlias<TFrom> pFromVar, long pToVertexId)
												where TFrom : IVertex, new()
												where TTo : IVertex, new()
												where TEdge : IWeaverEdge<TFrom, TTo> {
			VerifyVertex<TTo>(pApiCtx, pToVertexId);

			IWeaverVarAlias<TTo> toVertexVar;
			pTxBuild.GetVertex(pToVertexId, out toVertexVar);
			pTxBuild.AddEdge<FactorCreatedByMember>(pFromVar, toVertexVar);
		}

		
		/*--------------------------------------------------------------------------------------------*/
		public static void AddEdge<TFrom, TEdge, TTo>(TxBuilder pTxBuild, object pApiCtx, 
												IWeaverVarAlias<TFrom> pFromVar, long? pToVertexId)
												where TFrom : IVertex, new()
												where TTo : IVertex, new()
												where TEdge : IWeaverEdge<TFrom, TTo> {
			if ( pToVertexId != null ) {
				AddEdge<TFrom, TEdge, TTo>(pTxBuild, pApiCtx, pFromVar, (long)pToVertexId);
			}
		}

	}

}