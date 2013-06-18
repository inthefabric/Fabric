﻿using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetGrant : IntegTestBase {

		private string vCode;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			OauthGrant og = GetVertex<OauthGrant>((long)SetupOauth.OauthGrantId.GalMel);
			ApiCtx.TestUtcNow = new DateTime(og.Expires).AddMinutes(-20);
		}

		/*--------------------------------------------------------------------------------------------*/
		private GrantResult TestGo() {
			return new GetGrant(vCode).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupOauth.GrantGalZach, SetupOauth.OauthGrantId.GalZach, AppGal, UserZach)]
		[TestCase(SetupOauth.GrantBookMel, SetupOauth.OauthGrantId.BookMel, AppBook, UserMel)]
		public void Go(string pCode, SetupOauth.OauthGrantId pExpectId,
									SetupUsers.AppId pExpectAppId, SetupUsers.UserId pExpectUserId) {
			vCode = pCode;

			OauthGrant clearOg = GetVertex<OauthGrant>((long)pExpectId);
			Assert.NotNull(clearOg, "Target OauthGrant is missing.");
			Assert.NotNull(clearOg.Code, "Target OauthGrant must have a Token value.");

			int codeCount = CountCodes();

			GrantResult result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectId, result.GrantId, "Incorrect GrantId.");
			Assert.AreEqual((long)pExpectAppId, result.AppId, "Incorrect AppId.");
			Assert.AreEqual((long)pExpectUserId, result.UserId, "Incorrect UserId.");

			clearOg = GetVertex<OauthGrant>((long)pExpectId);
			Assert.NotNull(clearOg, "Target OauthGrant was deleted.");
			Assert.AreEqual("", clearOg.Code, "Target OauthGrant.Code was not cleared.");

			int updatedCodeCount = CountCodes();
			Assert.AreEqual(codeCount+1, updatedCodeCount, "Incorrect updated Code count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupOauth.GrantBookElliePast)]
		[TestCase("x")]
		[TestCase("")]
		public void NotFound(string pCode) {
			vCode = pCode;
			int codeCount = CountCodes();

			GrantResult result = TestGo();

			Assert.Null(result, "Result should be null.");

			int updatedCodeCount = CountCodes();
			Assert.AreEqual(codeCount, updatedCodeCount, "Incorrect updated Code count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private int CountCodes() {
			IWeaverQuery q = GetVertexByPropQuery<OauthGrant>(
				".has('"+PropDbName.OauthGrant_Code+"',Tokens.T.eq,'').count()");
			IApiDataAccess data = ApiCtx.DbData("TEST.CountCodes", q);
			return int.Parse(data.Result.TextList[0]);
		}

	}

}