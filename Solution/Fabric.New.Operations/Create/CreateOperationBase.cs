using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using ServiceStack.Text;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public abstract class CreateOperationBase : ICreateOperation {

		protected IOperationContext OpCtx { get; set; }
		protected TxBuilder TxBuild { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract void Create(IOperationContext pOpCtx, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		public abstract FabObject GetResult();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<TDom> CreateInit<TCre, TDom>(IOperationContext pOpCtx, string pJson,
												Func<TCre, TDom> pConvert, out TCre pCre, out TDom pDom)
												where TCre : CreateFabObject where TDom : IVertex {
			OpCtx = pOpCtx;
			TxBuild = new TxBuilder();

			pCre = JsonSerializer.DeserializeFromString<TCre>(pJson);
			CreateOperationsCustom.BeforeCreateObjectValidation(pOpCtx, pCre);
			pCre.Validate();

			pDom = pConvert(pCre);
			pDom.VertexId = Sharpflake.GetId<Vertex>();
			pDom.Timestamp = DateTime.UtcNow.Ticks;

			IWeaverVarAlias<TDom> va;
			TxBuild.AddVertex(pDom, out va);
			return va;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T ExecuteTx<T>(IWeaverVarAlias<T> pVertexAlias) where T : Vertex, IElement, new() {
			IWeaverTransaction tx = TxBuild.Finish(pVertexAlias);
			IDataResult data = OpCtx.NewData().AddQueries(tx).Execute(GetType().Name);
			return data.ToElementAt<T>(0, 0);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void VerifyVertex<T>(long pVertexId) where T : Vertex, new() {
			Vertex v = OpCtx.GetVertexById<Vertex>(pVertexId);

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