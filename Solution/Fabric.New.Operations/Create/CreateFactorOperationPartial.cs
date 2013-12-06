using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public partial class CreateFactorOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void VerifyCustomFactor() { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			if ( NewCre.UsesPrimaryArtifactId == NewCre.UsesRelatedArtifactId ) {
				throw new FabPropertyValueFault("RelatedArtifactId", NewCre.UsesRelatedArtifactId+"",
					"Cannot be equal to PrimaryArtifactId");
			}
		}
	}

}