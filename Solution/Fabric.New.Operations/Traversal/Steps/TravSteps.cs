
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Enums;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravSteps {

		public static readonly IList<ITravStep> LinkList = new List<ITravStep> {
			new TravStepLink<FabApp, FabAppDefinesMember>("DefinesMembers", "pdm", false),
			new TravStepLink<FabArtifact, FabMember>("CreatedByMember", "acbm", true),
			new TravStepLink<FabArtifact, FabArtifactUsedAsPrimaryByFactor>("UsedAsPrimaryByFactors", "apbf", false),
			new TravStepLink<FabArtifact, FabArtifactUsedAsRelatedByFactor>("UsedAsRelatedByFactors", "arbf", false),
			new TravStepLink<FabFactor, FabMember>("CreatedByMember", "fcbm", true),
			new TravStepLink<FabFactor, FabArtifact>("RefinesPrimaryWithArtifact", "frpa", true),
			new TravStepLink<FabFactor, FabArtifact>("RefinesRelatedWithArtifact", "frra", true),
			new TravStepLink<FabFactor, FabArtifact>("RefinesTypeWithArtifact", "frta", true),
			new TravStepLink<FabFactor, FabArtifact>("UsesPrimaryArtifact", "fpa", true),
			new TravStepLink<FabFactor, FabArtifact>("UsesRelatedArtifact", "fra", true),
			new TravStepLink<FabFactor, FabArtifact>("UsesAxisArtifact", "faa", true),
			new TravStepLink<FabMember, FabMemberCreatesArtifact>("CreatesArtifacts", "mca", false),
			new TravStepLink<FabMember, FabMemberCreatesFactor>("CreatesFactors", "mcf", false),
			new TravStepLink<FabMember, FabApp>("DefinedByApp", "mdbp", true),
			new TravStepLink<FabMember, FabUser>("DefinedByUser", "mdbu", true),
			new TravStepLink<FabUser, FabUserDefinesMember>("DefinesMembers", "udm", false),
		};

		public static readonly IList<ITravStep> VertexHasList = new List<ITravStep> {
			new TravStepHas<FabFactor, byte>("WithAssertionType", "f.at", true),
			new TravStepHas<FabFactor, bool>("WithIsDefining", "f.de", true),
			new TravStepHas<FabFactor, byte>("WithDescriptorType", "f.det", true),
			new TravStepHas<FabFactor, byte>("WithDirectorType", "f.dit", true),
			new TravStepHas<FabFactor, byte>("WithDirectorPrimaryAction", "f.dip", true),
			new TravStepHas<FabFactor, byte>("WithDirectorRelatedAction", "f.dir", true),
			new TravStepHas<FabFactor, byte>("WithEventorType", "f.evt", true),
			TravStepsCustom.FactorWhereEventorYear<FabFactor, long>("WhereEventorYear", "f.evd"),
			TravStepsCustom.FactorWhereEventorMonth<FabFactor, byte>("WhereEventorMonth", "f.evd"),
			TravStepsCustom.FactorWhereEventorDay<FabFactor, byte>("WhereEventorDay", "f.evd"),
			TravStepsCustom.FactorWhereEventorHour<FabFactor, byte>("WhereEventorHour", "f.evd"),
			TravStepsCustom.FactorWhereEventorMinute<FabFactor, byte>("WhereEventorMinute", "f.evd"),
			TravStepsCustom.FactorWhereEventorSecond<FabFactor, byte>("WhereEventorSecond", "f.evd"),
			new TravStepHas<FabFactor, byte>("WithIdentorType", "f.idt", true),
			new TravStepHas<FabFactor, string>("WithIdentorValue", "f.no", true),
			new TravStepHas<FabFactor, byte>("WithLocatorType", "f.lot", true),
			new TravStepHas<FabFactor, double>("WhereLocatorValueX", "f.lox", false),
			new TravStepHas<FabFactor, double>("WhereLocatorValueY", "f.loy", false),
			new TravStepHas<FabFactor, double>("WhereLocatorValueZ", "f.loz", false),
			new TravStepHas<FabFactor, byte>("WithVectorType", "f.vet", true),
			new TravStepHas<FabFactor, byte>("WithVectorUnit", "f.veu", true),
			new TravStepHas<FabFactor, byte>("WithVectorUnitPrefix", "f.vep", true),
			new TravStepHas<FabFactor, long>("WhereVectorValue", "f.vev", false),
			new TravStepHas<FabMember, byte>("WithType", "m.at", true),
			new TravStepHas<FabVertex, long>("WithId", "v.id", true),
			TravStepsCustom.VertexWhereTimestamp<FabVertex, long>("WhereTimestamp", "v.ts"),
			new TravStepHas<FabVertex, byte>("WithVertexType", "v.t", true),
		};

		public static readonly IList<ITravStep> LinkHasList = new List<ITravStep> {
			TravStepsCustom.AppDefinesMemberWhereTimestamp<FabAppDefinesMember, long>("WhereTimestamp", "pdm.ts"),
			new TravStepHas<FabAppDefinesMember, byte>("WithMemberType", "pdm.mt", true),
			new TravStepHas<FabAppDefinesMember, long>("WithUserId", "pdm.ui", true),
			TravStepsCustom.ArtifactUsedAsPrimaryByFactorWhereTimestamp<FabArtifactUsedAsPrimaryByFactor, long>("WhereTimestamp", "apbf.ts"),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, byte>("WithDescriptorType", "apbf.dt", true),
			new TravStepHas<FabArtifactUsedAsPrimaryByFactor, long>("WithRelatedArtifactId", "apbf.ra", true),
			TravStepsCustom.ArtifactUsedAsRelatedByFactorWhereTimestamp<FabArtifactUsedAsRelatedByFactor, long>("WhereTimestamp", "arbf.ts"),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, byte>("WithDescriptorType", "arbf.dt", true),
			new TravStepHas<FabArtifactUsedAsRelatedByFactor, long>("WithPrimaryArtifactId", "arbf.pa", true),
			TravStepsCustom.MemberCreatesArtifactWhereTimestamp<FabMemberCreatesArtifact, long>("WhereTimestamp", "mca.ts"),
			new TravStepHas<FabMemberCreatesArtifact, byte>("WithVertexType", "mca.vt", true),
			TravStepsCustom.MemberCreatesFactorWhereTimestamp<FabMemberCreatesFactor, long>("WhereTimestamp", "mcf.ts"),
			new TravStepHas<FabMemberCreatesFactor, byte>("WithDescriptorType", "mcf.dt", true),
			new TravStepHas<FabMemberCreatesFactor, long>("WithPrimaryArtifactId", "mcf.pa", true),
			new TravStepHas<FabMemberCreatesFactor, long>("WithRelatedArtifactId", "mcf.ra", true),
			TravStepsCustom.UserDefinesMemberWhereTimestamp<FabUserDefinesMember, long>("WhereTimestamp", "udm.ts"),
			new TravStepHas<FabUserDefinesMember, byte>("WithMemberType", "udm.mt", true),
			new TravStepHas<FabUserDefinesMember, long>("WithAppId", "udm.pi", true),
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
			new TravStepTo<FabArtifact, FabApp>("ToApp", VertexType.Id.App),
			new TravStepTo<FabVertex, FabApp>("ToApp", VertexType.Id.App),
			new TravStepTo<FabVertex, FabArtifact>("ToArtifact", VertexType.Id.Artifact),
			new TravStepTo<FabArtifact, FabClass>("ToClass", VertexType.Id.Class),
			new TravStepTo<FabVertex, FabClass>("ToClass", VertexType.Id.Class),
			new TravStepTo<FabVertex, FabFactor>("ToFactor", VertexType.Id.Factor),
			new TravStepTo<FabArtifact, FabInstance>("ToInstance", VertexType.Id.Instance),
			new TravStepTo<FabVertex, FabInstance>("ToInstance", VertexType.Id.Instance),
			new TravStepTo<FabVertex, FabMember>("ToMember", VertexType.Id.Member),
			new TravStepTo<FabArtifact, FabUrl>("ToUrl", VertexType.Id.Url),
			new TravStepTo<FabVertex, FabUrl>("ToUrl", VertexType.Id.Url),
			new TravStepTo<FabArtifact, FabUser>("ToUser", VertexType.Id.User),
			new TravStepTo<FabVertex, FabUser>("ToUser", VertexType.Id.User),
		};

		public static readonly IList<ITravStep> EntryList = new List<ITravStep> {
			new TravStepEntryContains<FabTravAppRoot, FabApp>("WhereNameContains", "p.na"),
			new TravStepEntry<FabTravAppRoot, string, FabApp>("WithName", "p.nk", true, true),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("WhereNameContains", "c.na"),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("WhereDisambContains", "c.di"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("WhereNameContains", "i.na"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("WhereDisambContains", "i.di"),
			new TravStepEntryContains<FabTravUrlRoot, FabUrl>("WhereNameContains", "r.na"),
			new TravStepEntry<FabTravUrlRoot, string, FabUrl>("WithFullPath", "r.fp", true, true),
			new TravStepEntryContains<FabTravUserRoot, FabUser>("WhereNameContains", "u.na"),
			new TravStepEntry<FabTravUserRoot, string, FabUser>("WithName", "u.nk", true, true),
			new TravStepEntry<FabTravVertexRoot, long, FabVertex>("WithId", "v.id", true, false),
			new TravStepEntry<FabTravVertexRoot, long, FabVertex>("WhereTimestamp", "v.ts", false, false),
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