using System;
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
	public class TCreateOauthAccessOperation : TCreateVertexOperation<
							OauthAccess, FabVertex, CreateFabOauthAccess, CreateOauthAccessOperation> {

		private static readonly Logger Log = Logger.Build<TCreateOauthAccessOperation>();

		private const int GetMemberCmdI = 2;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Token = "abcdefghijklmnopQRSTUVWXYZ012345";
			vCreateObj.Refresh = "012345ABCdefghijklmnopQRSTUVWXYZ";
			vCreateObj.Expires = DateTime.UtcNow.AddMinutes(5).Ticks;
			vCreateObj.IsDataProv = true;
			vCreateObj.AuthenticatesMemberId = 121236;

			SetupAddVertexResultAt(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetMemberCmdI, 0)).Returns(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pConditionCmdId) {
			AddCommand("addOauthAccess", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.OauthAccess.Token+":_P,"+
						DbName.Vert.OauthAccess.Refresh+":_P,"+
						DbName.Vert.OauthAccess.Expires+":_P,"+
						DbName.Vert.OauthAccess.IsDataProv+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Token,
					vCreateObj.Refresh,
					vCreateObj.Expires,
					vCreateObj.IsDataProv,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.OauthAccess
				}),
				Cache = true
			});

			var getMember = AddCommand("getMember", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "v0=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);(v0?{v0=v0.next();1;}:0);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.AuthenticatesMemberId
				}),
				Cache = true
			});

			pConditionCmdId = getMember.CommandId;

			AddCommand("addEdgeOaam", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "g.addEdge(a,v0,_P);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.OauthAccessAuthenticatesMemberName
				}),
				Cache = true,
				OmitResults = true
			});

			AddCommand("addEdgeMaboa", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "g.addEdge(v0,a,_P,["+
						DbName.Edge.MemberAuthenticatedByOauthAccess.Timestamp+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.MemberAuthenticatedByOauthAccessName,
					vExpectDomResult.Timestamp
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
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexType.Id GetVertexTypeId() {
			return VertexType.Id.OauthAccess;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailNoMember() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetMemberCmdI, 0)).Returns(0);
			CreateOauthAccessOperation c = BuildCreateVerify();
			TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
		}

	}

}