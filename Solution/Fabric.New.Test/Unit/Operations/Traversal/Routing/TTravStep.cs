using System;
using System.Collections.Generic;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	public abstract class TTravStep {

		protected Mock<ITravPathItem> MockItem { get; private set; }
		protected List<ITravPathItem> Items { get; private set; }
		protected Mock<ITravPath> MockPath { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			MockItem = new Mock<ITravPathItem>(MockBehavior.Strict);

			Items = new List<ITravPathItem>();
			Items.Add(MockItem.Object);

			MockPath = new Mock<ITravPath>(MockBehavior.Strict);
			MockPath.Setup(x => x.ConsumeSteps(1, GetToType())).Returns(Items);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract ITravStep GetStep();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Type GetToType();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void CheckSuccess(bool pSuccess);

		/*--------------------------------------------------------------------------------------------*/
		protected void SetupFault(FabStepFault pFault, string pMessageContains) {
			MockItem
				.Setup(x => x.NewStepFault(pFault.ErrCode, It.IsAny<string>(), pFault.ParamIndex, null))
				.Callback((FabFault.Code c, string m, int pi, Exception e) =>
					TestUtil.AssertContains("Fault.Message", m, pMessageContains))
				.Returns(pFault);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void CheckConsumePathThrows(FabStepFault pFault) {
			FabStepFault faultResult = TestUtil.Throws<FabStepFault>(
				() => GetStep().ConsumePath(MockPath.Object, GetToType()));
			Assert.AreEqual(pFault, faultResult, "Incorrect fault result.");
			CheckSuccess(false);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			GetStep().ConsumePath(MockPath.Object, GetToType());
			CheckSuccess(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CorrectParams() {
			IList<ITravStepParam> par = GetStep().Params;

			for ( int i = 0 ; i < par.Count ; ++i ) {
				Assert.NotNull(par, "Param should not be null @ "+i+".");
				Assert.AreEqual(i, par[i].ParamIndex, "Incorrect result @ "+i+".");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcceptsType() {
			MockPath.Setup(x => x.IsAcceptableType(It.IsAny<Type>(), It.IsAny<bool>())).Returns(true);
			MockPath.Setup(x => x.GetSteps(1)).Returns(Items);
			MockItem.SetupGet(x => x.Command).Returns(GetStep().CommandLow);

			bool result = GetStep().AcceptsPath(MockPath.Object);
			Assert.True(result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcceptsTypeWrongType() {
			MockPath
				.Setup(x => x.IsAcceptableType(It.IsAny<Type>(), It.IsAny<bool>()))
				.Returns(false);

			bool result = GetStep().AcceptsPath(MockPath.Object);
			Assert.False(result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcceptsTypeWrongCommand() {
			MockPath.Setup(x => x.IsAcceptableType(It.IsAny<Type>(), It.IsAny<bool>())).Returns(true);
			MockPath.Setup(x => x.GetSteps(1)).Returns(Items);
			MockItem.SetupGet(x => x.Command).Returns("not-a-match");

			bool result = GetStep().AcceptsPath(MockPath.Object);
			Assert.False(result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AcceptsTypeNullStep() {
			MockPath.Setup(x => x.IsAcceptableType(It.IsAny<Type>(), It.IsAny<bool>())).Returns(true);
			MockPath.Setup(x => x.GetSteps(1)).Returns((IList<ITravPathItem>)null);

			bool result = GetStep().AcceptsPath(MockPath.Object);
			Assert.False(result, "Incorrect result.");
		}

	}

}