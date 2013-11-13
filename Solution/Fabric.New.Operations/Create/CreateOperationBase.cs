using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using ServiceStack.Text;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public abstract class CreateOperationBase : ICreateOperation {

		protected IOperationContext OpCtx { get; set; }
		protected TxBuilder TxBuild { get; set; }

		private IWeaverVarAlias vVertexAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract void Create(IOperationContext pOpCtx, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void CreateEdges<T>(T pCreateObj) where T : CreateFabElement {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) where T : IWeaverElement {
			vVertexAlias = pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract FabObject GetResult();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected T ExecuteTx<T>() where T : Vertex, IElement, new() {
			IWeaverTransaction tx = TxBuild.Finish(vVertexAlias);
			IDataResult data = OpCtx.NewData().AddQueries(tx).Execute(GetType().Name);
			return data.ToElementAt<T>(0, 0);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TDom ConvertInput<TCre, TDom>(string pJson, Func<TCre, TDom> pConvert, 
									out TCre pInput) where TCre : CreateFabElement where TDom : IVertex {
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