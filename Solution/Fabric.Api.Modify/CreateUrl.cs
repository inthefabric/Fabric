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
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModUrlsUri, typeof(FabUrl),
		Auth=ServiceAuthType.Member)]
	public class CreateUrl : BaseModifyFunc<Url> {

		public const string PathParam = "Path";
		public const string NameParam = "Name";

		[ServiceOpParam(ServiceOpParamType.Form, PathParam, 0, typeof(Url))]
		private readonly string vPath;

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, 1, typeof(Url))]
		private readonly string vName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUrl(IModifyTasks pTasks, string pPath, string pName) : base(pTasks) {
			vPath = pPath;
			vName = pName;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.UrlPath(vPath, PathParam);
			Tasks.Validator.UrlName(vName, NameParam);

			////

			int protoI = vPath.IndexOf("://");
			int protoEnd = protoI+3;

			if ( protoI < 2 || vPath.Length <= protoEnd ) {
				throw new FabArgumentValueFault(
					PathParam+" uses an invalid format. Try starting the URL with 'http://'.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Url Execute() {
			if ( Tasks.GetUrlByPath(ApiCtx, vPath) != null ) {
				throw new FabDuplicateFault(typeof(Url), PathParam, vPath);
			}

			Member m = GetContextMember();

			////

			IWeaverVarAlias<Url> urlVar;
			IWeaverVarAlias<Member> memVar;

			var txb = new TxBuilder();
			txb.GetVertex(m, out memVar);
			Tasks.TxAddUrl(ApiCtx, txb, vPath, vName, memVar, out urlVar);
			txb.RegisterVarWithTxBuilder(urlVar);

			return ApiCtx.Get<Url>(txb.Finish(urlVar));
		}

	}

}