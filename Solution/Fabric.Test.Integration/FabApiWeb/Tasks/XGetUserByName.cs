﻿using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUserByName : XWebTasks {

		private string vName;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			UsesElasticSearch = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return Tasks.GetUserByName(ApiCtx, vName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("ZachKinstner")]
		[TestCase("MELkins")]
		public void Found(string pName) {
			vName = pName;

			User result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vName.ToLower(), result.Name.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("zachkinstnerr")]
		[TestCase("melkin")]
		public void NotFound(string pName) {
			vName = pName;

			User result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}