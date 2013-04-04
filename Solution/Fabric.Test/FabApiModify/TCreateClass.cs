using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

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
			vOutClassVar = GetTxVar<Class>("CLASS");

			vResultClass = new Class();
			vResultClass.ClassId = 84761294623;
			vResultClass.Name = vName;
			vResultClass.Disamb = vDisamb;

			MockTasks
				.Setup(x => x.TxAddClass(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vDisamb,
						vNote,
						It.IsAny<IWeaverVarAlias<Root>>(),
						It.IsAny<IWeaverVarAlias<Member>>(),
						out vOutClassVar
					)
				);
				
			MockTasks
				.Setup(x => x.GetValidMemberByContext(MockApiCtx.Object))
				.Returns(vResultMember);

			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			MockApiCtx
				.Setup(x => x.DbSingle<Class>("CreateClassTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateClassTx(q));

			SetUpMember(1, 2, vResultMember);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class CreateClassTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			string expectPartial = 
				"g.V('"+typeof(Root).Name+"Id',_TP0)[0].each{_V0=g.v(it)};"+
				"_V1=g.v(_TP1);"+
				"CLASS;";

			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", 0);
			TestUtil.CheckParam(pTx.Params, "_TP1", vResultMember.Id);
			return vResultClass;
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

			MockValidator.Verify(x => x.ClassName(vName, CreateClass.NameParam), Times.Once());
			MockValidator.Verify(x => x.ClassDisamb(vDisamb, CreateClass.DisambParam), Times.Once());
			MockValidator.Verify(x => x.ClassNote(vNote, CreateClass.NoteParam), Times.Once());
			MockClassCache.Verify(x => x.AddClass(vResultClass.ClassId, vName, vDisamb), Times.Once());
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