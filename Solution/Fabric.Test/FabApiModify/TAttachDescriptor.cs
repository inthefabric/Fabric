using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachDescriptor : TAttachFactorElement {

		private byte vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;

		private bool vResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vDescTypeId = 9;
			vPrimArtRefId = 935823;
			vRelArtRefId = 25323;
			vDescTypeRefId = 5439225;

			MockApiCtx
				.Setup(x => x.DbVertexById<Artifact>((long)vPrimArtRefId))
				.Returns(new Artifact());

			MockApiCtx
				.Setup(x => x.DbVertexById<Artifact>((long)vRelArtRefId))
				.Returns(new Artifact());

			MockApiCtx
				.Setup(x => x.DbVertexById<Artifact>((long)vDescTypeRefId))
				.Returns(new Artifact());

			MockTasks
				.Setup(x => x.UpdateFactorDescriptor(
					MockApiCtx.Object,
					ActiveFactor,
					vDescTypeId,
					vPrimArtRefId,
					vRelArtRefId,
					vDescTypeRefId
				));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachDescriptor(MockTasks.Object, FactorId, vDescTypeId,
				vPrimArtRefId, vRelArtRefId, vDescTypeRefId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewDescriptor() {
			TestGo();
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorDescriptor_TypeId(vDescTypeId,
				AttachDescriptor.DescTypeParam), Times.Once());

			if ( vPrimArtRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vPrimArtRefId,
					AttachDescriptor.PrimArtRefParam), Times.Once());
			}

			if ( vRelArtRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vRelArtRefId,
					AttachDescriptor.RelArtRefParam), Times.Once());
			}

			if ( vDescTypeRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vDescTypeRefId,
					AttachDescriptor.DescTypeRefParam), Times.Once());
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

			MockApiCtx.Setup(x => x.DbVertexById<Artifact>(refId)).Returns((Artifact)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}