using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataEdge {

		IWeaverVertex OutVertex { get; }
		IWeaverEdge Edge { get; }
		IWeaverVertex InVertex { get; }
		bool IsForTesting { get; }
		IWeaverQuery AddQuery { get; }
		string TestVal { get; set; }

	}

	/*================================================================================================*/
	public class DataEdge {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataEdge<TFrom, TEdge, TTo> Create<TFrom, TEdge, TTo>(TFrom pOutVertex, TEdge pEdge,
											TTo pInVertex, bool pIsForTest) where TFrom : IWeaverVertex
												where TEdge : IWeaverEdge where TTo : IWeaverVertex {
			return new DataEdge<TFrom, TEdge, TTo>(pOutVertex, pEdge, pInVertex, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataEdge<TFrom, TEdge, TTo> : IDataEdge where TFrom : IWeaverVertex
													where TEdge : IWeaverEdge where TTo : IWeaverVertex {

		public TFrom OutVertexT { get; private set; }
		public IWeaverVertex OutVertex { get; private set; }
		public TEdge EdgeT { get; private set; }
		public IWeaverEdge Edge { get; private set; }
		public TTo InVertexT { get; private set; }
		public IWeaverVertex InVertex { get; private set; }
		public bool IsForTesting { get; private set; }
		public string TestVal { get; set; }

		private IWeaverQuery vAddQuery;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataEdge(TFrom pOutVertex, TEdge pEdge, TTo pInVertex, bool pIsForTesting) {
			OutVertex = pOutVertex;
			OutVertexT = pOutVertex;
			EdgeT = pEdge;
			Edge = pEdge;
			InVertex = pInVertex;
			InVertexT = pInVertex;
			IsForTesting = pIsForTesting;

			if ( !pEdge.IsValidOutVertexType(typeof(TFrom)) ) {
				throw new Exception("Incorrect OutVertexType '"+typeof(TFrom)+
					"', expected '"+pEdge.OutVertexType+"'.");
			}

			if ( !pEdge.IsValidInVertexType(typeof(TTo)) ) {
				throw new Exception("Incorrect InVertexType '"+typeof(TTo)+
					"', expected '"+pEdge.InVertexType+"'.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery AddQuery {
			get {
				if ( vAddQuery == null ) {
					vAddQuery = Weave.Inst.Graph.AddEdge(OutVertexT, EdgeT, InVertexT);
				}

				return vAddQuery;
			}
		}

	}

}