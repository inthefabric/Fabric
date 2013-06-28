using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

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

			vOutInstanceVar = TestUtil.GetTxVar<Instance>("INST");
			vResultInstance = new Instance();

			MockTasks
				.Setup(x => x.TxAddInstance(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vDisamb,
						vNote,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out vOutInstanceVar
					)
				);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			SetUpMember(1, 2, new Member { MemberId = 234623 });

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vResultInstance);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			const string expectPartial = 
				"_V0=g.V('"+PropDbName.Member_MemberId+"',_TP0).next();"+
				"INST;";

			Assert.AreEqual(expectPartial, cmd.Script, "Incorrect partial script.");
			TestUtil.CheckParam(cmd.Params, "_TP0", ApiCtxMember.MemberId);
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
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDisambWithoutName() {
			vName = null;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			SetUpMember(1, 2, null);
			TestUtil.CheckThrows<FabMembershipFault>(true, TestGo);
		}

	}

}