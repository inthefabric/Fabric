namespace Fabric.New.Domain {

	/*================================================================================================*/
	public enum VertexDomainType : byte {
		Artifact = 0,
		Vertex = 0,
		//Skip = 1,
		App = 2,
		Class = 3,
		Instance = 4,
		Url = 5,
		User = 6,
		Member = 7,
		//Skip = 8,
		Factor = 9,
		Email = 10,
		OauthAccess = 11,
		OauthDomain = 12,
		OauthGrant = 13,
		OauthScope = 14,
	}

	/*================================================================================================*/
	public enum MemberType : byte {
		None = 1,
		Request,
		Invite,
		Member,
		Staff,
		Admin,
		Owner,
		DataProvider
	}

	/*================================================================================================*/
	public enum FactorDescriptorType {
		IsRelatedTo = 1,
		IsA,
		IsAnInstanceOf,
		HasA,
		IsLike,
		IsNotLike,

		RefersTo,
		IsCreatedBy,
		IsInterestedIn,
		Receives,
		Consumes,
		Produces,
		ParticipatesIn,
		IsFoundIn,
		BelongsTo,
		Requires,
		InteractsWith,

		LooksLike,
		SmellsLike,
		TastesLike,
		SoundsLike,
		FeelsLike,
		EmotesLike,

		Uses
	}

	/*================================================================================================*/
	public enum FactorDirectorAction {
		Read = 1,
		Listen,
		View,
		Consume,
		Perform,
		Produce,
		Destroy,
		Modify,
		Obtain,
		Locate,
		Travel,
		Become,
		Explain,
		Give,
		Learn,
		Start,
		Stop
	}

	/*================================================================================================*/
	public enum FactorDirectorType {
		Hyperlink = 1,
		DefinedPath,
		SuggestPath,
		AvoidPath,
		Causality
	}

	/*================================================================================================*/
	public enum FactorEventorType {
		Start = 1,
		End,
		Pause,
		Unpause,
		Continue,
		Occur,
		Expected
	}

	/*================================================================================================*/
	public enum FactorAssertionType {
		Undefined = 1,
		Fact,
		Opinion,
		Guess
	}

	/*================================================================================================*/
	public enum FactorIdentorType {
		Text = 1,
		Key
	}

	/*================================================================================================*/
	public enum FactorLocatorType {
		EarthCoord = 1,
		MoonCoord,
		MarsCoord,
		RelPos1D,
		RelPos2D,
		RelPos3D
	}

	/*================================================================================================*/
	public enum FactorVectorRange {
		FullNum = 1,
		PosNum,
		NegNum,
		FullAgree,
		PosAgree,
		FullFavor,
		PosFavor
	}

	/*================================================================================================*/
	public enum FactorVectorRangeLevel {
		Zero0 = 1,
		Zero05,
		Zero1,

		Min0,
		Max1,

		CompDisagree,
		MostDisagree,
		SomeDisagree,
		NoOpinion05,
		SomeAgree,
		MostAgree,
		CompAgree,

		NoOpinion0,
		SomeAgreePos,
		MostAgreePos,
		CompAgreePos,

		CompUnfavor,
		MostUnfavor,
		SomeUnfavor,
		SomeFavor,
		MostFavor,
		CompFavor,

		SomeFavorPos,
		MostFavorPos,
		CompFavorPos
	}

	/*================================================================================================*/
	public enum FactorVectorType {
		FullLong = 1,
		PosLong,
		NegLong,
		FullPerc,
		StdPerc,
		OppPerc,
		StdAgree,
		OppAgree,
		StdFavor,
		OppFavor
	}

	/*================================================================================================*/
	public enum FactorVectorUnit {
		None = 1,
		Unit,

		Metre,
		Gram,
		Second,
		Ampere,
		Celsius,
		Candela,
		Mole,
		Bit,
		Byte,

		Hertz,
		Radian,
		Newton,
		Pascal,
		Joule,
		Watt,
		Volt,
		Ohm,

		Area,
		Volume,
		Speed,
		Acceleration,

		Point,
		Item,
		Person,
		Percent,
		Index,
		Pixel
	}

	/*================================================================================================*/
	public enum FactorVectorUnitDerived {
		HertzSec = 1,
		NewtonGram,
		NewtonMetre,
		NewtonSec,
		PascalGram,
		PascalMetre,
		PascalSec,
		JouleGram,
		JouleMetre,
		JouleSec,
		WattGram,
		WattMetre,
		WattSec,
		VoltGram,
		VoltMetre,
		VoltSec,
		VoltAmp,
		OhmGram,
		OhmMetre,
		OhmSec,
		OhmAmp,
		AreaMetre,
		VolumeMetre,
		SpeedMetre,
		SpeedSec,
		AccelMetre,
		AccelSec
	}

	/*================================================================================================*/
	public enum FactorVectorUnitPrefix {
		Base = 1,

		Kilo,
		Mega,
		Giga,
		Tera,
		Peta,
		Exa,

		Milli,
		Micro,
		Nano,
		Pico,
		Femto,
		Atto,

		Kibi,
		Mebi,
		Gibi,
		Tebi,
		Pebi,
		Exbi
	}

}