﻿using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	public abstract class TWebTasks {

		protected IWebTasks Tasks { get; private set; }
		protected Mock<IApiContext> MockApiCtx { get; private set; }
		protected UsageMap UsageMap { get; private set; }
		protected TxBuilder TxBuild { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			Tasks = new WebTasks();
			UsageMap = new UsageMap();
			MockApiCtx = new Mock<IApiContext>();
			TxBuild = new TxBuilder();

			TestSetUp();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestSetUp();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void FinishTx() {
			TxBuild.Finish();
			TestUtil.LogWeaverScript(TxBuild.Transaction);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<T> GetTxVar<T>(string pName) where T : INode {
			IWeaverVarAlias v;
			TxBuild.Transaction.AddQuery(WeaverQuery.InitListVar(pName, out v));

			var tv = new Mock<IWeaverVarAlias<T>>();
			tv.SetupGet(x => x.Name).Returns(v.Name);
			tv.SetupGet(x => x.VarType).Returns(typeof(T));
			TxBuild.RegisterVarWithTxBuilder(tv.Object);
			return tv.Object;
		}

	}

}