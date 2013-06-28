using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachDescriptor : TAttachFactorElement {

		private byte vDescTypeId;
		private long? vPrimArtRefId;
		private long? vEdgeArtRefId;
		private long? vDescTypeRefId;

		private bool vResult;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vDescTypeId = 9;
			vPrimArtRefId = 935823;
			vEdgeArtRefId = 25323;
			vDescTypeRefId = 5439225;

			var mda = MockDataAccess.Create(m => {});
			mda.MockResult.SetupToElement(new Artifact());
			MockDataList.Add(mda);

			mda = MockDataAccess.Create(m => {});
			mda.MockResult.SetupToElement(new Artifact());
			MockDataList.Add(mda);

			mda = MockDataAccess.Create(m => {});
			mda.MockResult.SetupToElement(new Artifact());
			MockDataList.Add(mda);

			MockTasks
				.Setup(x => x.UpdateFactorDescriptor(
					MockApiCtx.Object,
					ActiveFactor,
					vDescTypeId,
					vPrimArtRefId,
					vEdgeArtRefId,
					vDescTypeRefId
				)
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachDescriptor(MockTasks.Object, FactorId, vDescTypeId,
				vPrimArtRefId, vEdgeArtRefId, vDescTypeRefId);
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

			if ( vEdgeArtRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vEdgeArtRefId,
					AttachDescriptor.EdgeArtRefParam), Times.Once());
			}

			if ( vDescTypeRefId != null ) {
				MockValidator.Verify(x => x.ArtifactId((long)vDescTypeRefId,
					AttachDescriptor.DescTypeRefParam), Times.Once());
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("P", 0)]
		[TestCase("R", 1)]
		[TestCase("T", 2)]
		public void ErrPrimRefArtNotFound(string pType, int pIndex) {
			const long refId = 999;

			switch ( pType ) {
				case "P": vPrimArtRefId = refId; break;
				case "R": vEdgeArtRefId = refId; break;
				case "T": vDescTypeRefId = refId; break;
			}

			MockDataList[pIndex].MockResult.SetupToElement((Artifact)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}