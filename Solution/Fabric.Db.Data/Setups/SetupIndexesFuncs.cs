using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static partial class SetupIndexes {

		private const string TitanPath = "com.thinkaurelius.titan.core.";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildGroup(string pNode, int pId) {
			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery(TitanPath+"TypeGroup Group_"+pNode+" = "+
				TitanPath+"TypeGroup.of("+pId+",'"+pNode+"')");
			return q;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildKey(string pNode, string pProp, string pType, bool pIndex) {
			string script = 
				TitanPath+"TitanKey "+pProp+" = "+
					"g.makeType()"+
					".dataType("+pType+".class)"+
					".name('"+pProp+"')"+
					".unique(OUT)"; //,NO_LOCK)";

			if ( pNode != null ) {
				script += ".group(Group_"+pNode+")";
			}

			if ( pIndex ) {
				script += ".indexed(Vertex.class)";
			}

			script += ".makePropertyKey()";

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery(script);
			return q;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildLabel(string pName, bool pInUnique, bool pOutUnique,
												/*string[] pPrimaryKeys,*/ string[] pSignatureKeys) {
			string script = 
				//TitanPath+"TitanLabel "+pName.Replace('-', '_')+" = "+
					"g.makeType()"+
					".name('"+pName+"')"+
					//".primaryKey("+string.Join(",", pPrimaryKeys)+")";
					".signature("+string.Join(",", pSignatureKeys)+")";

			if ( pInUnique ) {
				script += ".unique(IN)";
			}

			if ( pOutUnique ) {
				script += ".unique(OUT)";
			}

			script += ".makeEdgeLabel()";

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery(script);
			return q;
		}

	}

}