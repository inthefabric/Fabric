using Fabric.Infrastructure.Data;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TDataResultCheck {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			const string cmdId = "myCmd";
			var dr = new DataResultCheck(cmdId, (r, i) => { });
			Assert.AreEqual(cmdId, dr.CommandId, "Incorrect CommandId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void PerformCheck() {
			const string cmdId = "myCmd";
			const int cmdIndex = 999;
			IDataResult checkDataRes = null;
			int checkIndex = -1;

			var mockDataRes = new Mock<IDataResult>(MockBehavior.Strict);
			mockDataRes.Setup(x => x.GetCommandIndexByCmdId(cmdId)).Returns(cmdIndex);

			var dr = new DataResultCheck(cmdId, (r, i) => {
				checkDataRes = r;
				checkIndex = i;
			});

			dr.PerformCheck(mockDataRes.Object);

			Assert.AreEqual(mockDataRes.Object, checkDataRes, "Incorrect check DataResult.");
			Assert.AreEqual(cmdIndex, checkIndex, "Incorrect check Index.");
		}

	}

}