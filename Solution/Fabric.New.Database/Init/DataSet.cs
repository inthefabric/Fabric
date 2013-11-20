using System;
using System.Collections.Generic;
using Fabric.New.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Database.Init {

	/*================================================================================================*/
	public class DataSet {

		public IList<IWeaverQuery> Initialization { get; private set; }
		public IList<IWeaverQuery> Indexes { get; private set; }
		public IList<IDataVertex> Vertices { get; private set; }
		public IList<IDataEdge> Edges { get; private set; }
		public bool IsForTesting { get; private set; }

		private readonly Random vRand;
		private DateTime vCurrDate;
		private readonly Dictionary<long, IVertex> vVertexMap;
		private readonly Dictionary<IWeaverVertex, IDataVertex> vDataVertexMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataSet(bool pIsForTesting) {
			Initialization = new List<IWeaverQuery>();
			Indexes = new List<IWeaverQuery>();
			Vertices = new List<IDataVertex>();
			Edges = new List<IDataEdge>();
			IsForTesting = pIsForTesting;

			vRand = new Random(999);
			vCurrDate = DateTime.UtcNow.AddDays(-10);
			vVertexMap = new Dictionary<long, IVertex>();
			vDataVertexMap = new Dictionary<IWeaverVertex, IDataVertex>();
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
		public T GetVertex<T>(long pVertexId) where T : IVertex {
			IVertex n;
			vVertexMap.TryGetValue(pVertexId, out n);
			return (T)n;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IDataVertex GetDataVertex(IWeaverVertex pDomainVertex) {
			return vDataVertexMap[pDomainVertex];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddIndexQuery(IWeaverQuery pQuery) {
			Indexes.Add(pQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool AddVertex<T>(DataVertex<T> pVertData) where T : IVertex {
			if ( !IsForTesting && pVertData.IsForTesting ) {
				return false;
			}

			Vertices.Add(pVertData);
			vVertexMap.Add(pVertData.Vertex.VertexId, pVertData.Vertex);
			vDataVertexMap.Add(pVertData.Vertex, pVertData);
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataEdge<TFrom, TEdge, TTo> AddEdge<TFrom, TEdge, TTo>(DataEdge<TFrom, TEdge, TTo> pEdge)
								where TFrom : IVertex where TEdge : IWeaverEdge where TTo : IVertex {
			if ( !IsForTesting && pEdge.IsForTesting ) {
				return pEdge;
			}

			Edges.Add(pEdge);
			return pEdge;
		}

	}

}