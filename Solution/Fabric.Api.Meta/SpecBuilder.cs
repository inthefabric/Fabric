// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 9:59:20 PM

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

				case "Vertex.FabType":
					break;

				case "VertexForAction.Performed":
					break;

				case "VertexForAction.Note":
					pValue.LenMax = 256;
					pValue.LenMin = 1;
					break;

				case "Artifact.ArtifactId":
					break;

				case "Artifact.Created":
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

				case "Url.Name":
					pValue.LenMax = 128;
					pValue.LenMin = 1;
					break;

				case "Url.AbsoluteUrl":
					pValue.LenMax = 2048;
					pValue.LenMin = 1;
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

				case "VertexForAction.Performed":
					pProp.Name = "Performed";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("VertexForAction_Performed");
					pProp.Enum = null;
					pProp.IsTimestamp = true;
					break;

				case "VertexForAction.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("VertexForAction_Note");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Artifact.ArtifactId":
					pProp.Name = "ArtifactId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.Enum = null;
					pProp.IsPrimaryKey = true;
					break;

				case "Artifact.Created":
					pProp.Name = "Created";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Artifact_Created");
					pProp.Enum = null;
					pProp.IsTimestamp = true;
					break;

				case "App.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("App_Name");
					pProp.Enum = null;
					pProp.IsCaseInsensitive = true;
					pProp.IsUnique = true;
					break;

				case "Class.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Class_Name");
					pProp.Enum = null;
					break;

				case "Class.Disamb":
					pProp.Name = "Disamb";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Class_Disamb");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Class.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Class_Note");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Instance.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Instance_Name");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Instance.Disamb":
					pProp.Name = "Disamb";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Instance_Disamb");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Instance.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Instance_Note");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Member.MemberId":
					pProp.Name = "MemberId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.Enum = null;
					pProp.IsPrimaryKey = true;
					break;

				case "MemberTypeAssign.MemberTypeAssignId":
					pProp.Name = "MemberTypeAssignId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.Enum = null;
					pProp.IsPrimaryKey = true;
					break;

				case "MemberTypeAssign.MemberTypeId":
					pProp.Name = "MemberTypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("MemberTypeAssign_MemberTypeId");
					pProp.Enum = "MemberType";
					break;

				case "Url.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Url_Name");
					pProp.Enum = null;
					break;

				case "Url.AbsoluteUrl":
					pProp.Name = "AbsoluteUrl";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Url_AbsoluteUrl");
					pProp.Enum = null;
					pProp.IsCaseInsensitive = true;
					pProp.IsUnique = true;
					break;

				case "User.Name":
					pProp.Name = "Name";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("User_Name");
					pProp.Enum = null;
					pProp.IsCaseInsensitive = true;
					pProp.IsUnique = true;
					break;

				case "Factor.FactorId":
					pProp.Name = "FactorId";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Object_TypeId");
					pProp.Enum = null;
					pProp.IsPrimaryKey = true;
					break;

				case "Factor.FactorAssertionId":
					pProp.Name = "FactorAssertionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_FactorAssertionId");
					pProp.Enum = "FactorAssertion";
					break;

				case "Factor.IsDefining":
					pProp.Name = "IsDefining";
					pProp.Type = "bool";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_IsDefining");
					pProp.Enum = null;
					break;

				case "Factor.Created":
					pProp.Name = "Created";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Created");
					pProp.Enum = null;
					pProp.IsTimestamp = true;
					break;

				case "Factor.Completed":
					pProp.Name = "Completed";
					pProp.Type = "long?";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Completed");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Factor.Note":
					pProp.Name = "Note";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Factor_Note");
					pProp.Enum = null;
					pProp.IsNullable = true;
					break;

				case "Descriptor.TypeId":
					pProp.Name = "TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Descriptor_TypeId");
					pProp.Enum = "DescriptorType";
					break;

				case "Director.TypeId":
					pProp.Name = "TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Director_TypeId");
					pProp.Enum = "DirectorType";
					break;

				case "Director.PrimaryActionId":
					pProp.Name = "PrimaryActionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Director_PrimaryActionId");
					pProp.Enum = "DirectorAction";
					break;

				case "Director.RelatedActionId":
					pProp.Name = "RelatedActionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Director_RelatedActionId");
					pProp.Enum = "DirectorAction";
					break;

				case "Eventor.TypeId":
					pProp.Name = "TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Eventor_TypeId");
					pProp.Enum = "EventorType";
					break;

				case "Eventor.PrecisionId":
					pProp.Name = "PrecisionId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Eventor_PrecisionId");
					pProp.Enum = "EventorPrecision";
					break;

				case "Eventor.DateTime":
					pProp.Name = "DateTime";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Eventor_DateTime");
					pProp.Enum = null;
					break;

				case "Identor.TypeId":
					pProp.Name = "TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Identor_TypeId");
					pProp.Enum = "IdentorType";
					break;

				case "Identor.Value":
					pProp.Name = "Value";
					pProp.Type = "string";
					pProp.Description = SpecDoc.GetDtoPropText("Identor_Value");
					pProp.Enum = null;
					break;

				case "Locator.TypeId":
					pProp.Name = "TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_TypeId");
					pProp.Enum = "LocatorType";
					break;

				case "Locator.ValueX":
					pProp.Name = "ValueX";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_ValueX");
					pProp.Enum = null;
					break;

				case "Locator.ValueY":
					pProp.Name = "ValueY";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_ValueY");
					pProp.Enum = null;
					break;

				case "Locator.ValueZ":
					pProp.Name = "ValueZ";
					pProp.Type = "double";
					pProp.Description = SpecDoc.GetDtoPropText("Locator_ValueZ");
					pProp.Enum = null;
					break;

				case "Vector.TypeId":
					pProp.Name = "TypeId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Vector_TypeId");
					pProp.Enum = "VectorType";
					break;

				case "Vector.UnitId":
					pProp.Name = "UnitId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Vector_UnitId");
					pProp.Enum = "VectorUnit";
					break;

				case "Vector.UnitPrefixId":
					pProp.Name = "UnitPrefixId";
					pProp.Type = "byte";
					pProp.Description = SpecDoc.GetDtoPropText("Vector_UnitPrefixId");
					pProp.Enum = "VectorUnitPrefix";
					break;

				case "Vector.Value":
					pProp.Name = "Value";
					pProp.Type = "long";
					pProp.Description = SpecDoc.GetDtoPropText("Vector_Value");
					pProp.Enum = null;
					break;
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void FillSpecObjectTravFuncs(string pTypeName, FabSpecObject pObject) {
			switch ( pTypeName ) {

				case "VertexForAction":
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
					pObject.TraversalFunctions.Add("WhereApp");
					pObject.TraversalFunctions.Add("WhereClass");
					pObject.TraversalFunctions.Add("WhereInstance");
					pObject.TraversalFunctions.Add("WhereUrl");
					pObject.TraversalFunctions.Add("WhereUser");
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

				case "VertexForAction":
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
			e.Description = SpecDoc.GetEnumText("BaseEnum");
			e.Properties = new List<FabSpecObjectProp>();
			list.Add(e);
			
				p = new FabSpecObjectProp();
				p.Name = "Id";
				p.Description = SpecDoc.GetEnumPropText("BaseEnum_Id");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "EnumId";
				p.Description = SpecDoc.GetEnumPropText("BaseEnum_EnumId");
				p.Type = "string";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Name";
				p.Description = SpecDoc.GetEnumPropText("BaseEnum_Name");
				p.Type = "string";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Description";
				p.Description = SpecDoc.GetEnumPropText("BaseEnum_Description");
				p.Type = "string";
				e.Properties.Add(p);

			e = new FabSpecEnum();
			e.Name = "MemberType";
			e.Description = SpecDoc.GetEnumText("MemberType");
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
			e.Description = SpecDoc.GetEnumText("DescriptorType");
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
			e.Description = SpecDoc.GetEnumText("DirectorType");
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
			e.Description = SpecDoc.GetEnumText("DirectorAction");
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
			e.Description = SpecDoc.GetEnumText("EventorPrecision");
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
			e.Description = SpecDoc.GetEnumText("EventorType");
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
			e.Description = SpecDoc.GetEnumText("FactorAssertion");
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
			e.Description = SpecDoc.GetEnumText("IdentorType");
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
			e.Description = SpecDoc.GetEnumText("LocatorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "MinX";
				p.Description = SpecDoc.GetEnumPropText("LocatorType_MinX");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MaxX";
				p.Description = SpecDoc.GetEnumPropText("LocatorType_MaxX");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MinY";
				p.Description = SpecDoc.GetEnumPropText("LocatorType_MinY");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MaxY";
				p.Description = SpecDoc.GetEnumPropText("LocatorType_MaxY");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MinZ";
				p.Description = SpecDoc.GetEnumPropText("LocatorType_MinZ");
				p.Type = "double";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "MaxZ";
				p.Description = SpecDoc.GetEnumPropText("LocatorType_MaxZ");
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
			e.Description = SpecDoc.GetEnumText("VectorType");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "VectorRangeId";
				p.Description = SpecDoc.GetEnumPropText("VectorType_VectorRangeId");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Min";
				p.Description = SpecDoc.GetEnumPropText("VectorType_Min");
				p.Type = "long";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "Max";
				p.Description = SpecDoc.GetEnumPropText("VectorType_Max");
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
			e.Description = SpecDoc.GetEnumText("VectorRangeLevel");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "Position";
				p.Description = SpecDoc.GetEnumPropText("VectorRangeLevel_Position");
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
			e.Description = SpecDoc.GetEnumText("VectorRange");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "VectorRangeLevelIds";
				p.Description = SpecDoc.GetEnumPropText("VectorRange_VectorRangeLevelIds");
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
			e.Description = SpecDoc.GetEnumText("VectorUnit");
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
			e.Description = SpecDoc.GetEnumText("VectorUnitPrefix");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "Amount";
				p.Description = SpecDoc.GetEnumPropText("VectorUnitPrefix_Amount");
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
			e.Description = SpecDoc.GetEnumText("VectorUnitDerived");
			e.Extends = "BaseEnum";
			e.Properties = new List<FabSpecObjectProp>();
			
				p = new FabSpecObjectProp();
				p.Name = "DefinesVectorUnitId";
				p.Description = SpecDoc.GetEnumPropText("VectorUnitDerived_DefinesVectorUnitId");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "RaisesVectorUnitId";
				p.Description = SpecDoc.GetEnumPropText("VectorUnitDerived_RaisesVectorUnitId");
				p.Type = "byte";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "WithExponent";
				p.Description = SpecDoc.GetEnumPropText("VectorUnitDerived_WithExponent");
				p.Type = "int";
				e.Properties.Add(p);

				p = new FabSpecObjectProp();
				p.Name = "RaisesVectorUnitPrefixId";
				p.Description = SpecDoc.GetEnumPropText("VectorUnitDerived_RaisesVectorUnitPrefixId");
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