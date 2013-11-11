using Fabric.New.Domain;

namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public abstract class FabObject : FabElement {

		public string ObjectType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Fill(Vertex pVertex) {
			ObjectType = GetType().Name;
		}

	}

}