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
	public class TCreateEmailOperation :
						TCreateVertexOperation<Email, FabVertex, CreateFabEmail, CreateEmailOperation> {

		private static readonly Logger Log = Logger.Build<TCreateEmailOperation>();

		private const int GetArtifactCmdI = 2;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Address = "MyAddress@MyDomain.com";
			vCreateObj.Code = "abcdefghijklmnopQRSTUVWXYZ012345";
			vCreateObj.Verified = false;
			vCreateObj.UsedByArtifactId = 987442;

			SetupAddVertexResultAt(1);
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetArtifactCmdI, 0)).Returns(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			AddCommand("addEmail", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.Email.Address+":_P,"+
						DbName.Vert.Email.Code+":_P,"+
						DbName.Vert.Email.Verified+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Address.ToLower(),
					vCreateObj.Code,
					vCreateObj.Verified,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.Email
				}),
				Cache = true
			});

			pCondCmdId = SetupEdgePair("usedByArt", pCondCmdId, 0, vCreateObj.UsedByArtifactId,
				DbName.Edge.EmailUsedByArtifactName, DbName.Edge.ArtifactUsesEmailName,
				new string[0], new object[0]);

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
			return VertexType.Id.Email;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailNoArtifact() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetArtifactCmdI, 0)).Returns(0);
			CreateEmailOperation c = BuildCreateVerify();
			TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
		}

	}

}