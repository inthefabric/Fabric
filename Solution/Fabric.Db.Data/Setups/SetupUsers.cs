using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Domain;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class SetupUsers {

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
			GalBookDataNone,
			GalPenny
		}

		public enum MemberTypeAssignId {
			FabFabDataBySystem = 1,
			FabZachBySystem,
			FabMelBySystem,
			FabGalDataBySystem,
			GalGalDataBySystem,
			GalZachByGalGalData,
			FabEllieBySystem,
			GalEllieBySystem,
			GalMelByGalGalData,
			FabPennyBySystem,
			FabBookDataBySystem,
			BookBookDataBySystem,
			BookZachBySystem,
			BookMelBySystem,
			GalBookDataNoneByBookBookData,
			GalPennyBySystem
		}

		public enum UserId {
			FabData = SetupArtifacts.ArtifactId.User_FabData,
			Zach = SetupArtifacts.ArtifactId.User_Zach,
			Mel = SetupArtifacts.ArtifactId.User_Mel,
			GalData = SetupArtifacts.ArtifactId.User_GalData,
			Ellie = SetupArtifacts.ArtifactId.User_Ellie,
			Penny = SetupArtifacts.ArtifactId.User_Penny,
			BookData = SetupArtifacts.ArtifactId.User_BookData
		}

		public enum AppId {
			FabSys = SetupArtifacts.ArtifactId.App_FabSys,
			KinPhoGal = SetupArtifacts.ArtifactId.App_KinPhoGal,
			Bookmarker = SetupArtifacts.ArtifactId.App_Bookmarker
		}

		public const int NumEmails = 7;
		public const int NumMembers = 16;
		public const int NumUsers = 7;
		public const int NumApps = 3;
		public const int NumResetpasses = 0;

		public const string FabSysSecret    = "abcdefghijklmnopqrstuvwxyZ012345";
		public const string KinPhoGalSecret = "0123456789abcdefghijkLMNOPqrstuv";
		public const string BookmarkSecret  = "alkjdfkusdlf7f238092fijlcsdc089f";

		private readonly DataSet vSet;
		private readonly bool vTestMode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			var su = new SetupUsers(pSet);
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupUsers(DataSet pSet) {
			vSet = pSet;
			vTestMode = false;

			AddEmail(EmailId.DP_ITF, "dataprov@inthefabric.com");
			AddApp(AppId.FabSys, "Fabric System", EmailId.DP_ITF, FabSysSecret);
			AddUser(UserId.FabData, "Fabric", "DifficultToGuess", EmailId.DP_ITF);
			AddMember(MemberId.FabFabData, AppId.FabSys, UserId.FabData,
				MemberTypeId.DataProvider, MemberTypeAssignId.FabFabDataBySystem, MemberId.FabFabData);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_FabSys, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_FabData, MemberId.FabFabData);
			vSet.ElapseTime();

			////

			vTestMode = true;
			
			AddEmail(EmailId.Zach_AEI, "zach@aestheticinteractive.com");
			AddUser(UserId.Zach, "zachkinstner", "asdfasdf", EmailId.Zach_AEI);
			AddMember(MemberId.FabZach, AppId.FabSys, UserId.Zach,
				MemberTypeId.Owner, MemberTypeAssignId.FabZachBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Zach, MemberId.FabZach);
			vSet.ElapseTime();

			AddEmail(EmailId.MKin_Gmail, "mkinstner@gmail.com");
			AddUser(UserId.Mel, "melkins", "EllieBear1", EmailId.MKin_Gmail);
			AddMember(MemberId.FabMel, AppId.FabSys, UserId.Mel,
				MemberTypeId.Member, MemberTypeAssignId.FabMelBySystem, MemberId.FabMel);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Mel, MemberId.FabMel);
			vSet.ElapseTime();

			AddEmail(EmailId.PhoApp_ZK, "photoapp@zachkinstner.com");
			AddUser(UserId.GalData, "KinstnerPhotos", "snapshot1234", EmailId.PhoApp_ZK);
			AddMember(MemberId.FabGalData, AppId.FabSys, UserId.GalData,
				MemberTypeId.Member, MemberTypeAssignId.FabGalDataBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_GalData, MemberId.FabGalData);
			vSet.ElapseTime();

			AddApp(AppId.KinPhoGal, "Kinstner Photo Gallery", EmailId.PhoApp_ZK, KinPhoGalSecret);
			AddMember(MemberId.GalGalData, AppId.KinPhoGal, UserId.GalData,
				MemberTypeId.DataProvider, MemberTypeAssignId.GalGalDataBySystem, MemberId.FabFabData);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_KinPhoGal, MemberId.FabGalData);
			vSet.ElapseTime();

			AddMember(MemberId.GalZach, AppId.KinPhoGal, UserId.Zach,
				MemberTypeId.Owner, MemberTypeAssignId.GalZachByGalGalData, MemberId.GalGalData);
			vSet.ElapseTime();

			AddEmail(EmailId.EJ_ZK, "elliejoy@zachkinstner.com");
			AddUser(UserId.Ellie, "EllieJoy", "iLOVEdaddy", EmailId.EJ_ZK);
			AddMember(MemberId.FabEllie, AppId.FabSys, UserId.Ellie,
				MemberTypeId.Member, MemberTypeAssignId.FabEllieBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Ellie,MemberId.FabEllie);
			vSet.ElapseTime();

			AddMember(MemberId.GalEllie, AppId.KinPhoGal, UserId.Ellie,
				MemberTypeId.Member, MemberTypeAssignId.GalEllieBySystem, MemberId.FabFabData);
			vSet.ElapseTime();

			AddMember(MemberId.GalMel, AppId.KinPhoGal, UserId.Mel,
				MemberTypeId.Admin, MemberTypeAssignId.GalMelByGalGalData, MemberId.GalGalData);
			vSet.ElapseTime();

			AddEmail(EmailId.PJ_ZK, "pennyjane@zachkinstner.com");
			AddUser(UserId.Penny, "PennyJane", "iLOVEdaddyTOO!", EmailId.PJ_ZK);
			AddMember(MemberId.FabPenny, AppId.FabSys, UserId.Penny,
				MemberTypeId.Member, MemberTypeAssignId.FabPennyBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Penny, MemberId.FabPenny);
			vSet.ElapseTime();

			AddEmail(EmailId.FabApp_Book, "fabricapp@bookmarker.com");
			AddUser(UserId.BookData, "BookmarkerDP", "bookpass", EmailId.FabApp_Book);
			AddMember(MemberId.FabBookData, AppId.FabSys, UserId.BookData,
				MemberTypeId.Member, MemberTypeAssignId.FabBookDataBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_BookData, MemberId.FabBookData);
			vSet.ElapseTime();

			AddApp(AppId.Bookmarker, "The Bookmarker", EmailId.FabApp_Book, BookmarkSecret);
			AddMember(MemberId.BookBookData, AppId.Bookmarker, UserId.BookData,
				MemberTypeId.DataProvider, MemberTypeAssignId.BookBookDataBySystem, MemberId.FabFabData);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_Bookmarker,  MemberId.FabBookData);
			vSet.ElapseTime();

			AddMember(MemberId.BookZach, AppId.Bookmarker, UserId.Zach,
				MemberTypeId.Member, MemberTypeAssignId.BookZachBySystem, MemberId.FabFabData);
			vSet.ElapseTime();

			AddMember(MemberId.BookMel, AppId.Bookmarker, UserId.Mel,
				MemberTypeId.Member, MemberTypeAssignId.BookMelBySystem, MemberId.FabFabData);
			vSet.ElapseTime();

			AddMember(MemberId.GalBookDataNone, AppId.KinPhoGal, UserId.BookData, MemberTypeId.None,
				MemberTypeAssignId.GalBookDataNoneByBookBookData, MemberId.BookBookData);
			vSet.ElapseTime();

			AddMember(MemberId.GalPenny, AppId.KinPhoGal, UserId.Penny,
				MemberTypeId.Member, MemberTypeAssignId.GalPennyBySystem, MemberId.FabFabData);
			vSet.ElapseTime();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddEmail(EmailId pId, string pAddress) {
			var e = new Email();
			e.EmailId = (long)pId;
			e.Address = pAddress;
			e.Code = FabricUtil.Code32;
			e.Created = vSet.SetupTimestamp;
			e.Verified = vSet.SetupTimestamp+10000000;

			vSet.AddVertex(e, vTestMode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void AddMember(MemberId pId, AppId pAppId, UserId pUserId,
					MemberTypeId pMemTypeId, MemberTypeAssignId pMemTypeAssnId, MemberId pAssignerId) {
			var m = new Member();
			m.MemberId = (long)pId;

			vSet.AddVertex(m, vTestMode);

			var edgeA = DataEdge.Create(vSet.GetVertex<App>((long)pAppId),
				new AppDefinesMember(), m, vTestMode);
			vSet.AddEdge(edgeA);

			var edgeU = DataEdge.Create(vSet.GetVertex<User>((long)pUserId),
				new UserDefinesMember(), m, vTestMode);
			vSet.AddEdge(edgeU);

			AddMemberTypeAssign(pId, false, pMemTypeAssnId, pMemTypeId, pAssignerId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberTypeAssign(MemberId pMemberId, bool pIsHistoric,
					MemberTypeAssignId pMemTypeAssnId, MemberTypeId pMemTypeId, MemberId pAssignerId) {
			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = (long)pMemTypeAssnId;
			mta.MemberTypeId = (byte)pMemTypeId;
			mta.Performed = vSet.SetupTimestamp;

			vSet.AddVertex(mta, vTestMode);

			var edgeAsn = DataEdge.Create(vSet.GetVertex<Member>((long)pAssignerId),
				new MemberCreatesMemberTypeAssign(), mta, vTestMode);
			vSet.AddEdge(edgeAsn);

			////

			Member m = vSet.GetVertex<Member>((long)pMemberId);

			if ( pIsHistoric ) {
				var edgeMta = DataEdge.Create(m, new MemberHasHistoricMemberTypeAssign(), mta, vTestMode);
				vSet.AddEdge(edgeMta);
			}
			else {
				var edgeMta = DataEdge.Create(m, new MemberHasMemberTypeAssign(), mta, vTestMode);
				vSet.AddEdge(edgeMta);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddApp(AppId pId, string pName, EmailId pEmailId, string pSecret) {
			var a = new App();
			a.ArtifactId = (long)pId;
			a.Name = pName;
			a.NameKey = pName.ToLower();
			a.Secret = pSecret;

			vSet.AddVertex(a, vTestMode);

			var edgeE = DataEdge.Create(
				a, new AppUsesEmail(), vSet.GetVertex<Email>((long)pEmailId), vTestMode);
			vSet.AddEdge(edgeE);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddUser(UserId pId, string pName, string pPass, EmailId pEmailId) {
			var u = new User();
			u.ArtifactId = (byte)pId;
			u.Name = pName;
			u.NameKey = pName.ToLower();
			u.Password = FabricUtil.HashPassword(pPass);

			vSet.AddVertex(u, vTestMode);

			var edgeE = DataEdge.Create(
				u, new UserUsesEmail(), vSet.GetVertex<Email>((long)pEmailId), vTestMode);
			vSet.AddEdge(edgeE);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillUserArtifact(SetupArtifacts.ArtifactId pId, MemberId pCreatorId) {
			User user = vSet.GetVertex<User>((long)pId);
			SetupArtifacts.FillArtifact(vSet, user, pId, pCreatorId, vTestMode);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FillAppArtifact(SetupArtifacts.ArtifactId pId, MemberId pCreatorId) {
			App app = vSet.GetVertex<App>((long)pId);
			SetupArtifacts.FillArtifact(vSet, app, pId, pCreatorId, vTestMode);
		}

	}

}