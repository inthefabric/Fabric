﻿using Fabric.Domain.Schemas.Utils;

namespace Fabric.Domain.Schemas.Vertices {

	/*================================================================================================*/
	public class FactorSchema : VertexSchema {

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
			GetAccess = Access.All;
			CreateAccess = Access.All;
			DeleteAccess = Access.CreatorUserAndApp;
			IsAbstract = false;
			CustomCreate = true;

			////

			AssertionType = new DomainProperty<byte>("AssertionType", "f_at");

			IsDefining = new DomainProperty<bool>("IsDefining", "f_de");
			
			Note = new DomainProperty<string>("Note", "f_no");
			Note.IsNullable = true;

			DescriptorType = new DomainProperty<byte>("DescriptorType", "f_det");

			DirectorType = new DomainProperty<byte>("DirectorType", "f_dit");
			DirectorType.IsNullable = true;

			DirectorPrimaryAction = new DomainProperty<byte>("DirectorPrimaryAction", "f_dip");
			DirectorPrimaryAction.IsNullable = true;

			DirectorRelatedAction = new DomainProperty<byte>("DirectorRelatedAction", "f_dir");
			DirectorRelatedAction.IsNullable = true;

			EventorType = new DomainProperty<byte>("EventorType", "f_evt");
			EventorType.IsNullable = true;

			EventorDateTime = new DomainProperty<long>("EventorDateTime", "f_evd");
			EventorDateTime.IsNullable = true;

			IdentorType = new DomainProperty<byte>("IdentorType", "f_idt");
			IdentorType.IsNullable = true;

			IdentorValue = new DomainProperty<string>("IdentorValue", "f_idv");
			IdentorValue.IsNullable = true;
			IdentorValue.IsIndexed = true;
			IdentorValue.IsElastic = true;

			LocatorType = new DomainProperty<byte>("LocatorType", "f_lot");
			LocatorType.IsNullable = true;

			LocatorValueX = new DomainProperty<double>("LocatorValueX", "f_lox");
			LocatorValueX.IsNullable = true;

			LocatorValueY = new DomainProperty<double>("LocatorValueY", "f_loy");
			LocatorValueY.IsNullable = true;

			LocatorValueZ = new DomainProperty<double>("LocatorValueZ", "f_loz");
			LocatorValueZ.IsNullable = true;

			VectorType = new DomainProperty<byte>("VectorType", "f_vet");
			VectorType.IsNullable = true;

			VectorUnit = new DomainProperty<byte>("VectorUnit", "f_veu");
			VectorUnit.IsNullable = true;

			VectorUnitPrefix = new DomainProperty<byte>("VectorUnitPrefix", "f_vep");
			VectorUnitPrefix.IsNullable = true;

			VectorValue = new DomainProperty<long>("VectorValue", "f_vev");
			VectorValue.IsNullable = true;

			////

			FabAssertionType = new ApiProperty<byte>("AssertionType");
			FabAssertionType.SetOpenUnmodAccess();
			FabAssertionType.FromEnum = "FactorAssertion";

			FabIsDefining = new ApiProperty<bool>("IsDefining");
			FabIsDefining.SetOpenUnmodAccess();

			FabNote = new ApiProperty<string>("Note");
			FabNote.SetOpenUnmodAccess();
			FabNote.IsNullable = true;
			FabNote.LenMin = 1;
			FabNote.LenMax = 256;
			FabNote.TraversalHas = Matching.None;

			FabDescriptorType = new ApiProperty<byte>("Type");
			FabDescriptorType.SetOpenUnmodAccess();
			FabDescriptorType.SubObjectOf = "FabDescriptor";
			FabDescriptorType.FromEnum = "DescriptorType";

			FabDirectorType = new ApiProperty<byte>("Type");
			FabDirectorType.SetOpenUnmodAccess();
			FabDirectorType.SubObjectOf = "FabDirector";
			FabDirectorType.FromEnum = "DirectorType";

			FabDirectorPrimaryAction = new ApiProperty<byte>("PrimaryAction");
			FabDirectorPrimaryAction.SetOpenUnmodAccess();
			FabDirectorPrimaryAction.SubObjectOf = "FabDirector";
			FabDirectorPrimaryAction.FromEnum = "DirectorAction";

			FabDirectorRelatedAction = new ApiProperty<byte>("RelatedAction");
			FabDirectorRelatedAction.SetOpenUnmodAccess();
			FabDirectorRelatedAction.SubObjectOf = "FabDirector";
			FabDirectorRelatedAction.FromEnum = "DirectorAction";

			FabEventorType = new ApiProperty<byte>("Type");
			FabEventorType.SetOpenUnmodAccess();
			FabEventorType.SubObjectOf = "FabEventor";
			FabEventorType.FromEnum = "EventorType";

			FabEventorYear = new ApiProperty<long>("Year");
			FabEventorYear.SetOpenUnmodAccess();
			FabEventorYear.SubObjectOf = "FabEventor";
			FabEventorYear.Min = -100000000000;
			FabEventorYear.Max = 100000000000;
			FabEventorYear.CustomValidation = true;
			FabEventorYear.TraversalHas = Matching.Custom;

			FabEventorMonth = new ApiProperty<byte>("Month");
			FabEventorMonth.SetOpenUnmodAccess();
			FabEventorMonth.SubObjectOf = "FabEventor";
			FabEventorMonth.IsNullable = true;
			FabEventorMonth.Min = 1;
			FabEventorMonth.Max = 12;
			FabEventorMonth.TraversalHas = Matching.Custom;

			FabEventorDay = new ApiProperty<byte>("Day");
			FabEventorDay.SetOpenUnmodAccess();
			FabEventorDay.SubObjectOf = "FabEventor";
			FabEventorDay.IsNullable = true;
			FabEventorDay.Min = 0;
			FabEventorDay.Max = 31;
			FabEventorDay.TraversalHas = Matching.Custom;

			FabEventorHour = new ApiProperty<byte>("Hour");
			FabEventorHour.SetOpenUnmodAccess();
			FabEventorHour.SubObjectOf = "FabEventor";
			FabEventorHour.IsNullable = true;
			FabEventorHour.Min = 0;
			FabEventorHour.Max = 23;
			FabEventorHour.TraversalHas = Matching.Custom;

			FabEventorMinute = new ApiProperty<byte>("Minute");
			FabEventorMinute.SetOpenUnmodAccess();
			FabEventorMinute.SubObjectOf = "FabEventor";
			FabEventorMinute.IsNullable = true;
			FabEventorMinute.Min = 0;
			FabEventorMinute.Max = 59;
			FabEventorMinute.TraversalHas = Matching.Custom;

			FabEventorSecond = new ApiProperty<byte>("Second");
			FabEventorSecond.SetOpenUnmodAccess();
			FabEventorSecond.SubObjectOf = "FabEventor";
			FabEventorSecond.IsNullable = true;
			FabEventorSecond.Min = 0;
			FabEventorSecond.Max = 59;
			FabEventorSecond.TraversalHas = Matching.Custom;

			FabIdentorType = new ApiProperty<byte>("Type");
			FabIdentorType.SetOpenUnmodAccess();
			FabIdentorType.SubObjectOf = "FabIdentor";
			FabIdentorType.FromEnum = "IdentorType";

			FabIdentorValue = new ApiProperty<string>("Value");
			FabIdentorValue.SetOpenUnmodAccess();
			FabIdentorValue.SubObjectOf = "FabIdentor";
			FabIdentorValue.IsNullable = true;
			FabIdentorValue.LenMin = 1;
			FabIdentorValue.LenMax = 256;

			FabLocatorType = new ApiProperty<byte>("Type");
			FabLocatorType.SetOpenUnmodAccess();
			FabLocatorType.SubObjectOf = "FabLocator";
			FabLocatorType.FromEnum = "LocatorType";

			FabLocatorValueX = new ApiProperty<double>("ValueX");
			FabLocatorValueX.SetOpenUnmodAccess();
			FabLocatorValueX.SubObjectOf = "FabLocator";
			FabLocatorValueX.CustomValidation = true;

			FabLocatorValueY = new ApiProperty<double>("ValueY");
			FabLocatorValueY.SetOpenUnmodAccess();
			FabLocatorValueY.SubObjectOf = "FabLocator";
			FabLocatorValueY.CustomValidation = true;

			FabLocatorValueZ = new ApiProperty<double>("ValueZ");
			FabLocatorValueZ.SetOpenUnmodAccess();
			FabLocatorValueZ.SubObjectOf = "FabLocator";
			FabLocatorValueZ.CustomValidation = true;

			FabVectorType = new ApiProperty<byte>("Type");
			FabVectorType.SetOpenUnmodAccess();
			FabVectorType.SubObjectOf = "FabVector";
			FabVectorType.FromEnum = "VectorType";

			FabVectorUnit = new ApiProperty<byte>("Unit");
			FabVectorUnit.SetOpenUnmodAccess();
			FabVectorUnit.SubObjectOf = "FabVector";
			FabVectorUnit.FromEnum = "VectorUnit";

			FabVectorUnitPrefix = new ApiProperty<byte>("UnitPrefix");
			FabVectorUnitPrefix.SetOpenUnmodAccess();
			FabVectorUnitPrefix.SubObjectOf = "FabVector";
			FabVectorUnitPrefix.FromEnum = "VectorUnitPrefix";

			FabVectorValue = new ApiProperty<long>("Value");
			FabVectorValue.SetOpenUnmodAccess();
			FabVectorValue.SubObjectOf = "FabVector";
			FabVectorValue.CustomValidation = true;

			////

			FabAssertionTypeMap = new PropertyMapping<byte, byte>(AssertionType, FabAssertionType);
			FabIsDefiningMap = new PropertyMapping<bool, bool>(IsDefining, FabIsDefining);
			FabNoteMap = new PropertyMapping<string, string>(Note, FabNote);
			FabDescriptorTypeMap = new PropertyMapping<byte, byte>(DescriptorType, FabDescriptorType);
			FabDirectorTypeMap = new PropertyMapping<byte, byte>(DirectorType, FabDirectorType);
			FabDirectorPrimaryActionMap = new PropertyMapping<byte, byte>(
				DirectorPrimaryAction, FabDirectorPrimaryAction);
			FabDirectorRelatedActionMap = new PropertyMapping<byte, byte>(
				DirectorRelatedAction, FabDirectorRelatedAction);
			FabEventorTypeMap = new PropertyMapping<byte, byte>(EventorType, FabEventorType);
			FabEventorYearMap = new PropertyMapping<long, long>(EventorDateTime, FabEventorYear,
				CustomDir.Both);
			FabEventorYearMap.ApiToDomainNote = "Set Domain.EventorDateTime using Api.Year/Month/etc.";
			FabEventorYearMap.DomainToApiNote = "Set Api.Year/Momth/etc. using Domain.EventorDateTime.";
			FabEventorMonthMap = new PropertyMapping<long, byte>(
				EventorDateTime, FabEventorMonth, CustomDir.Both);
			FabEventorDayMap = new PropertyMapping<long, byte>(
				EventorDateTime, FabEventorDay, CustomDir.Both);
			FabEventorHourMap = new PropertyMapping<long, byte>(
				EventorDateTime, FabEventorHour, CustomDir.Both);
			FabEventorMinuteMap = new PropertyMapping<long, byte>(
				EventorDateTime, FabEventorMinute, CustomDir.Both);
			FabEventorSecondMap = new PropertyMapping<long, byte>(
				EventorDateTime, FabEventorSecond, CustomDir.Both);
			FabIdentorTypeMap = new PropertyMapping<byte, byte>(IdentorType, FabIdentorType);
			FabIdentorValueMap = new PropertyMapping<string, string>(IdentorValue, FabIdentorValue);
			FabLocatorTypeMap = new PropertyMapping<byte, byte>(LocatorType, FabLocatorType);
			FabLocatorValueXMap = new PropertyMapping<double, double>(LocatorValueX, FabLocatorValueX);
			FabLocatorValueYMap = new PropertyMapping<double, double>(LocatorValueY, FabLocatorValueY);
			FabLocatorValueZMap = new PropertyMapping<double, double>(LocatorValueZ, FabLocatorValueZ);
			FabVectorTypeMap = new PropertyMapping<byte, byte>(VectorType, FabVectorType);
			FabVectorUnitMap = new PropertyMapping<byte, byte>(VectorUnit, FabVectorUnit);
			FabVectorUnitPrefixMap = new PropertyMapping<byte, byte>(
				VectorUnitPrefix, FabVectorUnitPrefix);
			FabVectorValueMap = new PropertyMapping<long, long>(VectorValue, FabVectorValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override bool IsSubObjectNullable(string pName) {
			return (pName != "FabDescriptor");
		}

	}

}