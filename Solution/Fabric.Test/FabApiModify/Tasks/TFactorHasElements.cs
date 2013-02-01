using Fabric.Domain;
using Fabric.Infrastructure.Api;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TFactorHasDescriptor : TFactorHasElement<Descriptor, FactorUsesDescriptor> {

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasDescriptor(pApiCtx, pFactor);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TFactorHasDirector : TFactorHasElement<Director, FactorUsesDirector> {

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasDirector(pApiCtx, pFactor);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TFactorHasEventor : TFactorHasElement<Eventor, FactorUsesEventor> {

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasEventor(pApiCtx, pFactor);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TFactorHasIdentor : TFactorHasElement<Identor, FactorUsesIdentor> {

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasIdentor(pApiCtx, pFactor);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TFactorHasLocator : TFactorHasElement<Locator, FactorUsesLocator> {

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasLocator(pApiCtx, pFactor);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TFactorHasVector : TFactorHasElement<Vector, FactorUsesVector> {

		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasVector(pApiCtx, pFactor);
		}

	}

}