using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;
using System;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateLocator : XCreateFactorElement {

		private long vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;
		
		private Locator vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vLocTypeId = (long)LocatorTypeId.EarthCoord;
			vValueX = 12.3456;
			vValueY = -88.8754;
			vValueZ = 22.2234;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new CreateLocator(Tasks, FactorId, vLocTypeId, vValueX, vValueY, vValueZ);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewLocator() {
			IsReadOnlyTest = false;

			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Locator newLocator = GetNode<Locator>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newLocator, "New Locator was not created.");
			Assert.AreEqual(newLocator.LocatorId, vResult.LocatorId,
				"Incorrect Result.LocatorId.");

			NodeConnections conn = GetNodeConnections(newLocator);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<RootContainsLocator, Root>(false, 0);
			conn.AssertRel<FactorUsesLocator, Factor>(false, FactorId);
			conn.AssertRel<LocatorUsesLocatorType, LocatorType>(true, vLocTypeId);

			NewNodeCount = 1;
			NewRelCount = 3;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ExistingLocator() {
			IsReadOnlyTest = false;

			vLocTypeId = (long)LocatorTypeId.RelPos2D;
			vValueX = 0.5;
			vValueY = 0.333;
			vValueZ = 0;
			long expectLocatorId = (long)SetupFactors.LocatorId.ElliePos2D;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");

			////

			Locator newLocator = GetNode<Locator>(expectLocatorId);
			NodeConnections conn = GetNodeConnections(newLocator);
			conn.AssertRel<FactorUsesLocator, Factor>(false, FactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumLocatorTypes+1)]
		public void ErrLocatorTypeRange(int pId) {
			vLocTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}