using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class ChangeAppSecret : BaseWebFunc<SuccessResult> { //TEST: ChangeAppSecret

		public const string AppIdParam = "AppId";

		private readonly long vAppId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ChangeAppSecret(IWebTasks pTasks, long pAppId) : base(pTasks) {
			vAppId = pAppId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.AppId(vAppId, AppIdParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override SuccessResult Execute() {
			//Assume AppId is valid
			App app = Tasks.UpdateAppSecret(ApiCtx, vAppId, ApiCtx.Code32);
			return new SuccessResult(app != null);
		}

	}

}