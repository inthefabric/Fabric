using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TElasticIndexContainsFunc {

		// ElasticIndexContainsFunc is abstract, and the subclasses are all generated. These tests use
		// the ApNaElasticIndexFunc subclass as a representative case for all of the others.


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var f = new ApNaElasticIndexFunc(p.Object);

			Assert.AreEqual(p.Object, f.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabApp), f.DtoType, "Incorrect DtoType.");
			Assert.Null(f.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(f, "query()"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test", new [] { "test" })]
		[TestCase("TEST abcd", new [] { "TEST", "abcd" })]
		[TestCase("test   123 456", new [] { "test", "123", "456" })]
		[TestCase("test-123-456", new [] { "test", "123", "456" })]
		[TestCase("test   123-456", new [] { "test", "123", "456" })]
		public void SetDataAndUpdatePath(string pValue, string[] pExpectTokens) {
			const string propName = PropDbName.App_Name;
			int paramI = 0;
			var scripts = new List<string>();

			var p = new Mock<IPath>();
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == propName)))
				.Returns("_P"+(paramI++));

			foreach ( string token in pExpectTokens ) {
				string t = token;
				string par = "_P"+(paramI++);

				p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == t))).Returns(par);
				scripts.Add("has(_P0,"+ElasticIndexFunc.TextNamespace+"CONTAINS,"+par+")");
			}
			
			var f = new ApNaElasticIndexFunc(p.Object);
			var sd = new StepData("AppNameContains("+pValue+")");

			////

			f.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(typeof(AppStep), f.ProxyStep.GetType(), "Incorrect ProxyStep type.");

			foreach ( string script in scripts ) {
				string s = script;
				p.Verify(x => x.AddSegment(f, s), Times.Once());
			}
			
			p.Verify(x => x.AddSegment(f, "vertices()"), Times.Once());
			p.Verify(x => x.AddSegment(f, "_()"), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("()")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = new ApNaElasticIndexFunc(p.Object);
			var sd = new StepData("AppNameContains"+pParams);

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

	}

}