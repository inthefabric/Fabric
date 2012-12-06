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

			/*const SetupUsers.MemberId ffd = SetupUsers.MemberId.FabFabData;
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

		/*--------------------------------------------------------------------------------------------*/
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

		/*--------------------------------------------------------------------------------------------*/
		public void AddCrowdian(CrowdianId pId, CrowdId pCrowdId, SetupUsers.UserId pUserId,
									CrowdianTypeId pTypeId, float pWeight, CrowdianTypeAssignId pCtaId,
									SetupUsers.UserId pAssignerId){
			var c = new Crowdian();
			c.CrowdianId = (long)pId;

			vSet.AddNodeAndIndex(c, x => x.CrowdianId, vTestMode);
			vSet.AddRootRel<RootContainsCrowdian>(c, vTestMode);

			var relCro = DataRel.Create(c, new CrowdianUsesCrowd(),
				vSet.GetNode<Crowd>((long)pCrowdId), vTestMode);
			vSet.AddRel(relCro);

			var relUser = DataRel.Create(c, new CrowdianUsesUser(),
				vSet.GetNode<User>((long)pUserId), vTestMode);
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