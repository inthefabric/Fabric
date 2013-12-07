using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateArtifactOperation<TDom, TApi, TCre, TOper> :
										TCreateVertexOperation<TDom, TApi, TCre, TOper>
										where TDom : Artifact, new()
										where TApi : FabArtifact, new()
										where TCre : CreateFabArtifact, new()
										where TOper : CreateArtifactOperation<TDom, TApi, TCre>, new() {

		private long vMemId;
		private int vGetMemCmdIndex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vMemId = 123456;

			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(vMemId);
			vMockData.Setup(x => x.GetVertexById<Vertex>(vMemId)).Returns(new Member());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			vGetMemCmdIndex = GetExpectedCommandCount();
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(vGetMemCmdIndex, 0)).Returns(1);

			pCondCmdId = SetupEdgePair("creByMem", pCondCmdId, 0, vMemId,
				DbName.Edge.ArtifactCreatedByMemberName, DbName.Edge.MemberCreatesArtifactName,
				new [] {
					DbName.Edge.MemberCreatesArtifact.Timestamp,
					DbName.Edge.MemberCreatesArtifact.VertexType
				},
				new object[] {
					vExpectDomResult.Timestamp,
					(byte)GetVertexTypeId()
				}
			);

			return pCondCmdId;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailGetMember() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(vGetMemCmdIndex, 0)).Returns(0);
			TOper c = BuildCreateVerify();
			TestUtil.Throws<FabNotFoundFault>(() => c.Execute());
		}

	}

}