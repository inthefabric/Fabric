using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Operations.Create;
using Moq;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateArtifactOperation<TDom, TApi, TCre, TOper> :
										TCreateVertexOperation<TDom, TApi, TCre, TOper>
										where TDom : Artifact, new()
										where TApi : FabArtifact, new()
										where TCre : CreateFabArtifact, new()
										where TOper : CreateArtifactOperation<TDom, TApi, TCre>, new() {

		protected long vMemId;
		private IWeaverVarAlias<Member> vMemVar;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vMemId = 123456;
			vMemVar = new WeaverVarAlias<Member>("mem");

			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(vMemId);
			vMockData.Setup(x => x.GetVertexById<Vertex>(vMemId)).Returns(new Member());
			//vMockTxb.Setup(x => x.GetVertex(vMemId, out vMemVar));
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCreate() {
			/*vMockTxb.Verify(
				x => x.AddEdge(
					It.IsAny<IWeaverVarAlias<Artifact>>(),
					It.IsAny<ArtifactCreatedByMember>(),
					It.IsAny<IWeaverVarAlias<Member>>()
				),
				Times.Once
			);

			vMockTxb.Verify(
				x => x.AddEdge(
					It.IsAny<IWeaverVarAlias<Member>>(),
					It.IsAny<MemberCreatesArtifact>(),
					It.IsAny<IWeaverVarAlias<Artifact>>()
				),
				Times.Once
			);*/
		}

	}

}