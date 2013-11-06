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
	public abstract class CreateOperationBase {

		public object ApiCtx { get; private set; }
		protected TxBuilder TxBuild { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected CreateOperationBase(object pApiCtx) {
			ApiCtx = pApiCtx;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public abstract void Create(string pJson);

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void CreateEdges<T>(T pCreateObj) where T : CreateFabObject {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) where T : IWeaverElement {}


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
			TxBuild.AddEdge<TEdge>(pFromVar, toVertexVar);

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
										IWeaverVarAlias<TFrom> pFromVar, IWeaverVarAlias<TTo> pToVar)
														where TFrom : IVertex, new()
														where TTo : IVertex, new()
														where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			if ( pFromVar != null ) {
				TxBuild.AddEdge<TEdge>(pFromVar, pToVar);
			}
		}

	}

}