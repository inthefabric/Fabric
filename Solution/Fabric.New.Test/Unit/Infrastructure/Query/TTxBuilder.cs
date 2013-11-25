using System;
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
	public class TTxBuilder {

		private static readonly Logger Log = Logger.Build<TTxBuilder>();


		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var txb = new TxBuilder();
			Assert.NotNull(txb.Transaction, "TxBuilder.Transaction should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void Finish(bool pWithVar) {
			var txb = new TxBuilder();
			Assert.Null(txb.Transaction.Script, "Script should be empty before Finish().");

			if ( pWithVar ) {
				var v = new WeaverVarAlias("test");
				txb.RegisterVarWithTxBuilder(v);
				txb.Finish(v);
			}
			else {
				txb.Finish();
			}

			Assert.NotNull("", txb.Transaction.Script, "Script should be filled after Finish().");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FinishUnregisteredVar() {
			var txb = new TxBuilder();
			var v = new WeaverVarAlias("test");
			TestUtil.Throws<Exception>(() => txb.Finish(v));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void GetVertex(bool pById) {
			const long id = 123456;
			const string expectScript = "_V0=g.V('"+DbName.Vert.Vertex.VertexId+"',_P0).next();";
			IWeaverVarAlias<App> alias;

			var txb = new TxBuilder();

			if ( pById ) {
				txb.GetVertex(id, out alias);
			}
			else {
				var app = new App();
				app.VertexId = id;
				txb.GetVertex(app, out alias);
			}

			IWeaverQuery q = GetFirstQuery(txb);
			TestUtil.LogWeaverScript(Log, q);
			Assert.AreEqual(expectScript, q.Script, "Incorrect script.");
			TestUtil.CheckParams(q.Params, "_P", new List<object>(new object[] { id }));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("Z")]
		public void GetVertexByDatabaseId(string pVarName) {
			const string id = "this-is-an-id";
			string expectVarName = (pVarName ?? "_V0");
			string expectScript = expectVarName+"=g.v(_P0);";
			IWeaverVarAlias<App> alias;

			var app = new App();
			app.Id = id;

			var txb = new TxBuilder();
			txb.GetVertexByDatabaseId(app, out alias, pVarName);

			IWeaverQuery q = GetFirstQuery(txb);
			TestUtil.LogWeaverScript(Log, q);
			Assert.AreEqual(expectScript, q.Script, "Incorrect script.");
			TestUtil.CheckParams(q.Params, "_P", new List<object>(new object[] { id }));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddVertex() {
			var vert = new Vertex();
			vert.VertexId = 9876;
			vert.VertexType = 7;
			vert.Timestamp = 102030405060;

			IWeaverVarAlias<Vertex> alias;

			const string expectScript = 
				"_V0=g.addVertex(["+
					DbName.Vert.Vertex.VertexId+":_P0,"+
					DbName.Vert.Vertex.Timestamp+":_P1,"+
					DbName.Vert.Vertex.VertexType+":_P2"+
				"]);";

			var txb = new TxBuilder();
			txb.AddVertex(vert, out alias);
			txb.Finish(alias); //ensure that the alias becomes registered

			IWeaverQuery q = GetFirstQuery(txb);
			TestUtil.LogWeaverScript(Log, q);
			Assert.AreEqual(expectScript, q.Script, "Incorrect script.");
			TestUtil.CheckParams(q.Params, "_P", new List<object>(
				new object[] { vert.VertexId, vert.Timestamp, vert.VertexType }));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddEdge() {
			var edge = new ArtifactCreatedByMember();
			var artAlias = new WeaverVarAlias<Artifact>("art");
			var memAlias = new WeaverVarAlias<Member>("mem");

			const string expectScript = 
				"g.addEdge(art,mem,_P0);";

			var txb = new TxBuilder();
			txb.RegisterVarWithTxBuilder(artAlias);
			txb.RegisterVarWithTxBuilder(memAlias);
			txb.AddEdge(artAlias, edge, memAlias);

			IWeaverQuery q = GetFirstQuery(txb);
			TestUtil.LogWeaverScript(Log, q);
			Assert.AreEqual(expectScript, q.Script, "Incorrect script.");
			TestUtil.CheckParams(q.Params, "_P", new List<object>(
				new object[] { DbName.Edge.ArtifactCreatedByMemberName }));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void AddEdgeUnregisteredVar(bool pFirst) {
			var edge = new ArtifactCreatedByMember();
			var artAlias = new WeaverVarAlias<Artifact>("art");
			var memAlias = new WeaverVarAlias<Member>("mem");

			var txb = new TxBuilder();

			if ( pFirst ) {
				txb.RegisterVarWithTxBuilder(artAlias);
			}
			else {
				txb.RegisterVarWithTxBuilder(memAlias);
			}

			TestUtil.Throws<Exception>(() => txb.AddEdge(artAlias, edge, memAlias));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private IWeaverQuery GetFirstQuery(TxBuilder pTxBuild, int pExpectCount=1) {
			Assert.NotNull(pTxBuild.Transaction, "Transaction should be filled.");
			Assert.NotNull(pTxBuild.Transaction.Queries, "Transaction.Queries should be filled.");
			Assert.AreEqual(pExpectCount, pTxBuild.Transaction.Queries.Count,
				"Incorrect Transaction.Queries count.");

			return pTxBuild.Transaction.Queries[0];
		}

	}

}