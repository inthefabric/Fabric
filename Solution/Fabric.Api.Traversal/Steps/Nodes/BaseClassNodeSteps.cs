// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 2:54:24 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

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
		protected override IStep GetLink(StepData pData) {
			switch ( pData.Command ) {
				case "inmembercreates": return InMemberCreates;
				case "infactorlistusesprimary": return InFactorListUsesPrimary;
				case "infactorlistusesrelated": return InFactorListUsesRelated;
				case "infactorlistrefinesprimarywith": return InFactorListRefinesPrimaryWith;
				case "infactorlistrefinesrelatedwith": return InFactorListRefinesRelatedWith;
				case "infactorlistrefinestypewith": return InFactorListRefinesTypeWith;
				case "infactorlistusesaxis": return InFactorListUsesAxis;
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
		public IFactorStep InFactorListRefinesPrimaryWith {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorRefinesPrimaryWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListRefinesRelatedWith {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorRefinesRelatedWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListRefinesTypeWith {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorRefinesTypeWithArtifact').outV");
				return step;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IFactorStep InFactorListUsesAxis {
			get {
				var step = new FactorStep(Path);
				Path.AddSegment(step, "inE('FactorUsesAxisArtifact').outV");
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
			new StepLink("RefinesPrimaryWith", "Factor", false, "/InFactorListRefinesPrimaryWith"),
			new StepLink("RefinesRelatedWith", "Factor", false, "/InFactorListRefinesRelatedWith"),
			new StepLink("RefinesTypeWith", "Factor", false, "/InFactorListRefinesTypeWith"),
			new StepLink("UsesAxis", "Factor", false, "/InFactorListUsesAxis"),
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

}