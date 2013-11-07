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
	public abstract class CreateOperationBase : ICreateOperation {

		protected object ApiCtx { get; set; }
		protected TxBuilder TxBuild { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract void Create(object pApiCtx, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void CreateEdges<T>(T pCreateObj) where T : CreateFabObject {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) where T : IWeaverElement {}

		/*--------------------------------------------------------------------------------------------*/
		public abstract FabObject GetResult();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TDom ConvertInput<TCre, TDom>(string pJson, Func<TCre, TDom> pConvert, 
									out TCre pInput) where TCre : CreateFabObject where TDom : IVertex {
			pInput = JsonSerializer.DeserializeFromString<TCre>(pJson);
			pInput.Validate();

			TDom dom = pConvert(pInput);
			dom.VertexId = Sharpflake.GetId<Vertex>();
			dom.Timestamp = DateTime.UtcNow.Ticks;
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void VerifyVertex<T>(long pVertexId) where T : IVertex {
			//TODO: CreateOperationsUtil.VerifyVertex()
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(
													IWeaverVarAlias<TFrom> pFromVar, long pToVertexId)
													where TFrom : IVertex, new()
													where TTo : IVertex, new()
													where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			VerifyVertex<TTo>(pToVertexId);

			IWeaverVarAlias<TTo> toVertexVar;
			TxBuild.GetVertex(pToVertexId, out toVertexVar);
			TxBuild.AddEdge(pFromVar, new TEdge(), toVertexVar);

			return toVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(
													IWeaverVarAlias<TFrom> pFromVar, long? pToVertexId)
													where TFrom : IVertex, new()
													where TTo : IVertex, new()
													where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			if ( pToVertexId == null ) {
				return null;
			}

			return AddEdge<TFrom, TEdge, TTo>(pFromVar, (long)pToVertexId);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddReverseEdge<TFrom, TEdge, TTo>(
							IWeaverVarAlias<TFrom> pFromVar, TEdge pEdge, IWeaverVarAlias<TTo> pToVar)
														where TFrom : IVertex, new()
														where TTo : IVertex, new()
														where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			if ( pFromVar != null ) {
				TxBuild.AddEdge(pFromVar, pEdge, pToVar);
			}
		}

	}

}