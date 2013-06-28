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
	public class TCreateClass : TBaseModifyFunc {

		private string vName;
		private string vDisamb;
		private string vNote;
		
		private Member vResultMember;
		private IWeaverVarAlias<Class> vOutClassVar;
		private Class vResultClass;
		private Class vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "Class Name";
			vDisamb = "Disamb Text";
			vNote = "This is a note.";
			
			vResultMember = new Member { Id = "x87123523" };
			vOutClassVar = TestUtil.GetTxVar<Class>("CLASS");

			vResultClass = new Class();
			vResultClass.ArtifactId = 84761294623;
			vResultClass.Name = vName;
			vResultClass.Disamb = vDisamb;

			MockTasks
				.Setup(x => x.TxAddClass(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vDisamb,
						vNote,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out vOutClassVar
					)
				);
				
			MockTasks
				.Setup(x => x.GetValidMemberByContext(MockApiCtx.Object))
				.Returns(vResultMember);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			SetUpMember(1, 2, vResultMember);

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vResultClass);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			const string expectPartial = 
				"_V0=g.v(_TP0);"+
				"CLASS;";

			Assert.AreEqual(expectPartial, cmd.Script, "Incorrect partial script.");
			TestUtil.CheckParam(cmd.Params, "_TP0", vResultMember.Id);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateClass(MockTasks.Object, vName, vDisamb, vNote);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.AreEqual(vResultClass, vResult, "Incorrect Result.");

			AssertDataExecution(true);
			MockValidator.Verify(x => x.ClassName(vName, CreateClass.NameParam), Times.Once());
			MockValidator.Verify(x => x.ClassDisamb(vDisamb, CreateClass.DisambParam), Times.Once());
			MockValidator.Verify(x => x.ClassNote(vNote, CreateClass.NoteParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateClass() {
			MockTasks
				.Setup(x => x.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb))
				.Returns(new Class());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMemberNotFound() {
			SetUpMember(1, 2, null);
			TestUtil.CheckThrows<FabMembershipFault>(true, TestGo);
		}

	}

}