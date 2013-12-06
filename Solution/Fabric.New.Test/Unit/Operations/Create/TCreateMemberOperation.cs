using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
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
		protected override string SetupCommands(string pConditionCmdId) {
			var getMember = AddCommand("getMember", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
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

			pConditionCmdId = getMember.CommandId;

			AddCommand("addMember", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
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

			////

			var getApp = AddCommand("getApp", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "v0=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);(v0?{v0=v0.next();1;}:0);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.DefinedByAppId
				}),
				Cache = true
			});

			pConditionCmdId = getApp.CommandId;

			AddCommand("addEdgeMdbp", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "g.addEdge(a,v0,_P);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.MemberDefinedByAppName
				}),
				Cache = true,
				OmitResults = true
			});

			AddCommand("addEdgePdm", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = 
					"g.addEdge(v0,a,_P,["+
						DbName.Edge.AppDefinesMember.Timestamp+":_P,"+
						DbName.Edge.AppDefinesMember.MemberType+":_P,"+
						DbName.Edge.AppDefinesMember.UserId+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.AppDefinesMemberName,
					vExpectDomResult.Timestamp,
					(byte)GetVertexTypeId(),
					vCreateObj.DefinedByUserId,
				}),
				Cache = true,
				OmitResults = true
			});

			////

			var getUser = AddCommand("getUser", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "v1=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);(v1?{v1=v1.next();1;}:0);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.DefinedByUserId
				}),
				Cache = true
			});

			pConditionCmdId = getUser.CommandId;

			AddCommand("addEdgeMdbu", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "g.addEdge(a,v1,_P);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.MemberDefinedByUserName
				}),
				Cache = true,
				OmitResults = true
			});

			AddCommand("addEdgeUdm", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = 
					"g.addEdge(v1,a,_P,["+
						DbName.Edge.UserDefinesMember.Timestamp+":_P,"+
						DbName.Edge.UserDefinesMember.MemberType+":_P,"+
						DbName.Edge.UserDefinesMember.AppId+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.UserDefinesMemberName,
					vExpectDomResult.Timestamp,
					(byte)GetVertexTypeId(),
					vCreateObj.DefinedByAppId,
				}),
				Cache = true,
				OmitResults = true
			});

			return pConditionCmdId;
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