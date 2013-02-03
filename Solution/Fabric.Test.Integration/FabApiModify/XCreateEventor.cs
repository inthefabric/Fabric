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
	public class XCreateEventor : XCreateFactorElement {

		private long vEveTypeId;
		private long vEvePrecId;
		private long vDateTime;
		
		private Eventor vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vEveTypeId = (long)EventorTypeId.Continue;
			vEvePrecId = (long)EventorPrecisionId.Second;
			vDateTime = 925923592753292;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new CreateEventor(Tasks, FactorId, vEveTypeId, vEvePrecId, vDateTime);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewEventor() {
			IsReadOnlyTest = false;

			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Eventor newEventor = GetNode<Eventor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newEventor, "New Eventor was not created.");
			Assert.AreEqual(newEventor.EventorId, vResult.EventorId,
				"Incorrect Result.EventorId.");

			NodeConnections conn = GetNodeConnections(newEventor);
			conn.AssertRelCount(2, 2);
			conn.AssertRel<RootContainsEventor, Root>(false, 0);
			conn.AssertRel<FactorUsesEventor, Factor>(false, FactorId);
			conn.AssertRel<EventorUsesEventorType, EventorType>(true, vEveTypeId);
			conn.AssertRel<EventorUsesEventorPrecision, EventorPrecision>(true, vEvePrecId);

			NewNodeCount = 1;
			NewRelCount = 4;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ExistingEventor() {
			IsReadOnlyTest = false;

			vEveTypeId = (long)EventorTypeId.Occur;
			vEvePrecId = (long)EventorPrecisionId.Year;
			vDateTime = 631769760000000000;
			long expectEventorId = (long)SetupFactors.EventorId.Occur_Year_2003;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");

			////

			Eventor newEventor = GetNode<Eventor>(expectEventorId);
			NodeConnections conn = GetNodeConnections(newEventor);
			conn.AssertRel<FactorUsesEventor, Factor>(false, FactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumEventorTypes+1)]
		public void ErrEventorTypeRange(int pId) {
			vEveTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumEventorPrecisions+1)]
		public void ErrEventorPrecisionRange(int pId) {
			vEvePrecId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}