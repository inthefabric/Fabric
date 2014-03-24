using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.New.Database.Init {

	/*================================================================================================*/
	public interface  IDataVertex {

		IVertex Vertex { get; }
		Type VertexType { get; }
		bool IsForTesting { get; }
		IWeaverQuery AddQuery { get; }
		int TestVal { get; set; }

	}

	/*================================================================================================*/
	public class DataVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataVertex<T> Create<T>(T pVertex, bool pIsForTest) where T : IVertex {
			return new DataVertex<T>(pVertex, pIsForTest);
		}

	}

	/*================================================================================================*/
	public class DataVertex<T> : IDataVertex where T : IVertex {

		public T VertexT { get; private set; }
		public Type VertexType { get; private set; }
		public IVertex Vertex { get; private set; }

		public bool IsForTesting { get; private set; }
		public int TestVal { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataVertex(T pVertex, bool pIsForTesting) {
			Vertex = pVertex;
			VertexT = pVertex;
			VertexType = typeof(T);
			IsForTesting = pIsForTesting;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery AddQuery {
			get { return Weave.Inst.Graph.AddVertex(VertexT); }
		}

	}

}