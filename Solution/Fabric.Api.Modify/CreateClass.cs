using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

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
			Tasks.Validator.ClassName(vName, NameParam);
			Tasks.Validator.ClassDisamb(vDisamb, DisambParam);
			Tasks.Validator.ClassNote(vNote, NoteParam);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Class Execute() {
			VerifyUniqueClass();

			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Class> classVar;
			TxBuilder txb = GetFullTx(out memVar, out classVar);
			return ApiCtx.Get<Class>(txb.Finish(classVar));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void VerifyUniqueClass() {
			return;
			Class c = Tasks.GetClassByNameDisamb(ApiCtx, vName, vDisamb);

			if ( c == null ) {
				return;
			}

			string name = vName+(vDisamb == null ? "" : " ("+vDisamb+")");

			throw new FabDuplicateFault(typeof(Class), NameParam, name,
				"Conflicts with ClassId="+c.ArtifactId+".");
		}

		/*--------------------------------------------------------------------------------------------*/
		private TxBuilder GetFullTx(out IWeaverVarAlias<Member> pMemVar,
																out IWeaverVarAlias<Class> pClassVar) {
			var txb = new TxBuilder();
			txb.GetVertexByVertexId(GetContextMember(), out pMemVar);
			AppendTx(txb, pMemVar, out pClassVar);
			return txb;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AppendTx(TxBuilder pTxBuild, IWeaverVarAlias<Member> pMemVar,
																out IWeaverVarAlias<Class> pClassVar) {
			vNewClassId = Tasks.TxAddClass(ApiCtx, pTxBuild,
				vName, vDisamb, vNote, pMemVar, out pClassVar);
			pTxBuild.RegisterVarWithTxBuilder(pClassVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal void ValidateParamsForBatch() {
			ValidateParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		internal TxBuilder GetFullTxForBatch(IApiContext pApiCtx, out IWeaverVarAlias<Member> pMemVar, 
																out IWeaverVarAlias<Class> pClassVar) {
			SetApiCtx(pApiCtx);
			VerifyUniqueClass();
			return GetFullTx(out pMemVar, out pClassVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		internal void AppendTxForBatch(IApiContext pApiCtx, TxBuilder pTxBuild,
								IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar) {
			SetApiCtx(pApiCtx);
			VerifyUniqueClass();
			AppendTx(pTxBuild, pMemVar, out pClassVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		internal Class GetNewClassForBatch() {
			var c = new Class();
			c.ArtifactId = vNewClassId;
			c.Name = vName;
			c.Disamb = vDisamb;
			c.Note = vNote;
			return c;
		}

	}

}