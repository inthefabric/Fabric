using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUserOperation : 
						TCreateArtifactOperation<User, FabUser, CreateFabUser, CreateUserOperation> {

		private static readonly Logger Log = Logger.Build<TCreateUserOperation>();

		private const string UniqueUserNameScript = "g.V('"+DbName.Vert.User.NameKey+"',_P);";

		private const string CreateUserScript = 
			"_V0=g.addVertex(["+
				DbName.Vert.User.Name+":_TP,"+
				DbName.Vert.User.NameKey+":_TP,"+
				DbName.Vert.User.Password+":_TP,"+
				DbName.Vert.Vertex.VertexId+":_TP,"+
				DbName.Vert.Vertex.Timestamp+":_TP,"+
				DbName.Vert.Vertex.VertexType+":_TP"+
			"]);"+
			"_V1=g.V('"+DbName.Vert.Vertex.VertexId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"g.addEdge(_V1,_V0,_TP,["+
				DbName.Edge.MemberCreatesArtifact.Timestamp+":_TP,"+
				DbName.Edge.MemberCreatesArtifact.VertexType+":_TP"+
			"]);"+
			"_V0;";

		private Action<IWeaverScript, string> vCheckUniqueUserName;
		private Action<IWeaverScript, string> vCheckCreateUser;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vCreateObj.Name = "MyUser";
			vCreateObj.Password = "MyPassword";

			vMockDataAcc.MockResult.Setup(x => x.GetCommandIndexByCmdId("1")).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToElementAt<User>(1, 0)).Returns(vExpectDomResult);

			////

			vCheckUniqueUserName = ((ws, n) => {
				var list = new List<object> {
					vCreateObj.Name.ToLower()
				};

			    CheckScriptAndParams(Log, ws, UniqueUserNameScript, "_P", list);
			});

			vCheckCreateUser = ((ws, n) => {
				var list = new List<object> {
					vCreateObj.Name,
					vCreateObj.Name.ToLower(),
					DataUtil.HashPassword(vCreateObj.Password),
					vVertId,
					vVertTime.Ticks,
					(byte)VertexType.Id.User,
					vMemId,
					DbName.Edge.ArtifactCreatedByMemberName,
					DbName.Edge.MemberCreatesArtifactName,
					vVertTime.Ticks,
					(byte)VertexType.Id.User,
				};

				CheckScriptAndParams(Log, ws, CreateUserScript, "_TP", list);
			});
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCreate() {
			base.VerifyCreate();

			vMockData.Verify(
				x => x.Get<User>(It.IsAny<IWeaverQuery>(), "UniqueUserName"),
				Times.Once
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CreateDuplicate() {
			vMockData
				.Setup(x => x.Get<User>(It.IsAny<IWeaverQuery>(), "UniqueUserName"))
				.Callback(vCheckUniqueUserName)
				.Returns(new User());

			TestUtil.Throws<FabDuplicateFault>(() => DoCreate());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Logger GetLogger() {
			return Log;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsInternalGetResult() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void OnDataExecuteInner(MockDataAccess pDataAccess) {
			//vCheckCreateUser
		}

	}

}