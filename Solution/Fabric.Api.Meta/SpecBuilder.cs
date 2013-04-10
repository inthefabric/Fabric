// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/10/2013 12:55:31 PM

using System.Collections.Generic;
using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure.Domain.Types;

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

				case "Factor.Descriptor_TypeId":
					break;

				case "Factor.Director_TypeId":
					break;

				case "Factor.Director_PrimaryActionId":
					break;

				case "Factor.Director_RelatedActionId":
					break;

				case "Factor.Eventor_TypeId":
					break;

				case "Factor.Eventor_PrecisionId":
					break;

				case "Factor.Eventor_DateTime":
					break;

				case "Factor.Identor_TypeId":
					break;

				case "Factor.Identor_Value":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "Factor.Locator_TypeId":
					break;

				case "Factor.Locator_ValueX":
					break;

				case "Factor.Locator_ValueY":
					break;

				case "Factor.Locator_ValueZ":
					break;

				case "Factor.Vector_TypeId":
					break;

				case "Factor.Vector_UnitId":
					break;

				case "Factor.Vector_UnitPrefixId":
					break;

				case "Factor.Vector_Value":
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
					break;

				case "MemberTypeAssign.MemberTypeAssignId":
					pProp.Name = "MemberTypeAssignId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
					break;

				case "MemberTypeAssign.MemberTypeId":
					pProp.Name = "MemberTypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("MemberTypeAssign_MemberTypeId");
					break;

				case "Url.UrlId":
					pProp.Name = "UrlId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.IsPrimaryKey = true;
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
					break;

				case "Factor.FactorAssertionId":
					pProp.Name = "FactorAssertionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_FactorAssertionId");
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

				case "Factor.Descriptor_TypeId":
					pProp.Name = "Descriptor_TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Descriptor_TypeId");
					break;

				case "Factor.Director_TypeId":
					pProp.Name = "Director_TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Director_TypeId");
					break;

				case "Factor.Director_PrimaryActionId":
					pProp.Name = "Director_PrimaryActionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Director_PrimaryActionId");
					break;

				case "Factor.Director_RelatedActionId":
					pProp.Name = "Director_RelatedActionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Director_RelatedActionId");
					break;

				case "Factor.Eventor_TypeId":
					pProp.Name = "Eventor_TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Eventor_TypeId");
					break;

				case "Factor.Eventor_PrecisionId":
					pProp.Name = "Eventor_PrecisionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Eventor_PrecisionId");
					break;

				case "Factor.Eventor_DateTime":
					pProp.Name = "Eventor_DateTime";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Eventor_DateTime");
					break;

				case "Factor.Identor_TypeId":
					pProp.Name = "Identor_TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Identor_TypeId");
					break;

				case "Factor.Identor_Value":
					pProp.Name = "Identor_Value";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Identor_Value");
					break;

				case "Factor.Locator_TypeId":
					pProp.Name = "Locator_TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Locator_TypeId");
					break;

				case "Factor.Locator_ValueX":
					pProp.Name = "Locator_ValueX";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Locator_ValueX");
					break;

				case "Factor.Locator_ValueY":
					pProp.Name = "Locator_ValueY";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Locator_ValueY");
					break;

				case "Factor.Locator_ValueZ":
					pProp.Name = "Locator_ValueZ";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Locator_ValueZ");
					break;

				case "Factor.Vector_TypeId":
					pProp.Name = "Vector_TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Vector_TypeId");
					break;

				case "Factor.Vector_UnitId":
					pProp.Name = "Vector_UnitId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Vector_UnitId");
					break;

				case "Factor.Vector_UnitPrefixId":
					pProp.Name = "Vector_UnitPrefixId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Vector_UnitPrefixId");
					break;

				case "Factor.Vector_Value":
					pProp.Name = "Vector_Value";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Vector_Value");
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
					link.Name = "InFactorListDescriptorRefinesPrimaryWith";
					link.Type = "FactorDescriptorRefinesPrimaryWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorDescriptorRefinesPrimaryWithArtifact");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "DescriptorRefinesPrimaryWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InFactorListDescriptorRefinesRelatedWith";
					link.Type = "FactorDescriptorRefinesRelatedWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorDescriptorRefinesRelatedWithArtifact");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "DescriptorRefinesRelatedWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InFactorListDescriptorRefinesTypeWith";
					link.Type = "FactorDescriptorRefinesTypeWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorDescriptorRefinesTypeWithArtifact");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "DescriptorRefinesTypeWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "InFactorListVectorUsesAxis";
					link.Type = "FactorVectorUsesAxisArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorVectorUsesAxisArtifact");
					link.IsOutgoing = false;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "VectorUsesAxis";
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
					link.Name = "DescriptorRefinesPrimaryWithArtifact";
					link.Type = "FactorDescriptorRefinesPrimaryWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorDescriptorRefinesPrimaryWithArtifact");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "DescriptorRefinesPrimaryWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "DescriptorRefinesRelatedWithArtifact";
					link.Type = "FactorDescriptorRefinesRelatedWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorDescriptorRefinesRelatedWithArtifact");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "DescriptorRefinesRelatedWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "DescriptorRefinesTypeWithArtifact";
					link.Type = "FactorDescriptorRefinesTypeWithArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorDescriptorRefinesTypeWithArtifact");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "DescriptorRefinesTypeWith";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					link = new FabSpecTravLink();
					link.Name = "VectorUsesAxisArtifact";
					link.Type = "FactorVectorUsesAxisArtifact";
					link.Description = SpecDoc.GetDtoLinkText("FactorVectorUsesAxisArtifact");
					link.IsOutgoing = true;
					link.From = "FabFactor";
					link.FromConn = "OutToZeroOrOne";
					link.Relation = "VectorUsesAxis";
					link.To = "FabArtifact";
					link.ToConn = "InFromZeroOrMore";
					pObject.TraversalLinks.Add(link);

					break;
			}

		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static List<FabSpecEnum> BuildSpecEnums() {
			var list = new List<FabSpecEnum>();
			FabSpecEnum e;
			FabSpecObjectProp p;

			e = new FabSpecEnum();
			e.Name = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "Id";
				p.Description = SpecDoc.GetDtoPropText("BaseEnum_Id");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "EnumId";
				p.Description = SpecDoc.GetDtoPropText("BaseEnum_EnumId");
				p.Type = "string";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Name";
				p.Description = SpecDoc.GetDtoPropText("BaseEnum_Name");
				p.Type = "string";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Description";
				p.Description = SpecDoc.GetDtoPropText("BaseEnum_Description");
				p.Type = "string";
				e.Properties.Add(p);

			e = new FabSpecEnum();
			e.Name = "MemberType";
			e.Description = SpecDoc.GetDtoText("MemberType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( MemberType val in StaticTypes.MemberTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "DescriptorType";
			e.Description = SpecDoc.GetDtoText("DescriptorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( DescriptorType val in StaticTypes.DescriptorTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "DirectorType";
			e.Description = SpecDoc.GetDtoText("DirectorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( DirectorType val in StaticTypes.DirectorTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "DirectorAction";
			e.Description = SpecDoc.GetDtoText("DirectorAction");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( DirectorAction val in StaticTypes.DirectorActions.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "EventorPrecision";
			e.Description = SpecDoc.GetDtoText("EventorPrecision");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( EventorPrecision val in StaticTypes.EventorPrecisions.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "EventorType";
			e.Description = SpecDoc.GetDtoText("EventorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( EventorType val in StaticTypes.EventorTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "FactorAssertion";
			e.Description = SpecDoc.GetDtoText("FactorAssertion");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( FactorAssertion val in StaticTypes.FactorAssertions.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "IdentorType";
			e.Description = SpecDoc.GetDtoText("IdentorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( IdentorType val in StaticTypes.IdentorTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "LocatorType";
			e.Description = SpecDoc.GetDtoText("LocatorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "MinX";
				p.Description = SpecDoc.GetDtoPropText("LocatorType_MinX");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MaxX";
				p.Description = SpecDoc.GetDtoPropText("LocatorType_MaxX");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MinY";
				p.Description = SpecDoc.GetDtoPropText("LocatorType_MinY");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MaxY";
				p.Description = SpecDoc.GetDtoPropText("LocatorType_MaxY");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MinZ";
				p.Description = SpecDoc.GetDtoPropText("LocatorType_MinZ");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MaxZ";
				p.Description = SpecDoc.GetDtoPropText("LocatorType_MaxZ");
				p.Type = "double";
				e.Properties.Add(p);

			e.Data = new List<Dictionary<string, object>>();

			foreach ( LocatorType val in StaticTypes.LocatorTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("MinX", val.MinX);
				map.Add("MaxX", val.MaxX);
				map.Add("MinY", val.MinY);
				map.Add("MaxY", val.MaxY);
				map.Add("MinZ", val.MinZ);
				map.Add("MaxZ", val.MaxZ);
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "VectorType";
			e.Description = SpecDoc.GetDtoText("VectorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "VectorRangeId";
				p.Description = SpecDoc.GetDtoPropText("VectorType_VectorRangeId");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Min";
				p.Description = SpecDoc.GetDtoPropText("VectorType_Min");
				p.Type = "long";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Max";
				p.Description = SpecDoc.GetDtoPropText("VectorType_Max");
				p.Type = "long";
				e.Properties.Add(p);

			e.Data = new List<Dictionary<string, object>>();

			foreach ( VectorType val in StaticTypes.VectorTypes.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("VectorRangeId", val.VectorRangeId);
				map.Add("Min", val.Min);
				map.Add("Max", val.Max);
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "VectorRangeLevel";
			e.Description = SpecDoc.GetDtoText("VectorRangeLevel");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "Position";
				p.Description = SpecDoc.GetDtoPropText("VectorRangeLevel_Position");
				p.Type = "float";
				e.Properties.Add(p);

			e.Data = new List<Dictionary<string, object>>();

			foreach ( VectorRangeLevel val in StaticTypes.VectorRangeLevels.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Position", val.Position);
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "VectorRange";
			e.Description = SpecDoc.GetDtoText("VectorRange");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "VectorRangeLevelIds";
				p.Description = SpecDoc.GetDtoPropText("VectorRange_VectorRangeLevelIds");
				p.Type = "byte[]";
				e.Properties.Add(p);

			e.Data = new List<Dictionary<string, object>>();

			foreach ( VectorRange val in StaticTypes.VectorRanges.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("VectorRangeLevelIds", val.VectorRangeLevelIds);
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "VectorUnit";
			e.Description = SpecDoc.GetDtoText("VectorUnit");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
			e.Data = new List<Dictionary<string, object>>();

			foreach ( VectorUnit val in StaticTypes.VectorUnits.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "VectorUnitPrefix";
			e.Description = SpecDoc.GetDtoText("VectorUnitPrefix");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "Amount";
				p.Description = SpecDoc.GetDtoPropText("VectorUnitPrefix_Amount");
				p.Type = "double";
				e.Properties.Add(p);

			e.Data = new List<Dictionary<string, object>>();

			foreach ( VectorUnitPrefix val in StaticTypes.VectorUnitPrefixs.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("Amount", val.Amount);
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			e = new FabSpecEnum();
			e.Name = "VectorUnitDerived";
			e.Description = SpecDoc.GetDtoText("VectorUnitDerived");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "DefinesVectorUnitId";
				p.Description = SpecDoc.GetDtoPropText("VectorUnitDerived_DefinesVectorUnitId");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "RaisesVectorUnitId";
				p.Description = SpecDoc.GetDtoPropText("VectorUnitDerived_RaisesVectorUnitId");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "WithExponent";
				p.Description = SpecDoc.GetDtoPropText("VectorUnitDerived_WithExponent");
				p.Type = "int";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "RaisesVectorUnitPrefixId";
				p.Description = SpecDoc.GetDtoPropText("VectorUnitDerived_RaisesVectorUnitPrefixId");
				p.Type = "byte";
				e.Properties.Add(p);

			e.Data = new List<Dictionary<string, object>>();

			foreach ( VectorUnitDerived val in StaticTypes.VectorUnitDeriveds.Values ) {
				var map = new Dictionary<string, object>();
				map.Add("DefinesVectorUnitId", val.DefinesVectorUnitId);
				map.Add("RaisesVectorUnitId", val.RaisesVectorUnitId);
				map.Add("WithExponent", val.WithExponent);
				map.Add("RaisesVectorUnitPrefixId", val.RaisesVectorUnitPrefixId);
				map.Add("Id", val.Id);
				map.Add("EnumId", val.EnumId);
				map.Add("Name", val.Name);
				map.Add("Description", val.Description);
				e.Data.Add(map);
			}

			list.Add(e);

			return list;
		}

	}

}