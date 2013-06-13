﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public class DataSet {

		public IList<IWeaverQuery> Initialization { get; private set; }
		public IList<IWeaverQuery> Indexes { get; private set; }
		public IList<IDataNode> Nodes { get; private set; }
		public IList<IDataRel> Rels { get; private set; }
		public bool IsForTesting { get; private set; }

		private readonly Random vRand;
		private DateTime vCurrDate;
		private readonly Dictionary<string, INode> vNodeMap;
		private readonly Dictionary<IWeaverVertex, IDataNode> vDataNodeMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataSet(bool pIsForTesting) {
			Initialization = new List<IWeaverQuery>();
			Indexes = new List<IWeaverQuery>();
			Nodes = new List<IDataNode>();
			Rels = new List<IDataRel>();
			IsForTesting = pIsForTesting;

			vRand = new Random(999);
			vCurrDate = DateTime.UtcNow.AddDays(-10);
			vNodeMap = new Dictionary<string, INode>();
			vDataNodeMap = new Dictionary<IWeaverVertex, IDataNode>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClearPreviousData() {
			var q = new WeaverQuery();
			q.FinalizeQuery("g.V.remove()"); //also removes all edges
			Initialization.Add(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public long NowTimestamp {
			get { return DateTime.UtcNow.Ticks; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public DateTime SetupDateTime {
			get { return new DateTime(SetupTimestamp);  }
		}


		/*--------------------------------------------------------------------------------------------*/
		public long SetupTimestamp {
			get { return vCurrDate.Ticks; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public long ElapseTime() {
			vCurrDate = vCurrDate.AddMinutes(5+vRand.NextDouble()*55);
			return SetupTimestamp;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T GetNode<T>(long pNodeTypeId) where T : INode {
			INode n;
			vNodeMap.TryGetValue(typeof(T).Name+pNodeTypeId, out n);
			return (T)n;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IDataNode GetDataNode(IWeaverVertex pDomainNode) {
			return vDataNodeMap[pDomainNode];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddIndexQuery(IWeaverQuery pQuery) {
			Indexes.Add(pQuery);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool AddNode<T>(T pDomainNode, bool pIsForTesting) where T : INode {
			if ( !IsForTesting && pIsForTesting ) { return false; }
			DataNode<T> n = DataNode.Create(pDomainNode, pIsForTesting);
			Nodes.Add(n);
			vNodeMap.Add(typeof(T).Name+pDomainNode.GetTypeId(), pDomainNode);
			vDataNodeMap.Add(pDomainNode, n);
			return true;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool RegisterBaseClassNode<T>(T pDomainNode, Type pBaseClassType, long pTypeId, 
																bool pIsForTesting) where T : INode {
			if ( !IsForTesting && pIsForTesting ) { return false; }
			vNodeMap.Add(pBaseClassType.Name+pTypeId, pDomainNode);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataRel<TFrom, TRel, TTo> AddRel<TFrom, TRel, TTo>(DataRel<TFrom, TRel, TTo> pRel)
							where TFrom : INode where TRel : IWeaverEdge where TTo : INode {
			if ( !IsForTesting && pRel.IsForTesting ) { return pRel; }
			Rels.Add(pRel);
			return pRel;
		}

	}

}