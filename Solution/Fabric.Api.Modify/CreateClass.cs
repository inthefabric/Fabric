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
			IWeaverVarAlias<Artifact> artVar;

			var txb = new TxBuilder();
			txb.GetRoot(out rootVar);

			/*//TEST: CreateClass new direct-to-ID approach
			IWeaverVarAlias<Root> rootVar = new WeaverVarAlias<Root>(txb.Transaction);
			txb.RegisterVarWithTxBuilder(rootVar);
			var q = new WeaverQuery();
			q.FinalizeQuery(rootVar.Name+"=g.v(4)");
			txb.Transaction.AddQuery(q);*/

			IWeaverVarAlias<Member> memVar = new WeaverVarAlias<Member>(txb.Transaction);
			txb.RegisterVarWithTxBuilder(memVar);
			var q = new WeaverQuery();
			q.FinalizeQuery(memVar.Name+"=g.v("+m.Id+")");
			txb.Transaction.AddQuery(q);

			Tasks.TxAddClass(ApiCtx, txb, vName, vDisamb, vNote, rootVar, out classVar);
			Tasks.TxAddArtifact<Class, ClassHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.Class, rootVar, classVar, memVar, out artVar);
			txb.RegisterVarWithTxBuilder(classVar);

			/*IWeaverVarAlias classIdVar; = new WeaverVarAlias(txb.Transaction);
			txb.RegisterVarWithTxBuilder(classIdVar);
			q = new WeaverQuery();
			q.FinalizeQuery(classIdVar.Name+"="+classVar.Name+".id");
			txb.Transaction.AddQuery(q);*/

			/*
			//get Class c from the TxAddClass task
			txb.Transaction.AddQuery(
				WeaverTasks.BeginPath(classVar, false).BaseNode.Prop(x => x.Id).End()
			);
			 
			IApiDataAccess data = ApiCtx.DbData("CreateClassTx", txb.Finish()); //classVar));
			c.Id = data.GetLongResultAt(0);*/

			Class c = ApiCtx.DbSingle<Class>("CreateClassTx", txb.Finish(classVar));
			ApiCtx.AddToClassNameCache(c);
			return c;
		}

	}

}