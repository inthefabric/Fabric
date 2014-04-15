using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Util;

namespace Fabric.Database.Init.Setups {

	/*================================================================================================*/
	public class SetupFactors : SetupVertices {

		private enum DescriptorId {
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

		private enum DirectorId {
			View_Sugg_Learn = 1,
			View_Sugg_View
		}

		private enum EventorId {
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

		private enum IdentorId {
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

		private enum LocatorId {
			LakerLane = 1,
			Silverbow,
			InningPos1D,
			CabinSwing,
			ElliePos2D,
			SmilePos2D,
			FisherPos2D
		}

		private enum VectorId {
			GPA_1230_MilliPoints = 1,
			Overall_6_Points,
			Height_1730000_MicroMeters,
			Weight_69_KiloGrams,
			Weight_69812_Grams,
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

		private Dictionary<long, Descriptor> DescMap;
		private Dictionary<long, Director> DirMap;
		private Dictionary<long, Eventor> EveMap;
		private Dictionary<long, Identor> IdenMap;
		private Dictionary<long, Locator> LocMap;
		private Dictionary<long, Vector> VecMap;
		private long vIdCount;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SetupFactors(DataSet pData) : base(pData) { }
			
		/*--------------------------------------------------------------------------------------------*/
		public void Create() {
			IsForTestingOnly = true;

			DescMap = new Dictionary<long, Descriptor>();
			DirMap = new Dictionary<long, Director>();
			EveMap = new Dictionary<long, Eventor>();
			IdenMap = new Dictionary<long, Identor>();
			LocMap = new Dictionary<long, Locator>();
			VecMap = new Dictionary<long, Vector>();
			
			vIdCount = 0;
			AddDescriptor(DescriptorType.Id.IsA, null, null, SetupArtifactId.Cla_Male);
			AddDescriptor(DescriptorType.Id.IsA);
			AddDescriptor(DescriptorType.Id.HasA);
			AddDescriptor(DescriptorType.Id.HasA, null, null, SetupArtifactId.Cla_Legal);
			AddDescriptor(DescriptorType.Id.IsFoundIn, null, SetupArtifactId.Cla_Home);
			AddDescriptor(DescriptorType.Id.IsRelatedTo);
			AddDescriptor(DescriptorType.Id.ParticipatesIn, null, SetupArtifactId.Cla_Attend);
			AddDescriptor(DescriptorType.Id.ParticipatesIn);
			AddDescriptor(DescriptorType.Id.Produces);
			AddDescriptor(DescriptorType.Id.IsInterestedIn);
			AddDescriptor(DescriptorType.Id.IsA, null, null, SetupArtifactId.Cla_Female);
			AddDescriptor(DescriptorType.Id.IsFoundIn);
			AddDescriptor(DescriptorType.Id.BelongsTo);
			AddDescriptor(DescriptorType.Id.RefersTo);
			AddDescriptor(DescriptorType.Id.IsA, null, null, SetupArtifactId.Cla_Digital);
			AddDescriptor(DescriptorType.Id.Receives);
			AddDescriptor(DescriptorType.Id.RefersTo, SetupArtifactId.Cla_Subject);
			AddDescriptor(DescriptorType.Id.HasA, SetupArtifactId.Cla_Subject);
			AddDescriptor(DescriptorType.Id.HasA,
				SetupArtifactId.Cla_Blue);
			AddDescriptor(DescriptorType.Id.HasA, SetupArtifactId.Cla_Object);
			AddDescriptor(DescriptorType.Id.RefersTo, SetupArtifactId.Cla_Object);
			AddDescriptor(DescriptorType.Id.EmotesLike);

			vIdCount = 0;
			AddDirector(DirectorType.Id.SuggestedPath, DirectorAction.Id.View, DirectorAction.Id.Learn);
			AddDirector(DirectorType.Id.SuggestedPath, DirectorAction.Id.View, DirectorAction.Id.View);

			vIdCount = 0;
			AddEventor(EventorType.Id.Start, 1985, 8, 27);
			AddEventor(EventorType.Id.End, 2003, 8);
			AddEventor(EventorType.Id.Start, 2003, 8);
			AddEventor(EventorType.Id.End, 2004, 8);
			AddEventor(EventorType.Id.Start, 2004, 8);
			AddEventor(EventorType.Id.End, 2005, 7);
			AddEventor(EventorType.Id.Start, 2005, 7);
			AddEventor(EventorType.Id.End, 2007, 12);
			AddEventor(EventorType.Id.Start, 2007, 11, 13);
			AddEventor(EventorType.Id.Start, 1999, 8);
			AddEventor(EventorType.Id.End, 2003, 6);
			AddEventor(EventorType.Id.Occur, 2003);
			AddEventor(EventorType.Id.Occur, 2002);
			AddEventor(EventorType.Id.End, 2007, 5);
			AddEventor(EventorType.Id.Occur, 2012, 1, 16, 6, 43);
			AddEventor(EventorType.Id.Occur, 2012, 3, 27, 6, 22);
			AddEventor(EventorType.Id.Occur, 2012, 5, 4, 6, 59);
			AddEventor(EventorType.Id.Occur, 2012, 6, 29, 6, 31);
			AddEventor(EventorType.Id.Start, 1984, 11, 13);
			AddEventor(EventorType.Id.End, 2007, 8, 11);
			AddEventor(EventorType.Id.Start, 2007, 8, 11);
			AddEventor(EventorType.Id.Start, 2012, 4, 8, 13, 5);
			AddEventor(EventorType.Id.End, 2012, 4, 8, 17, 50);
			AddEventor(EventorType.Id.Start, 2012, 4, 08, 17, 23);
			AddEventor(EventorType.Id.Occur, 2012, 5, 26, 17, 57, 0);
			AddEventor(EventorType.Id.Occur, 2012, 5, 26, 20, 0, 1);
			AddEventor(EventorType.Id.Occur, 2012, 5, 28, 16, 24, 41);
			AddEventor(EventorType.Id.Occur, 2012, 5, 29, 17, 59, 59);
			AddEventor(EventorType.Id.Occur, 2012, 5, 29, 18, 30, 03);
			AddEventor(EventorType.Id.Occur, 2012, 5, 29, 18, 31, 0);

			vIdCount = 0;
			AddIdentor(IdentorType.Id.Text, "Zach Kinstner");
			AddIdentor(IdentorType.Id.Text, "Zachary Richard Kinstner");
			AddIdentor(IdentorType.Id.Text, "10262 Laker Lane");
			AddIdentor(IdentorType.Id.Text, "1731 Silverbow");
			AddIdentor(IdentorType.Id.Text, "Melissa McDonald");
			AddIdentor(IdentorType.Id.Text, "Melissa Kinstner");
			AddIdentor(IdentorType.Id.Text, "Melissa Rose McDonald");
			AddIdentor(IdentorType.Id.Text, "Melissa Rose Kinstner");
			AddIdentor(IdentorType.Id.Key, "4165");
			AddIdentor(IdentorType.Id.Text, "IMG_9203.JPG");

			vIdCount = 0;
			AddLocator(LocatorType.Id.EarthCoord, -85.891373, 42.955912, 0);
			AddLocator(LocatorType.Id.EarthCoord, -85.621265, 42.830739, 0);
			AddLocator(LocatorType.Id.RelPos1D, 0.942, 0, 0);
			AddLocator(LocatorType.Id.EarthCoord, -85.827441, 43.79177, 0);
			AddLocator(LocatorType.Id.RelPos2D, 0.5, 0.333, 0);
			AddLocator(LocatorType.Id.RelPos2D, 0.55, 0.4, 0);
			AddLocator(LocatorType.Id.RelPos2D, 0.61, 0.812345, 0);

			vIdCount = 0;
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_GradePointAvg,
				3960, VectorUnitPrefix.Id.Milli, VectorUnit.Id.Point);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Overall,
				32, VectorUnitPrefix.Id.Base, VectorUnit.Id.Point);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Height,
				1730000, VectorUnitPrefix.Id.Micro, VectorUnit.Id.Metre);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Weight,
				69, VectorUnitPrefix.Id.Kilo, VectorUnit.Id.Gram);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Weight,
				69812, VectorUnitPrefix.Id.Base, VectorUnit.Id.Gram);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Weight,
				68901328, VectorUnitPrefix.Id.Milli, VectorUnit.Id.Gram);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Weight,
				68501, VectorUnitPrefix.Id.Base, VectorUnit.Id.Gram);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Beauty,
				100, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Height,
				1574, VectorUnitPrefix.Id.Milli, VectorUnit.Id.Metre);

			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Inning,
				11, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Inning,
				11, VectorUnitPrefix.Id.Base, VectorUnit.Id.Index);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Attendance,
				30788, VectorUnitPrefix.Id.Base, VectorUnit.Id.Person);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Excitement,
				92, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Excitement,
				75, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Excitement,
				88, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Excitement,
				98, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Excitement,
				95, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Excitement,
				83, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);

			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_FocalLength,
				50, VectorUnitPrefix.Id.Milli, VectorUnit.Id.Metre);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_FocalLength,
				50000000, VectorUnitPrefix.Id.Nano, VectorUnit.Id.Metre);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_FocalLength,
				50000, VectorUnitPrefix.Id.Micro, VectorUnit.Id.Metre);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_Exposure,
				8000, VectorUnitPrefix.Id.Micro, VectorUnit.Id.Second);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_FStop,
				4500, VectorUnitPrefix.Id.Milli, VectorUnit.Id.Unit);
			AddVector(VectorType.Id.PosLong, SetupArtifactId.Cla_IsoSpeed,
				100, VectorUnitPrefix.Id.Base, VectorUnit.Id.Unit);

			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Quality,
				92, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Quality,
				88, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Quality,
				95, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Quality,
				98, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Cuteness,
				96, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Cuteness,
				100, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);
			AddVector(VectorType.Id.OppFavor, SetupArtifactId.Cla_Cuteness,
				82, VectorUnitPrefix.Id.Base, VectorUnit.Id.None);

			////

			const SetupMemberId mfz = SetupMemberId.FabZach;
			const SetupMemberId mfm = SetupMemberId.FabMel;
			const SetupMemberId mbb = SetupMemberId.BookBookData;
			const SetupMemberId mbz = SetupMemberId.BookZach;
			const SetupMemberId mbm = SetupMemberId.BookMel;
			const SetupMemberId mfe = SetupMemberId.FabEllie;
			const SetupMemberId mfp = SetupMemberId.FabPenny;
			const SetupMemberId mgg = SetupMemberId.GalGalData;
			const SetupMemberId mgz = SetupMemberId.GalZach;
			const SetupMemberId mgm = SetupMemberId.GalMel;
			const SetupMemberId mge = SetupMemberId.GalEllie;

			const SetupArtifactId zach = SetupArtifactId.User_Zach;
			const SetupArtifactId mel = SetupArtifactId.User_Mel;
			const SetupArtifactId game = SetupArtifactId.Ins_TigersGame;
			const SetupArtifactId bot11 = SetupArtifactId.Ins_Bottom11;
			const SetupArtifactId cuteUrl = SetupArtifactId.Url_CutePhoto;
			const SetupArtifactId cutePho = SetupArtifactId.Ins_CutePhoto;

			const FactorAssertion.Id asUnd = FactorAssertion.Id.Undefined;
			const FactorAssertion.Id asFac = FactorAssertion.Id.Fact;
			const FactorAssertion.Id asOpi = FactorAssertion.Id.Opinion;

			vIdCount = (long)SetupFactorId.FZ_Zach_Human_IsA_Male_Def;
			
			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA_Male, null, null, null, null, null,
				true,  asFac, "Zach is a human male.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, EventorId.Start_Day_1985_08_27, null, null, null,
				true,  asFac, "Zach is a human born on Aug 27 1985.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Name,
				DescriptorId.HasA, null, null, IdentorId.Text_ZachKin, null, null,
				false,  asFac, "Zach has a name 'Zach Kinstner'.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Name,
				DescriptorId.HasA_Legal, null, null, IdentorId.Text_ZachRichKin, null, null,
				true,  asFac, "Zach has a legal name 'Zachary Richard Kinstner'.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Muskegon,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Day_1985_08_27, null, null, null,
				false,  asFac, "Zach's home was Muskegon starting on Aug 27 1985..");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Muskegon,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2003_08, null, null, null,
				false,  asFac, "Zach's home was Muskegon ending in Aug 2003.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_Neimeyer,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Month_2003_08, null, null, null,
				false,  asFac, "Zach's home was Neimeyer starting in Aug 2003.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_Neimeyer,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2004_08, null, null, null,
				false,  asFac, "Zach's home was Neimeyer ending in Aug 2004.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_CampusView,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Month_2004_08,
					IdentorId.Text_LakerLane, LocatorId.LakerLane, null,
				false,  asFac, "Zach's home was Campus View starting in Aug 2004.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_CampusView,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2005_07, null, null, null,
				false,  asFac, "Zach's home was Campus View ending in Jul 2005.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_AppleRidge,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Month_2005_07, null, null, null,
				false,  asFac, "Zach's home was Apple Ridge starting in Jul 2005.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_AppleRidge,
				DescriptorId.IsFoundIn_Home, null, EventorId.End_Month_2007_12, null, null, null,
				false,  asFac, "Zach's home was Apple Ridge ending in Dec 2007.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Caldonia,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Day_2007_11_13,
					IdentorId.Text_Silverbow, LocatorId.Silverbow, null,
				false,  asFac, "Zach's home was 1731 Silverbow, Caledonia starting on Nov 13, 2007.");

			AddFactor(mfz, zach, SetupArtifactId.Ins_FabricPlat,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_Learn, null, null, null, null,
				false, asUnd, "After viewing Zach, I suggest you learn about Fabric.");
			AddFactor(mfz, zach, SetupArtifactId.User_Mel,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_View, null, null, null, null,
				false, asOpi, "After viewing Zach, I suggest you view Mel.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_RPHS,
				DescriptorId.ParticIn_Attend, null, EventorId.Start_Month_1999_08, null, null, null,
				false, asFac, "Zach attended RPHS starting in Aug 1999.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_RPHS,
				DescriptorId.ParticIn_Attend, null, EventorId.End_Month_2003_06, null, null, null,
				false, asFac, "Zach attended RPHS ending in Jun 2003.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_RPHS,
				DescriptorId.ParticIn_Attend, null, EventorId.Occur_Year_2003, null, null,
					VectorId.GPA_1230_MilliPoints,
				false, asFac, "Zach attended RPHS, with a 1.23 GPA in 2003.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_ACTTest,
				DescriptorId.ParticIn, null, EventorId.Occur_Year_2002, null, null,
					VectorId.Overall_6_Points,
				false, asFac, "Zach scored a 6 on the ACT Test in 2002.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_GrandValley,
				DescriptorId.ParticIn_Attend, null, EventorId.Start_Month_2003_08, null, null, null,
				false, asFac, "Zach attended GVSU starting in Aug 2003.");
			AddFactor(mfz, zach, SetupArtifactId.Ins_GrandValley,
				DescriptorId.ParticIn_Attend, null, EventorId.End_Month_2007_05, null, null, null,
				false, asFac, "Zach attended GVSU ending in May 2007.");

			AddFactor(mfz, zach, SetupArtifactId.Ins_Aei,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_View, null, null, null, null,
				false, asUnd,
				"After viewing Zach, I suggest viewing Aesthetic Interactive.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Software,
				DescriptorId.Produces, null, null, null, null, null,
				false, asUnd, "Zach creates software.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Art,
				DescriptorId.Produces, null, null, null, null, null,
				false, asUnd, "Zach creates art.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Graphics,
				DescriptorId.Produces, null, null, null, null, null,
				false, asUnd, "Zach creates graphics.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Games,
				DescriptorId.Produces, null, null, null, null, null,
				false, asUnd, "Zach creates games.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Music,
				DescriptorId.Produces, null, null, null, null, null,
				false, asUnd, "Zach creates music.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Software,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, asOpi, "Zach is interested in software.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Graphics,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, asOpi, "Zach is interested in graphics.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Evolution,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, asOpi, "Zach is interested in evolution.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Games,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, asOpi, "Zach is interested in games.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_ArtlIntel,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, asOpi, "Zach is interested in artificial intelligence.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Physics,
				DescriptorId.IsInterestIn, null, null, null, null, null,
				false, asOpi, "Zach is interested in physics.");

			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, null, null, null, VectorId.Height_1730000_MicroMeters,
				false, asFac, "Zach is 1.73 meters tall.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_01_16_06_43, null, null,
					VectorId.Weight_69_KiloGrams,
				false, asFac, "Zach is 69.2kg at this time.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_03_27_06_22, null, null,
					VectorId.Weight_69812_Grams,
				false, asFac, "Zach is 69.8kg at this time.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_05_04_06_59, null, null,
					VectorId.Weight_68901328_MilliGrams,
				false, asFac, "Zach is 68.9kg at this time.");
			AddFactor(mfz, zach, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, EventorId.Occur_Minute_2012_06_29_06_31, null, null,
					VectorId.Weight_68501_Grams,
				false, asFac, "Zach is 68.5kg at this time.");

			AddFactor(mfm, mel, SetupArtifactId.Cla_Human,
				DescriptorId.IsA_Female, null, null, null, null, null,
				true,  asFac, "Mel is a human female.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, EventorId.Start_Day_1984_11_13, null, null, null,
				true,  asFac, "Mel is a human born on Nov 13 1984.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Name,
				DescriptorId.HasA, null, EventorId.End_Day_2007_08_11,
					IdentorId.Text_MelMc, null, null,
				false,  asFac, "Mel's name is 'Melissa McDonald' ending on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Name,
				DescriptorId.HasA, null, EventorId.Start_Day_2007_08_11,
					IdentorId.Text_MelKin, null, null,
				false,  asFac, "Mel's name is 'Melissa Kinsnter' starting on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Name,
				DescriptorId.HasA_Legal, null, EventorId.End_Day_2007_08_11,
					IdentorId.Text_MelRoseMc, null, null,
				true,  asFac, "Mel's legal name is 'Melissa Rose McDonald' ending on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Name,
				DescriptorId.HasA_Legal, null, EventorId.Start_Day_2007_08_11,
					IdentorId.Text_MelRoseKin, null, null,
				true,  asFac, "Mel's legal name is 'Melissa Rose Kinstner' starting on Aug 11 2007.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Caldonia,
				DescriptorId.IsFoundIn_Home, null, EventorId.Start_Day_2007_11_13,
				IdentorId.Text_Silverbow, null, null,
				false,  asFac, "Mel's home is 1731 Silverbow Caledonia starting on Nov 13 2007.");
			AddFactor(mfm, mel, SetupArtifactId.User_Zach,
				DescriptorId.IsRelatedTo, DirectorId.View_Sugg_View, null, null, null, null,
				false,  asOpi, "After viewing Mel, I suggest viewing Zach.");
			AddFactor(mfz, mel, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, null, null, null, VectorId.Beauty_100_None,
				false,  asOpi, "Mel is a human with 100 Beauty.");
			AddFactor(mfm, mel, SetupArtifactId.Cla_Human,
				DescriptorId.IsA, null, null, null, null, VectorId.Height_1574_MilliMeters,
				false,  asFac, "Mel is 1,574mm tall.");

			AddFactor(mbb, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, null,
				true,  asFac, "The game is an MLB game.");
			AddFactor(mbb, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, EventorId.Start_Minute_2012_04_08_13_05, null, null, null,
				true,  asFac, "The game is an MLB game stating at this time.");
			AddFactor(mbb, game, SetupArtifactId.Ins_DetroitTigers,
				DescriptorId.HasA, null, null, null, null, null,
				true,  asFac, "The game includes the Detroit Tigers.");
			AddFactor(mbb, game, SetupArtifactId.Ins_BostonRedSox,
				DescriptorId.HasA, null, null, null, null, null,
				true,  asFac, "The game includes the Boston Red Sox.");
			AddFactor(mbb, game, SetupArtifactId.Ins_ComericaPark,
				DescriptorId.IsFoundIn, null, null, null, null, null,
				true,  asFac, "The game was played at Comerica Park.");
			AddFactor(mbb, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, EventorId.End_Minute_2012_04_08_17_50, null, null, null,
				false,  asFac, "The game is an MLB game ending at this time.");
			AddFactor(mbb, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Inning_11_None,
				false,  asFac, "The game has 11 innings.");
			AddFactor(mbz, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Attendance_30788_User,
				false,  asFac, "The game has an attendance of 30,788 users.");
			AddFactor(mbz, game, SetupArtifactId.Ins_Bottom11,
				DescriptorId.HasA, null, null, null, LocatorId.InningPos1D, VectorId.Inning_11_Index,
				false,  asFac, "The game has an 11th inning.");
			AddFactor(mbz, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_95_None,
				false, asOpi, "The game has 95 excitement.");
			AddFactor(mbm, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_75_None,
				false, asOpi, "The game has 75 excitement.");
			AddFactor(mfe, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_88_None,
				false, asOpi, "The game has 88 excitement.");
			AddFactor(mfp, game, SetupArtifactId.Cla_MlbGame,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_98_None,
				false, asOpi, "The game has 98 excitement.");

			AddFactor(mbb, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, null, null, null, null,
				true, asFac, "This is an inning.");
			AddFactor(mbb, bot11, SetupArtifactId.Ins_TigersGame,
				DescriptorId.BelongsTo, null, null, null, null, null,
				true, asFac, "The inning belongs to a particular game.");
			AddFactor(mbb, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, EventorId.Start_Minute_2012_04_08_17_23, null, null, null,
				false, asFac, "The inning starts at this time.");
			AddFactor(mbb, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, EventorId.End_Minute_2012_04_08_17_50, null, null, null,
				false, asFac, "The inning ends at this time.");
			AddFactor(mbz, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_95_None,
				false, asOpi, "The inning has a 95 excitement.");
			AddFactor(mbm, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_83_None,
				false, asOpi, "The inning has a 83 excitement.");
			AddFactor(mfe, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_92_None,
				false, asOpi, "The inning has a 92 excitement.");
			AddFactor(mfp, bot11, SetupArtifactId.Cla_Inning,
				DescriptorId.IsA, null, null, null, null, VectorId.Excitement_98_None,
				false, asOpi, "The inning has a 98 excitement.");

			AddFactor(mgg, cuteUrl, SetupArtifactId.Cla_WebPage,
				DescriptorId.IsA, null, null, null, null, null,
				true, asUnd, "This is a web page.");
			AddFactor(mgg, cuteUrl, SetupArtifactId.Ins_CutePhoto,
				DescriptorId.RefersTo, null, null, null, null, null,
				true, asUnd, "This URL refers to Cute Photo.");
			AddFactor(mgg, cuteUrl, SetupArtifactId.App_KinPhoGal,
				DescriptorId.BelongsTo, null, null, null, null, null,
				true, asUnd, "This URL belongs to Kinstner Photo Gallery.");

			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA_Digital, null, null, null, null, null,
				true, asUnd, "This is a digital photo.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_26_17_57_04, null,
					LocatorId.CabinSwing, null,
				true, asFac, "This photo was taken at this time and location.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, IdentorId.Key_4165, null, null,
				true, asFac, "This photo has a key of 4165.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, IdentorId.Text_Img9023Jpg, null, null,
				false, asFac, "This photo is called 'IMG_9203.JPG'.");
			AddFactor(mgg, cutePho, SetupArtifactId.App_KinPhoGal,
				DescriptorId.BelongsTo, null, null, null, null, null,
				true, asUnd, "This photo belongs to Kinstner Photo Gallery.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Favorite,
				DescriptorId.Receives, null, null, null, null, null,
				false, asUnd, "This photo received a Favorite distinction.");

			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FocalLen_50_MilliMeters,
				false, asFac, "This photo has a 50mm focal length.");
			AddFactor(mgz, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FocalLen_50000000_NanoMeters,
				false, asFac, "This photo has a 0.05m focal length.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FocalLen_50000_MicroMeters,
				false, asFac, "This photo has a 50,000 micrometer focal length.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.Exposure_8000_MicroSeconds,
				false, asFac, "This photo has a 1/125 sec exposure.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.FStop_45000_MilliUnit,
				false, asFac, "This photo 4.5 F-Stop.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.ISO_100_Unit,
				false, asFac, "This photo has a 100 ISO speed.");
			AddFactor(mgg, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, null, null, null, VectorId.Quality_92_None,
				false, asOpi, "This photo has 92 quality.");

			AddFactor(mgm, cutePho, SetupArtifactId.User_Ellie,
				DescriptorId.RefersTo_Subject, null, null, null, LocatorId.ElliePos2D, null,
				false, asUnd, "This photo's subject refers to Ellie at this position.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Smile,
				DescriptorId.HasA_Subject, null, null, null, LocatorId.SmilePos2D, null,
				false, asUnd, "This photo's subject has a smile at this position.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Pigtail,
				DescriptorId.HasA_Subject, null, null, null, null, null,
				false, asUnd, "This photo's subject has a pigtail.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Rope,
				DescriptorId.HasA_Object_Blue, null, null, null, null, null,
				false, asUnd, "This photo's object has a blue rope.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Swing,
				DescriptorId.HasA_Object, null, null, null, null, null,
				false, asUnd, "This photo's object has a swing.");
			AddFactor(mgz, cutePho, SetupArtifactId.User_Ellie,
				DescriptorId.RefersTo_Subject, null, null, null, LocatorId.ElliePos2D, null,
				false, asUnd, "This photo's subject refers to Ellie at this position.");
			AddFactor(mgz, cutePho, SetupArtifactId.Ins_FisherPrice,
				DescriptorId.RefersTo_Object, null, null, null, LocatorId.FisherPos2D, null,
				false, asUnd, "This photo's object refers to Fisher-Price at this pos.");
			AddFactor(mgz, cutePho, SetupArtifactId.Cla_Swing,
				DescriptorId.HasA_Object, null, null, null, null, null,
				false, asUnd, "This photo's object has a swing.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Happiness,
				DescriptorId.EmotesLike, null, null, null, null, null,
				false, asOpi, "This photo causes the emotion of happiness.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Fun,
				DescriptorId.EmotesLike, null, null, null, null, null,
				false, asOpi, "This photo causes the emotion of fun.");

			AddFactor(mgz, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_26_20_00_01, null, null,
					VectorId.Quality_88_None,
				false, asOpi, "This photo has 88 quality.");
			AddFactor(mgz, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_28_16_24_41, null, null,
					VectorId.Quality_95_None,
				false, asOpi, "This photo has 95 quality.");
			AddFactor(mgz, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_17_59_59, null, null,
					VectorId.Quality_92_None,
				false, asOpi, "This photo has 92 quality.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_18_30_03, null, null,
					VectorId.Quality_98_None,
				false, asOpi, "This photo has 98 quality.");
			AddFactor(mgz, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_17_59_59, null, null,
					VectorId.Cuteness_96_None,
				false, asOpi, "This photo has 96 cuteness.");
			AddFactor(mgm, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_18_30_03, null, null,
					VectorId.Cuteness_100_None,
				false, asOpi, "This photo has 100 cuteness.");
			AddFactor(mge, cutePho, SetupArtifactId.Cla_Photo,
				DescriptorId.IsA, null, EventorId.Occur_Second_2012_05_29_18_31_03, null, null,
					VectorId.Cuteness_82_None,
				false, asOpi, "This photo has 82 cuteness.");
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddDescriptor(DescriptorType.Id pTypeId, SetupArtifactId? pPrimRefId=null,
				SetupArtifactId? pDtRefId=null, SetupArtifactId? pRelRefId=null) {
			var d = new Descriptor();
			d.DescriptorId = ++vIdCount;
			d.Type = (byte)pTypeId;
			d.PrimArtRefId = (long?)pPrimRefId;
			d.TypeArtRefId = (long?)pDtRefId;
			d.RelArtRefId = (long?)pRelRefId;
			DescMap.Add(d.DescriptorId, d);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddDirector(DirectorType.Id pTypeId, DirectorAction.Id pPrimActId,
																		DirectorAction.Id pEdgeActId) {
			var d = new Director();
			d.DirectorId = ++vIdCount;
			d.Type = (byte)pTypeId;
			d.PrimaryDirectorActionId = (byte)pPrimActId;
			d.RelatedDirectorActionId = (byte)pEdgeActId;
			DirMap.Add(d.DirectorId, d);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddEventor(EventorType.Id pTypeId, long pYear, byte? pMonth=null, byte? pDay=null,
											byte? pHour=null, byte? pMinute=null, byte? pSecond=null) {
			var e = new Eventor();
			e.EventorId = ++vIdCount;
			e.Type = (byte)pTypeId;
			e.DateTime = DataUtil.EventorTimesToLong(pYear, pMonth, pDay, pHour, pMinute, pSecond);
			EveMap.Add(e.EventorId, e);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddIdentor(IdentorType.Id pTypeId, string pValue) {
			var i = new Identor();
			i.IdentorId = ++vIdCount;
			i.Type = (byte)pTypeId;
			i.Value = pValue;
			IdenMap.Add(i.IdentorId, i);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddLocator(LocatorType.Id pTypeId, double pX, double pY, double pZ) {
			var l = new Locator();
			l.LocatorId = ++vIdCount;
			l.Type = (byte)pTypeId;
			l.ValueX = pX;
			l.ValueY = pY;
			l.ValueZ = pZ;
			LocMap.Add(l.LocatorId, l);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddVector(VectorType.Id pTypeId, SetupArtifactId pAxisArtId, long pValue, 
												VectorUnitPrefix.Id pPrefId, VectorUnit.Id pUnitId) {
			var v = new Vector();
			v.VectorId = ++vIdCount;
			v.Type = (byte)pTypeId;
			v.Unit = (byte)pUnitId;
			v.UnitPrefix = (byte)pPrefId;
			v.Value = pValue;
			v.AxisArtId = (long)pAxisArtId;
			VecMap.Add(v.VectorId, v);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddFactor(SetupMemberId pMemId, SetupArtifactId pPrimArtId,
					SetupArtifactId pRelArtId, DescriptorId pDescId, DirectorId? pDirId,
					EventorId? pEventId, IdentorId? pIdentId, LocatorId? pLocId, VectorId? pVectId,
					bool pIsDefining, FactorAssertion.Id pAstId, string pNote) {

			Descriptor desc = DescMap[(long)pDescId];

			var f = new Factor();
			f.AssertionType = (byte)pAstId;
			f.IsDefining = pIsDefining;
			f.Note = pNote;
			f.DescriptorType = desc.Type;
			AddVertex(f, (SetupVertexId)(++vIdCount));
			
			////

			Member mem = Data.GetVertex<Member>((long)pMemId);

			var mcf = new MemberCreatesFactor();
			mcf.Timestamp = f.Timestamp;
			mcf.DescriptorType = f.DescriptorType;
			mcf.PrimaryArtifactId = (long)pPrimArtId;
			mcf.RelatedArtifactId = (long)pRelArtId;

			AddEdge(mem, mcf, f);
			AddEdge(f, new FactorCreatedByMember(), mem);

			////
			
			Artifact priArt = Data.GetVertex<Artifact>((long)pPrimArtId);
			Artifact relArt = Data.GetVertex<Artifact>((long)pRelArtId);

			var aupf = new ArtifactUsedAsPrimaryByFactor();
			aupf.Timestamp = f.Timestamp;
			aupf.DescriptorType = f.DescriptorType;
			aupf.RelatedArtifactId = relArt.VertexId;

			var aurf = new ArtifactUsedAsRelatedByFactor();
			aurf.Timestamp = f.Timestamp;
			aurf.DescriptorType = f.DescriptorType;
			aurf.PrimaryArtifactId = priArt.VertexId;

			AddEdge(priArt, aupf, f);
			AddEdge(relArt, aurf, f);
			AddEdge(f, new FactorUsesPrimaryArtifact(), priArt);
			AddEdge(f, new FactorUsesRelatedArtifact(), relArt);

			////
			
			if ( desc.PrimArtRefId != null ) {
				AddEdge(f, new FactorDescriptorRefinesPrimaryWithArtifact(),
					Data.GetVertex<Artifact>((long)desc.PrimArtRefId));
			}

			if ( desc.TypeArtRefId != null ) {
				AddEdge(f, new FactorDescriptorRefinesTypeWithArtifact(),
					Data.GetVertex<Artifact>((long)desc.TypeArtRefId));
			}

			if ( desc.RelArtRefId != null ) {
				AddEdge(f, new FactorDescriptorRefinesRelatedWithArtifact(),
					Data.GetVertex<Artifact>((long)desc.RelArtRefId));
			}
			
			if ( pDirId != null ) {
				Director dir = DirMap[(long)pDirId];
				f.DirectorType = dir.Type;
				f.DirectorPrimaryAction = dir.PrimaryDirectorActionId;
				f.DirectorRelatedAction = dir.RelatedDirectorActionId;
			}

			if ( pEventId != null ) {
				Eventor e = EveMap[(long)pEventId];
				f.EventorType = e.Type;
				f.EventorDateTime = e.DateTime;
			}

			if ( pIdentId != null ) {
				Identor i = IdenMap[(long)pIdentId];
				f.IdentorType = i.Type;
				f.IdentorValue = i.Value;
			}

			if ( pLocId != null ) {
				Locator l = LocMap[(long)pLocId];
				f.LocatorType = l.Type;
				f.LocatorValueX = l.ValueX;
				f.LocatorValueY = l.ValueY;
				f.LocatorValueZ = l.ValueZ;
			}

			if ( pVectId != null ) {
				Vector v = VecMap[(long)pVectId];
				f.VectorType = v.Type;
				f.VectorUnit= v.Unit;
				f.VectorUnitPrefix = v.UnitPrefix;
				f.VectorValue = v.Value;
				AddEdge(f, new FactorVectorUsesAxisArtifact(), Data.GetVertex<Artifact>(v.AxisArtId));
			}

			Data.ElapseTime();
		}

	}


	/*================================================================================================*/
	public class Descriptor {

		public virtual long DescriptorId { get; set; }
		public virtual byte Type { get; set; }
		public virtual long? PrimArtRefId { get; set; }
		public virtual long? RelArtRefId { get; set; }
		public virtual long? TypeArtRefId { get; set; }

	}


	/*================================================================================================*/
	public class Director {

		public virtual long DirectorId { get; set; }
		public virtual byte Type { get; set; }
		public virtual byte PrimaryDirectorActionId { get; set; }
		public virtual byte RelatedDirectorActionId { get; set; }

	}


	/*================================================================================================*/
	public class Eventor {

		public virtual long EventorId { get; set; }
		public virtual byte Type { get; set; }
		public virtual long DateTime { get; set; }

	}


	/*================================================================================================*/
	public class Identor {

		public virtual long IdentorId { get; set; }
		public virtual byte Type { get; set; }
		public virtual string Value { get; set; }

	}


	/*================================================================================================*/
	public class Locator {

		public virtual long LocatorId { get; set; }
		public virtual byte Type { get; set; }
		public virtual double ValueX { get; set; }
		public virtual double ValueY { get; set; }
		public virtual double ValueZ { get; set; }

	}


	/*================================================================================================*/
	public class Vector {

		public virtual long VectorId { get; set; }
		public virtual byte Type { get; set; }
		public virtual byte Unit { get; set; }
		public virtual byte UnitPrefix { get; set; }
		public virtual long Value { get; set; }
		public virtual long AxisArtId { get; set; }

	}

}