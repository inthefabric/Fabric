using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateFactor : TBaseModifyFunc {

		private long vPrimArtId;
		private long vEdgeArtId;
		private byte vAssertId;
		private bool vIsDefining;
		private string vNote;

		private IWeaverVarAlias<Factor> vOutFactorVar;
		private Factor vResultFactor;
		private Factor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vPrimArtId = 1251253;
			vEdgeArtId = 64362346;
			vAssertId = 1;
			vIsDefining = true;
			vNote = "note here";

			vOutFactorVar = TestUtil.GetTxVar<Factor>("FACTOR");
			vResultFactor = new Factor();

			SetUpMember(1, 2, new Member { MemberId = 234623 });

			MockTasks
				.Setup(x => x.TxAddFactor(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vPrimArtId,
						vEdgeArtId,
						vAssertId,
						vIsDefining,
						vNote,
						ApiCtxMember,
						out vOutFactorVar
					)
				);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			var mda = MockDataAccess.Create(m => { });
			mda.MockResult.SetupToElement(new Artifact());
			MockDataList.Add(mda);

			mda = MockDataAccess.Create(m => { });
			mda.MockResult.SetupToElement(new Artifact());
			MockDataList.Add(mda);

			mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vResultFactor);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			const string expectPartial = "FACTOR;";
			Assert.AreEqual(expectPartial, cmd.Script, "Incorrect partial script.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateFactor(
				MockTasks.Object, vPrimArtId, vEdgeArtId, vAssertId, vIsDefining, vNote);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.AreEqual(vResultFactor, vResult, "Incorrect Result.");

			MockValidator.Verify(x => x.ArtifactId(vPrimArtId, CreateFactor.PrimArtParam),Times.Once());
			MockValidator.Verify(x => x.ArtifactId(vEdgeArtId, CreateFactor.EdgeArtParam), Times.Once());
			MockValidator.Verify(x => x.FactorFactorAssertionId(
				vAssertId, CreateFactor.AssertParam), Times.Once());
			MockValidator.Verify(x => x.FactorNote(vNote, CreateFactor.NoteParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryEqualsRelated() {
			vEdgeArtId = vPrimArtId;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryArtifactNotFound() {
			MockDataList[0].MockResult.SetupToElement((Artifact)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRelatedArtifactNotFound() {
			MockDataList[1].MockResult.SetupToElement((Artifact)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			SetUpMember(1, 2);
			TestUtil.CheckThrows<FabMembershipFault>(true, TestGo);
		}

	}

}