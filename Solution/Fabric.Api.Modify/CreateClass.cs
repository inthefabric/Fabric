using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesUri, typeof(FabClass),
		Auth=ServiceAuthType.Member)]
	public class CreateClass : BaseModifyFunc<Class> {

		private static readonly object MemberLock = new object();

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
			//TEST: add one-char lower tests everywhere
			Tasks.Validator.ClassName(vName, NameParam);
			Tasks.Validator.ClassDisamb(vDisamb, DisambParam);
			Tasks.Validator.ClassNote(vNote, NoteParam);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Class Execute() {
			return ExecuteInner();
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class ExecuteInner() {
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Class> classVar;
			Member m;

			if ( Tasks.GetClassByNameDisamb(ApiCtx, vName, vDisamb) != null ) {
				string name = vName+(vDisamb == null ? "" : " ("+vDisamb+")");
				throw new FabDuplicateFault(typeof(Class), NameParam, name);
			}

			lock ( MemberLock ) {
				m = GetContextMember();
			}

			var txb = new TxBuilder();
			txb.GetNodeByNodeId(m, out memVar);

			Tasks.TxAddClass(ApiCtx, txb, vName, vDisamb, vNote, memVar, out classVar);
			txb.RegisterVarWithTxBuilder(classVar);

			Class c = ApiCtx.DbSingle<Class>("CreateClassTx", txb.Finish(classVar));
			ApiCtx.Cache.UniqueClasses.AddClass(c.ClassId, c.Name, c.Disamb);
			return c;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal void ValidateParamsForBatch() {
			ValidateParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		internal Class ExecuteForBatch(IApiContext pApiCtx) {
			SetApiCtx(pApiCtx);
			return ExecuteInner();
		}

	}

}