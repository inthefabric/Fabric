using System;
using Fabric.Domain;
using Fabric.Infrastructure;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class SetupOauth {

		public enum OauthDomainId {
			Fab1 = 1,
			Fab2,
			Gal1,
			Gal2,
			Book1,
			Book2
		}

		public enum OauthAccessId {
			GalZach_Past = 1,
			GalMel_Past,
			Book_Past1,
			Gal_Past,
			GalGalData_Past,
			GalEllie_Past,
			BookBookData_Past,
			Book_Past2,
			BookMel_Past,
			GalZach,
			GalMel,
			GalGalData,
			Gal,
			BookZach,
			Book,
			BookMel,
			FabZach
		}

		public enum OauthGrantId {
			BookElliePast = 1,
			GalMel,
			GalZach,
			GalPenny,
			BookMel
		}

		public enum OauthScopeId {
			FabFabData = 1,
			GalZach,
			GalPenny,
			GalMel,
			GalGalData,
			GalEllie,
			BookZach,
			BookBookData,
			BookMel,
			BookEllieNo,
			BookPennyNo
		}
		
		public const int NumDomains = 6;
		public const int NumAccesses = 17;
		public const int NumGrants = 5;
		public const int NumScopes = 11;
		
		public const string TokenFabZach	= "8f32fho2f8092uef0fdskl0383275fld";
		public const string TokenGalEllieExp	= "dfjsdf87897df982ef0972ef082e7f89";
		public const string TokenGalZach	= "98dsf98sd9as8dcj9a8sdc9as8d7ff22";
		public const string TokenGalMel	= "8dsfashdclasjdchasd87fas89dcdc98";
		public const string TokenGalGalData= "293f9wfsd98sdfsdhcsjdf98sdfsfsqw";
		public const string TokenGal		= "892fjdlsfsdoifsdhfe89chsdcldsflk";
		public const string TokenBookZach	= "kjdsf978sd23092hj32623kh11djfhc0";
		public const string TokenBook		= "sdlkfsd87fsdjfhsd987fsdfsdf87sdf";
		public const string TokenBookMel	= "kjlsdfsd9fs9dfjsdkfsd90f8sdfkjdf";

		public const string RefreshGalZach	= "3fu2f9ufd9usdf9usd9cew920e9udsa1";

		public const string DomFab1		= "inthefabric.com";
		public const string DomFab2		= "localhost:55555";
		public const string DomGal1		= "zachkinstner.com";
		public const string DomGal2		= "localhost:49316";
		public const string DomBook1	= "my.super.bookmarker.com";
		public const string DomBook2	= "localhost:32123";

		public const string GrantBookElliePast	= "8923fh23f982362f27f7611fjhfjhfds";
		public const string GrantGalMel		= "kjdcio2ejh237297wcjk121890872hfd";
		public const string GrantGalZach	= "jf3982h8er7wv8dcsn29c2ec92efj29f";
		public const string GrantGalPenny	= "hu198fe2h2f923h32f239823101h3484";
		public const string GrantBookMel	= "9832hf3031fh10fj9e7sdlckjsdc8732";

		public const string GrantUrlGal		= "http://"+DomGal1+"/oauth";
		public const string GrantUrlGalS	= "https://"+DomGal1+"/oauth";
		public const string GrantUrlGalLoc	= "http://"+DomGal2+"/testing";
		public const string GrantUrlBook	= "http://"+DomBook1+"/test/a/b/";

		private readonly DataSet vSet;
		private readonly bool vTestMode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			var so = new SetupOauth(pSet);
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupOauth(DataSet pSet) {
			vSet = pSet;

			const SetupUsers.AppId fab = SetupUsers.AppId.FabSys;
			const SetupUsers.AppId gal = SetupUsers.AppId.KinPhoGal;
			const SetupUsers.AppId book = SetupUsers.AppId.Bookmarker;

			const SetupUsers.UserId fabData = SetupUsers.UserId.FabData;
			const SetupUsers.UserId galData = SetupUsers.UserId.GalData;
			const SetupUsers.UserId bookData = SetupUsers.UserId.BookData;
			const SetupUsers.UserId zach = SetupUsers.UserId.Zach;
			const SetupUsers.UserId mel = SetupUsers.UserId.Mel;
			const SetupUsers.UserId ellie = SetupUsers.UserId.Ellie;
			const SetupUsers.UserId penny = SetupUsers.UserId.Penny;

			DateTime now = new DateTime(vSet.NowTimestamp);

			vTestMode = false;
			AddDomain(OauthDomainId.Fab1, fab, DomFab1);
			AddDomain(OauthDomainId.Fab2, fab, DomFab2);
			vTestMode = true;
			AddDomain(OauthDomainId.Gal1, gal, DomGal1);
			AddDomain(OauthDomainId.Gal2, gal, DomGal2);
			AddDomain(OauthDomainId.Book1, book, DomBook1);
			AddDomain(OauthDomainId.Book2, book, DomBook2);
			
			AddAccess(OauthAccessId.GalZach_Past, gal, zach, "", -320);
			AddAccess(OauthAccessId.GalMel_Past, gal, mel, "", -301);
			AddAccess(OauthAccessId.Book_Past1, book, null, "", -299);
			AddAccess(OauthAccessId.Gal_Past, gal, null, "", -271);
			AddAccess(OauthAccessId.GalGalData_Past, gal, galData, "", -222);
			AddAccess(OauthAccessId.GalEllie_Past, gal, ellie, TokenGalEllieExp, -186); //not refreshed
			AddAccess(OauthAccessId.BookBookData_Past, book, bookData, "", -143);
			AddAccess(OauthAccessId.Book_Past2, book, null, "", -88);
			AddAccess(OauthAccessId.BookMel_Past, book, mel, "", -3);
			AddAccess(OauthAccessId.GalZach, gal, zach, TokenGalZach, 2, RefreshGalZach);
			AddAccess(OauthAccessId.GalMel, gal, mel, TokenGalMel, 7);
			AddAccess(OauthAccessId.GalGalData, gal, galData, TokenGalGalData, 18);
			AddAccess(OauthAccessId.Gal, gal, null, TokenGal, 26);
			AddAccess(OauthAccessId.BookZach, book, zach, TokenBookZach, 35);
			AddAccess(OauthAccessId.Book, book, null, TokenBook, 48);
			AddAccess(OauthAccessId.BookMel, book, mel, TokenBookMel, 57);
			AddAccess(OauthAccessId.FabZach, fab, zach, TokenFabZach, 62);

			AddGrant(OauthGrantId.BookElliePast, book, ellie, GrantBookElliePast, GrantUrlBook,
				now.AddMinutes(-3));
			AddGrant(OauthGrantId.GalMel, gal, mel, GrantGalMel, GrantUrlGal,
				now.AddMinutes(20));
			AddGrant(OauthGrantId.GalZach, gal, zach, GrantGalZach, GrantUrlGalLoc,
				now.AddMinutes(25));
			AddGrant(OauthGrantId.GalPenny, gal, penny, GrantGalPenny, GrantUrlGalS,
				now.AddMinutes(32));
			AddGrant(OauthGrantId.BookMel, book, mel, GrantBookMel, GrantUrlBook,
				now.AddMinutes(47));
			
			AddScope(OauthScopeId.FabFabData, fab, fabData, true);
			AddScope(OauthScopeId.GalZach, gal, zach, true);
			AddScope(OauthScopeId.GalPenny, gal, penny, true);
			AddScope(OauthScopeId.GalMel, gal, mel, true);
			AddScope(OauthScopeId.GalGalData, gal, galData, true);
			AddScope(OauthScopeId.GalEllie, gal, ellie, true);
			AddScope(OauthScopeId.BookZach, book, zach, true);
			AddScope(OauthScopeId.BookBookData, book, bookData, true);
			AddScope(OauthScopeId.BookMel, book, mel, true);
			AddScope(OauthScopeId.BookEllieNo,book, ellie, false);
			AddScope(OauthScopeId.BookPennyNo, book, penny, false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddDomain(OauthDomainId pId, SetupUsers.AppId pAppId, string pDomain) {
			var od = new OauthDomain();
			od.OauthDomainId = (long)pId;
			od.Domain = pDomain;

			vSet.AddNodeAndIndex(od, x => x.OauthDomainId, vTestMode);
			vSet.AddRootRel<RootContainsOauthDomain>(od, vTestMode);

			var relA = DataRel.Create(od, new OauthDomainUsesApp(),
				vSet.GetNode<App>((long)pAppId), vTestMode);
			vSet.AddRel(relA);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddAccess(OauthAccessId pId, SetupUsers.AppId pAppId, SetupUsers.UserId? pUserId,
													string pToken, int pMins, string pRefresh=null) {
			var oa = new OauthAccess();
			oa.OauthAccessId = (long)pId;
			oa.Expires = new DateTime(vSet.NowTimestamp).AddMinutes(pMins).Ticks;
			oa.Token = pToken;
			oa.Refresh = (pRefresh ?? FabricUtil.Code32);
			oa.IsClientOnly = (pUserId == null);

			vSet.AddNodeAndIndex(oa, x => x.OauthAccessId, vTestMode);
			vSet.AddRootRel<RootContainsOauthAccess>(oa, vTestMode);

			var relA = DataRel.Create(oa, new OauthAccessUsesApp(),
				vSet.GetNode<App>((long)pAppId), vTestMode);
			vSet.AddRel(relA);

			if ( pUserId != null ) {
				var relU = DataRel.Create(oa, new OauthAccessUsesUser(),
					vSet.GetNode<User>((long)pUserId), vTestMode);
				vSet.AddRel(relU);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddGrant(OauthGrantId pId, SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
												string pCode, string pRedirectUri, DateTime pExpires) {
			var og = new OauthGrant();
			og.OauthGrantId = (long)pId;
			og.RedirectUri = pRedirectUri;
			og.Code = pCode;
			og.Expires = pExpires.Ticks;

			vSet.AddNodeAndIndex(og, x => x.OauthGrantId, vTestMode);
			vSet.AddRootRel<RootContainsOauthGrant>(og, vTestMode);

			var relA = DataRel.Create(og, new OauthGrantUsesApp(),
				vSet.GetNode<App>((long)pAppId), vTestMode);
			vSet.AddRel(relA);

			var relU = DataRel.Create(og, new OauthGrantUsesUser(),
				vSet.GetNode<User>((long)pUserId), vTestMode);
			vSet.AddRel(relU);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddScope(OauthScopeId pId, SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
																						bool pAllow) {
			var os = new OauthScope();
			os.OauthScopeId = (long)pId;
			os.Allow = pAllow;
			os.Created = vSet.NowTimestamp;

			vSet.AddNodeAndIndex(os, x => x.OauthScopeId, vTestMode);
			vSet.AddRootRel<RootContainsOauthScope>(os, vTestMode);

			var relA = DataRel.Create(os, new OauthScopeUsesApp(),
				vSet.GetNode<App>((long)pAppId), vTestMode);
			vSet.AddRel(relA);

			var relU = DataRel.Create(os, new OauthScopeUsesUser(),
				vSet.GetNode<User>((long)pUserId), vTestMode);
			vSet.AddRel(relU);

			vSet.ElapseTime();
		}

	}

}