using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateDirector : XCreateFactorElement {

		private long vDirTypeId;
		private long vPrimActId;
		private long vRelActId;
		
		private Director vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vDirTypeId = (long)DirectorTypeId.DefinedPath;
			vPrimActId = (long)DirectorActionId.Locate;
			vRelActId = (long)DirectorActionId.Obtain;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new CreateDirector(Tasks, FactorId, vDirTypeId, vPrimActId, vRelActId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewDirector() {
			IsReadOnlyTest = false;

			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Director newDirector = GetNode<Director>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDirector, "New Director was not created.");
			Assert.AreEqual(newDirector.DirectorId, vResult.DirectorId,
				"Incorrect Result.DirectorId.");

			NodeConnections conn = GetNodeConnections(newDirector);
			conn.AssertRelCount(2, 3);
			conn.AssertRel<RootContainsDirector, Root>(false, 0);
			conn.AssertRel<FactorUsesDirector, Factor>(false, FactorId);
			conn.AssertRel<DirectorUsesDirectorType, DirectorType>(true, vDirTypeId);
			conn.AssertRel<DirectorUsesPrimaryDirectorAction, DirectorAction>(true, vPrimActId);
			conn.AssertRel<DirectorUsesRelatedDirectorAction, DirectorAction>(true, vRelActId);

			NewNodeCount = 1;
			NewRelCount = 5;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingDirector() {
			IsReadOnlyTest = false;

			vDirTypeId = (long)DirectorTypeId.SuggestPath;
			vPrimActId = (long)DirectorActionId.View;
			vRelActId = (long)DirectorActionId.Learn;
			const long expectDirectorId = (long)SetupFactors.DirectorId.View_Sugg_Learn;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");

			////

			Director newDirector = GetNode<Director>(expectDirectorId);
			NodeConnections conn = GetNodeConnections(newDirector);
			conn.AssertRel<FactorUsesDirector, Factor>(false, FactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumDirectorTypes+1)]
		public void ErrDirectorTypeRange(int pId) {
			vDirTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumDirectorActions+1)]
		public void ErrPrimaryDirectorActionRange(int pId) {
			vDirTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumDirectorActions+1)]
		public void ErrRelatedDirectorActionRange(int pId) {
			vDirTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}