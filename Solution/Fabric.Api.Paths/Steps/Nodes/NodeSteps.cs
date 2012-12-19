// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/19/2012 2:20:25 PM

using Fabric.Api.Dto;

namespace Fabric.Api.Paths.Steps.Nodes {
	
	/*================================================================================================*/
	public interface IContainsAppList {
		AppStep ContainsAppList { get; }
	}

	/*================================================================================================*/
	public interface IContainsArtifactList {
		ArtifactStep ContainsArtifactList { get; }
	}

	/*================================================================================================*/
	public interface IContainsArtifactTypeList {
		ArtifactTypeStep ContainsArtifactTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsCrowdList {
		CrowdStep ContainsCrowdList { get; }
	}

	/*================================================================================================*/
	public interface IContainsCrowdianList {
		CrowdianStep ContainsCrowdianList { get; }
	}

	/*================================================================================================*/
	public interface IContainsCrowdianTypeList {
		CrowdianTypeStep ContainsCrowdianTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsCrowdianTypeAssignList {
		CrowdianTypeAssignStep ContainsCrowdianTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface IContainsLabelList {
		LabelStep ContainsLabelList { get; }
	}

	/*================================================================================================*/
	public interface IContainsMemberList {
		MemberStep ContainsMemberList { get; }
	}

	/*================================================================================================*/
	public interface IContainsMemberTypeList {
		MemberTypeStep ContainsMemberTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsMemberTypeAssignList {
		MemberTypeAssignStep ContainsMemberTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface IContainsThingList {
		ThingStep ContainsThingList { get; }
	}

	/*================================================================================================*/
	public interface IContainsUrlList {
		UrlStep ContainsUrlList { get; }
	}

	/*================================================================================================*/
	public interface IContainsUserList {
		UserStep ContainsUserList { get; }
	}

	/*================================================================================================*/
	public interface IContainsFactorList {
		FactorStep ContainsFactorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsFactorAssertionList {
		FactorAssertionStep ContainsFactorAssertionList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDescriptorList {
		DescriptorStep ContainsDescriptorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDescriptorTypeList {
		DescriptorTypeStep ContainsDescriptorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDirectorList {
		DirectorStep ContainsDirectorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDirectorTypeList {
		DirectorTypeStep ContainsDirectorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsDirectorActionList {
		DirectorActionStep ContainsDirectorActionList { get; }
	}

	/*================================================================================================*/
	public interface IContainsEventorList {
		EventorStep ContainsEventorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsEventorTypeList {
		EventorTypeStep ContainsEventorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsEventorPrecisionList {
		EventorPrecisionStep ContainsEventorPrecisionList { get; }
	}

	/*================================================================================================*/
	public interface IContainsIdentorList {
		IdentorStep ContainsIdentorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsIdentorTypeList {
		IdentorTypeStep ContainsIdentorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsLocatorList {
		LocatorStep ContainsLocatorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsLocatorTypeList {
		LocatorTypeStep ContainsLocatorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorList {
		VectorStep ContainsVectorList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorTypeList {
		VectorTypeStep ContainsVectorTypeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorRangeList {
		VectorRangeStep ContainsVectorRangeList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorRangeLevelList {
		VectorRangeLevelStep ContainsVectorRangeLevelList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorUnitList {
		VectorUnitStep ContainsVectorUnitList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorUnitPrefixList {
		VectorUnitPrefixStep ContainsVectorUnitPrefixList { get; }
	}

	/*================================================================================================*/
	public interface IContainsVectorUnitDerivedList {
		VectorUnitDerivedStep ContainsVectorUnitDerivedList { get; }
	}

	/*================================================================================================*/
	public interface IInRootContains {
		RootStep InRootContains { get; }
	}

	/*================================================================================================*/
	public interface IHasArtifact {
		ArtifactStep HasArtifact { get; }
	}

	/*================================================================================================*/
	public interface IDefinesMemberList {
		MemberStep DefinesMemberList { get; }
	}

	/*================================================================================================*/
	public interface IInAppHas {
		AppStep InAppHas { get; }
	}

	/*================================================================================================*/
	public interface IUsesArtifactType {
		ArtifactTypeStep UsesArtifactType { get; }
	}

	/*================================================================================================*/
	public interface IInCrowdHas {
		CrowdStep InCrowdHas { get; }
	}

	/*================================================================================================*/
	public interface IInLabelHas {
		LabelStep InLabelHas { get; }
	}

	/*================================================================================================*/
	public interface IInMemberCreates {
		MemberStep InMemberCreates { get; }
	}

	/*================================================================================================*/
	public interface IInThingHas {
		ThingStep InThingHas { get; }
	}

	/*================================================================================================*/
	public interface IInUrlHas {
		UrlStep InUrlHas { get; }
	}

	/*================================================================================================*/
	public interface IInUserHas {
		UserStep InUserHas { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUsesPrimary {
		FactorStep InFactorListUsesPrimary { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUsesRelated {
		FactorStep InFactorListUsesRelated { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListRefinesPrimaryWith {
		DescriptorStep InDescriptorListRefinesPrimaryWith { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListRefinesRelatedWith {
		DescriptorStep InDescriptorListRefinesRelatedWith { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListRefinesTypeWith {
		DescriptorStep InDescriptorListRefinesTypeWith { get; }
	}

	/*================================================================================================*/
	public interface IInVectorListUsesAxis {
		VectorStep InVectorListUsesAxis { get; }
	}

	/*================================================================================================*/
	public interface IInArtifactListUses {
		ArtifactStep InArtifactListUses { get; }
	}

	/*================================================================================================*/
	public interface IDefinesCrowdianList {
		CrowdianStep DefinesCrowdianList { get; }
	}

	/*================================================================================================*/
	public interface IInCrowdDefines {
		CrowdStep InCrowdDefines { get; }
	}

	/*================================================================================================*/
	public interface IHasCrowdianTypeAssign {
		CrowdianTypeAssignStep HasCrowdianTypeAssign { get; }
	}

	/*================================================================================================*/
	public interface IHasHistoricCrowdianTypeAssignList {
		CrowdianTypeAssignStep HasHistoricCrowdianTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface IInUserDefines {
		UserStep InUserDefines { get; }
	}

	/*================================================================================================*/
	public interface IInCrowdianTypeAssignListUses {
		CrowdianTypeAssignStep InCrowdianTypeAssignListUses { get; }
	}

	/*================================================================================================*/
	public interface IInCrowdianHas {
		CrowdianStep InCrowdianHas { get; }
	}

	/*================================================================================================*/
	public interface IInCrowdianHasHistoric {
		CrowdianStep InCrowdianHasHistoric { get; }
	}

	/*================================================================================================*/
	public interface IUsesCrowdianType {
		CrowdianTypeStep UsesCrowdianType { get; }
	}

	/*================================================================================================*/
	public interface IInUserCreates {
		UserStep InUserCreates { get; }
	}

	/*================================================================================================*/
	public interface IInAppUses {
		AppStep InAppUses { get; }
	}

	/*================================================================================================*/
	public interface IInUserUses {
		UserStep InUserUses { get; }
	}

	/*================================================================================================*/
	public interface IInAppDefines {
		AppStep InAppDefines { get; }
	}

	/*================================================================================================*/
	public interface IHasMemberTypeAssign {
		MemberTypeAssignStep HasMemberTypeAssign { get; }
	}

	/*================================================================================================*/
	public interface IHasHistoricMemberTypeAssignList {
		MemberTypeAssignStep HasHistoricMemberTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface ICreatesArtifactList {
		ArtifactStep CreatesArtifactList { get; }
	}

	/*================================================================================================*/
	public interface ICreatesMemberTypeAssignList {
		MemberTypeAssignStep CreatesMemberTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface ICreatesFactorList {
		FactorStep CreatesFactorList { get; }
	}

	/*================================================================================================*/
	public interface IInMemberTypeAssignListUses {
		MemberTypeAssignStep InMemberTypeAssignListUses { get; }
	}

	/*================================================================================================*/
	public interface IInMemberHas {
		MemberStep InMemberHas { get; }
	}

	/*================================================================================================*/
	public interface IInMemberHasHistoric {
		MemberStep InMemberHasHistoric { get; }
	}

	/*================================================================================================*/
	public interface IUsesMemberType {
		MemberTypeStep UsesMemberType { get; }
	}

	/*================================================================================================*/
	public interface ICreatesCrowdianTypeAssignList {
		CrowdianTypeAssignStep CreatesCrowdianTypeAssignList { get; }
	}

	/*================================================================================================*/
	public interface IUsesPrimaryArtifact {
		ArtifactStep UsesPrimaryArtifact { get; }
	}

	/*================================================================================================*/
	public interface IUsesRelatedArtifact {
		ArtifactStep UsesRelatedArtifact { get; }
	}

	/*================================================================================================*/
	public interface IUsesFactorAssertion {
		FactorAssertionStep UsesFactorAssertion { get; }
	}

	/*================================================================================================*/
	public interface IReplacesFactor {
		FactorStep ReplacesFactor { get; }
	}

	/*================================================================================================*/
	public interface IUsesDescriptor {
		DescriptorStep UsesDescriptor { get; }
	}

	/*================================================================================================*/
	public interface IUsesDirector {
		DirectorStep UsesDirector { get; }
	}

	/*================================================================================================*/
	public interface IUsesEventor {
		EventorStep UsesEventor { get; }
	}

	/*================================================================================================*/
	public interface IUsesIdentor {
		IdentorStep UsesIdentor { get; }
	}

	/*================================================================================================*/
	public interface IUsesLocator {
		LocatorStep UsesLocator { get; }
	}

	/*================================================================================================*/
	public interface IUsesVector {
		VectorStep UsesVector { get; }
	}

	/*================================================================================================*/
	public interface IInFactorListUses {
		FactorStep InFactorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesDescriptorType {
		DescriptorTypeStep UsesDescriptorType { get; }
	}

	/*================================================================================================*/
	public interface IRefinesPrimaryWithArtifact {
		ArtifactStep RefinesPrimaryWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IRefinesRelatedWithArtifact {
		ArtifactStep RefinesRelatedWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IRefinesTypeWithArtifact {
		ArtifactStep RefinesTypeWithArtifact { get; }
	}

	/*================================================================================================*/
	public interface IInDescriptorListUses {
		DescriptorStep InDescriptorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesDirectorType {
		DirectorTypeStep UsesDirectorType { get; }
	}

	/*================================================================================================*/
	public interface IUsesPrimaryDirectorAction {
		DirectorActionStep UsesPrimaryDirectorAction { get; }
	}

	/*================================================================================================*/
	public interface IUsesRelatedDirectorAction {
		DirectorActionStep UsesRelatedDirectorAction { get; }
	}

	/*================================================================================================*/
	public interface IInDirectorListUses {
		DirectorStep InDirectorListUses { get; }
	}

	/*================================================================================================*/
	public interface IInDirectorListUsesPrimary {
		DirectorStep InDirectorListUsesPrimary { get; }
	}

	/*================================================================================================*/
	public interface IInDirectorListUsesRelated {
		DirectorStep InDirectorListUsesRelated { get; }
	}

	/*================================================================================================*/
	public interface IUsesEventorType {
		EventorTypeStep UsesEventorType { get; }
	}

	/*================================================================================================*/
	public interface IUsesEventorPrecision {
		EventorPrecisionStep UsesEventorPrecision { get; }
	}

	/*================================================================================================*/
	public interface IInEventorListUses {
		EventorStep InEventorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesIdentorType {
		IdentorTypeStep UsesIdentorType { get; }
	}

	/*================================================================================================*/
	public interface IInIdentorListUses {
		IdentorStep InIdentorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesLocatorType {
		LocatorTypeStep UsesLocatorType { get; }
	}

	/*================================================================================================*/
	public interface IInLocatorListUses {
		LocatorStep InLocatorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesAxisArtifact {
		ArtifactStep UsesAxisArtifact { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorType {
		VectorTypeStep UsesVectorType { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorUnit {
		VectorUnitStep UsesVectorUnit { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorUnitPrefix {
		VectorUnitPrefixStep UsesVectorUnitPrefix { get; }
	}

	/*================================================================================================*/
	public interface IInVectorListUses {
		VectorStep InVectorListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorRange {
		VectorRangeStep UsesVectorRange { get; }
	}

	/*================================================================================================*/
	public interface IInVectorTypeListUses {
		VectorTypeStep InVectorTypeListUses { get; }
	}

	/*================================================================================================*/
	public interface IUsesVectorRangeLevelList {
		VectorRangeLevelStep UsesVectorRangeLevelList { get; }
	}

	/*================================================================================================*/
	public interface IInVectorRangeListUses {
		VectorRangeStep InVectorRangeListUses { get; }
	}

	/*================================================================================================*/
	public interface IInVectorUnitDerivedListDefines {
		VectorUnitDerivedStep InVectorUnitDerivedListDefines { get; }
	}

	/*================================================================================================*/
	public interface IInVectorUnitDerivedListRaisesToExp {
		VectorUnitDerivedStep InVectorUnitDerivedListRaisesToExp { get; }
	}

	/*================================================================================================*/
	public interface IInVectorUnitDerivedListUses {
		VectorUnitDerivedStep InVectorUnitDerivedListUses { get; }
	}

	/*================================================================================================*/
	public interface IDefinesVectorUnit {
		VectorUnitStep DefinesVectorUnit { get; }
	}

	/*================================================================================================*/
	public interface IRaisesToExpVectorUnit {
		VectorUnitStep RaisesToExpVectorUnit { get; }
	}

	/*================================================================================================*/
	public interface IUsesApp {
		AppStep UsesApp { get; }
	}

	/*================================================================================================*/
	public interface IUsesUser {
		UserStep UsesUser { get; }
	}

	/*================================================================================================*/
	public partial class RootStep : NodeStep<FabRoot>, IContainsAppList, IContainsArtifactList, IContainsArtifactTypeList, IContainsCrowdList, IContainsCrowdianList, IContainsCrowdianTypeList, IContainsCrowdianTypeAssignList, IContainsLabelList, IContainsMemberList, IContainsMemberTypeList, IContainsMemberTypeAssignList, IContainsThingList, IContainsUrlList, IContainsUserList, IContainsFactorList, IContainsFactorAssertionList, IContainsDescriptorList, IContainsDescriptorTypeList, IContainsDirectorList, IContainsDirectorTypeList, IContainsDirectorActionList, IContainsEventorList, IContainsEventorTypeList, IContainsEventorPrecisionList, IContainsIdentorList, IContainsIdentorTypeList, IContainsLocatorList, IContainsLocatorTypeList, IContainsVectorList, IContainsVectorTypeList, IContainsVectorRangeList, IContainsVectorRangeLevelList, IContainsVectorUnitList, IContainsVectorUnitPrefixList, IContainsVectorUnitDerivedList {
	
		private static readonly string[] AvailNodeSteps = new [] { "/ContainsAppList", "/ContainsArtifactList", "/ContainsArtifactTypeList", "/ContainsCrowdList", "/ContainsCrowdianList", "/ContainsCrowdianTypeList", "/ContainsCrowdianTypeAssignList", "/ContainsLabelList", "/ContainsMemberList", "/ContainsMemberTypeList", "/ContainsMemberTypeAssignList", "/ContainsThingList", "/ContainsUrlList", "/ContainsUserList", "/ContainsFactorList", "/ContainsFactorAssertionList", "/ContainsDescriptorList", "/ContainsDescriptorTypeList", "/ContainsDirectorList", "/ContainsDirectorTypeList", "/ContainsDirectorActionList", "/ContainsEventorList", "/ContainsEventorTypeList", "/ContainsEventorPrecisionList", "/ContainsIdentorList", "/ContainsIdentorTypeList", "/ContainsLocatorList", "/ContainsLocatorTypeList", "/ContainsVectorList", "/ContainsVectorTypeList", "/ContainsVectorRangeList", "/ContainsVectorRangeLevelList", "/ContainsVectorUnitList", "/ContainsVectorUnitPrefixList", "/ContainsVectorUnitDerivedList" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep(bool pIsToNode, Path pPath) : base(pPath) {
			string q;
			
			if ( pPath.Segments.Count == 0 ) {
				q = "g.v(0)";
			}
			else {
				q = (pIsToNode ? "inV" : "outV");
			}
			
			AddPathSegment(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "RootId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "containsapplist": return ContainsAppList;
				case "containsartifactlist": return ContainsArtifactList;
				case "containsartifacttypelist": return ContainsArtifactTypeList;
				case "containscrowdlist": return ContainsCrowdList;
				case "containscrowdianlist": return ContainsCrowdianList;
				case "containscrowdiantypelist": return ContainsCrowdianTypeList;
				case "containscrowdiantypeassignlist": return ContainsCrowdianTypeAssignList;
				case "containslabellist": return ContainsLabelList;
				case "containsmemberlist": return ContainsMemberList;
				case "containsmembertypelist": return ContainsMemberTypeList;
				case "containsmembertypeassignlist": return ContainsMemberTypeAssignList;
				case "containsthinglist": return ContainsThingList;
				case "containsurllist": return ContainsUrlList;
				case "containsuserlist": return ContainsUserList;
				case "containsfactorlist": return ContainsFactorList;
				case "containsfactorassertionlist": return ContainsFactorAssertionList;
				case "containsdescriptorlist": return ContainsDescriptorList;
				case "containsdescriptortypelist": return ContainsDescriptorTypeList;
				case "containsdirectorlist": return ContainsDirectorList;
				case "containsdirectortypelist": return ContainsDirectorTypeList;
				case "containsdirectoractionlist": return ContainsDirectorActionList;
				case "containseventorlist": return ContainsEventorList;
				case "containseventortypelist": return ContainsEventorTypeList;
				case "containseventorprecisionlist": return ContainsEventorPrecisionList;
				case "containsidentorlist": return ContainsIdentorList;
				case "containsidentortypelist": return ContainsIdentorTypeList;
				case "containslocatorlist": return ContainsLocatorList;
				case "containslocatortypelist": return ContainsLocatorTypeList;
				case "containsvectorlist": return ContainsVectorList;
				case "containsvectortypelist": return ContainsVectorTypeList;
				case "containsvectorrangelist": return ContainsVectorRangeList;
				case "containsvectorrangelevellist": return ContainsVectorRangeLevelList;
				case "containsvectorunitlist": return ContainsVectorUnitList;
				case "containsvectorunitprefixlist": return ContainsVectorUnitPrefixList;
				case "containsvectorunitderivedlist": return ContainsVectorUnitDerivedList;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppStep ContainsAppList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsApp')");
				return new AppStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep ContainsArtifactList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeStep ContainsArtifactTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsArtifactType')");
				return new ArtifactTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdStep ContainsCrowdList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsCrowd')");
				return new CrowdStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianStep ContainsCrowdianList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsCrowdian')");
				return new CrowdianStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeStep ContainsCrowdianTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsCrowdianType')");
				return new CrowdianTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignStep ContainsCrowdianTypeAssignList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsCrowdianTypeAssign')");
				return new CrowdianTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LabelStep ContainsLabelList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsLabel')");
				return new LabelStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep ContainsMemberList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsMember')");
				return new MemberStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep ContainsMemberTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsMemberType')");
				return new MemberTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep ContainsMemberTypeAssignList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsMemberTypeAssign')");
				return new MemberTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ThingStep ContainsThingList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsThing')");
				return new ThingStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UrlStep ContainsUrlList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsUrl')");
				return new UrlStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep ContainsUserList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsUser')");
				return new UserStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep ContainsFactorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsFactor')");
				return new FactorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep ContainsFactorAssertionList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsFactorAssertion')");
				return new FactorAssertionStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep ContainsDescriptorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsDescriptor')");
				return new DescriptorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep ContainsDescriptorTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsDescriptorType')");
				return new DescriptorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep ContainsDirectorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsDirector')");
				return new DirectorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep ContainsDirectorTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsDirectorType')");
				return new DirectorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep ContainsDirectorActionList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsDirectorAction')");
				return new DirectorActionStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep ContainsEventorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsEventor')");
				return new EventorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep ContainsEventorTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsEventorType')");
				return new EventorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep ContainsEventorPrecisionList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsEventorPrecision')");
				return new EventorPrecisionStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep ContainsIdentorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsIdentor')");
				return new IdentorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep ContainsIdentorTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsIdentorType')");
				return new IdentorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep ContainsLocatorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsLocator')");
				return new LocatorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep ContainsLocatorTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsLocatorType')");
				return new LocatorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep ContainsVectorList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVector')");
				return new VectorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep ContainsVectorTypeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVectorType')");
				return new VectorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep ContainsVectorRangeList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVectorRange')");
				return new VectorRangeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep ContainsVectorRangeLevelList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVectorRangeLevel')");
				return new VectorRangeLevelStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep ContainsVectorUnitList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVectorUnit')");
				return new VectorUnitStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep ContainsVectorUnitPrefixList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVectorUnitPrefix')");
				return new VectorUnitPrefixStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep ContainsVectorUnitDerivedList {
			get {
				Path.AppendToCurrentSegment("outE('RootContainsVectorUnitDerived')");
				return new VectorUnitDerivedStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class AppStep : NodeStep<FabApp>, IInRootContains, IHasArtifact, IDefinesMemberList {
	
		private static readonly string[] AvailNodeSteps = new [] { "/HasArtifact", "/DefinesMemberList" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "AppId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
				case "definesmemberlist": return DefinesMemberList;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsApp')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				Path.AppendToCurrentSegment("outE('AppHasArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep DefinesMemberList {
			get {
				Path.AppendToCurrentSegment("outE('AppDefinesMember')");
				return new MemberStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class ArtifactStep : NodeStep<FabArtifact>, IInRootContains, IInAppHas, IUsesArtifactType, IInCrowdHas, IInLabelHas, IInMemberCreates, IInThingHas, IInUrlHas, IInUserHas, IInFactorListUsesPrimary, IInFactorListUsesRelated, IInDescriptorListRefinesPrimaryWith, IInDescriptorListRefinesRelatedWith, IInDescriptorListRefinesTypeWith, IInVectorListUsesAxis {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InAppHas", "/UsesArtifactType", "/InCrowdHas", "/InLabelHas", "/InMemberCreates", "/InThingHas", "/InUrlHas", "/InUserHas", "/InFactorListUsesPrimary", "/InFactorListUsesRelated", "/InDescriptorListRefinesPrimaryWith", "/InDescriptorListRefinesRelatedWith", "/InDescriptorListRefinesTypeWith", "/InVectorListUsesAxis" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "ArtifactId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inapphas": return InAppHas;
				case "usesartifacttype": return UsesArtifactType;
				case "incrowdhas": return InCrowdHas;
				case "inlabelhas": return InLabelHas;
				case "inmembercreates": return InMemberCreates;
				case "inthinghas": return InThingHas;
				case "inurlhas": return InUrlHas;
				case "inuserhas": return InUserHas;
				case "infactorlistusesprimary": return InFactorListUsesPrimary;
				case "infactorlistusesrelated": return InFactorListUsesRelated;
				case "indescriptorlistrefinesprimarywith": return InDescriptorListRefinesPrimaryWith;
				case "indescriptorlistrefinesrelatedwith": return InDescriptorListRefinesRelatedWith;
				case "indescriptorlistrefinestypewith": return InDescriptorListRefinesTypeWith;
				case "invectorlistusesaxis": return InVectorListUsesAxis;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsArtifact')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public AppStep InAppHas {
			get {
				Path.AppendToCurrentSegment("inE('AppHasArtifact')");
				return new AppStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeStep UsesArtifactType {
			get {
				Path.AppendToCurrentSegment("outE('ArtifactUsesArtifactType')");
				return new ArtifactTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdStep InCrowdHas {
			get {
				Path.AppendToCurrentSegment("inE('CrowdHasArtifact')");
				return new CrowdStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LabelStep InLabelHas {
			get {
				Path.AppendToCurrentSegment("inE('LabelHasArtifact')");
				return new LabelStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberCreates {
			get {
				Path.AppendToCurrentSegment("inE('MemberCreatesArtifact')");
				return new MemberStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ThingStep InThingHas {
			get {
				Path.AppendToCurrentSegment("inE('ThingHasArtifact')");
				return new ThingStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UrlStep InUrlHas {
			get {
				Path.AppendToCurrentSegment("inE('UrlHasArtifact')");
				return new UrlStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep InUserHas {
			get {
				Path.AppendToCurrentSegment("inE('UserHasArtifact')");
				return new UserStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUsesPrimary {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesPrimaryArtifact')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUsesRelated {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesRelatedArtifact')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListRefinesPrimaryWith {
			get {
				Path.AppendToCurrentSegment("inE('DescriptorRefinesPrimaryWithArtifact')");
				return new DescriptorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListRefinesRelatedWith {
			get {
				Path.AppendToCurrentSegment("inE('DescriptorRefinesRelatedWithArtifact')");
				return new DescriptorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListRefinesTypeWith {
			get {
				Path.AppendToCurrentSegment("inE('DescriptorRefinesTypeWithArtifact')");
				return new DescriptorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUsesAxis {
			get {
				Path.AppendToCurrentSegment("inE('VectorUsesAxisArtifact')");
				return new VectorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class ArtifactTypeStep : NodeStep<FabArtifactType>, IInRootContains, IInArtifactListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InArtifactListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "ArtifactTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inartifactlistuses": return InArtifactListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsArtifactType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep InArtifactListUses {
			get {
				Path.AppendToCurrentSegment("inE('ArtifactUsesArtifactType')");
				return new ArtifactStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class CrowdStep : NodeStep<FabCrowd>, IInRootContains, IHasArtifact, IDefinesCrowdianList {
	
		private static readonly string[] AvailNodeSteps = new [] { "/HasArtifact", "/DefinesCrowdianList" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "CrowdId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
				case "definescrowdianlist": return DefinesCrowdianList;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsCrowd')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				Path.AppendToCurrentSegment("outE('CrowdHasArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianStep DefinesCrowdianList {
			get {
				Path.AppendToCurrentSegment("outE('CrowdDefinesCrowdian')");
				return new CrowdianStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class CrowdianStep : NodeStep<FabCrowdian>, IInRootContains, IInCrowdDefines, IHasCrowdianTypeAssign, IHasHistoricCrowdianTypeAssignList, IInUserDefines {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InCrowdDefines", "/HasCrowdianTypeAssign", "/HasHistoricCrowdianTypeAssignList", "/InUserDefines" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "CrowdianId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "incrowddefines": return InCrowdDefines;
				case "hascrowdiantypeassign": return HasCrowdianTypeAssign;
				case "hashistoriccrowdiantypeassignlist": return HasHistoricCrowdianTypeAssignList;
				case "inuserdefines": return InUserDefines;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsCrowdian')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdStep InCrowdDefines {
			get {
				Path.AppendToCurrentSegment("inE('CrowdDefinesCrowdian')");
				return new CrowdStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignStep HasCrowdianTypeAssign {
			get {
				Path.AppendToCurrentSegment("outE('CrowdianHasCrowdianTypeAssign')");
				return new CrowdianTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignStep HasHistoricCrowdianTypeAssignList {
			get {
				Path.AppendToCurrentSegment("outE('CrowdianHasHistoricCrowdianTypeAssign')");
				return new CrowdianTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep InUserDefines {
			get {
				Path.AppendToCurrentSegment("inE('UserDefinesCrowdian')");
				return new UserStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class CrowdianTypeStep : NodeStep<FabCrowdianType>, IInRootContains, IInCrowdianTypeAssignListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InCrowdianTypeAssignListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "CrowdianTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "incrowdiantypeassignlistuses": return InCrowdianTypeAssignListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsCrowdianType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignStep InCrowdianTypeAssignListUses {
			get {
				Path.AppendToCurrentSegment("inE('CrowdianTypeAssignUsesCrowdianType')");
				return new CrowdianTypeAssignStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class CrowdianTypeAssignStep : NodeStep<FabCrowdianTypeAssign>, IInRootContains, IInCrowdianHas, IInCrowdianHasHistoric, IUsesCrowdianType, IInUserCreates {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InCrowdianHas", "/InCrowdianHasHistoric", "/UsesCrowdianType", "/InUserCreates" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "CrowdianTypeAssignId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "incrowdianhas": return InCrowdianHas;
				case "incrowdianhashistoric": return InCrowdianHasHistoric;
				case "usescrowdiantype": return UsesCrowdianType;
				case "inusercreates": return InUserCreates;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsCrowdianTypeAssign')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianStep InCrowdianHas {
			get {
				Path.AppendToCurrentSegment("inE('CrowdianHasCrowdianTypeAssign')");
				return new CrowdianStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianStep InCrowdianHasHistoric {
			get {
				Path.AppendToCurrentSegment("inE('CrowdianHasHistoricCrowdianTypeAssign')");
				return new CrowdianStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeStep UsesCrowdianType {
			get {
				Path.AppendToCurrentSegment("outE('CrowdianTypeAssignUsesCrowdianType')");
				return new CrowdianTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep InUserCreates {
			get {
				Path.AppendToCurrentSegment("inE('UserCreatesCrowdianTypeAssign')");
				return new UserStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class LabelStep : NodeStep<FabLabel>, IInRootContains, IHasArtifact {
	
		private static readonly string[] AvailNodeSteps = new [] { "/HasArtifact" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LabelStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "LabelId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsLabel')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				Path.AppendToCurrentSegment("outE('LabelHasArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberStep : NodeStep<FabMember>, IInRootContains, IInAppDefines, IHasMemberTypeAssign, IHasHistoricMemberTypeAssignList, ICreatesArtifactList, ICreatesMemberTypeAssignList, ICreatesFactorList, IInUserDefines {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InAppDefines", "/HasMemberTypeAssign", "/HasHistoricMemberTypeAssignList", "/CreatesArtifactList", "/CreatesMemberTypeAssignList", "/CreatesFactorList", "/InUserDefines" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "MemberId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inappdefines": return InAppDefines;
				case "hasmembertypeassign": return HasMemberTypeAssign;
				case "hashistoricmembertypeassignlist": return HasHistoricMemberTypeAssignList;
				case "createsartifactlist": return CreatesArtifactList;
				case "createsmembertypeassignlist": return CreatesMemberTypeAssignList;
				case "createsfactorlist": return CreatesFactorList;
				case "inuserdefines": return InUserDefines;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsMember')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public AppStep InAppDefines {
			get {
				Path.AppendToCurrentSegment("inE('AppDefinesMember')");
				return new AppStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep HasMemberTypeAssign {
			get {
				Path.AppendToCurrentSegment("outE('MemberHasMemberTypeAssign')");
				return new MemberTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep HasHistoricMemberTypeAssignList {
			get {
				Path.AppendToCurrentSegment("outE('MemberHasHistoricMemberTypeAssign')");
				return new MemberTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep CreatesArtifactList {
			get {
				Path.AppendToCurrentSegment("outE('MemberCreatesArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep CreatesMemberTypeAssignList {
			get {
				Path.AppendToCurrentSegment("outE('MemberCreatesMemberTypeAssign')");
				return new MemberTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep CreatesFactorList {
			get {
				Path.AppendToCurrentSegment("outE('MemberCreatesFactor')");
				return new FactorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep InUserDefines {
			get {
				Path.AppendToCurrentSegment("inE('UserDefinesMember')");
				return new UserStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeStep : NodeStep<FabMemberType>, IInRootContains, IInMemberTypeAssignListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InMemberTypeAssignListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "MemberTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inmembertypeassignlistuses": return InMemberTypeAssignListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsMemberType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep InMemberTypeAssignListUses {
			get {
				Path.AppendToCurrentSegment("inE('MemberTypeAssignUsesMemberType')");
				return new MemberTypeAssignStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeAssignStep : NodeStep<FabMemberTypeAssign>, IInRootContains, IInMemberHas, IInMemberHasHistoric, IInMemberCreates, IUsesMemberType {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InMemberHas", "/InMemberHasHistoric", "/InMemberCreates", "/UsesMemberType" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "MemberTypeAssignId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inmemberhas": return InMemberHas;
				case "inmemberhashistoric": return InMemberHasHistoric;
				case "inmembercreates": return InMemberCreates;
				case "usesmembertype": return UsesMemberType;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsMemberTypeAssign')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberHas {
			get {
				Path.AppendToCurrentSegment("inE('MemberHasMemberTypeAssign')");
				return new MemberStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberHasHistoric {
			get {
				Path.AppendToCurrentSegment("inE('MemberHasHistoricMemberTypeAssign')");
				return new MemberStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberCreates {
			get {
				Path.AppendToCurrentSegment("inE('MemberCreatesMemberTypeAssign')");
				return new MemberStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep UsesMemberType {
			get {
				Path.AppendToCurrentSegment("outE('MemberTypeAssignUsesMemberType')");
				return new MemberTypeStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class ThingStep : NodeStep<FabThing>, IInRootContains, IHasArtifact {
	
		private static readonly string[] AvailNodeSteps = new [] { "/HasArtifact" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ThingStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "ThingId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsThing')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				Path.AppendToCurrentSegment("outE('ThingHasArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class UrlStep : NodeStep<FabUrl>, IInRootContains, IHasArtifact {
	
		private static readonly string[] AvailNodeSteps = new [] { "/HasArtifact" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "UrlId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsUrl')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				Path.AppendToCurrentSegment("outE('UrlHasArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class UserStep : NodeStep<FabUser>, IInRootContains, IHasArtifact, ICreatesCrowdianTypeAssignList, IDefinesCrowdianList, IDefinesMemberList {
	
		private static readonly string[] AvailNodeSteps = new [] { "/HasArtifact", "/CreatesCrowdianTypeAssignList", "/DefinesCrowdianList", "/DefinesMemberList" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "UserId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
				case "createscrowdiantypeassignlist": return CreatesCrowdianTypeAssignList;
				case "definescrowdianlist": return DefinesCrowdianList;
				case "definesmemberlist": return DefinesMemberList;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsUser')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				Path.AppendToCurrentSegment("outE('UserHasArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignStep CreatesCrowdianTypeAssignList {
			get {
				Path.AppendToCurrentSegment("outE('UserCreatesCrowdianTypeAssign')");
				return new CrowdianTypeAssignStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public CrowdianStep DefinesCrowdianList {
			get {
				Path.AppendToCurrentSegment("outE('UserDefinesCrowdian')");
				return new CrowdianStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep DefinesMemberList {
			get {
				Path.AppendToCurrentSegment("outE('UserDefinesMember')");
				return new MemberStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class FactorStep : NodeStep<FabFactor>, IInRootContains, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IUsesFactorAssertion, IReplacesFactor, IUsesDescriptor, IUsesDirector, IUsesEventor, IUsesIdentor, IUsesLocator, IUsesVector {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InMemberCreates", "/UsesPrimaryArtifact", "/UsesRelatedArtifact", "/UsesFactorAssertion", "/ReplacesFactor", "/UsesDescriptor", "/UsesDirector", "/UsesEventor", "/UsesIdentor", "/UsesLocator", "/UsesVector" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "FactorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inmembercreates": return InMemberCreates;
				case "usesprimaryartifact": return UsesPrimaryArtifact;
				case "usesrelatedartifact": return UsesRelatedArtifact;
				case "usesfactorassertion": return UsesFactorAssertion;
				case "replacesfactor": return ReplacesFactor;
				case "usesdescriptor": return UsesDescriptor;
				case "usesdirector": return UsesDirector;
				case "useseventor": return UsesEventor;
				case "usesidentor": return UsesIdentor;
				case "useslocator": return UsesLocator;
				case "usesvector": return UsesVector;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsFactor')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberCreates {
			get {
				Path.AppendToCurrentSegment("inE('MemberCreatesFactor')");
				return new MemberStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep UsesPrimaryArtifact {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesPrimaryArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep UsesRelatedArtifact {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesRelatedArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep UsesFactorAssertion {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesFactorAssertion')");
				return new FactorAssertionStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep ReplacesFactor {
			get {
				Path.AppendToCurrentSegment("outE('FactorReplacesFactor')");
				return new FactorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep UsesDescriptor {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesDescriptor')");
				return new DescriptorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep UsesDirector {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesDirector')");
				return new DirectorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep UsesEventor {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesEventor')");
				return new EventorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep UsesIdentor {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesIdentor')");
				return new IdentorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep UsesLocator {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesLocator')");
				return new LocatorStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep UsesVector {
			get {
				Path.AppendToCurrentSegment("outE('FactorUsesVector')");
				return new VectorStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class FactorAssertionStep : NodeStep<FabFactorAssertion>, IInRootContains, IInFactorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "FactorAssertionId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsFactorAssertion')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesFactorAssertion')");
				return new FactorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class DescriptorStep : NodeStep<FabDescriptor>, IInRootContains, IInFactorListUses, IUsesDescriptorType, IRefinesPrimaryWithArtifact, IRefinesRelatedWithArtifact, IRefinesTypeWithArtifact {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses", "/UsesDescriptorType", "/RefinesPrimaryWithArtifact", "/RefinesRelatedWithArtifact", "/RefinesTypeWithArtifact" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DescriptorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesdescriptortype": return UsesDescriptorType;
				case "refinesprimarywithartifact": return RefinesPrimaryWithArtifact;
				case "refinesrelatedwithartifact": return RefinesRelatedWithArtifact;
				case "refinestypewithartifact": return RefinesTypeWithArtifact;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsDescriptor')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesDescriptor')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep UsesDescriptorType {
			get {
				Path.AppendToCurrentSegment("outE('DescriptorUsesDescriptorType')");
				return new DescriptorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep RefinesPrimaryWithArtifact {
			get {
				Path.AppendToCurrentSegment("outE('DescriptorRefinesPrimaryWithArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep RefinesRelatedWithArtifact {
			get {
				Path.AppendToCurrentSegment("outE('DescriptorRefinesRelatedWithArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep RefinesTypeWithArtifact {
			get {
				Path.AppendToCurrentSegment("outE('DescriptorRefinesTypeWithArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class DescriptorTypeStep : NodeStep<FabDescriptorType>, IInRootContains, IInDescriptorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InDescriptorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DescriptorTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "indescriptorlistuses": return InDescriptorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsDescriptorType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListUses {
			get {
				Path.AppendToCurrentSegment("inE('DescriptorUsesDescriptorType')");
				return new DescriptorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorStep : NodeStep<FabDirector>, IInRootContains, IInFactorListUses, IUsesDirectorType, IUsesPrimaryDirectorAction, IUsesRelatedDirectorAction {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses", "/UsesDirectorType", "/UsesPrimaryDirectorAction", "/UsesRelatedDirectorAction" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DirectorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesdirectortype": return UsesDirectorType;
				case "usesprimarydirectoraction": return UsesPrimaryDirectorAction;
				case "usesrelateddirectoraction": return UsesRelatedDirectorAction;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsDirector')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesDirector')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep UsesDirectorType {
			get {
				Path.AppendToCurrentSegment("outE('DirectorUsesDirectorType')");
				return new DirectorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep UsesPrimaryDirectorAction {
			get {
				Path.AppendToCurrentSegment("outE('DirectorUsesPrimaryDirectorAction')");
				return new DirectorActionStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep UsesRelatedDirectorAction {
			get {
				Path.AppendToCurrentSegment("outE('DirectorUsesRelatedDirectorAction')");
				return new DirectorActionStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorTypeStep : NodeStep<FabDirectorType>, IInRootContains, IInDirectorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InDirectorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DirectorTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "indirectorlistuses": return InDirectorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsDirectorType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep InDirectorListUses {
			get {
				Path.AppendToCurrentSegment("inE('DirectorUsesDirectorType')");
				return new DirectorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorActionStep : NodeStep<FabDirectorAction>, IInRootContains, IInDirectorListUsesPrimary, IInDirectorListUsesRelated {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InDirectorListUsesPrimary", "/InDirectorListUsesRelated" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DirectorActionId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "indirectorlistusesprimary": return InDirectorListUsesPrimary;
				case "indirectorlistusesrelated": return InDirectorListUsesRelated;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsDirectorAction')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep InDirectorListUsesPrimary {
			get {
				Path.AppendToCurrentSegment("inE('DirectorUsesPrimaryDirectorAction')");
				return new DirectorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep InDirectorListUsesRelated {
			get {
				Path.AppendToCurrentSegment("inE('DirectorUsesRelatedDirectorAction')");
				return new DirectorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorStep : NodeStep<FabEventor>, IInRootContains, IInFactorListUses, IUsesEventorType, IUsesEventorPrecision {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses", "/UsesEventorType", "/UsesEventorPrecision" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "EventorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "useseventortype": return UsesEventorType;
				case "useseventorprecision": return UsesEventorPrecision;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsEventor')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesEventor')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep UsesEventorType {
			get {
				Path.AppendToCurrentSegment("outE('EventorUsesEventorType')");
				return new EventorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep UsesEventorPrecision {
			get {
				Path.AppendToCurrentSegment("outE('EventorUsesEventorPrecision')");
				return new EventorPrecisionStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorTypeStep : NodeStep<FabEventorType>, IInRootContains, IInEventorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InEventorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "EventorTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "ineventorlistuses": return InEventorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsEventorType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep InEventorListUses {
			get {
				Path.AppendToCurrentSegment("inE('EventorUsesEventorType')");
				return new EventorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorPrecisionStep : NodeStep<FabEventorPrecision>, IInRootContains, IInEventorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InEventorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "EventorPrecisionId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "ineventorlistuses": return InEventorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsEventorPrecision')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep InEventorListUses {
			get {
				Path.AppendToCurrentSegment("inE('EventorUsesEventorPrecision')");
				return new EventorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class IdentorStep : NodeStep<FabIdentor>, IInRootContains, IInFactorListUses, IUsesIdentorType {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses", "/UsesIdentorType" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "IdentorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesidentortype": return UsesIdentorType;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsIdentor')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesIdentor')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep UsesIdentorType {
			get {
				Path.AppendToCurrentSegment("outE('IdentorUsesIdentorType')");
				return new IdentorTypeStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class IdentorTypeStep : NodeStep<FabIdentorType>, IInRootContains, IInIdentorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InIdentorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "IdentorTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inidentorlistuses": return InIdentorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsIdentorType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep InIdentorListUses {
			get {
				Path.AppendToCurrentSegment("inE('IdentorUsesIdentorType')");
				return new IdentorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class LocatorStep : NodeStep<FabLocator>, IInRootContains, IInFactorListUses, IUsesLocatorType {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses", "/UsesLocatorType" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "LocatorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "useslocatortype": return UsesLocatorType;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsLocator')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesLocator')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep UsesLocatorType {
			get {
				Path.AppendToCurrentSegment("outE('LocatorUsesLocatorType')");
				return new LocatorTypeStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class LocatorTypeStep : NodeStep<FabLocatorType>, IInRootContains, IInLocatorListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InLocatorListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "LocatorTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "inlocatorlistuses": return InLocatorListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsLocatorType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep InLocatorListUses {
			get {
				Path.AppendToCurrentSegment("inE('LocatorUsesLocatorType')");
				return new LocatorStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorStep : NodeStep<FabVector>, IInRootContains, IInFactorListUses, IUsesAxisArtifact, IUsesVectorType, IUsesVectorUnit, IUsesVectorUnitPrefix {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InFactorListUses", "/UsesAxisArtifact", "/UsesVectorType", "/UsesVectorUnit", "/UsesVectorUnitPrefix" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesaxisartifact": return UsesAxisArtifact;
				case "usesvectortype": return UsesVectorType;
				case "usesvectorunit": return UsesVectorUnit;
				case "usesvectorunitprefix": return UsesVectorUnitPrefix;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVector')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				Path.AppendToCurrentSegment("inE('FactorUsesVector')");
				return new FactorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep UsesAxisArtifact {
			get {
				Path.AppendToCurrentSegment("outE('VectorUsesAxisArtifact')");
				return new ArtifactStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep UsesVectorType {
			get {
				Path.AppendToCurrentSegment("outE('VectorUsesVectorType')");
				return new VectorTypeStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep UsesVectorUnit {
			get {
				Path.AppendToCurrentSegment("outE('VectorUsesVectorUnit')");
				return new VectorUnitStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep UsesVectorUnitPrefix {
			get {
				Path.AppendToCurrentSegment("outE('VectorUsesVectorUnitPrefix')");
				return new VectorUnitPrefixStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorTypeStep : NodeStep<FabVectorType>, IInRootContains, IInVectorListUses, IUsesVectorRange {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InVectorListUses", "/UsesVectorRange" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorTypeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "invectorlistuses": return InVectorListUses;
				case "usesvectorrange": return UsesVectorRange;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVectorType')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUses {
			get {
				Path.AppendToCurrentSegment("inE('VectorUsesVectorType')");
				return new VectorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep UsesVectorRange {
			get {
				Path.AppendToCurrentSegment("outE('VectorTypeUsesVectorRange')");
				return new VectorRangeStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeStep : NodeStep<FabVectorRange>, IInRootContains, IInVectorTypeListUses, IUsesVectorRangeLevelList {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InVectorTypeListUses", "/UsesVectorRangeLevelList" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorRangeId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "invectortypelistuses": return InVectorTypeListUses;
				case "usesvectorrangelevellist": return UsesVectorRangeLevelList;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVectorRange')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep InVectorTypeListUses {
			get {
				Path.AppendToCurrentSegment("inE('VectorTypeUsesVectorRange')");
				return new VectorTypeStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep UsesVectorRangeLevelList {
			get {
				Path.AppendToCurrentSegment("outE('VectorRangeUsesVectorRangeLevel')");
				return new VectorRangeLevelStep(true, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeLevelStep : NodeStep<FabVectorRangeLevel>, IInRootContains, IInVectorRangeListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InVectorRangeListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorRangeLevelId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "invectorrangelistuses": return InVectorRangeListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVectorRangeLevel')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep InVectorRangeListUses {
			get {
				Path.AppendToCurrentSegment("inE('VectorRangeUsesVectorRangeLevel')");
				return new VectorRangeStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitStep : NodeStep<FabVectorUnit>, IInRootContains, IInVectorListUses, IInVectorUnitDerivedListDefines, IInVectorUnitDerivedListRaisesToExp {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InVectorListUses", "/InVectorUnitDerivedListDefines", "/InVectorUnitDerivedListRaisesToExp" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorUnitId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "invectorlistuses": return InVectorListUses;
				case "invectorunitderivedlistdefines": return InVectorUnitDerivedListDefines;
				case "invectorunitderivedlistraisestoexp": return InVectorUnitDerivedListRaisesToExp;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVectorUnit')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUses {
			get {
				Path.AppendToCurrentSegment("inE('VectorUsesVectorUnit')");
				return new VectorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep InVectorUnitDerivedListDefines {
			get {
				Path.AppendToCurrentSegment("inE('VectorUnitDerivedDefinesVectorUnit')");
				return new VectorUnitDerivedStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep InVectorUnitDerivedListRaisesToExp {
			get {
				Path.AppendToCurrentSegment("inE('VectorUnitDerivedRaisesToExpVectorUnit')");
				return new VectorUnitDerivedStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitPrefixStep : NodeStep<FabVectorUnitPrefix>, IInRootContains, IInVectorListUses, IInVectorUnitDerivedListUses {
	
		private static readonly string[] AvailNodeSteps = new [] { "/InVectorListUses", "/InVectorUnitDerivedListUses" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorUnitPrefixId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "invectorlistuses": return InVectorListUses;
				case "invectorunitderivedlistuses": return InVectorUnitDerivedListUses;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVectorUnitPrefix')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUses {
			get {
				Path.AppendToCurrentSegment("inE('VectorUsesVectorUnitPrefix')");
				return new VectorStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep InVectorUnitDerivedListUses {
			get {
				Path.AppendToCurrentSegment("inE('VectorUnitDerivedUsesVectorUnitPrefix')");
				return new VectorUnitDerivedStep(false, Path);
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitDerivedStep : NodeStep<FabVectorUnitDerived>, IInRootContains, IDefinesVectorUnit, IRaisesToExpVectorUnit, IUsesVectorUnitPrefix {
	
		private static readonly string[] AvailNodeSteps = new [] { "/DefinesVectorUnit", "/RaisesToExpVectorUnit", "/UsesVectorUnitPrefix" };


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep(bool pIsToNode, Path pPath) : base(pPath) {
			AddPathSegment(pIsToNode ? "inV" : "outV");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorUnitDerivedId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get {
				string[] baseSteps = base.AvailableSteps;
				var mergeSteps = new string[baseSteps.Length+AvailNodeSteps.Length];
				base.AvailableSteps.CopyTo(mergeSteps, 0);
				AvailNodeSteps.CopyTo(mergeSteps, baseSteps.Length);
				return mergeSteps;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "definesvectorunit": return DefinesVectorUnit;
				case "raisestoexpvectorunit": return RaisesToExpVectorUnit;
				case "usesvectorunitprefix": return UsesVectorUnitPrefix;
			}

			return base.GetNextStep(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				Path.AppendToCurrentSegment("inE('RootContainsVectorUnitDerived')");
				return new RootStep(false, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep DefinesVectorUnit {
			get {
				Path.AppendToCurrentSegment("outE('VectorUnitDerivedDefinesVectorUnit')");
				return new VectorUnitStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep RaisesToExpVectorUnit {
			get {
				Path.AppendToCurrentSegment("outE('VectorUnitDerivedRaisesToExpVectorUnit')");
				return new VectorUnitStep(true, Path);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep UsesVectorUnitPrefix {
			get {
				Path.AppendToCurrentSegment("outE('VectorUnitDerivedUsesVectorUnitPrefix')");
				return new VectorUnitPrefixStep(true, Path);
			}
		}

	}

}