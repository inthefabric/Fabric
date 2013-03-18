using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesUri, typeof(FabClass),
		Auth=ServiceAuthType.Member)]
	public class CreateClass : BaseModifyFunc<Class> {

		public const string NameParam = "Name";
		public const string DisambParam = "Disamb";
		public const string NoteParam = "Note";

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, 0, typeof(Class))]
		private readonly string vName;

		[ServiceOpParam(ServiceOpParamType.Form, DisambParam, 1, typeof(Class), IsRequired=false)]
		private readonly string vDisamb;

		[ServiceOpParam(ServiceOpParamType.Form, NoteParam, 2, typeof(Class), IsRequired=false)]
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
			Tasks.Validator.ClassDisamb(vDisamb, DisambParam);
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

			txb.RegisterVarWithTxBuilder(classVar);
			Class c = ApiCtx.DbSingle<Class>("CreateClassTx", txb.Finish(classVar));
			ApiCtx.AddToClassNameCache(c);
			return c;
		}

	}

}