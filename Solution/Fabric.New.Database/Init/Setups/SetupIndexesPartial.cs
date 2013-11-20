using System;
using System.Linq;
using Weaver.Core.Query;

namespace Fabric.New.Database.Init.Setups {


	/*================================================================================================*/
	public partial class SetupIndexes : SetupVertices {

		private enum Elem {
			Vertex,
			Edge
		}

		private enum Index {
			None,
			Standard,
			Elastic,
			Both
		}

		private enum Cardin {
			OneToOne,
			OneToMany,
		}

		private enum Sort {
			None,
			Asc,
			Desc
		}

		private readonly Func<string, string> vNameToVar;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupIndexes(DataSet pData) : base(pData) {
			vNameToVar = (x => x.Replace('.', '_'));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddProp(Elem pElem, string pName, string pType, Index pIndex, bool pUnique) {
			IWeaverQuery q = new WeaverQuery();
			string s = "TitanKey "+vNameToVar(pName)+" = "+
				"g.makeKey('"+pName+"').dataType("+pType+".class)";

			if ( pIndex == Index.Standard || pIndex == Index.Both ) {
				s += ".indexed("+pElem+".class)";
			}

			if ( pIndex == Index.Elastic || pIndex == Index.Both ) {
				s += ".indexed('search', "+pElem+".class)";
			}

			if ( pUnique ) {
				s += ".unique()";
			}

			//do not specify "single()" to avoid extra Titan locking

			q.FinalizeQuery(s+".make()");
			Data.AddIndexQuery(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddEdge(string pLabel, Cardin pCard, Sort pOrder, string[] pSort, string[] pSig) {
			IWeaverQuery q = new WeaverQuery();
			string s = "g.makeLabel('"+pLabel+"').unidirected()";

			switch ( pCard ) {
				case Cardin.OneToOne:
					s += ".oneToOne(UniquenessConsistency.NO_LOCK)";
					break;

				case Cardin.OneToMany:
					s += ".oneToMany(UniquenessConsistency.NO_LOCK)";
					break;
			}

			if ( pSort.Length > 0 ) {
				s += ".sortKey("+string.Join(",", pSort.Select(vNameToVar))+")";

				if ( pOrder != Sort.None ) {
					s += ".sortOrder(Order."+(pOrder+"").ToUpper()+")";
				}
			}

			if ( pSig.Length > 0 ) {
				s += ".signature("+string.Join(",", pSig.Select(vNameToVar))+")";
			}

			q.FinalizeQuery(s+".make()");
			Data.AddIndexQuery(q);
		}

	}

}