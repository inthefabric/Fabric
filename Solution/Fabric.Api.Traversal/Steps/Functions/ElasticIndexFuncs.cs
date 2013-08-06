// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 8/6/2013 3:29:15 PM

using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ElasticIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<ACrElasticIndexFunc>(p => new ACrElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<ApNaElasticIndexFunc>(p => new ApNaElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<ClNaElasticIndexFunc>(p => new ClNaElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<ClDiElasticIndexFunc>(p => new ClDiElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<InNaElasticIndexFunc>(p => new InNaElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<InDiElasticIndexFunc>(p => new InDiElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UrNaElasticIndexFunc>(p => new UrNaElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<FCrElasticIndexFunc>(p => new FCrElasticIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<FIdVElasticIndexFunc>(p => new FIdVElasticIndexFunc(p), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("ArtifactCreated", ReturnsObject=typeof(FabArtifact))]
	public class ACrElasticIndexFunc : ElasticIndexHasFunc<long> {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ACrElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ArtifactStep(pPath);
			PropName = "A_Cr";
		}

	}


	/*================================================================================================*/
	[Func("AppNameContains", ReturnsObject=typeof(FabApp))]
	public class ApNaElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApNaElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			PropName = "Ap_Na";
		}

	}


	/*================================================================================================*/
	[Func("ClassNameContains", ReturnsObject=typeof(FabClass))]
	public class ClNaElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClNaElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			PropName = "Cl_Na";
		}

	}


	/*================================================================================================*/
	[Func("ClassDisambContains", ReturnsObject=typeof(FabClass))]
	public class ClDiElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClDiElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			PropName = "Cl_Di";
		}

	}


	/*================================================================================================*/
	[Func("InstanceNameContains", ReturnsObject=typeof(FabInstance))]
	public class InNaElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InNaElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new InstanceStep(pPath);
			PropName = "In_Na";
		}

	}


	/*================================================================================================*/
	[Func("InstanceDisambContains", ReturnsObject=typeof(FabInstance))]
	public class InDiElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InDiElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new InstanceStep(pPath);
			PropName = "In_Di";
		}

	}


	/*================================================================================================*/
	[Func("UrlNameContains", ReturnsObject=typeof(FabUrl))]
	public class UrNaElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrNaElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			PropName = "Ur_Na";
		}

	}


	/*================================================================================================*/
	[Func("FactorCreated", ReturnsObject=typeof(FabFactor))]
	public class FCrElasticIndexFunc : ElasticIndexHasFunc<long> {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FCrElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			PropName = "F_Cr";
		}

	}


	/*================================================================================================*/
	[Func("FactorIdentorValueContains", ReturnsObject=typeof(FabFactor))]
	public class FIdVElasticIndexFunc : ElasticIndexContainsFunc {
	

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FIdVElasticIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			PropName = "F_IdV";
		}

	}

}