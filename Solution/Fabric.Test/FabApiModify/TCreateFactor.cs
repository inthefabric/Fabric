using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateFactor : TBaseModifyFunc {

		private long vPrimArtId;
		private long vRelArtId;
		private long vAssertId;
		private bool vIsDefining;
		private string vNote;
		private Member vCreator;

		private IWeaverVarAlias<Factor> vOutFactorVar;
		private Factor vResultFactor;
		private Factor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vPrimArtId = 1251253;
			vRelArtId = 64362346;
			vAssertId = 1;
			vIsDefining = true;
			vNote = "note here";
			vCreator = new Member { MemberId = 151235 };

			vOutFactorVar = GetTxVar<Factor>("FACTOR");
			vResultFactor = new Factor();

			SetUpMember(1, 2, new Member { MemberId = 234623 });

			MockTasks
				.Setup(x => x.TxAddFactor(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vPrimArtId,
						vRelArtId,
						vAssertId,
						vIsDefining,
						vNote,
						ApiCtxMember,
						out vOutFactorVar
					)
				);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			MockApiCtx
				.Setup(x => x.DbSingle<Factor>("CreateFactorTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateFactorTx(q));

			MockTasks.Setup(x => x.GetArtifact(MockApiCtx.Object, vPrimArtId)).Returns(new Artifact());
			MockTasks.Setup(x => x.GetArtifact(MockApiCtx.Object, vRelArtId)).Returns(new Artifact());
		}

		/*--------------------------------------------------------------------------------------------*/
		private Factor CreateFactorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "FACTOR;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultFactor;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateFactor(
				MockTasks.Object, vPrimArtId, vRelArtId, vAssertId, vIsDefining, vNote);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.AreEqual(vResultFactor, vResult, "Incorrect Result.");

			MockValidator.Verify(x => x.ArtifactId(vPrimArtId, CreateFactor.PrimArtParam),Times.Once());
			MockValidator.Verify(x => x.ArtifactId(vRelArtId, CreateFactor.RelArtParam), Times.Once());
			MockValidator.Verify(x => x.FactorAssertionId(
				vAssertId, CreateFactor.AssertParam), Times.Once());
			MockValidator.Verify(x => x.FactorNote(vNote, CreateFactor.NoteParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryEqualsRelated() {
			vRelArtId = vPrimArtId;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryArtifactNotFound() {
			MockTasks.Setup(x => x.GetArtifact(MockApiCtx.Object, vPrimArtId)).Returns((Artifact)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRelatedArtifactNotFound() {
			MockTasks.Setup(x => x.GetArtifact(MockApiCtx.Object, vRelArtId)).Returns((Artifact)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			SetUpMember(1, 2, null);
			TestUtil.CheckThrows<FabMembershipFault>(true, TestGo);
		}

	}

}