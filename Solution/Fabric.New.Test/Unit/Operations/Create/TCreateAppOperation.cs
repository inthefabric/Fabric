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
	public class TCreateAppOperation :
							TCreateArtifactOperation<App, FabApp, CreateFabApp, CreateAppOperation> {

		private static readonly Logger Log = Logger.Build<TCreateAppOperation>();

		private const int GetDuplicateCmdI = 1;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Name = "MyApp";
			vCreateObj.Secret = "abcdefghijklmnopQRSTUVWXYZ012345";
			vCreateObj.OauthDomains = null;

			SetupAddVertexResultAt(2);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			var uniqueNameKey = AddCommand("uniqueNameKey", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = "unq=g.V('"+DbName.Vert.App.NameKey+"',_P);(unq?0:1);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name.ToLower()
				}),
				Cache = true
			});

			pCondCmdId = uniqueNameKey.CommandId;

			AddCommand("addApp", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.App.Name+":_P,"+
						DbName.Vert.App.NameKey+":_P,"+
						DbName.Vert.App.Secret+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name,
					vCreateObj.Name.ToLower(),
					vCreateObj.Secret,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.App
				}),
				Cache = true
			});

			return base.SetupCommands(pCondCmdId);
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
			return VertexType.Id.App;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailDuplicate() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetDuplicateCmdI, 0)).Returns(1);
			CreateAppOperation c = BuildCreateVerify();
			TestUtil.Throws<FabDuplicateFault>(() => c.Execute());
		}

	}

}