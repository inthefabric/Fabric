using Fabric.Domain;
using Fabric.Infrastructure;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class SetupUsers {

		public enum EmailId {
			DP_ITF = 1,
			Zach_AEI,
			MKin_Gmail,
			PhoApp_ZK,
			EJ_ZK,
			PJ_ZK,
			FabApp_Book
		}

		public enum MemberId {
			FabFabData = 1,
			FabZach,
			FabMel,
			FabGalData,
			GalGalData,
			GalZach,
			FabEllie,
			GalEllie,
			GalMel,
			FabPenny,
			FabBookData,
			BookBookData,
			BookZach,
			BookMel,
			GalBookData_None,
			GalPenny
		}

		public enum MemberTypeAssignId {
			FabFabDataBySystem = 1,
			FabZachBySystem,
			FabMelBySystem,
			FabGalDataBySystem,
			GalGalDataBySystem,
			GalZachBySystem,
			FabEllieBySystem,
			GalEllieBySystem,
			GalMelBySystem,
			FabPennyBySystem,
			FabBookDataBySystem,
			BookBookDataBySystem,
			BookZachBySystem,
			BookMelBySystem,
			GalBookData_NoneBySystem,
			GalPennyBySystem
		}

		public enum UserId {
			FabData = 1,
			Zach,
			Mel,
			GalData,
			Ellie,
			Penny,
			BookData
		}

		public enum AppId {
			FabSys = 1,
			KinPhoGal,
			Bookmarker
		}

		public const int NumEmails = 7;
		public const int NumMembers = 16;
		public const int NumUsers = 7;
		public const int NumApps = 3;
		public const int NumResetpasses = 0;

		public const string FabSysSecret    = "abcdefghijklmnopqrstuvwxyZ012345";
		public const string KinPhoGalSecret = "0123456789abcdefghijkLMNOPqrstuv";
		public const string BookmarkSecret  = "alkjdfkusdlf7f238092fijlcsdc089f";

		private static bool TestMode = false;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			TestMode = false;

			AddEmail(pSet, EmailId.DP_ITF, "dataprov@inthefabric.com");
			AddApp(pSet, AppId.FabSys, "Fabric System", EmailId.DP_ITF, FabSysSecret);
			AddUser(pSet, UserId.FabData, "Fabric", "password", EmailId.DP_ITF);
			AddMember(pSet, MemberId.FabFabData, AppId.FabSys, UserId.FabData,
				MemberTypeId.DataProvider, MemberTypeAssignId.FabFabDataBySystem, MemberId.FabFabData);
			AddAppArtifact(pSet, SetupArtifacts.ArtifactId.App_FabSys,
				AppId.FabSys, MemberId.FabFabData);
			AddUserArtifact(pSet, SetupArtifacts.ArtifactId.User_FabData,
				UserId.FabData, MemberId.FabFabData);
			pSet.ElapseTime();

			////

			TestMode = true;
			
			/*
			AddEmail("zach@aestheticinteractive.com");
			AddUser("zachkinstner", "asdfasdf", EmailIds.Zach_AEI, MemberIds.FabZach);
			AddMember(AppIds.FabSys, UserIds.Zach, MemberTypeIds.Owner);
			pSet.ElapseTime();

			AddEmail("mkinstner@gmail.com");
			AddUser("melkins", "EllieBear1", EmailIds.MKin_Gmail, MemberIds.FabMel);
			AddMember(AppIds.FabSys, UserIds.Mel, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddEmail("PhotoApp@zachkinstner.com");
			AddUser("KinstnerPhotos", "snapshot", EmailIds.PhoApp_ZK, MemberIds.FabGalData);
			AddMember(AppIds.FabSys, UserIds.GalData, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddApp("Kinstner Photo Gallery", EmailIds.PhoApp_ZK, MemberIds.GalGalData, KinPhoGalSecret);
			AddMember(AppIds.KinPhoGal, UserIds.GalData, MemberTypeIds.DataProvider);
			pSet.ElapseTime();

			AddMember(AppIds.KinPhoGal, UserIds.Zach, MemberTypeIds.Owner);
			pSet.ElapseTime();

			AddEmail("EllieJoy@zachkinstner.com");
			AddUser("EllieJoy", "iLOVEdaddy", EmailIds.EJ_ZK, MemberIds.FabEllie);
			AddMember(AppIds.FabSys, UserIds.Ellie, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddMember(AppIds.KinPhoGal, UserIds.Ellie, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddMember(AppIds.KinPhoGal, UserIds.Mel, MemberTypeIds.Admin);
			pSet.ElapseTime();

			AddEmail("PennyJane@zachkinstner.com");
			AddUser("PennyJane", "iLOVEdaddyTOO!", EmailIds.PJ_ZK, MemberIds.FabPenny);
			AddMember(AppIds.FabSys, UserIds.Penny, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddEmail("fabricApp@bookmarker.com");
			AddUser("BookmarkerDP", "bookpass", EmailIds.FabApp_Book, MemberIds.FabBookData);
			AddMember(AppIds.FabSys, UserIds.BookData, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddApp("The Bookmarker", EmailIds.FabApp_Book, MemberIds.BookBookData, BookmarkSecret);
			AddMember(AppIds.Bookmarker, UserIds.BookData, MemberTypeIds.DataProvider);
			pSet.ElapseTime();

			AddMember(AppIds.Bookmarker, UserIds.Zach, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddMember(AppIds.Bookmarker, UserIds.Mel, MemberTypeIds.Member);
			pSet.ElapseTime();

			AddMember(AppIds.KinPhoGal, UserIds.BookData, MemberTypeIds.None);
			pSet.ElapseTime();

			AddMember(AppIds.KinPhoGal, UserIds.Penny, MemberTypeIds.Member);
			pSet.ElapseTime();*/
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void AddEmail(DataSet pSet, EmailId pId, string pAddress) {
			var e = new Email();
			e.EmailId = (long)pId;
			e.Address = pAddress;
			e.Code = FabricUtil.Code32;
			e.CreatedTimestamp = pSet.SetupTimestamp;
			e.VerifiedTimestamp = pSet.SetupTimestamp+10000000;

			pSet.AddNodeAndIndex(e, x => x.EmailId, TestMode);
			pSet.AddRootRel<RootContainsEmail>(e, TestMode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static void AddMember(DataSet pSet, MemberId pId, AppId pAppId, UserId pUserId,
					MemberTypeId pMemTypeId, MemberTypeAssignId pMemTypeAssnId, MemberId pAssignerId) {
			var m = new Member();
			m.MemberId = (long)pId;

			pSet.AddNodeAndIndex(m, x => x.MemberId, TestMode);
			pSet.AddRootRel<RootContainsMember>(m, TestMode);

			var relA = DataRel.Create(m, new MemberUsesApp(),
				pSet.GetNode<App>((long)pAppId), TestMode);
			pSet.AddRel(relA);

			var relU = DataRel.Create(m, new MemberUsesUser(),
				pSet.GetNode<User>((long)pUserId), TestMode);
			pSet.AddRel(relU);

			AddMemberTypeAssign(pSet, pId, false, pMemTypeAssnId, pMemTypeId, pAssignerId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddMemberTypeAssign(DataSet pSet, MemberId pMemberId, bool pIsHistoric,
					MemberTypeAssignId pMemTypeAssnId, MemberTypeId pMemTypeId, MemberId pAssignerId) {
			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = (long)pMemTypeAssnId;

			pSet.AddNodeAndIndex(mta, x => x.MemberTypeAssignId, TestMode);
			pSet.AddRootRel<RootContainsMemberTypeAssign>(mta, TestMode);

			var relAsn = DataRel.Create(pSet.GetNode<Member>((long)pAssignerId),
				new MemberCreatesMemberTypeAssign(), mta, TestMode);
			pSet.AddRel(relAsn);

			////

			INode m = pSet.GetNode<Member>((long)pMemberId);

			if ( pIsHistoric ) {
				var relMta = DataRel.Create(m, new MemberHasHistoricMemberTypeAssign(), mta, TestMode);
				pSet.AddRel(relMta);
			}
			else {
				var relMta = DataRel.Create(m, new MemberHasMemberTypeAssign(), mta, TestMode);
				pSet.AddRel(relMta);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddApp(DataSet pSet, AppId pId, string pName, EmailId pEmailId,
																					string pSecret) {
			var a = new App();
			a.AppId = (long)pId;
			a.Name = pName;
			a.Secret = pSecret;

			pSet.AddNodeAndIndex(a, x => x.AppId, TestMode);
			pSet.AddRootRel<RootContainsApp>(a, TestMode);

			var relE = DataRel.Create(a, new AppUsesEmail(), pSet.GetNode<Email>((long)pEmailId));
			pSet.AddRel(relE);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddUser(DataSet pSet, UserId pId, string pName, string pPass, 
																					EmailId pEmailId) {
			var u = new User();
			u.UserId = (long)pId;
			u.Name = pName;
			u.Password = pPass;

			pSet.AddNodeAndIndex(u, x => x.UserId, TestMode);
			pSet.AddRootRel<RootContainsUser>(u, TestMode);

			var relE = DataRel.Create(u, new AppUsesEmail(), pSet.GetNode<Email>((long)pEmailId));
			pSet.AddRel(relE);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Artifact AddArtifact(DataSet pSet, SetupArtifacts.ArtifactId pId, 
													ArtifactTypeId pArtTypeId, MemberId pCreatorId) {
			var a = new Artifact();
			a.ArtifactId = (long)pId;
			a.IsPrivate = false;
			a.CreatedTimestamp = pSet.SetupTimestamp;

			pSet.AddNodeAndIndex(a, x => x.ArtifactId, TestMode);
			pSet.AddRootRel<RootContainsArtifact>(a, TestMode);

			var relT = DataRel.Create(a, new ArtifactUsesArtifactType(),
				pSet.GetNode<ArtifactType>((long)pArtTypeId));
			pSet.AddRel(relT);

			var relM = DataRel.Create(pSet.GetNode<Member>((long)pCreatorId),
				new MemberCreatesArtifact(), a);
			pSet.AddRel(relM);

			return a;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddUserArtifact(DataSet pSet, SetupArtifacts.ArtifactId pId, UserId pUserId,
																				MemberId pCreatorId) {
			Artifact a = AddArtifact(pSet, pId, ArtifactTypeId.User, pCreatorId);

			var rel = DataRel.Create(pSet.GetNode<User>((long)pUserId), new UserHasArtifact(), a);
			pSet.AddRel(rel);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddAppArtifact(DataSet pSet, SetupArtifacts.ArtifactId pId, AppId pAppId,
																				MemberId pCreatorId) {
			Artifact a = AddArtifact(pSet, pId, ArtifactTypeId.App, pCreatorId);

			var rel = DataRel.Create(pSet.GetNode<App>((long)pAppId), new AppHasArtifact(), a);
			pSet.AddRel(rel);
		}

	}

}