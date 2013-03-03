﻿using System.Web.Configuration;
using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		protected static FabMetaVersion Version;

#if DEBUG
		private const string ApiKey = "Dev_Api";
		private const string DbKey = "Dev_Db";
#else
		private const string ApiKey = "Prod_Api";
		private const string DbKey = "Prod_Db";
#endif

		public static readonly string ApiUrl = "http://"+WebConfigurationManager.AppSettings[ApiKey];
		public static readonly string DbUrl = "http://"+WebConfigurationManager.AppSettings[DbKey];


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			Log.ConfigureOnce();

			if ( Version == null ) {
				Version = new FabMetaVersion();
				Version.SetBuild(0, 1, 10, "322adcbc3087");
				Version.SetDate(2013, 3, 3);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			return new ApiContext(DbUrl);
		}

	}

}