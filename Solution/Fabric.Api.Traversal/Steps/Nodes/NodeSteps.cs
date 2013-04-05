﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/5/2013 1:09:17 PM

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
	public partial class MemberTypeStep : NodeForTypeStep<FabMemberType>, IMemberTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "MemberTypeAssign", false, "/InMemberTypeAssignListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeStep(IPath pPath) : base(pPath) {
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
		public IMemberTypeAssignStep InMemberTypeAssignListUses {
			get {
				var step = new MemberTypeAssignStep(Path);
				Path.AddSegment(step, "inE('MemberTypeAssignUsesMemberType').outV");
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
			new StepLink("Uses", "MemberType", true, "/UsesMemberType"),
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
				case "usesmembertype": return UsesMemberType;
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

		/*--------------------------------------------------------------------------------------------*/
		public IMemberTypeStep UsesMemberType {
			get {
				var step = new MemberTypeStep(Path);
				Path.AddSegment(step, "outE('MemberTypeAssignUsesMemberType').inV");
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
		public IFactorAssertionStep UsesFactorAssertion {
			get {
				var step = new FactorAssertionStep(Path);
				Path.AddSegment(step, "outE('FactorUsesFactorAssertion').inV");
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
		public IDescriptorStep UsesDescriptor {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesDescriptor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorStep UsesDirector {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesDirector').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorStep UsesEventor {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesEventor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IIdentorStep UsesIdentor {
			get {
				var step = new IdentorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesIdentor').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ILocatorStep UsesLocator {
			get {
				var step = new LocatorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesLocator').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorStep UsesVector {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "outE('FactorUsesVector').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class FactorAssertionStep : NodeForTypeStep<FabFactorAssertion>, IFactorAssertionStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesFactorAssertion').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DescriptorStep : FactorElementNodeStep<FabDescriptor>, IDescriptorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "DescriptorType", true, "/UsesDescriptorType"),
			new StepLink("RefinesPrimaryWith", "Artifact", true, "/RefinesPrimaryWithArtifact"),
			new StepLink("RefinesRelatedWith", "Artifact", true, "/RefinesRelatedWithArtifact"),
			new StepLink("RefinesTypeWith", "Artifact", true, "/RefinesTypeWithArtifact"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesDescriptor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorTypeStep UsesDescriptorType {
			get {
				var step = new DescriptorTypeStep(Path);
				Path.AddSegment(step, "outE('DescriptorUsesDescriptorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep RefinesPrimaryWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('DescriptorRefinesPrimaryWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep RefinesRelatedWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('DescriptorRefinesRelatedWithArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep RefinesTypeWithArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('DescriptorRefinesTypeWithArtifact').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DescriptorTypeStep : NodeForTypeStep<FabDescriptorType>, IDescriptorTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Descriptor", false, "/InDescriptorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeStep(IPath pPath) : base(pPath) {
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
		public IDescriptorStep InDescriptorListUses {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorUsesDescriptorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorStep : FactorElementNodeStep<FabDirector>, IDirectorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "DirectorType", true, "/UsesDirectorType"),
			new StepLink("UsesPrimary", "DirectorAction", true, "/UsesPrimaryDirectorAction"),
			new StepLink("UsesRelated", "DirectorAction", true, "/UsesRelatedDirectorAction"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesDirector').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorTypeStep UsesDirectorType {
			get {
				var step = new DirectorTypeStep(Path);
				Path.AddSegment(step, "outE('DirectorUsesDirectorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorActionStep UsesPrimaryDirectorAction {
			get {
				var step = new DirectorActionStep(Path);
				Path.AddSegment(step, "outE('DirectorUsesPrimaryDirectorAction').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorActionStep UsesRelatedDirectorAction {
			get {
				var step = new DirectorActionStep(Path);
				Path.AddSegment(step, "outE('DirectorUsesRelatedDirectorAction').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorTypeStep : NodeForTypeStep<FabDirectorType>, IDirectorTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Director", false, "/InDirectorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeStep(IPath pPath) : base(pPath) {
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
		public IDirectorStep InDirectorListUses {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "inE('DirectorUsesDirectorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class DirectorActionStep : NodeForTypeStep<FabDirectorAction>, IDirectorActionStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("UsesPrimary", "Director", false, "/InDirectorListUsesPrimary"),
			new StepLink("UsesRelated", "Director", false, "/InDirectorListUsesRelated"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionStep(IPath pPath) : base(pPath) {
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
		public IDirectorStep InDirectorListUsesPrimary {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "inE('DirectorUsesPrimaryDirectorAction').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDirectorStep InDirectorListUsesRelated {
			get {
				var step = new DirectorStep(Path);
				Path.AddSegment(step, "inE('DirectorUsesRelatedDirectorAction').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorStep : FactorElementNodeStep<FabEventor>, IEventorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "EventorType", true, "/UsesEventorType"),
			new StepLink("Uses", "EventorPrecision", true, "/UsesEventorPrecision"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesEventor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorTypeStep UsesEventorType {
			get {
				var step = new EventorTypeStep(Path);
				Path.AddSegment(step, "outE('EventorUsesEventorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IEventorPrecisionStep UsesEventorPrecision {
			get {
				var step = new EventorPrecisionStep(Path);
				Path.AddSegment(step, "outE('EventorUsesEventorPrecision').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorTypeStep : NodeForTypeStep<FabEventorType>, IEventorTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Eventor", false, "/InEventorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeStep(IPath pPath) : base(pPath) {
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
		public IEventorStep InEventorListUses {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "inE('EventorUsesEventorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class EventorPrecisionStep : NodeForTypeStep<FabEventorPrecision>, IEventorPrecisionStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Eventor", false, "/InEventorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionStep(IPath pPath) : base(pPath) {
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
		public IEventorStep InEventorListUses {
			get {
				var step = new EventorStep(Path);
				Path.AddSegment(step, "inE('EventorUsesEventorPrecision').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class IdentorStep : FactorElementNodeStep<FabIdentor>, IIdentorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "IdentorType", true, "/UsesIdentorType"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesIdentor').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IIdentorTypeStep UsesIdentorType {
			get {
				var step = new IdentorTypeStep(Path);
				Path.AddSegment(step, "outE('IdentorUsesIdentorType').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class IdentorTypeStep : NodeForTypeStep<FabIdentorType>, IIdentorTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Identor", false, "/InIdentorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeStep(IPath pPath) : base(pPath) {
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
		public IIdentorStep InIdentorListUses {
			get {
				var step = new IdentorStep(Path);
				Path.AddSegment(step, "inE('IdentorUsesIdentorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class LocatorStep : FactorElementNodeStep<FabLocator>, ILocatorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("Uses", "LocatorType", true, "/UsesLocatorType"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesLocator').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public ILocatorTypeStep UsesLocatorType {
			get {
				var step = new LocatorTypeStep(Path);
				Path.AddSegment(step, "outE('LocatorUsesLocatorType').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class LocatorTypeStep : NodeForTypeStep<FabLocatorType>, ILocatorTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Locator", false, "/InLocatorListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeStep(IPath pPath) : base(pPath) {
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
		public ILocatorStep InLocatorListUses {
			get {
				var step = new LocatorStep(Path);
				Path.AddSegment(step, "inE('LocatorUsesLocatorType').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorStep : FactorElementNodeStep<FabVector>, IVectorStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Factor", false, "/InFactorListUses"),
			new StepLink("UsesAxis", "Artifact", true, "/UsesAxisArtifact"),
			new StepLink("Uses", "VectorType", true, "/UsesVectorType"),
			new StepLink("Uses", "VectorUnit", true, "/UsesVectorUnit"),
			new StepLink("Uses", "VectorUnitPrefix", true, "/UsesVectorUnitPrefix"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorStep(IPath pPath) : base(pPath) {
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
		public IFactorStep InFactorListUses {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesVector').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IArtifactStep UsesAxisArtifact {
			get {
				var step = new ArtifactStep(Path);
				Path.AddSegment(step, "outE('VectorUsesAxisArtifact').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorTypeStep UsesVectorType {
			get {
				var step = new VectorTypeStep(Path);
				Path.AddSegment(step, "outE('VectorUsesVectorType').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitStep UsesVectorUnit {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('VectorUsesVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitPrefixStep UsesVectorUnitPrefix {
			get {
				var step = new VectorUnitPrefixStep(Path);
				Path.AddSegment(step, "outE('VectorUsesVectorUnitPrefix').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorTypeStep : NodeForTypeStep<FabVectorType>, IVectorTypeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Vector", false, "/InVectorListUses"),
			new StepLink("Uses", "VectorRange", true, "/UsesVectorRange"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeStep(IPath pPath) : base(pPath) {
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
		public IVectorStep InVectorListUses {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesVectorType').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorRangeStep UsesVectorRange {
			get {
				var step = new VectorRangeStep(Path);
				Path.AddSegment(step, "outE('VectorTypeUsesVectorRange').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeStep : NodeForTypeStep<FabVectorRange>, IVectorRangeStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "VectorType", false, "/InVectorTypeListUses"),
			new StepLink("Uses", "VectorRangeLevel", true, "/UsesVectorRangeLevelList"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeStep(IPath pPath) : base(pPath) {
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
		public IVectorTypeStep InVectorTypeListUses {
			get {
				var step = new VectorTypeStep(Path);
				Path.AddSegment(step, "inE('VectorTypeUsesVectorRange').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorRangeLevelStep UsesVectorRangeLevelList {
			get {
				var step = new VectorRangeLevelStep(Path);
				Path.AddSegment(step, "outE('VectorRangeUsesVectorRangeLevel').inV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeLevelStep : NodeForTypeStep<FabVectorRangeLevel>, IVectorRangeLevelStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "VectorRange", false, "/InVectorRangeListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelStep(IPath pPath) : base(pPath) {
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
		public IVectorRangeStep InVectorRangeListUses {
			get {
				var step = new VectorRangeStep(Path);
				Path.AddSegment(step, "inE('VectorRangeUsesVectorRangeLevel').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitStep : NodeForTypeStep<FabVectorUnit>, IVectorUnitStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Vector", false, "/InVectorListUses"),
			new StepLink("Defines", "VectorUnitDerived", false, "/InVectorUnitDerivedListDefines"),
			new StepLink("RaisesToExp", "VectorUnitDerived", false, "/InVectorUnitDerivedListRaisesToExp"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitStep(IPath pPath) : base(pPath) {
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
		public IVectorStep InVectorListUses {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesVectorUnit').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitDerivedStep InVectorUnitDerivedListDefines {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "inE('VectorUnitDerivedDefinesVectorUnit').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitDerivedStep InVectorUnitDerivedListRaisesToExp {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "inE('VectorUnitDerivedRaisesToExpVectorUnit').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitPrefixStep : NodeForTypeStep<FabVectorUnitPrefix>, IVectorUnitPrefixStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Uses", "Vector", false, "/InVectorListUses"),
			new StepLink("Uses", "VectorUnitDerived", false, "/InVectorUnitDerivedListUses"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixStep(IPath pPath) : base(pPath) {
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
		public IVectorStep InVectorListUses {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesVectorUnitPrefix').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitDerivedStep InVectorUnitDerivedListUses {
			get {
				var step = new VectorUnitDerivedStep(Path);
				Path.AddSegment(step, "inE('VectorUnitDerivedUsesVectorUnitPrefix').outV");
				return step;
			}
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitDerivedStep : NodeForTypeStep<FabVectorUnitDerived>, IVectorUnitDerivedStep {
		
		private static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Defines", "VectorUnit", true, "/DefinesVectorUnit"),
			new StepLink("RaisesToExp", "VectorUnit", true, "/RaisesToExpVectorUnit"),
			new StepLink("Uses", "VectorUnitPrefix", true, "/UsesVectorUnitPrefix"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedStep(IPath pPath) : base(pPath) {
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
		public IVectorUnitStep DefinesVectorUnit {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('VectorUnitDerivedDefinesVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitStep RaisesToExpVectorUnit {
			get {
				var step = new VectorUnitStep(Path);
				Path.AddSegment(step, "outE('VectorUnitDerivedRaisesToExpVectorUnit').inV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorUnitPrefixStep UsesVectorUnitPrefix {
			get {
				var step = new VectorUnitPrefixStep(Path);
				Path.AddSegment(step, "outE('VectorUnitDerivedUsesVectorUnitPrefix').inV");
				return step;
			}
		}

	}

}