using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateMemberOperation :
					TCreateVertexOperation<Member, FabMember, CreateFabMember, CreateMemberOperation> {

		private static readonly Logger Log = Logger.Build<TCreateMemberOperation>();

		private const int GetMemberCmdI = 1;
		private const int GetAppCmdI = 3;
		private const int GetUserCmdI = 6;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Type = (byte)MemberType.Id.Owner;
			vCreateObj.DefinedByAppId = 98763543;
			vCreateObj.DefinedByUserId = 235236122;

			SetupAddVertexResultAt(2);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetAppCmdI, 0)).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetUserCmdI, 0)).Returns(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			var getMember = AddCommand("getMember", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"m=g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
						".outE('"+DbName.Edge.UserDefinesMemberName+"')"+
							".has('"+DbName.Edge.UserDefinesMember.AppId+"',Tokens.T.eq,_P);"+
					"(m?0:1);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.DefinedByUserId,
					vCreateObj.DefinedByAppId
				}),
				Cache = true
			});

			pCondCmdId = getMember.CommandId;

			AddCommand("addMember", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.Member.MemberType+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Type,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.Member
				}),
				Cache = true
			});

			pCondCmdId = SetupEdgePair("defByApp", pCondCmdId, 0, vCreateObj.DefinedByAppId,
				DbName.Edge.MemberDefinedByAppName, DbName.Edge.AppDefinesMemberName,
				new[] {
					DbName.Edge.AppDefinesMember.Timestamp,
					DbName.Edge.AppDefinesMember.MemberType,
					DbName.Edge.AppDefinesMember.UserId
				},
				new object[] {
					vExpectDomResult.Timestamp,
					(byte)GetVertexTypeId(),
					vCreateObj.DefinedByUserId
				}
			);

			pCondCmdId = SetupEdgePair("defByUser", pCondCmdId, 1, vCreateObj.DefinedByUserId,
				DbName.Edge.MemberDefinedByUserName, DbName.Edge.UserDefinesMemberName,
				new[] {
					DbName.Edge.UserDefinesMember.Timestamp,
					DbName.Edge.UserDefinesMember.MemberType,
					DbName.Edge.UserDefinesMember.AppId
				},
				new object[] {
					vExpectDomResult.Timestamp,
					(byte)GetVertexTypeId(),
					vCreateObj.DefinedByAppId
				}
			);

			return pCondCmdId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Logger GetLogger() {
			return Log;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsInternalGetResult() {
			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexType.Id GetVertexTypeId() {
			return VertexType.Id.Member;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailDuplicate() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetMemberCmdI, 0)).Returns(1);
			CreateMemberOperation c = BuildCreateVerify();
			TestUtil.Throws<FabDuplicateFault>(() => c.Execute());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailNoApp() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetAppCmdI, 0)).Returns(0);
			CreateMemberOperation c = BuildCreateVerify();
			TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailNoUser() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetUserCmdI, 0)).Returns(0);
			CreateMemberOperation c = BuildCreateVerify();
			TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
		}

	}

}