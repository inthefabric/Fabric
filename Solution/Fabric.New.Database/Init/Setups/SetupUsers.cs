using System;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Database.Init.Setups {

	/*================================================================================================*/
	public class SetupUsers : SetupVertices {

		/*public const int NumEmails = 7;
		public const int NumMembers = 16;
		public const int NumUsers = 7;
		public const int NumApps = 3;*/

		public const string FabSysSecret    = "abcdefghijklmnopqrstuvwxyZ012345";
		public const string KinPhoGalSecret = "0123456789abcdefghijkLMNOPqrstuv";
		public const string BookmarkSecret  = "alkjdfkusdlf7f238092fijlcsdc089f";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupUsers(DataSet pData) : base(pData) {}
			
		/*--------------------------------------------------------------------------------------------*/
		public void Create() {
			IsForTestingOnly = false;

			AddEmail(SetupEmailId.DP_ITF, "dataprov@inthefabric.com");
			AddApp(SetupAppId.FabSys, "Fabric System", SetupEmailId.DP_ITF, FabSysSecret);
			AddUser(SetupUserId.FabData, "Fabric", "DifficultToGuess", SetupEmailId.DP_ITF);
			AddMember(SetupMemberId.FabFabData, SetupAppId.FabSys, SetupUserId.FabData,
				MemberType.Id.DataProv);
			AddArtifactCreator(SetupArtifactId.App_FabSys, SetupMemberId.FabFabData);
			AddArtifactCreator(SetupArtifactId.User_FabData, SetupMemberId.FabFabData);
			Data.ElapseTime();

			IsForTestingOnly = true;
			
			AddEmail(SetupEmailId.Zach_AEI, "zach@aestheticinteractive.com");
			AddUser(SetupUserId.Zach, "zachkinstner", "asdfasdf", SetupEmailId.Zach_AEI);
			AddMember(SetupMemberId.FabZach, SetupAppId.FabSys, SetupUserId.Zach, MemberType.Id.Owner);
			AddArtifactCreator(SetupArtifactId.User_Zach, SetupMemberId.FabZach);
			Data.ElapseTime();

			AddEmail(SetupEmailId.MKin_Gmail, "mkinstner@gmail.com");
			AddUser(SetupUserId.Mel, "melkins", "EllieBear1", SetupEmailId.MKin_Gmail);
			AddMember(SetupMemberId.FabMel, SetupAppId.FabSys, SetupUserId.Mel, MemberType.Id.Member);
			AddArtifactCreator(SetupArtifactId.User_Mel, SetupMemberId.FabMel);
			Data.ElapseTime();

			AddEmail(SetupEmailId.PhoApp_ZK, "photoapp@zachkinstner.com");
			AddUser(SetupUserId.GalData, "KinstnerPhotos", "snapshot1234", SetupEmailId.PhoApp_ZK);
			AddMember(SetupMemberId.FabGalData, SetupAppId.FabSys, SetupUserId.GalData,
				MemberType.Id.Member);
			AddArtifactCreator(SetupArtifactId.User_GalData, SetupMemberId.FabGalData);
			Data.ElapseTime();

			AddApp(SetupAppId.KinPhoGal, "Kinstner Photo Gallery", SetupEmailId.PhoApp_ZK, KinPhoGalSecret);
			AddMember(SetupMemberId.GalGalData, SetupAppId.KinPhoGal, SetupUserId.GalData,
				MemberType.Id.DataProv);
			AddArtifactCreator(SetupArtifactId.App_KinPhoGal, SetupMemberId.FabGalData);
			Data.ElapseTime();

			AddMember(SetupMemberId.GalZach, SetupAppId.KinPhoGal, SetupUserId.Zach,
				MemberType.Id.Owner);
			Data.ElapseTime();

			AddEmail(SetupEmailId.EJ_ZK, "elliejoy@zachkinstner.com");
			AddUser(SetupUserId.Ellie, "EllieJoy", "iLOVEdaddy", SetupEmailId.EJ_ZK);
			AddMember(SetupMemberId.FabEllie, SetupAppId.FabSys, SetupUserId.Ellie,
				MemberType.Id.Member);
			AddArtifactCreator(SetupArtifactId.User_Ellie,SetupMemberId.FabEllie);
			Data.ElapseTime();

			AddMember(SetupMemberId.GalEllie, SetupAppId.KinPhoGal, SetupUserId.Ellie,
				MemberType.Id.Member);
			Data.ElapseTime();

			AddMember(SetupMemberId.GalMel, SetupAppId.KinPhoGal, SetupUserId.Mel, MemberType.Id.Admin);
			Data.ElapseTime();

			AddEmail(SetupEmailId.PJ_ZK, "pennyjane@zachkinstner.com");
			AddUser(SetupUserId.Penny, "PennyJane", "iLOVEdaddyTOO!", SetupEmailId.PJ_ZK);
			AddMember(SetupMemberId.FabPenny, SetupAppId.FabSys, SetupUserId.Penny,
				MemberType.Id.Member);
			AddArtifactCreator(SetupArtifactId.User_Penny, SetupMemberId.FabPenny);
			Data.ElapseTime();

			AddEmail(SetupEmailId.FabApp_Book, "fabricapp@bookmarker.com");
			AddUser(SetupUserId.BookData, "BookmarkerDP", "bookpass", SetupEmailId.FabApp_Book);
			AddMember(SetupMemberId.FabBookData, SetupAppId.FabSys, SetupUserId.BookData,
				MemberType.Id.Member);
			AddArtifactCreator(SetupArtifactId.User_BookData, SetupMemberId.FabBookData);
			Data.ElapseTime();

			AddApp(SetupAppId.Bookmarker, "The Bookmarker", SetupEmailId.FabApp_Book, BookmarkSecret);
			AddMember(SetupMemberId.BookBookData, SetupAppId.Bookmarker, SetupUserId.BookData,
				MemberType.Id.DataProv);
			AddArtifactCreator(SetupArtifactId.App_Bookmarker,  SetupMemberId.FabBookData);
			Data.ElapseTime();

			AddMember(SetupMemberId.BookZach, SetupAppId.Bookmarker, SetupUserId.Zach,
				MemberType.Id.Member);
			Data.ElapseTime();

			AddMember(SetupMemberId.BookMel, SetupAppId.Bookmarker, SetupUserId.Mel,
				MemberType.Id.Member);
			Data.ElapseTime();

			AddMember(SetupMemberId.GalBookDataNone, SetupAppId.KinPhoGal, SetupUserId.BookData,
				MemberType.Id.None);
			Data.ElapseTime();

			AddMember(SetupMemberId.GalPenny, SetupAppId.KinPhoGal, SetupUserId.Penny,
				MemberType.Id.Member);
			Data.ElapseTime();

			AddMember(SetupMemberId.BookEllie, SetupAppId.Bookmarker, SetupUserId.Ellie,
				MemberType.Id.None);
			Data.ElapseTime();

			AddMember(SetupMemberId.BookPenny, SetupAppId.Bookmarker, SetupUserId.Penny,
				MemberType.Id.None);
			Data.ElapseTime();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddEmail(SetupEmailId pId, string pAddress) {
			var e = new Email();
			e.Address = pAddress;
			e.Code = new Guid().ToString("N");
			e.Verified = true;
			AddVertex(e, (SetupVertexId)(long)pId);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void AddMember(SetupMemberId pId, SetupAppId pSetupAppId, SetupUserId pSetupUserId,
													MemberType.Id pMemTypeId) {
			var m = new Member();
			m.MemberType = (byte)pMemTypeId;
			AddVertex(m, (SetupVertexId)(long)pId);
			AddEdge(Data.GetVertex<App>((long)pSetupAppId), new AppDefinesMember(), m);
			AddEdge(Data.GetVertex<User>((long)pSetupUserId), new UserDefinesMember(), m);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddApp(SetupAppId pId, string pName, SetupEmailId pSetupEmailId, string pSecret) {
			var a = new App();
			a.Name = pName;
			a.NameKey = pName.ToLower();
			a.Secret = pSecret;
			AddArtifact(a, (SetupArtifactId)(long)pId);
			AddEdge(a, new ArtifactUsesEmail(), Data.GetVertex<Email>((long)pSetupEmailId));
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddUser(SetupUserId pId, string pName, string pPass, SetupEmailId pSetupEmailId) {
			var u = new User();
			u.Name = pName;
			u.NameKey = pName.ToLower();
			//u.Password = FabricUtil.HashPassword(pPass); //TODO: hash password
			AddArtifact(u, (SetupArtifactId)(long)pId);
			AddEdge(u, new ArtifactUsesEmail(), Data.GetVertex<Email>((long)pSetupEmailId));
		}

	}

}