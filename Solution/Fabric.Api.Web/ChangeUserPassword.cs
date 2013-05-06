using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class ChangeUserPassword : BaseWebFunc<SuccessResult> {

		public const string UserIdParam = "UserId";
		public const string OldPasswordParam = "OldPassword";
		public const string NewPasswordParam = "NewPassword";

		private readonly long vUserId;
		private readonly string vOldPass;
		private readonly string vNewPass;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ChangeUserPassword(IWebTasks pTasks, long pUserId, string pOldPass, string pNewPass) :
																						base(pTasks) {
			vUserId = pUserId;
			vOldPass = pOldPass;
			vNewPass = pNewPass;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.ArtifactId(vUserId, UserIdParam);
			Tasks.Validator.UserPassword(vNewPass, NewPasswordParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override SuccessResult Execute() {
			User user = Tasks.GetUser(ApiCtx, vUserId);

			if ( user == null ) {
				throw new FabNotFoundFault(typeof(User), UserIdParam+"="+vUserId);
			}

			if ( user.Password != FabricUtil.HashPassword(vOldPass) ) {
				throw new FabPreventedFault(FabFault.Code.ActionNotPermitted,
					"Incorrect "+OldPasswordParam+".");
			}

			////
			
			user = Tasks.UpdateUserPassword(ApiCtx, vUserId, vNewPass);
			return new SuccessResult(user != null);
		}

	}

}