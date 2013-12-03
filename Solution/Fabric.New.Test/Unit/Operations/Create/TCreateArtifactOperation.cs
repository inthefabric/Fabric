using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateArtifactOperation<TDom, TCre, TOper> : 
					TCreateVertexOperation<TDom, TCre, TOper> where TDom : Artifact, new()
					where TCre : CreateFabArtifact, new() where TOper : CreateArtifactOperation, new() {

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
			vMockTxb.Setup(x => x.GetVertex(vMemId, out vMemVar));
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCreate() {
			vMockTxb.Verify(
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
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetResult() {
			var c = new CreateUserOperation();

			if ( IsInternalGetResult() ) {
				TestUtil.Throws<NotSupportedException>(() => c.GetResult());
				return;
			}

			Assert.Fail("Non-internal GetResult is not supported yet.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetTypedResult() {
			var tx = new Mock<IWeaverTransaction>();
			vMockTxb.Setup(x => x.Finish(vVertVar)).Returns(tx.Object);

			var expectResult = new TDom();
			vMockData.Setup(x => x.Get<TDom>(tx.Object, GetCreateQueryName())).Returns(expectResult);

			TOper c = DoCreate();
			TDom result = GetTypedResultFromOperation(c);

			Assert.AreEqual(expectResult, result, "Result should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		[Category(TestUtil.RawScriptCategory)]
		public void GetTypedResultScript() {
			var txb = new TxBuilder();
			var expectResult = new TDom();

			vMockData
				.Setup(x => x.Get<TDom>(It.IsAny<IWeaverTransaction>(), GetCreateQueryName()))
				.Callback(GetCreateScriptCallback())
				.Returns(expectResult);

			TOper c = DoCreate(txb);
			TDom result = GetTypedResultFromOperation(c);

			Assert.AreEqual(expectResult, result, "Result should be filled.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool IsInternalGetResult();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract string GetCreateQueryName();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract TDom GetTypedResultFromOperation(TOper pOper);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Action<IWeaverScript, string> GetCreateScriptCallback();

	}

}