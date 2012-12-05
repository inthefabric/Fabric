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
		
		public enum LabelId {
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

			/*const SetupUsers.UserId fabData = SetupUsers.UserId.FabData;
			const SetupUsers.UserId galData = SetupUsers.UserId.GalData;
			const SetupUsers.UserId bookData = SetupUsers.UserId.BookData;
			const SetupUsers.UserId zach = SetupUsers.UserId.Zach;
			const SetupUsers.UserId mel = SetupUsers.UserId.Mel;
			const SetupUsers.UserId ellie = SetupUsers.UserId.Ellie;
			const SetupUsers.UserId penny = SetupUsers.UserId.Penny;*/

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

			AddLabel(LabelId.A1234, "A1234",
				SetupArtifacts.ArtifactId.Label_A1234, SetupUsers.MemberId.BookZach);
			AddLabel(LabelId.EpicFail, "Epic Fail",
				SetupArtifacts.ArtifactId.Label_EpicFail, SetupUsers.MemberId.GalZach);
			AddLabel(LabelId.LOL, "LOL!",
				SetupArtifacts.ArtifactId.Label_LOL, SetupUsers.MemberId.GalMel);
			
			/*
			AddCrowd("Crowd Test 1", "The first crowd.", false, false, SetupUsers.MemberId.FabFabData);
			AddCrowd("Crowd Test 2", "The second crowd.", false, true, SetupUsers.MemberId.FabFabData);
			AddCrowd("Family", "Zach's circle.", true, true, SetupUsers.MemberId.GalZach);
			AddCrowd("Work", "Zach's circe.", true, true, SetupUsers.MemberId.GalZach);
			AddCrowd("Family", "Mel's circle,", true, true, SetupUsers.MemberId.BookMel);
			AddCrowd("Photo Critics", "Bash bad photos.", false, true, SetupUsers.MemberId.GalZach);
			AddCrowd("Photo Lovers", "Love good photos.", false, false, SetupUsers.MemberId.GalMel);
			AddCrowd("Crowd 3", "empty test crowd.", false, false, SetupUsers.MemberId.BookZach);
			AddCrowd("Data Providers", "Only DPs.", false, true, SetupUsers.MemberId.FabFabData);

			AddCrowdUser(CrowdId.Test1, zach, CrowdUserTypeId.Admin, 1.0f);
			AddCrowdUser(CrowdId.Test1, mel, CrowdUserTypeId.Admin, 1.0f);
			AddCrowdUser(CrowdId.Test1, ellie, CrowdUserTypeId.Member, 0.5f);
			AddCrowdUser(CrowdId.Test1, fabData, CrowdUserTypeId.Member, 0.2f);
			AddCrowdUser(CrowdId.Test1, galData, CrowdUserTypeId.Member, 0.3f);
			AddCrowdUser(CrowdId.Test1, bookData, CrowdUserTypeId.Member, 0.1f);
			AddCrowdUser(CrowdId.Test1, penny, CrowdUserTypeId.Member, 0.5f);

			AddCrowdUser(CrowdId.ZachFamCir, zach, CrowdUserTypeId.Admin, 1.0f);
			AddCrowdUser(CrowdId.ZachFamCir, mel, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.ZachFamCir, ellie, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.ZachFamCir, penny, CrowdUserTypeId.Member, 1.0f);

			AddCrowdUser(CrowdId.ZachWorkCir, zach, CrowdUserTypeId.Admin, 0.2f);
			AddCrowdUser(CrowdId.ZachWorkCir, fabData, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.ZachWorkCir, galData, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.ZachWorkCir, bookData, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.ZachWorkCir, mel, CrowdUserTypeId.Member, 0.2f);

			AddCrowdUser(CrowdId.MelFamCir, mel, CrowdUserTypeId.Admin, 0.0f);
			AddCrowdUser(CrowdId.MelFamCir, zach, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.MelFamCir, ellie, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.MelFamCir, penny, CrowdUserTypeId.Member, 1.0f);

			AddCrowdUser(CrowdId.PhoCrit, galData, CrowdUserTypeId.Admin, 1.0f);
			AddCrowdUser(CrowdId.PhoCrit, zach, CrowdUserTypeId.Invite, 0.0f);
			AddCrowdUser(CrowdId.PhoCrit, mel, CrowdUserTypeId.Invite, 0.0f);
			AddCrowdUser(CrowdId.PhoCrit, ellie, CrowdUserTypeId.Request, 0.0f);

			AddCrowdUser(CrowdId.PhoLove, mel, CrowdUserTypeId.Admin, 1.0f);
			AddCrowdUser(CrowdId.PhoLove, zach, CrowdUserTypeId.Request, 0.0f);
			AddCrowdUser(CrowdId.PhoLove, ellie, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.PhoLove, galData, CrowdUserTypeId.Member, 0.5f);

			AddCrowdUser(CrowdId.DataProv, fabData, CrowdUserTypeId.Admin, 0.0f);
			AddCrowdUser(CrowdId.DataProv, galData, CrowdUserTypeId.Member, 1.0f);
			AddCrowdUser(CrowdId.DataProv, bookData, CrowdUserTypeId.Member, 1.0f);

			const SetupUsers.MemberId ffd = SetupUsers.MemberId.FabFabData;
			const SetupUsers.MemberId ggd = SetupUsers.MemberId.GalGalData;
			const SetupUsers.MemberId bbd = SetupUsers.MemberId.BookBookData;

			AddThing(true, "Human", "", ffd);
			AddThing(true, "Male", "", ffd);
			AddThing(true, "Female", "", ffd);
			AddThing(true, "Name", "", ffd);
			AddThing(true, "Legal", "", ffd);
			AddThing(true, "Home", "", ffd);
			AddThing(true, "Muskegon", "MI, USA", ffd);
			AddThing(false, "Neimeyer Living Center", "GVSU", ffd);
			AddThing(false, "Campus View Apartments", "Allendale, MI", ffd);
			AddThing(true, "Location", "geographical", ffd);
			AddThing(false, "Apple Ridge Apartments", "Standale, MI", ffd);
			AddThing(true, "Caldonia", "MI, USA", ffd);
			AddThing(false, "Fabric Platform", "", ffd);
			AddThing(false, "Attend", "", ffd);
			AddThing(false, "Reeths Puffer High School", "Muskegon, MI, USA", ffd);
			AddThing(true, "Grade Point Average", "", ffd);
			AddThing(true, "ACT Test", "", ffd);
			AddThing(true, "Overall", "", ffd);
			AddThing(false, Thing_GVSU_Name, Thing_GVSU_Disamb, ffd);
			AddThing(false, "Aesthetic Interactive", "software firm", ffd);
			AddThing(true, "Software", "", ffd);
			AddThing(true, "Art", "", ffd);
			AddThing(true, "Graphics", "", ffd);
			AddThing(true, "Games", "", ffd);
			AddThing(true, "Music", "", ffd);
			AddThing(true, "Evolution", "", ffd);
			AddThing(true, "Artificial Intelligence", "", ffd);
			AddThing(true, "Physics", "", ffd);
			AddThing(true, "Height", "", ffd);
			AddThing(true, "Weight", "", ffd);
			AddThing(true, "Beauty", "", ffd);

			AddThing(false, "Tigers Game", "", bbd);
			AddThing(true, "MLB Game", "", bbd);
			AddThing(false, "Detroit Tigers", "", bbd);
			AddThing(false, "Boston Red Sox", "", bbd);
			AddThing(false, "Comerica Park", "", bbd);
			AddThing(false, "Bottom 11th", "", bbd);
			AddThing(true, "Inning", "", bbd);
			AddThing(true, "Attendance", "", ffd);
			AddThing(true, "Excitement", "", ffd);

			AddThing(true, "Web Page", "", ffd);
			AddThing(false, "Cute Photo", "", ggd);
			AddThing(true, "Photo", "", ggd);
			AddThing(true, "Digital", "", ggd);
			AddThing(true, "Favorite", "", ggd);
			AddThing(true, "Focal Length", "", ggd);
			AddThing(true, "Exposure", "", ggd);
			AddThing(true, "F-Stop", "", ggd);
			AddThing(true, "ISO Speed", "", ggd);
			AddThing(true, "Quality", "", ggd);
			AddThing(true, "Subject", "", ggd);
			AddThing(true, "Object", "", ggd);
			AddThing(true, "Smile", "", ggd);
			AddThing(true, "Pigtail", "", ggd);
			AddThing(true, "Rope", "", ggd);
			AddThing(true, "Blue", "", ggd);
			AddThing(true, "Swing", "", ggd);
			AddThing(false, "Fisher-Price", "company", ggd);
			AddThing(true, "Happiness", "", ggd);
			AddThing(true, "Fun", "", ggd);
			AddThing(true, "Cuteness", "", ggd);*/
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

		/*--------------------------------------------------------------------------------------------*/
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
		public void AddCrowd(string pName, string pDesc, bool pIsPrivate, bool pIsInviteOnly,
																	SetupUsers.MemberId pMemberId) {
			CrowdTable.AddItem(pName, pDesc, pIsPrivate, pIsInviteOnly,
				vSess.Load<Artifact>(vData.SetupArts.NextArtifactId));
			vData.SetupArts.ArtifactTable.AddItemForCrowd(
				vSess.Load<Member>((uint)pMemberId), pIsPrivate);
			vData.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddCrowdUser(CrowdId pCrowdId, Usr pUser, CrowdUserTypeId pTypeId,
																						float pWeight) {
			CrowdUserTable.AddItem(vSess.Load<Crowd>((uint)pCrowdId), pUser,
				vSess.Load<CrowdUserType>((byte)pTypeId), "", pWeight);
			vData.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------* /
		public void AddThing(bool pIsClass, string pName, string pDisamb,
																	SetupUsers.MemberId pMemberId) {
			ThingTable.AddItem(pIsClass, pName, pDisamb, "",
				vSess.Load<Artifact>(vData.SetupArts.NextArtifactId));
			vData.SetupArts.ArtifactTable.AddItemForThing(vSess.Load<Member>((uint)pMemberId));
			vData.ElapseTime();
		}*/

	}

}