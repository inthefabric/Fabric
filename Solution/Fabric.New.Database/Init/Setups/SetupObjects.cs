using Fabric.New.Domain;

namespace Fabric.New.Database.Init.Setups {

	/*================================================================================================*/
	public class SetupObjects {
		
		public enum UrlId {
			ZachKin = 1,
			Google,
			ZachFb,
			YahooFin,
			CutePhoto
		}

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
		public void AddUrl(UrlId pId, string pPath, string pName,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var u = new Url();
			u.VertexId = (byte)pId;
			u.Name = pName;
			u.FullPath = pPath;

			vSet.AddVertex(u, vTestMode);

			////
			
			SetupArtifacts.FillArtifact(vSet, vSet.GetVertex<Url>((long)pId),
				pArtId, pMemberId, vTestMode);
			vSet.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddClass(ClassId pId, string pName, string pDisamb,
									SetupArtifacts.ArtifactId pArtId, SetupUsers.MemberId pMemberId) {
			var c = new Class();
			c.VertexId = (byte)pId;
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
			i.VertexId = (byte)pId;
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