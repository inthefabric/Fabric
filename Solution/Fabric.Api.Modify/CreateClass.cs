using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
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

		private long vNewClassId;


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
			//TODO: add one-char lower bound to Class.Name length
			Tasks.Validator.ClassName(vName, NameParam);
			Tasks.Validator.ClassDisamb(vDisamb, DisambParam);
			Tasks.Validator.ClassNote(vNote, NoteParam);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override Class Execute() {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Class> classVar;

			TxBuilder txb = GetFullTx(out rootVar, out memVar, out classVar);

			Class c = ApiCtx.DbSingle<Class>("CreateClassTx", txb.Finish(classVar));
			//ApiCtx.ClassNameCache.AddClass(ApiCtx, c.ClassId, c.Name, c.Disamb);
			return c;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal void ValidateParamsForBatch() {
			ValidateParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		internal long GetNewClassIdForBatch() {
			return vNewClassId;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal void SetApiCtxForBatch(IApiContext pApiCtx) {
			SetApiCtx(pApiCtx);
		}

		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder GetFullTx(out IWeaverVarAlias<Root> pRootVar, 
							out IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar) {
			
			/*if ( Tasks.GetClassByNameDisamb(ApiCtx, vName, vDisamb) != null ) {
				string name = vName+(vDisamb == null ? "" : " ("+vDisamb+")");
				throw new FabDuplicateFault(typeof(Class), NameParam, name);
			}*/
			
			Member m = GetContextMember();
			
			var txb = new TxBuilder();
			txb.GetRoot(out pRootVar);
			txb.GetNodeByNodeId(m, out pMemVar);
			
			FillBatchTx(txb, pRootVar, pMemVar, out pClassVar);
			return txb;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillBatchTx(TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar) {
			vNewClassId = Tasks.TxAddClass(ApiCtx, pTxBuild, 
				vName, vDisamb, vNote, pRootVar, pMemVar, out pClassVar);

			pTxBuild.RegisterVarWithTxBuilder(pClassVar);
		}

	}

}