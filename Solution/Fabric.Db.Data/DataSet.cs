using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Db.Data {

	/*================================================================================================*/
	public class DataSet {

		public IList<IWeaverQuery> Initialization { get; private set; }
		public IList<IWeaverQuery> Indexes { get; private set; }
		public IList<IDataVertex> Vertices { get; private set; }
		public IList<IDataRel> Rels { get; private set; }
		public bool IsForTesting { get; private set; }

		private readonly Random vRand;
		private DateTime vCurrDate;
		private readonly Dictionary<string, IVertex> vVertexMap;
		private readonly Dictionary<IWeaverVertex, IDataVertex> vDataVertexMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataSet(bool pIsForTesting) {
			Initialization = new List<IWeaverQuery>();
			Indexes = new List<IWeaverQuery>();
			Vertices = new List<IDataVertex>();
			Rels = new List<IDataRel>();
			IsForTesting = pIsForTesting;

			vRand = new Random(999);
			vCurrDate = DateTime.UtcNow.AddDays(-10);
			vVertexMap = new Dictionary<string, IVertex>();
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
		public T GetVertex<T>(long pVertexTypeId) where T : IVertex {
			IVertex n;
			vVertexMap.TryGetValue(typeof(T).Name+pVertexTypeId, out n);
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool AddVertex<T>(T pDomainVertex, bool pIsForTesting) where T : IVertex {
			if ( !IsForTesting && pIsForTesting ) { return false; }
			DataVertex<T> n = DataVertex.Create(pDomainVertex, pIsForTesting);
			Vertices.Add(n);
			vVertexMap.Add(typeof(T).Name+pDomainVertex.GetTypeId(), pDomainVertex);
			vDataVertexMap.Add(pDomainVertex, n);
			return true;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool RegisterBaseClassVertex<T>(T pDomainVertex, Type pBaseClassType, long pTypeId, 
																bool pIsForTesting) where T : IVertex {
			if ( !IsForTesting && pIsForTesting ) { return false; }
			vVertexMap.Add(pBaseClassType.Name+pTypeId, pDomainVertex);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataRel<TFrom, TRel, TTo> AddRel<TFrom, TRel, TTo>(DataRel<TFrom, TRel, TTo> pRel)
							where TFrom : IVertex where TRel : IWeaverEdge where TTo : IVertex {
			if ( !IsForTesting && pRel.IsForTesting ) { return pRel; }
			Rels.Add(pRel);
			return pRel;
		}

	}

}