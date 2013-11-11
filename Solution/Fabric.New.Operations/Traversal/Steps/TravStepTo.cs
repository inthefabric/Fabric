using Fabric.New.Api.Objects;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepTo<TFrom, TTo> : TravStep<TFrom, TTo>
														where TFrom : FabObject where TTo : FabObject {

		private readonly VertexDomainType.Id vType;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTo(string pNameDom, VertexDomainType.Id pType) : base("To"+pNameDom, 0) {
			vType = pType;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathStep step = pPath.ConsumeSteps(1, ToType)[0];
			step.VerifyParamCount(Params);

			string op = GremlinUtil.GetStandardCompareOperation(GremlinUtil.Equal);
			string propParam = pPath.AddParam(DbName.Vert.Vertex.VertexType);
			string typeParam = pPath.AddParam(vType);

			pPath.AddScript(".has("+propParam+", "+op+", "+typeParam+")");
		}

	}

}