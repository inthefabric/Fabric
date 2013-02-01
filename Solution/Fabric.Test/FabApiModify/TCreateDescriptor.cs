using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateDescriptor : TCreateFactorElement<Descriptor> {

		private long vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;

		private IWeaverVarAlias<Descriptor> vOutDescriptorVar;
		private Descriptor vResultDescriptor;
		private Descriptor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vDescTypeId = 9;
			vPrimArtRefId = 935823;
			vRelArtRefId = 25323;
			vDescTypeRefId = 5439225;

			vOutDescriptorVar = GetTxVar<Descriptor>("DESC");

			MockTasks
				.Setup(x => x.GetArtifact(MockApiCtx.Object, (long)vPrimArtRefId))
				.Returns(new Artifact());

			MockTasks
				.Setup(x => x.GetArtifact(MockApiCtx.Object, (long)vRelArtRefId))
				.Returns(new Artifact());

			MockTasks
				.Setup(x => x.GetArtifact(MockApiCtx.Object, (long)vDescTypeRefId))
				.Returns(new Artifact());

			MockTasks
				.Setup(x => x.TxAddDescriptor(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vDescTypeId,
						vPrimArtRefId,
						vRelArtRefId,
						vDescTypeRefId,
						ActiveFactor,
						out vOutDescriptorVar
					)
				);

			vResultDescriptor = new Descriptor();

			MockApiCtx
				.Setup(x => x.DbSingle<Descriptor>("CreateDescriptorTx",
					It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateDescriptorTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Descriptor CreateDescriptorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "DESC;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultDescriptor;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupFactorHasElement(bool pResult) {
			MockTasks
				.Setup(x => x.FactorHasDescriptor(MockApiCtx.Object, ActiveFactor))
				.Returns(pResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new CreateDescriptor(MockTasks.Object, FactorId, vDescTypeId,
				vPrimArtRefId, vRelArtRefId, vDescTypeRefId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewDescriptor() {
			TestGo();
			Assert.AreEqual(vResultDescriptor, vResult, "Incorrect Result.");
			CheckValidation();
		}


		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingDescriptor() {
			var existing = new Descriptor();

			MockTasks
				.Setup(x => x.GetDescriptorMatch(
						MockApiCtx.Object,
						vDescTypeId,
						vPrimArtRefId,
						vRelArtRefId,
						vDescTypeRefId
					)
				)
				.Returns(existing);

			TestGo();

			Assert.AreEqual(existing, vResult, "Incorrect Result.");
			CheckValidation();

			MockTasks
				.Verify(x => x.AttachExistingElement<Descriptor, FactorUsesDescriptor>(
						MockApiCtx.Object,
						ActiveFactor,
						existing
					),
					Times.Once()
				);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.DescriptorTypeId(vDescTypeId,
				CreateDescriptor.DescTypeParam), Times.Once());

			if ( vPrimArtRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vPrimArtRefId,
					CreateDescriptor.PrimArtRefParam), Times.Once());
			}

			if ( vRelArtRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vRelArtRefId,
					CreateDescriptor.RelArtRefParam), Times.Once());
			}

			if ( vDescTypeRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vDescTypeRefId,
					CreateDescriptor.DescTypeRefParam), Times.Once());
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("P")]
		[TestCase("R")]
		[TestCase("T")]
		public void ErrPrimRefArtNotFound(string pType) {
			const long refId = 999;

			switch ( pType ) {
				case "P": vPrimArtRefId = refId; break;
				case "R": vRelArtRefId = refId; break;
				case "T": vDescTypeRefId = refId; break;
			}

			MockTasks
				.Setup(x => x.GetArtifact(MockApiCtx.Object, refId))
				.Returns((Artifact)null);

			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}