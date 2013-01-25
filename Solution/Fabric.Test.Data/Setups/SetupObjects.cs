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

		public enum ThingId {
			Human = 1,
			Male,
			Female,
			Name,
			Legal,
			Home,
			Muskegon,
			Neimeyer,
			CampusView,
			Location,
			AppleRidge,
			Caldonia,
			FabricPlatform,
			Attend,
			ReethsPufferHS,
			GradePointAvg,
			ACTTest,
			Overall,
			GrandValley,
			AestheticInteractive,
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
			TigersGame,
			MlbGame,
			DetroitTigers,
			BostonRedSox,
			ComericaPark,
			Bottom11,
			Inning,
			Attendance,
			Excitement,
			WebPage,
			CutePhoto,
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
			FisherPrice,
			Happiness,
			Fun,
			Cuteness
		}
		
		public const int NumUrls = 5;
		public const int NumLabels = 3;
		public const int NumCrowds = 9;
		public const int NumCrowdians = 31;
		public const int NumThings = 61;

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
			AddUrl(UrlId.CutePhoto, "http://zachkinstner.com/gallery/Photo/View/4165",
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

			const SetupUsers.UserId fabData = SetupUsers.UserId.FabData;
			const SetupUsers.UserId galData = SetupUsers.UserId.GalData;
			const SetupUsers.UserId bookData = SetupUsers.UserId.BookData;
			const SetupUsers.UserId zach = SetupUsers.UserId.Zach;
			const SetupUsers.UserId mel = SetupUsers.UserId.Mel;
			const SetupUsers.UserId ellie = SetupUsers.UserId.Ellie;
			const SetupUsers.UserId penny = SetupUsers.UserId.Penny;

			AddCrowdian(CrowdianId.Test1_Zach, CrowdId.Test1, zach, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.T1ZachAdminByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.Test1_Mel, CrowdId.Test1, mel, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.T1MelAdminByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.Test1_Ellie, CrowdId.Test1, ellie, CrowdianTypeId.Member, 0.5f,
				CrowdianTypeAssignId.T1EllieMemberByMel, SetupUsers.UserId.Mel);
			AddCrowdian(CrowdianId.Test1_FabData, CrowdId.Test1, fabData, CrowdianTypeId.Member, 0.2f,
				CrowdianTypeAssignId.T1FabMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.Test1_GalData, CrowdId.Test1, galData, CrowdianTypeId.Member, 0.3f,
				CrowdianTypeAssignId.T1GalMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.Test1_BookData, CrowdId.Test1, bookData, CrowdianTypeId.Member, 0.1f,
				CrowdianTypeAssignId.T1BookMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.Test1_Penny, CrowdId.Test1, penny, CrowdianTypeId.Member, 0.5f,
				CrowdianTypeAssignId.T1PennyMemberByMel, SetupUsers.UserId.Mel);

			AddCrowdian(CrowdianId.ZachFam_Zach, CrowdId.ZachFamCir, zach, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.ZfZachAdminByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachFam_Mel, CrowdId.ZachFamCir, mel, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.ZfMelMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachFam_Ellie, CrowdId.ZachFamCir, ellie, CrowdianTypeId.Member,1.0f,
				CrowdianTypeAssignId.ZfEllieMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachFam_Penny, CrowdId.ZachFamCir, penny, CrowdianTypeId.Member,1.0f,
				CrowdianTypeAssignId.ZfPennyMemberByZach, SetupUsers.UserId.Zach);

			AddCrowdian(CrowdianId.ZachWork_Zach, CrowdId.ZachWorkCir, zach, CrowdianTypeId.Admin, 0.2f,
				CrowdianTypeAssignId.ZwZachAdminByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachWork_FabData, CrowdId.ZachWorkCir, fabData,CrowdianTypeId.Member,
				1.0f, CrowdianTypeAssignId.ZwFabMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachWork_GalData, CrowdId.ZachWorkCir, galData,CrowdianTypeId.Member,
				1.0f, CrowdianTypeAssignId.ZwGalMemberByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachWork_BookData, CrowdId.ZachWorkCir, bookData,
				CrowdianTypeId.Member, 1.0f, CrowdianTypeAssignId.ZwBookMemberByZach,
				SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.ZachWork_Mel, CrowdId.ZachWorkCir, mel, CrowdianTypeId.Member, 0.2f,
				CrowdianTypeAssignId.ZwMelMemberByZach, SetupUsers.UserId.Zach);

			AddCrowdian(CrowdianId.MelFam_Mel, CrowdId.MelFamCir, mel, CrowdianTypeId.Admin, 0.0f,
				CrowdianTypeAssignId.MfMelAdminByMel, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.MelFam_Zach, CrowdId.MelFamCir, zach, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.MfZachMemberByMel, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.MelFam_Ellie, CrowdId.MelFamCir, ellie, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.MfEllieMemberByMel, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.MelFam_Penny, CrowdId.MelFamCir, penny, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.MfPennyMemberByMel, SetupUsers.UserId.Zach);

			AddCrowdian(CrowdianId.Crit_GalData, CrowdId.PhoCrit, galData, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.CritGalAdminByGal, SetupUsers.UserId.GalData);
			AddCrowdian(CrowdianId.Crit_Zach, CrowdId.PhoCrit, zach, CrowdianTypeId.Invite, 0.0f,
				CrowdianTypeAssignId.CriZachIntiveByGal, SetupUsers.UserId.GalData);
			AddCrowdian(CrowdianId.Crit_Mel, CrowdId.PhoCrit, mel, CrowdianTypeId.Invite, 0.0f,
				CrowdianTypeAssignId.CritMelInviteByGal, SetupUsers.UserId.GalData);
			AddCrowdian(CrowdianId.Crit_Ellie, CrowdId.PhoCrit, ellie, CrowdianTypeId.Request, 0.0f,
				CrowdianTypeAssignId.CritEllieRequestByElie, SetupUsers.UserId.Ellie);

			AddCrowdian(CrowdianId.Love_Mel, CrowdId.PhoLove, mel, CrowdianTypeId.Admin, 1.0f,
				CrowdianTypeAssignId.LoveMelAdminByMel, SetupUsers.UserId.Mel);
			AddCrowdian(CrowdianId.Love_Zach, CrowdId.PhoLove, zach, CrowdianTypeId.Request, 0.0f,
				CrowdianTypeAssignId.LoveZachRequestByZach, SetupUsers.UserId.Zach);
			AddCrowdian(CrowdianId.Love_Ellie, CrowdId.PhoLove, ellie, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.LoveEllieMemberByMel, SetupUsers.UserId.Mel);
			AddCrowdian(CrowdianId.Love_GalData, CrowdId.PhoLove, galData, CrowdianTypeId.Member, 0.5f,
				CrowdianTypeAssignId.LoveGalMemberByMel, SetupUsers.UserId.Mel);

			AddCrowdian(CrowdianId.Dp_FabData, CrowdId.DataProv, fabData, CrowdianTypeId.Admin, 0.0f,
				CrowdianTypeAssignId.DpFabAdminByFab, SetupUsers.UserId.FabData);
			AddCrowdian(CrowdianId.Dp_GalData, CrowdId.DataProv, galData, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.DbGalMemberByFab, SetupUsers.UserId.FabData);
			AddCrowdian(CrowdianId.Dp_BookData, CrowdId.DataProv, bookData, CrowdianTypeId.Member, 1.0f,
				CrowdianTypeAssignId.DbBookMemberByFab, SetupUsers.UserId.FabData);
			*/

			const SetupUsers.MemberId ffd = SetupUsers.MemberId.FabFabData;
			const SetupUsers.MemberId ggd = SetupUsers.MemberId.GalGalData;
			const SetupUsers.MemberId bbd = SetupUsers.MemberId.BookBookData;

			AddThing(ThingId.Human, true, "Human", "", SetupArtifacts.ArtifactId.Thi_Human, ffd);
			AddThing(ThingId.Male, true, "Male", "", SetupArtifacts.ArtifactId.Thi_Male, ffd);
			AddThing(ThingId.Female, true, "Female", "", SetupArtifacts.ArtifactId.Thi_Female, ffd);
			AddThing(ThingId.Name, true, "Name", "", SetupArtifacts.ArtifactId.Thi_Name, ffd);
			AddThing(ThingId.Legal, true, "Legal", "", SetupArtifacts.ArtifactId.Thi_Legal, ffd);
			AddThing(ThingId.Home, true, "Home", "", SetupArtifacts.ArtifactId.Thi_Home, ffd);
			AddThing(ThingId.Muskegon, true, "Muskegon", "MI, USA", 
				SetupArtifacts.ArtifactId.Thi_Muskegon, ffd);
			AddThing(ThingId.Neimeyer, false, "Neimeyer Living Center", "GVSU", 
				SetupArtifacts.ArtifactId.Thi_Neimeyer, ffd);
			AddThing(ThingId.CampusView, false, "Campus View Apartments", "Allendale, MI", 
				SetupArtifacts.ArtifactId.Thi_CampusView, ffd);
			AddThing(ThingId.Location, true, "Location", "geographical", 
				SetupArtifacts.ArtifactId.Thi_Location, ffd);
			AddThing(ThingId.AppleRidge, false, "Apple Ridge Apartments", "Standale, MI", 
				SetupArtifacts.ArtifactId.Thi_AppleRidge, ffd);
			AddThing(ThingId.Caldonia, true, "Caldonia", "MI, USA", 
				SetupArtifacts.ArtifactId.Thi_Caldonia, ffd);
			AddThing(ThingId.FabricPlatform, false, "Fabric Platform", "", 
				SetupArtifacts.ArtifactId.Thi_FabricPlat, ffd);
			AddThing(ThingId.Attend, false, "Attend", "", 
				SetupArtifacts.ArtifactId.Thi_Attend, ffd);
			AddThing(ThingId.ReethsPufferHS, false, "Reeths Puffer High School", "Muskegon, MI, USA", 
				SetupArtifacts.ArtifactId.Thi_RPHS, ffd);
			AddThing(ThingId.GradePointAvg, true, "Grade Point Average", "", 
				SetupArtifacts.ArtifactId.Thi_GradePointAvg, ffd);
			AddThing(ThingId.ACTTest, true, "ACT Test", "", SetupArtifacts.ArtifactId.Thi_ACTTest, ffd);
			AddThing(ThingId.Overall, true, "Overall", "", SetupArtifacts.ArtifactId.Thi_Overall, ffd);
			AddThing(ThingId.GrandValley, false, ThingGvsuName, ThingGvsuDisamb, 
				SetupArtifacts.ArtifactId.Thi_GrandValley, ffd);
			AddThing(ThingId.AestheticInteractive, false, "Aesthetic Interactive", "software firm", 
				SetupArtifacts.ArtifactId.Thi_Aei, ffd);
			AddThing(ThingId.Software, true, "Software", "", 
				SetupArtifacts.ArtifactId.Thi_Software, ffd);
			AddThing(ThingId.Art, true, "Art", "", SetupArtifacts.ArtifactId.Thi_Art, ffd);
			AddThing(ThingId.Graphics, true, "Graphics", "", 
				SetupArtifacts.ArtifactId.Thi_Graphics, ffd);
			AddThing(ThingId.Games, true, "Games", "", SetupArtifacts.ArtifactId.Thi_Games, ffd);
			AddThing(ThingId.Music, true, "Music", "", SetupArtifacts.ArtifactId.Thi_Music, ffd);
			AddThing(ThingId.Evolution, true, "Evolution", "", 
				SetupArtifacts.ArtifactId.Thi_Evolution, ffd);
			AddThing(ThingId.ArtificialIntel, true, "Artificial Intelligence", "", 
				SetupArtifacts.ArtifactId.Thi_ArtlIntel, ffd);
			AddThing(ThingId.Physics, true, "Physics", "", SetupArtifacts.ArtifactId.Thi_Physics, ffd);
			AddThing(ThingId.Height, true, "Height", "", SetupArtifacts.ArtifactId.Thi_Height, ffd);
			AddThing(ThingId.Weight, true, "Weight", "", SetupArtifacts.ArtifactId.Thi_Weight, ffd);
			AddThing(ThingId.Beauty, true, "Beauty", "", SetupArtifacts.ArtifactId.Thi_Beauty, ffd);

			AddThing(ThingId.TigersGame, false, "Tigers Game", "", 
				SetupArtifacts.ArtifactId.Thi_TigersGame, bbd);
			AddThing(ThingId.MlbGame, true, "MLB Game", "", SetupArtifacts.ArtifactId.Thi_MlbGame, bbd);
			AddThing(ThingId.DetroitTigers, false, "Detroit Tigers", "", 
				SetupArtifacts.ArtifactId.Thi_DetroitTigers, bbd);
			AddThing(ThingId.BostonRedSox, false, "Boston Red Sox", "", 
				SetupArtifacts.ArtifactId.Thi_BostonRedSox, bbd);
			AddThing(ThingId.ComericaPark, false, "Comerica Park", "", 
				SetupArtifacts.ArtifactId.Thi_ComericaPark, bbd);
			AddThing(ThingId.Bottom11, false, "Bottom 11th", "", 
				SetupArtifacts.ArtifactId.Thi_Bottom11, bbd);
			AddThing(ThingId.Inning, true, "Inning", "", 
				SetupArtifacts.ArtifactId.Thi_Inning, bbd);
			AddThing(ThingId.Attendance, true, "Attendance", "", 
				SetupArtifacts.ArtifactId.Thi_Attendance, ffd);
			AddThing(ThingId.Excitement, true, "Excitement", "", 
				SetupArtifacts.ArtifactId.Thi_Excitement, ffd);

			AddThing(ThingId.WebPage, true, "Web Page", "", SetupArtifacts.ArtifactId.Thi_WebPage, ffd);
			AddThing(ThingId.CutePhoto, false, "Cute Photo", "", 
				SetupArtifacts.ArtifactId.Thi_CutePhoto, ggd);
			AddThing(ThingId.Photo, true, "Photo", "", SetupArtifacts.ArtifactId.Thi_Photo, ggd);
			AddThing(ThingId.Digital, true, "Digital", "", SetupArtifacts.ArtifactId.Thi_Digital, ggd);
			AddThing(ThingId.Favorite, true, "Favorite", "", 
				SetupArtifacts.ArtifactId.Thi_Favorite, ggd);
			AddThing(ThingId.FocalLength, true, "Focal Length", "", 
				SetupArtifacts.ArtifactId.Thi_FocalLength, ggd);
			AddThing(ThingId.Exposure, true, "Exposure", "", 
				SetupArtifacts.ArtifactId.Thi_Exposure, ggd);
			AddThing(ThingId.FStop, true, "F-Stop", "", SetupArtifacts.ArtifactId.Thi_FStop, ggd);
			AddThing(ThingId.IsoSpeed, true, "ISO Speed", "", 
				SetupArtifacts.ArtifactId.Thi_IsoSpeed, ggd);
			AddThing(ThingId.Quality, true, "Quality", "", SetupArtifacts.ArtifactId.Thi_Quality, ggd);
			AddThing(ThingId.Subject, true, "Subject", "", SetupArtifacts.ArtifactId.Thi_Subject, ggd);
			AddThing(ThingId.Object, true, "Object", "", SetupArtifacts.ArtifactId.Thi_Object, ggd);
			AddThing(ThingId.Smile, true, "Smile", "", SetupArtifacts.ArtifactId.Thi_Smile, ggd);
			AddThing(ThingId.Pigtail, true, "Pigtail", "", SetupArtifacts.ArtifactId.Thi_Pigtail, ggd);
			AddThing(ThingId.Rope, true, "Rope", "", SetupArtifacts.ArtifactId.Thi_Rope, ggd);
			AddThing(ThingId.Blue, true, "Blue", "", SetupArtifacts.ArtifactId.Thi_Blue, ggd);
			AddThing(ThingId.Swing, true, "Swing", "", SetupArtifacts.ArtifactId.Thi_Swing, ggd);
			AddThing(ThingId.FisherPrice, false, "Fisher-Price", "company", 
				SetupArtifacts.ArtifactId.Thi_FisherPrice, ggd);
			AddThing(ThingId.Happiness, true, "Happiness", "", 
				SetupArtifacts.ArtifactId.Thi_Happiness, ggd);
			AddThing(ThingId.Fun, true, "Fun", "", SetupArtifacts.ArtifactId.Thi_Fun, ggd);
			AddThing(ThingId.Cuteness, true, "Cuteness", "", 
				SetupArtifacts.ArtifactId.Thi_Cuteness, ggd);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddUrl(UrlId pId, string pAbsoluteUrl, string pName,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var u = new Url();
			u.UrlId = (long)pId;
			u.Name = pName;
			u.AbsoluteUrl = pAbsoluteUrl;

			vSet.AddNodeAndIndex(u, x => x.UrlId, vTestMode);
			vSet.AddRootRel<RootContainsUrl>(u, vTestMode);

			////
			
			Artifact a = SetupArtifacts.AddArtifact(
				vSet, pArtId, ArtifactTypeId.Url, pMemberId, vTestMode);

			var rel = DataRel.Create(
				vSet.GetNode<Url>((long)pId), new UrlHasArtifact(), a, vTestMode);
			vSet.AddRel(rel);

			////

			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddLabel(LabelId pId, string pName,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var l = new Label();
			l.LabelId = (long)pId;
			l.Name = pName;

			vSet.AddNodeAndIndex(l, x => x.LabelId, vTestMode);
			vSet.AddRootRel<RootContainsLabel>(l, vTestMode);

			////

			Artifact a = SetupArtifacts.AddArtifact(
				vSet, pArtId, ArtifactTypeId.Label, pMemberId, vTestMode);

			var rel = DataRel.Create(
				vSet.GetNode<Label>((long)pId), new LabelHasArtifact(), a, vTestMode);
			vSet.AddRel(rel);

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

			vSet.AddNodeAndIndex(c, x => x.CrowdId, vTestMode);
			vSet.AddRootRel<RootContainsCrowd>(c, vTestMode);

			////

			Artifact a = SetupArtifacts.AddArtifact(
				vSet, pArtId, ArtifactTypeId.Crowd, pMemberId, vTestMode);

			var rel = DataRel.Create(
				vSet.GetNode<Crowd>((long)pId), new CrowdHasArtifact(), a, vTestMode);
			vSet.AddRel(rel);

			////

			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddCrowdian(CrowdianId pId, CrowdId pCrowdId, SetupUsers.UserId pUserId,
									CrowdianTypeId pTypeId, float pWeight, CrowdianTypeAssignId pCtaId,
									SetupUsers.UserId pAssignerId){
			var c = new Crowdian();
			c.CrowdianId = (long)pId;

			vSet.AddNodeAndIndex(c, x => x.CrowdianId, vTestMode);
			vSet.AddRootRel<RootContainsCrowdian>(c, vTestMode);

			var relCro = DataRel.Create(vSet.GetNode<Crowd>((long)pCrowdId),
				new CrowdDefinesCrowdian(), c, vTestMode);
			vSet.AddRel(relCro);

			var relUser = DataRel.Create(vSet.GetNode<User>((long)pUserId),
				new UserDefinesCrowdian(), c, vTestMode);
			vSet.AddRel(relUser);

			////

			var cta = new CrowdianTypeAssign();
			cta.CrowdianTypeAssignId = (long)pCtaId;
			cta.Weight = pWeight;

			vSet.AddNodeAndIndex(cta, x => x.CrowdianTypeAssignId, vTestMode);
			vSet.AddRootRel<RootContainsCrowdianTypeAssign>(cta, vTestMode);

			////

			var relC = DataRel.Create(c, new CrowdianHasCrowdianTypeAssign(), cta, vTestMode);
			vSet.AddRel(relC);

			var relCt = DataRel.Create(cta, new CrowdianTypeAssignUsesCrowdianType(),
				vSet.GetNode<CrowdianType>((long)pTypeId), vTestMode);
			vSet.AddRel(relCt);

			var relU = DataRel.Create(vSet.GetNode<User>((long)pAssignerId),
				new UserCreatesCrowdianTypeAssign(), cta, vTestMode);
			vSet.AddRel(relU);

			////

			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddThing(ThingId pId, bool pIsClass, string pName, string pDisamb,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var t = new Thing();
			t.ThingId = (long)pId;
			t.IsClass = pIsClass;
			t.Name = pName;
			t.Disamb = pDisamb;
			t.Note = null;

			vSet.AddNodeAndIndex(t, x => x.ThingId, vTestMode);
			vSet.AddRootRel<RootContainsThing>(t, vTestMode);

			////

			Artifact a = SetupArtifacts.AddArtifact(
				vSet, pArtId, ArtifactTypeId.Thing, pMemberId, vTestMode);

			var rel = DataRel.Create(
				vSet.GetNode<Thing>((long)pId), new ThingHasArtifact(), a, vTestMode);
			vSet.AddRel(rel);

			////
			
			vSet.ElapseTime();
		}

	}

}