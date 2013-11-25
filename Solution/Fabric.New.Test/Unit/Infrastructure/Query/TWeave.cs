using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Test.Shared;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Infrastructure.Query {

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
			TestUtil.CheckParams(q.Params, "_P", new List<object>(new object[] { app.VertexId }));
		}

	}

}