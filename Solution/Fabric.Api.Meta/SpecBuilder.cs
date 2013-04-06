// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/6/2013 10:19:09 AM

using System.Collections.Generic;
using Fabric.Api.Dto.Meta;

namespace Fabric.Api.Meta {

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
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "NodeForAction.Performed":
					break;

				case "NodeForAction.Note":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "Artifact.ArtifactId":
					break;

				case "Artifact.Created":
					break;

				case "App.AppId":
					break;

				case "App.Name":
					pValue.LenMax = 64;
					pValue.LenMin = 3;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "App.Secret":
					pValue.Len = 32;
					pValue.ValidRegex = @"^[a-zA-Z0-9]*$";
					break;

				case "Class.ClassId":
					break;

				case "Class.Name":
					pValue.LenMax = 128;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Class.Disamb":
					pValue.LenMax = 128;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Class.Note":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "Email.EmailId":
					break;

				case "Email.Address":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
					break;

				case "Email.Code":
					pValue.Len = 32;
					pValue.ValidRegex = @"^[a-zA-Z0-9]*$";
					break;

				case "Email.Created":
					break;

				case "Email.Verified":
					break;

				case "Instance.InstanceId":
					break;

				case "Instance.Name":
					pValue.LenMax = 128;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Instance.Disamb":
					pValue.LenMax = 128;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
					break;

				case "Instance.Note":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "Member.MemberId":
					break;

				case "MemberType.MemberTypeId":
					break;

				case "MemberTypeAssign.MemberTypeAssignId":
					break;

				case "Url.UrlId":
					break;

				case "Url.Name":
					pValue.LenMax = 128;
					pValue.LenMin = 1;
					break;

				case "Url.AbsoluteUrl":
					pValue.LenMax = 2048;
					pValue.LenMin = 1;
					break;

				case "User.UserId":
					break;

				case "User.Name":
					pValue.LenMax = 16;
					pValue.LenMin = 4;
					pValue.ValidRegex = @"^[a-zA-Z0-9_]*$";
					break;

				case "User.Password":
					pValue.LenMax = 32;
					pValue.LenMin = 8;
					break;

				case "Factor.FactorId":
					break;

				case "Factor.IsDefining":
					break;

				case "Factor.Created":
					break;

				case "Factor.Deleted":
					break;

				case "Factor.Completed":
					break;

				case "Factor.Note":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "FactorAssertion.FactorAssertionId":
					break;

				case "Descriptor.DescriptorId":
					break;

				case "DescriptorType.DescriptorTypeId":
					break;

				case "Director.DirectorId":
					break;

				case "DirectorType.DirectorTypeId":
					break;

				case "DirectorAction.DirectorActionId":
					break;

				case "Eventor.EventorId":
					break;

				case "Eventor.DateTime":
					break;

				case "EventorType.EventorTypeId":
					break;

				case "EventorPrecision.EventorPrecisionId":
					break;

				case "Identor.IdentorId":
					break;

				case "Identor.Value":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "IdentorType.IdentorTypeId":
					break;

				case "Locator.LocatorId":
					break;

				case "Locator.ValueX":
					break;

				case "Locator.ValueY":
					break;

				case "Locator.ValueZ":
					break;

				case "LocatorType.LocatorTypeId":
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
					break;

				case "Vector.Value":
					break;

				case "VectorType.VectorTypeId":
					break;

				case "VectorType.Min":
					break;

				case "VectorType.Max":
					break;

				case "VectorRange.VectorRangeId":
					break;

				case "VectorRangeLevel.VectorRangeLevelId":
					break;

				case "VectorRangeLevel.Position":
					break;

				case "VectorUnit.VectorUnitId":
					break;

				case "VectorUnit.Symbol":
					pValue.LenMax = 8;
					pValue.LenMin = 1;
					break;

				case "VectorUnitPrefix.VectorUnitPrefixId":
					break;

				case "VectorUnitPrefix.Symbol":
					pValue.LenMax = 8;
					pValue.LenMin = 1;
					break;

				case "VectorUnitPrefix.Amount":
					break;

				case "VectorUnitDerived.VectorUnitDerivedId":
					break;

				case "VectorUnitDerived.Exponent":
					break;

				case "OauthAccess.OauthAccessId":
					break;

				case "OauthAccess.Token":
					pValue.Len = 32;
					pValue.ValidRegex = @"^[a-zA-Z0-9]*$";
					break;

				case "OauthAccess.Refresh":
					pValue.Len = 32;
					pValue.ValidRegex = @"^[a-zA-Z0-9]*$";
					break;

				case "OauthAccess.Expires":
					break;

				case "OauthAccess.IsClientOnly":
					break;

				case "OauthDomain.OauthDomainId":
					break;

				case "OauthDomain.Domain":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					pValue.ValidRegex = @"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$";
					break;

				case "OauthGrant.OauthGrantId":
					break;

				case "OauthGrant.RedirectUri":
					pValue.LenMax = 450;
					pValue.LenMin = 1;
					break;

				case "OauthGrant.Code":
					pValue.Len = 32;
					pValue.ValidRegex = @"^[a-zA-Z0-9]*$";
					break;

				case "OauthGrant.Expires":
					break;

				case "OauthScope.OauthScopeId":
					break;

				case "OauthScope.Allow":
					break;

				case "OauthScope.Created":
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecDtoProp(string pTypeName, string pPropName, FabSpecObjectProp pProp){
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

				case "Artifact.ArtifactId":
					pProp.Name = "ArtifactId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Artifact.Created":
					pProp.Name = "Created";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Artifact_Created");
					pProp.IsTimestamp = true;
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
		public static void FillSpecObjectTravFuncs(string pTypeName, FabSpecObject pObject) {
			switch ( pTypeName ) {

				case "NodeForType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "NodeForAction":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Artifact":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "App":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Class":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Instance":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Member":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "MemberType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "MemberTypeAssign":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Url":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "User":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Factor":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "FactorAssertion":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "FactorElementNode":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Descriptor":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "DescriptorType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Director":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "DirectorType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "DirectorAction":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Eventor":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "EventorType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "EventorPrecision":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Identor":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "IdentorType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Locator":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "LocatorType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "Vector":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "VectorType":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "VectorRange":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "VectorRangeLevel":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "VectorUnit":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "VectorUnitPrefix":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;

				case "VectorUnitDerived":
					pObject.TraversalFunctions = new List<string>();
					pObject.TraversalFunctions.Add("As");
					pObject.TraversalFunctions.Add("Back");
					pObject.TraversalFunctions.Add("Limit");
					pObject.TraversalFunctions.Add("WhereId");
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecDtoLinks(string pTypeName, FabSpecObject pObject) {
			FabSpecTravLink link;

			switch ( pTypeName ) {

				case "NodeForType":
					break;

				case "NodeForAction":
					break;

				case "Artifact":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InMemberCreates";
					link.Type = "MemberCreatesArtifact";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesArtifact");
					link.IsOutgoing = false;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.To = "FabArtifact";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InFactorListUsesPrimary";
					link.Type = "FactorUsesPrimaryArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesPrimaryArtifact");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InFactorListUsesRelated";
					link.Type = "FactorUsesRelatedArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesRelatedArtifact");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InDescriptorListRefinesPrimaryWith";
					link.Type = "DescriptorRefinesPrimaryWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesPrimaryWithArtifact");
					link.IsOutgoing = false;
					link.From = "FabDescriptor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "RefinesPrimaryWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InDescriptorListRefinesRelatedWith";
					link.Type = "DescriptorRefinesRelatedWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesRelatedWithArtifact");
					link.IsOutgoing = false;
					link.From = "FabDescriptor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "RefinesRelatedWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InDescriptorListRefinesTypeWith";
					link.Type = "DescriptorRefinesTypeWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesTypeWithArtifact");
					link.IsOutgoing = false;
					link.From = "FabDescriptor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "RefinesTypeWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InVectorListUsesAxis";
					link.Type = "VectorUsesAxisArtifact";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesAxisArtifact");
					link.IsOutgoing = false;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "UsesAxis";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "App":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "DefinesMemberList";
					link.Type = "AppDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("AppDefinesMember");
					link.IsOutgoing = true;
					link.From = "FabApp";
					link.FromConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.To = "FabMember";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					break;

				case "Class":
					break;

				case "Instance":
					break;

				case "Member":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InAppDefines";
					link.Type = "AppDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("AppDefinesMember");
					link.IsOutgoing = false;
					link.From = "FabApp";
					link.FromConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.To = "FabMember";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "HasMemberTypeAssign";
					link.Type = "MemberHasMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasMemberTypeAssign");
					link.IsOutgoing = true;
					link.From = "FabMember";
					link.FromConn = "OutToOne";
					link.Relation = "Has";
					link.To = "FabMemberTypeAssign";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "HasHistoricMemberTypeAssignList";
					link.Type = "MemberHasHistoricMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasHistoricMemberTypeAssign");
					link.IsOutgoing = true;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "HasHistoric";
					link.To = "FabMemberTypeAssign";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "CreatesArtifactList";
					link.Type = "MemberCreatesArtifact";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesArtifact");
					link.IsOutgoing = true;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.To = "FabArtifact";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "CreatesMemberTypeAssignList";
					link.Type = "MemberCreatesMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesMemberTypeAssign");
					link.IsOutgoing = true;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.To = "FabMemberTypeAssign";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "CreatesFactorList";
					link.Type = "MemberCreatesFactor";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesFactor");
					link.IsOutgoing = true;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.To = "FabFactor";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InUserDefines";
					link.Type = "UserDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("UserDefinesMember");
					link.IsOutgoing = false;
					link.From = "FabUser";
					link.FromConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.To = "FabMember";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					break;

				case "MemberType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InMemberTypeAssignListUses";
					link.Type = "MemberTypeAssignUsesMemberType";
					link.Description = SpecDoc.GetDtoLinkText("MemberTypeAssignUsesMemberType");
					link.IsOutgoing = false;
					link.From = "FabMemberTypeAssign";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabMemberType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "MemberTypeAssign":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InMemberHas";
					link.Type = "MemberHasMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasMemberTypeAssign");
					link.IsOutgoing = false;
					link.From = "FabMember";
					link.FromConn = "OutToOne";
					link.Relation = "Has";
					link.To = "FabMemberTypeAssign";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InMemberHasHistoric";
					link.Type = "MemberHasHistoricMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberHasHistoricMemberTypeAssign");
					link.IsOutgoing = false;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "HasHistoric";
					link.To = "FabMemberTypeAssign";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InMemberCreates";
					link.Type = "MemberCreatesMemberTypeAssign";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesMemberTypeAssign");
					link.IsOutgoing = false;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.To = "FabMemberTypeAssign";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesMemberType";
					link.Type = "MemberTypeAssignUsesMemberType";
					link.Description = SpecDoc.GetDtoLinkText("MemberTypeAssignUsesMemberType");
					link.IsOutgoing = true;
					link.From = "FabMemberTypeAssign";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabMemberType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "Url":
					break;

				case "User":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "DefinesMemberList";
					link.Type = "UserDefinesMember";
					link.Description = SpecDoc.GetDtoLinkText("UserDefinesMember");
					link.IsOutgoing = true;
					link.From = "FabUser";
					link.FromConn = "OutToOneOrMore";
					link.Relation = "Defines";
					link.To = "FabMember";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					break;

				case "Factor":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InMemberCreates";
					link.Type = "MemberCreatesFactor";
					link.Description = SpecDoc.GetDtoLinkText("MemberCreatesFactor");
					link.IsOutgoing = false;
					link.From = "FabMember";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Creates";
					link.To = "FabFactor";
					link.ToConn = "InFromOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesPrimaryArtifact";
					link.Type = "FactorUsesPrimaryArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesPrimaryArtifact");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesRelatedArtifact";
					link.Type = "FactorUsesRelatedArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesRelatedArtifact");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesFactorAssertion";
					link.Type = "FactorUsesFactorAssertion";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesFactorAssertion");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabFactorAssertion";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "ReplacesFactor";
					link.Type = "FactorReplacesFactor";
					link.Description = SpecDoc.GetDtoLinkText("FactorReplacesFactor");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Replaces";
					link.To = "FabFactor";
					link.ToConn = "InFromZeroOrOne";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesDescriptor";
					link.Type = "FactorUsesDescriptor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDescriptor");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabDescriptor";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesDirector";
					link.Type = "FactorUsesDirector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDirector");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabDirector";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesEventor";
					link.Type = "FactorUsesEventor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesEventor");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabEventor";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesIdentor";
					link.Type = "FactorUsesIdentor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesIdentor");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabIdentor";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesLocator";
					link.Type = "FactorUsesLocator";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesLocator");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabLocator";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVector";
					link.Type = "FactorUsesVector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesVector");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabVector";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "FactorAssertion":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesFactorAssertion";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesFactorAssertion");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabFactorAssertion";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "FactorElementNode":
					break;

				case "Descriptor":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesDescriptor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDescriptor");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabDescriptor";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesDescriptorType";
					link.Type = "DescriptorUsesDescriptorType";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorUsesDescriptorType");
					link.IsOutgoing = true;
					link.From = "FabDescriptor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabDescriptorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "RefinesPrimaryWithArtifact";
					link.Type = "DescriptorRefinesPrimaryWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesPrimaryWithArtifact");
					link.IsOutgoing = true;
					link.From = "FabDescriptor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "RefinesPrimaryWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "RefinesRelatedWithArtifact";
					link.Type = "DescriptorRefinesRelatedWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesRelatedWithArtifact");
					link.IsOutgoing = true;
					link.From = "FabDescriptor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "RefinesRelatedWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "RefinesTypeWithArtifact";
					link.Type = "DescriptorRefinesTypeWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorRefinesTypeWithArtifact");
					link.IsOutgoing = true;
					link.From = "FabDescriptor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "RefinesTypeWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "DescriptorType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InDescriptorListUses";
					link.Type = "DescriptorUsesDescriptorType";
					link.Description = SpecDoc.GetDtoLinkText("DescriptorUsesDescriptorType");
					link.IsOutgoing = false;
					link.From = "FabDescriptor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabDescriptorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "Director":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesDirector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesDirector");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabDirector";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesDirectorType";
					link.Type = "DirectorUsesDirectorType";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesDirectorType");
					link.IsOutgoing = true;
					link.From = "FabDirector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabDirectorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesPrimaryDirectorAction";
					link.Type = "DirectorUsesPrimaryDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesPrimaryDirectorAction");
					link.IsOutgoing = true;
					link.From = "FabDirector";
					link.FromConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.To = "FabDirectorAction";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesRelatedDirectorAction";
					link.Type = "DirectorUsesRelatedDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesRelatedDirectorAction");
					link.IsOutgoing = true;
					link.From = "FabDirector";
					link.FromConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.To = "FabDirectorAction";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "DirectorType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InDirectorListUses";
					link.Type = "DirectorUsesDirectorType";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesDirectorType");
					link.IsOutgoing = false;
					link.From = "FabDirector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabDirectorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "DirectorAction":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InDirectorListUsesPrimary";
					link.Type = "DirectorUsesPrimaryDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesPrimaryDirectorAction");
					link.IsOutgoing = false;
					link.From = "FabDirector";
					link.FromConn = "OutToOne";
					link.Relation = "UsesPrimary";
					link.To = "FabDirectorAction";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InDirectorListUsesRelated";
					link.Type = "DirectorUsesRelatedDirectorAction";
					link.Description = SpecDoc.GetDtoLinkText("DirectorUsesRelatedDirectorAction");
					link.IsOutgoing = false;
					link.From = "FabDirector";
					link.FromConn = "OutToOne";
					link.Relation = "UsesRelated";
					link.To = "FabDirectorAction";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "Eventor":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesEventor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesEventor");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabEventor";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesEventorType";
					link.Type = "EventorUsesEventorType";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorType");
					link.IsOutgoing = true;
					link.From = "FabEventor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabEventorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesEventorPrecision";
					link.Type = "EventorUsesEventorPrecision";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorPrecision");
					link.IsOutgoing = true;
					link.From = "FabEventor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabEventorPrecision";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "EventorType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InEventorListUses";
					link.Type = "EventorUsesEventorType";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorType");
					link.IsOutgoing = false;
					link.From = "FabEventor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabEventorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "EventorPrecision":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InEventorListUses";
					link.Type = "EventorUsesEventorPrecision";
					link.Description = SpecDoc.GetDtoLinkText("EventorUsesEventorPrecision");
					link.IsOutgoing = false;
					link.From = "FabEventor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabEventorPrecision";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "Identor":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesIdentor";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesIdentor");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabIdentor";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesIdentorType";
					link.Type = "IdentorUsesIdentorType";
					link.Description = SpecDoc.GetDtoLinkText("IdentorUsesIdentorType");
					link.IsOutgoing = true;
					link.From = "FabIdentor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabIdentorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "IdentorType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InIdentorListUses";
					link.Type = "IdentorUsesIdentorType";
					link.Description = SpecDoc.GetDtoLinkText("IdentorUsesIdentorType");
					link.IsOutgoing = false;
					link.From = "FabIdentor";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabIdentorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "Locator":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesLocator";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesLocator");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabLocator";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesLocatorType";
					link.Type = "LocatorUsesLocatorType";
					link.Description = SpecDoc.GetDtoLinkText("LocatorUsesLocatorType");
					link.IsOutgoing = true;
					link.From = "FabLocator";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabLocatorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "LocatorType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InLocatorListUses";
					link.Type = "LocatorUsesLocatorType";
					link.Description = SpecDoc.GetDtoLinkText("LocatorUsesLocatorType");
					link.IsOutgoing = false;
					link.From = "FabLocator";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabLocatorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "Vector":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InFactorListUses";
					link.Type = "FactorUsesVector";
					link.Description = SpecDoc.GetDtoLinkText("FactorUsesVector");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "Uses";
					link.To = "FabVector";
					link.ToConn = "InFromOneOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesAxisArtifact";
					link.Type = "VectorUsesAxisArtifact";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesAxisArtifact");
					link.IsOutgoing = true;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "UsesAxis";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVectorType";
					link.Type = "VectorUsesVectorType";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorType");
					link.IsOutgoing = true;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVectorUnit";
					link.Type = "VectorUsesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnit");
					link.IsOutgoing = true;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorUnit";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVectorUnitPrefix";
					link.Type = "VectorUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnitPrefix");
					link.IsOutgoing = true;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorUnitPrefix";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "VectorType":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InVectorListUses";
					link.Type = "VectorUsesVectorType";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorType");
					link.IsOutgoing = false;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorType";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVectorRange";
					link.Type = "VectorTypeUsesVectorRange";
					link.Description = SpecDoc.GetDtoLinkText("VectorTypeUsesVectorRange");
					link.IsOutgoing = true;
					link.From = "FabVectorType";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorRange";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "VectorRange":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InVectorTypeListUses";
					link.Type = "VectorTypeUsesVectorRange";
					link.Description = SpecDoc.GetDtoLinkText("VectorTypeUsesVectorRange");
					link.IsOutgoing = false;
					link.From = "FabVectorType";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorRange";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVectorRangeLevelList";
					link.Type = "VectorRangeUsesVectorRangeLevel";
					link.Description = SpecDoc.GetDtoLinkText("VectorRangeUsesVectorRangeLevel");
					link.IsOutgoing = true;
					link.From = "FabVectorRange";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Uses";
					link.To = "FabVectorRangeLevel";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "VectorRangeLevel":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InVectorRangeListUses";
					link.Type = "VectorRangeUsesVectorRangeLevel";
					link.Description = SpecDoc.GetDtoLinkText("VectorRangeUsesVectorRangeLevel");
					link.IsOutgoing = false;
					link.From = "FabVectorRange";
					link.FromConn = "OutToZeroOrMore";
					link.Relation = "Uses";
					link.To = "FabVectorRangeLevel";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "VectorUnit":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InVectorListUses";
					link.Type = "VectorUsesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnit");
					link.IsOutgoing = false;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorUnit";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InVectorUnitDerivedListDefines";
					link.Type = "VectorUnitDerivedDefinesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedDefinesVectorUnit");
					link.IsOutgoing = false;
					link.From = "FabVectorUnitDerived";
					link.FromConn = "OutToOne";
					link.Relation = "Defines";
					link.To = "FabVectorUnit";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InVectorUnitDerivedListRaisesToExp";
					link.Type = "VectorUnitDerivedRaisesToExpVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedRaisesToExpVectorUnit");
					link.IsOutgoing = false;
					link.From = "FabVectorUnitDerived";
					link.FromConn = "OutToOne";
					link.Relation = "RaisesToExp";
					link.To = "FabVectorUnit";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "VectorUnitPrefix":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "InVectorListUses";
					link.Type = "VectorUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUsesVectorUnitPrefix");
					link.IsOutgoing = false;
					link.From = "FabVector";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorUnitPrefix";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InVectorUnitDerivedListUses";
					link.Type = "VectorUnitDerivedUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedUsesVectorUnitPrefix");
					link.IsOutgoing = false;
					link.From = "FabVectorUnitDerived";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorUnitPrefix";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;

				case "VectorUnitDerived":
					pObject.TraversalLinks = new List<FabSpecTravLink>();

					link = new FabSpecTravLink();
					link.Name = "DefinesVectorUnit";
					link.Type = "VectorUnitDerivedDefinesVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedDefinesVectorUnit");
					link.IsOutgoing = true;
					link.From = "FabVectorUnitDerived";
					link.FromConn = "OutToOne";
					link.Relation = "Defines";
					link.To = "FabVectorUnit";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "RaisesToExpVectorUnit";
					link.Type = "VectorUnitDerivedRaisesToExpVectorUnit";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedRaisesToExpVectorUnit");
					link.IsOutgoing = true;
					link.From = "FabVectorUnitDerived";
					link.FromConn = "OutToOne";
					link.Relation = "RaisesToExp";
					link.To = "FabVectorUnit";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "UsesVectorUnitPrefix";
					link.Type = "VectorUnitDerivedUsesVectorUnitPrefix";
					link.Description = SpecDoc.GetDtoLinkText("VectorUnitDerivedUsesVectorUnitPrefix");
					link.IsOutgoing = true;
					link.From = "FabVectorUnitDerived";
					link.FromConn = "OutToOne";
					link.Relation = "Uses";
					link.To = "FabVectorUnitPrefix";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;
			}

		}

	}

}