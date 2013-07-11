using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract class IndexFunc : Func { //TEST: IndexFunc

		protected string PropName { get; set; }
		protected byte? FabType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected IndexFunc(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			GetValue();
			AppendPathSegment();

			if ( FabType != null ) {
				string propParam = Path.AddParam(new WeaverQueryVal(PropDbName.Vertex_FabType));
				string typeParam = Path.AddParam(new WeaverQueryVal((byte)FabType));
				Path.AppendToCurrentSegment("has("+propParam+","+typeParam+")");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void AppendPathSegment();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void GetValue();

	}

}