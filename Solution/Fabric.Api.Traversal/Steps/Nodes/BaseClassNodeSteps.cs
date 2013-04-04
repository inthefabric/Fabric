// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/4/2013 9:44:55 AM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Nodes {
	

	/*================================================================================================*/
	public abstract partial class NodeForTypeStep<T> : NodeStep<T>, INodeForTypeStep
																			where T : FabNode, new() {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected NodeForTypeStep(IPath pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

	}


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
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inmembercreates": return InMemberCreates;
				case "infactorlistusesprimary": return InFactorListUsesPrimary;
				case "infactorlistusesrelated": return InFactorListUsesRelated;
				case "indescriptorlistrefinesprimarywith": return InDescriptorListRefinesPrimaryWith;
				case "indescriptorlistrefinesrelatedwith": return InDescriptorListRefinesRelatedWith;
				case "indescriptorlistrefinestypewith": return InDescriptorListRefinesTypeWith;
				case "invectorlistusesaxis": return InVectorListUsesAxis;
			}

			return base.GetLink(pData);
		}

		/*--------------------------------------------------------------------------------------------*/
		public IMemberStep InMemberCreates {
			get {
				var step = new MemberStep(Path);
				Path.AddSegment(step, "inE('MemberCreatesArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListUsesPrimary {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesPrimaryArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListUsesRelated {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesRelatedArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorStep InDescriptorListRefinesPrimaryWith {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorRefinesPrimaryWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorStep InDescriptorListRefinesRelatedWith {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorRefinesRelatedWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDescriptorStep InDescriptorListRefinesTypeWith {
			get {
				var step = new DescriptorStep(Path);
				Path.AddSegment(step, "inE('DescriptorRefinesTypeWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IVectorStep InVectorListUsesAxis {
			get {
				var step = new VectorStep(Path);
				Path.AddSegment(step, "inE('VectorUsesAxisArtifact').outV");
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
			new StepLink("RefinesPrimaryWith", "Descriptor", false, "/InDescriptorListRefinesPrimaryWith"),
			new StepLink("RefinesRelatedWith", "Descriptor", false, "/InDescriptorListRefinesRelatedWith"),
			new StepLink("RefinesTypeWith", "Descriptor", false, "/InDescriptorListRefinesTypeWith"),
			new StepLink("UsesAxis", "Vector", false, "/InVectorListUsesAxis"),
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
		public override string TypeIdName { get { return "ArtifactId"; } }
		public override bool TypeIdIsLong { get { return true; } }

	}


	/*================================================================================================*/
	public abstract partial class FactorElementNodeStep<T> : NodeStep<T>, IFactorElementNodeStep
																			where T : FabNode, new() {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FactorElementNodeStep(IPath pPath) : base(pPath) {
			ConstructorHook();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		partial void ConstructorHook();

	}

}