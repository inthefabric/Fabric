﻿
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravSteps {

		public static readonly IList<ITravStep> LinkList = new List<ITravStep> {
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

		public static readonly IList<ITravStep> VertexHasList = new List<ITravStep> {
			new TravStepHas<FabFactor, byte>("HasAssertionType", "f.at", true),
			new TravStepHas<FabFactor, bool>("HasIsDefining", "f.de", true),
			new TravStepHas<FabFactor, byte>("HasDescriptorType", "f.det", true),
			new TravStepHas<FabFactor, byte>("HasDirectorType", "f.dit", true),
			new TravStepHas<FabFactor, byte>("HasDirectorPrimaryAction", "f.dip", true),
			new TravStepHas<FabFactor, byte>("HasDirectorRelatedAction", "f.dir", true),
			new TravStepHas<FabFactor, byte>("HasEventorType", "f.evt", true),
			TravStepsCustom.HasFactorEventorYear<FabFactor, long>("HasEventorYear", "f.evd"),
			TravStepsCustom.HasFactorEventorMonth<FabFactor, byte>("HasEventorMonth", "f.evd"),
			TravStepsCustom.HasFactorEventorDay<FabFactor, byte>("HasEventorDay", "f.evd"),
			TravStepsCustom.HasFactorEventorHour<FabFactor, byte>("HasEventorHour", "f.evd"),
			TravStepsCustom.HasFactorEventorMinute<FabFactor, byte>("HasEventorMinute", "f.evd"),
			TravStepsCustom.HasFactorEventorSecond<FabFactor, byte>("HasEventorSecond", "f.evd"),
			new TravStepHas<FabFactor, byte>("HasIdentorType", "f.idt", true),
			new TravStepHas<FabFactor, string>("HasIdentorValue", "f.no", true),
			new TravStepHas<FabFactor, byte>("HasLocatorType", "f.lot", true),
			new TravStepHas<FabFactor, double>("HasLocatorValueX", "f.lox", false),
			new TravStepHas<FabFactor, double>("HasLocatorValueY", "f.loy", false),
			new TravStepHas<FabFactor, double>("HasLocatorValueZ", "f.loz", false),
			new TravStepHas<FabFactor, byte>("HasVectorType", "f.vet", true),
			new TravStepHas<FabFactor, byte>("HasVectorUnit", "f.veu", true),
			new TravStepHas<FabFactor, byte>("HasVectorUnitPrefix", "f.vep", true),
			new TravStepHas<FabFactor, long>("HasVectorValue", "f.vev", false),
			new TravStepHas<FabMember, byte>("HasType", "m.at", true),
			new TravStepHas<FabVertex, long>("HasId", "v.id", true),
			TravStepsCustom.HasVertexTimestamp<FabVertex, float>("HasTimestamp", "v.ts"),
		};

		public static readonly IList<ITravStep> LinkHasList = new List<ITravStep> {
			TravStepsCustom.HasAppDefinesMemberTimestamp<FabAppDefinesMember, float>("HasTimestamp", "pdm.ts"),
			new TravStepHas<FabAppDefinesMember, byte>("HasMemberType", "pdm.mt", true),
			new TravStepHas<FabAppDefinesMember, long>("HasUserId", "pdm.ui", true),
			TravStepsCustom.HasArtifactUsedAsPrimaryByFactorTimestamp<FabArtifactUsedAsPrimaryByFactor, float>("HasTimestamp", "apbf.ts"),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, byte>("HasDescriptorType", "apbf.dt", true),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, long>("HasRelatedArtifactId", "apbf.ra", true),
			TravStepsCustom.HasArtifactUsedAsRelatedByFactorTimestamp<FabArtifactUsedAsRelatedByFactor, float>("HasTimestamp", "arbf.ts"),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, byte>("HasDescriptorType", "arbf.dt", true),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, long>("HasPrimaryArtifactId", "arbf.pa", true),
			TravStepsCustom.HasMemberCreatesArtifactTimestamp<FabMemberCreatesArtifact, float>("HasTimestamp", "mca.ts"),
			new TravStepHas<FabMemberCreatesArtifact, byte>("HasVertexType", "mca.vt", false),
			TravStepsCustom.HasMemberCreatesFactorTimestamp<FabMemberCreatesFactor, float>("HasTimestamp", "mcf.ts"),
			new TravStepHas<FabMemberCreatesFactor, byte>("HasDescriptorType", "mcf.dt", true),
			new TravStepHas<FabMemberCreatesFactor, long>("HasPrimaryArtifactId", "mcf.pa", true),
			new TravStepHas<FabMemberCreatesFactor, long>("HasRelatedArtifactId", "mcf.ra", true),
			TravStepsCustom.HasUserDefinesMemberTimestamp<FabUserDefinesMember, float>("HasTimestamp", "udm.ts"),
			new TravStepHas<FabUserDefinesMember, byte>("HasMemberType", "udm.mt", true),
			new TravStepHas<FabUserDefinesMember, long>("HasAppId", "udm.pi", true),
		};

		public static readonly IList<ITravStep> LinkTakeList = new List<ITravStep> {
			new TravStepTake<FabAppDefinesMember, FabMember>("TakeMembers", true),
			new TravStepTake<FabArtifactUsedAsPrimaryByFactor, FabFactor>("TakeFactors", true),
			new TravStepTake<FabArtifactUsedAsRelatedByFactor, FabFactor>("TakeFactors", true),
			new TravStepTake<FabMemberCreatesArtifact, FabArtifact>("TakeArtifacts", true),
			new TravStepTake<FabMemberCreatesFactor, FabFactor>("TakeFactors", true),
			new TravStepTake<FabUserDefinesMember, FabMember>("TakeMembers", true),
		};

		public static readonly IList<ITravStep> ToTypeList = new List<ITravStep> {
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

		public static readonly IList<ITravStep> EntryList = new List<ITravStep> {
			new TravStepEntryContains<FabTravAppRoot, FabApp>("NameContains", "p.na"),
			new TravStepEntry<FabTravAppRoot, string, FabApp>("HasName", "p.nk", true, true),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("NameContains", "c.na"),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("DisambContains", "c.di"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("NameContains", "i.na"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("DisambContains", "i.di"),
			new TravStepEntryContains<FabTravUrlRoot, FabUrl>("NameContains", "r.na"),
			new TravStepEntry<FabTravUrlRoot, string, FabUrl>("HasFullPath", "r.fp", false, true),
			new TravStepEntryContains<FabTravUserRoot, FabUser>("NameContains", "u.na"),
			new TravStepEntry<FabTravUserRoot, string, FabUser>("HasName", "u.nk", true, true),
			new TravStepEntry<FabTravVertexRoot, long, FabVertex>("HasId", "v.id", false, false),
			new TravStepEntry<FabTravVertexRoot, float, FabVertex>("HasTimestamp", "v.ts", true, false),
		};

		public static readonly IList<ITravStep> RootList = new List<ITravStep> {
			new TravStepRoot<FabTravAppRoot>("Apps"),
			new TravStepRoot<FabTravArtifactRoot>("Artifacts"),
			new TravStepRoot<FabTravClassRoot>("Classes"),
			new TravStepRoot<FabTravFactorRoot>("Factors"),
			new TravStepRoot<FabTravInstanceRoot>("Instances"),
			new TravStepRoot<FabTravMemberRoot>("Members"),
			new TravStepRoot<FabTravUrlRoot>("Urls"),
			new TravStepRoot<FabTravUserRoot>("Users"),
			new TravStepRoot<FabTravVertexRoot>("Vertices"),
		};

	}

}