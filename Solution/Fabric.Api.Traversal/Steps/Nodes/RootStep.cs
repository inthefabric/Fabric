// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/16/2013 10:09:03 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;
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
			}

			return base.GetLink(pData);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IAppStep ContainsAppList {
			get {
				var step = new AppStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.App));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IClassStep ContainsClassList {
			get {
				var step = new ClassStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.Class));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IInstanceStep ContainsInstanceList {
			get {
				var step = new InstanceStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.Instance));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep ContainsMemberList {
			get {
				var step = new MemberStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.Member));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeAssignStep ContainsMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.MemberTypeAssign));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUrlStep ContainsUrlList {
			get {
				var step = new UrlStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.Url));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUserStep ContainsUserList {
			get {
				var step = new UserStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.User));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep ContainsFactorList {
			get {
				var step = new FactorStep(Path);
				string p = Path.AddParam(new WeaverQueryVal((byte)NodeFabType.Factor));
				Path.AddSegment(step, "V('"+PropDbName.Node_FabType+"',"+p+")");
				return step;
			}
		}

	}

}