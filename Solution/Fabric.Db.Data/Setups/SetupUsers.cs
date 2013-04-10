﻿using Fabric.Domain;
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
			FillAppArtifact(SetupArtifacts.ArtifactId.App_FabSys, AppId.FabSys, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_FabData, UserId.FabData,MemberId.FabFabData);
			vSet.ElapseTime();

			////

			vTestMode = true;
			
			AddEmail(EmailId.Zach_AEI, "zach@aestheticinteractive.com");
			AddUser(UserId.Zach, "zachkinstner", "asdfasdf", EmailId.Zach_AEI);
			AddMember(MemberId.FabZach, AppId.FabSys, UserId.Zach,
				MemberTypeId.Owner, MemberTypeAssignId.FabZachBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Zach, UserId.Zach, MemberId.FabZach);
			vSet.ElapseTime();

			AddEmail(EmailId.MKin_Gmail, "mkinstner@gmail.com");
			AddUser(UserId.Mel, "melkins", "EllieBear1", EmailId.MKin_Gmail);
			AddMember(MemberId.FabMel, AppId.FabSys, UserId.Mel,
				MemberTypeId.Member, MemberTypeAssignId.FabMelBySystem, MemberId.FabMel);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Mel, UserId.Mel, MemberId.FabMel);
			vSet.ElapseTime();

			AddEmail(EmailId.PhoApp_ZK, "PhotoApp@zachkinstner.com");
			AddUser(UserId.GalData, "KinstnerPhotos", "snapshot1234", EmailId.PhoApp_ZK);
			AddMember(MemberId.FabGalData, AppId.FabSys, UserId.GalData,
				MemberTypeId.Member, MemberTypeAssignId.FabGalDataBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_GalData, UserId.GalData,MemberId.FabGalData);
			vSet.ElapseTime();

			AddApp(AppId.KinPhoGal, "Kinstner Photo Gallery", EmailId.PhoApp_ZK, KinPhoGalSecret);
			AddMember(MemberId.GalGalData, AppId.KinPhoGal, UserId.GalData,
				MemberTypeId.DataProvider, MemberTypeAssignId.GalGalDataBySystem, MemberId.FabFabData);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_KinPhoGal,
				AppId.KinPhoGal, MemberId.FabGalData);
			vSet.ElapseTime();

			AddMember(MemberId.GalZach, AppId.KinPhoGal, UserId.Zach,
				MemberTypeId.Owner, MemberTypeAssignId.GalZachByGalGalData, MemberId.GalGalData);
			vSet.ElapseTime();

			AddEmail(EmailId.EJ_ZK, "EllieJoy@zachkinstner.com");
			AddUser(UserId.Ellie, "EllieJoy", "iLOVEdaddy", EmailId.EJ_ZK);
			AddMember(MemberId.FabEllie, AppId.FabSys, UserId.Ellie,
				MemberTypeId.Member, MemberTypeAssignId.FabEllieBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Ellie, UserId.Ellie, MemberId.FabEllie);
			vSet.ElapseTime();

			AddMember(MemberId.GalEllie, AppId.KinPhoGal, UserId.Ellie,
				MemberTypeId.Member, MemberTypeAssignId.GalEllieBySystem, MemberId.FabFabData);
			vSet.ElapseTime();

			AddMember(MemberId.GalMel, AppId.KinPhoGal, UserId.Mel,
				MemberTypeId.Admin, MemberTypeAssignId.GalMelByGalGalData, MemberId.GalGalData);
			vSet.ElapseTime();

			AddEmail(EmailId.PJ_ZK, "PennyJane@zachkinstner.com");
			AddUser(UserId.Penny, "PennyJane", "iLOVEdaddyTOO!", EmailId.PJ_ZK);
			AddMember(MemberId.FabPenny, AppId.FabSys, UserId.Penny,
				MemberTypeId.Member, MemberTypeAssignId.FabPennyBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_Penny, UserId.Penny, MemberId.FabPenny);
			vSet.ElapseTime();

			AddEmail(EmailId.FabApp_Book, "fabricApp@bookmarker.com");
			AddUser(UserId.BookData, "BookmarkerDP", "bookpass", EmailId.FabApp_Book);
			AddMember(MemberId.FabBookData, AppId.FabSys, UserId.BookData,
				MemberTypeId.Member, MemberTypeAssignId.FabBookDataBySystem, MemberId.FabFabData);
			FillUserArtifact(SetupArtifacts.ArtifactId.User_BookData,
				UserId.BookData, MemberId.FabBookData);
			vSet.ElapseTime();

			AddApp(AppId.Bookmarker, "The Bookmarker", EmailId.FabApp_Book, BookmarkSecret);
			AddMember(MemberId.BookBookData, AppId.Bookmarker, UserId.BookData,
				MemberTypeId.DataProvider, MemberTypeAssignId.BookBookDataBySystem, MemberId.FabFabData);
			FillAppArtifact(SetupArtifacts.ArtifactId.App_Bookmarker,
				AppId.Bookmarker, MemberId.FabBookData);
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

			vSet.AddNodeAndIndex(e, x => x.EmailId, vTestMode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void AddMember(MemberId pId, AppId pAppId, UserId pUserId,
					MemberTypeId pMemTypeId, MemberTypeAssignId pMemTypeAssnId, MemberId pAssignerId) {
			var m = new Member();
			m.MemberId = (long)pId;

			vSet.AddNodeAndIndex(m, x => x.MemberId, vTestMode);

			var relA = DataRel.Create(vSet.GetNode<App>((long)pAppId),
				new AppDefinesMember(), m, vTestMode);
			vSet.AddRel(relA);

			var relU = DataRel.Create(vSet.GetNode<User>((long)pUserId),
				new UserDefinesMember(), m, vTestMode);
			vSet.AddRel(relU);

			AddMemberTypeAssign(pId, false, pMemTypeAssnId, pMemTypeId, pAssignerId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberTypeAssign(MemberId pMemberId, bool pIsHistoric,
					MemberTypeAssignId pMemTypeAssnId, MemberTypeId pMemTypeId, MemberId pAssignerId) {
			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = (long)pMemTypeAssnId;
			mta.MemberTypeId = (byte)pMemTypeId;
			mta.Performed = vSet.SetupTimestamp;

			vSet.AddNodeAndIndex(mta, x => x.MemberTypeAssignId, vTestMode);

			var relAsn = DataRel.Create(vSet.GetNode<Member>((long)pAssignerId),
				new MemberCreatesMemberTypeAssign(), mta, vTestMode);
			vSet.AddRel(relAsn);

			////

			Member m = vSet.GetNode<Member>((long)pMemberId);

			if ( pIsHistoric ) {
				var relMta = DataRel.Create(m, new MemberHasHistoricMemberTypeAssign(), mta, vTestMode);
				vSet.AddRel(relMta);
			}
			else {
				var relMta = DataRel.Create(m, new MemberHasMemberTypeAssign(), mta, vTestMode);
				vSet.AddRel(relMta);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddApp(AppId pId, string pName, EmailId pEmailId, string pSecret) {
			var a = new App();
			a.AppId = (long)pId;
			a.Name = pName;
			a.Secret = pSecret;

			vSet.AddNodeAndIndex(a, x => x.AppId, vTestMode);

			var relE = DataRel.Create(
				a, new AppUsesEmail(), vSet.GetNode<Email>((long)pEmailId), vTestMode);
			vSet.AddRel(relE);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddUser(UserId pId, string pName, string pPass, EmailId pEmailId) {
			var u = new User();
			u.UserId = (long)pId;
			u.Name = pName;
			u.Password = FabricUtil.HashPassword(pPass);

			vSet.AddNodeAndIndex(u, x => x.UserId, vTestMode);

			var relE = DataRel.Create(
				u, new UserUsesEmail(), vSet.GetNode<Email>((long)pEmailId), vTestMode);
			vSet.AddRel(relE);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillUserArtifact(SetupArtifacts.ArtifactId pId, UserId pUserId,
																				MemberId pCreatorId) {
			Artifact user = vSet.GetNode<User>((long)pUserId);
			SetupArtifacts.FillArtifact(vSet, user, pId, pCreatorId, vTestMode);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FillAppArtifact(SetupArtifacts.ArtifactId pId, AppId pAppId, MemberId pCreatorId) {
			Artifact app = vSet.GetNode<App>((long)pAppId);
			SetupArtifacts.FillArtifact(vSet, app, pId, pCreatorId, vTestMode);
		}

	}

}