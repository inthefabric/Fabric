using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Util;

namespace Fabric.New.Database.Init.Setups {

	/*================================================================================================*/
	public class SetupOauth : SetupVertices {

		/*public const int NumDomains = 6;
		public const int NumAccesses = 17;
		public const int NumGrants = 5;
		public const int NumScopes = 11;*/
		
		public const string TokenFabZach	= "8f32fho2f8092uef0fdskl0383275fld";
		public const string TokenGalEllieExp= "dfjsdf87897df982ef0972ef082e7f89";
		public const string TokenGalZach	= "98dsf98sd9as8dcj9a8sdc9as8d7ff22";
		public const string TokenGalMel		= "8dsfashdclasjdchasd87fas89dcdc98";
		public const string TokenGalGalData	= "293f9wfsd98sdfsdhcsjdf98sdfsfsqw";
		public const string TokenBookZach	= "kjdsf978sd23092hj32623kh11djfhc0";
		public const string TokenBookMel	= "kjlsdfsd9fs9dfjsdkfsd90f8sdfkjdf";
		public const string RefreshGalZach	= "3fu2f9ufd9usdf9usd9cew920e9udsa1";

		public const string DomFab1		= "inthefabric.com";
		public const string DomFab2		= "localhost:55555";
		public const string DomGal1		= "zachkinstner.com";
		public const string DomGal2		= "localhost:49316";
		public const string DomBook1	= "my.super.bookmarker.com";
		public const string DomBook2	= "localhost:32123";

		public const string GrantBookZachPast	= "8923fh23f982362f27f7611fjhfjhfds";
		public const string GrantGalMel			= "kjdcio2ejh237297wcjk121890872hfd";
		public const string GrantGalZach		= "jf3982h8er7wv8dcsn29c2ec92efj29f";
		public const string GrantGalPenny		= "hu198fe2h2f923h32f239823101h3484";
		public const string GrantBookMel		= "9832hf3031fh10fj9e7sdlckjsdc8732";

		public const string GrantUrlGal		= "http://"+DomGal1+"/oauth";
		public const string GrantUrlGalS	= "https://"+DomGal1+"/oauth";
		public const string GrantUrlGalLoc	= "http://"+DomGal2+"/testing";
		public const string GrantUrlBook	= "http://"+DomBook1+"/test/a/b/";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupOauth(DataSet pData) : base(pData) {}
			
		/*--------------------------------------------------------------------------------------------*/
		public void Create() {
			const SetupAppId fab = SetupAppId.FabSys;
			const SetupAppId gal = SetupAppId.KinPhoGal;
			const SetupAppId book = SetupAppId.Bookmarker;

			var now = new DateTime(Data.NowTimestamp);

			IsForTestingOnly = false;
			AddDomain(fab, DomFab1);
			AddDomain(fab, DomFab2);
			IsForTestingOnly = true;
			AddDomain(gal, DomGal1);
			AddDomain(gal, DomGal2);
			AddDomain(book, DomBook1);
			AddDomain(book, DomBook2);

			AddAccess(OauthAccessId.GalZach_Past, SetupMemberId.GalZach, null, -320);
			AddAccess(OauthAccessId.GalMel_Past, SetupMemberId.GalMel, null, -301);
			AddAccess(OauthAccessId.GalGalData_Past, SetupMemberId.GalGalData, null, -222);
			AddAccess(OauthAccessId.GalEllie_Past, SetupMemberId.GalEllie, TokenGalEllieExp, -186); //not refreshed
			AddAccess(OauthAccessId.BookBookData_Past, SetupMemberId.BookBookData, null, -143);
			AddAccess(OauthAccessId.BookMel_Past, SetupMemberId.BookMel, null, -3);
			AddAccess(OauthAccessId.GalZach, SetupMemberId.GalZach, TokenGalZach, 2, RefreshGalZach);
			AddAccess(OauthAccessId.GalMel, SetupMemberId.GalMel, TokenGalMel, 7);
			AddAccess(OauthAccessId.GalGalData, SetupMemberId.GalGalData, TokenGalGalData, 18);
			AddAccess(OauthAccessId.BookZach, SetupMemberId.BookZach, TokenBookZach, 35);
			AddAccess(OauthAccessId.BookMel, SetupMemberId.BookMel, TokenBookMel, 57);
			AddAccess(OauthAccessId.FabZach, SetupMemberId.FabZach, TokenFabZach, 62);

			AddGrant(SetupMemberId.BookZach, GrantBookZachPast, GrantUrlBook, now.AddMinutes(-3));
			AddGrant(SetupMemberId.GalMel, GrantGalMel, GrantUrlGal, now.AddMinutes(20));
			AddGrant(SetupMemberId.GalZach, GrantGalZach, GrantUrlGalLoc, now.AddMinutes(25));
			AddGrant(SetupMemberId.GalPenny, GrantGalPenny, GrantUrlGalS, now.AddMinutes(32));
			AddGrant(SetupMemberId.BookMel, GrantBookMel, GrantUrlBook, now.AddMinutes(47));
			
			AddScope(SetupMemberId.FabFabData, true);
			AddScope(SetupMemberId.GalZach, true);
			AddScope(SetupMemberId.GalPenny, true);
			AddScope(SetupMemberId.GalMel, true);
			AddScope(SetupMemberId.GalGalData, true);
			AddScope(SetupMemberId.GalEllie, true);
			AddScope(SetupMemberId.BookZach, true);
			AddScope(SetupMemberId.BookBookData, true);
			AddScope(SetupMemberId.BookMel, true);
			AddScope(SetupMemberId.BookEllie, false);
			AddScope(SetupMemberId.BookPenny, false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddDomain(SetupAppId pAppId, string pDomain) {
			App a = Data.GetVertex<App>((long)pAppId);
			a.OauthDomains += (string.IsNullOrEmpty(a.OauthDomains) ? "" : "|")+pDomain;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddAccess(OauthAccessId pId, SetupMemberId pMemId,
													string pToken, int pMins, string pRefresh=null) {
			var oa = new OauthAccess();
			oa.Expires = new DateTime(Data.NowTimestamp).AddMinutes(pMins).Ticks;
			oa.Token = pToken;
			oa.Refresh = (pRefresh ?? DataUtil.Code32);
			oa.IsDataProv = (
				pMemId == SetupMemberId.FabFabData ||
				pMemId == SetupMemberId.GalGalData ||
				pMemId == SetupMemberId.BookBookData
			);
			AddVertex(oa, (SetupVertexId)(long)pId);
			AddEdge(oa, new OauthAccessAuthenticatesMember(), Data.GetVertex<Member>((long)pMemId));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddGrant(SetupMemberId pMemId, string pCode, string pRedirectUri, DateTime pExp) {
			Member m = Data.GetVertex<Member>((long)pMemId);
			m.OauthGrantCode = pCode;
			m.OauthGrantExpires = pExp.Ticks;
			m.OauthGrantRedirectUri = pRedirectUri;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddScope(SetupMemberId pMemId, bool pAllow) {
			Member m = Data.GetVertex<Member>((long)pMemId);
			m.OauthScopeAllow = pAllow;
			Data.ElapseTime();
		}

	}

}