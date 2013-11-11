
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravStepLinks {

		public static IList<ITravStep> Links = new List<ITravStep> {
			new TravStepLink<FabApp, FabAppDefinesMember>("DefinesMembers", "pdm"),
			new TravStepLink<FabArtifact, FabMember>("CreatedByMember", "acbm"),
			new TravStepLink<FabArtifact, FabArtifactUsedAsPrimaryByFactor>("UsedAsPrimaryByFactors", "apbf"),
			new TravStepLink<FabArtifact, FabArtifactUsedAsRelatedByFactor>("UsedAsRelatedByFactors", "arbf"),
			new TravStepLink<FabArtifact, FabEmail>("UsesEmails", "aue"),
			new TravStepLink<FabEmail, FabArtifact>("UsedByArtifact", "eba"),
			new TravStepLink<FabFactor, FabMember>("CreatedByMember", "fcbm"),
			new TravStepLink<FabFactor, FabArtifact>("RefinesPrimaryWithArtifact", "frpa"),
			new TravStepLink<FabFactor, FabArtifact>("RefinesRelatedWithArtifact", "frra"),
			new TravStepLink<FabFactor, FabArtifact>("RefinesTypeWithArtifact", "frta"),
			new TravStepLink<FabFactor, FabArtifact>("UsesPrimaryArtifact", "fpa"),
			new TravStepLink<FabFactor, FabArtifact>("UsesRelatedArtifact", "fra"),
			new TravStepLink<FabFactor, FabArtifact>("UsesAxisArtifact", "faa"),
			new TravStepLink<FabMember, FabMemberAuthenticatedByOauthAccess>("AuthenticatedByOauthAccesses", "maboa"),
			new TravStepLink<FabMember, FabMemberCreatesArtifact>("CreatesArtifacts", "mca"),
			new TravStepLink<FabMember, FabMemberCreatesFactor>("CreatesFactors", "mcf"),
			new TravStepLink<FabMember, FabApp>("DefinedByApp", "mdbp"),
			new TravStepLink<FabMember, FabUser>("DefinedByUser", "mdbu"),
			new TravStepLink<FabOauthAccess, FabMember>("AuthenticatesMember", "oaam"),
			new TravStepLink<FabUser, FabUserDefinesMember>("DefinesMembers", "udm"),
		};

	}

}