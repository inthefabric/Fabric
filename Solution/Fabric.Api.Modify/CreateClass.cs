﻿using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Weaver;
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
			IWeaverVarAlias<ArtifactType> artTypeVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Class> classVar;

			TxBuilder txb = GetFullTx(out rootVar, out memVar, out artTypeVar, out classVar);

			Class c = ApiCtx.DbSingle<Class>("CreateClassTx", txb.Finish(classVar));
			ApiCtx.AddToClassNameCache(c);
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
					out IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<ArtifactType> pArtTypeVar,
																out IWeaverVarAlias<Class> pClassVar) {
			
			if ( Tasks.GetClassByNameDisamb(ApiCtx, vName, vDisamb) != null ) {
				string name = vName+(vDisamb == null ? "" : " ("+vDisamb+")");
				throw new FabDuplicateFault(typeof(Class), NameParam, name);
			}
			
			Member m = GetContextMember();
			
			var txb = new TxBuilder();
			txb.GetRoot(out pRootVar);

			var at = new ArtifactType { ArtifactTypeId = (long)ArtifactTypeId.Class };
			txb.GetNode(at, out pArtTypeVar);
			
			pMemVar = new WeaverVarAlias<Member>(txb.Transaction);
			txb.RegisterVarWithTxBuilder(pMemVar);
			var q = new WeaverQuery();
			q.FinalizeQuery(pMemVar.Name+"=g.v("+m.Id+")");
			txb.Transaction.AddQuery(q);

			FillBatchTx(txb, pRootVar, pMemVar, pArtTypeVar, out pClassVar);
			return txb;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillBatchTx(TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<Member> pMemVar, IWeaverVarAlias<ArtifactType> pArtTypeVar,
							out IWeaverVarAlias<Class> pClassVar) {
			IWeaverVarAlias<Artifact> artVar;

			vNewClassId = Tasks.TxAddClass(ApiCtx, pTxBuild, 
				vName, vDisamb, vNote, pRootVar, out pClassVar);

			Tasks.TxAddArtifact<Class, ClassHasArtifact>(
				ApiCtx, pTxBuild, pRootVar, pArtTypeVar, pClassVar, pMemVar, out artVar);

			pTxBuild.RegisterVarWithTxBuilder(pClassVar);
		}

	}

}