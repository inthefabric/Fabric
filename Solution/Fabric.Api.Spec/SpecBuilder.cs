// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 2/5/2013 10:25:50 PM

using Fabric.Api.Dto.Spec;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public static class SpecBuilder {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecValue(string pTypeName, string pPropName, FabSpecValue pValue) {
			switch ( pTypeName+"."+pPropName ) {

				case "NodeForType.Name":
					pValue.LenMax = 32;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "NodeForType.Description":
					pValue.LenMax = 256;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "NodeForAction.Performed":
					break;

				case "NodeForAction.Note":
					pValue.LenMax = 256;
					break;

				case "Root.RootId":
					pValue.Min = 1;
					break;

				case "App.AppId":
					pValue.Min = 1;
					break;

				case "App.Name":
					pValue.LenMax = 64;
					pValue.LenMin = 3;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Artifact.ArtifactId":
					pValue.Min = 1;
					break;

				case "Artifact.IsPrivate":
					break;

				case "Artifact.Created":
					break;

				case "ArtifactType.ArtifactTypeId":
					pValue.Min = 1;
					break;

				case "Class.ClassId":
					pValue.Min = 1;
					break;

				case "Class.Name":
					pValue.LenMax = 128;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Class.Disamb":
					pValue.LenMax = 128;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Class.Note":
					pValue.LenMax = 256;
					break;

				case "Instance.InstanceId":
					pValue.Min = 1;
					break;

				case "Instance.Name":
					pValue.LenMax = 128;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Instance.Disamb":
					pValue.LenMax = 128;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Instance.Note":
					pValue.LenMax = 256;
					break;

				case "Member.MemberId":
					pValue.Min = 1;
					break;

				case "MemberType.MemberTypeId":
					pValue.Min = 1;
					break;

				case "MemberTypeAssign.MemberTypeAssignId":
					pValue.Min = 1;
					break;

				case "Url.UrlId":
					pValue.Min = 1;
					break;

				case "Url.Name":
					pValue.LenMax = 128;
					break;

				case "Url.AbsoluteUrl":
					pValue.LenMax = 2048;
					break;

				case "User.UserId":
					pValue.Min = 1;
					break;

				case "User.Name":
					pValue.LenMax = 16;
					pValue.LenMin = 4;
					pValue.ValidRegex = @"^[a-zA-Z0-9_]*$";
					break;

				case "Factor.FactorId":
					pValue.Min = 1;
					break;

				case "Factor.IsDefining":
					break;

				case "Factor.Created":
					break;

				case "Factor.Completed":
					break;

				case "Factor.Note":
					pValue.LenMax = 256;
					break;

				case "FactorAssertion.FactorAssertionId":
					pValue.Min = 1;
					break;

				case "Descriptor.DescriptorId":
					pValue.Min = 1;
					break;

				case "DescriptorType.DescriptorTypeId":
					pValue.Min = 1;
					break;

				case "Director.DirectorId":
					pValue.Min = 1;
					break;

				case "DirectorType.DirectorTypeId":
					pValue.Min = 1;
					break;

				case "DirectorAction.DirectorActionId":
					pValue.Min = 1;
					break;

				case "Eventor.EventorId":
					pValue.Min = 1;
					break;

				case "Eventor.DateTime":
					break;

				case "EventorType.EventorTypeId":
					pValue.Min = 1;
					break;

				case "EventorPrecision.EventorPrecisionId":
					pValue.Min = 1;
					break;

				case "Identor.IdentorId":
					pValue.Min = 1;
					break;

				case "Identor.Value":
					pValue.LenMax = 128;
					break;

				case "IdentorType.IdentorTypeId":
					pValue.Min = 1;
					break;

				case "Locator.LocatorId":
					pValue.Min = 1;
					break;

				case "Locator.ValueX":
					break;

				case "Locator.ValueY":
					break;

				case "Locator.ValueZ":
					break;

				case "LocatorType.LocatorTypeId":
					pValue.Min = 1;
					break;

				case "LocatorType.MinX":
					break;

				case "LocatorType.MaxX":
					break;

				case "LocatorType.MinY":
					break;

				case "LocatorType.MaxY":
					break;

				case "LocatorType.MinZ":
					break;

				case "LocatorType.MaxZ":
					break;

				case "Vector.VectorId":
					pValue.Min = 1;
					break;

				case "Vector.Value":
					break;

				case "VectorType.VectorTypeId":
					pValue.Min = 1;
					break;

				case "VectorType.Min":
					break;

				case "VectorType.Max":
					break;

				case "VectorRange.VectorRangeId":
					pValue.Min = 1;
					break;

				case "VectorRangeLevel.VectorRangeLevelId":
					pValue.Min = 1;
					break;

				case "VectorRangeLevel.Position":
					break;

				case "VectorUnit.VectorUnitId":
					pValue.Min = 1;
					break;

				case "VectorUnit.Symbol":
					pValue.LenMax = 8;
					break;

				case "VectorUnitPrefix.VectorUnitPrefixId":
					pValue.Min = 1;
					break;

				case "VectorUnitPrefix.Symbol":
					pValue.LenMax = 8;
					break;

				case "VectorUnitPrefix.Amount":
					break;

				case "VectorUnitDerived.VectorUnitDerivedId":
					pValue.Min = 1;
					break;

				case "VectorUnitDerived.Exponent":
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecDtoProp(string pTypeName, string pPropName, FabSpecDtoProp pProp) {
			FillSpecValue(pTypeName, pPropName, pProp);

			switch ( pTypeName+"."+pPropName ) {

				case "NodeForType.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("NodeForType_Name");
					pProp.IsUnique = true;
					break;

				case "NodeForType.Description":
					pProp.Name = "Description";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("NodeForType_Description");
					break;

				case "NodeForAction.Performed":
					pProp.Name = "Performed";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("NodeForAction_Performed");
					pProp.IsTimestamp = true;
					break;

				case "NodeForAction.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("NodeForAction_Note");
					pProp.IsNullable = true;
					break;

				case "Root.RootId":
					pProp.Name = "RootId";
					pProp.Type = "int";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "App.AppId":
					pProp.Name = "AppId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "App.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("App_Name");
					pProp.IsCaseInsensitive = true;
					pProp.IsUnique = true;
					break;

				case "Artifact.ArtifactId":
					pProp.Name = "ArtifactId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Artifact.IsPrivate":
					pProp.Name = "IsPrivate";
					pProp.Type = "bool";
					pProp.Description = SpecDoc.GetDtoPropText("Artifact_IsPrivate");
					break;

				case "Artifact.Created":
					pProp.Name = "Created";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Artifact_Created");
					pProp.IsTimestamp = true;
					break;

				case "ArtifactType.ArtifactTypeId":
					pProp.Name = "ArtifactTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Class.ClassId":
					pProp.Name = "ClassId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Class.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Class_Name");
					break;

				case "Class.Disamb":
					pProp.Name = "Disamb";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Class_Disamb");
					pProp.IsNullable = true;
					break;

				case "Class.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Class_Note");
					pProp.IsNullable = true;
					break;

				case "Instance.InstanceId":
					pProp.Name = "InstanceId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Instance.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Instance_Name");
					pProp.IsNullable = true;
					break;

				case "Instance.Disamb":
					pProp.Name = "Disamb";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Instance_Disamb");
					pProp.IsNullable = true;
					break;

				case "Instance.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Instance_Note");
					pProp.IsNullable = true;
					break;

				case "Member.MemberId":
					pProp.Name = "MemberId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "MemberType.MemberTypeId":
					pProp.Name = "MemberTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "MemberTypeAssign.MemberTypeAssignId":
					pProp.Name = "MemberTypeAssignId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Url.UrlId":
					pProp.Name = "UrlId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Url.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Url_Name");
					break;

				case "Url.AbsoluteUrl":
					pProp.Name = "AbsoluteUrl";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Url_AbsoluteUrl");
					pProp.IsCaseInsensitive = true;
					pProp.IsUnique = true;
					break;

				case "User.UserId":
					pProp.Name = "UserId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "User.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("User_Name");
					pProp.IsCaseInsensitive = true;
					pProp.IsUnique = true;
					break;

				case "Factor.FactorId":
					pProp.Name = "FactorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Factor.IsDefining":
					pProp.Name = "IsDefining";
					pProp.Type = "bool";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_IsDefining");
					break;

				case "Factor.Created":
					pProp.Name = "Created";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Created");
					pProp.IsTimestamp = true;
					break;

				case "Factor.Completed":
					pProp.Name = "Completed";
					pProp.Type = "long?";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Completed");
					pProp.IsNullable = true;
					break;

				case "Factor.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Note");
					pProp.IsNullable = true;
					break;

				case "FactorAssertion.FactorAssertionId":
					pProp.Name = "FactorAssertionId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Descriptor.DescriptorId":
					pProp.Name = "DescriptorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "DescriptorType.DescriptorTypeId":
					pProp.Name = "DescriptorTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Director.DirectorId":
					pProp.Name = "DirectorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "DirectorType.DirectorTypeId":
					pProp.Name = "DirectorTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "DirectorAction.DirectorActionId":
					pProp.Name = "DirectorActionId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Eventor.EventorId":
					pProp.Name = "EventorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Eventor.DateTime":
					pProp.Name = "DateTime";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Eventor_DateTime");
					break;

				case "EventorType.EventorTypeId":
					pProp.Name = "EventorTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "EventorPrecision.EventorPrecisionId":
					pProp.Name = "EventorPrecisionId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Identor.IdentorId":
					pProp.Name = "IdentorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Identor.Value":
					pProp.Name = "Value";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Identor_Value");
					break;

				case "IdentorType.IdentorTypeId":
					pProp.Name = "IdentorTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Locator.LocatorId":
					pProp.Name = "LocatorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Locator.ValueX":
					pProp.Name = "ValueX";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_ValueX");
					break;

				case "Locator.ValueY":
					pProp.Name = "ValueY";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_ValueY");
					break;

				case "Locator.ValueZ":
					pProp.Name = "ValueZ";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_ValueZ");
					break;

				case "LocatorType.LocatorTypeId":
					pProp.Name = "LocatorTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "LocatorType.MinX":
					pProp.Name = "MinX";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("LocatorType_MinX");
					break;

				case "LocatorType.MaxX":
					pProp.Name = "MaxX";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("LocatorType_MaxX");
					break;

				case "LocatorType.MinY":
					pProp.Name = "MinY";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("LocatorType_MinY");
					break;

				case "LocatorType.MaxY":
					pProp.Name = "MaxY";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("LocatorType_MaxY");
					break;

				case "LocatorType.MinZ":
					pProp.Name = "MinZ";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("LocatorType_MinZ");
					break;

				case "LocatorType.MaxZ":
					pProp.Name = "MaxZ";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("LocatorType_MaxZ");
					break;

				case "Vector.VectorId":
					pProp.Name = "VectorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Vector.Value":
					pProp.Name = "Value";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Vector_Value");
					break;

				case "VectorType.VectorTypeId":
					pProp.Name = "VectorTypeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "VectorType.Min":
					pProp.Name = "Min";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("VectorType_Min");
					break;

				case "VectorType.Max":
					pProp.Name = "Max";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("VectorType_Max");
					break;

				case "VectorRange.VectorRangeId":
					pProp.Name = "VectorRangeId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "VectorRangeLevel.VectorRangeLevelId":
					pProp.Name = "VectorRangeLevelId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "VectorRangeLevel.Position":
					pProp.Name = "Position";
					pProp.Type = "float";
					pProp.Description = SpecDoc.GetDtoPropText("VectorRangeLevel_Position");
					break;

				case "VectorUnit.VectorUnitId":
					pProp.Name = "VectorUnitId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "VectorUnit.Symbol":
					pProp.Name = "Symbol";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("VectorUnit_Symbol");
					break;

				case "VectorUnitPrefix.VectorUnitPrefixId":
					pProp.Name = "VectorUnitPrefixId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "VectorUnitPrefix.Symbol":
					pProp.Name = "Symbol";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("VectorUnitPrefix_Symbol");
					break;

				case "VectorUnitPrefix.Amount":
					pProp.Name = "Amount";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("VectorUnitPrefix_Amount");
					break;

				case "VectorUnitDerived.VectorUnitDerivedId":
					pProp.Name = "VectorUnitDerivedId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "VectorUnitDerived.Exponent":
					pProp.Name = "Exponent";
					pProp.Type = "int";
					pProp.Description = SpecDoc.GetDtoPropText("VectorUnitDerived_Exponent");
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecDtoFuncs(string pTypeName, FabSpecDto pObject) {
			switch ( pTypeName ) {

				case "Root":
					break;

				case "App":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Artifact":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "ArtifactType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Class":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Instance":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Member":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "MemberType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "MemberTypeAssign":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Url":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "User":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Factor":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "FactorAssertion":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Descriptor":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "DescriptorType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Director":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "DirectorType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "DirectorAction":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Eventor":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "EventorType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "EventorPrecision":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Identor":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "IdentorType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Locator":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "LocatorType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "Vector":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "VectorType":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "VectorRange":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "VectorRangeLevel":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "VectorUnit":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "VectorUnitPrefix":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;

				case "VectorUnitDerived":
					pObject.Functions.Add("Back");
					pObject.Functions.Add("Limit");
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecDtoLinks(string pTypeName, FabSpecDto pObject) {
			FabSpecDtoLink link;

			switch ( pTypeName ) {

				case "NodeForType":
					break;

				case "NodeForAction":
					break;

				case "ArtifactOwnerNode":
					break;

				case "Root":

					link = new FabSpecDtoLink();
					link.Name = "ContainsAppList";
					link.Type = "RootContainsApp";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsApp");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabApp";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsArtifactList";
					link.Type = "RootContainsArtifact";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsArtifactTypeList";
					link.Type = "RootContainsArtifactType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsArtifactType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabArtifactType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsClassList";
					link.Type = "RootContainsClass";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsClass");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabClass";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsInstanceList";
					link.Type = "RootContainsInstance";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsInstance");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabInstance";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsMemberList";
					link.Type = "RootContainsMember";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsMember");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabMember";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsMemberTypeList";
					link.Type = "RootContainsMemberType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsMemberType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabMemberType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsMemberTypeAssignList";
					link.Type = "RootContainsMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsMemberTypeAssign");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsUrlList";
					link.Type = "RootContainsUrl";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsUrl");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabUrl";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsUserList";
					link.Type = "RootContainsUser";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsUser");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabUser";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsFactorList";
					link.Type = "RootContainsFactor";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsFactor");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabFactor";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsFactorAssertionList";
					link.Type = "RootContainsFactorAssertion";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsFactorAssertion");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabFactorAssertion";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsDescriptorList";
					link.Type = "RootContainsDescriptor";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsDescriptor");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabDescriptor";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsDescriptorTypeList";
					link.Type = "RootContainsDescriptorType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsDescriptorType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabDescriptorType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsDirectorList";
					link.Type = "RootContainsDirector";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsDirector");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabDirector";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsDirectorTypeList";
					link.Type = "RootContainsDirectorType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsDirectorType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabDirectorType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsDirectorActionList";
					link.Type = "RootContainsDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsDirectorAction");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabDirectorAction";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsEventorList";
					link.Type = "RootContainsEventor";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsEventor");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabEventor";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsEventorTypeList";
					link.Type = "RootContainsEventorType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsEventorType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabEventorType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsEventorPrecisionList";
					link.Type = "RootContainsEventorPrecision";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsEventorPrecision");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabEventorPrecision";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsIdentorList";
					link.Type = "RootContainsIdentor";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsIdentor");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabIdentor";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsIdentorTypeList";
					link.Type = "RootContainsIdentorType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsIdentorType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabIdentorType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsLocatorList";
					link.Type = "RootContainsLocator";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsLocator");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabLocator";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsLocatorTypeList";
					link.Type = "RootContainsLocatorType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsLocatorType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabLocatorType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorList";
					link.Type = "RootContainsVector";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVector");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVector";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorTypeList";
					link.Type = "RootContainsVectorType";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVectorType");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVectorType";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorRangeList";
					link.Type = "RootContainsVectorRange";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVectorRange");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVectorRange";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorRangeLevelList";
					link.Type = "RootContainsVectorRangeLevel";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVectorRangeLevel");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVectorRangeLevel";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorUnitList";
					link.Type = "RootContainsVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVectorUnit");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorUnitPrefixList";
					link.Type = "RootContainsVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVectorUnitPrefix");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVectorUnitPrefix";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ContainsVectorUnitDerivedList";
					link.Type = "RootContainsVectorUnitDerived";
					link.Description = SpecDoc.GetDtoLinkText("RootContainsVectorUnitDerived");
					link.IsOutgoing = true;
					link.FromDto = "FabRoot";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Contains";
					link.ToDto = "FabVectorUnitDerived";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);

					break;

				case "App":

					link = new FabSpecDtoLink();
					link.Name = "HasArtifact";
					link.Type = "AppHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("AppHasArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabApp";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "DefinesMemberList";
					link.Type = "AppDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("AppDefinesMember");
					link.IsOutgoing = true;
					link.FromDto = "FabApp";
					link.FromDtoConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.ToDto = "FabMember";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);

					break;

				case "Artifact":

					link = new FabSpecDtoLink();
					link.Name = "InAppHas";
					link.Type = "AppHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("AppHasArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabApp";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesArtifactType";
					link.Type = "ArtifactUsesArtifactType";
					link.Description = SpecDoc.GetDtoLinkText("ArtifactUsesArtifactType");
					link.IsOutgoing = true;
					link.FromDto = "FabArtifact";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabArtifactType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InClassHas";
					link.Type = "ClassHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("ClassHasArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabClass";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InInstanceHas";
					link.Type = "InstanceHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("InstanceHasArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabInstance";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InMemberCreates";
					link.Type = "MemberCreatesArtifact";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InUrlHas";
					link.Type = "UrlHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("UrlHasArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabUrl";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InUserHas";
					link.Type = "UserHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("UserHasArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabUser";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InFactorListUsesPrimary";
					link.Type = "FactorUsesPrimaryArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesPrimaryArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InFactorListUsesRelated";
					link.Type = "FactorUsesRelatedArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesRelatedArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InDescriptorListRefinesPrimaryWith";
					link.Type = "DescriptorRefinesPrimaryWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesPrimaryWithArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "RefinesPrimaryWith";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InDescriptorListRefinesRelatedWith";
					link.Type = "DescriptorRefinesRelatedWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesRelatedWithArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "RefinesRelatedWith";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InDescriptorListRefinesTypeWith";
					link.Type = "DescriptorRefinesTypeWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesTypeWithArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "RefinesTypeWith";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InVectorListUsesAxis";
					link.Type = "VectorUsesAxisArtifact";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesAxisArtifact");
					link.IsOutgoing = false;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesAxis";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "ArtifactType":

					link = new FabSpecDtoLink();
					link.Name = "InArtifactListUses";
					link.Type = "ArtifactUsesArtifactType";
					link.Description = SpecDoc.GetDtoLinkText("ArtifactUsesArtifactType");
					link.IsOutgoing = false;
					link.FromDto = "FabArtifact";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabArtifactType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Class":

					link = new FabSpecDtoLink();
					link.Name = "HasArtifact";
					link.Type = "ClassHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("ClassHasArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabClass";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);

					break;

				case "Instance":

					link = new FabSpecDtoLink();
					link.Name = "HasArtifact";
					link.Type = "InstanceHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("InstanceHasArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabInstance";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);

					break;

				case "Member":

					link = new FabSpecDtoLink();
					link.Name = "InAppDefines";
					link.Type = "AppDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("AppDefinesMember");
					link.IsOutgoing = false;
					link.FromDto = "FabApp";
					link.FromDtoConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.ToDto = "FabMember";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "HasMemberTypeAssign";
					link.Type = "MemberHasMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasMemberTypeAssign");
					link.IsOutgoing = true;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "HasHistoricMemberTypeAssignList";
					link.Type = "MemberHasHistoricMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasHistoricMemberTypeAssign");
					link.IsOutgoing = true;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "HasHistoric";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "CreatesArtifactList";
					link.Type = "MemberCreatesArtifact";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "CreatesMemberTypeAssignList";
					link.Type = "MemberCreatesMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesMemberTypeAssign");
					link.IsOutgoing = true;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "CreatesFactorList";
					link.Type = "MemberCreatesFactor";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesFactor");
					link.IsOutgoing = true;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.ToDto = "FabFactor";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InUserDefines";
					link.Type = "UserDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("UserDefinesMember");
					link.IsOutgoing = false;
					link.FromDto = "FabUser";
					link.FromDtoConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.ToDto = "FabMember";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);

					break;

				case "MemberType":

					link = new FabSpecDtoLink();
					link.Name = "InMemberTypeAssignListUses";
					link.Type = "MemberTypeAssignUsesMemberType";
					link.Description = SpecDoc.GetDtoLinkText("MemberTypeAssignUsesMemberType");
					link.IsOutgoing = false;
					link.FromDto = "FabMemberTypeAssign";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabMemberType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "MemberTypeAssign":

					link = new FabSpecDtoLink();
					link.Name = "InMemberHas";
					link.Type = "MemberHasMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasMemberTypeAssign");
					link.IsOutgoing = false;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InMemberHasHistoric";
					link.Type = "MemberHasHistoricMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasHistoricMemberTypeAssign");
					link.IsOutgoing = false;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "HasHistoric";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InMemberCreates";
					link.Type = "MemberCreatesMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesMemberTypeAssign");
					link.IsOutgoing = false;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.ToDto = "FabMemberTypeAssign";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesMemberType";
					link.Type = "MemberTypeAssignUsesMemberType";
					link.Description = SpecDoc.GetDtoLinkText("MemberTypeAssignUsesMemberType");
					link.IsOutgoing = true;
					link.FromDto = "FabMemberTypeAssign";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabMemberType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Url":

					link = new FabSpecDtoLink();
					link.Name = "HasArtifact";
					link.Type = "UrlHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("UrlHasArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabUrl";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);

					break;

				case "User":

					link = new FabSpecDtoLink();
					link.Name = "HasArtifact";
					link.Type = "UserHasArtifact";
					link.Description = SpecDoc.GetDtoLinkText("UserHasArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabUser";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Has";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "DefinesMemberList";
					link.Type = "UserDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("UserDefinesMember");
					link.IsOutgoing = true;
					link.FromDto = "FabUser";
					link.FromDtoConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.ToDto = "FabMember";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);

					break;

				case "Factor":

					link = new FabSpecDtoLink();
					link.Name = "InMemberCreates";
					link.Type = "MemberCreatesFactor";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesFactor");
					link.IsOutgoing = false;
					link.FromDto = "FabMember";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.ToDto = "FabFactor";
					link.ToDtoConn = "InFromOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesPrimaryArtifact";
					link.Type = "FactorUsesPrimaryArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesPrimaryArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesRelatedArtifact";
					link.Type = "FactorUsesRelatedArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesRelatedArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesFactorAssertion";
					link.Type = "FactorUsesFactorAssertion";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesFactorAssertion");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabFactorAssertion";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "ReplacesFactor";
					link.Type = "FactorReplacesFactor";
					link.Description = SpecDoc.GetDtoLinkText("FactorReplacesFactor");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Replaces";
					link.ToDto = "FabFactor";
					link.ToDtoConn = "InFromZeroOrOne";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesDescriptor";
					link.Type = "FactorUsesDescriptor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDescriptor");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabDescriptor";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesDirector";
					link.Type = "FactorUsesDirector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDirector");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabDirector";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesEventor";
					link.Type = "FactorUsesEventor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesEventor");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabEventor";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesIdentor";
					link.Type = "FactorUsesIdentor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesIdentor");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabIdentor";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesLocator";
					link.Type = "FactorUsesLocator";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesLocator");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabLocator";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVector";
					link.Type = "FactorUsesVector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesVector");
					link.IsOutgoing = true;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabVector";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);

					break;

				case "FactorAssertion":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesFactorAssertion";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesFactorAssertion");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabFactorAssertion";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "FactorElementNode":
					break;

				case "Descriptor":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesDescriptor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDescriptor");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabDescriptor";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesDescriptorType";
					link.Type = "DescriptorUsesDescriptorType";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorUsesDescriptorType");
					link.IsOutgoing = true;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabDescriptorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "RefinesPrimaryWithArtifact";
					link.Type = "DescriptorRefinesPrimaryWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesPrimaryWithArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "RefinesPrimaryWith";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "RefinesRelatedWithArtifact";
					link.Type = "DescriptorRefinesRelatedWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesRelatedWithArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "RefinesRelatedWith";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "RefinesTypeWithArtifact";
					link.Type = "DescriptorRefinesTypeWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesTypeWithArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "RefinesTypeWith";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "DescriptorType":

					link = new FabSpecDtoLink();
					link.Name = "InDescriptorListUses";
					link.Type = "DescriptorUsesDescriptorType";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorUsesDescriptorType");
					link.IsOutgoing = false;
					link.FromDto = "FabDescriptor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabDescriptorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Director":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesDirector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDirector");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabDirector";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesDirectorType";
					link.Type = "DirectorUsesDirectorType";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesDirectorType");
					link.IsOutgoing = true;
					link.FromDto = "FabDirector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabDirectorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesPrimaryDirectorAction";
					link.Type = "DirectorUsesPrimaryDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesPrimaryDirectorAction");
					link.IsOutgoing = true;
					link.FromDto = "FabDirector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.ToDto = "FabDirectorAction";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesRelatedDirectorAction";
					link.Type = "DirectorUsesRelatedDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesRelatedDirectorAction");
					link.IsOutgoing = true;
					link.FromDto = "FabDirector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.ToDto = "FabDirectorAction";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "DirectorType":

					link = new FabSpecDtoLink();
					link.Name = "InDirectorListUses";
					link.Type = "DirectorUsesDirectorType";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesDirectorType");
					link.IsOutgoing = false;
					link.FromDto = "FabDirector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabDirectorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "DirectorAction":

					link = new FabSpecDtoLink();
					link.Name = "InDirectorListUsesPrimary";
					link.Type = "DirectorUsesPrimaryDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesPrimaryDirectorAction");
					link.IsOutgoing = false;
					link.FromDto = "FabDirector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.ToDto = "FabDirectorAction";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InDirectorListUsesRelated";
					link.Type = "DirectorUsesRelatedDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesRelatedDirectorAction");
					link.IsOutgoing = false;
					link.FromDto = "FabDirector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.ToDto = "FabDirectorAction";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Eventor":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesEventor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesEventor");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabEventor";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesEventorType";
					link.Type = "EventorUsesEventorType";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorType");
					link.IsOutgoing = true;
					link.FromDto = "FabEventor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabEventorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesEventorPrecision";
					link.Type = "EventorUsesEventorPrecision";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorPrecision");
					link.IsOutgoing = true;
					link.FromDto = "FabEventor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabEventorPrecision";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "EventorType":

					link = new FabSpecDtoLink();
					link.Name = "InEventorListUses";
					link.Type = "EventorUsesEventorType";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorType");
					link.IsOutgoing = false;
					link.FromDto = "FabEventor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabEventorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "EventorPrecision":

					link = new FabSpecDtoLink();
					link.Name = "InEventorListUses";
					link.Type = "EventorUsesEventorPrecision";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorPrecision");
					link.IsOutgoing = false;
					link.FromDto = "FabEventor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabEventorPrecision";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Identor":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesIdentor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesIdentor");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabIdentor";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesIdentorType";
					link.Type = "IdentorUsesIdentorType";
					link.Description = SpecDoc.GetDtoLinkText("IdentorUsesIdentorType");
					link.IsOutgoing = true;
					link.FromDto = "FabIdentor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabIdentorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "IdentorType":

					link = new FabSpecDtoLink();
					link.Name = "InIdentorListUses";
					link.Type = "IdentorUsesIdentorType";
					link.Description = SpecDoc.GetDtoLinkText("IdentorUsesIdentorType");
					link.IsOutgoing = false;
					link.FromDto = "FabIdentor";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabIdentorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Locator":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesLocator";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesLocator");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabLocator";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesLocatorType";
					link.Type = "LocatorUsesLocatorType";
					link.Description = SpecDoc.GetDtoLinkText("LocatorUsesLocatorType");
					link.IsOutgoing = true;
					link.FromDto = "FabLocator";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabLocatorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "LocatorType":

					link = new FabSpecDtoLink();
					link.Name = "InLocatorListUses";
					link.Type = "LocatorUsesLocatorType";
					link.Description = SpecDoc.GetDtoLinkText("LocatorUsesLocatorType");
					link.IsOutgoing = false;
					link.FromDto = "FabLocator";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabLocatorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "Vector":

					link = new FabSpecDtoLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesVector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesVector");
					link.IsOutgoing = false;
					link.FromDto = "FabFactor";
					link.FromDtoConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.ToDto = "FabVector";
					link.ToDtoConn = "InFromOneOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesAxisArtifact";
					link.Type = "VectorUsesAxisArtifact";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesAxisArtifact");
					link.IsOutgoing = true;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "UsesAxis";
					link.ToDto = "FabArtifact";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVectorType";
					link.Type = "VectorUsesVectorType";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorType");
					link.IsOutgoing = true;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVectorUnit";
					link.Type = "VectorUsesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnit");
					link.IsOutgoing = true;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVectorUnitPrefix";
					link.Type = "VectorUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnitPrefix");
					link.IsOutgoing = true;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorUnitPrefix";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "VectorType":

					link = new FabSpecDtoLink();
					link.Name = "InVectorListUses";
					link.Type = "VectorUsesVectorType";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorType");
					link.IsOutgoing = false;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorType";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVectorRange";
					link.Type = "VectorTypeUsesVectorRange";
					link.Description = SpecDoc.GetDtoLinkText("VectorTypeUsesVectorRange");
					link.IsOutgoing = true;
					link.FromDto = "FabVectorType";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorRange";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "VectorRange":

					link = new FabSpecDtoLink();
					link.Name = "InVectorTypeListUses";
					link.Type = "VectorTypeUsesVectorRange";
					link.Description = SpecDoc.GetDtoLinkText("VectorTypeUsesVectorRange");
					link.IsOutgoing = false;
					link.FromDto = "FabVectorType";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorRange";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVectorRangeLevelList";
					link.Type = "VectorRangeUsesVectorRangeLevel";
					link.Description = SpecDoc.GetDtoLinkText("VectorRangeUsesVectorRangeLevel");
					link.IsOutgoing = true;
					link.FromDto = "FabVectorRange";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Uses";
					link.ToDto = "FabVectorRangeLevel";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "VectorRangeLevel":

					link = new FabSpecDtoLink();
					link.Name = "InVectorRangeListUses";
					link.Type = "VectorRangeUsesVectorRangeLevel";
					link.Description = SpecDoc.GetDtoLinkText("VectorRangeUsesVectorRangeLevel");
					link.IsOutgoing = false;
					link.FromDto = "FabVectorRange";
					link.FromDtoConn = "OutToZeroOrMore";
					link.Relation = "Uses";
					link.ToDto = "FabVectorRangeLevel";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "VectorUnit":

					link = new FabSpecDtoLink();
					link.Name = "InVectorListUses";
					link.Type = "VectorUsesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnit");
					link.IsOutgoing = false;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InVectorUnitDerivedListDefines";
					link.Type = "VectorUnitDerivedDefinesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedDefinesVectorUnit");
					link.IsOutgoing = false;
					link.FromDto = "FabVectorUnitDerived";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Defines";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InVectorUnitDerivedListRaisesToExp";
					link.Type = "VectorUnitDerivedRaisesToExpVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedRaisesToExpVectorUnit");
					link.IsOutgoing = false;
					link.FromDto = "FabVectorUnitDerived";
					link.FromDtoConn = "OutToOne";
					link.Relation = "RaisesToExp";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "VectorUnitPrefix":

					link = new FabSpecDtoLink();
					link.Name = "InVectorListUses";
					link.Type = "VectorUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnitPrefix");
					link.IsOutgoing = false;
					link.FromDto = "FabVector";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorUnitPrefix";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "InVectorUnitDerivedListUses";
					link.Type = "VectorUnitDerivedUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedUsesVectorUnitPrefix");
					link.IsOutgoing = false;
					link.FromDto = "FabVectorUnitDerived";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorUnitPrefix";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;

				case "VectorUnitDerived":

					link = new FabSpecDtoLink();
					link.Name = "DefinesVectorUnit";
					link.Type = "VectorUnitDerivedDefinesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedDefinesVectorUnit");
					link.IsOutgoing = true;
					link.FromDto = "FabVectorUnitDerived";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Defines";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "RaisesToExpVectorUnit";
					link.Type = "VectorUnitDerivedRaisesToExpVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedRaisesToExpVectorUnit");
					link.IsOutgoing = true;
					link.FromDto = "FabVectorUnitDerived";
					link.FromDtoConn = "OutToOne";
					link.Relation = "RaisesToExp";
					link.ToDto = "FabVectorUnit";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);


					link = new FabSpecDtoLink();
					link.Name = "UsesVectorUnitPrefix";
					link.Type = "VectorUnitDerivedUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedUsesVectorUnitPrefix");
					link.IsOutgoing = true;
					link.FromDto = "FabVectorUnitDerived";
					link.FromDtoConn = "OutToOne";
					link.Relation = "Uses";
					link.ToDto = "FabVectorUnitPrefix";
					link.ToDtoConn = "InFromZeroOrMore";
					pObject.Links.Add(link);

					break;
			}
		}

	}

}