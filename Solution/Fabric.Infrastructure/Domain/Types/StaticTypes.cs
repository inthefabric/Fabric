using System;
using System.Collections.Generic;
using System.Linq;

namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public static class StaticTypes {
		
		public static Dictionary<byte, MemberType> MemberTypes;
		public static Dictionary<byte, DescriptorType> DescriptorTypes;
		public static Dictionary<byte, DirectorType> DirectorTypes;
		public static Dictionary<byte, DirectorAction> DirectorActions;
		public static Dictionary<byte, EventorPrecision> EventorPrecisions;
		public static Dictionary<byte, EventorType> EventorTypes;
		public static Dictionary<byte, FactorAssertion> FactorAssertions;
		public static Dictionary<byte, IdentorType> IdentorTypes;
		public static Dictionary<byte, LocatorType> LocatorTypes;
		public static Dictionary<byte, VectorType> VectorTypes;
		public static Dictionary<byte, VectorRangeLevel> VectorRangeLevels;
		public static Dictionary<byte, VectorRange> VectorRanges;
		public static Dictionary<byte, VectorUnit> VectorUnits;
		public static Dictionary<byte, VectorUnitPrefix> VectorUnitPrefixs;
		public static Dictionary<byte, VectorUnitDerived> VectorUnitDeriveds;

		public static List<Type> TypeList;

		private static bool IsInit = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool Init() {
			MemberTypes = new Dictionary<byte, MemberType>();
			DescriptorTypes = new Dictionary<byte, DescriptorType>();
			DirectorTypes = new Dictionary<byte, DirectorType>();
			DirectorActions = new Dictionary<byte, DirectorAction>();
			EventorPrecisions = new Dictionary<byte, EventorPrecision>();
			EventorTypes = new Dictionary<byte, EventorType>();
			FactorAssertions = new Dictionary<byte, FactorAssertion>();
			IdentorTypes = new Dictionary<byte, IdentorType>();
			LocatorTypes = new Dictionary<byte, LocatorType>();
			VectorTypes = new Dictionary<byte, VectorType>();
			VectorRangeLevels = new Dictionary<byte, VectorRangeLevel>();
			VectorRanges = new Dictionary<byte, VectorRange>();
			VectorUnits = new Dictionary<byte, VectorUnit>();
			VectorUnitPrefixs = new Dictionary<byte, VectorUnitPrefix>();
			VectorUnitDeriveds = new Dictionary<byte, VectorUnitDerived>();

			TypeList = new List<Type>();
			TypeList.Add(typeof(MemberType));
			TypeList.Add(typeof(DescriptorType));
			TypeList.Add(typeof(DirectorType));
			TypeList.Add(typeof(DirectorAction));
			TypeList.Add(typeof(EventorPrecision));
			TypeList.Add(typeof(EventorType));
			TypeList.Add(typeof(FactorAssertion));
			TypeList.Add(typeof(IdentorType));
			TypeList.Add(typeof(LocatorType));
			TypeList.Add(typeof(VectorType));
			TypeList.Add(typeof(VectorRangeLevel));
			TypeList.Add(typeof(VectorRange));
			TypeList.Add(typeof(VectorUnit));
			TypeList.Add(typeof(VectorUnitPrefix));
			TypeList.Add(typeof(VectorUnitDerived));

			//SetupCrowdianType();
			SetupMemberType();
			SetupDescriptorType();
			SetupDirectorAction();
			SetupDirectorType();
			SetupEventorPrecision();
			SetupEventorType();
			SetupFactorAssert();
			SetupIdentorType();
			SetupLocatorType();
			SetupVectorRangeLevel();
			SetupVectorRange();
			SetupVectorType();
			SetupVectorUnit();
			SetupVectorUnitPrefix();
			SetupVectorUnitDerived();

			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static void SetupCrowdianType() {
			AddCrowdianType(CrowdianTypeId.Request, "Request",
				"The User would like to be a member of this Crowd.");
			AddCrowdianType(CrowdianTypeId.Invite, "Invite",
				"The User has been invited to join this Crowd.");
			AddCrowdianType(CrowdianTypeId.Member, "Member",
				"The User is a member of this Crowd");
			AddCrowdianType(CrowdianTypeId.Admin, "Admin",
				"The User is an administrator of this Crowd.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupMemberType() {
			AddMemberType(MemberTypeId.None, "None",
				"The User is not associated with this App.");
			AddMemberType(MemberTypeId.Request, "Request",
				"The user would like to become a member of this App.");
			AddMemberType(MemberTypeId.Invite, "Invite",
				"The User has been invited to become a member of this App.");
			AddMemberType(MemberTypeId.Member, "Member",
				"The User is a member of this App.");
			AddMemberType(MemberTypeId.Staff, "Staff",
				"The User is a staff member of this App.");
			AddMemberType(MemberTypeId.Admin, "Admin",
				"The User is an administrator of this App.");
			AddMemberType(MemberTypeId.Owner, "Owner",
				"The User owns this App.");
			AddMemberType(MemberTypeId.DataProvider, "Data Provider",
				"The User has a special membership that allows it to interact with Fabric on behalf "+
				"of the App.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		private static void AddCrowdianType(CrowdianTypeId pId, string pName, string pDesc) {
			var t = new CrowdianType(pId, pName, pDesc);
			CrowdianTypes.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddMemberType(MemberTypeId pId, string pName, string pDesc) {
			var t = new MemberType(pId, pName, pDesc);
			MemberTypes.Add((byte)pId, t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupDescriptorType() {
			AddDescriptorType(DescriptorTypeId.IsRelatedTo, "Is Related To",
				"The primary Artifact is related to the related Artifact in "+
				"some way. This is the default (and least meaningful) DescriptorType.");
			AddDescriptorType(DescriptorTypeId.IsA, "Is A",
				"The primary Artifact is a type of, a subclass of, a subset of, "+
				"a subordinate of, or in the category defined by the related Artifact.");
			AddDescriptorType(DescriptorTypeId.IsAnInstanceOf, "Is An Instance Of",
				"The primary Artifact is an instance, case, example, "+
				"or representation of the related Artifact.");
			AddDescriptorType(DescriptorTypeId.HasA, "Has A",
				"The primary Artifact has, as a part, piece, feature, attribute, or component, "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.IsLike, "Is Like",
				"The primary Artifact is like or similar to the related Artifact.");
			AddDescriptorType(DescriptorTypeId.IsNotLike, "Is Not Like",
				"The primary Artifact is not like or not similar to the related Artifact");

			AddDescriptorType(DescriptorTypeId.RefersTo, "Refers To",
				"The primary Artifact refers to, mentions, discusses, links to, or references "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.IsCreatedBy, "Is Created By",
				"The primary Artifact is created, built, designed, invented, "+
				"formed, or performed by the related Artifact.");
			AddDescriptorType(DescriptorTypeId.IsInterestedIn, "Is Interested In",
				"The primary Artifact is interested in, fond of, attracted to, enjoys, prefers, or "+
				"desires the related Artifact.");
			AddDescriptorType(DescriptorTypeId.Receives, "Receives", 
				"The primary Artifact receives, gets, obtains, or is awarded the related Artifact.");
			AddDescriptorType(DescriptorTypeId.Consumes, "Consumes",
				"The primary Artifact consumes, eats, is powered by, uses up, "+
				"depletes, or destroys the related Artifact.");
			AddDescriptorType(DescriptorTypeId.Produces, "Produces",
				"The primary Artifact produces, has a byproduct of, creates, or generates the related "+
				"Artifact. This is similar to 'Is Created By', but in the opposite direction and "+
				"meant to be less specific.");
			AddDescriptorType(DescriptorTypeId.ParticipatesIn, "Participates In",
				"The primary Artifact participates in, competes in, attends, is a member of, or is "+
				"involved in the related Artifact.");
			AddDescriptorType(DescriptorTypeId.IsFoundIn, "Is Found In",
				"The primary Artifact is found in, located at, lives in, or is contained by "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.BelongsTo, "Belongs To", 
				"The primary Artifact belongs to, is controlled by, or is owned by "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.Requires, "Requires",
				"The primary Artifact requires, implies, needs, or demands "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.InteractsWith, "Interacts With",
				"The primary Artifact interacts, associates, combines, meets, or communicates with "+
				"the related Artifact.");

			AddDescriptorType(DescriptorTypeId.LooksLike, "Looks Like",
				"The primary Artifact looks like (has the appearance of) the related Artifact.");
			AddDescriptorType(DescriptorTypeId.SmellsLike, "Smells Like",
				"The primary Artifact smells like (has the odor, aroma, or fragrance of) "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.TastesLike, "Tastes Like",
				"The primary Artifact tastes like (has the flavor of) the related Artifact.");
			AddDescriptorType(DescriptorTypeId.SoundsLike, "Sounds Like",
				"The primary Artifact sounds like (has the aural characteristics of) "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.FeelsLike, "Feels Like",
				"The primary Artifact feels like (has the tactile characteristics of) "+
				"the related Artifact.");
			AddDescriptorType(DescriptorTypeId.EmotesLike, "Emotes Like",
				"The primary Artifact emotes like (causes the emotion of) the related Artifact.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupDirectorAction() {
			AddDirectorAction(DirectorActionId.Read, "Read",
				"Read the specified Artifact.");
			AddDirectorAction(DirectorActionId.Listen, "Listen",
				"Listen to the specified Artifact.");
			AddDirectorAction(DirectorActionId.View, "View",
				"View (or watch, observe) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Consume, "Consume",
				"Consume (or use, eat, drink, taste, smell) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Perform, "Perform",
				"Perform (or act, do, carry out, speak, sing, say, work, "+
				"write) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Produce, "Produce", 
				"Produce (or create, build, make, invent) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Destroy, "Destroy", 
				"Destroy (or remove, delete, kill, erase) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Modify, "Modify", 
				"Modify (or change) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Obtain, "Obtain", 
				"Obtain (or get, purchase, acquire, steal) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Locate, "Locate", 
				"Locate (or find) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Travel, "Travel", 
				"Travel (or visit, walk, run, fly, ride, drive) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Become, "Become", 
				"Become the specified Artifact.");
			AddDirectorAction(DirectorActionId.Explain, "Explain", 
				"Explain (or describe) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Give, "Give", 
				"Give the specified Artifact.");
			AddDirectorAction(DirectorActionId.Learn, "Learn", 
				"Learn (or study, understand) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Start, "Start", 
				"Start (or begin) the specified Artifact.");
			AddDirectorAction(DirectorActionId.Stop, "Stop", 
				"Stop (or end) the specified Artifact.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupDirectorType() {
			AddDirectorType(DirectorTypeId.Hyperlink, "Hyperlink",
				"There is a hyperlink from the primary Artifact to the related Artifact.");
			AddDirectorType(DirectorTypeId.DefinedPath, "Defined Path",
				"There is an expected, pre-defined path from the "+
				"primary Artifact to the related Artifact.");
			AddDirectorType(DirectorTypeId.SuggestPath, "Suggested Path",
				"There is a suggested, recommented path from the "+
				"primary Artifact to the related Artifact.");
			AddDirectorType(DirectorTypeId.AvoidPath, "Avoid Path",
				"There is an unsuitable, non-recommented path from the "+
				"primary Artifact to the related Artifact.");
			AddDirectorType(DirectorTypeId.Causality, "Causality",
				"The primary Artifact causes an effect/action to occur upon the related Artifact.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupEventorPrecision() {
			AddEventorPrecision(EventorPrecisionId.Year, "Year",
				"This Eventor date is accurate to the year.");
			AddEventorPrecision(EventorPrecisionId.Month, "Month", 
				"This Eventor date is accurate to the month.");
			AddEventorPrecision(EventorPrecisionId.Day, "Day", 
				"This Eventor date is accurate to the day.");
			AddEventorPrecision(EventorPrecisionId.Hour, "Hour",
				"This Eventor date is accurate to the hour.");
			AddEventorPrecision(EventorPrecisionId.Minute, "Minute",
				"This Eventor date is accurate to the minute.");
			AddEventorPrecision(EventorPrecisionId.Second, "Second",
				"This Eventor date is accurate to the second.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupEventorType() {
			AddEventorType(EventorTypeId.Start, "Start", 
				"This Factor starts, begins, or commences on the specified date.");
			AddEventorType(EventorTypeId.End, "End", 
				"This Factor ends, stops, or terminates on the specified date.");
			AddEventorType(EventorTypeId.Pause, "Pause", 
				"This Factor pauses, suspendeds, or waits on the specified date.");
			AddEventorType(EventorTypeId.Unpause, "Unpause", 
				"This Factor unpauses or resumes on the specified date.");
			AddEventorType(EventorTypeId.Continue, "Continue", 
				"This Factor continues in its current state on the specified date.");
			AddEventorType(EventorTypeId.Occur, "Occur", 
				"This Factor occurrs or happens on the specified date.");
			AddEventorType(EventorTypeId.Expected, "Expected",
				"This Factor is/was expected, anticipated, or due on the specified date.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupFactorAssert() {
			AddFactorAssertion(FactorAssertionId.Undefined, "Undefined",
				"The Factor's assertion type is not known or not defined.");
			AddFactorAssertion(FactorAssertionId.Fact, "Fact",
				"The Factor represents a factual statement.");
			AddFactorAssertion(FactorAssertionId.Opinion, "Opinion",
				"The Factor represents an opinion.");
			AddFactorAssertion(FactorAssertionId.Guess, "Guess",
				"The Factor represents a guess.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupIdentorType() {
			AddIdentorType(IdentorTypeId.Text, "Text",
				"A value (a string, typically a name).");
			AddIdentorType(IdentorTypeId.Key, "Key",
				"A value (numeric or otherwise) representing a unique key or ID.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupLocatorType() {
			AddLocatorTypeCoord(LocatorTypeId.EarthCoord, "Earth Coordinate",
				"A coordinate position on Earth.");
			AddLocatorTypeCoord(LocatorTypeId.MoonCoord, "Moon Coordinate",
				"A coordinate position on Earth's Moon.");
			AddLocatorTypeCoord(LocatorTypeId.MarsCoord, "Mars Coordinate",
				"A coordinate position on Mars.");

			const string pos = "A position is relative to the Artifact's dimensions. For example, "+
				"X=0.25 represents a position (starting from the origin) that is 25% of the "+
				"distance to the maximum X dimension.";

			AddLocatorType(LocatorTypeId.RelPos1D, "Relative Position 1D",
				"A one-dimensional position, using X=Time. "+pos,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				0, 0,
				0, 0);

			AddLocatorType(LocatorTypeId.RelPos2D, "Relative Position 2D",
				"A two-dimensional position, using X=Width and Y=Height. "+pos,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				0, 0);

			AddLocatorType(LocatorTypeId.RelPos3D, "Relative Position 3D",
				"A three-dimensional position, using X, Y, and Z axes. "+pos,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorRangeLevel() {
			AddVectorRangeLevel(VectorRangeLevelId.Zero0, 0.0f, "Zero");
			AddVectorRangeLevel(VectorRangeLevelId.Zero05, 0.5f, "Zero");
			AddVectorRangeLevel(VectorRangeLevelId.Zero1, 1.0f, "Zero");

			AddVectorRangeLevel(VectorRangeLevelId.Min0, 0.0f, "Minimum");
			AddVectorRangeLevel(VectorRangeLevelId.Max1, 1.0f, "Maximum");

			AddVectorRangeLevel(VectorRangeLevelId.CompDisagree, 0.0f, "Completely Disagree");
			AddVectorRangeLevel(VectorRangeLevelId.MostDisagree, 1/6.0f, "Mostly Disagree");
			AddVectorRangeLevel(VectorRangeLevelId.SomeDisagree, 2/6.0f, "Somewhat Disagree");
			AddVectorRangeLevel(VectorRangeLevelId.NoOpinion05, 3/6.0f, "No Opinion");
			AddVectorRangeLevel(VectorRangeLevelId.SomeAgree, 4/6.0f, "Somewhat Agree");
			AddVectorRangeLevel(VectorRangeLevelId.MostAgree, 5/6.0f, "Mostly Agree");
			AddVectorRangeLevel(VectorRangeLevelId.CompAgree, 1.0f, "Completely Agree");

			AddVectorRangeLevel(VectorRangeLevelId.NoOpinion0, 0.0f, "No Opinion");
			AddVectorRangeLevel(VectorRangeLevelId.SomeAgreePos, 1/3.0f, "Somewhat Agree");
			AddVectorRangeLevel(VectorRangeLevelId.MostAgreePos, 2/3.0f, "Mostly Agree");
			AddVectorRangeLevel(VectorRangeLevelId.CompAgreePos, 1.0f, "Completely Agree");

			AddVectorRangeLevel(VectorRangeLevelId.CompUnfavor, 0.0f, "Completely Unfavorable");
			AddVectorRangeLevel(VectorRangeLevelId.MostUnfavor, 1/6.0f, "Mostly Unfavorable");
			AddVectorRangeLevel(VectorRangeLevelId.SomeUnfavor, 2/6.0f, "Somewhat Unfavorable");
			AddVectorRangeLevel(VectorRangeLevelId.SomeFavor, 4/6.0f, "Somewhat Favorable");
			AddVectorRangeLevel(VectorRangeLevelId.MostFavor, 5/6.0f, "Mostly Favorable");
			AddVectorRangeLevel(VectorRangeLevelId.CompFavor, 1.0f, "Completely Favorable");

			AddVectorRangeLevel(VectorRangeLevelId.SomeFavorPos, 1/3.0f, "Somewhat Favorable");
			AddVectorRangeLevel(VectorRangeLevelId.MostFavorPos, 2/3.0f, "Mostly Favorable");
			AddVectorRangeLevel(VectorRangeLevelId.CompFavorPos, 1.0f, "Completely Favorable");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorRange() {
			AddVectorRange(VectorRangeId.FullNum, "Full Numeric", new [] {
				VectorRangeLevelId.Min0,
				VectorRangeLevelId.Zero05,
				VectorRangeLevelId.Max1
			});
			AddVectorRange(VectorRangeId.PosNum, "Positive Numeric", new[] {
				VectorRangeLevelId.Zero0,
				VectorRangeLevelId.Max1
			});
			AddVectorRange(VectorRangeId.NegNum, "Negative Numeric", new[] {
				VectorRangeLevelId.Min0,
				VectorRangeLevelId.Zero1
			});
			AddVectorRange(VectorRangeId.FullAgree, "Full Agreement", new[] {
				VectorRangeLevelId.CompDisagree,
				VectorRangeLevelId.MostDisagree,
				VectorRangeLevelId.SomeDisagree,
				VectorRangeLevelId.NoOpinion05,
				VectorRangeLevelId.SomeAgree,
				VectorRangeLevelId.MostAgree,
				VectorRangeLevelId.CompAgree
			});
			AddVectorRange(VectorRangeId.PosAgree, "Positive Agreement", new[] {
				VectorRangeLevelId.NoOpinion0,
				VectorRangeLevelId.SomeAgreePos,
				VectorRangeLevelId.MostAgreePos,
				VectorRangeLevelId.CompAgreePos
			});
			AddVectorRange(VectorRangeId.FullFavor, "Full Favorability", new[] {
				VectorRangeLevelId.CompUnfavor,
				VectorRangeLevelId.MostUnfavor,
				VectorRangeLevelId.SomeUnfavor,
				VectorRangeLevelId.NoOpinion05,
				VectorRangeLevelId.SomeFavor,
				VectorRangeLevelId.MostFavor,
				VectorRangeLevelId.CompFavor
			});
			AddVectorRange(VectorRangeId.PosFavor, "Positive Favorability", new[] {
				VectorRangeLevelId.NoOpinion0,
				VectorRangeLevelId.SomeFavorPos,
				VectorRangeLevelId.MostFavorPos,
				VectorRangeLevelId.CompFavorPos
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorType() {
			const long min = long.MinValue;
			const long max = long.MaxValue;

			AddVectorType(VectorTypeId.FullLong, VectorRangeId.FullNum,
				min, max, "Full Bounds");
			AddVectorType(VectorTypeId.PosLong, VectorRangeId.PosNum,
				0, max, "Positive Bounds");
			AddVectorType(VectorTypeId.NegLong, VectorRangeId.NegNum,
				min, 0, "Negative Bounds");

			AddVectorType(VectorTypeId.FullPerc, VectorRangeId.FullNum,
				min, max, "Full Percentage");
			AddVectorType(VectorTypeId.StdPerc, VectorRangeId.PosNum,
				0, 100, "Standard Percentage");
			AddVectorType(VectorTypeId.OppPerc,VectorRangeId.FullNum,
				-100, 100, "Opposable Percentage");

			AddVectorType(VectorTypeId.StdAgree, VectorRangeId.PosAgree,
				0, 100, "Standard Agreement");
			AddVectorType(VectorTypeId.OppAgree, VectorRangeId.FullAgree,
				-100, 100, "Opposable Agreement");

			AddVectorType(VectorTypeId.StdFavor, VectorRangeId.PosFavor,
				0, 100, "Standard Favorability");
			AddVectorType(VectorTypeId.OppFavor, VectorRangeId.FullFavor,
				-100, 100, "Opposable Favorability");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorUnit() {
			AddVectorUnit(VectorUnitId.None, "None", "");
			AddVectorUnit(VectorUnitId.Unit, "Unit", "");

			AddVectorUnit(VectorUnitId.Metre, "Metre", "m");
			AddVectorUnit(VectorUnitId.Gram, "Gram", "g");
			AddVectorUnit(VectorUnitId.Second, "Second", "s");
			AddVectorUnit(VectorUnitId.Ampere, "Ampere", "A");
			AddVectorUnit(VectorUnitId.Celsius, "Celsius", "C");
			AddVectorUnit(VectorUnitId.Candela, "Candela", "cd");
			AddVectorUnit(VectorUnitId.Mole, "Mole", "mol");
			AddVectorUnit(VectorUnitId.Bit, "Bit", "b");
			AddVectorUnit(VectorUnitId.Byte, "long", "B");

			AddVectorUnit(VectorUnitId.Hertz, "Hertz", "Hz");
			AddVectorUnit(VectorUnitId.Radian, "Radian", "rad");
			AddVectorUnit(VectorUnitId.Newton, "Newton", "N");
			AddVectorUnit(VectorUnitId.Pascal, "Pascal", "Pa");
			AddVectorUnit(VectorUnitId.Joule, "Joule", "J");
			AddVectorUnit(VectorUnitId.Watt, "Watt", "W");
			AddVectorUnit(VectorUnitId.Volt, "Volt", "V");
			AddVectorUnit(VectorUnitId.Ohm, "Ohm", "Ω");

			AddVectorUnit(VectorUnitId.Area, "Area", "m^2");
			AddVectorUnit(VectorUnitId.Volume, "Volume", "m^3");
			AddVectorUnit(VectorUnitId.Speed, "Speed", "m/s");
			AddVectorUnit(VectorUnitId.Acceleration, "Acceleration", "m^3/s");

			AddVectorUnit(VectorUnitId.Point, "Point", "pt");
			AddVectorUnit(VectorUnitId.Item, "Item", "item");
			AddVectorUnit(VectorUnitId.Person, "Person", "person");
			AddVectorUnit(VectorUnitId.Percent, "Percent", "%");
			AddVectorUnit(VectorUnitId.Index, "Index", "index");
			AddVectorUnit(VectorUnitId.Pixel, "Pixel", "pixel");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorUnitPrefix() {
			AddVectorUnitPrefix(VectorUnitPrefixId.Base, "Base", "", VectorUnitPrefix.Base);

			AddVectorUnitPrefix(VectorUnitPrefixId.Kilo, "Kilo", "k", VectorUnitPrefix.Kilo);
			AddVectorUnitPrefix(VectorUnitPrefixId.Mega, "Mega", "M", VectorUnitPrefix.Mega);
			AddVectorUnitPrefix(VectorUnitPrefixId.Giga, "Giga", "G", VectorUnitPrefix.Giga);
			AddVectorUnitPrefix(VectorUnitPrefixId.Tera, "Tera", "T", VectorUnitPrefix.Tera);
			AddVectorUnitPrefix(VectorUnitPrefixId.Peta, "Peta", "P", VectorUnitPrefix.Peta);
			AddVectorUnitPrefix(VectorUnitPrefixId.Exa, "Exa", "E", VectorUnitPrefix.Exa);

			AddVectorUnitPrefix(VectorUnitPrefixId.Milli, "Milli", "m", VectorUnitPrefix.Milli);
			AddVectorUnitPrefix(VectorUnitPrefixId.Micro, "Micro", "μ", VectorUnitPrefix.Micro);
			AddVectorUnitPrefix(VectorUnitPrefixId.Nano, "Nano", "n", VectorUnitPrefix.Nano);
			AddVectorUnitPrefix(VectorUnitPrefixId.Pico, "Pico", "p", VectorUnitPrefix.Pico);
			AddVectorUnitPrefix(VectorUnitPrefixId.Femto, "Femto", "f", VectorUnitPrefix.Femto);
			AddVectorUnitPrefix(VectorUnitPrefixId.Atto, "Atto", "a", VectorUnitPrefix.Atto);

			AddVectorUnitPrefix(VectorUnitPrefixId.Kibi, "Kibi", "Ki", VectorUnitPrefix.Kibi);
			AddVectorUnitPrefix(VectorUnitPrefixId.Mebi, "Mebi", "Mi", VectorUnitPrefix.Mebi);
			AddVectorUnitPrefix(VectorUnitPrefixId.Gibi, "Gibi", "Gi", VectorUnitPrefix.Gibi);
			AddVectorUnitPrefix(VectorUnitPrefixId.Tebi, "Tebi", "Ti", VectorUnitPrefix.Tebi);
			AddVectorUnitPrefix(VectorUnitPrefixId.Pebi, "Pebi", "Pi", VectorUnitPrefix.Pebi);
			AddVectorUnitPrefix(VectorUnitPrefixId.Exbi, "Exbi", "Ei", VectorUnitPrefix.Exbi);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorUnitDerived() {
			AddVectorUnitDerived(VectorUnitDerivedId.HertzSec,
				VectorUnitId.Hertz, VectorUnitId.Second, -1);

			AddVectorUnitDerived(VectorUnitDerivedId.NewtonGram,
				VectorUnitId.Newton, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(VectorUnitDerivedId.NewtonMetre,
				VectorUnitId.Newton, VectorUnitId.Metre, 1);
			AddVectorUnitDerived(VectorUnitDerivedId.NewtonSec,
				VectorUnitId.Newton, VectorUnitId.Second, -2);

			AddVectorUnitDerived(VectorUnitDerivedId.PascalGram,
				VectorUnitId.Pascal, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(VectorUnitDerivedId.PascalMetre,
				VectorUnitId.Pascal, VectorUnitId.Metre, -1);
			AddVectorUnitDerived(VectorUnitDerivedId.PascalSec,
				VectorUnitId.Pascal, VectorUnitId.Second, -2);

			AddVectorUnitDerived(VectorUnitDerivedId.JouleGram,
				VectorUnitId.Joule, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(VectorUnitDerivedId.JouleMetre,
				VectorUnitId.Joule, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(VectorUnitDerivedId.JouleSec,
				VectorUnitId.Joule, VectorUnitId.Second, -2);

			AddVectorUnitDerived(VectorUnitDerivedId.WattGram,
				VectorUnitId.Watt, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(VectorUnitDerivedId.WattMetre,
				VectorUnitId.Watt, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(VectorUnitDerivedId.WattSec,
				VectorUnitId.Watt, VectorUnitId.Second, -3);

			AddVectorUnitDerived(VectorUnitDerivedId.VoltGram,
				VectorUnitId.Volt, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(VectorUnitDerivedId.VoltMetre,
				VectorUnitId.Volt, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(VectorUnitDerivedId.VoltSec,
				VectorUnitId.Volt, VectorUnitId.Second, -3);
			AddVectorUnitDerived(VectorUnitDerivedId.VoltAmp, 
				VectorUnitId.Volt, VectorUnitId.Ampere, -1);

			AddVectorUnitDerived(VectorUnitDerivedId.OhmGram, 
				VectorUnitId.Ohm, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(VectorUnitDerivedId.OhmMetre, 
				VectorUnitId.Ohm, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(VectorUnitDerivedId.OhmSec, 
				VectorUnitId.Ohm, VectorUnitId.Second, -3);
			AddVectorUnitDerived(VectorUnitDerivedId.OhmAmp, 
				VectorUnitId.Ohm, VectorUnitId.Ampere, -2);

			AddVectorUnitDerived(VectorUnitDerivedId.AreaMetre, 
				VectorUnitId.Area, VectorUnitId.Metre, 2);

			AddVectorUnitDerived(VectorUnitDerivedId.VolumeMetre, 
				VectorUnitId.Volume, VectorUnitId.Metre, 3);

			AddVectorUnitDerived(VectorUnitDerivedId.SpeedMetre, 
				VectorUnitId.Speed, VectorUnitId.Metre, 1);
			AddVectorUnitDerived(VectorUnitDerivedId.SpeedSec, 
				VectorUnitId.Speed, VectorUnitId.Second, -1);

			AddVectorUnitDerived(VectorUnitDerivedId.AccelMetre, 
				VectorUnitId.Acceleration, VectorUnitId.Metre, 1);
			AddVectorUnitDerived(VectorUnitDerivedId.AccelSec, 
				VectorUnitId.Acceleration, VectorUnitId.Second, -2);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void AddDescriptorType(DescriptorTypeId pId, string pName, string pDesc) {
			var t = new DescriptorType(pId, pName, pDesc);
			DescriptorTypes.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddDirectorAction(DirectorActionId pId, string pName, string pDesc) {
			var t = new DirectorAction(pId, pName, pDesc);
			DirectorActions.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddDirectorType(DirectorTypeId pId, string pName, string pDesc) {
			var t = new DirectorType(pId, pName, pDesc);
			DirectorTypes.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddEventorPrecision(EventorPrecisionId pId, string pName, string pDesc) {
			var t = new EventorPrecision(pId, pName, pDesc);
			EventorPrecisions.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddEventorType(EventorTypeId pId, string pName, string pDesc) {
			var t = new EventorType(pId, pName, pDesc);
			EventorTypes.Add((byte)pId, t);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static void AddFactorAssertion(FactorAssertionId pId, string pName, string pDesc) {
			var t = new FactorAssertion(pId, pName, pDesc);
			FactorAssertions.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddIdentorType(IdentorTypeId pId, string pName, string pDesc) {
			var t = new IdentorType(pId, pName, pDesc);
			IdentorTypes.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddLocatorType(LocatorTypeId pId, string pName, string pDesc, double pMinX,
								double pMaxX, double pMinY, double pMaxY, double pMinZ, double pMaxZ) {
			var t = new LocatorType(pId, pName, pDesc, pMinX, pMaxX, pMinY, pMaxY, pMinZ, pMaxZ);
			LocatorTypes.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddLocatorTypeCoord(LocatorTypeId pId, string pName, string pDesc) {
			AddLocatorType(pId, pName,
				pDesc+"Coordinates use X=Longitude, Y=Latitude, and Z=Elevation "+
				"(in metres).", -180, 180, -90, 90, FabricUtil.DoubleMin, FabricUtil.DoubleMax);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorRangeLevel(VectorRangeLevelId pId, float pPosition, string pName) {
			var t = new VectorRangeLevel(pId, pName, pPosition);
			VectorRangeLevels.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorRange(VectorRangeId pId, string pName,
																	IList<VectorRangeLevelId> pLevels) {
			var levels = pLevels.Select(id => (byte)id).ToList();
			var t = new VectorRange(pId, pName, levels);
			VectorRanges.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorType(VectorTypeId pId, VectorRangeId pRangeId,
																long pMin, long pMax, string pName) {
			var t = new VectorType(pId, pName, (byte)pRangeId, pMin, pMax);
			VectorTypes.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorUnit(VectorUnitId pId, string pName, string pDesc) {
			var t = new VectorUnit(pId, pName, pDesc);
			VectorUnits.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorUnitPrefix(VectorUnitPrefixId pId, string pName,
																		string pDesc, double pAmount) {
			var t = new VectorUnitPrefix(pId, pName, pDesc, pAmount);
			VectorUnitPrefixs.Add((byte)pId, t);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorUnitDerived(VectorUnitDerivedId pId, 
											VectorUnitId pDefinesId, VectorUnitId pRaisesId, int pExp,
											VectorUnitPrefixId pPrefix=VectorUnitPrefixId.Base) {
			var t = new VectorUnitDerived(pId, (byte)pDefinesId, (byte)pRaisesId, pExp, (byte)pPrefix);
			VectorUnitDeriveds.Add((byte)pId, t);
		}

	}

}