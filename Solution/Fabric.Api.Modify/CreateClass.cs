using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateClass : BaseModifyFunc<Class> { //TEST: CreateClass

		public const string NameParam = "Name";
		public const string DisabmParam = "Disamb";
		public const string NoteParam = "Note";

		private readonly string vName;
		private readonly string vDisamb;
		private readonly string vNote;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateClass(IModifyTasks pTasks, string pName, string pDisamb, string pNote) : 
																						base(pTasks) {
			vName = pName;
			vDisamb = pDisamb;
			vNote = pNote;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.ClassName(vName, NameParam);
			Tasks.Validator.ClassDisamb(vDisamb, DisabmParam);
			Tasks.Validator.ClassNote(vNote, NoteParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Class Execute() {
			if ( Tasks.GetClassByNameDisamb(ApiCtx, vName, vDisamb) != null ) {
				string name = vName+(vDisamb == null ? "" : " ("+vDisamb+")");
				throw new FabDuplicateFault(typeof(Class), NameParam, name);
			}

			Member m = GetContextMember();

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Class> classVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Artifact> artVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			txb.GetNode(m, out memVar);
			Tasks.TxAddClass(ApiCtx, txb, vName, vDisamb, vNote, rootVar, out classVar);
			Tasks.TxAddArtifact<Class, ClassHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.Class, rootVar, classVar, memVar, out artVar);

			return ApiCtx.DbSingle<Class>("CreateClassTx", txb.Finish(classVar));
		}

	}

}