
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using System.Linq;

namespace Fabric.Domain.Enums {


	/*================================================================================================*/
	public class DescriptorType : EnumObject {

		public enum Id : byte {
			IsRelatedTo = 1,
			IsA, // 2
			IsAnInstanceOf, // 3
			HasA, // 4
			IsLike, // 5
			IsNotLike, // 6
			RefersTo, // 7
			IsCreatedBy, // 8
			IsInterestedIn, // 9
			Receives, // 10
			Consumes, // 11
			Produces, // 12
			ParticipatesIn, // 13
			IsFoundIn, // 14
			BelongsTo, // 15
			Requires, // 16
			InteractsWith, // 17
			LooksLike, // 18
			SmellsLike, // 19
			TastesLike, // 20
			SoundsLike, // 21
			FeelsLike, // 22
			EmotesLike, // 23
			Uses, // 24
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.IsRelatedTo, new Item {
				Id = 1,
				EnumId = "IsRelatedTo",
				Name = "Is Related To",
				Description = "The primary Artifact is related to the related Artifact in some way. This is the default (and least meaningful) DescriptorType.",
			}},
			{Id.IsA, new Item {
				Id = 2,
				EnumId = "IsA",
				Name = "Is (A/An)",
				Description = "The primary Artifact is a type of, a subclass of, a subset of, a subordinate of, or in the category defined by the related Artifact.",
			}},
			{Id.IsAnInstanceOf, new Item {
				Id = 3,
				EnumId = "IsAnInstanceOf",
				Name = "Is An Instance Of",
				Description = "The primary Artifact is an instance, case, example, or representation of the related Artifact.",
			}},
			{Id.HasA, new Item {
				Id = 4,
				EnumId = "HasA",
				Name = "Has (A/An)",
				Description = "The primary Artifact has, as a part, piece, feature, attribute, or component, the related Artifact.",
			}},
			{Id.IsLike, new Item {
				Id = 5,
				EnumId = "IsLike",
				Name = "Is Like",
				Description = "The primary Artifact is like or similar to the related Artifact.",
			}},
			{Id.IsNotLike, new Item {
				Id = 6,
				EnumId = "IsNotLike",
				Name = "Is Not Like",
				Description = "The primary Artifact is not like or not similar to the related Artifact",
			}},
			{Id.RefersTo, new Item {
				Id = 7,
				EnumId = "RefersTo",
				Name = "Refers To",
				Description = "The primary Artifact refers to, mentions, discusses, links to, or references the related Artifact.",
			}},
			{Id.IsCreatedBy, new Item {
				Id = 8,
				EnumId = "IsCreatedBy",
				Name = "Is Created By",
				Description = "The primary Artifact is created, built, designed, invented, formed, or performed by the related Artifact.",
			}},
			{Id.IsInterestedIn, new Item {
				Id = 9,
				EnumId = "IsInterestedIn",
				Name = "Is Interested In",
				Description = "The primary Artifact is interested in, fond of, attracted to, enjoys, prefers, or desires the related Artifact.",
			}},
			{Id.Receives, new Item {
				Id = 10,
				EnumId = "Receives",
				Name = "Receives",
				Description = "The primary Artifact receives, gets, obtains, or is awarded the related Artifact.",
			}},
			{Id.Consumes, new Item {
				Id = 11,
				EnumId = "Consumes",
				Name = "Consumes",
				Description = "The primary Artifact consumes, eats, is powered by, uses up, depletes, or destroys the related Artifact.",
			}},
			{Id.Produces, new Item {
				Id = 12,
				EnumId = "Produces",
				Name = "Produces",
				Description = "The primary Artifact produces, has a byproduct of, creates, or generates the related Artifact. This is similar to 'Is Created By', but in the opposite direction and meant to be less specific.",
			}},
			{Id.ParticipatesIn, new Item {
				Id = 13,
				EnumId = "ParticipatesIn",
				Name = "Participates In",
				Description = "The primary Artifact participates in, competes in, attends, is a member of, or is involved in the related Artifact.",
			}},
			{Id.IsFoundIn, new Item {
				Id = 14,
				EnumId = "IsFoundIn",
				Name = "Is Found In",
				Description = "The primary Artifact is found in, located at, lives in, or is contained by the related Artifact.",
			}},
			{Id.BelongsTo, new Item {
				Id = 15,
				EnumId = "BelongsTo",
				Name = "Belongs To",
				Description = "The primary Artifact belongs to, is controlled by, or is owned by the related Artifact.",
			}},
			{Id.Requires, new Item {
				Id = 16,
				EnumId = "Requires",
				Name = "Requires",
				Description = "The primary Artifact requires, implies, needs, or demands the related Artifact.",
			}},
			{Id.InteractsWith, new Item {
				Id = 17,
				EnumId = "InteractsWith",
				Name = "Interacts With",
				Description = "The primary Artifact interacts, associates, combines, meets, or communicates with the related Artifact.",
			}},
			{Id.LooksLike, new Item {
				Id = 18,
				EnumId = "LooksLike",
				Name = "Looks Like",
				Description = "The primary Artifact looks like (has the appearance of) the related Artifact.",
			}},
			{Id.SmellsLike, new Item {
				Id = 19,
				EnumId = "SmellsLike",
				Name = "Smells Like",
				Description = "The primary Artifact smells like (has the odor, aroma, or fragrance of) the related Artifact.",
			}},
			{Id.TastesLike, new Item {
				Id = 20,
				EnumId = "TastesLike",
				Name = "Tastes Like",
				Description = "The primary Artifact tastes like (has the flavor of) the related Artifact.",
			}},
			{Id.SoundsLike, new Item {
				Id = 21,
				EnumId = "SoundsLike",
				Name = "Sounds Like",
				Description = "The primary Artifact sounds like (has the aural characteristics of) the related Artifact.",
			}},
			{Id.FeelsLike, new Item {
				Id = 22,
				EnumId = "FeelsLike",
				Name = "Feels Like",
				Description = "The primary Artifact feels like (has the tactile characteristics of) the related Artifact.",
			}},
			{Id.EmotesLike, new Item {
				Id = 23,
				EnumId = "EmotesLike",
				Name = "Emotes Like",
				Description = "The primary Artifact emotes like (causes the emotion of) the related Artifact.",
			}},
			{Id.Uses, new Item {
				Id = 24,
				EnumId = "Uses",
				Name = "Uses",
				Description = "The primary Artifact uses, utilizes, controls, employs, or manipulates the related Artifact.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class DirectorAction : EnumObject {

		public enum Id : byte {
			Read = 1,
			Listen, // 2
			View, // 3
			Consume, // 4
			Perform, // 5
			Produce, // 6
			Destroy, // 7
			Modify, // 8
			Obtain, // 9
			Locate, // 10
			Travel, // 11
			Become, // 12
			Explain, // 13
			Give, // 14
			Learn, // 15
			Start, // 16
			Stop, // 17
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Read, new Item {
				Id = 1,
				EnumId = "Read",
				Name = "Read",
				Description = "Read the specified Artifact.",
			}},
			{Id.Listen, new Item {
				Id = 2,
				EnumId = "Listen",
				Name = "Listen",
				Description = "Listen to the specified Artifact.",
			}},
			{Id.View, new Item {
				Id = 3,
				EnumId = "View",
				Name = "View",
				Description = "View (or watch, observe) the specified Artifact.",
			}},
			{Id.Consume, new Item {
				Id = 4,
				EnumId = "Consume",
				Name = "Consume",
				Description = "Consume (or use, eat, drink, taste, smell) the specified Artifact.",
			}},
			{Id.Perform, new Item {
				Id = 5,
				EnumId = "Perform",
				Name = "Perform",
				Description = "Perform (or act, do, carry out, speak, sing, say, work, write) the specified Artifact.",
			}},
			{Id.Produce, new Item {
				Id = 6,
				EnumId = "Produce",
				Name = "Produce",
				Description = "Produce (or create, build, make, invent) the specified Artifact.",
			}},
			{Id.Destroy, new Item {
				Id = 7,
				EnumId = "Destroy",
				Name = "Destroy",
				Description = "Destroy (or remove, delete, kill, erase) the specified Artifact.",
			}},
			{Id.Modify, new Item {
				Id = 8,
				EnumId = "Modify",
				Name = "Modify",
				Description = "Modify (or change) the specified Artifact.",
			}},
			{Id.Obtain, new Item {
				Id = 9,
				EnumId = "Obtain",
				Name = "Obtain",
				Description = "Obtain (or get, purchase, acquire, steal) the specified Artifact.",
			}},
			{Id.Locate, new Item {
				Id = 10,
				EnumId = "Locate",
				Name = "Locate",
				Description = "Locate (or find) the specified Artifact.",
			}},
			{Id.Travel, new Item {
				Id = 11,
				EnumId = "Travel",
				Name = "Travel",
				Description = "Travel (or visit, walk, run, fly, ride, drive) the specified Artifact.",
			}},
			{Id.Become, new Item {
				Id = 12,
				EnumId = "Become",
				Name = "Become",
				Description = "Become the specified Artifact.",
			}},
			{Id.Explain, new Item {
				Id = 13,
				EnumId = "Explain",
				Name = "Explain",
				Description = "Explain (or describe) the specified Artifact.",
			}},
			{Id.Give, new Item {
				Id = 14,
				EnumId = "Give",
				Name = "Give",
				Description = "Give the specified Artifact.",
			}},
			{Id.Learn, new Item {
				Id = 15,
				EnumId = "Learn",
				Name = "Learn",
				Description = "Learn (or study, understand) the specified Artifact.",
			}},
			{Id.Start, new Item {
				Id = 16,
				EnumId = "Start",
				Name = "Start",
				Description = "Start (or begin) the specified Artifact.",
			}},
			{Id.Stop, new Item {
				Id = 17,
				EnumId = "Stop",
				Name = "Stop",
				Description = "Stop (or end) the specified Artifact.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class DirectorType : EnumObject {

		public enum Id : byte {
			Hyperlink = 1,
			DefinedPath, // 2
			SuggestedPath, // 3
			AvoidPath, // 4
			Causality, // 5
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Hyperlink, new Item {
				Id = 1,
				EnumId = "Hyperlink",
				Name = "Hyperlink",
				Description = "There is a hyperlink from the primary Artifact to the related Artifact.",
			}},
			{Id.DefinedPath, new Item {
				Id = 2,
				EnumId = "DefinedPath",
				Name = "Defined Path",
				Description = "There is an expected, pre-defined path from the primary Artifact to the related Artifact.",
			}},
			{Id.SuggestedPath, new Item {
				Id = 3,
				EnumId = "SuggestedPath",
				Name = "Suggested Path",
				Description = "There is a suggested, recommented path from the primary Artifact to the related Artifact.",
			}},
			{Id.AvoidPath, new Item {
				Id = 4,
				EnumId = "AvoidPath",
				Name = "Avoid Path",
				Description = "There is an unsuitable, non-recommented path from the primary Artifact to the related Artifact.",
			}},
			{Id.Causality, new Item {
				Id = 5,
				EnumId = "Causality",
				Name = "Causality",
				Description = "The primary Artifact causes an effect/action to occur upon the related Artifact.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class EventorType : EnumObject {

		public enum Id : byte {
			Start = 1,
			End, // 2
			Pause, // 3
			Unpause, // 4
			Continue, // 5
			Occur, // 6
			Expected, // 7
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Start, new Item {
				Id = 1,
				EnumId = "Start",
				Name = "Start",
				Description = "This Factor starts, begins, or commences on the specified date.",
			}},
			{Id.End, new Item {
				Id = 2,
				EnumId = "End",
				Name = "End",
				Description = "This Factor ends, stops, or terminates on the specified date.",
			}},
			{Id.Pause, new Item {
				Id = 3,
				EnumId = "Pause",
				Name = "Pause",
				Description = "This Factor pauses, suspendeds, or waits on the specified date.",
			}},
			{Id.Unpause, new Item {
				Id = 4,
				EnumId = "Unpause",
				Name = "Unpause",
				Description = "This Factor unpauses or resumes on the specified date.",
			}},
			{Id.Continue, new Item {
				Id = 5,
				EnumId = "Continue",
				Name = "Continue",
				Description = "This Factor continues in its current state on the specified date.",
			}},
			{Id.Occur, new Item {
				Id = 6,
				EnumId = "Occur",
				Name = "Occur",
				Description = "This Factor occurrs or happens on the specified date.",
			}},
			{Id.Expected, new Item {
				Id = 7,
				EnumId = "Expected",
				Name = "Expected",
				Description = "This Factor is/was expected, anticipated, or due on the specified date.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class FactorAssertion : EnumObject {

		public enum Id : byte {
			Undefined = 1,
			Fact, // 2
			Opinion, // 3
			Guess, // 4
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Undefined, new Item {
				Id = 1,
				EnumId = "Undefined",
				Name = "Undefined",
				Description = "The Factor's assertion type is not known or not defined.",
			}},
			{Id.Fact, new Item {
				Id = 2,
				EnumId = "Fact",
				Name = "Fact",
				Description = "The Factor represents a factual statement.",
			}},
			{Id.Opinion, new Item {
				Id = 3,
				EnumId = "Opinion",
				Name = "Opinion",
				Description = "The Factor represents an opinion.",
			}},
			{Id.Guess, new Item {
				Id = 4,
				EnumId = "Guess",
				Name = "Guess",
				Description = "The Factor represents a guess.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class IdentorType : EnumObject {

		public enum Id : byte {
			Text = 1,
			Key, // 2
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Text, new Item {
				Id = 1,
				EnumId = "Text",
				Name = "Text",
				Description = "A value (a string, typically a name).",
			}},
			{Id.Key, new Item {
				Id = 2,
				EnumId = "Key",
				Name = "Key",
				Description = "A value (numeric or otherwise) representing a unique key or ID.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class LocatorType : EnumObject {

		public enum Id : byte {
			EarthCoord = 1,
			MoonCoord, // 2
			MarsCoord, // 3
			RelPos1D, // 4
			RelPos2D, // 5
			RelPos3D, // 6
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {

			public double MinX { get; set; }
			public double MaxX { get; set; }
			public double MinY { get; set; }
			public double MaxY { get; set; }
			public double MinZ { get; set; }
			public double MaxZ { get; set; }

		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.EarthCoord, new Item {
				MinX = -180,
				MaxX = 180,
				MinY = -90,
				MaxY = 90,
				MinZ = -1.79769313486231E+308,
				MaxZ = 1.79769313486231E+308,
				Id = 1,
				EnumId = "EarthCoord",
				Name = "Earth Coordinate",
				Description = "A coordinate position on Earth.Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).",
			}},
			{Id.MoonCoord, new Item {
				MinX = -180,
				MaxX = 180,
				MinY = -90,
				MaxY = 90,
				MinZ = -1.79769313486231E+308,
				MaxZ = 1.79769313486231E+308,
				Id = 2,
				EnumId = "MoonCoord",
				Name = "Moon Coordinate",
				Description = "A coordinate position on Earth's Moon.Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).",
			}},
			{Id.MarsCoord, new Item {
				MinX = -180,
				MaxX = 180,
				MinY = -90,
				MaxY = 90,
				MinZ = -1.79769313486231E+308,
				MaxZ = 1.79769313486231E+308,
				Id = 3,
				EnumId = "MarsCoord",
				Name = "Mars Coordinate",
				Description = "A coordinate position on Mars.Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).Coordinates use X=Longitude, Y=Latitude, and Z=Elevation (in metres).",
			}},
			{Id.RelPos1D, new Item {
				MinX = -1.79769313486231E+308,
				MaxX = 1.79769313486231E+308,
				MinY = 0,
				MaxY = 0,
				MinZ = 0,
				MaxZ = 0,
				Id = 4,
				EnumId = "RelPos1D",
				Name = "Relative Position 1D",
				Description = "A one-dimensional position, using X=Time. A position is relative to the Artifact's dimensions. For example, X=0.25 represents a position (starting from the origin) that is 25% of the distance to the maximum X dimension.",
			}},
			{Id.RelPos2D, new Item {
				MinX = -1.79769313486231E+308,
				MaxX = 1.79769313486231E+308,
				MinY = -1.79769313486231E+308,
				MaxY = 1.79769313486231E+308,
				MinZ = 0,
				MaxZ = 0,
				Id = 5,
				EnumId = "RelPos2D",
				Name = "Relative Position 2D",
				Description = "A two-dimensional position, using X=Width and Y=Height. A position is relative to the Artifact's dimensions. For example, X=0.25 represents a position (starting from the origin) that is 25% of the distance to the maximum X dimension.",
			}},
			{Id.RelPos3D, new Item {
				MinX = -1.79769313486231E+308,
				MaxX = 1.79769313486231E+308,
				MinY = -1.79769313486231E+308,
				MaxY = 1.79769313486231E+308,
				MinZ = -1.79769313486231E+308,
				MaxZ = 1.79769313486231E+308,
				Id = 6,
				EnumId = "RelPos3D",
				Name = "Relative Position 3D",
				Description = "A three-dimensional position, using X, Y, and Z axes. A position is relative to the Artifact's dimensions. For example, X=0.25 represents a position (starting from the origin) that is 25% of the distance to the maximum X dimension.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class MemberType : EnumObject {

		public enum Id : byte {
			None = 1,
			Request, // 2
			Invite, // 3
			Member, // 4
			Staff, // 5
			Admin, // 6
			Owner, // 7
			DataProv, // 8
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.None, new Item {
				Id = 1,
				EnumId = "None",
				Name = "None",
				Description = "The User is not associated with this App.",
			}},
			{Id.Request, new Item {
				Id = 2,
				EnumId = "Request",
				Name = "Request",
				Description = "The user would like to become a member of this App.",
			}},
			{Id.Invite, new Item {
				Id = 3,
				EnumId = "Invite",
				Name = "Invite",
				Description = "The User has been invited to become a member of this App.",
			}},
			{Id.Member, new Item {
				Id = 4,
				EnumId = "Member",
				Name = "Member",
				Description = "The User is a member of this App.",
			}},
			{Id.Staff, new Item {
				Id = 5,
				EnumId = "Staff",
				Name = "Staff",
				Description = "The User is a staff member of this App.",
			}},
			{Id.Admin, new Item {
				Id = 6,
				EnumId = "Admin",
				Name = "Admin",
				Description = "The User is an administrator of this App.",
			}},
			{Id.Owner, new Item {
				Id = 7,
				EnumId = "Owner",
				Name = "Owner",
				Description = "The User owns this App.",
			}},
			{Id.DataProv, new Item {
				Id = 8,
				EnumId = "DataProv",
				Name = "Data Provider",
				Description = "The User has a special membership that allows it to interact with Fabric on behalf of the App.",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VectorRangeLevel : EnumObject {

		public enum Id : byte {
			Zero0 = 1,
			Zero05, // 2
			Zero1, // 3
			Min0, // 4
			Max1, // 5
			CompDisagree, // 6
			MostDisagree, // 7
			SomeDisagree, // 8
			NoOpinion05, // 9
			SomeAgree, // 10
			MostAgree, // 11
			CompAgree, // 12
			NoOpinion0, // 13
			SomeAgreePos, // 14
			MostAgreePos, // 15
			CompAgreePos, // 16
			CompUnfavor, // 17
			MostUnfavor, // 18
			SomeUnfavor, // 19
			SomeFavor, // 20
			MostFavor, // 21
			CompFavor, // 22
			SomeFavorPos, // 23
			MostFavorPos, // 24
			CompFavorPos, // 25
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {

			public float Position { get; set; }

		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Zero0, new Item {
				Position = 0f,
				Id = 1,
				EnumId = "Zero0",
				Name = "Zero",
				Description = "",
			}},
			{Id.Zero05, new Item {
				Position = 0.5f,
				Id = 2,
				EnumId = "Zero05",
				Name = "Zero",
				Description = "",
			}},
			{Id.Zero1, new Item {
				Position = 1f,
				Id = 3,
				EnumId = "Zero1",
				Name = "Zero",
				Description = "",
			}},
			{Id.Min0, new Item {
				Position = 0f,
				Id = 4,
				EnumId = "Min0",
				Name = "Minimum",
				Description = "",
			}},
			{Id.Max1, new Item {
				Position = 1f,
				Id = 5,
				EnumId = "Max1",
				Name = "Maximum",
				Description = "",
			}},
			{Id.CompDisagree, new Item {
				Position = 0f,
				Id = 6,
				EnumId = "CompDisagree",
				Name = "Completely Disagree",
				Description = "",
			}},
			{Id.MostDisagree, new Item {
				Position = 0.1666667f,
				Id = 7,
				EnumId = "MostDisagree",
				Name = "Mostly Disagree",
				Description = "",
			}},
			{Id.SomeDisagree, new Item {
				Position = 0.3333333f,
				Id = 8,
				EnumId = "SomeDisagree",
				Name = "Somewhat Disagree",
				Description = "",
			}},
			{Id.NoOpinion05, new Item {
				Position = 0.5f,
				Id = 9,
				EnumId = "NoOpinion05",
				Name = "No Opinion",
				Description = "",
			}},
			{Id.SomeAgree, new Item {
				Position = 0.6666667f,
				Id = 10,
				EnumId = "SomeAgree",
				Name = "Somewhat Agree",
				Description = "",
			}},
			{Id.MostAgree, new Item {
				Position = 0.8333333f,
				Id = 11,
				EnumId = "MostAgree",
				Name = "Mostly Agree",
				Description = "",
			}},
			{Id.CompAgree, new Item {
				Position = 1f,
				Id = 12,
				EnumId = "CompAgree",
				Name = "Completely Agree",
				Description = "",
			}},
			{Id.NoOpinion0, new Item {
				Position = 0f,
				Id = 13,
				EnumId = "NoOpinion0",
				Name = "No Opinion",
				Description = "",
			}},
			{Id.SomeAgreePos, new Item {
				Position = 0.3333333f,
				Id = 14,
				EnumId = "SomeAgreePos",
				Name = "Somewhat Agree",
				Description = "",
			}},
			{Id.MostAgreePos, new Item {
				Position = 0.6666667f,
				Id = 15,
				EnumId = "MostAgreePos",
				Name = "Mostly Agree",
				Description = "",
			}},
			{Id.CompAgreePos, new Item {
				Position = 1f,
				Id = 16,
				EnumId = "CompAgreePos",
				Name = "Completely Agree",
				Description = "",
			}},
			{Id.CompUnfavor, new Item {
				Position = 0f,
				Id = 17,
				EnumId = "CompUnfavor",
				Name = "Completely Unfavorable",
				Description = "",
			}},
			{Id.MostUnfavor, new Item {
				Position = 0.1666667f,
				Id = 18,
				EnumId = "MostUnfavor",
				Name = "Mostly Unfavorable",
				Description = "",
			}},
			{Id.SomeUnfavor, new Item {
				Position = 0.3333333f,
				Id = 19,
				EnumId = "SomeUnfavor",
				Name = "Somewhat Unfavorable",
				Description = "",
			}},
			{Id.SomeFavor, new Item {
				Position = 0.6666667f,
				Id = 20,
				EnumId = "SomeFavor",
				Name = "Somewhat Favorable",
				Description = "",
			}},
			{Id.MostFavor, new Item {
				Position = 0.8333333f,
				Id = 21,
				EnumId = "MostFavor",
				Name = "Mostly Favorable",
				Description = "",
			}},
			{Id.CompFavor, new Item {
				Position = 1f,
				Id = 22,
				EnumId = "CompFavor",
				Name = "Completely Favorable",
				Description = "",
			}},
			{Id.SomeFavorPos, new Item {
				Position = 0.3333333f,
				Id = 23,
				EnumId = "SomeFavorPos",
				Name = "Somewhat Favorable",
				Description = "",
			}},
			{Id.MostFavorPos, new Item {
				Position = 0.6666667f,
				Id = 24,
				EnumId = "MostFavorPos",
				Name = "Mostly Favorable",
				Description = "",
			}},
			{Id.CompFavorPos, new Item {
				Position = 1f,
				Id = 25,
				EnumId = "CompFavorPos",
				Name = "Completely Favorable",
				Description = "",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VectorRange : EnumObject {

		public enum Id : byte {
			FullNum = 1,
			PosNum, // 2
			NegNum, // 3
			FullAgree, // 4
			PosAgree, // 5
			FullFavor, // 6
			PosFavor, // 7
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {

			public VectorRangeLevel.Id[] Levels { get; set; }

		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.FullNum, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.Min0, 
					VectorRangeLevel.Id.Zero05, 
					VectorRangeLevel.Id.Max1, 
				},
				Id = 1,
				EnumId = "FullNum",
				Name = "Full Numeric",
				Description = "",
			}},
			{Id.PosNum, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.Zero0, 
					VectorRangeLevel.Id.Max1, 
				},
				Id = 2,
				EnumId = "PosNum",
				Name = "Positive Numeric",
				Description = "",
			}},
			{Id.NegNum, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.Min0, 
					VectorRangeLevel.Id.Zero1, 
				},
				Id = 3,
				EnumId = "NegNum",
				Name = "Negative Numeric",
				Description = "",
			}},
			{Id.FullAgree, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.CompDisagree, 
					VectorRangeLevel.Id.MostDisagree, 
					VectorRangeLevel.Id.SomeDisagree, 
					VectorRangeLevel.Id.NoOpinion05, 
					VectorRangeLevel.Id.SomeAgree, 
					VectorRangeLevel.Id.MostAgree, 
					VectorRangeLevel.Id.CompAgree, 
				},
				Id = 4,
				EnumId = "FullAgree",
				Name = "Full Agreement",
				Description = "",
			}},
			{Id.PosAgree, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.NoOpinion0, 
					VectorRangeLevel.Id.SomeAgreePos, 
					VectorRangeLevel.Id.MostAgreePos, 
					VectorRangeLevel.Id.CompAgreePos, 
				},
				Id = 5,
				EnumId = "PosAgree",
				Name = "Positive Agreement",
				Description = "",
			}},
			{Id.FullFavor, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.CompUnfavor, 
					VectorRangeLevel.Id.MostUnfavor, 
					VectorRangeLevel.Id.SomeUnfavor, 
					VectorRangeLevel.Id.NoOpinion05, 
					VectorRangeLevel.Id.SomeFavor, 
					VectorRangeLevel.Id.MostFavor, 
					VectorRangeLevel.Id.CompFavor, 
				},
				Id = 6,
				EnumId = "FullFavor",
				Name = "Full Favorability",
				Description = "",
			}},
			{Id.PosFavor, new Item {
				Levels = new[] { 
					VectorRangeLevel.Id.NoOpinion0, 
					VectorRangeLevel.Id.SomeFavorPos, 
					VectorRangeLevel.Id.MostFavorPos, 
					VectorRangeLevel.Id.CompFavorPos, 
				},
				Id = 7,
				EnumId = "PosFavor",
				Name = "Positive Favorability",
				Description = "",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VectorType : EnumObject {

		public enum Id : byte {
			FullLong = 1,
			PosLong, // 2
			NegLong, // 3
			FullPerc, // 4
			StdPerc, // 5
			OppPerc, // 6
			StdAgree, // 7
			OppAgree, // 8
			StdFavor, // 9
			OppFavor, // 10
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {

			public VectorRange.Id VectorRange { get; set; }
			public long Min { get; set; }
			public long Max { get; set; }

		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.FullLong, new Item {
				VectorRange = VectorRange.Id.FullNum,
				Min = -9223372036854775808,
				Max = 9223372036854775807,
				Id = 1,
				EnumId = "FullLong",
				Name = "Full Bounds",
				Description = "",
			}},
			{Id.PosLong, new Item {
				VectorRange = VectorRange.Id.PosNum,
				Min = 0,
				Max = 9223372036854775807,
				Id = 2,
				EnumId = "PosLong",
				Name = "Positive Bounds",
				Description = "",
			}},
			{Id.NegLong, new Item {
				VectorRange = VectorRange.Id.NegNum,
				Min = -9223372036854775808,
				Max = 0,
				Id = 3,
				EnumId = "NegLong",
				Name = "Negative Bounds",
				Description = "",
			}},
			{Id.FullPerc, new Item {
				VectorRange = VectorRange.Id.FullNum,
				Min = -9223372036854775808,
				Max = 9223372036854775807,
				Id = 4,
				EnumId = "FullPerc",
				Name = "Full Percentage",
				Description = "",
			}},
			{Id.StdPerc, new Item {
				VectorRange = VectorRange.Id.PosNum,
				Min = 0,
				Max = 100,
				Id = 5,
				EnumId = "StdPerc",
				Name = "Standard Percentage",
				Description = "",
			}},
			{Id.OppPerc, new Item {
				VectorRange = VectorRange.Id.FullNum,
				Min = -100,
				Max = 100,
				Id = 6,
				EnumId = "OppPerc",
				Name = "Opposable Percentage",
				Description = "",
			}},
			{Id.StdAgree, new Item {
				VectorRange = VectorRange.Id.PosAgree,
				Min = 0,
				Max = 100,
				Id = 7,
				EnumId = "StdAgree",
				Name = "Standard Agreement",
				Description = "",
			}},
			{Id.OppAgree, new Item {
				VectorRange = VectorRange.Id.FullAgree,
				Min = -100,
				Max = 100,
				Id = 8,
				EnumId = "OppAgree",
				Name = "Opposable Agreement",
				Description = "",
			}},
			{Id.StdFavor, new Item {
				VectorRange = VectorRange.Id.PosFavor,
				Min = 0,
				Max = 100,
				Id = 9,
				EnumId = "StdFavor",
				Name = "Standard Favorability",
				Description = "",
			}},
			{Id.OppFavor, new Item {
				VectorRange = VectorRange.Id.FullFavor,
				Min = -100,
				Max = 100,
				Id = 10,
				EnumId = "OppFavor",
				Name = "Opposable Favorability",
				Description = "",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VectorUnitDerived : EnumObject {

		public enum Id : byte {
			HertzSec = 1,
			NewtonGram, // 2
			NewtonMetre, // 3
			NewtonSec, // 4
			PascalGram, // 5
			PascalMetre, // 6
			PascalSec, // 7
			JouleGram, // 8
			JouleMetre, // 9
			JouleSec, // 10
			WattGram, // 11
			WattMetre, // 12
			WattSec, // 13
			VoltGram, // 14
			VoltMetre, // 15
			VoltSec, // 16
			VoltAmp, // 17
			OhmGram, // 18
			OhmMetre, // 19
			OhmSec, // 20
			OhmAmp, // 21
			AreaMetre, // 22
			VolumeMetre, // 23
			SpeedMetre, // 24
			SpeedSec, // 25
			AccelMetre, // 26
			AccelSec, // 27
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {

			public VectorUnit.Id DefinesVectorUnit { get; set; }
			public VectorUnit.Id RaisesVectorUnit { get; set; }
			public int WithExponent { get; set; }
			public VectorUnitPrefix.Id RaisesVectorUnitPrefix { get; set; }

		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.HertzSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Hertz,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 1,
				EnumId = "HertzSec",
				Name = "",
				Description = "",
			}},
			{Id.NewtonGram, new Item {
				DefinesVectorUnit = VectorUnit.Id.Newton,
				RaisesVectorUnit = VectorUnit.Id.Gram,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Kilo,
				Id = 2,
				EnumId = "NewtonGram",
				Name = "",
				Description = "",
			}},
			{Id.NewtonMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Newton,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 3,
				EnumId = "NewtonMetre",
				Name = "",
				Description = "",
			}},
			{Id.NewtonSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Newton,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 4,
				EnumId = "NewtonSec",
				Name = "",
				Description = "",
			}},
			{Id.PascalGram, new Item {
				DefinesVectorUnit = VectorUnit.Id.Pascal,
				RaisesVectorUnit = VectorUnit.Id.Gram,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Kilo,
				Id = 5,
				EnumId = "PascalGram",
				Name = "",
				Description = "",
			}},
			{Id.PascalMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Pascal,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = -1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 6,
				EnumId = "PascalMetre",
				Name = "",
				Description = "",
			}},
			{Id.PascalSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Pascal,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 7,
				EnumId = "PascalSec",
				Name = "",
				Description = "",
			}},
			{Id.JouleGram, new Item {
				DefinesVectorUnit = VectorUnit.Id.Joule,
				RaisesVectorUnit = VectorUnit.Id.Gram,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Kilo,
				Id = 8,
				EnumId = "JouleGram",
				Name = "",
				Description = "",
			}},
			{Id.JouleMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Joule,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 9,
				EnumId = "JouleMetre",
				Name = "",
				Description = "",
			}},
			{Id.JouleSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Joule,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 10,
				EnumId = "JouleSec",
				Name = "",
				Description = "",
			}},
			{Id.WattGram, new Item {
				DefinesVectorUnit = VectorUnit.Id.Watt,
				RaisesVectorUnit = VectorUnit.Id.Gram,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Kilo,
				Id = 11,
				EnumId = "WattGram",
				Name = "",
				Description = "",
			}},
			{Id.WattMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Watt,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 12,
				EnumId = "WattMetre",
				Name = "",
				Description = "",
			}},
			{Id.WattSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Watt,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -3,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 13,
				EnumId = "WattSec",
				Name = "",
				Description = "",
			}},
			{Id.VoltGram, new Item {
				DefinesVectorUnit = VectorUnit.Id.Volt,
				RaisesVectorUnit = VectorUnit.Id.Gram,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Kilo,
				Id = 14,
				EnumId = "VoltGram",
				Name = "",
				Description = "",
			}},
			{Id.VoltMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Volt,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 15,
				EnumId = "VoltMetre",
				Name = "",
				Description = "",
			}},
			{Id.VoltSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Volt,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -3,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 16,
				EnumId = "VoltSec",
				Name = "",
				Description = "",
			}},
			{Id.VoltAmp, new Item {
				DefinesVectorUnit = VectorUnit.Id.Volt,
				RaisesVectorUnit = VectorUnit.Id.Ampere,
				WithExponent = -1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 17,
				EnumId = "VoltAmp",
				Name = "",
				Description = "",
			}},
			{Id.OhmGram, new Item {
				DefinesVectorUnit = VectorUnit.Id.Ohm,
				RaisesVectorUnit = VectorUnit.Id.Gram,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Kilo,
				Id = 18,
				EnumId = "OhmGram",
				Name = "",
				Description = "",
			}},
			{Id.OhmMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Ohm,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 19,
				EnumId = "OhmMetre",
				Name = "",
				Description = "",
			}},
			{Id.OhmSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Ohm,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -3,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 20,
				EnumId = "OhmSec",
				Name = "",
				Description = "",
			}},
			{Id.OhmAmp, new Item {
				DefinesVectorUnit = VectorUnit.Id.Ohm,
				RaisesVectorUnit = VectorUnit.Id.Ampere,
				WithExponent = -2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 21,
				EnumId = "OhmAmp",
				Name = "",
				Description = "",
			}},
			{Id.AreaMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Area,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 22,
				EnumId = "AreaMetre",
				Name = "",
				Description = "",
			}},
			{Id.VolumeMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Volume,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 3,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 23,
				EnumId = "VolumeMetre",
				Name = "",
				Description = "",
			}},
			{Id.SpeedMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Speed,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 24,
				EnumId = "SpeedMetre",
				Name = "",
				Description = "",
			}},
			{Id.SpeedSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Speed,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 25,
				EnumId = "SpeedSec",
				Name = "",
				Description = "",
			}},
			{Id.AccelMetre, new Item {
				DefinesVectorUnit = VectorUnit.Id.Acceleration,
				RaisesVectorUnit = VectorUnit.Id.Metre,
				WithExponent = 1,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 26,
				EnumId = "AccelMetre",
				Name = "",
				Description = "",
			}},
			{Id.AccelSec, new Item {
				DefinesVectorUnit = VectorUnit.Id.Acceleration,
				RaisesVectorUnit = VectorUnit.Id.Second,
				WithExponent = -2,
				RaisesVectorUnitPrefix = VectorUnitPrefix.Id.Base,
				Id = 27,
				EnumId = "AccelSec",
				Name = "",
				Description = "",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VectorUnitPrefix : EnumObject {

		public enum Id : byte {
			Base = 1,
			Kilo, // 2
			Mega, // 3
			Giga, // 4
			Tera, // 5
			Peta, // 6
			Exa, // 7
			Milli, // 8
			Micro, // 9
			Nano, // 10
			Pico, // 11
			Femto, // 12
			Atto, // 13
			Kibi, // 14
			Mebi, // 15
			Gibi, // 16
			Tebi, // 17
			Pebi, // 18
			Exbi, // 19
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {

			public double Amount { get; set; }

		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Base, new Item {
				Amount = 1,
				Id = 1,
				EnumId = "Base",
				Name = "Base",
				Description = "",
			}},
			{Id.Kilo, new Item {
				Amount = 1000,
				Id = 2,
				EnumId = "Kilo",
				Name = "Kilo",
				Description = "k",
			}},
			{Id.Mega, new Item {
				Amount = 1000000,
				Id = 3,
				EnumId = "Mega",
				Name = "Mega",
				Description = "M",
			}},
			{Id.Giga, new Item {
				Amount = 1000000000,
				Id = 4,
				EnumId = "Giga",
				Name = "Giga",
				Description = "G",
			}},
			{Id.Tera, new Item {
				Amount = 1000000000000,
				Id = 5,
				EnumId = "Tera",
				Name = "Tera",
				Description = "T",
			}},
			{Id.Peta, new Item {
				Amount = 1E+15,
				Id = 6,
				EnumId = "Peta",
				Name = "Peta",
				Description = "P",
			}},
			{Id.Exa, new Item {
				Amount = 1E+18,
				Id = 7,
				EnumId = "Exa",
				Name = "Exa",
				Description = "E",
			}},
			{Id.Milli, new Item {
				Amount = 0.001,
				Id = 8,
				EnumId = "Milli",
				Name = "Milli",
				Description = "m",
			}},
			{Id.Micro, new Item {
				Amount = 1E-06,
				Id = 9,
				EnumId = "Micro",
				Name = "Micro",
				Description = "μ",
			}},
			{Id.Nano, new Item {
				Amount = 1E-09,
				Id = 10,
				EnumId = "Nano",
				Name = "Nano",
				Description = "n",
			}},
			{Id.Pico, new Item {
				Amount = 1E-12,
				Id = 11,
				EnumId = "Pico",
				Name = "Pico",
				Description = "p",
			}},
			{Id.Femto, new Item {
				Amount = 1E-15,
				Id = 12,
				EnumId = "Femto",
				Name = "Femto",
				Description = "f",
			}},
			{Id.Atto, new Item {
				Amount = 1E-18,
				Id = 13,
				EnumId = "Atto",
				Name = "Atto",
				Description = "a",
			}},
			{Id.Kibi, new Item {
				Amount = 1024,
				Id = 14,
				EnumId = "Kibi",
				Name = "Kibi",
				Description = "Ki",
			}},
			{Id.Mebi, new Item {
				Amount = 1048576,
				Id = 15,
				EnumId = "Mebi",
				Name = "Mebi",
				Description = "Mi",
			}},
			{Id.Gibi, new Item {
				Amount = 1073741824,
				Id = 16,
				EnumId = "Gibi",
				Name = "Gibi",
				Description = "Gi",
			}},
			{Id.Tebi, new Item {
				Amount = 1099511627776,
				Id = 17,
				EnumId = "Tebi",
				Name = "Tebi",
				Description = "Ti",
			}},
			{Id.Pebi, new Item {
				Amount = 1.12589990684262E+15,
				Id = 18,
				EnumId = "Pebi",
				Name = "Pebi",
				Description = "Pi",
			}},
			{Id.Exbi, new Item {
				Amount = 1.15292150460685E+18,
				Id = 19,
				EnumId = "Exbi",
				Name = "Exbi",
				Description = "Ei",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VectorUnit : EnumObject {

		public enum Id : byte {
			None = 1,
			Unit, // 2
			Metre, // 3
			Gram, // 4
			Second, // 5
			Ampere, // 6
			Celsius, // 7
			Candela, // 8
			Mole, // 9
			Bit, // 10
			Byte, // 11
			Hertz, // 12
			Radian, // 13
			Newton, // 14
			Pascal, // 15
			Joule, // 16
			Watt, // 17
			Volt, // 18
			Ohm, // 19
			Area, // 20
			Volume, // 21
			Speed, // 22
			Acceleration, // 23
			Point, // 24
			Item, // 25
			Person, // 26
			Percent, // 27
			Index, // 28
			Pixel, // 29
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.None, new Item {
				Id = 1,
				EnumId = "None",
				Name = "None",
				Description = "",
			}},
			{Id.Unit, new Item {
				Id = 2,
				EnumId = "Unit",
				Name = "Unit",
				Description = "",
			}},
			{Id.Metre, new Item {
				Id = 3,
				EnumId = "Metre",
				Name = "Metre",
				Description = "m",
			}},
			{Id.Gram, new Item {
				Id = 4,
				EnumId = "Gram",
				Name = "Gram",
				Description = "g",
			}},
			{Id.Second, new Item {
				Id = 5,
				EnumId = "Second",
				Name = "Second",
				Description = "s",
			}},
			{Id.Ampere, new Item {
				Id = 6,
				EnumId = "Ampere",
				Name = "Ampere",
				Description = "A",
			}},
			{Id.Celsius, new Item {
				Id = 7,
				EnumId = "Celsius",
				Name = "Celsius",
				Description = "C",
			}},
			{Id.Candela, new Item {
				Id = 8,
				EnumId = "Candela",
				Name = "Candela",
				Description = "cd",
			}},
			{Id.Mole, new Item {
				Id = 9,
				EnumId = "Mole",
				Name = "Mole",
				Description = "mol",
			}},
			{Id.Bit, new Item {
				Id = 10,
				EnumId = "Bit",
				Name = "Bit",
				Description = "b",
			}},
			{Id.Byte, new Item {
				Id = 11,
				EnumId = "Byte",
				Name = "Byte",
				Description = "B",
			}},
			{Id.Hertz, new Item {
				Id = 12,
				EnumId = "Hertz",
				Name = "Hertz",
				Description = "Hz",
			}},
			{Id.Radian, new Item {
				Id = 13,
				EnumId = "Radian",
				Name = "Radian",
				Description = "rad",
			}},
			{Id.Newton, new Item {
				Id = 14,
				EnumId = "Newton",
				Name = "Newton",
				Description = "N",
			}},
			{Id.Pascal, new Item {
				Id = 15,
				EnumId = "Pascal",
				Name = "Pascal",
				Description = "Pa",
			}},
			{Id.Joule, new Item {
				Id = 16,
				EnumId = "Joule",
				Name = "Joule",
				Description = "J",
			}},
			{Id.Watt, new Item {
				Id = 17,
				EnumId = "Watt",
				Name = "Watt",
				Description = "W",
			}},
			{Id.Volt, new Item {
				Id = 18,
				EnumId = "Volt",
				Name = "Volt",
				Description = "V",
			}},
			{Id.Ohm, new Item {
				Id = 19,
				EnumId = "Ohm",
				Name = "Ohm",
				Description = "Ω",
			}},
			{Id.Area, new Item {
				Id = 20,
				EnumId = "Area",
				Name = "Area",
				Description = "m^2",
			}},
			{Id.Volume, new Item {
				Id = 21,
				EnumId = "Volume",
				Name = "Volume",
				Description = "m^3",
			}},
			{Id.Speed, new Item {
				Id = 22,
				EnumId = "Speed",
				Name = "Speed",
				Description = "m/s",
			}},
			{Id.Acceleration, new Item {
				Id = 23,
				EnumId = "Acceleration",
				Name = "Acceleration",
				Description = "m^3/s",
			}},
			{Id.Point, new Item {
				Id = 24,
				EnumId = "Point",
				Name = "Point",
				Description = "pt",
			}},
			{Id.Item, new Item {
				Id = 25,
				EnumId = "Item",
				Name = "Item",
				Description = "item",
			}},
			{Id.Person, new Item {
				Id = 26,
				EnumId = "Person",
				Name = "Person",
				Description = "person",
			}},
			{Id.Percent, new Item {
				Id = 27,
				EnumId = "Percent",
				Name = "Percent",
				Description = "%",
			}},
			{Id.Index, new Item {
				Id = 28,
				EnumId = "Index",
				Name = "Index",
				Description = "index",
			}},
			{Id.Pixel, new Item {
				Id = 29,
				EnumId = "Pixel",
				Name = "Pixel",
				Description = "pixel",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}


	/*================================================================================================*/
	public class VertexType : EnumObject {

		public enum Id : byte {
			Vertex = 1,
			App, // 2
			Class, // 3
			Instance, // 4
			Url, // 5
			User, // 6
			Member, // 7
			Artifact, // 8
			Factor, // 9
			Email, // 10
			OauthAccess, // 11
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public class Item : EnumItem {


		}

		/*--------------------------------------------------------------------------------------------*/
		public readonly static IDictionary<Id, Item> Map = new Dictionary<Id, Item> {
			{Id.Vertex, new Item {
				Id = 1,
				EnumId = "Vertex",
				Name = "Vertex",
				Description = "",
			}},
			{Id.App, new Item {
				Id = 2,
				EnumId = "App",
				Name = "App",
				Description = "",
			}},
			{Id.Class, new Item {
				Id = 3,
				EnumId = "Class",
				Name = "Class",
				Description = "",
			}},
			{Id.Instance, new Item {
				Id = 4,
				EnumId = "Instance",
				Name = "Instance",
				Description = "",
			}},
			{Id.Url, new Item {
				Id = 5,
				EnumId = "Url",
				Name = "Url",
				Description = "",
			}},
			{Id.User, new Item {
				Id = 6,
				EnumId = "User",
				Name = "User",
				Description = "",
			}},
			{Id.Member, new Item {
				Id = 7,
				EnumId = "Member",
				Name = "Member",
				Description = "",
			}},
			{Id.Artifact, new Item {
				Id = 8,
				EnumId = "Artifact",
				Name = "Artifact",
				Description = "",
			}},
			{Id.Factor, new Item {
				Id = 9,
				EnumId = "Factor",
				Name = "Factor",
				Description = "",
			}},
			{Id.Email, new Item {
				Id = 10,
				EnumId = "Email",
				Name = "Email",
				Description = "",
			}},
			{Id.OauthAccess, new Item {
				Id = 11,
				EnumId = "OauthAccess",
				Name = "OauthAccess",
				Description = "",
			}},

		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override IList<EnumItem> ToList() {
			return Map.Values.Cast<EnumItem>().ToList();
		}
		
	}

}