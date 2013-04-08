// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 2:54:25 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Nodes {
	
	/*================================================================================================*/
	public partial class AppStep : ArtifactStep<FabApp>, IAppStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Defines", "Member", true, "/DefinesMemberList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppStep(IPath pPath) : base(pPath) {
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
				case "definesmemberlist": return DefinesMemberList;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep DefinesMemberList {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "outE('AppDefinesMember').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class ClassStep : ArtifactStep<FabClass>, IClassStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassStep(IPath pPath) : base(pPath) {
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
		


		////////////////////////////////////////////////////////////////////////////////////////////////
	}

	/*================================================================================================*/
	public partial class InstanceStep : ArtifactStep<FabInstance>, IInstanceStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceStep(IPath pPath) : base(pPath) {
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
		


		////////////////////////////////////////////////////////////////////////////////////////////////
	}

	/*================================================================================================*/
	public partial class MemberStep : NodeStep<FabMember>, IMemberStep {
		
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
		public MemberStep(IPath pPath) : base(pPath) {
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
		public IAppStep InAppDefines {
			get {
				var step = new AppStep(Path);
				Path.AddSegment(step, "inE('AppDefinesMember').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeAssignStep HasMemberTypeAssign {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('MemberHasMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeAssignStep HasHistoricMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('MemberHasHistoricMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep CreatesArtifactList {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('MemberCreatesArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeAssignStep CreatesMemberTypeAssignList {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "outE('MemberCreatesMemberTypeAssign').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep CreatesFactorList {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "outE('MemberCreatesFactor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IUserStep InUserDefines {
			get {
				var step = new UserStep(Path);
				Path.AddSegment(step, "inE('UserDefinesMember').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeAssignStep : NodeForActionStep<FabMemberTypeAssign>, IMemberTypeAssignStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Has", "Member", false, "/InMemberHas"),
			new StepLink("HasHistoric", "Member", false, "/InMemberHasHistoric"),
			new StepLink("Creates", "Member", false, "/InMemberCreates"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignStep(IPath pPath) : base(pPath) {
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
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep InMemberHas {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberHasMemberTypeAssign').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep InMemberHasHistoric {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberHasHistoricMemberTypeAssign').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberCreatesMemberTypeAssign').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class UrlStep : ArtifactStep<FabUrl>, IUrlStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlStep(IPath pPath) : base(pPath) {
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
		


		////////////////////////////////////////////////////////////////////////////////////////////////
	}

	/*================================================================================================*/
	public partial class UserStep : ArtifactStep<FabUser>, IUserStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Defines", "Member", true, "/DefinesMemberList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserStep(IPath pPath) : base(pPath) {
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
				case "definesmemberlist": return DefinesMemberList;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep DefinesMemberList {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "outE('UserDefinesMember').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class FactorStep : NodeStep<FabFactor>, IFactorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Creates", "Member", false, "/InMemberCreates"),
			new StepLink("UsesPrimary", "Artifact", true, "/UsesPrimaryArtifact"),
			new StepLink("UsesRelated", "Artifact", true, "/UsesRelatedArtifact"),
			new StepLink("Replaces", "Factor", true, "/ReplacesFactor"),
			new StepLink("RefinesPrimaryWith", "Artifact", true, "/RefinesPrimaryWithArtifact"),
			new StepLink("RefinesRelatedWith", "Artifact", true, "/RefinesRelatedWithArtifact"),
			new StepLink("RefinesTypeWith", "Artifact", true, "/RefinesTypeWithArtifact"),
			new StepLink("UsesAxis", "Artifact", true, "/UsesAxisArtifact"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorStep(IPath pPath) : base(pPath) {
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
				case "replacesfactor": return ReplacesFactor;
				case "refinesprimarywithartifact": return RefinesPrimaryWithArtifact;
				case "refinesrelatedwithartifact": return RefinesRelatedWithArtifact;
				case "refinestypewithartifact": return RefinesTypeWithArtifact;
				case "usesaxisartifact": return UsesAxisArtifact;
			}

			return base.GetLink(pData);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberCreatesFactor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep UsesPrimaryArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorUsesPrimaryArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep UsesRelatedArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorUsesRelatedArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep ReplacesFactor {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "outE('FactorReplacesFactor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep RefinesPrimaryWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorRefinesPrimaryWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep RefinesRelatedWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorRefinesRelatedWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep RefinesTypeWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorRefinesTypeWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep UsesAxisArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('FactorUsesAxisArtifact').inV");
				return step;
			}
		}

	}

}