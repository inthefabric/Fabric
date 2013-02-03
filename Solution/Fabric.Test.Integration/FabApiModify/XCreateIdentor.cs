﻿using Fabric.Api.Modify;
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
	public class XCreateIdentor : XCreateFactorElement {

		private long vIdenTypeId;
		private string vValue;
		
		private Identor vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vIdenTypeId = (long)IdentorTypeId.Text;
			vValue = "my unique value";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new CreateIdentor(Tasks, FactorId, vIdenTypeId, vValue);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewIdentor() {
			IsReadOnlyTest = false;

			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Identor newIdentor = GetNode<Identor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newIdentor, "New Identor was not created.");
			Assert.AreEqual(newIdentor.IdentorId, vResult.IdentorId,
				"Incorrect Result.IdentorId.");

			NodeConnections conn = GetNodeConnections(newIdentor);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<RootContainsIdentor, Root>(false, 0);
			conn.AssertRel<FactorUsesIdentor, Factor>(false, FactorId);
			conn.AssertRel<IdentorUsesIdentorType, IdentorType>(true, vIdenTypeId);

			NewNodeCount = 1;
			NewRelCount = 3;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ExistingIdentor() {
			IsReadOnlyTest = false;

			vIdenTypeId = (long)IdentorTypeId.Key;
			vValue = "4165";
			long expectIdentorId = (long)SetupFactors.IdentorId.Key_4165;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");

			////

			Identor newIdentor = GetNode<Identor>(expectIdentorId);
			NodeConnections conn = GetNodeConnections(newIdentor);
			conn.AssertRel<FactorUsesIdentor, Factor>(false, FactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumIdentorTypes+1)]
		public void ErrIdentorTypeRange(int pId) {
			vIdenTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrValueNull() {
			vValue = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(129)]
		public void ErrValueLength(int pLength) {
			vValue = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

	}

}