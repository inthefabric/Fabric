using System;
using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUser : TBaseWebFunc {

		private string vEmail;
		private string vName;
		private string vPassword;

		private IWeaverVarAlias<User> vOutUserVar;
		private IWeaverVarAlias<Email> vOutEmailVar;
		private Action<IWeaverVarAlias<Member>> vOutSetMemAction;
		private IWeaverVarAlias<Member> vResultMemAlias;
		private IApiDataAccess vResultData;
		private User vResultUser;
		private Email vResultEmail;
		private CreateUserResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vEmail = "new@email.com";
			vName = "NewUser";
			vPassword = "TestPassword";

			vOutUserVar = GetTxVar<User>("USER");
			vOutEmailVar = GetTxVar<Email>("EMAIL");
			vOutSetMemAction = (x => vResultMemAlias = x);
			IWeaverVarAlias<Member> memVar = new Mock<IWeaverVarAlias<Member>>().Object;

			MockTasks
				.Setup(x => x.TxAddEmail(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vEmail,
						out vOutEmailVar
					)
				);

			MockTasks
				.Setup(x => x.TxAddUser(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vPassword,
						It.IsAny<IWeaverVarAlias<Email>>(),
						out vOutUserVar,
						out vOutSetMemAction
					)
				);

			MockTasks
				.Setup(x => x.TxAddMember(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vOutUserVar,
						out memVar
					)
				);

			vResultUser = new User();
			vResultEmail = new Email();

			var mockData = new Mock<IApiDataAccess>();
			mockData.Setup(x => x.GetResultAt<User>(0)).Returns(vResultUser);
			mockData.Setup(x => x.GetResultAt<Email>(1)).Returns(vResultEmail);
			vResultData = mockData.Object;

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			MockApiCtx
				.Setup(x => x.DbData("CreateUserTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateUserTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess CreateUserTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "_V0=[USER,EMAIL];";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultData;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateUser(MockTasks.Object, vName, vPassword, vEmail);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			vResultMemAlias = null;
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.AreEqual(vResultUser, vResult.NewUser, "Incorrect Result.NewUser.");
			Assert.AreEqual(vResultEmail, vResult.NewEmail, "Incorrect Result.NewEmail.");
			Assert.NotNull(vResultMemAlias, "ResultMemAlias should not be null.");

			MockValidator.Verify(x => x.UserName(vName, CreateUser.NameParam), Times.Once());
			MockValidator.Verify(x => x.UserPassword(vPassword, CreateUser.PasswordParam),Times.Once());
			MockValidator.Verify(x => x.EmailAddress(vEmail, CreateUser.EmailParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateUser() {
			MockTasks
				.Setup(x => x.GetUserByName(MockApiCtx.Object, vName))
				.Returns(new User());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}

	}

}