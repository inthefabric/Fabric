// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/6/2013 10:15:23 AM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Weaver;

namespace Fabric.Api.Traversal.Steps.Nodes {
	
	/*================================================================================================*/
	public class RootStep : NodeStep<FabRoot>, IFinalStep {
	
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
		
		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


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
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.App));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IClassStep ContainsClassList {
			get {
				var step = new ClassStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Class));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IInstanceStep ContainsInstanceList {
			get {
				var step = new InstanceStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Instance));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep ContainsMemberList {
			get {
				var step = new MemberStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Member));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeStep ContainsMemberTypeList {
			get {
				var step = new MemberTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.MemberType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeAssignStep ContainsMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.MemberTypeAssign));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUrlStep ContainsUrlList {
			get {
				var step = new UrlStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Url));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUserStep ContainsUserList {
			get {
				var step = new UserStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.User));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep ContainsFactorList {
			get {
				var step = new FactorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Factor));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorAssertionStep ContainsFactorAssertionList {
			get {
				var step = new FactorAssertionStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.FactorAssertion));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorStep ContainsDescriptorList {
			get {
				var step = new DescriptorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Descriptor));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorTypeStep ContainsDescriptorTypeList {
			get {
				var step = new DescriptorTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.DescriptorType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorStep ContainsDirectorList {
			get {
				var step = new DirectorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Director));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorTypeStep ContainsDirectorTypeList {
			get {
				var step = new DirectorTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.DirectorType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorActionStep ContainsDirectorActionList {
			get {
				var step = new DirectorActionStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.DirectorAction));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorStep ContainsEventorList {
			get {
				var step = new EventorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Eventor));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorTypeStep ContainsEventorTypeList {
			get {
				var step = new EventorTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.EventorType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorPrecisionStep ContainsEventorPrecisionList {
			get {
				var step = new EventorPrecisionStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.EventorPrecision));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IIdentorStep ContainsIdentorList {
			get {
				var step = new IdentorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Identor));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IIdentorTypeStep ContainsIdentorTypeList {
			get {
				var step = new IdentorTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.IdentorType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ILocatorStep ContainsLocatorList {
			get {
				var step = new LocatorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Locator));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ILocatorTypeStep ContainsLocatorTypeList {
			get {
				var step = new LocatorTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.LocatorType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorStep ContainsVectorList {
			get {
				var step = new VectorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Vector));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorTypeStep ContainsVectorTypeList {
			get {
				var step = new VectorTypeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.VectorType));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorRangeStep ContainsVectorRangeList {
			get {
				var step = new VectorRangeStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.VectorRange));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorRangeLevelStep ContainsVectorRangeLevelList {
			get {
				var step = new VectorRangeLevelStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.VectorRangeLevel));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitStep ContainsVectorUnitList {
			get {
				var step = new VectorUnitStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.VectorUnit));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitPrefixStep ContainsVectorUnitPrefixList {
			get {
				var step = new VectorUnitPrefixStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.VectorUnitPrefix));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitDerivedStep ContainsVectorUnitDerivedList {
			get {
				var step = new VectorUnitDerivedStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.VectorUnitDerived));
				Path.AddSegment(step, "V('FabType',"+p+")");
				return step;
			}
		}

	}

}