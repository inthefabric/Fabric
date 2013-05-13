using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static partial class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildGroup(string pNode, int pId) {
			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery("Group_"+pNode+" = "+
				"com.thinkaurelius.titan.core.TypeGroup.of("+pId+",'"+pNode+"')");
			return q;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildKey(string pNode, string pProp, string pType, bool pIndex) {
			string script = pProp+" = "+
					"g.makeType()"+
					".dataType("+pType+".class)"+
					".name('"+pProp+"')"+
					".unique(OUT)"; //,com.thinkaurelius.titan.core.TypeMaker.UniquenessConsistency.NO_LOCK)";

			if ( pNode != null ) {
				script += ".group(Group_"+pNode+")";
			}

			if ( pIndex ) {
				script += ".indexed(Vertex.class)";
			}

			script += ".makePropertyKey();1";

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery(script);
			return q;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildLabel(string pName, bool pInUnique, bool pOutUnique,
												/*string[] pPrimaryKeys,*/ string[] pSignatureKeys) {
			string script = 
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

			script += ".makeEdgeLabel();1";

			var q = Weave.Inst.NewQuery();
			q.FinalizeQuery(script);
			return q;
		}

	}

}