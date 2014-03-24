using Fabric.New.Domain;

namespace Fabric.New.Database.Init.Setups {

	/*================================================================================================*/
	public class SetupObjects : SetupVertices {
		
		/*public const int NumUrls = 5;
		public const int NumClasses = 45;
		public const int NumInstances = 16;*/


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupObjects(DataSet pData) : base(pData) {}
			
		/*--------------------------------------------------------------------------------------------*/
		public void Create() {
			IsForTestingOnly = true;

			AddUrl(SetupUrlId.ZachKin, "http://zachkinstner.com", "ZachKinstner.com", 
				SetupMemberId.BookZach);
			AddUrl(SetupUrlId.Google, "http://google.com", "Google Homepage",
				SetupMemberId.BookMel);
			AddUrl(SetupUrlId.ZachFb, "http://facebook.com/zachkinstner", "ZK@FB",
				SetupMemberId.GalZach);
			AddUrl(SetupUrlId.YahooFin, "http://finance.yahoo.com", "Financial News",
				SetupMemberId.BookZach);
			AddUrl(SetupUrlId.CutePhoto, "http://zachkinstner.com/photo/4165", "Super Cute Photo",
				SetupMemberId.GalMel);

			const SetupMemberId ffd = SetupMemberId.FabFabData;
			const SetupMemberId ggd = SetupMemberId.GalGalData;
			const SetupMemberId bbd = SetupMemberId.BookBookData;

			AddClass(SetupClassId.Human, "Human", null, ffd);
			AddClass(SetupClassId.Male, "Male", null, ffd);
			AddClass(SetupClassId.Female, "Female", null, ffd);
			AddClass(SetupClassId.Name, "Name", null, ffd);
			AddClass(SetupClassId.Legal, "Legal", null, ffd);
			AddClass(SetupClassId.Home, "Home", null, ffd);
			AddClass(SetupClassId.Muskegon, "Muskegon", "MI, USA", ffd);
			AddInst(SetupInstanceId.Neimeyer, "Neimeyer Living Center", "GVSU", ffd);
			AddInst(SetupInstanceId.CampusView, "Campus View Apartments", "Allendale, MI", ffd);
			AddClass(SetupClassId.Location, "Location", "geographical", ffd);
			AddInst(SetupInstanceId.AppleRidge, "Apple Ridge Apartments", "Standale, MI", ffd);
			AddClass(SetupClassId.Caldonia, "Caldonia", "MI, USA", ffd);
			AddInst(SetupInstanceId.FabricPlatform, "Fabric Platform", null, ffd);
			AddClass(SetupClassId.Attend, "Attend", null, ffd);
			AddInst(SetupInstanceId.ReethsPufferHS,"Reeths-Puffer High School","Muskegon, MI, USA",ffd);
			AddClass(SetupClassId.GradePointAvg, "Grade Point Average", null, ffd);
			AddClass(SetupClassId.ACTTest, "ACT Test", null, ffd);
			AddClass(SetupClassId.Overall, "Overall", null, ffd);
			AddInst(SetupInstanceId.GrandValley, "Grand Valley State University", "Allendale, MI", ffd);
			AddInst(SetupInstanceId.AestheticInteractive, "Aesthetic Interactive", "software firm",ffd);
			AddClass(SetupClassId.Software, "Software", null, ffd);
			AddClass(SetupClassId.Art, "Art", null, ffd);
			AddClass(SetupClassId.Graphics, "Graphics", null, ffd);
			AddClass(SetupClassId.Games, "Games", null, ffd);
			AddClass(SetupClassId.Music, "Music", null, ffd);
			AddClass(SetupClassId.Evolution, "Evolution", null, ffd);
			AddClass(SetupClassId.ArtificialIntel, "Artificial Intelligence", null, ffd);
			AddClass(SetupClassId.Physics, "Physics", null, ffd);
			AddClass(SetupClassId.Height, "Height", null, ffd);
			AddClass(SetupClassId.Weight, "Weight", null, ffd);
			AddClass(SetupClassId.Beauty, "Beauty", null, ffd);

			AddInst(SetupInstanceId.TigersGame, "Tigers Game", null, bbd);
			AddClass(SetupClassId.MlbGame, "MLB Game", null, bbd);
			AddInst(SetupInstanceId.DetroitTigers, "Detroit Tigers", null, bbd);
			AddInst(SetupInstanceId.BostonRedSox, "Boston Red Sox", null, bbd);
			AddInst(SetupInstanceId.ComericaPark, "Comerica Park", null, bbd);
			AddInst(SetupInstanceId.Bottom11, "Bottom 11th", null, bbd);
			AddClass(SetupClassId.Inning, "Inning", null, bbd);
			AddClass(SetupClassId.Attendance, "Attendance", null, ffd);
			AddClass(SetupClassId.Excitement, "Excitement", null, ffd);

			AddClass(SetupClassId.WebPage, "Web Page", null, ffd);
			AddInst(SetupInstanceId.CutePhoto, "Cute Photo", null, ggd);
			AddClass(SetupClassId.Photo, "Photo", null, ggd);
			AddClass(SetupClassId.Digital, "Digital", null, ggd);
			AddClass(SetupClassId.Favorite, "Favorite", null, ggd);
			AddClass(SetupClassId.FocalLength, "Focal Length", null, ggd);
			AddClass(SetupClassId.Exposure, "Exposure", null, ggd);
			AddClass(SetupClassId.FStop, "F-Stop", null, ggd);
			AddClass(SetupClassId.IsoSpeed, "ISO Speed", null, ggd);
			AddClass(SetupClassId.Quality, "Quality", null, ggd);
			AddClass(SetupClassId.Subject, "Subject", null, ggd);
			AddClass(SetupClassId.Object, "Object", null, ggd);
			AddClass(SetupClassId.Smile, "Smile", null, ggd);
			AddClass(SetupClassId.Pigtail, "Pigtail", null, ggd);
			AddClass(SetupClassId.Rope, "Rope", null, ggd);
			AddClass(SetupClassId.Blue, "Blue", null, ggd);
			AddClass(SetupClassId.Swing, "Swing", null, ggd);
			AddInst(SetupInstanceId.FisherPrice, "Fisher-Price", "company", ggd);
			AddClass(SetupClassId.Happiness, "Happiness", null, ggd);
			AddClass(SetupClassId.Fun, "Fun", null, ggd);
			AddClass(SetupClassId.Cuteness, "Cuteness", null, ggd);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddUrl(SetupUrlId pId, string pPath, string pName, SetupMemberId pMemId) {
			var u = new Url();
			u.Name = pName;
			u.FullPath = pPath;
			AddArtifact(u, (SetupArtifactId)(long)pId, pMemId);
			Data.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddClass(SetupClassId pId, string pName, string pDisamb, SetupMemberId pMemId) {
			var c = new Class();
			c.Name = pName;
			c.NameKey = pName.ToLower();
			c.Disamb = pDisamb;
			c.Note = null;
			AddArtifact(c, (SetupArtifactId)(long)pId, pMemId);
			Data.ElapseTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddInst(SetupInstanceId pId, string pName, string pDisamb, SetupMemberId pMemId) {
			var i = new Instance();
			i.Name = pName;
			i.Disamb = pDisamb;
			i.Note = null;
			AddArtifact(i, (SetupArtifactId)(long)pId, pMemId);
			Data.ElapseTime();
		}

	}

}