// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 2/11/2013 3:19:53 PM

using System;
using Fabric.Db.Data;

namespace Fabric.Api.Modify.Validators {


	/*================================================================================================*/
	public interface IDomainValidator {
	
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AppId(long pValue, string pParamName);
		void AppId(long pValue);
		void AppName(string pValue, string pParamName);
		void AppName(string pValue);
		void AppSecret(string pValue, string pParamName);
		void AppSecret(string pValue);
		void ArtifactId(long pValue, string pParamName);
		void ArtifactId(long pValue);
		void ArtifactIsPrivate(bool pValue, string pParamName);
		void ArtifactIsPrivate(bool pValue);
		void ArtifactCreated(long pValue, string pParamName);
		void ArtifactCreated(long pValue);
		void ArtifactTypeId(long pValue, string pParamName);
		void ArtifactTypeId(long pValue);
		void ClassId(long pValue, string pParamName);
		void ClassId(long pValue);
		void ClassName(string pValue, string pParamName);
		void ClassName(string pValue);
		void ClassDisamb(string pValue, string pParamName);
		void ClassDisamb(string pValue);
		void ClassNote(string pValue, string pParamName);
		void ClassNote(string pValue);
		void CrowdId(long pValue, string pParamName);
		void CrowdId(long pValue);
		void CrowdName(string pValue, string pParamName);
		void CrowdName(string pValue);
		void CrowdDescription(string pValue, string pParamName);
		void CrowdDescription(string pValue);
		void CrowdIsPrivate(bool pValue, string pParamName);
		void CrowdIsPrivate(bool pValue);
		void CrowdIsInviteOnly(bool pValue, string pParamName);
		void CrowdIsInviteOnly(bool pValue);
		void CrowdianId(long pValue, string pParamName);
		void CrowdianId(long pValue);
		void CrowdianTypeId(long pValue, string pParamName);
		void CrowdianTypeId(long pValue);
		void CrowdianTypeAssignId(long pValue, string pParamName);
		void CrowdianTypeAssignId(long pValue);
		void CrowdianTypeAssignWeight(float pValue, string pParamName);
		void CrowdianTypeAssignWeight(float pValue);
		void EmailId(long pValue, string pParamName);
		void EmailId(long pValue);
		void EmailAddress(string pValue, string pParamName);
		void EmailAddress(string pValue);
		void EmailCode(string pValue, string pParamName);
		void EmailCode(string pValue);
		void EmailCreated(long pValue, string pParamName);
		void EmailCreated(long pValue);
		void EmailVerified(long pValue, string pParamName);
		void EmailVerified(long pValue);
		void InstanceId(long pValue, string pParamName);
		void InstanceId(long pValue);
		void InstanceName(string pValue, string pParamName);
		void InstanceName(string pValue);
		void InstanceDisamb(string pValue, string pParamName);
		void InstanceDisamb(string pValue);
		void InstanceNote(string pValue, string pParamName);
		void InstanceNote(string pValue);
		void LabelId(long pValue, string pParamName);
		void LabelId(long pValue);
		void LabelName(string pValue, string pParamName);
		void LabelName(string pValue);
		void MemberId(long pValue, string pParamName);
		void MemberId(long pValue);
		void MemberTypeId(long pValue, string pParamName);
		void MemberTypeId(long pValue);
		void MemberTypeAssignId(long pValue, string pParamName);
		void MemberTypeAssignId(long pValue);
		void UrlId(long pValue, string pParamName);
		void UrlId(long pValue);
		void UrlName(string pValue, string pParamName);
		void UrlName(string pValue);
		void UrlAbsoluteUrl(string pValue, string pParamName);
		void UrlAbsoluteUrl(string pValue);
		void UserId(long pValue, string pParamName);
		void UserId(long pValue);
		void UserName(string pValue, string pParamName);
		void UserName(string pValue);
		void UserPassword(string pValue, string pParamName);
		void UserPassword(string pValue);
		void FactorId(long pValue, string pParamName);
		void FactorId(long pValue);
		void FactorIsDefining(bool pValue, string pParamName);
		void FactorIsDefining(bool pValue);
		void FactorCreated(long pValue, string pParamName);
		void FactorCreated(long pValue);
		void FactorDeleted(long pValue, string pParamName);
		void FactorDeleted(long pValue);
		void FactorCompleted(long pValue, string pParamName);
		void FactorCompleted(long pValue);
		void FactorNote(string pValue, string pParamName);
		void FactorNote(string pValue);
		void FactorAssertionId(long pValue, string pParamName);
		void FactorAssertionId(long pValue);
		void DescriptorId(long pValue, string pParamName);
		void DescriptorId(long pValue);
		void DescriptorTypeId(long pValue, string pParamName);
		void DescriptorTypeId(long pValue);
		void DirectorId(long pValue, string pParamName);
		void DirectorId(long pValue);
		void DirectorTypeId(long pValue, string pParamName);
		void DirectorTypeId(long pValue);
		void DirectorActionId(long pValue, string pParamName);
		void DirectorActionId(long pValue);
		void EventorId(long pValue, string pParamName);
		void EventorId(long pValue);
		void EventorDateTime(long pValue, string pParamName);
		void EventorDateTime(long pValue);
		void EventorTypeId(long pValue, string pParamName);
		void EventorTypeId(long pValue);
		void EventorPrecisionId(long pValue, string pParamName);
		void EventorPrecisionId(long pValue);
		void IdentorId(long pValue, string pParamName);
		void IdentorId(long pValue);
		void IdentorValue(string pValue, string pParamName);
		void IdentorValue(string pValue);
		void IdentorTypeId(long pValue, string pParamName);
		void IdentorTypeId(long pValue);
		void LocatorId(long pValue, string pParamName);
		void LocatorId(long pValue);
		void LocatorValueX(double pValue, string pParamName);
		void LocatorValueX(double pValue);
		void LocatorValueY(double pValue, string pParamName);
		void LocatorValueY(double pValue);
		void LocatorValueZ(double pValue, string pParamName);
		void LocatorValueZ(double pValue);
		void LocatorTypeId(long pValue, string pParamName);
		void LocatorTypeId(long pValue);
		void LocatorTypeMinX(double pValue, string pParamName);
		void LocatorTypeMinX(double pValue);
		void LocatorTypeMaxX(double pValue, string pParamName);
		void LocatorTypeMaxX(double pValue);
		void LocatorTypeMinY(double pValue, string pParamName);
		void LocatorTypeMinY(double pValue);
		void LocatorTypeMaxY(double pValue, string pParamName);
		void LocatorTypeMaxY(double pValue);
		void LocatorTypeMinZ(double pValue, string pParamName);
		void LocatorTypeMinZ(double pValue);
		void LocatorTypeMaxZ(double pValue, string pParamName);
		void LocatorTypeMaxZ(double pValue);
		void VectorId(long pValue, string pParamName);
		void VectorId(long pValue);
		void VectorValue(long pValue, string pParamName);
		void VectorValue(long pValue);
		void VectorTypeId(long pValue, string pParamName);
		void VectorTypeId(long pValue);
		void VectorTypeMin(long pValue, string pParamName);
		void VectorTypeMin(long pValue);
		void VectorTypeMax(long pValue, string pParamName);
		void VectorTypeMax(long pValue);
		void VectorRangeId(long pValue, string pParamName);
		void VectorRangeId(long pValue);
		void VectorRangeLevelId(long pValue, string pParamName);
		void VectorRangeLevelId(long pValue);
		void VectorRangeLevelPosition(float pValue, string pParamName);
		void VectorRangeLevelPosition(float pValue);
		void VectorUnitId(long pValue, string pParamName);
		void VectorUnitId(long pValue);
		void VectorUnitSymbol(string pValue, string pParamName);
		void VectorUnitSymbol(string pValue);
		void VectorUnitPrefixId(long pValue, string pParamName);
		void VectorUnitPrefixId(long pValue);
		void VectorUnitPrefixSymbol(string pValue, string pParamName);
		void VectorUnitPrefixSymbol(string pValue);
		void VectorUnitPrefixAmount(double pValue, string pParamName);
		void VectorUnitPrefixAmount(double pValue);
		void VectorUnitDerivedId(long pValue, string pParamName);
		void VectorUnitDerivedId(long pValue);
		void VectorUnitDerivedExponent(int pValue, string pParamName);
		void VectorUnitDerivedExponent(int pValue);
		void OauthAccessId(long pValue, string pParamName);
		void OauthAccessId(long pValue);
		void OauthAccessToken(string pValue, string pParamName);
		void OauthAccessToken(string pValue);
		void OauthAccessRefresh(string pValue, string pParamName);
		void OauthAccessRefresh(string pValue);
		void OauthAccessExpires(long pValue, string pParamName);
		void OauthAccessExpires(long pValue);
		void OauthAccessIsClientOnly(bool pValue, string pParamName);
		void OauthAccessIsClientOnly(bool pValue);
		void OauthDomainId(long pValue, string pParamName);
		void OauthDomainId(long pValue);
		void OauthDomainDomain(string pValue, string pParamName);
		void OauthDomainDomain(string pValue);
		void OauthGrantId(long pValue, string pParamName);
		void OauthGrantId(long pValue);
		void OauthGrantRedirectUri(string pValue, string pParamName);
		void OauthGrantRedirectUri(string pValue);
		void OauthGrantCode(string pValue, string pParamName);
		void OauthGrantCode(string pValue);
		void OauthGrantExpires(long pValue, string pParamName);
		void OauthGrantExpires(long pValue);
		void OauthScopeId(long pValue, string pParamName);
		void OauthScopeId(long pValue);
		void OauthScopeAllow(bool pValue, string pParamName);
		void OauthScopeAllow(bool pValue);
		void OauthScopeCreated(long pValue, string pParamName);
		void OauthScopeCreated(long pValue);
	}


	/*================================================================================================*/
	public partial class DomainValidator : IDomainValidator {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AppId(long pValue, string pParamName) {
			throw new Exception("AppId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppId(long pValue) {
			AppId(pValue, "AppId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 3, 64);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppName(string pValue) {
			AppName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppSecret(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppSecret(string pValue) {
			AppSecret(pValue, "Secret");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactId(long pValue, string pParamName) {
			throw new Exception("ArtifactId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactId(long pValue) {
			ArtifactId(pValue, "ArtifactId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactIsPrivate(bool pValue, string pParamName) {
			throw new Exception("IsPrivate has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactIsPrivate(bool pValue) {
			ArtifactIsPrivate(pValue, "IsPrivate");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactCreated(long pValue, string pParamName) {
			throw new Exception("Created has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactCreated(long pValue) {
			ArtifactCreated(pValue, "Created");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(ArtifactTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactTypeId(long pValue) {
			ArtifactTypeId(pValue, "ArtifactTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ClassId(long pValue, string pParamName) {
			throw new Exception("ClassId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassId(long pValue) {
			ClassId(pValue, "ClassId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassName(string pValue) {
			ClassName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassDisamb(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthLessThanOrEqual(pParamName, pValue, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassDisamb(string pValue) {
			ClassDisamb(pValue, "Disamb");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassNote(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthLessThanOrEqual(pParamName, pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassNote(string pValue) {
			ClassNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdId(long pValue, string pParamName) {
			throw new Exception("CrowdId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdId(long pValue) {
			CrowdId(pValue, "CrowdId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 3, 64);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdName(string pValue) {
			CrowdName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdDescription(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdDescription(string pValue) {
			CrowdDescription(pValue, "Description");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdIsPrivate(bool pValue, string pParamName) {
			throw new Exception("IsPrivate has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdIsPrivate(bool pValue) {
			CrowdIsPrivate(pValue, "IsPrivate");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdIsInviteOnly(bool pValue, string pParamName) {
			throw new Exception("IsInviteOnly has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdIsInviteOnly(bool pValue) {
			CrowdIsInviteOnly(pValue, "IsInviteOnly");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianId(long pValue, string pParamName) {
			throw new Exception("CrowdianId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianId(long pValue) {
			CrowdianId(pValue, "CrowdianId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeId(long pValue, string pParamName) {
			throw new Exception("CrowdianTypeId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeId(long pValue) {
			CrowdianTypeId(pValue, "CrowdianTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeAssignId(long pValue, string pParamName) {
			throw new Exception("CrowdianTypeAssignId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeAssignId(long pValue) {
			CrowdianTypeAssignId(pValue, "CrowdianTypeAssignId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeAssignWeight(float pValue, string pParamName) {
			throw new Exception("Weight has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CrowdianTypeAssignWeight(float pValue) {
			CrowdianTypeAssignWeight(pValue, "Weight");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EmailId(long pValue, string pParamName) {
			throw new Exception("EmailId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailId(long pValue) {
			EmailId(pValue, "EmailId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailAddress(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 256);
			MatchesRegex(pParamName, pValue, @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailAddress(string pValue) {
			EmailAddress(pValue, "Address");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailCode(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailCode(string pValue) {
			EmailCode(pValue, "Code");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailCreated(long pValue, string pParamName) {
			throw new Exception("Created has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailCreated(long pValue) {
			EmailCreated(pValue, "Created");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailVerified(long pValue, string pParamName) {
			throw new Exception("Verified has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailVerified(long pValue) {
			EmailVerified(pValue, "Verified");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void InstanceId(long pValue, string pParamName) {
			throw new Exception("InstanceId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceId(long pValue) {
			InstanceId(pValue, "InstanceId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceName(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthLessThanOrEqual(pParamName, pValue, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceName(string pValue) {
			InstanceName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceDisamb(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthLessThanOrEqual(pParamName, pValue, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceDisamb(string pValue) {
			InstanceDisamb(pValue, "Disamb");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceNote(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthLessThanOrEqual(pParamName, pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceNote(string pValue) {
			InstanceNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LabelId(long pValue, string pParamName) {
			throw new Exception("LabelId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LabelId(long pValue) {
			LabelId(pValue, "LabelId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LabelName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LabelName(string pValue) {
			LabelName(pValue, "Name");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberId(long pValue, string pParamName) {
			throw new Exception("MemberId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberId(long pValue) {
			MemberId(pValue, "MemberId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(MemberTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeId(long pValue) {
			MemberTypeId(pValue, "MemberTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeAssignId(long pValue, string pParamName) {
			throw new Exception("MemberTypeAssignId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeAssignId(long pValue) {
			MemberTypeAssignId(pValue, "MemberTypeAssignId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UrlId(long pValue, string pParamName) {
			throw new Exception("UrlId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlId(long pValue) {
			UrlId(pValue, "UrlId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlName(string pValue) {
			UrlName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlAbsoluteUrl(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 2048);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlAbsoluteUrl(string pValue) {
			UrlAbsoluteUrl(pValue, "AbsoluteUrl");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UserId(long pValue, string pParamName) {
			throw new Exception("UserId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserId(long pValue) {
			UserId(pValue, "UserId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 4, 16);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9_]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserName(string pValue) {
			UserName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserPassword(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 8, 32);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UserPassword(string pValue) {
			UserPassword(pValue, "Password");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void FactorId(long pValue, string pParamName) {
			throw new Exception("FactorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorId(long pValue) {
			FactorId(pValue, "FactorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIsDefining(bool pValue, string pParamName) {
			throw new Exception("IsDefining has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIsDefining(bool pValue) {
			FactorIsDefining(pValue, "IsDefining");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorCreated(long pValue, string pParamName) {
			throw new Exception("Created has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorCreated(long pValue) {
			FactorCreated(pValue, "Created");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDeleted(long pValue, string pParamName) {
			throw new Exception("Deleted has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDeleted(long pValue) {
			FactorDeleted(pValue, "Deleted");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorCompleted(long pValue, string pParamName) {
			throw new Exception("Completed has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorCompleted(long pValue) {
			FactorCompleted(pValue, "Completed");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorNote(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthLessThanOrEqual(pParamName, pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorNote(string pValue) {
			FactorNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void FactorAssertionId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(FactorAssertionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorAssertionId(long pValue) {
			FactorAssertionId(pValue, "FactorAssertionId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorId(long pValue, string pParamName) {
			throw new Exception("DescriptorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorId(long pValue) {
			DescriptorId(pValue, "DescriptorId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DescriptorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorTypeId(long pValue) {
			DescriptorTypeId(pValue, "DescriptorTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorId(long pValue, string pParamName) {
			throw new Exception("DirectorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DirectorId(long pValue) {
			DirectorId(pValue, "DirectorId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DirectorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DirectorTypeId(long pValue) {
			DirectorTypeId(pValue, "DirectorTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorActionId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DirectorActionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DirectorActionId(long pValue) {
			DirectorActionId(pValue, "DirectorActionId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorId(long pValue, string pParamName) {
			throw new Exception("EventorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorId(long pValue) {
			EventorId(pValue, "EventorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorDateTime(long pValue, string pParamName) {
			LongGreaterThanOrEqual(pParamName, pValue, 1);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorDateTime(long pValue) {
			EventorDateTime(pValue, "DateTime");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(EventorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorTypeId(long pValue) {
			EventorTypeId(pValue, "EventorTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorPrecisionId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(EventorPrecisionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorPrecisionId(long pValue) {
			EventorPrecisionId(pValue, "EventorPrecisionId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void IdentorId(long pValue, string pParamName) {
			throw new Exception("IdentorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorId(long pValue) {
			IdentorId(pValue, "IdentorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorValue(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorValue(string pValue) {
			IdentorValue(pValue, "Value");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void IdentorTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(IdentorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorTypeId(long pValue) {
			IdentorTypeId(pValue, "IdentorTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LocatorId(long pValue, string pParamName) {
			throw new Exception("LocatorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorId(long pValue) {
			LocatorId(pValue, "LocatorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueX(double pValue, string pParamName) {
			throw new Exception("ValueX has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueX(double pValue) {
			LocatorValueX(pValue, "ValueX");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueY(double pValue, string pParamName) {
			throw new Exception("ValueY has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueY(double pValue) {
			LocatorValueY(pValue, "ValueY");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueZ(double pValue, string pParamName) {
			throw new Exception("ValueZ has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorValueZ(double pValue) {
			LocatorValueZ(pValue, "ValueZ");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(LocatorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeId(long pValue) {
			LocatorTypeId(pValue, "LocatorTypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinX(double pValue, string pParamName) {
			throw new Exception("MinX has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinX(double pValue) {
			LocatorTypeMinX(pValue, "MinX");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxX(double pValue, string pParamName) {
			throw new Exception("MaxX has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxX(double pValue) {
			LocatorTypeMaxX(pValue, "MaxX");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinY(double pValue, string pParamName) {
			throw new Exception("MinY has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinY(double pValue) {
			LocatorTypeMinY(pValue, "MinY");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxY(double pValue, string pParamName) {
			throw new Exception("MaxY has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxY(double pValue) {
			LocatorTypeMaxY(pValue, "MaxY");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinZ(double pValue, string pParamName) {
			throw new Exception("MinZ has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMinZ(double pValue) {
			LocatorTypeMinZ(pValue, "MinZ");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxZ(double pValue, string pParamName) {
			throw new Exception("MaxZ has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeMaxZ(double pValue) {
			LocatorTypeMaxZ(pValue, "MaxZ");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorId(long pValue, string pParamName) {
			throw new Exception("VectorId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorId(long pValue) {
			VectorId(pValue, "VectorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorValue(long pValue, string pParamName) {
			throw new Exception("Value has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorValue(long pValue) {
			VectorValue(pValue, "Value");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeId(long pValue) {
			VectorTypeId(pValue, "VectorTypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeMin(long pValue, string pParamName) {
			throw new Exception("Min has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeMin(long pValue) {
			VectorTypeMin(pValue, "Min");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeMax(long pValue, string pParamName) {
			throw new Exception("Max has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeMax(long pValue) {
			VectorTypeMax(pValue, "Max");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorRangeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeId(long pValue) {
			VectorRangeId(pValue, "VectorRangeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeLevelId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorRangeLevelId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeLevelId(long pValue) {
			VectorRangeLevelId(pValue, "VectorRangeLevelId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeLevelPosition(float pValue, string pParamName) {
			throw new Exception("Position has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorRangeLevelPosition(float pValue) {
			VectorRangeLevelPosition(pValue, "Position");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorUnitId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitId(long pValue) {
			VectorUnitId(pValue, "VectorUnitId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitSymbol(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 8);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitSymbol(string pValue) {
			VectorUnitSymbol(pValue, "Symbol");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorUnitPrefixId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixId(long pValue) {
			VectorUnitPrefixId(pValue, "VectorUnitPrefixId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixSymbol(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 8);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixSymbol(string pValue) {
			VectorUnitPrefixSymbol(pValue, "Symbol");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixAmount(double pValue, string pParamName) {
			throw new Exception("Amount has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixAmount(double pValue) {
			VectorUnitPrefixAmount(pValue, "Amount");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitDerivedId(long pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorUnitDerivedId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitDerivedId(long pValue) {
			VectorUnitDerivedId(pValue, "VectorUnitDerivedId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitDerivedExponent(int pValue, string pParamName) {
			throw new Exception("Exponent has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitDerivedExponent(int pValue) {
			VectorUnitDerivedExponent(pValue, "Exponent");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessId(long pValue, string pParamName) {
			throw new Exception("OauthAccessId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessId(long pValue) {
			OauthAccessId(pValue, "OauthAccessId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessToken(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessToken(string pValue) {
			OauthAccessToken(pValue, "Token");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessRefresh(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessRefresh(string pValue) {
			OauthAccessRefresh(pValue, "Refresh");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessExpires(long pValue, string pParamName) {
			throw new Exception("Expires has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessExpires(long pValue) {
			OauthAccessExpires(pValue, "Expires");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessIsClientOnly(bool pValue, string pParamName) {
			throw new Exception("IsClientOnly has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthAccessIsClientOnly(bool pValue) {
			OauthAccessIsClientOnly(pValue, "IsClientOnly");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainId(long pValue, string pParamName) {
			throw new Exception("OauthDomainId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainId(long pValue) {
			OauthDomainId(pValue, "OauthDomainId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainDomain(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainDomain(string pValue) {
			OauthDomainDomain(pValue, "Domain");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantId(long pValue, string pParamName) {
			throw new Exception("OauthGrantId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantId(long pValue) {
			OauthGrantId(pValue, "OauthGrantId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantRedirectUri(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthLessThanOrEqual(pParamName, pValue, 450);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantRedirectUri(string pValue) {
			OauthGrantRedirectUri(pValue, "RedirectUri");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantCode(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantCode(string pValue) {
			OauthGrantCode(pValue, "Code");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantExpires(long pValue, string pParamName) {
			throw new Exception("Expires has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantExpires(long pValue) {
			OauthGrantExpires(pValue, "Expires");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeId(long pValue, string pParamName) {
			throw new Exception("OauthScopeId has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeId(long pValue) {
			OauthScopeId(pValue, "OauthScopeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeAllow(bool pValue, string pParamName) {
			throw new Exception("Allow has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeAllow(bool pValue) {
			OauthScopeAllow(pValue, "Allow");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeCreated(long pValue, string pParamName) {
			throw new Exception("Created has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthScopeCreated(long pValue) {
			OauthScopeCreated(pValue, "Created");
		}

	}

}