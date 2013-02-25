﻿using System;

namespace Fabric.Infrastructure.Db {

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
		Class,
		Instance,
		Url
		//Label,
		//Crowd
	}

	/*================================================================================================* /
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
	public enum FactorAssertionId {
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
	public enum MemberId {
		FabFabData = 1
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
	public enum VectorRangeLevelId {
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
	public class VectorUnitPrefixConst {

		public const double Base = 1;

		public const double Kilo = 1E3;
		public const double Mega = 1E6;
		public const double Giga = 1E9;
		public const double Tera = 1E12;
		public const double Peta = 1E15;
		public const double Exa = 1E18;

		public const double Milli = 1E-3;
		public const double Micro = 1E-6;
		public const double Nano = 1E-9;
		public const double Pico = 1E-12;
		public const double Femto = 1E-15;
		public const double Atto = 1E-18;

		public const double Kibi = 1024;
		public const double Mebi = 1048576;
		public const double Gibi = 1073741824;
		public const double Tebi = 1099511627776;
		public const double Pebi = 1125899906842624;
		public const double Exbi = 1152921504606846976;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static double GetMult(long pUnitPrefixId) {
			switch ( pUnitPrefixId ) {
				case (long)VectorUnitPrefixId.Base: return VectorUnitPrefixConst.Base;
					
				case (long)VectorUnitPrefixId.Kilo: return VectorUnitPrefixConst.Kilo;
				case (long)VectorUnitPrefixId.Mega: return VectorUnitPrefixConst.Mega;
				case (long)VectorUnitPrefixId.Giga: return VectorUnitPrefixConst.Giga;
				case (long)VectorUnitPrefixId.Tera: return VectorUnitPrefixConst.Tera;
				case (long)VectorUnitPrefixId.Peta: return VectorUnitPrefixConst.Peta;
				case (long)VectorUnitPrefixId.Exa: return VectorUnitPrefixConst.Exa;
					
				case (long)VectorUnitPrefixId.Milli: return VectorUnitPrefixConst.Milli;
				case (long)VectorUnitPrefixId.Micro: return VectorUnitPrefixConst.Micro;
				case (long)VectorUnitPrefixId.Nano: return VectorUnitPrefixConst.Nano;
				case (long)VectorUnitPrefixId.Pico: return VectorUnitPrefixConst.Pico;
				case (long)VectorUnitPrefixId.Femto: return VectorUnitPrefixConst.Femto;
				case (long)VectorUnitPrefixId.Atto: return VectorUnitPrefixConst.Atto;
					
				case (long)VectorUnitPrefixId.Kibi: return VectorUnitPrefixConst.Kibi;
				case (long)VectorUnitPrefixId.Mebi: return VectorUnitPrefixConst.Mebi;
				case (long)VectorUnitPrefixId.Gibi: return VectorUnitPrefixConst.Gibi;
				case (long)VectorUnitPrefixId.Tebi: return VectorUnitPrefixConst.Tebi;
				case (long)VectorUnitPrefixId.Pebi: return VectorUnitPrefixConst.Pebi;
				case (long)VectorUnitPrefixId.Exbi: return VectorUnitPrefixConst.Exbi;
					
				default:
					throw new Exception("Unknown VectorUnitPrefixConst: "+pUnitPrefixId);
			}
		}

	}

}