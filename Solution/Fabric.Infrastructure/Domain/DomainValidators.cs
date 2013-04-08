// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:15 PM

using System;
using Fabric.Infrastructure.Db;

namespace Fabric.Infrastructure.Domain {


	/*================================================================================================*/
	public interface IDomainValidator {
	
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void NodeForActionPerformed(long pValue, string pParamName);
		void NodeForActionPerformed(long pValue);
		void NodeForActionNote(string pValue, string pParamName);
		void NodeForActionNote(string pValue);
		void ArtifactId(long pValue, string pParamName);
		void ArtifactId(long pValue);
		void ArtifactCreated(long pValue, string pParamName);
		void ArtifactCreated(long pValue);
		void AppId(long pValue, string pParamName);
		void AppId(long pValue);
		void AppName(string pValue, string pParamName);
		void AppName(string pValue);
		void AppSecret(string pValue, string pParamName);
		void AppSecret(string pValue);
		void ClassId(long pValue, string pParamName);
		void ClassId(long pValue);
		void ClassName(string pValue, string pParamName);
		void ClassName(string pValue);
		void ClassDisamb(string pValue, string pParamName);
		void ClassDisamb(string pValue);
		void ClassNote(string pValue, string pParamName);
		void ClassNote(string pValue);
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
		void MemberId(long pValue, string pParamName);
		void MemberId(long pValue);
		void MemberTypeAssignId(long pValue, string pParamName);
		void MemberTypeAssignId(long pValue);
		void MemberTypeId(byte pValue, string pParamName);
		void MemberTypeId(byte pValue);
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
		void FactorAssertionId(byte pValue, string pParamName);
		void FactorAssertionId(byte pValue);
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
		void DescriptorId(long pValue, string pParamName);
		void DescriptorId(long pValue);
		void DescriptorTypeId(byte pValue, string pParamName);
		void DescriptorTypeId(byte pValue);
		void DirectorId(long pValue, string pParamName);
		void DirectorId(long pValue);
		void DirectorTypeId(byte pValue, string pParamName);
		void DirectorTypeId(byte pValue);
		void PrimaryDirectorActionId(byte pValue, string pParamName);
		void PrimaryDirectorActionId(byte pValue);
		void RelatedDirectorActionId(byte pValue, string pParamName);
		void RelatedDirectorActionId(byte pValue);
		void EventorId(long pValue, string pParamName);
		void EventorId(long pValue);
		void EventorTypeId(byte pValue, string pParamName);
		void EventorTypeId(byte pValue);
		void EventorPrecisionId(byte pValue, string pParamName);
		void EventorPrecisionId(byte pValue);
		void EventorDateTime(long pValue, string pParamName);
		void EventorDateTime(long pValue);
		void IdentorId(long pValue, string pParamName);
		void IdentorId(long pValue);
		void IdentorTypeId(byte pValue, string pParamName);
		void IdentorTypeId(byte pValue);
		void IdentorValue(string pValue, string pParamName);
		void IdentorValue(string pValue);
		void LocatorId(long pValue, string pParamName);
		void LocatorId(long pValue);
		void LocatorTypeId(byte pValue, string pParamName);
		void LocatorTypeId(byte pValue);
		void LocatorValueX(double pValue, string pParamName);
		void LocatorValueX(double pValue);
		void LocatorValueY(double pValue, string pParamName);
		void LocatorValueY(double pValue);
		void LocatorValueZ(double pValue, string pParamName);
		void LocatorValueZ(double pValue);
		void VectorId(long pValue, string pParamName);
		void VectorId(long pValue);
		void VectorTypeId(byte pValue, string pParamName);
		void VectorTypeId(byte pValue);
		void VectorUnitId(byte pValue, string pParamName);
		void VectorUnitId(byte pValue);
		void VectorUnitPrefixId(byte pValue, string pParamName);
		void VectorUnitPrefixId(byte pValue);
		void VectorValue(long pValue, string pParamName);
		void VectorValue(long pValue);
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
		public void NodeForActionPerformed(long pValue, string pParamName) {
			throw new Exception("Performed has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void NodeForActionPerformed(long pValue) {
			NodeForActionPerformed(pValue, "Performed");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void NodeForActionNote(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthBetween(pParamName, pValue, 1, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void NodeForActionNote(string pValue) {
			NodeForActionNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ArtifactId(long pValue) {
			ArtifactId(pValue, "ArtifactId");
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
		public void AppId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
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
		public void ClassId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassId(long pValue) {
			ClassId(pValue, "ClassId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassName(string pValue) {
			ClassName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassDisamb(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthBetween(pParamName, pValue, 1, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassDisamb(string pValue) {
			ClassDisamb(pValue, "Disamb");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassNote(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthBetween(pParamName, pValue, 1, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ClassNote(string pValue) {
			ClassNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EmailId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailId(long pValue) {
			EmailId(pValue, "EmailId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EmailAddress(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 256);
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
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceId(long pValue) {
			InstanceId(pValue, "InstanceId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceName(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthBetween(pParamName, pValue, 1, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceName(string pValue) {
			InstanceName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceDisamb(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthBetween(pParamName, pValue, 1, 128);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceDisamb(string pValue) {
			InstanceDisamb(pValue, "Disamb");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceNote(string pValue, string pParamName) {
			if ( pValue == null ) { return; }
			LengthBetween(pParamName, pValue, 1, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void InstanceNote(string pValue) {
			InstanceNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberId(long pValue) {
			MemberId(pValue, "MemberId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeAssignId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeAssignId(long pValue) {
			MemberTypeAssignId(pValue, "MemberTypeAssignId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeId(byte pValue) {
			MemberTypeId(pValue, "MemberTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UrlId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlId(long pValue) {
			UrlId(pValue, "UrlId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlName(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 128);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlName(string pValue) {
			UrlName(pValue, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlAbsoluteUrl(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 2048);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UrlAbsoluteUrl(string pValue) {
			UrlAbsoluteUrl(pValue, "AbsoluteUrl");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UserId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
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
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorId(long pValue) {
			FactorId(pValue, "FactorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorAssertionId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorAssertionId(byte pValue) {
			FactorAssertionId(pValue, "FactorAssertionId");
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
			LengthBetween(pParamName, pValue, 1, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorNote(string pValue) {
			FactorNote(pValue, "Note");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorId(long pValue) {
			DescriptorId(pValue, "DescriptorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DescriptorTypeId(byte pValue) {
			DescriptorTypeId(pValue, "DescriptorTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void DirectorId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DirectorId(long pValue) {
			DirectorId(pValue, "DirectorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DirectorTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DirectorTypeId(byte pValue) {
			DirectorTypeId(pValue, "DirectorTypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void PrimaryDirectorActionId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void PrimaryDirectorActionId(byte pValue) {
			PrimaryDirectorActionId(pValue, "PrimaryDirectorActionId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RelatedDirectorActionId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RelatedDirectorActionId(byte pValue) {
			RelatedDirectorActionId(pValue, "RelatedDirectorActionId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void EventorId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorId(long pValue) {
			EventorId(pValue, "EventorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorTypeId(byte pValue) {
			EventorTypeId(pValue, "EventorTypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorPrecisionId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void EventorPrecisionId(byte pValue) {
			EventorPrecisionId(pValue, "EventorPrecisionId");
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
		public void IdentorId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorId(long pValue) {
			IdentorId(pValue, "IdentorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorTypeId(byte pValue) {
			IdentorTypeId(pValue, "IdentorTypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorValue(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IdentorValue(string pValue) {
			IdentorValue(pValue, "Value");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LocatorId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorId(long pValue) {
			LocatorId(pValue, "LocatorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void LocatorTypeId(byte pValue) {
			LocatorTypeId(pValue, "LocatorTypeId");
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
		public void VectorId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorId(long pValue) {
			VectorId(pValue, "VectorId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorTypeId(byte pValue) {
			VectorTypeId(pValue, "VectorTypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitId(byte pValue) {
			VectorUnitId(pValue, "VectorUnitId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixId(byte pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VectorUnitPrefixId(byte pValue) {
			VectorUnitPrefixId(pValue, "VectorUnitPrefixId");
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
		public void OauthAccessId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
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
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainId(long pValue) {
			OauthDomainId(pValue, "OauthDomainId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainDomain(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 256);
			MatchesRegex(pParamName, pValue, @"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthDomainDomain(string pValue) {
			OauthDomainDomain(pValue, "Domain");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantId(long pValue, string pParamName) {
			LongNotEqualTo(pParamName, pValue, 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantId(long pValue) {
			OauthGrantId(pValue, "OauthGrantId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OauthGrantRedirectUri(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 450);
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
			LongNotEqualTo(pParamName, pValue, 0);
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