﻿using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class ChangeAppName : BaseWebFunc<SuccessResult> { //TEST: ChangeAppName

		public const string AppIdParam = "AppId";
		public const string NameParam = "Name";

		private readonly long vAppId;
		private readonly string vName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ChangeAppName(IWebTasks pTasks, long pAppId, string pName) : base(pTasks) {
			vAppId = pAppId;
			vName = pName;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.AppId(vAppId, AppIdParam);
			Tasks.Validator.AppName(vName, NameParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override SuccessResult Execute() {
			//Assume AppId is valid
			App app = Tasks.UpdateAppName(ApiCtx, vAppId, vName);
			return new SuccessResult(app != null);
		}

	}

}