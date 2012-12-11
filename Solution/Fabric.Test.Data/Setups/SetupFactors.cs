﻿using System;
using Fabric.Domain;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class SetupFactors {

		public enum FactorId {
			FZ_Zach_Human_IsA_Male_Def = 1,
			FZ_Zach_Human_Start_Def,
			FZ_Zach_Name_ZK,
			FZ_Zach_Name_Legal_ZRK_Def,
			FZ_Zach_Muskegon_FoundIn_Home_Start,
			FZ_Zach_Muskegon_FoundIn_Home_End,
			FZ_Zach_Neimeyer_FoundIn_Home_Start,
			FZ_Zach_Neimeyer_FoundIn_Home_End,
			FZ_Zach_CampView_FoundIn_Home_Start,
			FZ_Zach_CampView_FoundIn_Home_End,
			FZ_Zach_AppRidge_FoundIn_Home_Start,
			FZ_Zach_AppRidge_FoundIn_Home_End,
			FZ_Zach_Caledonia_FoundIn_Home_Start,
			FZ_Zach_Fabric_ViewSuggLearn,
			FZ_Zach_Mel_ViewSuggView,
			FZ_Zach_RPHS_PartIn_Attend_Start,
			FZ_Zach_RPHS_PartIn_Attend_End,
			FZ_Zach_RPHS_PartIn_Attend_GPA,
			FZ_Zach_ACT_PartIn_Overall,
			FZ_Zach_GVSU_PartIn_Attend_Start,
			FZ_Zach_GVSU_PartIn_Attend_End,
			FZ_Zach_AEI_RelTo_ViewSuggView,
			FZ_Zach_Software_Produce,
			FZ_Zach_Art_Produce,
			FZ_Zach_Graphics_Produce,
			FZ_Zach_Games_Produce,
			FZ_Zach_Music_Produce,
			FZ_Zach_Software_Interest,
			FZ_Zach_Graphics_Interest,
			FZ_Zach_Evolution_Interest,
			FZ_Zach_Games_Interest,
			FZ_Zach_ArtIntel_Interest,
			FZ_Zach_Physics_Interest,
			FZ_Zach_Human_IsA_Height,
			FZ_Zach_Human_IsA_WeightA,
			FZ_Zach_Human_IsA_WeightB,
			FZ_Zach_Human_IsA_WeightC_Del,
			FZ_Zach_Human_IsA_WeightD_Del,
			FZ_Zach_Human_IsA_WeightE,
			FZ_Zach_Human_IsA_WeightF,

			FM_Mel_Human_IsA_Female_Def,
			FM_Mel_Human_IsA_Start_Def,
			FM_Mel_Name_HasA_MM_End,
			FM_Mel_Name_HasA_MK_Start,
			FM_Mel_Name_HasA_Legal_MRM_End_Def,
			FM_Mel_Name_HasA_Legal_MRK_Start_Def,
			FM_Mel_Caldonia_FoundIn_Home,
			FM_Mel_Zach_ViewSuggView,
			FZ_Mel_Human_IsA_Beauty,
			FM_Mel_Human_IsA_Height,

			BB_Game_MlbGame_IsA_Def,
			BB_Game_MlbGame_IsA_Start_Def,
			BB_Game_Tigers_HasA_Def,
			BB_Game_RedSox_HasA_Def,
			BB_Game_Comerica_FoundIn_Def,
			BB_Game_MlbGame_IsA_End,
			BB_Game_MlbGame_IsA_Innings,
			BZ_Game_MlbGame_IsA_Attendance,
			BZ_Game_Bot11_HasA,
			BZ_Game_MlbGame_IsA_Excite,
			BM_Game_MlbGame_IsA_Excite,
			FE_Game_MlbGame_IsA_Excite,
			FP_Game_MlbGame_IsA_Excite,

			BB_Bot11_Inning_IsA_Def,
			BB_Bot11_Game_Belongs_Def,
			BB_Bot11_Inning_IsA_Start,
			BB_Bot11_Inning_IsA_End,
			BZ_Bot11_Inning_IsA_Excite,
			BM_Bot11_Inning_IsA_Excite,
			FE_Bot11_Inning_IsA_Excite,
			FP_Bot11_Inning_IsA_Excite,

			GG_CuteUrl_WebPage_IsA_Def,
			GG_CuteUrl_CutePho_Refers_Def,
			GG_CuteUrl_KinPhoGal_Belongs_Def,

			GG_CutePho_Photo_IsA_Digi_Def,
			GG_CutePho_Photo_IsA_Occur_Def,
			GG_CutePho_Photo_IsA_Key4165_Def,
			GG_CutePho_Photo_IsA_TextImg9203,
			GG_CutePho_KinPhoGal_Belongs_Def,
			GG_CutePho_Receives_Favorite,
			GG_CutePho_Photo_IsA_Focal,
			GZ_CutePho_Photo_IsA_Focal,
			GM_CutePho_Photo_IsA_Focal,
			GG_CutePho_Photo_IsA_Expose,
			GG_CutePho_Photo_IsA_FStop,
			GG_CutePho_Photo_IsA_Iso,
			GG_CutePho_Photo_IsA_Quality,
			GM_CutePho_Ellie_Refers_Subject,
			GM_CutePho_Smile_HasA_Subject,
			GM_CutePho_Pigtail_HasA_Subject,
			GM_CutePho_Rope_HasA_Object_Blue,
			GM_CutePho_Swing_HasA_Object,
			GZ_CutePho_Ellie_Refers_Subject,
			GZ_CutePho_Fisher_Refers_Object,
			GZ_CutePho_Swing_Refers_Object,
			GM_CutePho_Happiness_Emotes,
			GM_CutePho_Fun_Emotes,
			GZ_CutePho_Photo_IsA_Occur_QualityA,
			GZ_CutePho_Photo_IsA_Occur_QualityB,
			GZ_CutePho_Photo_IsA_Occur_QualityC,
			GM_CutePho_Photo_IsA_Occur_Quality,
			GZ_CutePho_Photo_IsA_Occur_Cuteness,
			GM_CutePho_Photo_IsA_Occur_Cuteness,
			GE_CutePho_Photo_IsA_Occur_Cuteness,

			FZ_Art_Music_Incomplete
		}

		public enum DescriptorId {
			IsA_Male = 1,
			IsA,
			HasA,
			HasA_Legal,
			IsFoundIn_Home,
			IsRelatedTo,
			ParticIn_Attend,
			ParticIn,
			Produces,
			IsInterestIn,
			IsA_Female,
			IsFoundIn,
			BelongsTo,
			RefersTo,
			IsA_Digital,
			Receives,
			RefersTo_Subject,
			HasA_Subject,
			HasA_Object_Blue,
			HasA_Object,
			RefersTo_Object,
			EmotesLike
		}

		public enum DescriptorRefId {
			Rel_Male = 1,
			Rel_Legal,
			Type_Home,
			Type_Attend,
			Rel_Female,
			Rel_Digital,
			Prim_RT_Subject,
			Prim_HA_Subject,
			Prim_HA1_Object,
			Rel_Blue,
			Prim_HA2_Object,
			Prim_RT_Object
		}

		public enum DirectorId {
			View_Sugg_Learn = 1,
			View_Sugg_View
		}

		public enum EventorId {
			Start_Day_1985_08_27 = 1,
			End_Month_2003_08,
			Start_Month_2003_08,
			End_Month_2004_08,
			Start_Month_2004_08,
			End_Month_2005_07,
			Start_Month_2005_07,
			End_Month_2007_12,
			Start_Day_2007_11_13,
			Start_Month_1999_08,
			End_Month_2003_06,
			Occur_Year_2003,
			Occur_Year_2002,
			End_Month_2007_05,
			Occur_Minute_2012_01_16_06_43,
			Occur_Minute_2012_03_27_06_22,
			Occur_Minute_2012_05_04_06_59,
			Occur_Minute_2012_06_29_06_31,
			Start_Day_1984_11_13,
			End_Day_2007_08_11,
			Start_Day_2007_08_11,
			Start_Minute_2012_04_08_13_05,
			End_Minute_2012_04_08_17_50,
			Start_Minute_2012_04_08_17_23,
			Occur_Second_2012_05_26_17_57_04,
			Occur_Second_2012_05_26_20_00_01,
			Occur_Second_2012_05_28_16_24_41,
			Occur_Second_2012_05_29_17_59_59,
			Occur_Second_2012_05_29_18_30_03,
			Occur_Second_2012_05_29_18_31_03
		}

		public enum IdentorId {
			Text_ZachKin = 1,
			Text_ZachRichKin,
			Text_LakerLane,
			Text_Silverbow,
			Text_MelMc,
			Text_MelKin,
			Text_MelRoseMc,
			Text_MelRoseKin,
			Key_4165,
			Text_Img9023Jpg
		}

		public enum LocatorId {
			LakerLane = 1,
			Silverbow,
			InningPos1D,
			CabinSwing,
			ElliePos2D,
			SmilePos2D,
			FisherPos2D
		}

		public enum VectorId {
			GPA_3960_MilliPoints = 1,
			Overall_32_Points,
			Height_1730000_MicroMeters,
			Weight_69_KiloGrams,
			Weight_69812_Grams,
			Weight_89609_Grams,
			Weight_96877_Grams,
			Weight_68901328_MilliGrams,
			Weight_68501_Grams,
			Beauty_100_None,
			Height_1574_MilliMeters,
			Inning_11_None,
			Inning_11_Index,
			Attendance_30788_User,
			Excitement_92_None,
			Excitement_75_None,
			Excitement_88_None,
			Excitement_98_None,
			Excitement_95_None,
			Excitement_83_None,
			FocalLen_50_MilliMeters,
			FocalLen_50000000_NanoMeters,
			FocalLen_50000_MicroMeters,
			Exposure_8000_MicroSeconds,
			FStop_45000_MilliUnit,
			ISO_100_Unit,
			Quality_92_None,
			Quality_88_None,
			Quality_95_None,
			Quality_98_None,
			Cuteness_96_None,
			Cuteness_100_None,
			Cuteness_82_None
		}

		public const int NumFactors = 105;

		public const int NumFactorDescriptors = 104;
		public const int NumFactorDirectors = 4;
		public const int NumFactorEventors = 40;
		public const int NumFactorIdentors = 11;
		public const int NumFactorLocators = 8;
		public const int NumFactorVectors = 36;

		public const int NumDescriptors = 22;
		public const int NumDescriptorRefines = 12;
		public const int NumDirectors = 2;
		public const int NumEventors = 30;
		public const int NumIdentors = 10;
		public const int NumLocators = 7;
		public const int NumVectors = 33;

		private readonly DataSet vSet;
		private readonly bool vTestMode;
		private int vIdCount;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			var sf = new SetupFactors(pSet);
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupFactors(DataSet pSet) {
			vSet = pSet;
			vTestMode = true;
			
			vIdCount = 0;
			AddDescriptor(DescriptorTypeId.IsA, null, null, SetupArtifacts.ArtifactId.Thi_Male);
			AddDescriptor(DescriptorTypeId.IsA);
			AddDescriptor(DescriptorTypeId.HasA);
			AddDescriptor(DescriptorTypeId.HasA, null, null, SetupArtifacts.ArtifactId.Thi_Legal);
			AddDescriptor(DescriptorTypeId.IsFoundIn, null, SetupArtifacts.ArtifactId.Thi_Home);
			AddDescriptor(DescriptorTypeId.IsRelatedTo);
			AddDescriptor(DescriptorTypeId.ParticipatesIn, null, SetupArtifacts.ArtifactId.Thi_Attend);
			AddDescriptor(DescriptorTypeId.ParticipatesIn);
			AddDescriptor(DescriptorTypeId.Produces);
			AddDescriptor(DescriptorTypeId.IsInterestedIn);
			AddDescriptor(DescriptorTypeId.IsA, null, null, SetupArtifacts.ArtifactId.Thi_Female);
			AddDescriptor(DescriptorTypeId.IsFoundIn);
			AddDescriptor(DescriptorTypeId.BelongsTo);
			AddDescriptor(DescriptorTypeId.RefersTo);
			AddDescriptor(DescriptorTypeId.IsA, null, null, SetupArtifacts.ArtifactId.Thi_Digital);
			AddDescriptor(DescriptorTypeId.Receives);
			AddDescriptor(DescriptorTypeId.RefersTo, SetupArtifacts.ArtifactId.Thi_Subject);
			AddDescriptor(DescriptorTypeId.HasA, SetupArtifacts.ArtifactId.Thi_Subject);
			AddDescriptor(DescriptorTypeId.HasA,
				SetupArtifacts.ArtifactId.Thi_Object, null, SetupArtifacts.ArtifactId.Thi_Blue);
			AddDescriptor(DescriptorTypeId.HasA, SetupArtifacts.ArtifactId.Thi_Object);
			AddDescriptor(DescriptorTypeId.RefersTo, SetupArtifacts.ArtifactId.Thi_Object);
			AddDescriptor(DescriptorTypeId.EmotesLike);

			vIdCount = 0;
			AddDirector(DirectorTypeId.SuggestPath, DirectorActionId.View, DirectorActionId.Learn);
			AddDirector(DirectorTypeId.SuggestPath, DirectorActionId.View, DirectorActionId.View);

			vIdCount = 0;
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Day, new DateTime(1985, 8, 27));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Month, new DateTime(2003, 8, 1));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Month, new DateTime(2003, 8, 1));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Month, new DateTime(2004, 8, 1));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Month, new DateTime(2004, 8, 1));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Month, new DateTime(2005, 7, 1));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Month, new DateTime(2005, 7, 1));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Month, new DateTime(2007, 12, 1));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Day, new DateTime(2007, 11, 13));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Month, new DateTime(1999, 8, 1));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Month, new DateTime(2003, 6, 1));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Year, new DateTime(2003, 1, 1));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Year, new DateTime(2002, 1, 1));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Month, new DateTime(2007, 5, 1));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Minute,
				new DateTime(2012, 1, 16, 6, 43, 0));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Minute,
				new DateTime(2012, 3, 27, 6, 22, 0));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Minute,
				new DateTime(2012, 5, 4, 6, 59, 0));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Minute,
				new DateTime(2012, 6, 29, 6, 31, 0));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Day, new DateTime(1984, 11, 13));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Day, new DateTime(2007, 8, 11));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Day, new DateTime(2007, 8, 11));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Minute,
				new DateTime(2012, 4, 8, 13, 5, 0));
			AddEventor(EventorTypeId.End, EventorPrecisionId.Minute,
				new DateTime(2012, 4, 8, 17, 50, 0));
			AddEventor(EventorTypeId.Start, EventorPrecisionId.Minute,
				new DateTime(2012, 4, 08, 17, 23, 0));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Second,
				new DateTime(2012, 5, 26, 17, 57, 0));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Second,
				new DateTime(2012, 5, 26, 20, 00, 01));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Second,
				new DateTime(2012, 5, 28, 16, 24, 41));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Second,
				new DateTime(2012, 5, 29, 17, 59, 59));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Second,
				new DateTime(2012, 5, 29, 18, 30, 03));
			AddEventor(EventorTypeId.Occur, EventorPrecisionId.Second,
				new DateTime(2012, 5, 29, 18, 31, 0));

			vIdCount = 0;
			AddIdentor(IdentorTypeId.Text, "Zach Kinstner");
			AddIdentor(IdentorTypeId.Text, "Zachary Richard Kinstner");
			AddIdentor(IdentorTypeId.Text, "10262 Laker Lane");
			AddIdentor(IdentorTypeId.Text, "1731 Silverbow");
			AddIdentor(IdentorTypeId.Text, "Melissa McDonald");
			AddIdentor(IdentorTypeId.Text, "Melissa Kinstner");
			AddIdentor(IdentorTypeId.Text, "Melissa Rose McDonald");
			AddIdentor(IdentorTypeId.Text, "Melissa Rose Kinstner");
			AddIdentor(IdentorTypeId.Key, "4165");
			AddIdentor(IdentorTypeId.Text, "IMG_9203.JPG");

			vIdCount = 0;
			AddLocator(LocatorTypeId.EarthCoord, -85.891373, 42.955912, 0);
			AddLocator(LocatorTypeId.EarthCoord, -85.621265, 42.830739, 0);
			AddLocator(LocatorTypeId.RelPos1D, 0.942, 0, 0);
			AddLocator(LocatorTypeId.EarthCoord, -85.827441, 43.79177, 0);
			AddLocator(LocatorTypeId.RelPos2D, 0.5, 0.333, 0);
			AddLocator(LocatorTypeId.RelPos2D, 0.55, 0.4, 0);
			AddLocator(LocatorTypeId.RelPos2D, 0.61, 0.812345, 0);

			vIdCount = 0;
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_GradePointAvg,
				3960, VectorUnitPrefixId.Milli, VectorUnitId.Point);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Overall,
				32, VectorUnitPrefixId.Base, VectorUnitId.Point);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Height,
				1730000, VectorUnitPrefixId.Micro, VectorUnitId.Metre);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Weight,
				69, VectorUnitPrefixId.Kilo, VectorUnitId.Gram);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Weight,
				69812, VectorUnitPrefixId.Base, VectorUnitId.Gram);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Weight,
				89609, VectorUnitPrefixId.Base, VectorUnitId.Gram);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Weight,
				96877, VectorUnitPrefixId.Base, VectorUnitId.Gram);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Weight,
				68901328, VectorUnitPrefixId.Milli, VectorUnitId.Gram);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Weight,
				68501, VectorUnitPrefixId.Base, VectorUnitId.Gram);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Beauty,
				100, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Height,
				1574, VectorUnitPrefixId.Milli, VectorUnitId.Metre);

			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Inning,
				11, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Inning,
				11, VectorUnitPrefixId.Base, VectorUnitId.Index);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Attendance,
				30788, VectorUnitPrefixId.Base, VectorUnitId.Person);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Excitement,
				92, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Excitement,
				75, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Excitement,
				88, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Excitement,
				98, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Excitement,
				95, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Excitement,
				83, VectorUnitPrefixId.Base, VectorUnitId.None);

			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_FocalLength,
				50, VectorUnitPrefixId.Milli, VectorUnitId.Metre);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_FocalLength,
				50000000, VectorUnitPrefixId.Nano, VectorUnitId.Metre);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_FocalLength,
				50000, VectorUnitPrefixId.Micro, VectorUnitId.Metre);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_Exposure,
				8000, VectorUnitPrefixId.Micro, VectorUnitId.Second);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_FStop,
				4500, VectorUnitPrefixId.Milli, VectorUnitId.Unit);
			AddVector(VectorTypeId.PosLong, SetupArtifacts.ArtifactId.Thi_IsoSpeed,
				100, VectorUnitPrefixId.Base, VectorUnitId.Unit);

			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Quality,
				92, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Quality,
				88, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Quality,
				95, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Quality,
				98, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Cuteness,
				96, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Cuteness,
				100, VectorUnitPrefixId.Base, VectorUnitId.None);
			AddVector(VectorTypeId.OppFavor, SetupArtifacts.ArtifactId.Thi_Cuteness,
				82, VectorUnitPrefixId.Base, VectorUnitId.None);

			////

			const SetupUsers.MemberId mfz = SetupUsers.MemberId.FabZach;
			const SetupUsers.MemberId mfm = SetupUsers.MemberId.FabMel;
			const SetupUsers.MemberId mbb = SetupUsers.MemberId.BookBookData;
			const SetupUsers.MemberId mbz = SetupUsers.MemberId.BookZach;
			const SetupUsers.MemberId mbm = SetupUsers.MemberId.BookMel;
			const SetupUsers.MemberId mfe = SetupUsers.MemberId.FabEllie;
			const SetupUsers.MemberId mfp = SetupUsers.MemberId.FabPenny;
			const SetupUsers.MemberId mgg = SetupUsers.MemberId.GalGalData;
			const SetupUsers.MemberId mgz = SetupUsers.MemberId.GalZach;
			const SetupUsers.MemberId mgm = SetupUsers.MemberId.GalMel;
			const SetupUsers.MemberId mge = SetupUsers.MemberId.GalEllie;

			const SetupArtifacts.ArtifactId zach = SetupArtifacts.ArtifactId.User_Zach;
			const SetupArtifacts.ArtifactId mel = SetupArtifacts.ArtifactId.User_Mel;
			const SetupArtifacts.ArtifactId game = SetupArtifacts.ArtifactId.Thi_TigersGame;
			const SetupArtifacts.ArtifactId bot11 = SetupArtifacts.ArtifactId.Thi_Bottom11;
			const SetupArtifacts.ArtifactId cuteUrl = SetupArtifacts.ArtifactId.Url_CutePhoto;
			const SetupArtifacts.ArtifactId cutePho = SetupArtifacts.ArtifactId.Thi_CutePhoto;

			const FactorAccessId atStd = FactorAccessId.Standard;
			const FactorAccessId atPub = FactorAccessId.Public;

			const FactorAssertionId asUnd = FactorAssertionId.Undefined;
			const FactorAssertionId asFac = FactorAssertionId.Fact;
			const FactorAssertionId asOpi = FactorAssertionId.Opinion;

			vIdCount = 0;
			
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA_Male, null, null, null, null, null,
				true, atPub, asFac, false, "Zach is a human male.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Start_Day_1985_08_27, null, null, null,
				true, atPub, asFac, false, "Zach is a human born on Aug 27 1985.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Name,
				DescriptorId.HasA, null, null, IdentorId.Text_ZachKin, null, null,
				false, atPub, asFac, false, "Zach has a name 'Zach Kinstner'.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Name,
				DescriptorId.HasA_Legal, null, null, IdentorId.Text_ZachRichKin, null, null,
				true, atPub, asFac, false, "Zach has a legal name 'Zachary Richard Kinstner'.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Muskegon,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Day_1985_08_27, null, null, null,
				false, atPub, asFac, false, "Zach's home was Muskegon starting on Aug 27 1985..");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Muskegon,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2003_08, null, null, null,
				false, atPub, asFac, false, "Zach's home was Muskegon ending in Aug 2003.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Neimeyer,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Month_2003_08, null, null, null,
				false, atPub, asFac, false, "Zach's home was Neimeyer starting in Aug 2003.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Neimeyer,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2004_08, null, null, null,
				false, atPub, asFac, false, "Zach's home was Neimeyer ending in Aug 2004.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_CampusView,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Month_2004_08,
					IdentorId.Text_LakerLane, LocatorId.LakerLane, null,
				false, atPub, asFac, false, "Zach's home was Campus View starting in Aug 2004.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_CampusView,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2005_07, null, null, null,
				false, atPub, asFac, false, "Zach's home was Campus View ending in Jul 2005.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_AppleRidge,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Month_2005_07, null, null, null,
				false, atPub, asFac, false, "Zach's home was Apple Ridge starting in Jul 2005.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_AppleRidge,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2007_12, null, null, null,
				false, atPub, asFac, false, "Zach's home was Apple Ridge ending in Dec 2007.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Caldonia,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Day_2007_11_13,
					IdentorId.Text_Silverbow, LocatorId.Silverbow, null,
				false, atPub, asFac, false,
				"Zach's home was 1731 Silverbow, Caledonia starting on Nov 13, 2007.");

			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_FabricPlat,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_Learn, null, null, null, null,
				false, atStd, asUnd, false, "After viewing Zach, I suggest you learn about Fabric.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.User_Mel,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_View, null, null, null, null,
				false, atStd, asOpi, false, "After viewing Zach, I suggest you view Mel.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_RPHS,
				DescriptorId.ParticIn_Attend, null, EventorId.Start_Month_1999_08, null, null, null,
				false, atStd, asFac, false, "Zach attended RPHS starting in Aug 1999.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_RPHS,
				DescriptorId.ParticIn_Attend, null, EventorId.End_Month_2003_06, null, null, null,
				false, atStd, asFac, false, "Zach attended RPHS ending in Jun 2003.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_RPHS,
				DescriptorId.ParticIn_Attend, null, EventorId.Occur_Year_2003, null, null,
					VectorId.GPA_3960_MilliPoints,
				false, atStd, asFac, false, "Zach attended RPHS, with a 3.96 GPA in 2003.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_ACTTest,
				DescriptorId.ParticIn, null, EventorId.Occur_Year_2002, null, null,
					VectorId.Overall_32_Points,
				false, atStd, asFac, false, "Zach scored a 32 on the ACT Test in 2002.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_GrandValley,
				DescriptorId.ParticIn_Attend, null, EventorId.Start_Month_2003_08, null, null, null,
				false, atStd, asFac, false, "Zach attended GVSU starting in Aug 2003.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_GrandValley,
				DescriptorId.ParticIn_Attend, null, EventorId.End_Month_2007_05, null, null, null,
				false, atStd, asFac, false, "Zach attended GVSU ending in May 2007.");

			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Aei,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_View, null, null, null, null,
				false, atStd, asUnd, false,
				"After viewing Zach, I suggest viewing Aesthetic Interactive.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Software,
				DescriptorId.Produces, null, null, null, null, null,
				false, atStd, asUnd, false, "Zach creates software.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Art,
				DescriptorId.Produces, null, null, null, null, null,
				false, atStd, asUnd, false, "Zach creates art.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Graphics,
				DescriptorId.Produces, null, null, null, null, null,
				false, atStd, asUnd, false, "Zach creates graphics.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Games,
				DescriptorId.Produces, null, null, null, null, null,
				false, atStd, asUnd, false, "Zach creates games.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Music,
				DescriptorId.Produces, null, null, null, null, null,
				false, atStd, asUnd, false, "Zach creates music.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Software,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, atStd, asOpi, false, "Zach is interested in software.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Graphics,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, atStd, asOpi, false, "Zach is interested in graphics.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Evolution,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, atStd, asOpi, false, "Zach is interested in evolution.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Games,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, atStd, asOpi, false, "Zach is interested in games.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_ArtlIntel,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, atStd, asOpi, false, "Zach is interested in artificial intelligence.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Physics,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, atStd, asOpi, false, "Zach is interested in physics.");

			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, null, null, null, VectorId.Height_1730000_MicroMeters,
				false, atStd, asFac, false, "Zach is 1.73 meters tall.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_01_16_06_43, null, null,
					VectorId.Weight_69_KiloGrams,
				false, atStd, asFac, false, "Zach is 69.2kg at this time.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_03_27_06_22, null, null,
					VectorId.Weight_69812_Grams,
				false, atStd, asFac, false, "Zach is 69.8kg at this time.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_05_04_06_59, null, null,
					VectorId.Weight_89609_Grams,
				false, atStd, asFac, true, "Zach 89.6kg at this time.", true,
				FactorId.FZ_Zach_Human_IsA_WeightB);
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_05_04_06_59, null, null,
					VectorId.Weight_96877_Grams,
				false, atStd, asFac, true, "Zach 96.8kg at this time.", true,
				FactorId.FZ_Zach_Human_IsA_WeightC_Del);
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_05_04_06_59, null, null,
					VectorId.Weight_68901328_MilliGrams,
				false, atStd, asFac, false, "Zach is 68.9kg at this time.");
			AddFactor(mfz, zach, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_06_29_06_31, null, null,
					VectorId.Weight_68501_Grams,
				false, atStd, asFac, false, "Zach is 68.5kg at this time.");

			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA_Female, null, null, null, null, null,
				true, atPub, asFac, false, "Mel is a human female.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, EventorId.Start_Day_1984_11_13, null, null, null,
				true, atPub, asFac, false, "Mel is a human born on Nov 13 1984.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Name,
				DescriptorId.HasA, null, EventorId.End_Day_2007_08_11,
					IdentorId.Text_MelMc, null, null,
				false, atPub, asFac, false, "Mel's name is 'Melissa McDonald' ending on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Name,
				DescriptorId.HasA, null, EventorId.Start_Day_2007_08_11,
					IdentorId.Text_MelKin, null, null,
				false, atPub, asFac, false,
				"Mel's name is 'Melissa Kinsnter' starting on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Name,
				DescriptorId.HasA_Legal, null, EventorId.End_Day_2007_08_11,
					IdentorId.Text_MelRoseMc, null, null,
				true, atPub, asFac, false,
				"Mel's legal name is 'Melissa Rose McDonald' ending on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Name,
				DescriptorId.HasA_Legal, null, EventorId.Start_Day_2007_08_11,
					IdentorId.Text_MelRoseKin, null, null,
				true, atPub, asFac, false,
				"Mel's legal name is 'Melissa Rose Kinstner' starting on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Caldonia,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Day_2007_11_13,
				IdentorId.Text_Silverbow, null, null,
				false, atPub, asFac, false,
				"Mel's home is 1731 Silverbow Caledonia starting on Nov 13 2007.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.User_Zach,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_View, null, null, null, null,
				false, atPub, asOpi, false, "After viewing Mel, I suggest viewing Zach.");
			AddFactor(mfz, mel, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, null, null, null, VectorId.Beauty_100_None,
				false, atPub, asOpi, false, "Mel is a human with 100 Beauty.");
			AddFactor(mfm, mel, SetupArtifacts.ArtifactId.Thi_Human,
				DescriptorId.IsA, null, null, null, null, VectorId.Height_1574_MilliMeters,
				false, atPub, asFac, false, "Mel is 1,574mm tall.");

			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, null,
				true, atPub, asFac, false, "The game is an MLB game.");
			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, EventorId.Start_Minute_2012_04_08_13_05, null, null, null,
				true, atPub, asFac, false, "The game is an MLB game stating at this time.");
			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_DetroitTigers,
				DescriptorId.HasA, null, null, null, null, null,
				true, atPub, asFac, false, "The game includes the Detroit Tigers.");
			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_BostonRedSox,
				DescriptorId.HasA, null, null, null, null, null,
				true, atPub, asFac, false, "The game includes the Boston Red Sox.");
			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_ComericaPark,
				DescriptorId.IsFoundIn, null, null, null, null, null,
				true, atPub, asFac, false, "The game was played at Comerica Park.");
			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, EventorId.End_Minute_2012_04_08_17_50, null, null, null,
				false, atPub, asFac, false, "The game is an MLB game ending at this time.");
			AddFactor(mbb, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Inning_11_None,
				false, atPub, asFac, false, "The game has 11 innings.");
			AddFactor(mbz, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Attendance_30788_User,
				false, atPub, asFac, false, "The game has an attendance of 30,788 users.");
			AddFactor(mbz, game, SetupArtifacts.ArtifactId.Thi_Bottom11,
				DescriptorId.HasA, null, null, null, LocatorId.InningPos1D, VectorId.Inning_11_Index,
				false, atPub, asFac, false,
				"The game has this particular inning as its 11th inning at 94.2% of completion.");
			AddFactor(mbz, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_95_None,
				false, atStd, asOpi, false, "The game has 95 excitement.");
			AddFactor(mbm, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_83_None,
				false, atStd, asOpi, false, "The game has 83 excitement.");
			AddFactor(mfe, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_92_None,
				false, atStd, asOpi, false, "The game has 92 excitement.");
			AddFactor(mfp, game, SetupArtifacts.ArtifactId.Thi_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_98_None,
				false, atStd, asOpi, false, "The game has 98 excitement.");

			AddFactor(mbb, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, null, null, null, null,
				true, atStd, asFac, false, "This is an inning.");
			AddFactor(mbb, bot11, SetupArtifacts.ArtifactId.Thi_TigersGame,
				DescriptorId.BelongsTo, null, null, null, null, null,
				true, atStd, asFac, false, "The inning belongs to a particular game.");
			AddFactor(mbb, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, EventorId.Start_Minute_2012_04_08_17_23, null, null, null,
				false, atStd, asFac, false, "The inning starts at this time.");
			AddFactor(mbb, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, EventorId.End_Minute_2012_04_08_17_50, null, null, null,
				false, atStd, asFac, false, "The inning ends at this time.");
			AddFactor(mbz, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_95_None,
				false, atStd, asOpi, false, "The inning has a 95 excitement.");
			AddFactor(mbm, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_83_None,
				false, atStd, asOpi, false, "The inning has a 83 excitement.");
			AddFactor(mfe, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_92_None,
				false, atStd, asOpi, false, "The inning has a 92 excitement.");
			AddFactor(mfp, bot11, SetupArtifacts.ArtifactId.Thi_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_98_None,
				false, atStd, asOpi, false, "The inning has a 98 excitement.");

			AddFactor(mgg, cuteUrl, SetupArtifacts.ArtifactId.Thi_WebPage,
				DescriptorId.IsA, null, null, null, null, null,
				true, atStd, asUnd, false, "This is a web page.");
			AddFactor(mgg, cuteUrl, SetupArtifacts.ArtifactId.Thi_CutePhoto,
				DescriptorId.RefersTo, null, null, null, null, null,
				true, atStd, asUnd, false, "This URL refers to Cute Photo.");
			AddFactor(mgg, cuteUrl, SetupArtifacts.ArtifactId.App_KinPhoGal,
				DescriptorId.BelongsTo, null, null, null, null, null,
				true, atStd, asUnd, false, "This URL belongs to Kinstner Photo Gallery.");

			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA_Digital, null, null, null, null, null,
				true, atStd, asUnd, false, "This is a digital photo.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_26_17_57_04, null,
					LocatorId.CabinSwing, null,
				true, atStd, asFac, false, "This photo was taken at this time and location.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, IdentorId.Key_4165, null, null,
				true, atStd, asFac, false, "This photo has a key of 4165.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, IdentorId.Text_Img9023Jpg, null, null,
				false, atStd, asFac, false, "This photo is called 'IMG_9203.JPG'.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.App_KinPhoGal,
				DescriptorId.BelongsTo, null, null, null, null, null,
				true, atStd, asUnd, false, "This photo belongs to Kinstner Photo Gallery.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Favorite,
				DescriptorId.Receives, null, null, null, null, null,
				false, atStd, asUnd, false, "This photo received a Favorite distinction.");

			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FocalLen_50_MilliMeters,
				false, atStd, asFac, false, "This photo has a 50mm focal length.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FocalLen_50000000_NanoMeters,
				false, atStd, asFac, false, "This photo has a 0.05m focal length.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FocalLen_50000_MicroMeters,
				false, atStd, asFac, false, "This photo has a 50,000 micrometer focal length.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.Exposure_8000_MicroSeconds,
				false, atStd, asFac, false, "This photo has a 1/125 sec exposure.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FStop_45000_MilliUnit,
				false, atStd, asFac, false, "This photo 4.5 F-Stop.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.ISO_100_Unit,
				false, atStd, asFac, false, "This photo has a 100 ISO speed.");
			AddFactor(mgg, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.Quality_92_None,
				false, atStd, asOpi, false, "This photo has 92 quality.");

			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.User_Ellie,
				DescriptorId.RefersTo_Subject, null, null, null, LocatorId.ElliePos2D, null,
				false, atStd, asUnd, false, "This photo's subject refers to Ellie at this position.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Smile,
				DescriptorId.HasA_Subject, null, null, null, LocatorId.SmilePos2D, null,
				false, atStd, asUnd, false, "This photo's subject has a smile at this position.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Pigtail,
				DescriptorId.HasA_Subject, null, null, null, null, null,
				false, atStd, asUnd, false, "This photo's subject has a pigtail.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Rope,
				DescriptorId.HasA_Object_Blue, null, null, null, null, null,
				false, atStd, asUnd, false, "This photo's object has a blue rope.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Swing,
				DescriptorId.HasA_Object, null, null, null, null, null,
				false, atStd, asUnd, false, "This photo's object has a swing.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.User_Ellie,
				DescriptorId.RefersTo_Subject, null, null, null, LocatorId.ElliePos2D, null,
				false, atStd, asUnd, false, "This photo's subject refers to Ellie at this position.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_FisherPrice,
				DescriptorId.RefersTo_Object, null, null, null, LocatorId.FisherPos2D, null,
				false, atStd, asUnd, false, "This photo's object refers to Fisher-Price at this pos.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_Swing,
				DescriptorId.HasA_Object, null, null, null, null, null,
				false, atStd, asUnd, false, "This photo's object has a swing.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Happiness,
				DescriptorId.EmotesLike, null, null, null, null, null,
				false, atStd, asOpi, false, "This photo causes the emotion of happiness.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Fun,
				DescriptorId.EmotesLike, null, null, null, null, null,
				false, atStd, asOpi, false, "This photo causes the emotion of fun.");

			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_26_20_00_01, null, null,
					VectorId.Quality_88_None,
				false, atStd, asOpi, false, "This photo has 88 quality.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_28_16_24_41, null, null,
					VectorId.Quality_95_None,
				false, atStd, asOpi, false, "This photo has 95 quality.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_17_59_59, null, null,
					VectorId.Quality_92_None,
				false, atStd, asOpi, false, "This photo has 92 quality.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_18_30_03, null, null,
					VectorId.Quality_98_None,
				false, atStd, asOpi, false, "This photo has 98 quality.");
			AddFactor(mgz, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_17_59_59, null, null,
					VectorId.Cuteness_96_None,
				false, atStd, asOpi, false, "This photo has 96 cuteness.");
			AddFactor(mgm, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_18_30_03, null, null,
					VectorId.Cuteness_100_None,
				false, atStd, asOpi, false, "This photo has 100 cuteness.");
			AddFactor(mge, cutePho, SetupArtifacts.ArtifactId.Thi_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_18_31_03, null, null,
					VectorId.Cuteness_82_None,
				false, atStd, asOpi, false, "This photo has 82 cuteness.");

			AddFactor(mfz, SetupArtifacts.ArtifactId.Thi_Music, SetupArtifacts.ArtifactId.Thi_Art,
				null, null, null, null, null, null, false, FactorAccessId.Public,
				FactorAssertionId.Undefined, false, "", false);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddDescriptor(DescriptorTypeId pTypeId,
														SetupArtifacts.ArtifactId? pPrimModId=null,
														SetupArtifacts.ArtifactId? pDtModId=null,
														SetupArtifacts.ArtifactId? pRelModId=null) {
			var d = new Descriptor();
			d.DescriptorId = ++vIdCount;

			vSet.AddNodeAndIndex(d, x => x.DescriptorId, vTestMode);
			vSet.AddRootRel<RootContainsDescriptor>(d, vTestMode);

			var relDt = DataRel.Create(d, new DescriptorUsesDescriptorType(),
				vSet.GetNode<DescriptorType>((long)pTypeId), vTestMode);
			vSet.AddRel(relDt);

			if ( pPrimModId != null ) {
				var rel = DataRel.Create(d, new DescriptorRefinesPrimaryWithArtifact(),
					vSet.GetNode<Artifact>((long)pPrimModId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pDtModId != null ) {
				var rel = DataRel.Create(d, new DescriptorRefinesTypeWithArtifact(),
					vSet.GetNode<Artifact>((long)pDtModId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pRelModId != null ) {
				var rel = DataRel.Create(d, new DescriptorRefinesRelatedWithArtifact(),
					vSet.GetNode<Artifact>((long)pRelModId), vTestMode);
				vSet.AddRel(rel);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddDirector(DirectorTypeId pTypeId, DirectorActionId pPrimActId,
																		DirectorActionId pRelActId) {
			var d = new Director();
			d.DirectorId = ++vIdCount;

			vSet.AddNodeAndIndex(d, x => x.DirectorId, vTestMode);
			vSet.AddRootRel<RootContainsDirector>(d, vTestMode);

			var relDt = DataRel.Create(d, new DirectorUsesDirectorType(),
				vSet.GetNode<DirectorType>((long)pTypeId), vTestMode);
			vSet.AddRel(relDt);

			var relP = DataRel.Create(d, new DirectorUsesPrimaryDirectorAction(),
				vSet.GetNode<DirectorAction>((long)pPrimActId), vTestMode);
			vSet.AddRel(relP);

			var relA = DataRel.Create(d, new DirectorUsesRelatedDirectorAction(),
				vSet.GetNode<DirectorAction>((long)pRelActId), vTestMode);
			vSet.AddRel(relA);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddEventor(EventorTypeId pTypeId, EventorPrecisionId pPrecId, DateTime pDate) {
			var e = new Eventor();
			e.EventorId = ++vIdCount;
			e.DateTimeTimestamp = pDate.Ticks;

			vSet.AddNodeAndIndex(e, x => x.EventorId, vTestMode);
			vSet.AddRootRel<RootContainsEventor>(e, vTestMode);

			var relEt = DataRel.Create(e, new EventorUsesEventorType(),
				vSet.GetNode<EventorType>((long)pTypeId), vTestMode);
			vSet.AddRel(relEt);

			var relEp = DataRel.Create(e, new EventorUsesEventorPrecision(),
				vSet.GetNode<EventorPrecision>((long)pPrecId), vTestMode);
			vSet.AddRel(relEp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddIdentor(IdentorTypeId pTypeId, string pValue) {
			var i = new Identor();
			i.IdentorId = ++vIdCount;
			i.Value = pValue;

			vSet.AddNodeAndIndex(i, x => x.IdentorId, vTestMode);
			vSet.AddRootRel<RootContainsIdentor>(i, vTestMode);

			var relIt = DataRel.Create(i, new IdentorUsesIdentorType(),
				vSet.GetNode<IdentorType>((long)pTypeId), vTestMode);
			vSet.AddRel(relIt);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddLocator(LocatorTypeId pTypeId, double pX, double pY, double pZ) {
			var l = new Locator();
			l.LocatorId = ++vIdCount;
			l.ValueX = pX;
			l.ValueY = pY;
			l.ValueZ = pZ;

			vSet.AddNodeAndIndex(l, x => x.LocatorId, vTestMode);
			vSet.AddRootRel<RootContainsLocator>(l, vTestMode);

			var relLt = DataRel.Create(l, new LocatorUsesLocatorType(),
				vSet.GetNode<LocatorType>((long)pTypeId), vTestMode);
			vSet.AddRel(relLt);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddVector(VectorTypeId pTypeId, SetupArtifacts.ArtifactId pAxisArtId,
								long pValue, VectorUnitPrefixId pPrefId, VectorUnitId pUnitId) {
			var v = new Vector();
			v.VectorId = ++vIdCount;
			v.Value = pValue;

			vSet.AddNodeAndIndex(v, x => x.VectorId, vTestMode);
			vSet.AddRootRel<RootContainsVector>(v, vTestMode);

			var relVt = DataRel.Create(v, new VectorUsesVectorType(),
				vSet.GetNode<VectorType>((long)pTypeId), vTestMode);
			vSet.AddRel(relVt);

			var relA = DataRel.Create(v, new VectorUsesAxisArtifact(),
				vSet.GetNode<Artifact>((long)pAxisArtId), vTestMode);
			vSet.AddRel(relA);

			var relVu = DataRel.Create(v, new VectorUsesVectorUnit(),
				vSet.GetNode<VectorUnit>((long)pUnitId), vTestMode);
			vSet.AddRel(relVu);

			var relVup = DataRel.Create(v, new VectorUsesVectorUnitPrefix(),
				vSet.GetNode<VectorUnitPrefix>((long)pPrefId), vTestMode);
			vSet.AddRel(relVup);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddFactor(SetupUsers.MemberId pMemId, SetupArtifacts.ArtifactId pPrimArtId,
					SetupArtifacts.ArtifactId pRelArtId, DescriptorId? pDescId, DirectorId? pDirId,
					EventorId? pEventId, IdentorId? pIdentId, LocatorId? pLocId, VectorId? pVectId,
					bool pIsDefining, FactorAccessId pAccId, FactorAssertionId pAstId, bool pIsDeleted,
					string pNote, bool pIsCompleted=true, FactorId? pReplaceFactorId=null) {

			DateTime dt = vSet.SetupDateTime;

			var f = new Factor();
			f.FactorId = ++vIdCount;
			f.IsPublic = (pAccId == FactorAccessId.Public);
			f.IsDefining = pIsDefining;
			f.CreatedTimestamp = dt.AddMinutes(-1).Ticks;
			f.Note = pNote;

			if ( pIsCompleted ) {
				f.CompletedTimestamp = vSet.SetupTimestamp;
			}

			if ( pIsDeleted ) {
				f.DeletedTimestamp = dt.AddMinutes(5).Ticks;
			}

			vSet.AddNodeAndIndex(f, x => x.FactorId, vTestMode);
			vSet.AddRootRel<RootContainsFactor>(f, vTestMode);

			var relM = DataRel.Create(vSet.GetNode<Member>((long)pMemId),
				new MemberCreatesFactor(), f, vTestMode);
			vSet.AddRel(relM);

			var relPa = DataRel.Create(f, new FactorUsesPrimaryArtifact(),
				vSet.GetNode<Artifact>((long)pPrimArtId), vTestMode);
			vSet.AddRel(relPa);

			var relRa = DataRel.Create(f, new FactorUsesRelatedArtifact(),
				vSet.GetNode<Artifact>((long)pRelArtId), vTestMode);
			vSet.AddRel(relRa);

			var relFa = DataRel.Create(f, new FactorUsesFactorAssertion(),
				vSet.GetNode<FactorAssertion>((long)pAstId), vTestMode);
			vSet.AddRel(relFa);

			if ( pReplaceFactorId != null ) {
				var relRf = DataRel.Create(f, new FactorReplacesFactor(),
					vSet.GetNode<Factor>((long)pReplaceFactorId), vTestMode);
				vSet.AddRel(relRf);
			}

			if ( pDescId != null ) {
				var rel = DataRel.Create(f, new FactorUsesDescriptor(),
					vSet.GetNode<Descriptor>((long)pDescId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pDirId != null ) {
				var rel = DataRel.Create(f, new FactorUsesDirector(),
					vSet.GetNode<Director>((long)pDirId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pEventId != null ) {
				var rel = DataRel.Create(f, new FactorUsesEventor(),
					vSet.GetNode<Eventor>((long)pEventId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pIdentId != null ) {
				var rel = DataRel.Create(f, new FactorUsesIdentor(),
					vSet.GetNode<Identor>((long)pIdentId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pLocId != null ) {
				var rel = DataRel.Create(f, new FactorUsesLocator(),
					vSet.GetNode<Locator>((long)pLocId), vTestMode);
				vSet.AddRel(rel);
			}

			if ( pVectId != null ) {
				var rel = DataRel.Create(f, new FactorUsesVector(),
					vSet.GetNode<Vector>((long)pVectId), vTestMode);
				vSet.AddRel(rel);
			}

			vSet.ElapseTime();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public void GetFactorPieces(uint pFactorId, out Descriptor pDesc, out Director pDir,
							out Eventor pEvent, out Identor pIdent, out Locator pLoc, out Vector pVec) {
			Factor fac = FactorTable.FindRowById(pFactorId);
			pDesc = null;
			pDir = null;
			pEvent = null;
			pIdent = null;
			pLoc = null;
			pVec = null;

			if ( fac.FactorDescriptors.Count > 0 ) {
				pDesc = DescriptorTable.FindRowById(fac.FactorDescriptors[0].Descriptor.Id);
			}

			if ( fac.FactorDirectors.Count > 0 ) {
				pDir = DirectorTable.FindRowById(fac.FactorDirectors[0].Director.Id);
			}

			if ( fac.FactorEventors.Count > 0 ) {
				pEvent = EventorTable.FindRowById(fac.FactorEventors[0].Eventor.Id);
			}

			if ( fac.FactorIdentors.Count > 0 ) {
				pIdent = IdentorTable.FindRowById(fac.FactorIdentors[0].Identor.Id);
			}

			if ( fac.FactorLocators.Count > 0 ) {
				pLoc = LocatorTable.FindRowById(fac.FactorLocators[0].Locator.Id);
			}

			if ( fac.FactorVectors.Count > 0 ) {
				pVec = VectorTable.FindRowById(fac.FactorVectors[0].Vector.Id);
			}
		}

		/*--------------------------------------------------------------------------------------------* /
		public void GetDescriptorRefines(uint pDescId, out DescriptorRefine pPrimRefine,
												out DescriptorRefine pTypeRefine, out DescriptorRefine pRelRefine) {
			DescriptorRefId? prim = null;
			DescriptorRefId? type = null;
			DescriptorRefId? rel = null;

			switch ( pDescId ) {
				case (uint)DescriptorId.IsA:
				case (uint)DescriptorId.HasA:
				case (uint)DescriptorId.IsRelatedTo:
				case (uint)DescriptorId.ParticIn:
				case (uint)DescriptorId.Produces:
				case (uint)DescriptorId.IsInterestIn:
				case (uint)DescriptorId.IsFoundIn:
				case (uint)DescriptorId.BelongsTo:
				case (uint)DescriptorId.RefersTo:
				case (uint)DescriptorId.Receives:
				case (uint)DescriptorId.EmotesLike:
					break;

				case (uint)DescriptorId.IsA_Digital:
					rel = DescriptorRefId.Rel_Digital;
					break;

				case (uint)DescriptorId.RefersTo_Subject:
					prim = DescriptorRefId.Prim_RT_Subject;
					break;

				case (uint)DescriptorId.HasA_Object_Blue:
					prim = DescriptorRefId.Prim_HA1_Object;
					rel = DescriptorRefId.Rel_Blue;
					break;

				case (uint)DescriptorId.ParticIn_Attend:
					type = DescriptorRefId.Type_Attend;
					break;

				default:
					throw new Exception("DescriptorId "+pDescId+" is not handled yet.");
			}

			pPrimRefine = (prim == null ? null : DescriptorRefineTable.FindRowById((uint)prim));
			pTypeRefine = (type == null ? null : DescriptorRefineTable.FindRowById((uint)type));
			pRelRefine  = (rel  == null ? null : DescriptorRefineTable.FindRowById((uint)rel));
		}*/

	}

}