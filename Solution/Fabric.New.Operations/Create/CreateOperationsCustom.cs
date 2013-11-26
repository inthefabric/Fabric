using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public static class CreateOperationsCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void BeforeCreateObjectValidation<T>(IOperationContext pOpCtx, T pCre) {
			CreateFabArtifact art = (pCre as CreateFabArtifact);
			CreateFabFactor fac = (pCre as CreateFabFactor);

			if ( art != null ) {
				art.CreatedByMemberId = (pOpCtx.Auth.ActiveMemberId ?? 0);
			}

			if ( fac != null ) {
				fac.CreatedByMemberId = (pOpCtx.Auth.ActiveMemberId ?? 0);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void CreateClass(IOperationContext pOpCtx, TxBuilder pTxBuild,
																	CreateFabClass pApi, Class pDom) {
			//TODO: perform this in the SAME TRANSACTION as the creation query
			
			Class c = Weave.Inst.Graph
				.V.ExactIndex<Class>(x => x.NameKey, pDom.Name.ToLower());
			IWeaverQuery q;
			string name = pDom.Name;

			if ( pDom.Disamb == null ) {
				q = c.HasNot(x => x.Disamb)
					//.Property(x => x.VertexId)
					.ToQuery();
			}
			else {
				q = c.CustomStep(
					"filter{"+ //the "?." before "toLowerCase()" is the "safe-navigation" operator
						"it.getProperty('"+DbName.Vert.Class.Disamb+"')?.toLowerCase()==_P1;"+
					"}")
					//.Property(x => x.VertexId)
					.ToQuery();
				
				q.AddParam(new WeaverQueryVal(pDom.Disamb.ToLower()));
				name += "("+pDom.Disamb+")";
			}

			c = pOpCtx.Data.Get<Class>(q, "IsClassUnique");

			if ( c != null ) {
				throw new FabDuplicateFault(typeof(Class), "Name", name,
					"Name+Disamb conflict, see Id="+c.VertexId+".");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static void CreateFactor(IOperationContext pOpCtx, TxBuilder pTxBuild,
																	CreateFabFactor pApi, Factor pDom) {
			if ( pApi.UsesPrimaryArtifactId == pApi.UsesRelatedArtifactId ) {
				throw new FabPropertyValueFault("RelatedArtifactId", pApi.UsesRelatedArtifactId+"",
					"Cannot be equal to PrimaryArtifactId");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void CreateInstance(IOperationContext pOpCtx, TxBuilder pTxBuild,
																CreateFabInstance pApi, Instance pDom) {
			if ( pDom.Name == null && pDom.Disamb != null ) {
				throw new FabPropertyValueFault("Name", null,
					"Cannot be null when Disamb is specified.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void CreateMember(IOperationContext pOpCtx, TxBuilder pTxBuild,
																CreateFabMember pApi, Member pDom) {
			//TODO: verify member doesn't already exist
			throw new NotImplementedException();
		}

	}

}