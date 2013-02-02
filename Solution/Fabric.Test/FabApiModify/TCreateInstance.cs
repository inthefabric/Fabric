﻿using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateInstance : TBaseModifyFunc {

		private string vName;
		private string vDisamb;
		private string vNote;

		private IWeaverVarAlias<Instance> vOutInstanceVar;
		private Instance vResultInstance;
		private Instance vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "Instance Name";
			vDisamb = "Disamb Text";
			vNote = "This is a note.";

			vOutInstanceVar = GetTxVar<Instance>("INST");
			vResultInstance = new Instance();

			MockTasks
				.Setup(x => x.TxAddInstance(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vDisamb,
						vNote,
						It.IsAny<IWeaverVarAlias<Root>>(),
						out vOutInstanceVar
					)
				);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			MockApiCtx
				.Setup(x => x.DbSingle<Instance>("CreateInstanceTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateInstanceTx(q));

			SetUpMember(1, 2, new Member { MemberId = 234623 });
		}

		/*--------------------------------------------------------------------------------------------*/
		private Instance CreateInstanceTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			string expectPartial = 
				"g.V('RootId',0)[0].each{_V0=g.v(it)};"+
				"g.V('MemberId',"+ApiCtxMember.MemberId+"L)[0].each{_V1=g.v(it)};"+
				"INST;";

			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultInstance;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateInstance(MockTasks.Object, vName, vDisamb, vNote);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.AreEqual(vResultInstance, vResult, "Incorrect Result.");

			MockValidator.Verify(x => x.InstanceName(vName, CreateInstance.NameParam), Times.Once());
			MockValidator.Verify(x => x.InstanceDisamb(vDisamb, CreateInstance.DisambParam), Times.Once());
			MockValidator.Verify(x => x.InstanceNote(vNote, CreateInstance.NoteParam), Times.Once());

			IWeaverVarAlias<Artifact> artVar;

			MockTasks
				.Verify(x => x.TxAddArtifact<Instance, InstanceHasArtifact>(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						ArtifactTypeId.Instance,
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutInstanceVar,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out artVar
					),
					Times.Once()
				);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDisambWithoutName() {
			vName = null;
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			SetUpMember(1, 2, null);
			TestUtil.CheckThrows<FabMembershipFault>(true, TestGo);
		}

	}

}