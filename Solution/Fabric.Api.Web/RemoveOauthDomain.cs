using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class RemoveOauthDomain : BaseWebFunc<SuccessResult> { //TEST: RemoveOauthDomain

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
			//Assume AppId is valid
			bool result = Tasks.DeleteOauthDomain(ApiCtx, vAppId, vOauthDomainId);
			return new SuccessResult(result);
		}

	}

}