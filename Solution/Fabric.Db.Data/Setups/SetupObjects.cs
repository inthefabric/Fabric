using Fabric.Domain;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class SetupObjects {
		
		public enum UrlId {
			ZachKin = 1,
			Google,
			ZachFb,
			YahooFin,
			CutePhoto
		}
		
		/*public enum LabelId {
			A1234 = 1,
			EpicFail,
			LOL
		}
		
		public enum CrowdId {
			Test1 = 1,
			Test2,
			ZachFamCir,
			ZachWorkCir,
			MelFamCir,
			PhoCrit,
			PhoLove,
			Crowd3,
			DataProv
		}
		
		public enum CrowdianId {
			Test1_Zach = 1,
			Test1_Mel,
			Test1_Ellie,
			Test1_FabData,
			Test1_GalData,
			Test1_BookData,
			Test1_Penny,

			ZachFam_Zach,
			ZachFam_Mel,
			ZachFam_Ellie,
			ZachFam_Penny,

			ZachWork_Zach,
			ZachWork_FabData,
			ZachWork_GalData,
			ZachWork_BookData,
			ZachWork_Mel,

			MelFam_Mel,
			MelFam_Zach,
			MelFam_Ellie,
			MelFam_Penny,

			Crit_GalData,
			Crit_Zach,
			Crit_Mel,
			Crit_Ellie,

			Love_Mel,
			Love_Zach,
			Love_Ellie,
			Love_GalData,

			Dp_FabData,
			Dp_GalData,
			Dp_BookData
		}

		public enum CrowdianTypeAssignId {
			T1ZachAdminByZach = 1,
			T1MelAdminByZach,
			T1EllieMemberByMel,
			T1FabMemberByZach,
			T1GalMemberByZach,
			T1BookMemberByZach,
			T1PennyMemberByMel,

			ZfZachAdminByZach,
			ZfMelMemberByZach,
			ZfEllieMemberByZach,
			ZfPennyMemberByZach,

			ZwZachAdminByZach,
			ZwFabMemberByZach,
			ZwGalMemberByZach,
			ZwBookMemberByZach,
			ZwMelMemberByZach,

			MfMelAdminByMel,
			MfZachMemberByMel,
			MfEllieMemberByMel,
			MfPennyMemberByMel,

			CritGalAdminByGal,
			CriZachIntiveByGal,
			CritMelInviteByGal,
			CritEllieRequestByElie,

			LoveMelAdminByMel,
			LoveZachRequestByZach,
			LoveEllieMemberByMel,
			LoveGalMemberByMel,

			DpFabAdminByFab,
			DbGalMemberByFab,
			DbBookMemberByFab
		}*/

		public enum ClassId {
			Human = 1,
			Male,
			Female,
			Name,
			Legal,
			Home,
			Muskegon,
			Location,
			Caldonia,
			Attend,
			GradePointAvg,
			ACTTest,
			Overall,
			Software,
			Art,
			Graphics,
			Games,
			Music,
			Evolution,
			ArtificialIntel,
			Physics,
			Height,
			Weight,
			Beauty,
			MlbGame,
			Inning,
			Attendance,
			Excitement,
			WebPage,
			Photo,
			Digital,
			Favorite,
			FocalLength,
			Exposure,
			FStop,
			IsoSpeed,
			Quality,
			Subject,
			Object,
			Smile,
			Pigtail,
			Rope,
			Blue,
			Swing,
			Happiness,
			Fun,
			Cuteness
		}

		public enum InstanceId {
			Neimeyer = 1,
			CampusView,
			AppleRidge,
			FabricPlatform,
			ReethsPufferHS,
			GrandValley,
			AestheticInteractive,
			TigersGame,
			DetroitTigers,
			BostonRedSox,
			ComericaPark,
			Bottom11,
			CutePhoto,
			FisherPrice
		}
		
		public const int NumUrls = 5;
		public const int NumLabels = 3;
		public const int NumCrowds = 9;
		public const int NumCrowdians = 31;
		public const int NumClasses = 45;
		public const int NumInstances = 16;

		public const string ThingGvsuName = "Grand Valley State University";
		public const string ThingGvsuDisamb = "Allendale, MI";

		private readonly DataSet vSet;
		private readonly bool vTestMode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			var so = new SetupObjects(pSet);
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupObjects(DataSet pSet) {
			vSet = pSet;
			vTestMode = true;

			AddUrl(UrlId.ZachKin, "http://zachkinstner.com", "ZachKinstner.com", 
				SetupArtifacts.ArtifactId.Url_ZachKin, SetupUsers.MemberId.BookZach);
			AddUrl(UrlId.Google, "http://google.com", "Google Homepage",
				SetupArtifacts.ArtifactId.Url_Google, SetupUsers.MemberId.BookMel);
			AddUrl(UrlId.ZachFb, "http://facebook.com/zachkinstner", "ZK@FB",
				SetupArtifacts.ArtifactId.Url_ZachFb, SetupUsers.MemberId.GalZach);
			AddUrl(UrlId.YahooFin, "http://finance.yahoo.com", "Financial News",
				SetupArtifacts.ArtifactId.Url_YahooFin, SetupUsers.MemberId.BookZach);
			AddUrl(UrlId.CutePhoto, "http://zachkinstner.com/gallery/photo/view/4165",
				"Super Cute Photo", SetupArtifacts.ArtifactId.Url_CutePhoto,SetupUsers.MemberId.GalMel);

			/*AddLabel(LabelId.A1234, "A1234",
				SetupArtifacts.ArtifactId.Label_A1234, SetupUsers.MemberId.BookZach);
			AddLabel(LabelId.EpicFail, "Epic Fail",
				SetupArtifacts.ArtifactId.Label_EpicFail, SetupUsers.MemberId.GalZach);
			AddLabel(LabelId.LOL, "LOL!",
				SetupArtifacts.ArtifactId.Label_LOL, SetupUsers.MemberId.GalMel);
			
			AddCrowd(CrowdId.Test1, "Crowd Test 1", "The first crowd.", false, false, 
				SetupArtifacts.ArtifactId.Cro_Test1, SetupUsers.MemberId.FabFabData);
			AddCrowd(CrowdId.Test2, "Crowd Test 2", "The second crowd.", false, true,
				SetupArtifacts.ArtifactId.Cro_Test2, SetupUsers.MemberId.FabFabData);
			AddCrowd(CrowdId.ZachFamCir, "Family", "Zach's circle.", true, true,
				SetupArtifacts.ArtifactId.Cro_ZachFamCir, SetupUsers.MemberId.GalZach);
			AddCrowd(CrowdId.ZachWorkCir, "Work", "Zach's circe.", true, true,
				SetupArtifacts.ArtifactId.Cro_ZachWorkCir, SetupUsers.MemberId.GalZach);
			AddCrowd(CrowdId.MelFamCir, "Family", "Mel's circle,", true, true,
				SetupArtifacts.ArtifactId.Cro_MelFamCir, SetupUsers.MemberId.BookMel);
			AddCrowd(CrowdId.PhoCrit, "Photo Critics", "Bash bad photos.", false, true,
				SetupArtifacts.ArtifactId.Cro_PhoCrit, SetupUsers.MemberId.GalZach);
			AddCrowd(CrowdId.PhoLove, "Photo Lovers", "Love good photos.", false, false,
				SetupArtifacts.ArtifactId.Cro_PhoLove, SetupUsers.MemberId.GalMel);
			AddCrowd(CrowdId.Crowd3, "Crowd 3", "empty test crowd.", false, false,
				SetupArtifacts.ArtifactId.Cro_Crowd3, SetupUsers.MemberId.BookZach);
			AddCrowd(CrowdId.DataProv, "Data Providers", "Only DPs.", false, true,
				SetupArtifacts.ArtifactId.Cro_DataProv, SetupUsers.MemberId.FabFabData);

			const SetupUsers.ArtifactId fabData = SetupUsers.ArtifactId.FabData;
			const SetupUsers.ArtifactId galData = SetupUsers.ArtifactId.GalData;
			const SetupUsers.ArtifactId bookData = SetupUsers.ArtifactId.BookData;
			const SetupUsers.ArtifactId zach = SetupUsers.ArtifactId.Zach;
			const SetupUsers.ArtifactId mel = SetupUsers.ArtifactId.Mel;
			const SetupUsers.ArtifactId ellie = SetupUsers.ArtifactId.Ellie;
			const SetupUsers.ArtifactId penny = SetupUsers.ArtifactId.Penny;

			AddCrowdian(CrowdianId.Test1_Zach, CrowdId.Test1, zach, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.T1ZachAdminByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.Test1_Mel, CrowdId.Test1, mel, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.T1MelAdminByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.Test1_Ellie, CrowdId.Test1, ellie, CrowdianTypeId.Member, 0.5f,
				CrowdianTypeAssignId.T1EllieMemberByMel, SetupUsers.ArtifactId.Mel);
			AddCrowdian(CrowdianId.Test1_FabData, CrowdId.Test1, fabData, CrowdianTypeId.Member, 0.2f,
				CrowdianTypeAssignId.T1FabMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.Test1_GalData, CrowdId.Test1, galData, CrowdianTypeId.Member, 0.3f,
				CrowdianTypeAssignId.T1GalMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.Test1_BookData, CrowdId.Test1, bookData, CrowdianTypeId.Member, 0.1f,
				CrowdianTypeAssignId.T1BookMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.Test1_Penny, CrowdId.Test1, penny, CrowdianTypeId.Member, 0.5f,
				CrowdianTypeAssignId.T1PennyMemberByMel, SetupUsers.ArtifactId.Mel);

			AddCrowdian(CrowdianId.ZachFam_Zach, CrowdId.ZachFamCir, zach, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.ZfZachAdminByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachFam_Mel, CrowdId.ZachFamCir, mel, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.ZfMelMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachFam_Ellie, CrowdId.ZachFamCir, ellie, CrowdianTypeId.Member,1.0f,
				CrowdianTypeAssignId.ZfEllieMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachFam_Penny, CrowdId.ZachFamCir, penny, CrowdianTypeId.Member,1.0f,
				CrowdianTypeAssignId.ZfPennyMemberByZach, SetupUsers.ArtifactId.Zach);

			AddCrowdian(CrowdianId.ZachWork_Zach, CrowdId.ZachWorkCir, zach, CrowdianTypeId.Admin, 0.2f,
				CrowdianTypeAssignId.ZwZachAdminByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachWork_FabData, CrowdId.ZachWorkCir, fabData,CrowdianTypeId.Member,
				1.0f, CrowdianTypeAssignId.ZwFabMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachWork_GalData, CrowdId.ZachWorkCir, galData,CrowdianTypeId.Member,
				1.0f, CrowdianTypeAssignId.ZwGalMemberByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachWork_BookData, CrowdId.ZachWorkCir, bookData,
				CrowdianTypeId.Member, 1.0f, CrowdianTypeAssignId.ZwBookMemberByZach,
				SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.ZachWork_Mel, CrowdId.ZachWorkCir, mel, CrowdianTypeId.Member, 0.2f,
				CrowdianTypeAssignId.ZwMelMemberByZach, SetupUsers.ArtifactId.Zach);

			AddCrowdian(CrowdianId.MelFam_Mel, CrowdId.MelFamCir, mel, CrowdianTypeId.Admin, 0.0f,
				CrowdianTypeAssignId.MfMelAdminByMel, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.MelFam_Zach, CrowdId.MelFamCir, zach, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.MfZachMemberByMel, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.MelFam_Ellie, CrowdId.MelFamCir, ellie, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.MfEllieMemberByMel, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.MelFam_Penny, CrowdId.MelFamCir, penny, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.MfPennyMemberByMel, SetupUsers.ArtifactId.Zach);

			AddCrowdian(CrowdianId.Crit_GalData, CrowdId.PhoCrit, galData, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.CritGalAdminByGal, SetupUsers.ArtifactId.GalData);
			AddCrowdian(CrowdianId.Crit_Zach, CrowdId.PhoCrit, zach, CrowdianTypeId.Invite, 0.0f,
				CrowdianTypeAssignId.CriZachIntiveByGal, SetupUsers.ArtifactId.GalData);
			AddCrowdian(CrowdianId.Crit_Mel, CrowdId.PhoCrit, mel, CrowdianTypeId.Invite, 0.0f,
				CrowdianTypeAssignId.CritMelInviteByGal, SetupUsers.ArtifactId.GalData);
			AddCrowdian(CrowdianId.Crit_Ellie, CrowdId.PhoCrit, ellie, CrowdianTypeId.Request, 0.0f,
				CrowdianTypeAssignId.CritEllieRequestByElie, SetupUsers.ArtifactId.Ellie);

			AddCrowdian(CrowdianId.Love_Mel, CrowdId.PhoLove, mel, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.LoveMelAdminByMel, SetupUsers.ArtifactId.Mel);
			AddCrowdian(CrowdianId.Love_Zach, CrowdId.PhoLove, zach, CrowdianTypeId.Request, 0.0f,
				CrowdianTypeAssignId.LoveZachRequestByZach, SetupUsers.ArtifactId.Zach);
			AddCrowdian(CrowdianId.Love_Ellie, CrowdId.PhoLove, ellie, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.LoveEllieMemberByMel, SetupUsers.ArtifactId.Mel);
			AddCrowdian(CrowdianId.Love_GalData, CrowdId.PhoLove, galData, CrowdianTypeId.Member, 0.5f,
				CrowdianTypeAssignId.LoveGalMemberByMel, SetupUsers.ArtifactId.Mel);

			AddCrowdian(CrowdianId.Dp_FabData, CrowdId.DataProv, fabData, CrowdianTypeId.Admin, 0.0f,
				CrowdianTypeAssignId.DpFabAdminByFab, SetupUsers.ArtifactId.FabData);
			AddCrowdian(CrowdianId.Dp_GalData, CrowdId.DataProv, galData, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.DbGalMemberByFab, SetupUsers.ArtifactId.FabData);
			AddCrowdian(CrowdianId.Dp_BookData, CrowdId.DataProv, bookData, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.DbBookMemberByFab, SetupUsers.ArtifactId.FabData);
			*/

			const SetupUsers.MemberId ffd = SetupUsers.MemberId.FabFabData;
			const SetupUsers.MemberId ggd = SetupUsers.MemberId.GalGalData;
			const SetupUsers.MemberId bbd = SetupUsers.MemberId.BookBookData;

			AddClass(ClassId.Human, "Human", null, SetupArtifacts.ArtifactId.Thi_Human, ffd);
			AddClass(ClassId.Male, "Male", null, SetupArtifacts.ArtifactId.Thi_Male, ffd);
			AddClass(ClassId.Female, "Female", null, SetupArtifacts.ArtifactId.Thi_Female, ffd);
			AddClass(ClassId.Name, "Name", null, SetupArtifacts.ArtifactId.Thi_Name, ffd);
			AddClass(ClassId.Legal, "Legal", null, SetupArtifacts.ArtifactId.Thi_Legal, ffd);
			AddClass(ClassId.Home, "Home", null, SetupArtifacts.ArtifactId.Thi_Home, ffd);
			AddClass(ClassId.Muskegon, "Muskegon", "MI, USA",
				SetupArtifacts.ArtifactId.Thi_Muskegon, ffd);
			AddInstance(InstanceId.Neimeyer, "Neimeyer Living Center", "GVSU", 
				SetupArtifacts.ArtifactId.Thi_Neimeyer, ffd);
			AddInstance(InstanceId.CampusView, "Campus View Apartments", "Allendale, MI", 
				SetupArtifacts.ArtifactId.Thi_CampusView, ffd);
			AddClass(ClassId.Location, "Location", "geographical", 
				SetupArtifacts.ArtifactId.Thi_Location, ffd);
			AddInstance(InstanceId.AppleRidge, "Apple Ridge Apartments", "Standale, MI", 
				SetupArtifacts.ArtifactId.Thi_AppleRidge, ffd);
			AddClass(ClassId.Caldonia, "Caldonia", "MI, USA", 
				SetupArtifacts.ArtifactId.Thi_Caldonia, ffd);
			AddInstance(InstanceId.FabricPlatform, "Fabric Platform", null, 
				SetupArtifacts.ArtifactId.Thi_FabricPlat, ffd);
			AddClass(ClassId.Attend, "Attend", null, SetupArtifacts.ArtifactId.Thi_Attend, ffd);
			AddInstance(InstanceId.ReethsPufferHS, "Reeths Puffer High School", "Muskegon, MI, USA", 
				SetupArtifacts.ArtifactId.Thi_RPHS, ffd);
			AddClass(ClassId.GradePointAvg, "Grade Point Average", null, 
				SetupArtifacts.ArtifactId.Thi_GradePointAvg, ffd);
			AddClass(ClassId.ACTTest, "ACT Test", null, SetupArtifacts.ArtifactId.Thi_ACTTest, ffd);
			AddClass(ClassId.Overall, "Overall", null, SetupArtifacts.ArtifactId.Thi_Overall, ffd);
			AddInstance(InstanceId.GrandValley, ThingGvsuName, ThingGvsuDisamb, 
				SetupArtifacts.ArtifactId.Thi_GrandValley, ffd);
			AddInstance(InstanceId.AestheticInteractive, "Aesthetic Interactive", "software firm", 
				SetupArtifacts.ArtifactId.Thi_Aei, ffd);
			AddClass(ClassId.Software, "Software", null, SetupArtifacts.ArtifactId.Thi_Software, ffd);
			AddClass(ClassId.Art, "Art", null, SetupArtifacts.ArtifactId.Thi_Art, ffd);
			AddClass(ClassId.Graphics, "Graphics", null, SetupArtifacts.ArtifactId.Thi_Graphics, ffd);
			AddClass(ClassId.Games, "Games", null, SetupArtifacts.ArtifactId.Thi_Games, ffd);
			AddClass(ClassId.Music, "Music", null, SetupArtifacts.ArtifactId.Thi_Music, ffd);
			AddClass(ClassId.Evolution, "Evolution", null, SetupArtifacts.ArtifactId.Thi_Evolution, ffd);
			AddClass(ClassId.ArtificialIntel, "Artificial Intelligence", null, 
				SetupArtifacts.ArtifactId.Thi_ArtlIntel, ffd);
			AddClass(ClassId.Physics, "Physics", null, SetupArtifacts.ArtifactId.Thi_Physics, ffd);
			AddClass(ClassId.Height, "Height", null, SetupArtifacts.ArtifactId.Thi_Height, ffd);
			AddClass(ClassId.Weight, "Weight", null, SetupArtifacts.ArtifactId.Thi_Weight, ffd);
			AddClass(ClassId.Beauty, "Beauty", null, SetupArtifacts.ArtifactId.Thi_Beauty, ffd);

			AddInstance(InstanceId.TigersGame, "Tigers Game", null, 
				SetupArtifacts.ArtifactId.Thi_TigersGame, bbd);
			AddClass(ClassId.MlbGame, "MLB Game", null, SetupArtifacts.ArtifactId.Thi_MlbGame, bbd);
			AddInstance(InstanceId.DetroitTigers, "Detroit Tigers", null, 
				SetupArtifacts.ArtifactId.Thi_DetroitTigers, bbd);
			AddInstance(InstanceId.BostonRedSox, "Boston Red Sox", null, 
				SetupArtifacts.ArtifactId.Thi_BostonRedSox, bbd);
			AddInstance(InstanceId.ComericaPark, "Comerica Park", null, 
				SetupArtifacts.ArtifactId.Thi_ComericaPark, bbd);
			AddInstance(InstanceId.Bottom11, "Bottom 11th", null, 
				SetupArtifacts.ArtifactId.Thi_Bottom11, bbd);
			AddClass(ClassId.Inning, "Inning", null, SetupArtifacts.ArtifactId.Thi_Inning, bbd);
			AddClass(ClassId.Attendance, "Attendance", null, 
				SetupArtifacts.ArtifactId.Thi_Attendance, ffd);
			AddClass(ClassId.Excitement, "Excitement", null, 
				SetupArtifacts.ArtifactId.Thi_Excitement, ffd);

			AddClass(ClassId.WebPage, "Web Page", null, SetupArtifacts.ArtifactId.Thi_WebPage, ffd);
			AddInstance(InstanceId.CutePhoto, "Cute Photo", null, 
				SetupArtifacts.ArtifactId.Thi_CutePhoto, ggd);
			AddClass(ClassId.Photo, "Photo", null, SetupArtifacts.ArtifactId.Thi_Photo, ggd);
			AddClass(ClassId.Digital, "Digital", null, SetupArtifacts.ArtifactId.Thi_Digital, ggd);
			AddClass(ClassId.Favorite, "Favorite", null, 
				SetupArtifacts.ArtifactId.Thi_Favorite, ggd);
			AddClass(ClassId.FocalLength, "Focal Length", null, 
				SetupArtifacts.ArtifactId.Thi_FocalLength, ggd);
			AddClass(ClassId.Exposure, "Exposure", null, SetupArtifacts.ArtifactId.Thi_Exposure, ggd);
			AddClass(ClassId.FStop, "F-Stop", null, SetupArtifacts.ArtifactId.Thi_FStop, ggd);
			AddClass(ClassId.IsoSpeed, "ISO Speed", null, SetupArtifacts.ArtifactId.Thi_IsoSpeed, ggd);
			AddClass(ClassId.Quality, "Quality", null, SetupArtifacts.ArtifactId.Thi_Quality, ggd);
			AddClass(ClassId.Subject, "Subject", null, SetupArtifacts.ArtifactId.Thi_Subject, ggd);
			AddClass(ClassId.Object, "Object", null, SetupArtifacts.ArtifactId.Thi_Object, ggd);
			AddClass(ClassId.Smile, "Smile", null, SetupArtifacts.ArtifactId.Thi_Smile, ggd);
			AddClass(ClassId.Pigtail, "Pigtail", null, SetupArtifacts.ArtifactId.Thi_Pigtail, ggd);
			AddClass(ClassId.Rope, "Rope", null, SetupArtifacts.ArtifactId.Thi_Rope, ggd);
			AddClass(ClassId.Blue, "Blue", null, SetupArtifacts.ArtifactId.Thi_Blue, ggd);
			AddClass(ClassId.Swing, "Swing", null, SetupArtifacts.ArtifactId.Thi_Swing, ggd);
			AddInstance(InstanceId.FisherPrice, "Fisher-Price", "company", 
				SetupArtifacts.ArtifactId.Thi_FisherPrice, ggd);
			AddClass(ClassId.Happiness, "Happiness", null, SetupArtifacts.ArtifactId.Thi_Happiness, ggd);
			AddClass(ClassId.Fun, "Fun", null, SetupArtifacts.ArtifactId.Thi_Fun, ggd);
			AddClass(ClassId.Cuteness, "Cuteness", null, SetupArtifacts.ArtifactId.Thi_Cuteness, ggd);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddUrl(UrlId pId, string pAbsoluteUrl, string pName,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var u = new Url();
			u.ArtifactId = (byte)pId;
			u.Name = pName;
			u.AbsoluteUrl = pAbsoluteUrl;

			vSet.AddVertex(u, vTestMode);

			////
			
			SetupArtifacts.FillArtifact(vSet, vSet.GetVertex<Url>((long)pId),
				pArtId, pMemberId, vTestMode);
			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddLabel(LabelId pId, string pName,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var l = new Label();
			l.LabelId = (long)pId;
			l.Name = pName;

			vSet.AddVertexAndIndex(l, x => x.LabelId, vTestMode);
			vSet.AddRootEdge<RootContainsLabel>(l, vTestMode);

			////

			Artifact a = SetupArtifacts.AddArtifact(
				vSet, pArtId, ArtifactTypeId.Label, pMemberId, vTestMode);

			var edge = DataEdge.Create(
				vSet.GetVertex<Label>((long)pId), new LabelHasArtifact(), a, vTestMode);
			vSet.AddEdge(edge);

			////

			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddCrowd(CrowdId pId, string pName, string pDesc, bool pIsPrivate, bool pIsInvOnly,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var c = new Crowd();
			c.CrowdId = (long)pId;
			c.Name = pName;
			c.Description = pDesc;
			c.IsPrivate = pIsPrivate;
			c.IsInviteOnly = pIsInvOnly;

			vSet.AddVertexAndIndex(c, x => x.CrowdId, vTestMode);
			vSet.AddRootEdge<RootContainsCrowd>(c, vTestMode);

			////

			Artifact a = SetupArtifacts.AddArtifact(
				vSet, pArtId, ArtifactTypeId.Crowd, pMemberId, vTestMode);

			var edge = DataEdge.Create(
				vSet.GetVertex<Crowd>((long)pId), new CrowdHasArtifact(), a, vTestMode);
			vSet.AddEdge(edge);

			////

			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddCrowdian(CrowdianId pId, CrowdId pCrowdId, SetupUsers.ArtifactId pUserId,
									CrowdianTypeId pTypeId, float pWeight, CrowdianTypeAssignId pCtaId,
									SetupUsers.ArtifactId pAssignerId){
			var c = new Crowdian();
			c.CrowdianId = (long)pId;

			vSet.AddVertexAndIndex(c, x => x.CrowdianId, vTestMode);
			vSet.AddRootEdge<RootContainsCrowdian>(c, vTestMode);

			var edgeCro = DataEdge.Create(vSet.GetVertex<Crowd>((long)pCrowdId),
				new CrowdDefinesCrowdian(), c, vTestMode);
			vSet.AddEdge(edgeCro);

			var edgeUser = DataEdge.Create(vSet.GetVertex<User>((long)pUserId),
				new UserDefinesCrowdian(), c, vTestMode);
			vSet.AddEdge(edgeUser);

			////

			var cta = new CrowdianTypeAssign();
			cta.CrowdianTypeAssignId = (long)pCtaId;
			cta.Weight = pWeight;

			vSet.AddVertexAndIndex(cta, x => x.CrowdianTypeAssignId, vTestMode);
			vSet.AddRootEdge<RootContainsCrowdianTypeAssign>(cta, vTestMode);

			////

			var edgeC = DataEdge.Create(c, new CrowdianHasCrowdianTypeAssign(), cta, vTestMode);
			vSet.AddEdge(edgeC);

			var edgeCt = DataEdge.Create(cta, new CrowdianTypeAssignUsesCrowdianType(),
				vSet.GetVertex<CrowdianType>((long)pTypeId), vTestMode);
			vSet.AddEdge(edgeCt);

			var edgeU = DataEdge.Create(vSet.GetVertex<User>((long)pAssignerId),
				new UserCreatesCrowdianTypeAssign(), cta, vTestMode);
			vSet.AddEdge(edgeU);

			////

			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddClass(ClassId pId, string pName, string pDisamb,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var c = new Class();
			c.ArtifactId = (byte)pId;
			c.Name = pName;
			c.NameKey = pName.ToLower();
			c.Disamb = pDisamb;
			c.Note = null;

			vSet.AddVertex(c, vTestMode);

			////

			SetupArtifacts.FillArtifact(vSet, vSet.GetVertex<Class>((long)pId),
				pArtId, pMemberId, vTestMode);
			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddInstance(InstanceId pId, string pName, string pDisamb,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var i = new Instance();
			i.ArtifactId = (byte)pId;
			i.Name = pName;
			i.Disamb = pDisamb;
			i.Note = null;

			vSet.AddVertex(i, vTestMode);

			////

			SetupArtifacts.FillArtifact(vSet, vSet.GetVertex<Instance>((long)pId), 
				pArtId, pMemberId, vTestMode);
			vSet.ElapseTime();
		}

	}

}