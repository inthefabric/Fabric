using System;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Database.Init.Setups {

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
			AddMember(MemberId.FabFabData, AppId.FabSys, UserId.FabData, MemberType.Id.DataProv);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_FabSys, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_FabData, MemberId.FabFabData);
			vSet.ElapseTime();

			////

			vTestMode = true;
			
			AddEmail(EmailId.Zach_AEI, "zach@aestheticinteractive.com");
			AddUser(UserId.Zach, "zachkinstner", "asdfasdf", EmailId.Zach_AEI);
			AddMember(MemberId.FabZach, AppId.FabSys, UserId.Zach, MemberType.Id.Owner);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Zach, MemberId.FabZach);
			vSet.ElapseTime();

			AddEmail(EmailId.MKin_Gmail, "mkinstner@gmail.com");
			AddUser(UserId.Mel, "melkins", "EllieBear1", EmailId.MKin_Gmail);
			AddMember(MemberId.FabMel, AppId.FabSys, UserId.Mel, MemberType.Id.Member);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Mel, MemberId.FabMel);
			vSet.ElapseTime();

			AddEmail(EmailId.PhoApp_ZK, "photoapp@zachkinstner.com");
			AddUser(UserId.GalData, "KinstnerPhotos", "snapshot1234", EmailId.PhoApp_ZK);
			AddMember(MemberId.FabGalData, AppId.FabSys, UserId.GalData, MemberType.Id.Member);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_GalData, MemberId.FabGalData);
			vSet.ElapseTime();

			AddApp(AppId.KinPhoGal, "Kinstner Photo Gallery", EmailId.PhoApp_ZK, KinPhoGalSecret);
			AddMember(MemberId.GalGalData, AppId.KinPhoGal, UserId.GalData, MemberType.Id.DataProv);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_KinPhoGal, MemberId.FabGalData);
			vSet.ElapseTime();

			AddMember(MemberId.GalZach, AppId.KinPhoGal, UserId.Zach, MemberType.Id.Owner);
			vSet.ElapseTime();

			AddEmail(EmailId.EJ_ZK, "elliejoy@zachkinstner.com");
			AddUser(UserId.Ellie, "EllieJoy", "iLOVEdaddy", EmailId.EJ_ZK);
			AddMember(MemberId.FabEllie, AppId.FabSys, UserId.Ellie, MemberType.Id.Member);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Ellie,MemberId.FabEllie);
			vSet.ElapseTime();

			AddMember(MemberId.GalEllie, AppId.KinPhoGal, UserId.Ellie, MemberType.Id.Member);
			vSet.ElapseTime();

			AddMember(MemberId.GalMel, AppId.KinPhoGal, UserId.Mel, MemberType.Id.Admin);
			vSet.ElapseTime();

			AddEmail(EmailId.PJ_ZK, "pennyjane@zachkinstner.com");
			AddUser(UserId.Penny, "PennyJane", "iLOVEdaddyTOO!", EmailId.PJ_ZK);
			AddMember(MemberId.FabPenny, AppId.FabSys, UserId.Penny, MemberType.Id.Member);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Penny, MemberId.FabPenny);
			vSet.ElapseTime();

			AddEmail(EmailId.FabApp_Book, "fabricapp@bookmarker.com");
			AddUser(UserId.BookData, "BookmarkerDP", "bookpass", EmailId.FabApp_Book);
			AddMember(MemberId.FabBookData, AppId.FabSys, UserId.BookData, MemberType.Id.Member);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_BookData, MemberId.FabBookData);
			vSet.ElapseTime();

			AddApp(AppId.Bookmarker, "The Bookmarker", EmailId.FabApp_Book, BookmarkSecret);
			AddMember(MemberId.BookBookData, AppId.Bookmarker, UserId.BookData, MemberType.Id.DataProv);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_Bookmarker,  MemberId.FabBookData);
			vSet.ElapseTime();

			AddMember(MemberId.BookZach, AppId.Bookmarker, UserId.Zach, MemberType.Id.Member);
			vSet.ElapseTime();

			AddMember(MemberId.BookMel, AppId.Bookmarker, UserId.Mel, MemberType.Id.Member);
			vSet.ElapseTime();

			AddMember(MemberId.GalBookDataNone, AppId.KinPhoGal, UserId.BookData, MemberType.Id.None);
			vSet.ElapseTime();

			AddMember(MemberId.GalPenny, AppId.KinPhoGal, UserId.Penny, MemberType.Id.Member);
			vSet.ElapseTime();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddEmail(EmailId pId, string pAddress) {
			var e = new Email();
			e.VertexId = (long)pId;
			e.Address = pAddress;
			e.Code = new Guid().ToString("N");
			e.Timestamp = vSet.SetupTimestamp;

			vSet.AddVertex(e, vTestMode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void AddMember(MemberId pId, AppId pAppId, UserId pUserId,
													MemberType.Id pMemTypeId) {
			var m = new Member();
			m.VertexId = (long)pId;
			m.MemberType = (byte)pMemTypeId;

			vSet.AddVertex(m, vTestMode);

			var edgeA = DataEdge.Create(vSet.GetVertex<App>((long)pAppId),
				new AppDefinesMember(), m, vTestMode);
			vSet.AddEdge(edgeA);

			var edgeU = DataEdge.Create(vSet.GetVertex<User>((long)pUserId),
				new UserDefinesMember(), m, vTestMode);
			vSet.AddEdge(edgeU);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddApp(AppId pId, string pName, EmailId pEmailId, string pSecret) {
			var a = new App();
			a.VertexId = (long)pId;
			a.Name = pName;
			a.NameKey = pName.ToLower();
			a.Secret = pSecret;

			vSet.AddVertex(a, vTestMode);

			var edgeE = DataEdge.Create(
				a, new ArtifactUsesEmail(), vSet.GetVertex<Email>((long)pEmailId), vTestMode);
			vSet.AddEdge(edgeE);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddUser(UserId pId, string pName, string pPass, EmailId pEmailId) {
			var u = new User();
			u.VertexId = (byte)pId;
			u.Name = pName;
			u.NameKey = pName.ToLower();
			//u.Password = FabricUtil.HashPassword(pPass); //TODO: hash password

			vSet.AddVertex(u, vTestMode);

			var edgeE = DataEdge.Create(
				u, new ArtifactUsesEmail(), vSet.GetVertex<Email>((long)pEmailId), vTestMode);
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