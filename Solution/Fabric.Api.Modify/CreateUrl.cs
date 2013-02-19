﻿using Fabric.Api.Dto;
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
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModUrlsUri, typeof(FabUrl),
		Auth=ServiceAuthType.Member)]
	public class CreateUrl : BaseModifyFunc<Url> {

		public const string AbsoluteUrlParam = "AbsoluteUrl";
		public const string NameParam = "Name";

		[ServiceOpParam(ServiceOpParamType.Form, AbsoluteUrlParam, 0, typeof(Url))]
		private readonly string vAbsoluteUrl;

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, 1, typeof(Url))]
		private readonly string vName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUrl(IModifyTasks pTasks, string pAbsoluteUrl, string pName) : base(pTasks) {
			vAbsoluteUrl = pAbsoluteUrl;
			vName = pName;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.UrlAbsoluteUrl(vAbsoluteUrl, AbsoluteUrlParam);
			Tasks.Validator.UrlName(vName, NameParam);

			////

			int protoI = vAbsoluteUrl.IndexOf("://");
			int protoEnd = protoI+3;

			if ( protoI < 2 || vAbsoluteUrl.Length <= protoEnd ) {
				throw new FabArgumentValueFault(
					AbsoluteUrlParam+" uses an invalid format. Try starting the URL with 'http://'.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Url Execute() {
			if ( Tasks.GetUrlByAbsoluteUrl(ApiCtx, vAbsoluteUrl) != null ) {
				throw new FabDuplicateFault(typeof(Url), AbsoluteUrlParam, vAbsoluteUrl);
			}

			Member m = GetContextMember();

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Url> urlVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Artifact> artVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			txb.GetNode(m, out memVar);
			Tasks.TxAddUrl(ApiCtx, txb, vAbsoluteUrl, vName, rootVar, out urlVar);
			Tasks.TxAddArtifact<Url, UrlHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.Url, rootVar, urlVar, memVar, out artVar);

			txb.RegisterVarWithTxBuilder(urlVar);
			return ApiCtx.DbSingle<Url>("CreateUrlTx", txb.Finish(urlVar));
		}

	}

}