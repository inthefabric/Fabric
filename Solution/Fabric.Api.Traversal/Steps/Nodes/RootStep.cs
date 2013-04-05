// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/4/2013 11:30:00 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Nodes {
	
	/*================================================================================================*/
	public class RootStep : NodeStep<FabRoot> {
	
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Contains", "App", true, "/ContainsAppList"),
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
		public RootStep(IPath pPath) : base(pPath) {
			pPath.AddSegment(this, "g");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return null; } }
		public override bool TypeIdIsLong { get { return false; } }
		
		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "containsapplist": return ContainsAppList;
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
		public IAppStep ContainsAppList {
			get {
				var step = new AppStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.App+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IClassStep ContainsClassList {
			get {
				var step = new ClassStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Class+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IInstanceStep ContainsInstanceList {
			get {
				var step = new InstanceStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Instance+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep ContainsMemberList {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Member+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeStep ContainsMemberTypeList {
			get {
				var step = new MemberTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.MemberType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeAssignStep ContainsMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.MemberTypeAssign+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUrlStep ContainsUrlList {
			get {
				var step = new UrlStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Url+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUserStep ContainsUserList {
			get {
				var step = new UserStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.User+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep ContainsFactorList {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Factor+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorAssertionStep ContainsFactorAssertionList {
			get {
				var step = new FactorAssertionStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.FactorAssertion+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorStep ContainsDescriptorList {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Descriptor+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorTypeStep ContainsDescriptorTypeList {
			get {
				var step = new DescriptorTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.DescriptorType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorStep ContainsDirectorList {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Director+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorTypeStep ContainsDirectorTypeList {
			get {
				var step = new DirectorTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.DirectorType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorActionStep ContainsDirectorActionList {
			get {
				var step = new DirectorActionStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.DirectorAction+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorStep ContainsEventorList {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Eventor+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorTypeStep ContainsEventorTypeList {
			get {
				var step = new EventorTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.EventorType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorPrecisionStep ContainsEventorPrecisionList {
			get {
				var step = new EventorPrecisionStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.EventorPrecision+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IIdentorStep ContainsIdentorList {
			get {
				var step = new IdentorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Identor+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IIdentorTypeStep ContainsIdentorTypeList {
			get {
				var step = new IdentorTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.IdentorType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ILocatorStep ContainsLocatorList {
			get {
				var step = new LocatorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Locator+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ILocatorTypeStep ContainsLocatorTypeList {
			get {
				var step = new LocatorTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.LocatorType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorStep ContainsVectorList {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.Vector+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorTypeStep ContainsVectorTypeList {
			get {
				var step = new VectorTypeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.VectorType+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorRangeStep ContainsVectorRangeList {
			get {
				var step = new VectorRangeStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.VectorRange+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorRangeLevelStep ContainsVectorRangeLevelList {
			get {
				var step = new VectorRangeLevelStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.VectorRangeLevel+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitStep ContainsVectorUnitList {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.VectorUnit+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitPrefixStep ContainsVectorUnitPrefixList {
			get {
				var step = new VectorUnitPrefixStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.VectorUnitPrefix+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitDerivedStep ContainsVectorUnitDerivedList {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "V('FabType',"+(int)NodeFabType.VectorUnitDerived+")");
				return step;
			}
		}

	}

}