using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class SetupTypes {

		public const int NumArtifactTypes = 5;
		//public const int NumCrowdUserTypes = 4;
		public const int NumMemberTypes = 8;

		public const int NumDescriptorRefineTypes = 3;
		public const int NumDescriptorTypes = 21;
		public const int NumDirectorActions = 17;
		public const int NumDirectorTypes = 5;
		public const int NumEventorPrecisions = 6;
		public const int NumEventorTypes = 7;
		public const int NumFactorAccesses = 2;
		public const int NumFactorAsserts = 4;
		public const int NumIdentorTypes = 2;
		public const int NumLocatorTypes = 6;
		public const int NumVectorRanges = 7;
		public const int NumVectorRangeLevels = 29;
		public const int NumVectorTypes = 10;
		public const int NumVectorUnitPrefixes = 19;
		public const int NumVectorUnits = 28;
		public const int NumVectorUnitDeriveds = 27;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			SetupArtifactType(pSet);
			//SetupCrowdianType(pSet);
			SetupMemberType(pSet);

			SetupDescriptorType(pSet);
			SetupDirectorAction(pSet);
			SetupDirectorType(pSet);
			SetupEventorPrecision(pSet);
			SetupEventorType(pSet);
			SetupFactorAssert(pSet);
			SetupIdentorType(pSet);
			SetupLocatorType(pSet);
			SetupVectorRangeLevel(pSet);
			SetupVectorRange(pSet);
			SetupVectorType(pSet);
			SetupVectorUnit(pSet);
			SetupVectorUnitPrefix(pSet);
			SetupVectorUnitDerived(pSet);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupArtifactType(DataSet pSet) {
			AddArtifactType(pSet, ArtifactTypeId.App, "App",
				"This Artifact is related to a specific App.");
			AddArtifactType(pSet, ArtifactTypeId.User, "User",
				"This Artifact is related to a specific User.");
			AddArtifactType(pSet, ArtifactTypeId.Class, "Class",
				"This Artifact is related to a specific Class.");
			AddArtifactType(pSet, ArtifactTypeId.Instance, "Instance",
				"This Artifact is related to a specific Instance.");
			AddArtifactType(pSet, ArtifactTypeId.Url, "Url",
				"This Artifact is related to a specific URL.");
			/*AddArtifactType(pSet, ArtifactTypeId.Label, "Label",
				"This Artifact is related to a specific Label.");
			AddArtifactType(pSet, ArtifactTypeId.Crowd, "Crowd",
				"This Artifact is related to a specific Crowd.");*/
		}

		/*--------------------------------------------------------------------------------------------* /
		public static void SetupCrowdianType(DataSet pSet) {
			AddCrowdianType(pSet, CrowdianTypeId.Request, "Request",
				"The User would like to be a member of this Crowd.");
			AddCrowdianType(pSet, CrowdianTypeId.Invite, "Invite",
				"The User has been invited to join this Crowd.");
			AddCrowdianType(pSet, CrowdianTypeId.Member, "Member",
				"The User is a member of this Crowd");
			AddCrowdianType(pSet, CrowdianTypeId.Admin, "Admin",
				"The User is an administrator of this Crowd.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupMemberType(DataSet pSet) {
			AddMemberType(pSet, MemberTypeId.None, "None",
				"The User is not associated with this App.");
			AddMemberType(pSet, MemberTypeId.Request, "Request",
				"The user would like to become a member of this App.");
			AddMemberType(pSet, MemberTypeId.Invite, "Invite",
				"The User has been invited to become a member of this App.");
			AddMemberType(pSet, MemberTypeId.Member, "Member",
				"The User is a member of this App.");
			AddMemberType(pSet, MemberTypeId.Staff, "Staff",
				"The User is a staff member of this App.");
			AddMemberType(pSet, MemberTypeId.Admin, "Admin",
				"The User is an administrator of this App.");
			AddMemberType(pSet, MemberTypeId.Owner, "Owner",
				"The User owns this App.");
			AddMemberType(pSet, MemberTypeId.DataProvider, "DataProvider",
				"The User has a special membership that allows it to interact with Fabric on behalf "+
				"of the App.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void AddArtifactType(DataSet pSet, ArtifactTypeId pId, string pName,
																						string pDesc) {
			var t = new ArtifactType();
			t.ArtifactTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(t, false);
		}
		
		/*--------------------------------------------------------------------------------------------* /
		private static void AddCrowdianType(DataSet pSet, CrowdianTypeId pId, string pName,
																						string pDesc) {
			var t = new CrowdianType();
			t.CrowdianTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.CrowdianTypeId, false);
			pSet.AddRootRel<RootContainsCrowdianType>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddMemberType(DataSet pSet, MemberTypeId pId, string pName, string pDesc) {
			var t = new MemberType();
			t.MemberTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(t, false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupDescriptorType(DataSet pSet) {
			AddDescriptorType(pSet, DescriptorTypeId.IsRelatedTo, "Is Related To",
				"The primary Artifact is related to the related Artifact in "+
				"some way. This is the default (and least meaningful) DescriptorType.");
			AddDescriptorType(pSet, DescriptorTypeId.IsA, "Is A",
				"The primary Artifact is a type of, a subclass of, a subset of, "+
				"a subordinate of, or in the category defined by the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.IsAnInstanceOf, "Is An Instance Of",
				"The primary Artifact is an instance, case, example, "+
				"or representation of the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.HasA, "Has A",
				"The primary Artifact has, as a part, piece, feature, attribute, or component, "+
				"the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.IsLike, "Is Like",
				"The primary Artifact is like or similar to the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.IsNotLike, "Is Not Like",
				"The primary Artifact is not like or not similar to the related Artifact");

			AddDescriptorType(pSet, DescriptorTypeId.RefersTo, "Refers To",
				"The primary Artifact refers to, mentions, discusses, links to, or references "+
				"the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.IsCreatedBy, "Is Created By",
				"The primary Artifact is created, built, designed, invented, "+
				"formed, or performed by the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.IsInterestedIn, "Is Interested In",
				"The primary Artifact is interested in, fond of, attracted to, enjoys, prefers, or "+
				"desires the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.Receives, "Receives", 
				"The primary Artifact receives, gets, obtains, or is awarded the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.Consumes, "Consumes",
				"The primary Artifact consumes, eats, is powered by, uses up, "+
				"depletes, or destroys the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.Produces, "Produces",
				"The primary Artifact produces, has a byproduct of, creates, or generates the related "+
				"Artifact. This is similar to 'Is Created By', but in the opposite direction and "+
				"meant to be less specific.");
			AddDescriptorType(pSet, DescriptorTypeId.ParticipatesIn, "Participates In",
				"The primary Artifact participates in, competes in, attends, is a member of, or is "+
				"involved in the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.IsFoundIn, "Is Found In",
				"The primary Artifact is found in, located at, lives in, or is contained by "+
				"the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.BelongsTo, "Belongs To", 
				"The primary Artifact belongs to, is controlled by, or is owned by "+
				"the related Artifact.");

			AddDescriptorType(pSet, DescriptorTypeId.LooksLike, "Looks Like",
				"The primary Artifact looks like (has the appearance of) the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.SmellsLike, "Smells Like",
				"The primary Artifact smells like (has the odor, aroma, or fragrance of) "+
				"the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.TastesLike, "Tastes Like",
				"The primary Artifact tastes like (has the flavor of) the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.SoundsLike, "Sounds Like",
				"The primary Artifact sounds like (has the aural characteristics of) "+
				"the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.FeelsLike, "Feels Like",
				"The primary Artifact feels like (has the tactile characteristics of) "+
				"the related Artifact.");
			AddDescriptorType(pSet, DescriptorTypeId.EmotesLike, "Emotes Like",
				"The primary Artifact emotes like (causes the emotion of) the related Artifact.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupDirectorAction(DataSet pSet) {
			AddDirectorAction(pSet, DirectorActionId.Read, "Read",
				"Read the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Listen, "Listen",
				"Listen to the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.View, "View",
				"View (or watch, observe) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Consume, "Consume",
				"Consume (or use, eat, drink, taste, smell) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Perform, "Perform",
				"Perform (or act, do, carry out, speak, sing, say, work, "+
				"write) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Produce, "Produce", 
				"Produce (or create, build, make, invent) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Destroy, "Destroy", 
				"Destroy (or remove, delete, kill, erase) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Modify, "Modify", 
				"Modify (or change) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Obtain, "Obtain", 
				"Obtain (or get, purchase, acquire, steal) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Locate, "Locate", 
				"Locate (or find) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Travel, "Travel", 
				"Travel (or visit, walk, run, fly, ride, drive) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Become, "Become", 
				"Become the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Explain, "Explain", 
				"Explain (or describe) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Give, "Give", 
				"Give the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Learn, "Learn", 
				"Learn (or study, understand) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Start, "Start", 
				"Start (or begin) the specified Artifact.");
			AddDirectorAction(pSet, DirectorActionId.Stop, "Stop", 
				"Stop (or end) the specified Artifact.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupDirectorType(DataSet pSet) {
			AddDirectorType(pSet, DirectorTypeId.Hyperlink, "Hyperlink",
				"There is a hyperlink from the primary Artifact to the related Artifact.");
			AddDirectorType(pSet, DirectorTypeId.DefinedPath, "Defined Path",
				"There is an expected, pre-defined path from the "+
				"primary Artifact to the related Artifact.");
			AddDirectorType(pSet, DirectorTypeId.SuggestPath, "Suggested Path",
				"There is a suggested, recommented path from the "+
				"primary Artifact to the related Artifact.");
			AddDirectorType(pSet, DirectorTypeId.AvoidPath, "Avoid Path",
				"There is an unsuitable, non-recommented path from the "+
				"primary Artifact to the related Artifact.");
			AddDirectorType(pSet, DirectorTypeId.Causality, "Causality",
				"The primary Artifact causes an effect/action to occur upon the related Artifact.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupEventorPrecision(DataSet pSet) {
			AddEventorPrecision(pSet, EventorPrecisionId.Year, "Year",
				"This Eventor date is accurate to the year.");
			AddEventorPrecision(pSet, EventorPrecisionId.Month, "Month", 
				"This Eventor date is accurate to the month.");
			AddEventorPrecision(pSet, EventorPrecisionId.Day, "Day", 
				"This Eventor date is accurate to the day.");
			AddEventorPrecision(pSet, EventorPrecisionId.Hour, "Hour",
				"This Eventor date is accurate to the hour.");
			AddEventorPrecision(pSet, EventorPrecisionId.Minute, "Minute",
				"This Eventor date is accurate to the minute.");
			AddEventorPrecision(pSet, EventorPrecisionId.Second, "Second",
				"This Eventor date is accurate to the second.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupEventorType(DataSet pSet) {
			AddEventorType(pSet, EventorTypeId.Start, "Start", 
				"This Factor starts, begins, or commences on the specified date.");
			AddEventorType(pSet, EventorTypeId.End, "End", 
				"This Factor ends, stops, or terminates on the specified date.");
			AddEventorType(pSet, EventorTypeId.Pause, "Pause", 
				"This Factor pauses, suspendeds, or waits on the specified date.");
			AddEventorType(pSet, EventorTypeId.Unpause, "Unpause", 
				"This Factor unpauses or resumes on the specified date.");
			AddEventorType(pSet, EventorTypeId.Continue, "Continue", 
				"This Factor continues in its current state on the specified date.");
			AddEventorType(pSet, EventorTypeId.Occur, "Occur", 
				"This Factor occurrs or happens on the specified date.");
			AddEventorType(pSet, EventorTypeId.Expected, "Expected",
				"This Factor is/was expected, anticipated, or due on the specified date.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupFactorAssert(DataSet pSet) {
			AddFactorAssertion(pSet, FactorAssertionId.Undefined, "Undefined",
				"The Factor's assertion type is not known or not defined.");
			AddFactorAssertion(pSet, FactorAssertionId.Fact, "Fact",
				"The Factor represents a factual statement.");
			AddFactorAssertion(pSet, FactorAssertionId.Opinion, "Opinion",
				"The Factor represents an opinion.");
			AddFactorAssertion(pSet, FactorAssertionId.Guess, "Guess",
				"The Factor represents a guess.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupIdentorType(DataSet pSet) {
			AddIdentorType(pSet, IdentorTypeId.Text, "Text",
				"A value (a string, typically a name).");
			AddIdentorType(pSet, IdentorTypeId.Key, "Key",
				"A value (numeric or otherwise) representing a unique key or ID.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupLocatorType(DataSet pSet) {
			AddLocatorTypeCoord(pSet, LocatorTypeId.EarthCoord, "Earth Coordinate",
				"A coordinate position on Earth.");
			AddLocatorTypeCoord(pSet, LocatorTypeId.MoonCoord, "Moon Coordinate",
				"A coordinate position on Earth's Moon.");
			AddLocatorTypeCoord(pSet, LocatorTypeId.MarsCoord, "Mars Coordinate",
				"A coordinate position on Mars.");

			const string pos = "A position is relative to the Artifact's dimensions. For example, "+
				"X=0.25 represents a position (starting from the origin) that is 25% of the "+
				"distance to the maximum X dimension.";

			AddLocatorType(pSet, LocatorTypeId.RelPos1D, "Relative Position 1D",
				"A one-dimensional position, using X=Time. "+pos,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				0, 0,
				0, 0);

			AddLocatorType(pSet, LocatorTypeId.RelPos2D, "Relative Position 2D",
				"A two-dimensional position, using X=Width and Y=Height. "+pos,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				0, 0);

			AddLocatorType(pSet, LocatorTypeId.RelPos3D, "Relative Position 3D",
				"A three-dimensional position, using X, Y, and Z axes. "+pos,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax,
				FabricUtil.DoubleMin, FabricUtil.DoubleMax);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorRangeLevel(DataSet pSet) {
			AddVectorRangeLevel(pSet, VectorRangeLevelId.Zero0, 0.0f, "Zero");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.Zero05, 0.5f, "Zero");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.Zero1, 1.0f, "Zero");

			AddVectorRangeLevel(pSet, VectorRangeLevelId.Min0, 0.0f, "Minimum");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.Max1, 1.0f, "Maximum");

			AddVectorRangeLevel(pSet, VectorRangeLevelId.CompDisagree, 0.0f, "Completely Disagree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.MostDisagree, 1/6.0f, "Mostly Disagree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.SomeDisagree, 2/6.0f, "Somewhat Disagree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.NoOpinion05, 3/6.0f, "No Opinion");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.SomeAgree, 4/6.0f, "Somewhat Agree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.MostAgree, 5/6.0f, "Mostly Agree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.CompAgree, 1.0f, "Completely Agree");

			AddVectorRangeLevel(pSet, VectorRangeLevelId.NoOpinion0, 0.0f, "No Opinion");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.SomeAgreePos, 1/3.0f, "Somewhat Agree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.MostAgreePos, 2/3.0f, "Mostly Agree");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.CompAgreePos, 1.0f, "Completely Agree");

			AddVectorRangeLevel(pSet, VectorRangeLevelId.CompUnfavor, 0.0f, "Completely Unfavorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.MostUnfavor, 1/6.0f, "Mostly Unfavorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.SomeUnfavor, 2/6.0f, "Somewhat Unfavorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.SomeFavor, 4/6.0f, "Somewhat Favorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.MostFavor, 5/6.0f, "Mostly Favorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.CompFavor, 1.0f, "Completely Favorable");

			AddVectorRangeLevel(pSet, VectorRangeLevelId.SomeFavorPos, 1/3.0f, "Somewhat Favorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.MostFavorPos, 2/3.0f, "Mostly Favorable");
			AddVectorRangeLevel(pSet, VectorRangeLevelId.CompFavorPos, 1.0f, "Completely Favorable");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorRange(DataSet pSet) {
			AddVectorRange(pSet, VectorRangeId.FullNum, "Full Numeric", new [] {
				VectorRangeLevelId.Min0,
				VectorRangeLevelId.Zero05,
				VectorRangeLevelId.Max1
			});
			AddVectorRange(pSet, VectorRangeId.PosNum, "Positive Numeric", new[] {
				VectorRangeLevelId.Zero0,
				VectorRangeLevelId.Max1
			});
			AddVectorRange(pSet, VectorRangeId.NegNum, "Negative Numeric", new[] {
				VectorRangeLevelId.Min0,
				VectorRangeLevelId.Zero1
			});
			AddVectorRange(pSet, VectorRangeId.FullAgree, "Full Agreement", new[] {
				VectorRangeLevelId.CompDisagree,
				VectorRangeLevelId.MostDisagree,
				VectorRangeLevelId.SomeDisagree,
				VectorRangeLevelId.NoOpinion05,
				VectorRangeLevelId.SomeAgree,
				VectorRangeLevelId.MostAgree,
				VectorRangeLevelId.CompAgree
			});
			AddVectorRange(pSet, VectorRangeId.PosAgree, "Positive Agreement", new[] {
				VectorRangeLevelId.NoOpinion0,
				VectorRangeLevelId.SomeAgreePos,
				VectorRangeLevelId.MostAgreePos,
				VectorRangeLevelId.CompAgreePos
			});
			AddVectorRange(pSet, VectorRangeId.FullFavor, "Full Favorability", new[] {
				VectorRangeLevelId.CompUnfavor,
				VectorRangeLevelId.MostUnfavor,
				VectorRangeLevelId.SomeUnfavor,
				VectorRangeLevelId.NoOpinion05,
				VectorRangeLevelId.SomeFavor,
				VectorRangeLevelId.MostFavor,
				VectorRangeLevelId.CompFavor
			});
			AddVectorRange(pSet, VectorRangeId.PosFavor, "Positive Favorability", new[] {
				VectorRangeLevelId.NoOpinion0,
				VectorRangeLevelId.SomeFavorPos,
				VectorRangeLevelId.MostFavorPos,
				VectorRangeLevelId.CompFavorPos
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorType(DataSet pSet) {
			const long min = long.MinValue;
			const long max = long.MaxValue;

			AddVectorType(pSet, VectorTypeId.FullLong, VectorRangeId.FullNum,
				min, max, "Full Bounds");
			AddVectorType(pSet, VectorTypeId.PosLong, VectorRangeId.PosNum,
				0, max, "Positive Bounds");
			AddVectorType(pSet, VectorTypeId.NegLong, VectorRangeId.NegNum,
				min, 0, "Negative Bounds");

			AddVectorType(pSet, VectorTypeId.FullPerc, VectorRangeId.FullNum,
				min, max, "Full Percentage");
			AddVectorType(pSet, VectorTypeId.StdPerc, VectorRangeId.PosNum,
				0, 100, "Standard Percentage");
			AddVectorType(pSet, VectorTypeId.OppPerc,VectorRangeId.FullNum,
				-100, 100, "Opposable Percentage");

			AddVectorType(pSet, VectorTypeId.StdAgree, VectorRangeId.PosAgree,
				0, 100, "Standard Agreement");
			AddVectorType(pSet, VectorTypeId.OppAgree, VectorRangeId.FullAgree,
				-100, 100, "Opposable Agreement");

			AddVectorType(pSet, VectorTypeId.StdFavor, VectorRangeId.PosFavor,
				0, 100, "Standard Favorability");
			AddVectorType(pSet, VectorTypeId.OppFavor, VectorRangeId.FullFavor,
				-100, 100, "Opposable Favorability");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorUnit(DataSet pSet) {
			AddVectorUnit(pSet, VectorUnitId.None, "None", "");
			AddVectorUnit(pSet, VectorUnitId.Unit, "Unit", "");

			AddVectorUnit(pSet, VectorUnitId.Metre, "Metre", "m");
			AddVectorUnit(pSet, VectorUnitId.Gram, "Gram", "g");
			AddVectorUnit(pSet, VectorUnitId.Second, "Second", "s");
			AddVectorUnit(pSet, VectorUnitId.Ampere, "Ampere", "A");
			AddVectorUnit(pSet, VectorUnitId.Celsius, "Celsius", "C");
			AddVectorUnit(pSet, VectorUnitId.Candela, "Candela", "cd");
			AddVectorUnit(pSet, VectorUnitId.Mole, "Mole", "mol");
			AddVectorUnit(pSet, VectorUnitId.Bit, "Bit", "b");
			AddVectorUnit(pSet, VectorUnitId.Byte, "long", "B");

			AddVectorUnit(pSet, VectorUnitId.Hertz, "Hertz", "Hz");
			AddVectorUnit(pSet, VectorUnitId.Radian, "Radian", "rad");
			AddVectorUnit(pSet, VectorUnitId.Newton, "Newton", "N");
			AddVectorUnit(pSet, VectorUnitId.Pascal, "Pascal", "Pa");
			AddVectorUnit(pSet, VectorUnitId.Joule, "Joule", "J");
			AddVectorUnit(pSet, VectorUnitId.Watt, "Watt", "W");
			AddVectorUnit(pSet, VectorUnitId.Volt, "Volt", "V");
			AddVectorUnit(pSet, VectorUnitId.Ohm, "Ohm", "Ω");

			AddVectorUnit(pSet, VectorUnitId.Area, "Area", "m^2");
			AddVectorUnit(pSet, VectorUnitId.Volume, "Volume", "m^3");
			AddVectorUnit(pSet, VectorUnitId.Speed, "Speed", "m/s");
			AddVectorUnit(pSet, VectorUnitId.Acceleration, "Acceleration", "m^3/s");

			AddVectorUnit(pSet, VectorUnitId.Point, "Point", "pt");
			AddVectorUnit(pSet, VectorUnitId.Item, "Item", "item");
			AddVectorUnit(pSet, VectorUnitId.Person, "Person", "person");
			AddVectorUnit(pSet, VectorUnitId.Percent, "Percent", "%");
			AddVectorUnit(pSet, VectorUnitId.Index, "Index", "index");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorUnitPrefix(DataSet pSet) {
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Base, "Base", "",
				VectorUnitPrefixConst.Base);

			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Kilo, "Kilo", "k",
				VectorUnitPrefixConst.Kilo);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Mega, "Mega", "M",
				VectorUnitPrefixConst.Mega);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Giga, "Giga", "G", 
				VectorUnitPrefixConst.Giga);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Tera, "Tera", "T", 
				VectorUnitPrefixConst.Tera);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Peta, "Peta", "P", 
				VectorUnitPrefixConst.Peta);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Exa, "Exa", "E", 
				VectorUnitPrefixConst.Exa);

			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Milli, "Milli", "m", 
				VectorUnitPrefixConst.Milli);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Micro, "Micro", "μ", 
				VectorUnitPrefixConst.Micro);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Nano, "Nano", "n", 
				VectorUnitPrefixConst.Nano);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Pico, "Pico", "p", 
				VectorUnitPrefixConst.Pico);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Femto, "Femto", "f", 
				VectorUnitPrefixConst.Femto);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Atto, "Atto", "a", 
				VectorUnitPrefixConst.Atto);

			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Kibi, "Kibi", "Ki", 
				VectorUnitPrefixConst.Kibi);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Mebi, "Mebi", "Mi", 
				VectorUnitPrefixConst.Mebi);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Gibi, "Gibi", "Gi", 
				VectorUnitPrefixConst.Gibi);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Tebi, "Tebi", "Ti", 
				VectorUnitPrefixConst.Tebi);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Pebi, "Pebi", "Pi", 
				VectorUnitPrefixConst.Pebi);
			AddVectorUnitPrefix(pSet, VectorUnitPrefixId.Exbi, "Exbi", "Ei", 
				VectorUnitPrefixConst.Exbi);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupVectorUnitDerived(DataSet pSet) {
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.HertzSec,
				VectorUnitId.Hertz, VectorUnitId.Second, -1);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.NewtonGram,
				VectorUnitId.Newton, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.NewTonMetre,
				VectorUnitId.Newton, VectorUnitId.Metre, 1);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.NewtonSec,
				VectorUnitId.Newton, VectorUnitId.Second, -2);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.PascalGram,
				VectorUnitId.Pascal, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.PascalMetre,
				VectorUnitId.Pascal, VectorUnitId.Metre, -1);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.PascalSec,
				VectorUnitId.Pascal, VectorUnitId.Second, -2);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.JouleGram,
				VectorUnitId.Joule, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.JouleMetre,
				VectorUnitId.Joule, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.JouleSec,
				VectorUnitId.Joule, VectorUnitId.Second, -2);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.WattGram,
				VectorUnitId.Watt, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.WattMetre,
				VectorUnitId.Watt, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.WattSec,
				VectorUnitId.Watt, VectorUnitId.Second, -3);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.VoltGram,
				VectorUnitId.Volt, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.VoltMetre,
				VectorUnitId.Volt, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.VoltSec,
				VectorUnitId.Volt, VectorUnitId.Second, -3);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.VoltAmp, 
				VectorUnitId.Volt, VectorUnitId.Ampere, -1);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.OhmGram, 
				VectorUnitId.Ohm, VectorUnitId.Gram, 1, VectorUnitPrefixId.Kilo);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.OhmMetre, 
				VectorUnitId.Ohm, VectorUnitId.Metre, 2);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.OhmSec, 
				VectorUnitId.Ohm, VectorUnitId.Second, -3);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.OhmAmp, 
				VectorUnitId.Ohm, VectorUnitId.Ampere, -2);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.AreaMetre, 
				VectorUnitId.Area, VectorUnitId.Metre, 2);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.VolumeMetre, 
				VectorUnitId.Volume, VectorUnitId.Metre, 3);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.SpeedMetre, 
				VectorUnitId.Speed, VectorUnitId.Metre, 1);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.SpeedSec, 
				VectorUnitId.Speed, VectorUnitId.Second, -1);

			AddVectorUnitDerived(pSet, VectorUnitDerivedId.AccelMetre, 
				VectorUnitId.Acceleration, VectorUnitId.Metre, 1);
			AddVectorUnitDerived(pSet, VectorUnitDerivedId.AccelSec, 
				VectorUnitId.Acceleration, VectorUnitId.Second, -2);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void AddDescriptorType(DataSet pSet, DescriptorTypeId pId, string pName,
																						string pDesc) {
			var t = new DescriptorType();
			t.DescriptorTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.DescriptorTypeId, false);
			pSet.AddRootRel<RootContainsDescriptorType>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddDirectorAction(DataSet pSet, DirectorActionId pId, string pName,
																						string pDesc) {
			var t = new DirectorAction();
			t.DirectorActionId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.DirectorActionId, false);
			pSet.AddRootRel<RootContainsDirectorAction>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddDirectorType(DataSet pSet, DirectorTypeId pId, string pName,
																						string pDesc) {
			var t = new DirectorType();
			t.DirectorTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.DirectorTypeId, false);
			pSet.AddRootRel<RootContainsDirectorType>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddEventorPrecision(DataSet pSet, EventorPrecisionId pId, string pName,
																						string pDesc) {
			var t = new EventorPrecision();
			t.EventorPrecisionId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.EventorPrecisionId, false);
			pSet.AddRootRel<RootContainsEventorPrecision>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddEventorType(DataSet pSet, EventorTypeId pId, string pName,
																						string pDesc) {
			var t = new EventorType();
			t.EventorTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.EventorTypeId, false);
			pSet.AddRootRel<RootContainsEventorType>(t, false);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static void AddFactorAssertion(DataSet pSet, FactorAssertionId pId, string pName,
																						string pDesc) {
			var t = new FactorAssertion();
			t.FactorAssertionId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.FactorAssertionId, false);
			pSet.AddRootRel<RootContainsFactorAssertion>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddIdentorType(DataSet pSet, IdentorTypeId pId, string pName,
																						string pDesc) {
			var t = new IdentorType();
			t.IdentorTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.IdentorTypeId, false);
			pSet.AddRootRel<RootContainsIdentorType>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddLocatorType(DataSet pSet, LocatorTypeId pId, string pName,
								string pDesc, double pMinX, double pMaxX, double pMinY, double pMaxY,
																		double pMinZ, double pMaxZ) {
			var t = new LocatorType();
			t.LocatorTypeId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			t.MinX = pMinX;
			t.MaxX = pMaxX;
			t.MinY = pMinY;
			t.MaxY = pMaxY;
			t.MinZ = pMinZ;
			t.MaxZ = pMaxZ;
			pSet.AddNodeAndIndex(t, x => x.LocatorTypeId, false);
			pSet.AddRootRel<RootContainsLocatorType>(t, false);
		}


		/*--------------------------------------------------------------------------------------------*/
		private static void AddLocatorTypeCoord(DataSet pSet, LocatorTypeId pId, string pName,
																						string pDesc) {
			AddLocatorType(pSet, pId, pName,
				pDesc+"Coordinates use X=Longitude, Y=Latitude, and Z=Elevation "+
				"(in metres).", -180, 180, -90, 90, FabricUtil.DoubleMin, FabricUtil.DoubleMax);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorRangeLevel(DataSet pSet, VectorRangeLevelId pId, float pPosition,
																						string pName) {
			var t = new VectorRangeLevel();
			t.VectorRangeLevelId = (long)pId;
			t.Name = pName;
			t.Description = "";
			t.Position = pPosition;
			pSet.AddNodeAndIndex(t, x => x.VectorRangeLevelId, false);
			pSet.AddRootRel<RootContainsVectorRangeLevel>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorRange(DataSet pSet, VectorRangeId pId, string pName,
															IEnumerable<VectorRangeLevelId> pLevels) {
			var t = new VectorRange();
			t.VectorRangeId = (long)pId;
			t.Name = pName;
			t.Description = "";
			pSet.AddNodeAndIndex(t, x => x.VectorRangeId, false);
			pSet.AddRootRel<RootContainsVectorRange>(t, false);

			foreach ( VectorRangeLevelId level in pLevels ) {
				var rel = DataRel.Create(t, new VectorRangeUsesVectorRangeLevel(),
					pSet.GetNode<VectorRangeLevel>((long)level), false);
				pSet.AddRel(rel);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorType(DataSet pSet, VectorTypeId pId, VectorRangeId pRangeId,
																long pMin, long pMax, string pName) {
			var t = new VectorType();
			t.VectorTypeId = (long)pId;
			t.Name = pName;
			t.Description = "";
			t.Min = pMin;
			t.Max = pMax;
			pSet.AddNodeAndIndex(t, x => x.VectorTypeId, false);
			pSet.AddRootRel<RootContainsVectorType>(t, false);

			var rel = DataRel.Create(t, new VectorTypeUsesVectorRange(),
				pSet.GetNode<VectorRange>((long)pRangeId), false);
			pSet.AddRel(rel);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorUnit(DataSet pSet, VectorUnitId pId, string pName, string pDesc) {
			var t = new VectorUnit();
			t.VectorUnitId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			pSet.AddNodeAndIndex(t, x => x.VectorUnitId, false);
			pSet.AddRootRel<RootContainsVectorUnit>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorUnitPrefix(DataSet pSet, VectorUnitPrefixId pId, string pName,
																		string pDesc, double pAmount) {
			var t = new VectorUnitPrefix();
			t.VectorUnitPrefixId = (long)pId;
			t.Name = pName;
			t.Description = pDesc;
			t.Amount = pAmount;
			pSet.AddNodeAndIndex(t, x => x.VectorUnitPrefixId, false);
			pSet.AddRootRel<RootContainsVectorUnitPrefix>(t, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddVectorUnitDerived(DataSet pSet, VectorUnitDerivedId pId, 
											VectorUnitId pDefinesId, VectorUnitId pRaisesId, int pExp,
											VectorUnitPrefixId pPrefix=VectorUnitPrefixId.Base) {
			var t = new VectorUnitDerived();
			t.VectorUnitDerivedId = (long)pId;
			t.Name = "";
			t.Description = "";
			t.Exponent = pExp;
			pSet.AddNodeAndIndex(t, x => x.VectorUnitDerivedId, false);
			pSet.AddRootRel<RootContainsVectorUnitDerived>(t, false);

			var relD = DataRel.Create(t, new VectorUnitDerivedDefinesVectorUnit(),
				pSet.GetNode<VectorUnit>((long)pDefinesId), false);
			pSet.AddRel(relD);

			var relR = DataRel.Create(t, new VectorUnitDerivedRaisesToExpVectorUnit(),
				pSet.GetNode<VectorUnit>((long)pRaisesId), false);
			pSet.AddRel(relR);

			var relP = DataRel.Create(t, new VectorUnitDerivedUsesVectorUnitPrefix(),
				pSet.GetNode<VectorUnitPrefix>((long)pPrefix), false);
			pSet.AddRel(relP);
		}

	}

}