using System;
using Fabric.Api.Objects;
using Fabric.Operations.Traversal.Routing;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepParam {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			const int paramIndex = 1234;
			const string name = "My Name";
			Type dataType = typeof(FabClass);

			var p = new TravStepParam(paramIndex, name, dataType);

			Assert.AreEqual(paramIndex, p.ParamIndex, "Incorrect ParamIndex.");
			Assert.AreEqual(name, p.Name, "Incorrect Name.");
			Assert.AreEqual(dataType, p.DataType, "Incorrect DataType.");
			Assert.False(p.IsGenericDataType, "Incorrect IsGenericDataType.");
			Assert.Null(p.Min, "Min should be null.");
			Assert.Null(p.Max, "Max should be null.");
			Assert.Null(p.LenMax, "LenMax should be null.");
			Assert.Null(p.ValidRegex, "ValidRegex should be null.");
			Assert.Null(p.AcceptedStrings, "AcceptedStrings should be null.");
		}

	}

}