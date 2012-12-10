using System;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public interface  IDataRel {

		IWeaverNode FromNode { get; }
		IWeaverRel Rel { get; }
		IWeaverNode ToNode { get; }
		bool IsForTesting { get; }
		WeaverQuery AddQuery { get; }

	}

	/*================================================================================================*/
	public class DataRel {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataRel<TFrom, TRel, TTo> Create<TFrom, TRel, TTo>(TFrom pFromNode, TRel pRel,
												TTo pToNode, bool pIsForTest) where TFrom : IWeaverNode
												where TRel : IWeaverRel where TTo : IWeaverNode{
			return new DataRel<TFrom, TRel, TTo>(pFromNode, pRel, pToNode, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataRel<TFrom, TRel, TTo> : IDataRel where TFrom : IWeaverNode
													where TRel : IWeaverRel where TTo : IWeaverNode {

		public TFrom FromNodeT { get; private set; }
		public IWeaverNode FromNode { get; private set; }
		public TRel RelT { get; private set; }
		public IWeaverRel Rel { get; private set; }
		public TTo ToNodeT { get; private set; }
		public IWeaverNode ToNode { get; private set; }
		public bool IsForTesting { get; private set; }

		private WeaverQuery vAddQuery;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataRel(TFrom pFromNode, TRel pRel, TTo pToNode, bool pIsForTesting) {
			FromNode = pFromNode;
			FromNodeT = pFromNode;
			RelT = pRel;
			Rel = pRel;
			ToNode = pToNode;
			ToNodeT = pToNode;
			IsForTesting = pIsForTesting;

			if ( pRel.FromNodeType != typeof(TFrom) ) {
				throw new Exception("Incorrect FromNodeType '"+typeof(TFrom)+
					"', expected '"+pRel.FromNodeType+"'.");
			}

			if ( typeof(TFrom) != typeof(Root) && pRel.ToNodeType != typeof(TTo) ) {
				throw new Exception("Incorrect ToNodeType '"+typeof(TTo)+
					"', expected '"+pRel.ToNodeType+"'.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public WeaverQuery AddQuery {
			get {
				if ( vAddQuery == null ) {
					vAddQuery = WeaverQuery.AddRel(FromNode, Rel, ToNode);
				}

				return vAddQuery;
			}
		}

	}

}