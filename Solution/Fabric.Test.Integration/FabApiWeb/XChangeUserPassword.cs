using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XChangeUserPassword : XBaseWebFunc {

		private long vUserId;
		private string vOldPass;
		private string vNewPass;
		
		private SuccessResult vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vUserId = (long)UserZach;
			vOldPass = "asdfasdf";
			vNewPass = "N3wB3tt3rPa55w0rd";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeUserPassword(Tasks, vUserId, vOldPass, vNewPass);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Result.Success should not be null.");

			User upUser = GetVertex<User>(vUserId);
			Assert.AreEqual(FabricUtil.HashPassword(vNewPass), upUser.Password,
				"Target User.Password not updated.");
		}

				
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUserIdValue() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPasswordNull() {
			vNewPass = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(7)]
		[TestCase(33)]
		public void ErrPasswordLength(int pLength) {
			vNewPass = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

	}

}