// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:17 PM

using System.Collections.Generic;
using Fabric.Api.Dto.Meta;

namespace Fabric.Api.Meta {

	/*================================================================================================*/
	public static class SpecBuilder {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecValue(string pTypeName, string pPropName, FabSpecValue pValue) {
			switch ( pTypeName+"."+pPropName ) {

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

				case "MemberTypeAssign.MemberTypeAssignId":
					break;

				case "MemberTypeAssign.MemberTypeId":
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

				case "Factor.FactorAssertionId":
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

				case "Descriptor.DescriptorId":
					break;

				case "Descriptor.DescriptorTypeId":
					break;

				case "Director.DirectorId":
					break;

				case "Director.DirectorTypeId":
					break;

				case "Director.PrimaryDirectorActionId":
					break;

				case "Director.RelatedDirectorActionId":
					break;

				case "Eventor.EventorId":
					break;

				case "Eventor.EventorTypeId":
					break;

				case "Eventor.EventorPrecisionId":
					break;

				case "Eventor.DateTime":
					break;

				case "Identor.IdentorId":
					break;

				case "Identor.IdentorTypeId":
					break;

				case "Identor.Value":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "Locator.LocatorId":
					break;

				case "Locator.LocatorTypeId":
					break;

				case "Locator.ValueX":
					break;

				case "Locator.ValueY":
					break;

				case "Locator.ValueZ":
					break;

				case "Vector.VectorId":
					break;

				case "Vector.VectorTypeId":
					break;

				case "Vector.VectorUnitId":
					break;

				case "Vector.VectorUnitPrefixId":
					break;

				case "Vector.Value":
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

				case "MemberTypeAssign.MemberTypeAssignId":
					pProp.Name = "MemberTypeAssignId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "MemberTypeAssign.MemberTypeId":
					pProp.Name = "MemberTypeId";
					pProp.Type = "byte";
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

				case "Factor.FactorAssertionId":
					pProp.Name = "FactorAssertionId";
					pProp.Type = "byte";
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

				case "Descriptor.DescriptorId":
					pProp.Name = "DescriptorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Descriptor.DescriptorTypeId":
					pProp.Name = "DescriptorTypeId";
					pProp.Type = "byte";
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

				case "Director.DirectorTypeId":
					pProp.Name = "DirectorTypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Director.PrimaryDirectorActionId":
					pProp.Name = "PrimaryDirectorActionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Director.RelatedDirectorActionId":
					pProp.Name = "RelatedDirectorActionId";
					pProp.Type = "byte";
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

				case "Eventor.EventorTypeId":
					pProp.Name = "EventorTypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Eventor.EventorPrecisionId":
					pProp.Name = "EventorPrecisionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Eventor.DateTime":
					pProp.Name = "DateTime";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Eventor_DateTime");
					break;

				case "Identor.IdentorId":
					pProp.Name = "IdentorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Identor.IdentorTypeId":
					pProp.Name = "IdentorTypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Identor.Value":
					pProp.Name = "Value";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Identor_Value");
					break;

				case "Locator.LocatorId":
					pProp.Name = "LocatorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Locator.LocatorTypeId":
					pProp.Name = "LocatorTypeId";
					pProp.Type = "byte";
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

				case "Vector.VectorId":
					pProp.Name = "VectorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Vector.VectorTypeId":
					pProp.Name = "VectorTypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Vector.VectorUnitId":
					pProp.Name = "VectorUnitId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Vector.VectorUnitPrefixId":
					pProp.Name = "VectorUnitPrefixId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					pProp.IsUnique = true;
					break;

				case "Vector.Value":
					pProp.Name = "Value";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Vector_Value");
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecObjectTravFuncs(string pTypeName, FabSpecObject pObject) {
			switch ( pTypeName ) {

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

				case "Director":
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

				case "Identor":
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

				case "Vector":
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

					break;
			}

		}

	}

}