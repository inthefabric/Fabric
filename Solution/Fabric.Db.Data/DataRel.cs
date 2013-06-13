using System;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataRel {

		IWeaverVertex OutVertex { get; }
		IWeaverEdge Rel { get; }
		IWeaverVertex InVertex { get; }
		bool IsForTesting { get; }
		IWeaverQuery AddQuery { get; }
		string TestVal { get; set; }

	}

	/*================================================================================================*/
	public class DataRel {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataRel<TFrom, TRel, TTo> Create<TFrom, TRel, TTo>(TFrom pOutVertex, TRel pRel,
												TTo pInVertex, bool pIsForTest) where TFrom : IWeaverVertex
												where TRel : IWeaverEdge where TTo : IWeaverVertex{
			return new DataRel<TFrom, TRel, TTo>(pOutVertex, pRel, pInVertex, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataRel<TFrom, TRel, TTo> : IDataRel where TFrom : IWeaverVertex
													where TRel : IWeaverEdge where TTo : IWeaverVertex {

		public TFrom OutVertexT { get; private set; }
		public IWeaverVertex OutVertex { get; private set; }
		public TRel RelT { get; private set; }
		public IWeaverEdge Rel { get; private set; }
		public TTo InVertexT { get; private set; }
		public IWeaverVertex InVertex { get; private set; }
		public bool IsForTesting { get; private set; }
		public string TestVal { get; set; }

		private IWeaverQuery vAddQuery;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataRel(TFrom pOutVertex, TRel pRel, TTo pInVertex, bool pIsForTesting) {
			OutVertex = pOutVertex;
			OutVertexT = pOutVertex;
			RelT = pRel;
			Rel = pRel;
			InVertex = pInVertex;
			InVertexT = pInVertex;
			IsForTesting = pIsForTesting;

			if ( pRel.OutVertexType != typeof(TFrom) ) {
				throw new Exception("Incorrect OutVertexType '"+typeof(TFrom)+
					"', expected '"+pRel.OutVertexType+"'.");
			}

			if ( pRel.InVertexType != typeof(TTo) ) {
				throw new Exception("Incorrect InVertexType '"+typeof(TTo)+
					"', expected '"+pRel.InVertexType+"'.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery AddQuery {
			get {
				if ( vAddQuery == null ) {
					vAddQuery = Weave.Inst.Graph.AddEdge(OutVertexT, RelT, InVertexT);
				}

				return vAddQuery;
			}
		}

	}

}