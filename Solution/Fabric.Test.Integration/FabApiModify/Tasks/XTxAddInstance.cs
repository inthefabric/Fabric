﻿using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddInstance : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Instance Name", "Instance Disambiguation", "Instance Note")]
		public void Success(string pName, string pDisamb, string pNote) {
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Instance> urlVar;
			var mem = new Member { MemberId = (long)SetupUsers.MemberId.GalZach };

			TxBuild.GetNode(mem, out memVar);
			Tasks.TxAddInstance(ApiCtx, TxBuild, pName, pDisamb, pNote, memVar, out urlVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddInstance", TxBuild.Transaction);

			////

			Instance newInstance = GetNode<Instance>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newInstance, "New Instance was not created.");
			Assert.AreNotEqual(0, newInstance.ArtifactId, "Incorrect InstanceId.");
			Assert.AreEqual(pName, newInstance.Name, "Incorrect Name.");
			Assert.AreEqual(pDisamb, newInstance.Disamb, "Incorrect Disamb.");
			Assert.AreEqual(pNote, newInstance.Note, "Incorrect Note.");

			NodeConnections conn = GetNodeConnections(newInstance);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}