using Fabric.Domain;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class SetupArtifacts {

		public enum ArtifactId {
			User_FabData = 1,
			App_FabSys,
			User_Zach,
			User_Mel,
			User_GalData,
			App_KinPhoGal,
			User_Ellie,
			User_Penny,
			User_BookData,
			App_Bookmarker,

			Url_ZachKin,
			Url_Google,
			Url_ZachFb,
			Url_YahooFin,
			Url_CutePhoto,

			Label_A1234,
			Label_EpicFail,
			Label_LOL,

			Cro_Test1,
			Cro_Test2,
			Cro_ZachFamCir,
			Cro_ZachWorkCir,
			Cro_MelFamCir,
			Cro_PhoCrit,
			Cro_PhoLove,
			Cro_Crowd3,
			Cro_DataProv,

			Thi_Human,
			Thi_Male,
			Thi_Female,
			Thi_Name,
			Thi_Legal,
			Thi_Home,
			Thi_Muskegon,
			Thi_Neimeyer,
			Thi_CampusView,
			Thi_Location,
			Thi_AppleRidge,
			Thi_Caldonia,
			Thi_FabricPlat,
			Thi_Attend,
			Thi_RPHS,
			Thi_GradePointAvg,
			Thi_ACTTest,
			Thi_Overall,
			Thi_GrandValley,
			Thi_Aei,
			Thi_Software,
			Thi_Art,
			Thi_Graphics,
			Thi_Games,
			Thi_Music,
			Thi_Evolution,
			Thi_ArtlIntel,
			Thi_Physics,
			Thi_Height,
			Thi_Weight,
			Thi_Beauty,
			Thi_TigersGame,
			Thi_MlbGame,
			Thi_DetroitTigers,
			Thi_BostonRedSox,
			Thi_ComericaPark,
			Thi_Bottom11,
			Thi_Inning,
			Thi_Attendance,
			Thi_Excitement,
			Thi_WebPage,
			Thi_CutePhoto,
			Thi_Photo,
			Thi_Digital,
			Thi_Favorite,
			Thi_FocalLength,
			Thi_Exposure,
			Thi_FStop,
			Thi_IsoSpeed,
			Thi_Quality,
			Thi_Subject,
			Thi_Object,
			Thi_Smile,
			Thi_Pigtail,
			Thi_Rope,
			Thi_Blue,
			Thi_Swing,
			Thi_FisherPrice,
			Thi_Happiness,
			Thi_Fun,
			Thi_Cuteness/*,

			Com_First_1,
			Com_First_2,
			Com_First_3,
			Com_Love_1,
			Com_Love2,
			Com_Love3_Del,
			Com_Love4,
			Com_Crowd_1,
			Com_Sec_1c,
			Com_Sec_2b,
			Com_Sec_3_Del,
			Com_Sec_4,
			Com_Sec_5b,
			Com_First_4,
			Com_PhoLove_1,
			Com_PhoCrit_1,
			Com_ZFam_1,
			Com_ZFam_2*/
		}

		public const int NumArtifacts = 106;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Artifact AddArtifact(DataSet pSet, ArtifactId pId, ArtifactTypeId pArtTypeId,
													SetupUsers.MemberId pCreatorId, bool pTestMode) {
			var a = new Artifact();
			a.ArtifactId = (long)pId;
			a.IsPrivate = false;
			a.CreatedTimestamp = pSet.SetupTimestamp;

			pSet.AddNodeAndIndex(a, x => x.ArtifactId, pTestMode);
			pSet.AddRootRel<RootContainsArtifact>(a, pTestMode);

			var relT = DataRel.Create(a, new ArtifactUsesArtifactType(),
				pSet.GetNode<ArtifactType>((long)pArtTypeId), pTestMode);
			pSet.AddRel(relT);

			var relM = DataRel.Create(
				pSet.GetNode<Member>((long)pCreatorId), new MemberCreatesArtifact(), a, pTestMode);
			pSet.AddRel(relM);

			return a;
		}

	}

}