using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Api.Paths.Steps.Oauth;
using Fabric.Infrastructure;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncRegistry {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, new[] { "/Oauth" })]
		[TestCase(false, new[] { "oauth" })]
		public void GetAvailableFuncsForRoot(bool pUri, string[] pExpect) {
			var art = new RootStep(new Path());
			List<string> result = FuncRegistry.GetAvailableFuncs(art, pUri);
			Assert.AreEqual(pExpect, result, "Incorrect result.");

			result = FuncRegistry.GetAvailableFuncs(typeof(FabRoot), pUri);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, new [] { "/Back", "/Limit" })]
		[TestCase(false, new[] { "back", "limit" })]
		public void GetAvailableFuncsForArtifact(bool pUri, string[] pExpect) {
			var art = new ArtifactStep(new Path());

			List<string> result = FuncRegistry.GetAvailableFuncs(art, pUri);
			Assert.AreEqual(pExpect, result, "Incorrect result.");

			result = FuncRegistry.GetAvailableFuncs(typeof(FabArtifact), pUri);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, new[] {
			"/AccessToken",
			"/AccessTokenAuthCode",
			"/AccessTokenRefresh",
			"/AccessTokenClientCredentials",
			"/AccessTokenClientDataProv",
			"/Login",
			"/Logout"
		})]
		[TestCase(false, new[] {
			"accesstoken",
			"accesstokenauthcode",
			"accesstokenrefresh",
			"accesstokenclientcredentials",
			"accesstokenclientdataprov",
			"login",
			"logout",
		})]
		public void GetAvailableFuncsForOauth(bool pUri, string[] pExpect) {
			var art = new OauthStep(new Path());

			List<string> result = FuncRegistry.GetAvailableFuncs(art, pUri);

			foreach ( string r in result ) {
				Log.Debug(r);
			}

			Assert.AreEqual(pExpect, result, "Incorrect result.");

			result = FuncRegistry.GetAvailableFuncs(typeof(FabOauth), pUri);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetAvailableFuncsNotFabNode(bool pUri) {
			TestUtil.CheckThrows<Exception>(true, () =>
				FuncRegistry.GetAvailableFuncs(typeof(string), pUri));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("back", typeof(FuncBackStep))]
		[TestCase("limit", typeof(FuncLimitStep))]
		public void GetFuncStep(string pCommand, Type pExpectType) {
			IStep result = FuncRegistry.GetFuncStep(pCommand, new Path());
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pExpectType, result.GetType(), "Incorrect result type.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetFuncStepNotFound() {
			IStep result = FuncRegistry.GetFuncStep("abcd", null);
			Assert.Null(result, "Result should be null.");
		}

	}

}