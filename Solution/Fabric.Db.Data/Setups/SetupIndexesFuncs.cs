using Weaver.Core.Query;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static partial class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildGroup(string pVertex, int pId) {
			var q = new WeaverQuery();
			q.FinalizeQuery("Group_"+pVertex+" = "+
				"com.thinkaurelius.titan.core.TypeGroup.of("+pId+",'"+pVertex+"')");
			return q;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildKey(string pVertex, string pProp, string pType, bool pIndex, 
																						bool pElastic) {
			string script = pProp+" = "+
					"g.makeType()"+
					".dataType("+pType+".class)"+
					".name('"+pProp+"')"+
					".unique(OUT)"; 
					//,com.thinkaurelius.titan.core.TypeMaker.UniquenessConsistency.NO_LOCK)";

			if ( pVertex != null ) {
				script += ".group(Group_"+pVertex+")";
			}

			if ( pIndex ) {
				script += ".indexed(Vertex.class)";
			}
			
			if ( pElastic ) {
				script += ".indexed('search',Vertex.class)";
			}

			script += ".makePropertyKey();1";

			var q = new WeaverQuery();
			q.FinalizeQuery(script);
			return q;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverQuery BuildLabel(string pName, bool pInUnique, bool pOutUnique,
													string[] pPrimaryKeys, string[] pSignatureKeys) {
			string script = 
				"g.makeType()"+
				".name('"+pName+"')";

			if ( pPrimaryKeys.Length > 0 && pPrimaryKeys[0] != "" ) {
				script += ".primaryKey("+string.Join(",", pPrimaryKeys)+")";
			}

			if ( pSignatureKeys.Length > 0 && pSignatureKeys[0] != "" ) {
				script += ".signature("+string.Join(",", pSignatureKeys)+")";
			}

			if ( pInUnique ) {
				script += ".unique(IN)";
			}

			if ( pOutUnique ) {
				script += ".unique(OUT)";
			}

			script += ".makeEdgeLabel();1";

			var q = new WeaverQuery();
			q.FinalizeQuery(script);
			return q;
		}

	}

}