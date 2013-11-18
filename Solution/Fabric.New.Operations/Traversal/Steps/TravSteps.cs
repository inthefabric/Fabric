
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
			new TravStepWith<FabFactor, byte, FabFactor>("WithAssertionType", "f.at"),
			new TravStepWith<FabFactor, bool, FabFactor>("WithIsDefining", "f.de"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDescriptorType", "f.det"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDirectorType", "f.dit"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDirectorPrimaryAction", "f.dip"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDirectorRelatedAction", "f.dir"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithEventorType", "f.evt"),
			TravStepsCustom.FactorWhereEventorYear<FabFactor, long>("WhereEventorYear", "f.evd"),
			TravStepsCustom.FactorWhereEventorMonth<FabFactor, byte>("WhereEventorMonth", "f.evd"),
			TravStepsCustom.FactorWhereEventorDay<FabFactor, byte>("WhereEventorDay", "f.evd"),
			TravStepsCustom.FactorWhereEventorHour<FabFactor, byte>("WhereEventorHour", "f.evd"),
			TravStepsCustom.FactorWhereEventorMinute<FabFactor, byte>("WhereEventorMinute", "f.evd"),
			TravStepsCustom.FactorWhereEventorSecond<FabFactor, byte>("WhereEventorSecond", "f.evd"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithIdentorType", "f.idt"),
			new TravStepWith<FabFactor, string, FabFactor>("WithIdentorValue", "f.no"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithLocatorType", "f.lot"),
			new TravStepWhere<FabFactor, double, FabFactor>("WhereLocatorValueX", "f.lox"),
			new TravStepWhere<FabFactor, double, FabFactor>("WhereLocatorValueY", "f.loy"),
			new TravStepWhere<FabFactor, double, FabFactor>("WhereLocatorValueZ", "f.loz"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithVectorType", "f.vet"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithVectorUnit", "f.veu"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithVectorUnitPrefix", "f.vep"),
			new TravStepWhere<FabFactor, long, FabFactor>("WhereVectorValue", "f.vev"),
			new TravStepWith<FabMember, byte, FabMember>("WithType", "m.at"),
			new TravStepWith<FabVertex, long, FabVertex>("WithId", "v.id"),
			TravStepsCustom.VertexWhereTimestamp<FabVertex, long>("WhereTimestamp", "v.ts"),
			new TravStepWith<FabVertex, byte, FabVertex>("WithVertexType", "v.t"),
		};

		public static readonly IList<ITravStep> LinkHasList = new List<ITravStep> {
			TravStepsCustom.AppDefinesMemberWhereTimestamp<FabAppDefinesMember, long>("WhereTimestamp", "pdm.ts"),
			new TravStepWith<FabAppDefinesMember, byte, FabAppDefinesMember>("WithMemberType", "pdm.mt"),
			new TravStepWith<FabAppDefinesMember, long, FabAppDefinesMember>("WithUserId", "pdm.ui"),
			TravStepsCustom.ArtifactUsedAsPrimaryByFactorWhereTimestamp<FabArtifactUsedAsPrimaryByFactor, long>("WhereTimestamp", "apbf.ts"),
			new TravStepWith<FabArtifactUsedAsPrimaryByFactor, byte, FabArtifactUsedAsPrimaryByFactor>("WithDescriptorType", "apbf.dt"),
			new TravStepWith<FabArtifactUsedAsPrimaryByFactor, long, FabArtifactUsedAsPrimaryByFactor>("WithRelatedArtifactId", "apbf.ra"),
			TravStepsCustom.ArtifactUsedAsRelatedByFactorWhereTimestamp<FabArtifactUsedAsRelatedByFactor, long>("WhereTimestamp", "arbf.ts"),
			new TravStepWith<FabArtifactUsedAsRelatedByFactor, byte, FabArtifactUsedAsRelatedByFactor>("WithDescriptorType", "arbf.dt"),
			new TravStepWith<FabArtifactUsedAsRelatedByFactor, long, FabArtifactUsedAsRelatedByFactor>("WithPrimaryArtifactId", "arbf.pa"),
			TravStepsCustom.MemberCreatesArtifactWhereTimestamp<FabMemberCreatesArtifact, long>("WhereTimestamp", "mca.ts"),
			new TravStepWith<FabMemberCreatesArtifact, byte, FabMemberCreatesArtifact>("WithVertexType", "mca.vt"),
			TravStepsCustom.MemberCreatesFactorWhereTimestamp<FabMemberCreatesFactor, long>("WhereTimestamp", "mcf.ts"),
			new TravStepWith<FabMemberCreatesFactor, byte, FabMemberCreatesFactor>("WithDescriptorType", "mcf.dt"),
			new TravStepWith<FabMemberCreatesFactor, long, FabMemberCreatesFactor>("WithPrimaryArtifactId", "mcf.pa"),
			new TravStepWith<FabMemberCreatesFactor, long, FabMemberCreatesFactor>("WithRelatedArtifactId", "mcf.ra"),
			TravStepsCustom.UserDefinesMemberWhereTimestamp<FabUserDefinesMember, long>("WhereTimestamp", "udm.ts"),
			new TravStepWith<FabUserDefinesMember, byte, FabUserDefinesMember>("WithMemberType", "udm.mt"),
			new TravStepWith<FabUserDefinesMember, long, FabUserDefinesMember>("WithAppId", "udm.pi"),
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
			new TravStepEntryWith<FabTravAppRoot, string, FabApp>("WithName", "p.nk", true),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("WhereNameContains", "c.na"),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("WhereDisambContains", "c.di"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("WhereNameContains", "i.na"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("WhereDisambContains", "i.di"),
			new TravStepEntryContains<FabTravUrlRoot, FabUrl>("WhereNameContains", "r.na"),
			new TravStepEntryWith<FabTravUrlRoot, string, FabUrl>("WithFullPath", "r.fp", true),
			new TravStepEntryContains<FabTravUserRoot, FabUser>("WhereNameContains", "u.na"),
			new TravStepEntryWith<FabTravUserRoot, string, FabUser>("WithName", "u.nk", true),
			new TravStepEntryWith<FabTravVertexRoot, long, FabVertex>("WithId", "v.id", false),
			new TravStepEntryWhere<FabTravVertexRoot, long, FabVertex>("WhereTimestamp", "v.ts"),
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