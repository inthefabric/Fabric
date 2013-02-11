// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 2/11/2013 3:18:01 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Nodes {
	
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
	public interface IContainsClassList {
		ClassStep ContainsClassList { get; }
	}

	/*================================================================================================*/
	public interface IContainsInstanceList {
		InstanceStep ContainsInstanceList { get; }
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
	public interface IInClassHas {
		ClassStep InClassHas { get; }
	}

	/*================================================================================================*/
	public interface IInInstanceHas {
		InstanceStep InInstanceHas { get; }
	}

	/*================================================================================================*/
	public interface IInMemberCreates {
		MemberStep InMemberCreates { get; }
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
	public interface IInUserDefines {
		UserStep InUserDefines { get; }
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
	public partial class RootStep : NodeStep<FabRoot>, IFinalStep, IContainsAppList, IContainsArtifactList, IContainsArtifactTypeList, IContainsClassList, IContainsInstanceList, IContainsMemberList, IContainsMemberTypeList, IContainsMemberTypeAssignList, IContainsUrlList, IContainsUserList, IContainsFactorList, IContainsFactorAssertionList, IContainsDescriptorList, IContainsDescriptorTypeList, IContainsDirectorList, IContainsDirectorTypeList, IContainsDirectorActionList, IContainsEventorList, IContainsEventorTypeList, IContainsEventorPrecisionList, IContainsIdentorList, IContainsIdentorTypeList, IContainsLocatorList, IContainsLocatorTypeList, IContainsVectorList, IContainsVectorTypeList, IContainsVectorRangeList, IContainsVectorRangeLevelList, IContainsVectorUnitList, IContainsVectorUnitPrefixList, IContainsVectorUnitDerivedList {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Contains", "App", true, "/ContainsAppList"),
			new StepLink("Contains", "Artifact", true, "/ContainsArtifactList"),
			new StepLink("Contains", "ArtifactType", true, "/ContainsArtifactTypeList"),
			new StepLink("Contains", "Class", true, "/ContainsClassList"),
			new StepLink("Contains", "Instance", true, "/ContainsInstanceList"),
			new StepLink("Contains", "Member", true, "/ContainsMemberList"),
			new StepLink("Contains", "MemberType", true, "/ContainsMemberTypeList"),
			new StepLink("Contains", "MemberTypeAssign", true, "/ContainsMemberTypeAssignList"),
			new StepLink("Contains", "Url", true, "/ContainsUrlList"),
			new StepLink("Contains", "User", true, "/ContainsUserList"),
			new StepLink("Contains", "Factor", true, "/ContainsFactorList"),
			new StepLink("Contains", "FactorAssertion", true, "/ContainsFactorAssertionList"),
			new StepLink("Contains", "Descriptor", true, "/ContainsDescriptorList"),
			new StepLink("Contains", "DescriptorType", true, "/ContainsDescriptorTypeList"),
			new StepLink("Contains", "Director", true, "/ContainsDirectorList"),
			new StepLink("Contains", "DirectorType", true, "/ContainsDirectorTypeList"),
			new StepLink("Contains", "DirectorAction", true, "/ContainsDirectorActionList"),
			new StepLink("Contains", "Eventor", true, "/ContainsEventorList"),
			new StepLink("Contains", "EventorType", true, "/ContainsEventorTypeList"),
			new StepLink("Contains", "EventorPrecision", true, "/ContainsEventorPrecisionList"),
			new StepLink("Contains", "Identor", true, "/ContainsIdentorList"),
			new StepLink("Contains", "IdentorType", true, "/ContainsIdentorTypeList"),
			new StepLink("Contains", "Locator", true, "/ContainsLocatorList"),
			new StepLink("Contains", "LocatorType", true, "/ContainsLocatorTypeList"),
			new StepLink("Contains", "Vector", true, "/ContainsVectorList"),
			new StepLink("Contains", "VectorType", true, "/ContainsVectorTypeList"),
			new StepLink("Contains", "VectorRange", true, "/ContainsVectorRangeList"),
			new StepLink("Contains", "VectorRangeLevel", true, "/ContainsVectorRangeLevelList"),
			new StepLink("Contains", "VectorUnit", true, "/ContainsVectorUnitList"),
			new StepLink("Contains", "VectorUnitPrefix", true, "/ContainsVectorUnitPrefixList"),
			new StepLink("Contains", "VectorUnitDerived", true, "/ContainsVectorUnitDerivedList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep(Path pPath) : base(pPath) {
			if ( Path.Segments.Count == 0 ) {
				Path.AddSegment(this, "g"+(Path.StartAtRoot ? ".V('RootId',0)[0]" : ""));
			}

			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "RootId"; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "containsapplist": return ContainsAppList;
				case "containsartifactlist": return ContainsArtifactList;
				case "containsartifacttypelist": return ContainsArtifactTypeList;
				case "containsclasslist": return ContainsClassList;
				case "containsinstancelist": return ContainsInstanceList;
				case "containsmemberlist": return ContainsMemberList;
				case "containsmembertypelist": return ContainsMemberTypeList;
				case "containsmembertypeassignlist": return ContainsMemberTypeAssignList;
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

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppStep ContainsAppList {
			get {
				var step = new AppStep(Path);
				Path.AddSegment(step, "outE('RootContainsApp').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep ContainsArtifactList {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('RootContainsArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeStep ContainsArtifactTypeList {
			get {
				var step = new ArtifactTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsArtifactType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ClassStep ContainsClassList {
			get {
				var step = new ClassStep(Path);
				Path.AddSegment(step, "outE('RootContainsClass').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public InstanceStep ContainsInstanceList {
			get {
				var step = new InstanceStep(Path);
				Path.AddSegment(step, "outE('RootContainsInstance').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep ContainsMemberList {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "outE('RootContainsMember').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep ContainsMemberTypeList {
			get {
				var step = new MemberTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsMemberType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep ContainsMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('RootContainsMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UrlStep ContainsUrlList {
			get {
				var step = new UrlStep(Path);
				Path.AddSegment(step, "outE('RootContainsUrl').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep ContainsUserList {
			get {
				var step = new UserStep(Path);
				Path.AddSegment(step, "outE('RootContainsUser').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep ContainsFactorList {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "outE('RootContainsFactor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep ContainsFactorAssertionList {
			get {
				var step = new FactorAssertionStep(Path);
				Path.AddSegment(step, "outE('RootContainsFactorAssertion').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep ContainsDescriptorList {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "outE('RootContainsDescriptor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep ContainsDescriptorTypeList {
			get {
				var step = new DescriptorTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsDescriptorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep ContainsDirectorList {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "outE('RootContainsDirector').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep ContainsDirectorTypeList {
			get {
				var step = new DirectorTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsDirectorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep ContainsDirectorActionList {
			get {
				var step = new DirectorActionStep(Path);
				Path.AddSegment(step, "outE('RootContainsDirectorAction').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep ContainsEventorList {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "outE('RootContainsEventor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep ContainsEventorTypeList {
			get {
				var step = new EventorTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsEventorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep ContainsEventorPrecisionList {
			get {
				var step = new EventorPrecisionStep(Path);
				Path.AddSegment(step, "outE('RootContainsEventorPrecision').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep ContainsIdentorList {
			get {
				var step = new IdentorStep(Path);
				Path.AddSegment(step, "outE('RootContainsIdentor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep ContainsIdentorTypeList {
			get {
				var step = new IdentorTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsIdentorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep ContainsLocatorList {
			get {
				var step = new LocatorStep(Path);
				Path.AddSegment(step, "outE('RootContainsLocator').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep ContainsLocatorTypeList {
			get {
				var step = new LocatorTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsLocatorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep ContainsVectorList {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "outE('RootContainsVector').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep ContainsVectorTypeList {
			get {
				var step = new VectorTypeStep(Path);
				Path.AddSegment(step, "outE('RootContainsVectorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep ContainsVectorRangeList {
			get {
				var step = new VectorRangeStep(Path);
				Path.AddSegment(step, "outE('RootContainsVectorRange').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep ContainsVectorRangeLevelList {
			get {
				var step = new VectorRangeLevelStep(Path);
				Path.AddSegment(step, "outE('RootContainsVectorRangeLevel').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep ContainsVectorUnitList {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('RootContainsVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep ContainsVectorUnitPrefixList {
			get {
				var step = new VectorUnitPrefixStep(Path);
				Path.AddSegment(step, "outE('RootContainsVectorUnitPrefix').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep ContainsVectorUnitDerivedList {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "outE('RootContainsVectorUnitDerived').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class AppStep : NodeStep<FabApp>, IInRootContains, IHasArtifact, IDefinesMemberList {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Artifact", true, "/HasArtifact"),
			new StepLink("Defines", "Member", true, "/DefinesMemberList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "AppId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
				case "definesmemberlist": return DefinesMemberList;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsApp').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('AppHasArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep DefinesMemberList {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "outE('AppDefinesMember').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class ArtifactStep : NodeStep<FabArtifact>, IInRootContains, IInAppHas, IUsesArtifactType, IInClassHas, IInInstanceHas, IInMemberCreates, IInUrlHas, IInUserHas, IInFactorListUsesPrimary, IInFactorListUsesRelated, IInDescriptorListRefinesPrimaryWith, IInDescriptorListRefinesRelatedWith, IInDescriptorListRefinesTypeWith, IInVectorListUsesAxis {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "App", false, "/InAppHas"),
			new StepLink("Uses", "ArtifactType", true, "/UsesArtifactType"),
			new StepLink("Has", "Class", false, "/InClassHas"),
			new StepLink("Has", "Instance", false, "/InInstanceHas"),
			new StepLink("Creates", "Member", false, "/InMemberCreates"),
			new StepLink("Has", "Url", false, "/InUrlHas"),
			new StepLink("Has", "User", false, "/InUserHas"),
			new StepLink("UsesPrimary", "Factor", false, "/InFactorListUsesPrimary"),
			new StepLink("UsesRelated", "Factor", false, "/InFactorListUsesRelated"),
			new StepLink("RefinesPrimaryWith", "Descriptor", false, "/InDescriptorListRefinesPrimaryWith"),
			new StepLink("RefinesRelatedWith", "Descriptor", false, "/InDescriptorListRefinesRelatedWith"),
			new StepLink("RefinesTypeWith", "Descriptor", false, "/InDescriptorListRefinesTypeWith"),
			new StepLink("UsesAxis", "Vector", false, "/InVectorListUsesAxis"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "ArtifactId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inapphas": return InAppHas;
				case "usesartifacttype": return UsesArtifactType;
				case "inclasshas": return InClassHas;
				case "ininstancehas": return InInstanceHas;
				case "inmembercreates": return InMemberCreates;
				case "inurlhas": return InUrlHas;
				case "inuserhas": return InUserHas;
				case "infactorlistusesprimary": return InFactorListUsesPrimary;
				case "infactorlistusesrelated": return InFactorListUsesRelated;
				case "indescriptorlistrefinesprimarywith": return InDescriptorListRefinesPrimaryWith;
				case "indescriptorlistrefinesrelatedwith": return InDescriptorListRefinesRelatedWith;
				case "indescriptorlistrefinestypewith": return InDescriptorListRefinesTypeWith;
				case "invectorlistusesaxis": return InVectorListUsesAxis;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public AppStep InAppHas {
			get {
				var step = new AppStep(Path);
				Path.AddSegment(step, "inE('AppHasArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeStep UsesArtifactType {
			get {
				var step = new ArtifactTypeStep(Path);
				Path.AddSegment(step, "outE('ArtifactUsesArtifactType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ClassStep InClassHas {
			get {
				var step = new ClassStep(Path);
				Path.AddSegment(step, "inE('ClassHasArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public InstanceStep InInstanceHas {
			get {
				var step = new InstanceStep(Path);
				Path.AddSegment(step, "inE('InstanceHasArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberCreatesArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UrlStep InUrlHas {
			get {
				var step = new UrlStep(Path);
				Path.AddSegment(step, "inE('UrlHasArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep InUserHas {
			get {
				var step = new UserStep(Path);
				Path.AddSegment(step, "inE('UserHasArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUsesPrimary {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesPrimaryArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUsesRelated {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesRelatedArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListRefinesPrimaryWith {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorRefinesPrimaryWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListRefinesRelatedWith {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorRefinesRelatedWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListRefinesTypeWith {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorRefinesTypeWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUsesAxis {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesAxisArtifact').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class ArtifactTypeStep : NodeStep<FabArtifactType>, IInRootContains, IInArtifactListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Artifact", false, "/InArtifactListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "ArtifactTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inartifactlistuses": return InArtifactListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsArtifactType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep InArtifactListUses {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "inE('ArtifactUsesArtifactType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class ClassStep : NodeStep<FabClass>, IInRootContains, IHasArtifact {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Artifact", true, "/HasArtifact"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "ClassId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsClass').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('ClassHasArtifact').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class InstanceStep : NodeStep<FabInstance>, IInRootContains, IHasArtifact {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Artifact", true, "/HasArtifact"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "InstanceId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsInstance').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('InstanceHasArtifact').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberStep : NodeStep<FabMember>, IInRootContains, IInAppDefines, IHasMemberTypeAssign, IHasHistoricMemberTypeAssignList, ICreatesArtifactList, ICreatesMemberTypeAssignList, ICreatesFactorList, IInUserDefines {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Defines", "App", false, "/InAppDefines"),
			new StepLink("Has", "MemberTypeAssign", true, "/HasMemberTypeAssign"),
			new StepLink("HasHistoric", "MemberTypeAssign", true, "/HasHistoricMemberTypeAssignList"),
			new StepLink("Creates", "Artifact", true, "/CreatesArtifactList"),
			new StepLink("Creates", "MemberTypeAssign", true, "/CreatesMemberTypeAssignList"),
			new StepLink("Creates", "Factor", true, "/CreatesFactorList"),
			new StepLink("Defines", "User", false, "/InUserDefines"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "MemberId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inappdefines": return InAppDefines;
				case "hasmembertypeassign": return HasMemberTypeAssign;
				case "hashistoricmembertypeassignlist": return HasHistoricMemberTypeAssignList;
				case "createsartifactlist": return CreatesArtifactList;
				case "createsmembertypeassignlist": return CreatesMemberTypeAssignList;
				case "createsfactorlist": return CreatesFactorList;
				case "inuserdefines": return InUserDefines;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsMember').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public AppStep InAppDefines {
			get {
				var step = new AppStep(Path);
				Path.AddSegment(step, "inE('AppDefinesMember').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep HasMemberTypeAssign {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('MemberHasMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep HasHistoricMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('MemberHasHistoricMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep CreatesArtifactList {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('MemberCreatesArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep CreatesMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('MemberCreatesMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep CreatesFactorList {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "outE('MemberCreatesFactor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public UserStep InUserDefines {
			get {
				var step = new UserStep(Path);
				Path.AddSegment(step, "inE('UserDefinesMember').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeStep : NodeStep<FabMemberType>, IInRootContains, IInMemberTypeAssignListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "MemberTypeAssign", false, "/InMemberTypeAssignListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "MemberTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inmembertypeassignlistuses": return InMemberTypeAssignListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsMemberType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep InMemberTypeAssignListUses {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "inE('MemberTypeAssignUsesMemberType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeAssignStep : NodeStep<FabMemberTypeAssign>, IInRootContains, IInMemberHas, IInMemberHasHistoric, IInMemberCreates, IUsesMemberType {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Member", false, "/InMemberHas"),
			new StepLink("HasHistoric", "Member", false, "/InMemberHasHistoric"),
			new StepLink("Creates", "Member", false, "/InMemberCreates"),
			new StepLink("Uses", "MemberType", true, "/UsesMemberType"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "MemberTypeAssignId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inmemberhas": return InMemberHas;
				case "inmemberhashistoric": return InMemberHasHistoric;
				case "inmembercreates": return InMemberCreates;
				case "usesmembertype": return UsesMemberType;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsMemberTypeAssign').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberHas {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberHasMemberTypeAssign').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberHasHistoric {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberHasHistoricMemberTypeAssign').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberCreatesMemberTypeAssign').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep UsesMemberType {
			get {
				var step = new MemberTypeStep(Path);
				Path.AddSegment(step, "outE('MemberTypeAssignUsesMemberType').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class UrlStep : NodeStep<FabUrl>, IInRootContains, IHasArtifact {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Artifact", true, "/HasArtifact"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "UrlId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsUrl').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('UrlHasArtifact').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class UserStep : NodeStep<FabUser>, IInRootContains, IHasArtifact, IDefinesMemberList {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Artifact", true, "/HasArtifact"),
			new StepLink("Defines", "Member", true, "/DefinesMemberList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "UserId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "hasartifact": return HasArtifact;
				case "definesmemberlist": return DefinesMemberList;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsUser').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep HasArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('UserHasArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep DefinesMemberList {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "outE('UserDefinesMember').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class FactorStep : NodeStep<FabFactor>, IInRootContains, IInMemberCreates, IUsesPrimaryArtifact, IUsesRelatedArtifact, IUsesFactorAssertion, IReplacesFactor, IUsesDescriptor, IUsesDirector, IUsesEventor, IUsesIdentor, IUsesLocator, IUsesVector {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Creates", "Member", false, "/InMemberCreates"),
			new StepLink("UsesPrimary", "Artifact", true, "/UsesPrimaryArtifact"),
			new StepLink("UsesRelated", "Artifact", true, "/UsesRelatedArtifact"),
			new StepLink("Uses", "FactorAssertion", true, "/UsesFactorAssertion"),
			new StepLink("Replaces", "Factor", true, "/ReplacesFactor"),
			new StepLink("Uses", "Descriptor", true, "/UsesDescriptor"),
			new StepLink("Uses", "Director", true, "/UsesDirector"),
			new StepLink("Uses", "Eventor", true, "/UsesEventor"),
			new StepLink("Uses", "Identor", true, "/UsesIdentor"),
			new StepLink("Uses", "Locator", true, "/UsesLocator"),
			new StepLink("Uses", "Vector", true, "/UsesVector"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "FactorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
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

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsFactor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberCreatesFactor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep UsesPrimaryArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorUsesPrimaryArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep UsesRelatedArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorUsesRelatedArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep UsesFactorAssertion {
			get {
				var step = new FactorAssertionStep(Path);
				Path.AddSegment(step, "outE('FactorUsesFactorAssertion').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep ReplacesFactor {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "outE('FactorReplacesFactor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep UsesDescriptor {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesDescriptor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep UsesDirector {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesDirector').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep UsesEventor {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesEventor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep UsesIdentor {
			get {
				var step = new IdentorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesIdentor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep UsesLocator {
			get {
				var step = new LocatorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesLocator').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep UsesVector {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesVector').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class FactorAssertionStep : NodeStep<FabFactorAssertion>, IInRootContains, IInFactorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "FactorAssertionId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsFactorAssertion').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesFactorAssertion').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DescriptorStep : NodeStep<FabDescriptor>, IInRootContains, IInFactorListUses, IUsesDescriptorType, IRefinesPrimaryWithArtifact, IRefinesRelatedWithArtifact, IRefinesTypeWithArtifact {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "DescriptorType", true, "/UsesDescriptorType"),
			new StepLink("RefinesPrimaryWith", "Artifact", true, "/RefinesPrimaryWithArtifact"),
			new StepLink("RefinesRelatedWith", "Artifact", true, "/RefinesRelatedWithArtifact"),
			new StepLink("RefinesTypeWith", "Artifact", true, "/RefinesTypeWithArtifact"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DescriptorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesdescriptortype": return UsesDescriptorType;
				case "refinesprimarywithartifact": return RefinesPrimaryWithArtifact;
				case "refinesrelatedwithartifact": return RefinesRelatedWithArtifact;
				case "refinestypewithartifact": return RefinesTypeWithArtifact;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsDescriptor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesDescriptor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep UsesDescriptorType {
			get {
				var step = new DescriptorTypeStep(Path);
				Path.AddSegment(step, "outE('DescriptorUsesDescriptorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep RefinesPrimaryWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('DescriptorRefinesPrimaryWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep RefinesRelatedWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('DescriptorRefinesRelatedWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep RefinesTypeWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('DescriptorRefinesTypeWithArtifact').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DescriptorTypeStep : NodeStep<FabDescriptorType>, IInRootContains, IInDescriptorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Descriptor", false, "/InDescriptorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DescriptorTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "indescriptorlistuses": return InDescriptorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsDescriptorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep InDescriptorListUses {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorUsesDescriptorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorStep : NodeStep<FabDirector>, IInRootContains, IInFactorListUses, IUsesDirectorType, IUsesPrimaryDirectorAction, IUsesRelatedDirectorAction {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "DirectorType", true, "/UsesDirectorType"),
			new StepLink("UsesPrimary", "DirectorAction", true, "/UsesPrimaryDirectorAction"),
			new StepLink("UsesRelated", "DirectorAction", true, "/UsesRelatedDirectorAction"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DirectorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesdirectortype": return UsesDirectorType;
				case "usesprimarydirectoraction": return UsesPrimaryDirectorAction;
				case "usesrelateddirectoraction": return UsesRelatedDirectorAction;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsDirector').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesDirector').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep UsesDirectorType {
			get {
				var step = new DirectorTypeStep(Path);
				Path.AddSegment(step, "outE('DirectorUsesDirectorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep UsesPrimaryDirectorAction {
			get {
				var step = new DirectorActionStep(Path);
				Path.AddSegment(step, "outE('DirectorUsesPrimaryDirectorAction').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep UsesRelatedDirectorAction {
			get {
				var step = new DirectorActionStep(Path);
				Path.AddSegment(step, "outE('DirectorUsesRelatedDirectorAction').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorTypeStep : NodeStep<FabDirectorType>, IInRootContains, IInDirectorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Director", false, "/InDirectorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DirectorTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "indirectorlistuses": return InDirectorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsDirectorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep InDirectorListUses {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "inE('DirectorUsesDirectorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorActionStep : NodeStep<FabDirectorAction>, IInRootContains, IInDirectorListUsesPrimary, IInDirectorListUsesRelated {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("UsesPrimary", "Director", false, "/InDirectorListUsesPrimary"),
			new StepLink("UsesRelated", "Director", false, "/InDirectorListUsesRelated"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "DirectorActionId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "indirectorlistusesprimary": return InDirectorListUsesPrimary;
				case "indirectorlistusesrelated": return InDirectorListUsesRelated;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsDirectorAction').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep InDirectorListUsesPrimary {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "inE('DirectorUsesPrimaryDirectorAction').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep InDirectorListUsesRelated {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "inE('DirectorUsesRelatedDirectorAction').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorStep : NodeStep<FabEventor>, IInRootContains, IInFactorListUses, IUsesEventorType, IUsesEventorPrecision {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "EventorType", true, "/UsesEventorType"),
			new StepLink("Uses", "EventorPrecision", true, "/UsesEventorPrecision"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "EventorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "useseventortype": return UsesEventorType;
				case "useseventorprecision": return UsesEventorPrecision;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsEventor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesEventor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep UsesEventorType {
			get {
				var step = new EventorTypeStep(Path);
				Path.AddSegment(step, "outE('EventorUsesEventorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep UsesEventorPrecision {
			get {
				var step = new EventorPrecisionStep(Path);
				Path.AddSegment(step, "outE('EventorUsesEventorPrecision').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorTypeStep : NodeStep<FabEventorType>, IInRootContains, IInEventorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Eventor", false, "/InEventorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "EventorTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "ineventorlistuses": return InEventorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsEventorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep InEventorListUses {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "inE('EventorUsesEventorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorPrecisionStep : NodeStep<FabEventorPrecision>, IInRootContains, IInEventorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Eventor", false, "/InEventorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "EventorPrecisionId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "ineventorlistuses": return InEventorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsEventorPrecision').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public EventorStep InEventorListUses {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "inE('EventorUsesEventorPrecision').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class IdentorStep : NodeStep<FabIdentor>, IInRootContains, IInFactorListUses, IUsesIdentorType {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "IdentorType", true, "/UsesIdentorType"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "IdentorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesidentortype": return UsesIdentorType;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsIdentor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesIdentor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep UsesIdentorType {
			get {
				var step = new IdentorTypeStep(Path);
				Path.AddSegment(step, "outE('IdentorUsesIdentorType').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class IdentorTypeStep : NodeStep<FabIdentorType>, IInRootContains, IInIdentorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Identor", false, "/InIdentorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "IdentorTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inidentorlistuses": return InIdentorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsIdentorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep InIdentorListUses {
			get {
				var step = new IdentorStep(Path);
				Path.AddSegment(step, "inE('IdentorUsesIdentorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class LocatorStep : NodeStep<FabLocator>, IInRootContains, IInFactorListUses, IUsesLocatorType {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "LocatorType", true, "/UsesLocatorType"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "LocatorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "useslocatortype": return UsesLocatorType;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsLocator').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesLocator').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep UsesLocatorType {
			get {
				var step = new LocatorTypeStep(Path);
				Path.AddSegment(step, "outE('LocatorUsesLocatorType').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class LocatorTypeStep : NodeStep<FabLocatorType>, IInRootContains, IInLocatorListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Locator", false, "/InLocatorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "LocatorTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inlocatorlistuses": return InLocatorListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsLocatorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep InLocatorListUses {
			get {
				var step = new LocatorStep(Path);
				Path.AddSegment(step, "inE('LocatorUsesLocatorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorStep : NodeStep<FabVector>, IInRootContains, IInFactorListUses, IUsesAxisArtifact, IUsesVectorType, IUsesVectorUnit, IUsesVectorUnitPrefix {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("UsesAxis", "Artifact", true, "/UsesAxisArtifact"),
			new StepLink("Uses", "VectorType", true, "/UsesVectorType"),
			new StepLink("Uses", "VectorUnit", true, "/UsesVectorUnit"),
			new StepLink("Uses", "VectorUnitPrefix", true, "/UsesVectorUnitPrefix"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "infactorlistuses": return InFactorListUses;
				case "usesaxisartifact": return UsesAxisArtifact;
				case "usesvectortype": return UsesVectorType;
				case "usesvectorunit": return UsesVectorUnit;
				case "usesvectorunitprefix": return UsesVectorUnitPrefix;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVector').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesVector').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep UsesAxisArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('VectorUsesAxisArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep UsesVectorType {
			get {
				var step = new VectorTypeStep(Path);
				Path.AddSegment(step, "outE('VectorUsesVectorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep UsesVectorUnit {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('VectorUsesVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep UsesVectorUnitPrefix {
			get {
				var step = new VectorUnitPrefixStep(Path);
				Path.AddSegment(step, "outE('VectorUsesVectorUnitPrefix').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorTypeStep : NodeStep<FabVectorType>, IInRootContains, IInVectorListUses, IUsesVectorRange {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Vector", false, "/InVectorListUses"),
			new StepLink("Uses", "VectorRange", true, "/UsesVectorRange"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorTypeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "invectorlistuses": return InVectorListUses;
				case "usesvectorrange": return UsesVectorRange;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVectorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUses {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesVectorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep UsesVectorRange {
			get {
				var step = new VectorRangeStep(Path);
				Path.AddSegment(step, "outE('VectorTypeUsesVectorRange').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeStep : NodeStep<FabVectorRange>, IInRootContains, IInVectorTypeListUses, IUsesVectorRangeLevelList {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "VectorType", false, "/InVectorTypeListUses"),
			new StepLink("Uses", "VectorRangeLevel", true, "/UsesVectorRangeLevelList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorRangeId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "invectortypelistuses": return InVectorTypeListUses;
				case "usesvectorrangelevellist": return UsesVectorRangeLevelList;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVectorRange').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep InVectorTypeListUses {
			get {
				var step = new VectorTypeStep(Path);
				Path.AddSegment(step, "inE('VectorTypeUsesVectorRange').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep UsesVectorRangeLevelList {
			get {
				var step = new VectorRangeLevelStep(Path);
				Path.AddSegment(step, "outE('VectorRangeUsesVectorRangeLevel').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeLevelStep : NodeStep<FabVectorRangeLevel>, IInRootContains, IInVectorRangeListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "VectorRange", false, "/InVectorRangeListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorRangeLevelId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "invectorrangelistuses": return InVectorRangeListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVectorRangeLevel').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep InVectorRangeListUses {
			get {
				var step = new VectorRangeStep(Path);
				Path.AddSegment(step, "inE('VectorRangeUsesVectorRangeLevel').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitStep : NodeStep<FabVectorUnit>, IInRootContains, IInVectorListUses, IInVectorUnitDerivedListDefines, IInVectorUnitDerivedListRaisesToExp {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Vector", false, "/InVectorListUses"),
			new StepLink("Defines", "VectorUnitDerived", false, "/InVectorUnitDerivedListDefines"),
			new StepLink("RaisesToExp", "VectorUnitDerived", false, "/InVectorUnitDerivedListRaisesToExp"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorUnitId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "invectorlistuses": return InVectorListUses;
				case "invectorunitderivedlistdefines": return InVectorUnitDerivedListDefines;
				case "invectorunitderivedlistraisestoexp": return InVectorUnitDerivedListRaisesToExp;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVectorUnit').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUses {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesVectorUnit').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep InVectorUnitDerivedListDefines {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "inE('VectorUnitDerivedDefinesVectorUnit').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep InVectorUnitDerivedListRaisesToExp {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "inE('VectorUnitDerivedRaisesToExpVectorUnit').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitPrefixStep : NodeStep<FabVectorUnitPrefix>, IInRootContains, IInVectorListUses, IInVectorUnitDerivedListUses {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Vector", false, "/InVectorListUses"),
			new StepLink("Uses", "VectorUnitDerived", false, "/InVectorUnitDerivedListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorUnitPrefixId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "invectorlistuses": return InVectorListUses;
				case "invectorunitderivedlistuses": return InVectorUnitDerivedListUses;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVectorUnitPrefix').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorStep InVectorListUses {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesVectorUnitPrefix').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep InVectorUnitDerivedListUses {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "inE('VectorUnitDerivedUsesVectorUnitPrefix').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitDerivedStep : NodeStep<FabVectorUnitDerived>, IInRootContains, IDefinesVectorUnit, IRaisesToExpVectorUnit, IUsesVectorUnitPrefix {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Defines", "VectorUnit", true, "/DefinesVectorUnit"),
			new StepLink("RaisesToExp", "VectorUnit", true, "/RaisesToExpVectorUnit"),
			new StepLink("Uses", "VectorUnitPrefix", true, "/UsesVectorUnitPrefix"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep(Path pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "VectorUnitDerivedId"; } }
		public override bool TypeIdIsLong { get { return true; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "definesvectorunit": return DefinesVectorUnit;
				case "raisestoexpvectorunit": return RaisesToExpVectorUnit;
				case "usesvectorunitprefix": return UsesVectorUnitPrefix;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep InRootContains {
			get {
				var step = new RootStep(Path);
				Path.AddSegment(step, "inE('RootContainsVectorUnitDerived').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep DefinesVectorUnit {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('VectorUnitDerivedDefinesVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep RaisesToExpVectorUnit {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('VectorUnitDerivedRaisesToExpVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep UsesVectorUnitPrefix {
			get {
				var step = new VectorUnitPrefixStep(Path);
				Path.AddSegment(step, "outE('VectorUnitDerivedUsesVectorUnitPrefix').inV");
				return step;
			}
		}

	}

}