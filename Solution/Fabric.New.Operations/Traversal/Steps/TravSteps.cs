
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
			new TravStepWith<FabFactor, byte, FabFactor>("WithAssertionType", "f_at"),
			new TravStepWith<FabFactor, bool, FabFactor>("WithIsDefining", "f_de"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDescriptorType", "f_det"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDirectorType", "f_dit"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDirectorPrimaryAction", "f_dip"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithDirectorRelatedAction", "f_dir"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithEventorType", "f_evt"),
			TravStepsCustom.FactorWhereEventorYear<FabFactor, long, FabFactor>("WhereEventorYear", "f_evd"),
			TravStepsCustom.FactorWhereEventorMonth<FabFactor, byte, FabFactor>("WhereEventorMonth", "f_evd"),
			TravStepsCustom.FactorWhereEventorDay<FabFactor, byte, FabFactor>("WhereEventorDay", "f_evd"),
			TravStepsCustom.FactorWhereEventorHour<FabFactor, byte, FabFactor>("WhereEventorHour", "f_evd"),
			TravStepsCustom.FactorWhereEventorMinute<FabFactor, byte, FabFactor>("WhereEventorMinute", "f_evd"),
			TravStepsCustom.FactorWhereEventorSecond<FabFactor, byte, FabFactor>("WhereEventorSecond", "f_evd"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithIdentorType", "f_idt"),
			new TravStepWith<FabFactor, string, FabFactor>("WithIdentorValue", "f_no"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithLocatorType", "f_lot"),
			new TravStepWhere<FabFactor, double, FabFactor>("WhereLocatorValueX", "f_lox"),
			new TravStepWhere<FabFactor, double, FabFactor>("WhereLocatorValueY", "f_loy"),
			new TravStepWhere<FabFactor, double, FabFactor>("WhereLocatorValueZ", "f_loz"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithVectorType", "f_vet"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithVectorUnit", "f_veu"),
			new TravStepWith<FabFactor, byte, FabFactor>("WithVectorUnitPrefix", "f_vep"),
			new TravStepWhere<FabFactor, long, FabFactor>("WhereVectorValue", "f_vev"),
			new TravStepWith<FabMember, byte, FabMember>("WithType", "m_at"),
			new TravStepWith<FabVertex, long, FabVertex>("WithId", "v_id"),
			TravStepsCustom.VertexWhereTimestamp<FabVertex, long, FabVertex>("WhereTimestamp", "v_ts"),
			new TravStepWith<FabVertex, byte, FabVertex>("WithVertexType", "v_t"),
		};

		public static readonly IList<ITravStep> LinkHasList = new List<ITravStep> {
			TravStepsCustom.AppDefinesMemberWhereTimestamp<FabAppDefinesMember, long, FabAppDefinesMember>("WhereTimestamp", "pdm_ts"),
			new TravStepWith<FabAppDefinesMember, byte, FabAppDefinesMember>("WithMemberType", "pdm_mt"),
			new TravStepWith<FabAppDefinesMember, long, FabAppDefinesMember>("WithUserId", "pdm_ui"),
			TravStepsCustom.ArtifactUsedAsPrimaryByFactorWhereTimestamp<FabArtifactUsedAsPrimaryByFactor, long, FabArtifactUsedAsPrimaryByFactor>("WhereTimestamp", "apbf_ts"),
			new TravStepWith<FabArtifactUsedAsPrimaryByFactor, byte, FabArtifactUsedAsPrimaryByFactor>("WithDescriptorType", "apbf_dt"),
			new TravStepWith<FabArtifactUsedAsPrimaryByFactor, long, FabArtifactUsedAsPrimaryByFactor>("WithRelatedArtifactId", "apbf_ra"),
			TravStepsCustom.ArtifactUsedAsRelatedByFactorWhereTimestamp<FabArtifactUsedAsRelatedByFactor, long, FabArtifactUsedAsRelatedByFactor>("WhereTimestamp", "arbf_ts"),
			new TravStepWith<FabArtifactUsedAsRelatedByFactor, byte, FabArtifactUsedAsRelatedByFactor>("WithDescriptorType", "arbf_dt"),
			new TravStepWith<FabArtifactUsedAsRelatedByFactor, long, FabArtifactUsedAsRelatedByFactor>("WithPrimaryArtifactId", "arbf_pa"),
			TravStepsCustom.MemberCreatesArtifactWhereTimestamp<FabMemberCreatesArtifact, long, FabMemberCreatesArtifact>("WhereTimestamp", "mca_ts"),
			new TravStepWith<FabMemberCreatesArtifact, byte, FabMemberCreatesArtifact>("WithVertexType", "mca_vt"),
			TravStepsCustom.MemberCreatesFactorWhereTimestamp<FabMemberCreatesFactor, long, FabMemberCreatesFactor>("WhereTimestamp", "mcf_ts"),
			new TravStepWith<FabMemberCreatesFactor, byte, FabMemberCreatesFactor>("WithDescriptorType", "mcf_dt"),
			new TravStepWith<FabMemberCreatesFactor, long, FabMemberCreatesFactor>("WithPrimaryArtifactId", "mcf_pa"),
			new TravStepWith<FabMemberCreatesFactor, long, FabMemberCreatesFactor>("WithRelatedArtifactId", "mcf_ra"),
			TravStepsCustom.UserDefinesMemberWhereTimestamp<FabUserDefinesMember, long, FabUserDefinesMember>("WhereTimestamp", "udm_ts"),
			new TravStepWith<FabUserDefinesMember, byte, FabUserDefinesMember>("WithMemberType", "udm_mt"),
			new TravStepWith<FabUserDefinesMember, long, FabUserDefinesMember>("WithAppId", "udm_pi"),
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
			new TravStepEntryContains<FabTravAppRoot, FabApp>("WhereNameContains", "p_na"),
			new TravStepEntryWith<FabTravAppRoot, string, FabApp>("WithName", "p_nk", true),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("WhereNameContains", "c_na"),
			new TravStepEntryWith<FabTravClassRoot, string, FabClass>("WithName", "c_nk", true),
			new TravStepEntryContains<FabTravClassRoot, FabClass>("WhereDisambContains", "c_di"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("WhereNameContains", "i_na"),
			new TravStepEntryContains<FabTravInstanceRoot, FabInstance>("WhereDisambContains", "i_di"),
			new TravStepEntryContains<FabTravUrlRoot, FabUrl>("WhereNameContains", "r_na"),
			new TravStepEntryWith<FabTravUrlRoot, string, FabUrl>("WithFullPath", "r_fp", true),
			new TravStepEntryContains<FabTravUserRoot, FabUser>("WhereNameContains", "u_na"),
			new TravStepEntryWith<FabTravUserRoot, string, FabUser>("WithName", "u_nk", true),
			new TravStepEntryWith<FabTravVertexRoot, long, FabVertex>("WithId", "v_id", false),
			TravStepsCustom.VertexEntryWhereTimestamp<FabTravVertexRoot, long, FabVertex>("Timestamp", "v_ts"),
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