
// GENERATED CODE
// Changes made to this source file will be overwritten

using System;
using System.Collections.Generic;

namespace Fabric.New.Api.Objects.Traversal {


	/*================================================================================================*/
	public abstract partial class FabTravTypedRoot {

		public static readonly IDictionary<Type, Type> BaseTypeMap = new Dictionary<Type, Type> {
			{ typeof(FabTravAppRoot), typeof(FabApp) },
			{ typeof(FabTravArtifactRoot), typeof(FabArtifact) },
			{ typeof(FabTravClassRoot), typeof(FabClass) },
			{ typeof(FabTravFactorRoot), typeof(FabFactor) },
			{ typeof(FabTravInstanceRoot), typeof(FabInstance) },
			{ typeof(FabTravMemberRoot), typeof(FabMember) },
			{ typeof(FabTravUrlRoot), typeof(FabUrl) },
			{ typeof(FabTravUserRoot), typeof(FabUser) },
			{ typeof(FabTravVertexRoot), typeof(FabVertex) },
		};
	
	}

	/*================================================================================================*/
	public class FabTravAppRoot : FabTravArtifactRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabApp);
		}

	}

	/*================================================================================================*/
	public class FabTravArtifactRoot : FabTravVertexRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabArtifact);
		}

	}

	/*================================================================================================*/
	public class FabTravClassRoot : FabTravArtifactRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabClass);
		}

	}

	/*================================================================================================*/
	public class FabTravFactorRoot : FabTravVertexRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabFactor);
		}

	}

	/*================================================================================================*/
	public class FabTravInstanceRoot : FabTravArtifactRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabInstance);
		}

	}

	/*================================================================================================*/
	public class FabTravMemberRoot : FabTravVertexRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabMember);
		}

	}

	/*================================================================================================*/
	public class FabTravUrlRoot : FabTravArtifactRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabUrl);
		}

	}

	/*================================================================================================*/
	public class FabTravUserRoot : FabTravArtifactRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabUser);
		}

	}

	/*================================================================================================*/
	public class FabTravVertexRoot : FabTravTypedRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type GetBaseType() {
			return typeof(FabVertex);
		}

	}

}