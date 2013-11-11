
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravSteps {

		public static IList<ITravStep> LinkList = new List<ITravStep> {
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

		public static IList<ITravStep> VertexHasList = new List<ITravStep> {
			new TravStepHas<FabFactor, byte>("AssertionType", "f.at", true),
			new TravStepHas<FabFactor, bool>("IsDefining", "f.de", true),
			new TravStepHas<FabFactor, byte>("DescriptorType", "f.det", true),
			new TravStepHas<FabFactor, byte>("DirectorType", "f.dit", true),
			new TravStepHas<FabFactor, byte>("DirectorPrimaryAction", "f.dip", true),
			new TravStepHas<FabFactor, byte>("DirectorRelatedAction", "f.dir", true),
			new TravStepHas<FabFactor, byte>("EventorType", "f.evt", true),
			TravStepsCustom.HasFactorEventorYear<FabFactor, long>("EventorYear", "f.evd"),
			TravStepsCustom.HasFactorEventorMonth<FabFactor, byte>("EventorMonth", "f.evd"),
			TravStepsCustom.HasFactorEventorDay<FabFactor, byte>("EventorDay", "f.evd"),
			TravStepsCustom.HasFactorEventorHour<FabFactor, byte>("EventorHour", "f.evd"),
			TravStepsCustom.HasFactorEventorMinute<FabFactor, byte>("EventorMinute", "f.evd"),
			TravStepsCustom.HasFactorEventorSecond<FabFactor, byte>("EventorSecond", "f.evd"),
			new TravStepHas<FabFactor, byte>("IdentorType", "f.idt", true),
			new TravStepHas<FabFactor, string>("IdentorValue", "f.no", true),
			new TravStepHas<FabFactor, byte>("LocatorType", "f.lot", true),
			new TravStepHas<FabFactor, double>("LocatorValueX", "f.lox", false),
			new TravStepHas<FabFactor, double>("LocatorValueY", "f.loy", false),
			new TravStepHas<FabFactor, double>("LocatorValueZ", "f.loz", false),
			new TravStepHas<FabFactor, byte>("VectorType", "f.vet", true),
			new TravStepHas<FabFactor, byte>("VectorUnit", "f.veu", true),
			new TravStepHas<FabFactor, byte>("VectorUnitPrefix", "f.vep", true),
			new TravStepHas<FabFactor, long>("VectorValue", "f.vev", false),
			new TravStepHas<FabMember, byte>("Type", "m.at", true),
			new TravStepHas<FabVertex, long>("Id", "v.id", true),
			TravStepsCustom.HasVertexTimestamp<FabVertex, float>("Timestamp", "v.ts"),
		};

		public static IList<ITravStep> LinkHasList = new List<ITravStep> {
			new TravStepHas<FabAppDefinesMember, long>("Timestamp", "pdm.ts", false),
			new TravStepHas<FabAppDefinesMember, byte>("MemberType", "pdm.mt", false),
			new TravStepHas<FabAppDefinesMember, long>("UserId", "pdm.ui", false),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, long>("Timestamp", "apbf.ts", false),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, byte>("DescriptorType", "apbf.dt", false),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, long>("RelatedArtifactId", "apbf.ra", false),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, long>("Timestamp", "arbf.ts", false),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, byte>("DescriptorType", "arbf.dt", false),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, long>("PrimaryArtifactId", "arbf.pa", false),
			new TravStepHas<FabMemberCreatesArtifact, long>("Timestamp", "mca.ts", false),
			new TravStepHas<FabMemberCreatesArtifact, byte>("VertexType", "mca.vt", false),
			new TravStepHas<FabMemberCreatesFactor, long>("Timestamp", "mcf.ts", false),
			new TravStepHas<FabMemberCreatesFactor, byte>("DescriptorType", "mcf.dt", false),
			new TravStepHas<FabMemberCreatesFactor, long>("PrimaryArtifactId", "mcf.pa", false),
			new TravStepHas<FabMemberCreatesFactor, long>("RelatedArtifactId", "mcf.ra", false),
			new TravStepHas<FabUserDefinesMember, long>("Timestamp", "udm.ts", false),
			new TravStepHas<FabUserDefinesMember, byte>("MemberType", "udm.mt", false),
			new TravStepHas<FabUserDefinesMember, long>("AppId", "udm.pi", false),
		};

	}

}