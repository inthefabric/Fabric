using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XAttachDirector : XCreateFactorElement {

		private byte vDirTypeId;
		private byte vPrimActId;
		private byte vRelActId;
		
		private bool vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vDirTypeId = (byte)DirectorTypeId.DefinedPath;
			vPrimActId = (byte)DirectorActionId.Locate;
			vRelActId = (byte)DirectorActionId.Obtain;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new AttachDirector(Tasks, FactorId, vDirTypeId, vPrimActId, vRelActId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewDirector() {
			IsReadOnlyTest = false;

			TestGo();
			
			Assert.True(vResult, "Incorrect Result.");
			
			Factor updatedFactor = GetNode<Factor>(FactorId);
			Assert.NotNull(updatedFactor, "Updated Factor was deleted.");
			Assert.AreEqual(vDirTypeId, updatedFactor.Director_TypeId, "Incorrect Director_TypeId.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrDirectorTypeRange(byte pId) {
			vDirTypeId = pId;

			if ( pId == 1 ) {
				vDirTypeId = (byte)(StaticTypes.DirectorTypes.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrPrimaryDirectorActionRange(byte pId) {
			vDirTypeId = pId;

			if ( pId == 1 ) {
				vDirTypeId = (byte)(StaticTypes.DirectorActions.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrRelatedDirectorActionRange(byte pId) {
			vDirTypeId = pId;

			if ( pId == 1 ) {
				vDirTypeId = (byte)(StaticTypes.DirectorActions.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}