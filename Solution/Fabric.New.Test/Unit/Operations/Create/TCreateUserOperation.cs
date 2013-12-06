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
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUserOperation : 
						TCreateArtifactOperation<User, FabUser, CreateFabUser, CreateUserOperation> {

		private static readonly Logger Log = Logger.Build<TCreateUserOperation>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Name = "MyUser";
			vCreateObj.Password = "MyPassword";

			SetupAddVertexResultAt(2);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pConditionCmdId) {
			var uniqueNameKey = AddCommand("uniqueNameKey", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "unq=g.V('"+DbName.Vert.User.NameKey+"',_P);(unq?0:1);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name.ToLower()
				}),
				Cache = true
			});

			pConditionCmdId = uniqueNameKey.CommandId;

			AddCommand("addUser", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.User.Name+":_P,"+
						DbName.Vert.User.NameKey+":_P,"+
						DbName.Vert.User.Password+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name,
					vCreateObj.Name.ToLower(),
					DataUtil.HashPassword(vCreateObj.Password),
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.User
				}),
				Cache = true
			});

			return base.SetupCommands(pConditionCmdId);
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
		protected override VertexType.Id GetVertexTypeId() {
			return VertexType.Id.User;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailDuplicate() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(1, 0)).Returns(1);
			CreateUserOperation c = BuildCreateVerify();
			TestUtil.Throws<FabDuplicateFault>(() => c.Execute());
		}

	}

}