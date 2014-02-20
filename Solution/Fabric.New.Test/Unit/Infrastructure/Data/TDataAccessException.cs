using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Infrastructure.Data {

	/*================================================================================================*/
	[TestFixture]
	public class TDataAccessException {

		private static readonly Logger Log = Logger.Build<TDataAccessException>();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			IDataAccess acc = new Mock<IDataAccess>(MockBehavior.Strict).Object;
			const string msg = "this is a message.";

			var dae = new DataAccessException(acc, msg);

			Assert.AreEqual(acc, dae.Access, "Incorrect Access.");
			Assert.AreEqual(msg, dae.Message, "Incorrect Message.");
		}

	}

}