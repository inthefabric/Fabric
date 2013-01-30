﻿using Fabric.Api.Modify;
using Fabric.Api.Modify.Results;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUser : TBaseModifyFunc {

		private string vEmail;
		private string vName;
		private string vPassword;

		private IWeaverVarAlias<User> vOutUserVar;
		private IWeaverVarAlias<Email> vOutEmailVar;
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

			MockTasks
				.Setup(x => x.TxAddEmail(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vEmail,
						It.IsAny<IWeaverVarAlias<Root>>(),
						out vOutEmailVar
					)
				);

			MockTasks
				.Setup(x => x.TxAddUser(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vPassword,
						It.IsAny<IWeaverVarAlias<Root>>(),
						It.IsAny<IWeaverVarAlias<Email>>(),
						out vOutUserVar
					)
				);

			vResultUser = new User();
			vResultEmail = new Email();

			var mockData = new Mock<IApiDataAccess>();
			mockData.Setup(x => x.GetResultAt<User>(0)).Returns(vResultUser);
			mockData.Setup(x => x.GetResultAt<Email>(1)).Returns(vResultEmail);
			vResultData = mockData.Object;

			MockApiCtx
				.Setup(x => x.DbData("CreateUserTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateUserTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess CreateUserTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = 
				"g.V('RootId',0)[0].each{_V0=g.v(it)};"+
				"_V1=[USER,EMAIL];";

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
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.AreEqual(vResultUser, vResult.NewUser, "Incorrect Result.NewUser.");
			Assert.AreEqual(vResultEmail, vResult.NewEmail, "Incorrect Result.NewEmail.");

			MockValidator.Verify(x => x.UserName(vName), Times.Once());
			MockValidator.Verify(x => x.UserPassword(vPassword), Times.Once());
			MockValidator.Verify(x => x.EmailAddress(vEmail), Times.Once());

			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Artifact> artVar;

			MockTasks
				.Verify(x => x.TxAddMember(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutUserVar,
						out memVar
					),
					Times.Once()
				);

			MockTasks
				.Verify(x => x.TxAddArtifact<User, UserHasArtifact>(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						ArtifactTypeId.User,
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutUserVar,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out artVar
					),
					Times.Once()
				);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DuplicateUser() {
			MockTasks
				.Setup(x => x.GetUserByName(MockApiCtx.Object, vName))
				.Returns(new User());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}

	}

}