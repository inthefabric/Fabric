// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:16 PM

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
			new StepLink("Contains", "MemberTypeAssign", true, "/ContainsMemberTypeAssignList"),
			new StepLink("Contains", "Url", true, "/ContainsUrlList"),
			new StepLink("Contains", "User", true, "/ContainsUserList"),
			new StepLink("Contains", "Factor", true, "/ContainsFactorList"),
			new StepLink("Contains", "Descriptor", true, "/ContainsDescriptorList"),
			new StepLink("Contains", "Director", true, "/ContainsDirectorList"),
			new StepLink("Contains", "Eventor", true, "/ContainsEventorList"),
			new StepLink("Contains", "Identor", true, "/ContainsIdentorList"),
			new StepLink("Contains", "Locator", true, "/ContainsLocatorList"),
			new StepLink("Contains", "Vector", true, "/ContainsVectorList"),
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
				case "containsmembertypeassignlist": return ContainsMemberTypeAssignList;
				case "containsurllist": return ContainsUrlList;
				case "containsuserlist": return ContainsUserList;
				case "containsfactorlist": return ContainsFactorList;
				case "containsdescriptorlist": return ContainsDescriptorList;
				case "containsdirectorlist": return ContainsDirectorList;
				case "containseventorlist": return ContainsEventorList;
				case "containsidentorlist": return ContainsIdentorList;
				case "containslocatorlist": return ContainsLocatorList;
				case "containsvectorlist": return ContainsVectorList;
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
		public IDescriptorStep ContainsDescriptorList {
			get {
				var step = new DescriptorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Descriptor));
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
		public IEventorStep ContainsEventorList {
			get {
				var step = new EventorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Eventor));
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
		public ILocatorStep ContainsLocatorList {
			get {
				var step = new LocatorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((int)NodeFabType.Locator));
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

	}

}