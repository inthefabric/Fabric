using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public static class CreateOperationsCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ClassAfterSessionStart(CreateOperationTasks pTasks,
							ICreateOperationBuilder pCreCtx, Class pNewDom, CreateFabClass pNewCre) {
			pTasks.FindDuplicateClass(pCreCtx, pNewDom.NameKey, pNewDom.Disamb.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FactorAfterSessionStart(CreateOperationTasks pTasks,
							ICreateOperationBuilder pCreCtx, Factor pNewDom, CreateFabFactor pNewCre) {
			if ( pNewCre.UsesPrimaryArtifactId == pNewCre.UsesRelatedArtifactId ) {
				throw new FabPropertyValueFault("RelatedArtifactId", pNewCre.UsesRelatedArtifactId+"",
					"Cannot be equal to PrimaryArtifactId");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void InstanceAfterSessionStart(CreateOperationTasks pTasks,
						ICreateOperationBuilder pCreCtx, Instance pNewDom, CreateFabInstance pNewCre) {
			if ( pNewDom.Name == null && pNewDom.Disamb != null ) {
				throw new FabPropertyValueFault("Name", null,
					"Cannot be null when Disamb is specified.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void MemberAfterSessionStart(CreateOperationTasks pTasks,
							ICreateOperationBuilder pCreCtx, Member pNewDom, CreateFabMember pNewCre) {
			pTasks.FindDuplicateMember(pCreCtx, pNewCre.DefinedByUserId, pNewCre.DefinedByAppId);
		}

	}

}