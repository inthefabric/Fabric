using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {

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

	/*================================================================================================*/
	public class FactorSchema : ArtifactSchema {

		public DomainProperty<byte> AssertionType { get; private set; }
		public DomainProperty<bool> IsDefining { get; private set; }
		public DomainProperty<string> Note { get; private set; }
		public DomainProperty<byte> DescriptorType { get; private set; }
		public DomainProperty<byte> DirectorType { get; private set; }
		public DomainProperty<byte> DirectorPrimaryAction { get; private set; }
		public DomainProperty<byte> DirectorRelatedAction { get; private set; }
		public DomainProperty<byte> EventorType { get; private set; }
		public DomainProperty<long> EventorDateTime { get; private set; }
		public DomainProperty<byte> IdentorType { get; private set; }
		public DomainProperty<string> IdentorValue { get; private set; }
		public DomainProperty<byte> LocatorType { get; private set; }
		public DomainProperty<double> LocatorValueX { get; private set; }
		public DomainProperty<double> LocatorValueY { get; private set; }
		public DomainProperty<double> LocatorValueZ { get; private set; }
		public DomainProperty<byte> VectorType { get; private set; }
		public DomainProperty<byte> VectorUnit { get; private set; }
		public DomainProperty<byte> VectorUnitPrefix { get; private set; }
		public DomainProperty<long> VectorValue { get; private set; }

		public ApiProperty<byte> FabAssertionType { get; private set; }
		public ApiProperty<bool> FabIsDefining { get; private set; }
		public ApiProperty<string> FabNote { get; private set; }
		public ApiProperty<byte> FabDescriptorType { get; private set; }
		public ApiProperty<byte> FabDirectorType { get; private set; }
		public ApiProperty<byte> FabDirectorPrimaryAction { get; private set; }
		public ApiProperty<byte> FabDirectorRelatedAction { get; private set; }
		public ApiProperty<byte> FabEventorType { get; private set; }
		public ApiProperty<long> FabEventorYear { get; private set; }
		public ApiProperty<byte> FabEventorMonth { get; private set; }
		public ApiProperty<byte> FabEventorDay { get; private set; }
		public ApiProperty<byte> FabEventorHour { get; private set; }
		public ApiProperty<byte> FabEventorMinute { get; private set; }
		public ApiProperty<byte> FabEventorSecond { get; private set; }
		public ApiProperty<byte> FabIdentorType { get; private set; }
		public ApiProperty<string> FabIdentorValue { get; private set; }
		public ApiProperty<byte> FabLocatorType { get; private set; }
		public ApiProperty<double> FabLocatorValueX { get; private set; }
		public ApiProperty<double> FabLocatorValueY { get; private set; }
		public ApiProperty<double> FabLocatorValueZ { get; private set; }
		public ApiProperty<byte> FabVectorType { get; private set; }
		public ApiProperty<byte> FabVectorUnit { get; private set; }
		public ApiProperty<byte> FabVectorUnitPrefix { get; private set; }
		public ApiProperty<long> FabVectorValue { get; private set; }

		public PropertyMapping<byte, byte> FabAssertionTypeMap { get; private set; }
		public PropertyMapping<bool, bool> FabIsDefiningMap { get; private set; }
		public PropertyMapping<string, string> FabNoteMap { get; private set; }
		public PropertyMapping<byte, byte> FabDescriptorTypeMap { get; private set; }
		public PropertyMapping<byte, byte> FabDirectorTypeMap { get; private set; }
		public PropertyMapping<byte, byte> FabDirectorPrimaryActionMap { get; private set; }
		public PropertyMapping<byte, byte> FabDirectorRelatedActionMap { get; private set; }
		public PropertyMapping<byte, byte> FabEventorTypeMap { get; private set; }
		public PropertyMapping<long, long> FabEventorYearMap { get; private set; }
		public PropertyMapping<long, byte> FabEventorMonthMap { get; private set; }
		public PropertyMapping<long, byte> FabEventorDayMap { get; private set; }
		public PropertyMapping<long, byte> FabEventorHourMap { get; private set; }
		public PropertyMapping<long, byte> FabEventorMinuteMap { get; private set; }
		public PropertyMapping<long, byte> FabEventorSecondMap { get; private set; }
		public PropertyMapping<byte, byte> FabIdentorTypeMap { get; private set; }
		public PropertyMapping<string, string> FabIdentorValueMap { get; private set; }
		public PropertyMapping<byte, byte> FabLocatorTypeMap { get; private set; }
		public PropertyMapping<double, double> FabLocatorValueXMap { get; private set; }
		public PropertyMapping<double, double> FabLocatorValueYMap { get; private set; }
		public PropertyMapping<double, double> FabLocatorValueZMap { get; private set; }
		public PropertyMapping<byte, byte> FabVectorTypeMap { get; private set; }
		public PropertyMapping<byte, byte> FabVectorUnitMap { get; private set; }
		public PropertyMapping<byte, byte> FabVectorUnitPrefixMap { get; private set; }
		public PropertyMapping<long, long> FabVectorValueMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorSchema() {
			Names = new NameProvider("Factor", "Factors", "f");

			Actions.Add = new ActionAccess();
			Actions.Delete = new ActionAccess { Creator = true, AppDataProvider = true };

			////

			AssertionType = new DomainProperty<byte>("AssertionType", "f.at");

			IsDefining = new DomainProperty<bool>("IsDefining", "f.de");
			
			Note = new DomainProperty<string>("Note", "f.no");

			DescriptorType = new DomainProperty<byte>("DescriptorType", "f.det");
			DescriptorType.IsNullable = true;

			DirectorType = new DomainProperty<byte>("DirectorType", "f.dit");
			DirectorType.IsNullable = true;

			DirectorPrimaryAction = new DomainProperty<byte>("DirectorPrimaryAction", "f.dip");
			DirectorPrimaryAction.IsNullable = true;

			DirectorRelatedAction = new DomainProperty<byte>("DirectorRelatedAction", "f.dir");
			DirectorRelatedAction.IsNullable = true;

			EventorType = new DomainProperty<byte>("EventorType", "f.evt");
			EventorType.IsNullable = true;

			EventorDateTime = new DomainProperty<long>("EventorDateTime", "f.evd");
			EventorDateTime.IsNullable = true;

			IdentorType = new DomainProperty<byte>("IdentorType", "f.idt");
			IdentorType.IsNullable = true;

			IdentorValue = new DomainProperty<string>("IdentorValue", "f.idv");
			IdentorValue.IsNullable = true;
			IdentorValue.IsIndexed = true;
			IdentorValue.IsElastic = true;

			LocatorType = new DomainProperty<byte>("LocatorType", "f.lot");
			LocatorType.IsNullable = true;

			LocatorValueX = new DomainProperty<double>("LocatorValueX", "f.lox");
			LocatorValueX.IsNullable = true;

			LocatorValueY = new DomainProperty<double>("LocatorValueY", "f.loy");
			LocatorValueY.IsNullable = true;

			LocatorValueZ = new DomainProperty<double>("LocatorValueZ", "f.loz");
			LocatorValueZ.IsNullable = true;

			VectorType = new DomainProperty<byte>("VectorType", "f.vet");
			VectorType.IsNullable = true;

			VectorUnit = new DomainProperty<byte>("VectorUnit", "f.veu");
			VectorUnit.IsNullable = true;

			VectorUnitPrefix = new DomainProperty<byte>("VectorUnitPrefix", "f.vep");
			VectorUnitPrefix.IsNullable = true;

			VectorValue = new DomainProperty<long>("VectorValue", "f.vev");
			VectorValue.IsNullable = true;

			////

			FabAssertionType = new ApiProperty<byte>("AssertionType", true, false);
			FabAssertionType.FromEnum = typeof(FactorAssertionType);

			FabIsDefining = new ApiProperty<bool>("IsDefining", true, false);

			FabNote = new ApiProperty<string>("Note", true, false);
			FabNote.IsNullable = true;
			FabNote.LenMin = 1;
			FabNote.LenMax = 256;

			FabDescriptorType = new ApiProperty<byte>("DescriptorType", true, false);
			FabDescriptorType.SubObjectOf = "FabDescriptor";
			FabDescriptorType.FromEnum = typeof(FactorDescriptorType);

			FabDirectorType = new ApiProperty<byte>("DirectorType", true, false);
			FabDirectorType.SubObjectOf = "FabDirector";
			FabDirectorType.FromEnum = typeof(FactorDirectorType);

			FabDirectorPrimaryAction = new ApiProperty<byte>("PrimaryAction", true, false);
			FabDirectorPrimaryAction.SubObjectOf = "FabDirector";
			FabDirectorPrimaryAction.FromEnum = typeof(FactorDirectorAction);

			FabDirectorRelatedAction = new ApiProperty<byte>("RelatedAction", true, false);
			FabDirectorRelatedAction.SubObjectOf = "FabDirector";
			FabDirectorRelatedAction.FromEnum = typeof(FactorDirectorAction);

			FabEventorType = new ApiProperty<byte>("EventorType", true, false);
			FabEventorType.SubObjectOf = "FabEventor";
			FabEventorType.FromEnum = typeof(FactorEventorType);

			FabEventorYear = new ApiProperty<long>("Year", true, false);
			FabEventorYear.SubObjectOf = "FabEventor";

			FabEventorMonth = new ApiProperty<byte>("Month", true, false);
			FabEventorMonth.SubObjectOf = "FabEventor";
			FabEventorMonth.IsNullable = true;

			FabEventorDay = new ApiProperty<byte>("Day", true, false);
			FabEventorDay.SubObjectOf = "FabEventor";
			FabEventorDay.IsNullable = true;

			FabEventorHour = new ApiProperty<byte>("Hour", true, false);
			FabEventorHour.SubObjectOf = "FabEventor";
			FabEventorHour.IsNullable = true;

			FabEventorMinute = new ApiProperty<byte>("Minute", true, false);
			FabEventorMinute.SubObjectOf = "FabEventor";
			FabEventorMinute.IsNullable = true;

			FabEventorSecond = new ApiProperty<byte>("Second", true, false);
			FabEventorSecond.SubObjectOf = "FabEventor";
			FabEventorSecond.IsNullable = true;

			FabIdentorType = new ApiProperty<byte>("IdentorType", true, false);
			FabIdentorType.SubObjectOf = "FabIdentor";
			FabIdentorType.FromEnum = typeof(FactorIdentorType);

			FabIdentorValue = new ApiProperty<string>("Value", true, false);
			FabIdentorValue.SubObjectOf = "FabIdentor";
			FabIdentorValue.IsNullable = true;
			FabIdentorValue.LenMin = 1;
			FabIdentorValue.LenMax = 256;

			FabLocatorType = new ApiProperty<byte>("LocatorType", true, false);
			FabLocatorType.SubObjectOf = "FabLocator";
			FabLocatorType.FromEnum = typeof(FactorLocatorType);

			FabLocatorValueX = new ApiProperty<double>("ValueX", true, false);
			FabLocatorValueX.SubObjectOf = "FabLocator";

			FabLocatorValueY = new ApiProperty<double>("ValueY", true, false);
			FabLocatorValueY.SubObjectOf = "FabLocator";

			FabLocatorValueZ = new ApiProperty<double>("ValueZ", true, false);
			FabLocatorValueZ.SubObjectOf = "FabLocator";

			FabVectorType = new ApiProperty<byte>("VectorType", true, false);
			FabVectorType.SubObjectOf = "FabVector";
			FabVectorType.FromEnum = typeof(FactorVectorType);

			FabVectorUnit = new ApiProperty<byte>("Unit", true, false);
			FabVectorUnit.SubObjectOf = "FabVector";
			FabVectorUnit.FromEnum = typeof(FactorVectorUnit);

			FabVectorUnitPrefix = new ApiProperty<byte>("UnitPrefix", true, false);
			FabVectorUnitPrefix.SubObjectOf = "FabVector";
			FabVectorUnitPrefix.FromEnum = typeof(FactorVectorUnitPrefix);

			FabVectorValue = new ApiProperty<long>("Value", true, false);
			FabVectorValue.SubObjectOf = "FabVector";

			////

			FabAssertionTypeMap = new PropertyMapping<byte, byte>(AssertionType, FabAssertionType);
			FabIsDefiningMap = new PropertyMapping<bool, bool>(IsDefining, FabIsDefining);
			FabNoteMap = new PropertyMapping<string, string>(Note, FabNote);
			FabDescriptorTypeMap = new PropertyMapping<byte, byte>(DescriptorType, FabDescriptorType);
			FabDirectorTypeMap = new PropertyMapping<byte, byte>(DirectorType, FabDirectorType);
			FabDirectorPrimaryActionMap = new PropertyMapping<byte, byte>(DirectorPrimaryAction, FabDirectorPrimaryAction);
			FabDirectorRelatedActionMap = new PropertyMapping<byte, byte>(DirectorRelatedAction, FabDirectorRelatedAction);
			FabEventorTypeMap = new PropertyMapping<byte, byte>(EventorType, FabEventorType);
			FabEventorYearMap = new PropertyMapping<long, long>(EventorDateTime, FabEventorYear, true);
			FabEventorMonthMap = new PropertyMapping<long, byte>(EventorDateTime, FabEventorMonth, true);
			FabEventorDayMap = new PropertyMapping<long, byte>(EventorDateTime, FabEventorDay, true);
			FabEventorHourMap = new PropertyMapping<long, byte>(EventorDateTime, FabEventorHour, true);
			FabEventorMinuteMap = new PropertyMapping<long, byte>(EventorDateTime, FabEventorMinute, true);
			FabEventorSecondMap = new PropertyMapping<long, byte>(EventorDateTime, FabEventorSecond, true);
			FabIdentorTypeMap = new PropertyMapping<byte, byte>(IdentorType, FabIdentorType);
			FabIdentorValueMap = new PropertyMapping<string, string>(Note, FabIdentorValue);
			FabLocatorTypeMap = new PropertyMapping<byte, byte>(LocatorType, FabLocatorType);
			FabLocatorValueXMap = new PropertyMapping<double, double>(LocatorValueX, FabLocatorValueX);
			FabLocatorValueYMap = new PropertyMapping<double, double>(LocatorValueY, FabLocatorValueY);
			FabLocatorValueZMap = new PropertyMapping<double, double>(LocatorValueZ, FabLocatorValueZ);
			FabVectorTypeMap = new PropertyMapping<byte, byte>(VectorType, FabVectorType);
			FabVectorUnitMap = new PropertyMapping<byte, byte>(VectorUnit, FabVectorUnit);
			FabVectorUnitPrefixMap = new PropertyMapping<byte, byte>(VectorUnitPrefix, FabVectorUnitPrefix);
			FabVectorValueMap = new PropertyMapping<long, long>(VectorValue, FabVectorValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override bool IsSubObjectNullable(string pName) {
			return (pName != "FabDescriptor");
		}

	}

}