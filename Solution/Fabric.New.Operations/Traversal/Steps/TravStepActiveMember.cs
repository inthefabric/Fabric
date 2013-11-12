using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Names;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepActiveMember : TravStep<FabTravMemberRoot, FabMember> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepActiveMember() : base("Active", 0) {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathStep step = pPath.ConsumeSteps(1, ToType)[0];
			step.VerifyParamCount(Params);

			string propParam = pPath.AddParam(DbName.Vert.Vertex.VertexId);
			string idParam = pPath.AddParam(pPath.MemberId);

			pPath.AddScript(".has("+propParam+", "+idParam+")");
		}

	}

}