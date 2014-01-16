using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public static class CreateOperationsCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void ClassAfterSessionStart(CreateOperationTasks pTasks,
							ICreateOperationBuilder pBuild, Class pNewDom, CreateFabClass pNewCre) {
			string disLow = (pNewDom.Disamb == null ? null : pNewDom.Disamb.ToLower());
			pTasks.FindDuplicateClass(pBuild, pNewDom.NameKey, disLow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FactorAfterSessionStart(CreateOperationTasks pTasks,
							ICreateOperationBuilder pBuild, Factor pNewDom, CreateFabFactor pNewCre) {
			if ( pNewCre.UsesPrimaryArtifactId == pNewCre.UsesRelatedArtifactId ) {
				throw new FabPropertyValueFault("RelatedArtifactId", pNewCre.UsesRelatedArtifactId+"",
					"Cannot be equal to PrimaryArtifactId");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void InstanceAfterSessionStart(CreateOperationTasks pTasks,
						ICreateOperationBuilder pBuild, Instance pNewDom, CreateFabInstance pNewCre) {
			if ( pNewDom.Name == null && pNewDom.Disamb != null ) {
				throw new FabPropertyValueFault("Name", null,
					"Cannot be null when Disamb is specified.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void MemberAfterSessionStart(CreateOperationTasks pTasks,
							ICreateOperationBuilder pBuild, Member pNewDom, CreateFabMember pNewCre) {
			pTasks.FindDuplicateMember(pBuild, pNewCre.DefinedByUserId, pNewCre.DefinedByAppId);
		}

	}

}