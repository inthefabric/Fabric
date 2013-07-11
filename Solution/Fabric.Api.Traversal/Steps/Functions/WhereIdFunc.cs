using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IFuncWhereIdStep : IFunc, IFinalStep {
		
		long Id { get; }

	}


	/*================================================================================================*/
	[Func("WhereId")]
	public class WhereIdFunc : Func, IFuncWhereIdStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WhereIdFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "has");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(1);

			////

			Id = ParamAt<long>(0);

			if ( Id == 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Cannot be 0.", 0);
			}

			////

			ProxyStep = Path.GetSegmentBeforeLast(1).Step;
			IVertexStep ns;

			if ( ProxyStep is IFunc ) {
				ns = (IVertexStep)((IFunc)ProxyStep).ProxyStep;
			}
			else {
				ns = (IVertexStep)ProxyStep;
			}

			string idParam = Path.AddParam(new WeaverQueryVal(Id));
			Path.AppendToCurrentSegment("('"+ns.TypeIdName+"',Tokens.T.eq,"+idParam+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			return true;
		}

	}

}