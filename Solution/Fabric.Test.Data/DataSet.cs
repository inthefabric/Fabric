using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public class DataSet {

		public IList<WeaverQuery> Indexes { get; private set; }
		public IList<IDataNode> Nodes { get; private set; }
		public IList<IDataNodeIndex> NodeToIndexes { get; private set; }
		public IList<IDataRel> Rels { get; private set; }
		public bool IsForTesting { get; private set; }

		private readonly Random vRand;
		private DateTime vCurrDate;
		private readonly Dictionary<string, INode> vNodeMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataSet(bool pIsForTesting) {
			Indexes = new List<WeaverQuery>();
			Nodes = new List<IDataNode>();
			NodeToIndexes = new List<IDataNodeIndex>();
			Rels = new List<IDataRel>();
			IsForTesting = pIsForTesting;

			vRand = new Random(999);
			vCurrDate = DateTime.UtcNow.AddDays(-10);
			vNodeMap = new Dictionary<string, INode>();

			var r = new Root { Id = 0 };
			//AddNode(DataNode.Create(r)); //do not add node, use g.v(0) instead
			vNodeMap.Add(typeof(Root).Name+1, r);
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
		public INode GetNode<T>(long pNodeTypeId) where T : INode {
			INode n;
			vNodeMap.TryGetValue(typeof(T).Name+pNodeTypeId, out n);
			return n;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddIndex(WeaverQuery pQuery) {
			Indexes.Add(pQuery);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool AddNodeAndIndex<T>(T pDomainNode, Expression<Func<T,object>> pIndexValueFunc,
															bool pIsForTesting) where T : INode {
			if ( !IsForTesting && pIsForTesting ) { return false; }
			DataNode<T> n = DataNode.Create(pDomainNode, pIsForTesting);
			DataNodeIndex<T> ni = DataNodeIndex.Create(n, pIndexValueFunc);
			AddNode(n);
			AddNodeToIndex(ni);
			vNodeMap.Add(typeof(T).Name+pDomainNode.GetTypeId(), pDomainNode);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddNode<T>(DataNode<T> pNode) where T : INode {
			if ( !IsForTesting && pNode.IsForTesting ) { return; }
			Nodes.Add(pNode);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddNodeToIndex<T>(DataNodeIndex<T> pNodeToIndex) where T : INode {
			if ( !IsForTesting && pNodeToIndex.IsForTesting ) { return; }
			NodeToIndexes.Add(pNodeToIndex);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataRel<TFrom, TRel, TTo> AddRel<TFrom, TRel, TTo>(DataRel<TFrom, TRel, TTo> pRel)
							where TFrom : INode where TRel : IWeaverRel where TTo : INode {
			if ( !IsForTesting && pRel.IsForTesting ) { return pRel; }
			Rels.Add(pRel);
			return pRel;
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool AddRootRel<TRel>(IWeaverNode pToNode, bool pIsForTesting)
																		where TRel : IWeaverRel, new(){
			if ( !IsForTesting && pIsForTesting ) { return false; }
			IDataRel r = DataRel.Create(GetNode<Root>(1), new TRel(), pToNode);
			Rels.Add(r);
			return true;
		}

	}

}