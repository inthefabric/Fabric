// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/26/2013 4:16:59 PM

using System;

namespace Fabric.Api.Modify.Validators {


	/*================================================================================================*/
	public interface IDomainValidator {
	
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AppId(long pProp);
		void AppName(string pProp);
		void AppSecret(string pProp);
		void ArtifactId(long pProp);
		void ArtifactIsPrivate(bool pProp);
		void ArtifactCreated(long pProp);
		void ArtifactTypeId(long pProp);
		void ClassId(long pProp);
		void ClassName(string pProp);
		void ClassDisamb(string pProp);
		void ClassNote(string pProp);
		void CrowdId(long pProp);
		void CrowdName(string pProp);
		void CrowdDescription(string pProp);
		void CrowdIsPrivate(bool pProp);
		void CrowdIsInviteOnly(bool pProp);
		void CrowdianId(long pProp);
		void CrowdianTypeId(long pProp);
		void CrowdianTypeAssignId(long pProp);
		void CrowdianTypeAssignWeight(float pProp);
		void EmailId(long pProp);
		void EmailAddress(string pProp);
		void EmailCode(string pProp);
		void EmailCreated(long pProp);
		void EmailVerified(long pProp);
		void InstanceId(long pProp);
		void InstanceName(string pProp);
		void InstanceDisamb(string pProp);
		void InstanceNote(string pProp);
		void LabelId(long pProp);
		void LabelName(string pProp);
		void MemberId(long pProp);
		void MemberTypeId(long pProp);
		void MemberTypeAssignId(long pProp);
		void UrlId(long pProp);
		void UrlName(string pProp);
		void UrlAbsoluteUrl(string pProp);
		void UserId(long pProp);
		void UserName(string pProp);
		void UserPassword(string pProp);
		void FactorId(long pProp);
		void FactorIsDefining(bool pProp);
		void FactorCreated(long pProp);
		void FactorDeleted(long pProp);
		void FactorCompleted(long pProp);
		void FactorNote(string pProp);
		void FactorAssertionId(long pProp);
		void DescriptorId(long pProp);
		void DescriptorTypeId(long pProp);
		void DirectorId(long pProp);
		void DirectorTypeId(long pProp);
		void DirectorActionId(long pProp);
		void EventorId(long pProp);
		void EventorDateTime(long pProp);
		void EventorTypeId(long pProp);
		void EventorPrecisionId(long pProp);
		void IdentorId(long pProp);
		void IdentorValue(string pProp);
		void IdentorTypeId(long pProp);
		void LocatorId(long pProp);
		void LocatorValueX(double pProp);
		void LocatorValueY(double pProp);
		void LocatorValueZ(double pProp);
		void LocatorTypeId(long pProp);
		void LocatorTypeMinX(double pProp);
		void LocatorTypeMaxX(double pProp);
		void LocatorTypeMinY(double pProp);
		void LocatorTypeMaxY(double pProp);
		void LocatorTypeMinZ(double pProp);
		void LocatorTypeMaxZ(double pProp);
		void VectorId(long pProp);
		void VectorValue(long pProp);
		void VectorTypeId(long pProp);
		void VectorTypeMin(long pProp);
		void VectorTypeMax(long pProp);
		void VectorRangeId(long pProp);
		void VectorRangeLevelId(long pProp);
		void VectorRangeLevelPosition(float pProp);
		void VectorUnitId(long pProp);
		void VectorUnitSymbol(string pProp);
		void VectorUnitPrefixId(long pProp);
		void VectorUnitPrefixSymbol(string pProp);
		void VectorUnitPrefixAmount(double pProp);
		void VectorUnitDerivedId(long pProp);
		void VectorUnitDerivedExponent(int pProp);
		void OauthAccessId(long pProp);
		void OauthAccessToken(string pProp);
		void OauthAccessRefresh(string pProp);
		void OauthAccessExpires(long pProp);
		void OauthAccessIsClientOnly(bool pProp);
		void OauthDomainId(long pProp);
		void OauthDomainDomain(string pProp);
		void OauthGrantId(long pProp);
		void OauthGrantRedirectUri(string pProp);
		void OauthGrantCode(string pProp);
		void OauthGrantExpires(long pProp);
		void OauthScopeId(long pProp);
		void OauthScopeAllow(bool pProp);
		void OauthScopeCreated(long pProp);
	}


	/*================================================================================================*/
	public partial class DomainValidator : IDomainValidator {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AppId(long pProp) {
			LongGreaterThan("AppId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppName(string pProp) {
			NotNull("Name", pProp);
			LengthBetween("Name", pProp, 3, 64);
			MatchesRegex("Name", pProp, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppSecret(string pProp) {
			NotNull("Secret", pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactId(long pProp) {
			LongGreaterThan("ArtifactId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactIsPrivate(bool pProp) {
			throw new Exception("IsPrivate has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactCreated(long pProp) {
			LongGreaterThan("Created", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactTypeId(long pProp) {
			LongGreaterThan("ArtifactTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ClassId(long pProp) {
			LongGreaterThan("ClassId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassName(string pProp) {
			NotNull("Name", pProp);
			LengthLessThanOrEqual("Name", pProp, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassDisamb(string pProp) {
			NotNull("Disamb", pProp);
			LengthLessThanOrEqual("Disamb", pProp, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassNote(string pProp) {
			LengthLessThanOrEqual("Note", pProp, 256);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdId(long pProp) {
			LongGreaterThan("CrowdId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdName(string pProp) {
			NotNull("Name", pProp);
			LengthBetween("Name", pProp, 3, 64);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdDescription(string pProp) {
			NotNull("Description", pProp);
			LengthLessThanOrEqual("Description", pProp, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdIsPrivate(bool pProp) {
			throw new Exception("IsPrivate has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdIsInviteOnly(bool pProp) {
			throw new Exception("IsInviteOnly has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianId(long pProp) {
			LongGreaterThan("CrowdianId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeId(long pProp) {
			LongGreaterThan("CrowdianTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeAssignId(long pProp) {
			LongGreaterThan("CrowdianTypeAssignId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeAssignWeight(float pProp) {
			throw new Exception("Weight has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EmailId(long pProp) {
			LongGreaterThan("EmailId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailAddress(string pProp) {
			NotNull("Address", pProp);
			LengthLessThanOrEqual("Address", pProp, 256);
			MatchesRegex("Address", pProp, @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailCode(string pProp) {
			NotNull("Code", pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailCreated(long pProp) {
			LongGreaterThan("Created", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailVerified(long pProp) {
			throw new Exception("Verified has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void InstanceId(long pProp) {
			LongGreaterThan("InstanceId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceName(string pProp) {
			NotNull("Name", pProp);
			LengthLessThanOrEqual("Name", pProp, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceDisamb(string pProp) {
			NotNull("Disamb", pProp);
			LengthLessThanOrEqual("Disamb", pProp, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceNote(string pProp) {
			LengthLessThanOrEqual("Note", pProp, 256);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LabelId(long pProp) {
			LongGreaterThan("LabelId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LabelName(string pProp) {
			NotNull("Name", pProp);
			LengthBetween("Name", pProp, 1, 128);
			MatchesRegex("Name", pProp, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberId(long pProp) {
			LongGreaterThan("MemberId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeId(long pProp) {
			LongGreaterThan("MemberTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeAssignId(long pProp) {
			LongGreaterThan("MemberTypeAssignId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UrlId(long pProp) {
			LongGreaterThan("UrlId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlName(string pProp) {
			NotNull("Name", pProp);
			LengthLessThanOrEqual("Name", pProp, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlAbsoluteUrl(string pProp) {
			NotNull("AbsoluteUrl", pProp);
			LengthLessThanOrEqual("AbsoluteUrl", pProp, 2048);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UserId(long pProp) {
			LongGreaterThan("UserId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserName(string pProp) {
			NotNull("Name", pProp);
			LengthBetween("Name", pProp, 4, 16);
			MatchesRegex("Name", pProp, @"^[a-zA-Z0-9_]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserPassword(string pProp) {
			NotNull("Password", pProp);
			LengthBetween("Password", pProp, 8, 32);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void FactorId(long pProp) {
			LongGreaterThan("FactorId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIsDefining(bool pProp) {
			throw new Exception("IsDefining has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorCreated(long pProp) {
			LongGreaterThan("Created", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDeleted(long pProp) {
			throw new Exception("Deleted has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorCompleted(long pProp) {
			throw new Exception("Completed has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorNote(string pProp) {
			LengthLessThanOrEqual("Note", pProp, 256);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void FactorAssertionId(long pProp) {
			LongGreaterThan("FactorAssertionId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorId(long pProp) {
			LongGreaterThan("DescriptorId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorTypeId(long pProp) {
			LongGreaterThan("DescriptorTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorId(long pProp) {
			LongGreaterThan("DirectorId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorTypeId(long pProp) {
			LongGreaterThan("DirectorTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorActionId(long pProp) {
			LongGreaterThan("DirectorActionId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorId(long pProp) {
			LongGreaterThan("EventorId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorDateTime(long pProp) {
			throw new Exception("DateTime has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorTypeId(long pProp) {
			LongGreaterThan("EventorTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorPrecisionId(long pProp) {
			LongGreaterThan("EventorPrecisionId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void IdentorId(long pProp) {
			LongGreaterThan("IdentorId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorValue(string pProp) {
			NotNull("Value", pProp);
			LengthLessThanOrEqual("Value", pProp, 128);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void IdentorTypeId(long pProp) {
			LongGreaterThan("IdentorTypeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LocatorId(long pProp) {
			LongGreaterThan("LocatorId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueX(double pProp) {
			throw new Exception("ValueX has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueY(double pProp) {
			throw new Exception("ValueY has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueZ(double pProp) {
			throw new Exception("ValueZ has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeId(long pProp) {
			LongGreaterThan("LocatorTypeId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinX(double pProp) {
			throw new Exception("MinX has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxX(double pProp) {
			throw new Exception("MaxX has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinY(double pProp) {
			throw new Exception("MinY has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxY(double pProp) {
			throw new Exception("MaxY has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinZ(double pProp) {
			throw new Exception("MinZ has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxZ(double pProp) {
			throw new Exception("MaxZ has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorId(long pProp) {
			LongGreaterThan("VectorId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorValue(long pProp) {
			throw new Exception("Value has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeId(long pProp) {
			LongGreaterThan("VectorTypeId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeMin(long pProp) {
			throw new Exception("Min has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeMax(long pProp) {
			throw new Exception("Max has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeId(long pProp) {
			LongGreaterThan("VectorRangeId", pProp, 0);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeLevelId(long pProp) {
			LongGreaterThan("VectorRangeLevelId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeLevelPosition(float pProp) {
			throw new Exception("Position has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitId(long pProp) {
			LongGreaterThan("VectorUnitId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitSymbol(string pProp) {
			NotNull("Symbol", pProp);
			LengthLessThanOrEqual("Symbol", pProp, 8);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixId(long pProp) {
			LongGreaterThan("VectorUnitPrefixId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixSymbol(string pProp) {
			NotNull("Symbol", pProp);
			LengthLessThanOrEqual("Symbol", pProp, 8);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixAmount(double pProp) {
			throw new Exception("Amount has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitDerivedId(long pProp) {
			LongGreaterThan("VectorUnitDerivedId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitDerivedExponent(int pProp) {
			throw new Exception("Exponent has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessId(long pProp) {
			LongGreaterThan("OauthAccessId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessToken(string pProp) {
			throw new Exception("Token has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessRefresh(string pProp) {
			throw new Exception("Refresh has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessExpires(long pProp) {
			throw new Exception("Expires has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessIsClientOnly(bool pProp) {
			throw new Exception("IsClientOnly has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainId(long pProp) {
			LongGreaterThan("OauthDomainId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainDomain(string pProp) {
			NotNull("Domain", pProp);
			LengthLessThanOrEqual("Domain", pProp, 256);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantId(long pProp) {
			LongGreaterThan("OauthGrantId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantRedirectUri(string pProp) {
			NotNull("RedirectUri", pProp);
			LengthLessThanOrEqual("RedirectUri", pProp, 450);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantCode(string pProp) {
			NotNull("Code", pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantExpires(long pProp) {
			throw new Exception("Expires has no validation. Property value was "+pProp);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeId(long pProp) {
			LongGreaterThan("OauthScopeId", pProp, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeAllow(bool pProp) {
			throw new Exception("Allow has no validation. Property value was "+pProp);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeCreated(long pProp) {
			LongGreaterThan("Created", pProp, 0);
		}

	}

}