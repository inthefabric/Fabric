using System;
using System.Linq.Expressions;
using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract partial class Vertex : WeaverVertex, IVertex, IVertexWithId {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Vertex(VertexFabType pFabType) {
			FabType = (byte)pFabType;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract long GetTypeId();
		public abstract void SetTypeId(long pTypeId);
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual Expression<Func<T, object>> GetTypeIdProp<T>() where T : IVertex {
			return (x => x.Id);
		}

	}

}