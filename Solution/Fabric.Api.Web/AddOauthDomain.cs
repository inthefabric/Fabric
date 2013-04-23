using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class AddOauthDomain : BaseWebFunc<OauthDomain> {

		public const string AppIdParam = "AppId";
		public const string DomainParam = "Domain";

		private readonly long vAppId;
		private readonly string vDomain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddOauthDomain(IWebTasks pTasks, long pAppId, string pDomain) : base(pTasks) {
			vAppId = pAppId;
			vDomain = pDomain;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.AppId(vAppId, AppIdParam);
			Tasks.Validator.OauthDomainDomain(vDomain, DomainParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override OauthDomain Execute() {
			App app = Tasks.GetApp(ApiCtx, vAppId);
			
			if ( app == null ) {
				throw new FabNotFoundFault(typeof(App), AppIdParam+"="+vAppId);
			}

			if ( Tasks.GetOauthDomainByDomain(ApiCtx, vAppId, vDomain) != null ) {
				throw new FabDuplicateFault(typeof(OauthDomain), DomainParam, vDomain);
			}
			
			return Tasks.AddOauthDomain(ApiCtx, vAppId, vDomain);
		}

	}

}