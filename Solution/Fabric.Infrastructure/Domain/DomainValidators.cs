// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 9:20:45 PM

using System;
using Fabric.Infrastructure.Db;

namespace Fabric.Infrastructure.Domain {


	/*================================================================================================*/
	public interface IDomainValidator {
	
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void NodeFabType(int pValue, string pParamName);
		void NodeFabType(int pValue);
		void NodeForActionPerformed(long pValue, string pParamName);
		void NodeForActionPerformed(long pValue);
		void NodeForActionNote(string pValue, string pParamName);
		void NodeForActionNote(string pValue);
		void ArtifactId(long pValue, string pParamName);
		void ArtifactId(long pValue);
		void ArtifactCreated(long pValue, string pParamName);
		void ArtifactCreated(long pValue);
		void AppName(string pValue, string pParamName);
		void AppName(string pValue);
		void AppSecret(string pValue, string pParamName);
		void AppSecret(string pValue);
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
		void MemberTypeAssignMemberTypeId(byte pValue, string pParamName);
		void MemberTypeAssignMemberTypeId(byte pValue);
		void UrlName(string pValue, string pParamName);
		void UrlName(string pValue);
		void UrlAbsoluteUrl(string pValue, string pParamName);
		void UrlAbsoluteUrl(string pValue);
		void UserName(string pValue, string pParamName);
		void UserName(string pValue);
		void UserPassword(string pValue, string pParamName);
		void UserPassword(string pValue);
		void FactorId(long pValue, string pParamName);
		void FactorId(long pValue);
		void FactorFactorAssertionId(byte pValue, string pParamName);
		void FactorFactorAssertionId(byte pValue);
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
		void FactorDescriptor_TypeId(byte pValue, string pParamName);
		void FactorDescriptor_TypeId(byte pValue);
		void FactorDirector_TypeId(byte pValue, string pParamName);
		void FactorDirector_TypeId(byte pValue);
		void FactorDirector_PrimaryActionId(byte pValue, string pParamName);
		void FactorDirector_PrimaryActionId(byte pValue);
		void FactorDirector_RelatedActionId(byte pValue, string pParamName);
		void FactorDirector_RelatedActionId(byte pValue);
		void FactorEventor_TypeId(byte pValue, string pParamName);
		void FactorEventor_TypeId(byte pValue);
		void FactorEventor_PrecisionId(byte pValue, string pParamName);
		void FactorEventor_PrecisionId(byte pValue);
		void FactorEventor_DateTime(long pValue, string pParamName);
		void FactorEventor_DateTime(long pValue);
		void FactorIdentor_TypeId(byte pValue, string pParamName);
		void FactorIdentor_TypeId(byte pValue);
		void FactorIdentor_Value(string pValue, string pParamName);
		void FactorIdentor_Value(string pValue);
		void FactorLocator_TypeId(byte pValue, string pParamName);
		void FactorLocator_TypeId(byte pValue);
		void FactorLocator_ValueX(double pValue, string pParamName);
		void FactorLocator_ValueX(double pValue);
		void FactorLocator_ValueY(double pValue, string pParamName);
		void FactorLocator_ValueY(double pValue);
		void FactorLocator_ValueZ(double pValue, string pParamName);
		void FactorLocator_ValueZ(double pValue);
		void FactorVector_TypeId(byte pValue, string pParamName);
		void FactorVector_TypeId(byte pValue);
		void FactorVector_UnitId(byte pValue, string pParamName);
		void FactorVector_UnitId(byte pValue);
		void FactorVector_UnitPrefixId(byte pValue, string pParamName);
		void FactorVector_UnitPrefixId(byte pValue);
		void FactorVector_Value(long pValue, string pParamName);
		void FactorVector_Value(long pValue);
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
		public void NodeFabType(int pValue, string pParamName) {
			throw new Exception("FabType has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void NodeFabType(int pValue) {
			NodeFabType(pValue, "FabType");
		}

		
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
		public void MemberTypeAssignMemberTypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(MemberTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void MemberTypeAssignMemberTypeId(byte pValue) {
			MemberTypeAssignMemberTypeId(pValue, "MemberTypeId");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		public void FactorFactorAssertionId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(FactorAssertionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorFactorAssertionId(byte pValue) {
			FactorFactorAssertionId(pValue, "FactorAssertionId");
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

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDescriptor_TypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DescriptorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDescriptor_TypeId(byte pValue) {
			FactorDescriptor_TypeId(pValue, "Descriptor_TypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDirector_TypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DirectorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDirector_TypeId(byte pValue) {
			FactorDirector_TypeId(pValue, "Director_TypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDirector_PrimaryActionId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DirectorActionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDirector_PrimaryActionId(byte pValue) {
			FactorDirector_PrimaryActionId(pValue, "Director_PrimaryActionId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDirector_RelatedActionId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(DirectorActionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorDirector_RelatedActionId(byte pValue) {
			FactorDirector_RelatedActionId(pValue, "Director_RelatedActionId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorEventor_TypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(EventorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorEventor_TypeId(byte pValue) {
			FactorEventor_TypeId(pValue, "Eventor_TypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorEventor_PrecisionId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(EventorPrecisionId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorEventor_PrecisionId(byte pValue) {
			FactorEventor_PrecisionId(pValue, "Eventor_PrecisionId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorEventor_DateTime(long pValue, string pParamName) {
			LongGreaterThanOrEqual(pParamName, pValue, 1);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorEventor_DateTime(long pValue) {
			FactorEventor_DateTime(pValue, "Eventor_DateTime");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIdentor_TypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(IdentorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIdentor_TypeId(byte pValue) {
			FactorIdentor_TypeId(pValue, "Identor_TypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIdentor_Value(string pValue, string pParamName) {
			NotNull(pParamName, pValue);
			LengthBetween(pParamName, pValue, 1, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorIdentor_Value(string pValue) {
			FactorIdentor_Value(pValue, "Identor_Value");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_TypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(LocatorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_TypeId(byte pValue) {
			FactorLocator_TypeId(pValue, "Locator_TypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_ValueX(double pValue, string pParamName) {
			throw new Exception("Locator_ValueX has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_ValueX(double pValue) {
			FactorLocator_ValueX(pValue, "Locator_ValueX");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_ValueY(double pValue, string pParamName) {
			throw new Exception("Locator_ValueY has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_ValueY(double pValue) {
			FactorLocator_ValueY(pValue, "Locator_ValueY");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_ValueZ(double pValue, string pParamName) {
			throw new Exception("Locator_ValueZ has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorLocator_ValueZ(double pValue) {
			FactorLocator_ValueZ(pValue, "Locator_ValueZ");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_TypeId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorTypeId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_TypeId(byte pValue) {
			FactorVector_TypeId(pValue, "Vector_TypeId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_UnitId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorUnitId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_UnitId(byte pValue) {
			FactorVector_UnitId(pValue, "Vector_UnitId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_UnitPrefixId(byte pValue, string pParamName) {
			LongBetween(pParamName, pValue, 1, Enum.GetNames(typeof(VectorUnitPrefixId)).Length);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_UnitPrefixId(byte pValue) {
			FactorVector_UnitPrefixId(pValue, "Vector_UnitPrefixId");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_Value(long pValue, string pParamName) {
			throw new Exception("Vector_Value has no validation. Property value was "+pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void FactorVector_Value(long pValue) {
			FactorVector_Value(pValue, "Vector_Value");
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