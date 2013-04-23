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

			/*Label_A1234,
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
			Cro_DataProv,*/

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
			Thi_Cuteness
		}

		public const int NumArtifacts = 76;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillArtifact(DataSet pSet, Artifact pArtifact, ArtifactId pId,
													SetupUsers.MemberId pCreatorId, bool pTestMode) {
			if ( !pSet.IsForTesting && pTestMode ) {
				return;
			}

			pArtifact.ArtifactId = (long)pId;
			pArtifact.Created = pSet.SetupTimestamp;
			pSet.RegisterBaseClassNode(pArtifact, typeof(Artifact), pArtifact.ArtifactId, pTestMode);

			Member m = pSet.GetNode<Member>((long)pCreatorId);
			var relM = DataRel.Create(m, new MemberCreatesArtifact(), pArtifact, pTestMode);
			pSet.AddRel(relM);
		}

	}

}