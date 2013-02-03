using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XFactorHasDescriptor : XFactorHasElement<Descriptor, FactorUsesDescriptor> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasDescriptor(pApiCtx, pFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Zach_Graphics_Produce)]
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_Focal)]
		public override void Found(long pFactorId) {
			base.Found(pFactorId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public override void NotFound(long pFactorId) {
			base.NotFound(pFactorId);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class XFactorHasDirector : XFactorHasElement<Director, FactorUsesDirector> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasDirector(pApiCtx, pFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Zach_Fabric_ViewSuggLearn)]
		[TestCase(SetupFactors.FactorId.FM_Mel_Zach_ViewSuggView)]
		public override void Found(long pFactorId) {
			base.Found(pFactorId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Zach_Human_IsA_Male_Def)]
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public override void NotFound(long pFactorId) {
			base.NotFound(pFactorId);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class XFactorHasEventor : XFactorHasElement<Eventor, FactorUsesEventor> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasEventor(pApiCtx, pFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GE_CutePho_Photo_IsA_Occur_Cuteness)]
		[TestCase(SetupFactors.FactorId.FZ_Zach_Caledonia_FoundIn_Home_Start)]
		public override void Found(long pFactorId) {
			base.Found(pFactorId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Zach_Evolution_Interest)]
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public override void NotFound(long pFactorId) {
			base.NotFound(pFactorId);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class XFactorHasIdentor : XFactorHasElement<Identor, FactorUsesIdentor> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasIdentor(pApiCtx, pFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_Key4165_Def)]
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_TextImg9203)]
		public override void Found(long pFactorId) {
			base.Found(pFactorId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_Focal)]
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public override void NotFound(long pFactorId) {
			base.NotFound(pFactorId);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class XFactorHasLocator : XFactorHasElement<Locator, FactorUsesLocator> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasLocator(pApiCtx, pFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GM_CutePho_Smile_HasA_Subject)]
		[TestCase(SetupFactors.FactorId.FZ_Zach_Caledonia_FoundIn_Home_Start)]
		public override void Found(long pFactorId) {
			base.Found(pFactorId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_Quality)]
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public override void NotFound(long pFactorId) {
			base.NotFound(pFactorId);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class XFactorHasVector : XFactorHasElement<Vector, FactorUsesVector> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool ExecuteTask(IApiContext pApiCtx, Factor pFactor) {
			return Tasks.FactorHasVector(pApiCtx, pFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_FStop)]
		[TestCase(SetupFactors.FactorId.GZ_CutePho_Photo_IsA_Occur_QualityA)]
		public override void Found(long pFactorId) {
			base.Found(pFactorId);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.GM_CutePho_Fun_Emotes)]
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public override void NotFound(long pFactorId) {
			base.NotFound(pFactorId);
		}

	}

}