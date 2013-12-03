using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using ServiceStack.Text;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public abstract class CreateOperationBase<TDom, TApi, TCre> : ICreateOperation<TDom, TApi>
						where TDom : Vertex, new() where TApi : FabVertex where TCre : CreateFabVertex {

		protected IOperationContext OpCtx { get; private set; }
		protected ITxBuilder TxBuild { get; private set; }
		protected TDom NewDom { get; private set; }
		protected TApi NewApi { get; private set; }
		protected TCre NewCre { get; private set; }
		protected IWeaverVarAlias<TDom> NewDomAlias { get; private set; }
		protected Func<TDom, TApi> DomToApi { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		public TDom Execute() {
			IWeaverTransaction tx = TxBuild.Finish(NewDomAlias);
			NewDom = OpCtx.Data.Get<TDom>(tx, GetType().Name);
			NewApi = (DomToApi == null ? null : DomToApi(NewDom));
			return NewDom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TApi GetResult() {
			if ( DomToApi == null ) {
				throw new NotSupportedException("Internal: no DomainToApi conversion for "+
					typeof(TDom).Name+".");
			}

			return NewApi;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void Init(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson,
											Func<TCre, TDom> pCreToDom, Func<TDom, TApi> pDomToApi) {
			OpCtx = pOpCtx;
			TxBuild = pTxBuild;
			DomToApi = pDomToApi;

			NewCre = JsonSerializer.DeserializeFromString<TCre>(pJson);
			CreateOperationsCustom.BeforeCreateObjectValidation(pOpCtx, NewCre);
			NewCre.Validate();

			NewDom = pCreToDom(NewCre);
			NewDom.VertexId = OpCtx.GetSharpflakeId<Vertex>();
			NewDom.Timestamp = OpCtx.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddVertex() {
			IWeaverVarAlias<TDom> va;
			TxBuild.AddVertex(NewDom, out va);
			NewDomAlias = va;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void VerifyVertex<T>(long pVertexId) where T : Vertex, new() {
			Vertex v = OpCtx.Data.GetVertexById<Vertex>(pVertexId);

			if ( v == null ) {
				throw new FabNotFoundFault(typeof(T), "Id="+pVertexId);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(
													IWeaverVarAlias<TFrom> pFromVar, long pToVertexId)
													where TFrom : IVertex, new()
													where TTo : Vertex, new()
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
													where TTo : Vertex, new()
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