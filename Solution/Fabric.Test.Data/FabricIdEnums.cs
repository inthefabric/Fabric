namespace Fabric.Db.Data {

	/*================================================================================================*/
	public enum AppId {
		FabricSystem = 1
	}

	/*================================================================================================*/
	public enum UserId {
		Fabric = 1
	}

	/*================================================================================================*/
	public enum ArtifactTypeId {
		App = 1,
		User,
		Thing,
		Url,
		Label,
		Crowd
	}

	/*================================================================================================*/
	public enum CrowdianTypeId {
		None = 1,
		Request,
		Invite,
		Member,
		Admin
	}

	/*================================================================================================*/
	public enum DescriptorTypeId {
		IsRelatedTo = 1,
		IsA,
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

		LooksLike,
		SmellsLike,
		TastesLike,
		SoundsLike,
		FeelsLike,
		EmotesLike
	}

	/*================================================================================================*/
	public enum DirectorActionId {
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
	public enum DirectorTypeId {
		Hyperlink = 1,
		DefinedPath,
		SuggestPath,
		AvoidPath,
		Causality
	}

	/*================================================================================================*/
	public enum EventorPrecisionId {
		Year = 1,
		Month,
		Day,
		Hour,
		Minute,
		Second
	}

	/*================================================================================================*/
	public enum EventorTypeId {
		Start = 1,
		End,
		Pause,
		Unpause,
		Continue,
		Occur,
		Expected
	}

	/*================================================================================================*/
	public enum FactorAccessId {
		Standard = 1,
		Public
	}

	/*================================================================================================*/
	public enum FactorAssertId {
		Undefined = 1,
		Fact,
		Opinion,
		Guess
	}
	
	/*================================================================================================*/
	public enum IdentorTypeId {
		Text = 1,
		Key
	}

	/*================================================================================================*/
	public enum LocatorTypeId {
		EarthCoord = 1,
		MoonCoord,
		MarsCoord,
		RelPos1D,
		RelPos2D,
		RelPos3D
	}

	/*================================================================================================*/
	public enum MemberTypeId {
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
	public enum VectorRangeId {
		FullNum = 1,
		PosNum,
		NegNum,
		FullAgree,
		PosAgree,
		FullFavor,
		PosFavor
	}

	/*================================================================================================*/
	public enum VectorTypeId {
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
	public enum VectorUnitId {
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
		Index
	}

	/*================================================================================================*/
	public enum VectorUnitDerivedId {
		HertzSec = 1,
		NewtonGram,
		NewTonMetre,
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
	public enum VectorUnitPrefixId {
		Base = 1,

		Kilo,
		Mega,
		Giga,
		Tera,
		Peta,
		Exa,
		//Zetta,
		//Yotta,

		Milli,
		Micro,
		Nano,
		Pico,
		Femto,
		Atto,
		//Zepto,
		//Yocto,

		Kibi,
		Mebi,
		Gibi,
		Tebi,
		Pebi,
		Exbi,
		//Zebi,
		//Yobi
	}

}