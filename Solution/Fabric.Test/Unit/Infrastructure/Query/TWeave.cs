using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Query;
using Fabric.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Infrastructure.Query {

	/*================================================================================================*/
	[TestFixture]
	public class TWeave {

		private static readonly Logger Log = Logger.Build<TWeave>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExactIndex() {
			var app = new App();
			app.VertexId = 2364234;

			const string expectScript = "g.V('"+DbName.Vert.Vertex.VertexId+"',_P0);";

			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(app).ToQuery();

			TestUtil.LogWeaverScript(Log, q);
			Assert.AreEqual(expectScript, q.Script, "Incorrect script.");
			TestUtil.CheckParams(q.Params, "_P", new List<object>{ app.VertexId });
		}

	}

}