
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravSteps {

		public static IList<ITravStep> LinkList = new List<ITravStep> {
			new TravStepLink<FabApp, FabAppDefinesMember>("DefinesMembers", "pdm"),
			new TravStepLink<FabArtifact, FabMember>("CreatedByMember", "acbm"),
			new TravStepLink<FabArtifact, FabArtifactUsedAsPrimaryByFactor>("UsedAsPrimaryByFactors", "apbf"),
			new TravStepLink<FabArtifact, FabArtifactUsedAsRelatedByFactor>("UsedAsRelatedByFactors", "arbf"),
			new TravStepLink<FabFactor, FabMember>("CreatedByMember", "fcbm"),
			new TravStepLink<FabFactor, FabArtifact>("RefinesPrimaryWithArtifact", "frpa"),
			new TravStepLink<FabFactor, FabArtifact>("RefinesRelatedWithArtifact", "frra"),
			new TravStepLink<FabFactor, FabArtifact>("RefinesTypeWithArtifact", "frta"),
			new TravStepLink<FabFactor, FabArtifact>("UsesPrimaryArtifact", "fpa"),
			new TravStepLink<FabFactor, FabArtifact>("UsesRelatedArtifact", "fra"),
			new TravStepLink<FabFactor, FabArtifact>("UsesAxisArtifact", "faa"),
			new TravStepLink<FabMember, FabMemberCreatesArtifact>("CreatesArtifacts", "mca"),
			new TravStepLink<FabMember, FabMemberCreatesFactor>("CreatesFactors", "mcf"),
			new TravStepLink<FabMember, FabApp>("DefinedByApp", "mdbp"),
			new TravStepLink<FabMember, FabUser>("DefinedByUser", "mdbu"),
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
			TravStepsCustom.HasAppDefinesMemberTimestamp<FabAppDefinesMember, float>("Timestamp", "pdm.ts"),
			new TravStepHas<FabAppDefinesMember, byte>("MemberType", "pdm.mt", true),
			new TravStepHas<FabAppDefinesMember, long>("UserId", "pdm.ui", true),
			TravStepsCustom.HasArtifactUsedAsPrimaryByFactorTimestamp<FabArtifactUsedAsPrimaryByFactor, float>("Timestamp", "apbf.ts"),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, byte>("DescriptorType", "apbf.dt", true),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, long>("RelatedArtifactId", "apbf.ra", true),
			TravStepsCustom.HasArtifactUsedAsRelatedByFactorTimestamp<FabArtifactUsedAsRelatedByFactor, float>("Timestamp", "arbf.ts"),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, byte>("DescriptorType", "arbf.dt", true),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, long>("PrimaryArtifactId", "arbf.pa", true),
			TravStepsCustom.HasMemberCreatesArtifactTimestamp<FabMemberCreatesArtifact, float>("Timestamp", "mca.ts"),
			new TravStepHas<FabMemberCreatesArtifact, byte>("VertexType", "mca.vt", false),
			TravStepsCustom.HasMemberCreatesFactorTimestamp<FabMemberCreatesFactor, float>("Timestamp", "mcf.ts"),
			new TravStepHas<FabMemberCreatesFactor, byte>("DescriptorType", "mcf.dt", true),
			new TravStepHas<FabMemberCreatesFactor, long>("PrimaryArtifactId", "mcf.pa", true),
			new TravStepHas<FabMemberCreatesFactor, long>("RelatedArtifactId", "mcf.ra", true),
			TravStepsCustom.HasUserDefinesMemberTimestamp<FabUserDefinesMember, float>("Timestamp", "udm.ts"),
			new TravStepHas<FabUserDefinesMember, byte>("MemberType", "udm.mt", true),
			new TravStepHas<FabUserDefinesMember, long>("AppId", "udm.pi", true),
		};

		public static IList<ITravStep> ToTypeList = new List<ITravStep> {
			new TravStepTo<FabArtifact, FabApp>("App", VertexDomainType.Id.App),
			new TravStepTo<FabVertex, FabApp>("App", VertexDomainType.Id.App),
			new TravStepTo<FabVertex, FabArtifact>("Artifact", VertexDomainType.Id.Artifact),
			new TravStepTo<FabArtifact, FabClass>("Class", VertexDomainType.Id.Class),
			new TravStepTo<FabVertex, FabClass>("Class", VertexDomainType.Id.Class),
			new TravStepTo<FabVertex, FabFactor>("Factor", VertexDomainType.Id.Factor),
			new TravStepTo<FabArtifact, FabInstance>("Instance", VertexDomainType.Id.Instance),
			new TravStepTo<FabVertex, FabInstance>("Instance", VertexDomainType.Id.Instance),
			new TravStepTo<FabVertex, FabMember>("Member", VertexDomainType.Id.Member),
			new TravStepTo<FabArtifact, FabUrl>("Url", VertexDomainType.Id.Url),
			new TravStepTo<FabVertex, FabUrl>("Url", VertexDomainType.Id.Url),
			new TravStepTo<FabArtifact, FabUser>("User", VertexDomainType.Id.User),
			new TravStepTo<FabVertex, FabUser>("User", VertexDomainType.Id.User),
		};

	}

}