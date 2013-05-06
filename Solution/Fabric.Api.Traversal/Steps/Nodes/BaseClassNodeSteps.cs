// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 10:12:44 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Api.Traversal.Steps.Nodes {
	

	/*================================================================================================*/
	public abstract partial class NodeForActionStep<T> : NodeStep<T>, INodeForActionStep
																			where T : FabNode, new() {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected NodeForActionStep(IPath pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

	}


	/*================================================================================================*/
	public abstract partial class ArtifactStep<T> : NodeStep<T>, IArtifactStep
																			where T : FabNode, new() {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ArtifactStep(IPath pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks {
			get { return base.AvailableLinks.Concat(ArtifactStep.AvailNodeLinks).ToList(); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return PropDbName.Artifact_ArtifactId; } }
		public override bool TypeIdIsLong { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inmembercreates": return InMemberCreates;
				case "infactorlistusesprimary": return InFactorListUsesPrimary;
				case "infactorlistusesrelated": return InFactorListUsesRelated;
				case "infactorlistdescriptorrefinesprimarywith": return InFactorListDescriptorRefinesPrimaryWith;
				case "infactorlistdescriptorrefinesrelatedwith": return InFactorListDescriptorRefinesRelatedWith;
				case "infactorlistdescriptorrefinestypewith": return InFactorListDescriptorRefinesTypeWith;
				case "infactorlistvectorusesaxis": return InFactorListVectorUsesAxis;
			}

			return base.GetLink(pData);
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('M-C-A').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListUsesPrimary {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('F-UP-A').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListUsesRelated {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('F-UR-A').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListDescriptorRefinesPrimaryWith {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('F-DRP-A').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListDescriptorRefinesRelatedWith {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('F-DRR-A').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListDescriptorRefinesTypeWith {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('F-DRT-A').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListVectorUsesAxis {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('F-VUA-A').outV");
				return step;
			}
		}

	}


	/*================================================================================================*/
	public partial class ArtifactStep : ArtifactStep<FabArtifact> {
	
		internal static readonly List<IStepLink> AvailNodeLinks = new List<IStepLink> {
			new StepLink("Creates", "Member", false, "/InMemberCreates"),
			new StepLink("UsesPrimary", "Factor", false, "/InFactorListUsesPrimary"),
			new StepLink("UsesRelated", "Factor", false, "/InFactorListUsesRelated"),
			new StepLink("DescriptorRefinesPrimaryWith", "Factor", false, "/InFactorListDescriptorRefinesPrimaryWith"),
			new StepLink("DescriptorRefinesRelatedWith", "Factor", false, "/InFactorListDescriptorRefinesRelatedWith"),
			new StepLink("DescriptorRefinesTypeWith", "Factor", false, "/InFactorListDescriptorRefinesTypeWith"),
			new StepLink("VectorUsesAxis", "Factor", false, "/InFactorListVectorUsesAxis"),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactStep(IPath pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return PropDbName.Artifact_ArtifactId; } }
		public override bool TypeIdIsLong { get { return true; } }

	}

}