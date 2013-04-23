using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class RemoveOauthDomain : BaseWebFunc<SuccessResult> {

		public const string AppIdParam = "AppId";
		public const string OauthDomainIdParam = "OauthDomainId";

		private readonly long vAppId;
		private readonly long vOauthDomainId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RemoveOauthDomain(IWebTasks pTasks, long pAppId, long pOauthDomainId) : base(pTasks) {
			vAppId = pAppId;
			vOauthDomainId = pOauthDomainId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.AppId(vAppId, AppIdParam);
			Tasks.Validator.OauthDomainId(vOauthDomainId, OauthDomainIdParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override SuccessResult Execute() {
			bool result = Tasks.DeleteOauthDomain(ApiCtx, vAppId, vOauthDomainId);
			return new SuccessResult(result);
		}

	}

}