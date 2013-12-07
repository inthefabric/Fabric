using System;
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
		protected override string SetupCommands(string pCondCmdId) {
			AddCommand("addOauthAccess", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
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

			pCondCmdId = SetupEdgePair("authMem", pCondCmdId, 0, vCreateObj.AuthenticatesMemberId,
				DbName.Edge.OauthAccessAuthenticatesMemberName, DbName.Edge.MemberAuthenticatedByOauthAccessName,
				new[] {
					DbName.Edge.MemberAuthenticatedByOauthAccess.Timestamp
				},
				new object[] {
					vExpectDomResult.Timestamp
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