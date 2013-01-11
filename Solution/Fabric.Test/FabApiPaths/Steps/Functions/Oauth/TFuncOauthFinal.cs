using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions.Oauth;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Functions.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public abstract class TFuncOauthFinal {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract FuncOauthFinal NewStep(Path pPath);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = NewStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual("", s.Path.Script, "Incorrect Path.Script.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.AreEqual(true, s.UseLocalData, "Incorrect UseLocalData.");
			Assert.AreEqual(0, s.Index, "Incorrect Index.");
			Assert.AreEqual(1, s.Count, "Incorrect Count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("(1)")]
		[TestCase("(1,2,3)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Path();
			var s = NewStep(p);
			var sd = new StepData("Func"+pParams);

			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

	}

}