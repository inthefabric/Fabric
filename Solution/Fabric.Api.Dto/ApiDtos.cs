// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 11/28/2012 3:56:36 PM

using System.Collections.Generic;
using Fabric.Infrastructure;

namespace Fabric.Api.Dto {
	
	/*================================================================================================*/
	public abstract class FabNodeForType : FabNode {
	
		//[PropIsUnique(True)]
		//[PropLenMax(32)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Name { get; set; }

		//[PropLenMax(256)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Description { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public abstract class FabNodeForAction : FabNode {
	
		//[PropIsTimestamp(True)]
		public long PerformedTimestamp { get; set; }

		//[PropLenMax(256)]
		public string Note { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabRoot : FabNode {
	
		public IList<FabApp> OutContainsApps { get; set; }
		public IList<FabArtifact> OutContainsArtifacts { get; set; }
		public IList<FabArtifactType> OutContainsArtifactTypes { get; set; }
		public IList<FabCrowd> OutContainsCrowds { get; set; }
		public IList<FabCrowdian> OutContainsCrowdians { get; set; }
		public IList<FabCrowdianType> OutContainsCrowdianTypes { get; set; }
		public IList<FabEmail> OutContainsEmails { get; set; }
		public IList<FabLabel> OutContainsLabels { get; set; }
		public IList<FabMember> OutContainsMembers { get; set; }
		public IList<FabMemberType> OutContainsMemberTypes { get; set; }
		public IList<FabThing> OutContainsThings { get; set; }
		public IList<FabUrl> OutContainsUrls { get; set; }
		public IList<FabUser> OutContainsUsers { get; set; }
		public IList<FabFactor> OutContainsFactors { get; set; }
		public IList<FabFactorAssertion> OutContainsFactorAssertions { get; set; }
		public IList<FabDescriptor> OutContainsDescriptors { get; set; }
		public IList<FabDescriptorType> OutContainsDescriptorTypes { get; set; }
		public IList<FabDirector> OutContainsDirectors { get; set; }
		public IList<FabDirectorType> OutContainsDirectorTypes { get; set; }
		public IList<FabDirectorAction> OutContainsDirectorActions { get; set; }
		public IList<FabEventor> OutContainsEventors { get; set; }
		public IList<FabEventorType> OutContainsEventorTypes { get; set; }
		public IList<FabEventorPrecision> OutContainsEventorPrecisions { get; set; }
		public IList<FabIdentor> OutContainsIdentors { get; set; }
		public IList<FabIdentorType> OutContainsIdentorTypes { get; set; }
		public IList<FabLocator> OutContainsLocators { get; set; }
		public IList<FabLocatorType> OutContainsLocatorTypes { get; set; }
		public IList<FabVector> OutContainsVectors { get; set; }
		public IList<FabVectorType> OutContainsVectorTypes { get; set; }
		public IList<FabVectorRange> OutContainsVectorRanges { get; set; }
		public IList<FabVectorRangeLevel> OutContainsVectorRangeLevels { get; set; }
		public IList<FabVectorUnit> OutContainsVectorUnits { get; set; }
		public IList<FabVectorUnitPrefix> OutContainsVectorUnitPrefixs { get; set; }
		public IList<FabOauthAccess> OutContainsOauthAccesss { get; set; }
		public IList<FabOauthDomain> OutContainsOauthDomains { get; set; }
		public IList<FabOauthGrant> OutContainsOauthGrants { get; set; }
		public IList<FabOauthScope> OutContainsOauthScopes { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabApp : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long AppId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(64)]
		//[PropLenMin(3)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Name { get; set; }

		//[PropLen(32)]
		public string Secret { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabArtifact OutHasArtifact { get; set; }
		public FabEmail OutUsesEmail { get; set; }
		public IList<FabMember> InMembersUses { get; set; }
		public IList<FabOauthAccess> InOauthAccesssUses { get; set; }
		public IList<FabOauthDomain> InOauthDomainsUses { get; set; }
		public IList<FabOauthGrant> InOauthGrantsUses { get; set; }
		public IList<FabOauthScope> InOauthScopesUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabArtifact : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long ArtifactId { get; set; }

		public bool IsPrivate { get; set; }

		//[PropIsTimestamp(True)]
		public long CreatedTimestamp { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp InAppHas { get; set; }
		public FabArtifactType OutUsesArtifactType { get; set; }
		public FabCrowd InCrowdHas { get; set; }
		public FabLabel InLabelHas { get; set; }
		public FabMember InMemberCreates { get; set; }
		public FabThing InThingHas { get; set; }
		public FabUrl InUrlHas { get; set; }
		public FabUser InUserHas { get; set; }
		public IList<FabFactor> InFactorsUsesPrimary { get; set; }
		public IList<FabFactor> InFactorsUsesRelated { get; set; }
		public IList<FabDescriptor> InDescriptorsrefinesPrimaryWith { get; set; }
		public IList<FabDescriptor> InDescriptorsrefinesRelatedWith { get; set; }
		public IList<FabDescriptor> InDescriptorsrefinesTypeWith { get; set; }
		public IList<FabVector> InVectorsUsesAxis { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabArtifactType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte ArtifactTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabArtifact> InArtifactsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabCrowd : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long CrowdId { get; set; }

		//[PropLenMax(64)]
		//[PropLenMin(3)]
		public string Name { get; set; }

		//[PropLenMax(256)]
		public string Description { get; set; }

		public bool IsPrivate { get; set; }

		public bool IsInviteOnly { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabArtifact OutHasArtifact { get; set; }
		public IList<FabCrowdian> InCrowdiansUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabCrowdian : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long CrowdianId { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabCrowd OutUsesCrowd { get; set; }
		public FabUser OutUsesUser { get; set; }
		public FabCrowdianTypeAssign OutHasCrowdianTypeAssign { get; set; }
		public IList<FabCrowdianTypeAssign> OutUsesHistoricCrowdianTypeAssigns { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabCrowdianType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte CrowdianTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabCrowdianTypeAssign> InCrowdianTypeAssignsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabCrowdianTypeAssign : FabNodeForAction {
	
		public float Weight { get; set; }

		public FabCrowdian InCrowdianHas { get; set; }
		public FabCrowdian InCrowdianUsesHistoric { get; set; }
		public FabCrowdianType OutUsesCrowdianType { get; set; }
		public FabUser InUserCreates { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabEmail : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long EmailId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(256)]
		//[PropValidRegex(@"^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$")]
		public string Address { get; set; }

		//[PropLen(32)]
		public string Code { get; set; }

		//[PropIsTimestamp(True)]
		public long CreatedTimestamp { get; set; }

		//[PropIsNullable(True)]
		public long VerifiedTimestamp { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp InAppUses { get; set; }
		public FabUser InUserUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabLabel : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long LabelId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Name { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabArtifact OutHasArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabMember : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long MemberId { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp OutUsesApp { get; set; }
		public FabUser OutUsesUser { get; set; }
		public FabMemberTypeAssign OutHasMemberTypeAssign { get; set; }
		public IList<FabMemberTypeAssign> OutUsesHistoricMemberTypeAssigns { get; set; }
		public IList<FabArtifact> OutCreatesArtifacts { get; set; }
		public IList<FabMemberTypeAssign> OutCreatesMemberTypeAssigns { get; set; }
		public IList<FabFactor> OutCreatesFactors { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabMemberType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte MemberTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabMemberTypeAssign> InMemberTypeAssignsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabMemberTypeAssign : FabNodeForAction {
	
		public FabMember InMemberHas { get; set; }
		public FabMember InMemberUsesHistoric { get; set; }
		public FabMember InMemberCreates { get; set; }
		public FabMemberType OutUsesMemberType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabThing : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long ThingId { get; set; }

		public bool IsClass { get; set; }

		//[PropLenMax(128)]
		public string Name { get; set; }

		//[PropLenMax(128)]
		public string Disamb { get; set; }

		//[PropLenMax(256)]
		public string Note { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabArtifact OutHasArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabUrl : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long UrlId { get; set; }

		//[PropLenMax(128)]
		public string Name { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(2048)]
		public string AbsoluteUrl { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabArtifact OutHasArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabUser : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long UserId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(16)]
		//[PropValidRegex(@"^[a-zA-Z0-9_]*$")]
		public string Name { get; set; }

		//[PropLen(32)]
		public string Password { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabCrowdian> InCrowdiansUses { get; set; }
		public IList<FabMember> InMembersUses { get; set; }
		public FabArtifact OutHasArtifact { get; set; }
		public FabEmail OutUsesEmail { get; set; }
		public IList<FabCrowdianTypeAssign> OutCreatesCrowdianTypeAssigns { get; set; }
		public IList<FabOauthAccess> InOauthAccesssUses { get; set; }
		public IList<FabOauthGrant> InOauthGrantsUses { get; set; }
		public IList<FabOauthScope> InOauthScopesUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabFactor : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long FactorId { get; set; }

		public bool IsPublic { get; set; }

		public bool IsDefining { get; set; }

		//[PropIsTimestamp(True)]
		public long CreatedTimestamp { get; set; }

		//[PropIsNullable(True)]
		public long DeletedTimestamp { get; set; }

		//[PropIsNullable(True)]
		public long CompletedTimestamp { get; set; }

		//[PropLenMax(256)]
		public string Note { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabMember InMemberCreates { get; set; }
		public FabArtifact OutUsesPrimaryArtifact { get; set; }
		public FabArtifact OutUsesRelatedArtifact { get; set; }
		public FabFactorAssertion OutUsesFactorAssertion { get; set; }
		public FabFactor OutReplacesFactor { get; set; }
		public FabDescriptor OutUsesDescriptor { get; set; }
		public FabDirector OutUsesDirector { get; set; }
		public FabEventor OutUsesEventor { get; set; }
		public FabIdentor OutUsesIdentor { get; set; }
		public FabLocator OutUsesLocator { get; set; }
		public FabVector OutUsesVector { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabFactorAssertion : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte FactorAssertionId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public abstract class FabFactorElementNode : FabNode {
	

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabDescriptor : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long DescriptorId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }
		public FabDescriptorType OutUsesDescriptorType { get; set; }
		public FabArtifact OutrefinesPrimaryWithArtifact { get; set; }
		public FabArtifact OutrefinesRelatedWithArtifact { get; set; }
		public FabArtifact OutrefinesTypeWithArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabDescriptorType : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte DescriptorTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabDescriptor> InDescriptorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabDirector : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long DirectorId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }
		public FabDirectorType OutUsesDirectorType { get; set; }
		public FabDirectorAction OutUsesPrimaryDirectorAction { get; set; }
		public FabDirectorAction OutUsesRelatedDirectorAction { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabDirectorType : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte DirectorTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabDirector> InDirectorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabDirectorAction : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte DirectorActionId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabDirector> InDirectorsUsesPrimary { get; set; }
		public IList<FabDirector> InDirectorsUsesRelated { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabEventor : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long EventorId { get; set; }

		public long DateTimeTimestamp { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }
		public FabEventorType OutUsesEventorType { get; set; }
		public FabEventorPrecision OutUsesEventorPrecision { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabEventorType : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte EventorTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabEventor> InEventorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabEventorPrecision : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte EventorPrecisionId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabEventor> InEventorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabIdentor : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long IdentorId { get; set; }

		//[PropLenMax(128)]
		public string Value { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }
		public FabIdentorType OutUsesIdentorType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabIdentorType : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte IdentorTypeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabIdentor> InIdentorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabLocator : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long LocatorId { get; set; }

		public double ValueX { get; set; }

		public double ValueY { get; set; }

		public double ValueZ { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }
		public FabLocatorType OutUsesLocatorType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabLocatorType : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte LocatorTypeId { get; set; }

		public double MinX { get; set; }

		public double MaxX { get; set; }

		public double MinY { get; set; }

		public double MaxY { get; set; }

		public double MinZ { get; set; }

		public double MaxZ { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabLocator> InLocatorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabVector : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long VectorId { get; set; }

		public long Value { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabFactor> InFactorsUses { get; set; }
		public FabArtifact OutUsesAxisArtifact { get; set; }
		public FabVectorType OutUsesVectorType { get; set; }
		public FabVectorUnit OutUsesVectorUnit { get; set; }
		public FabVectorUnitPrefix OutUsesVectorUnitPrefix { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabVectorType : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorTypeId { get; set; }

		public long Min { get; set; }

		public long Max { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabVector> InVectorsUses { get; set; }
		public FabVectorRange OutUsesVectorRange { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabVectorRange : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorRangeId { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabVectorType> InVectorTypesUses { get; set; }
		public IList<FabVectorRangeLevel> OutUsesVectorRangeLevels { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabVectorRangeLevel : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorRangeLevelId { get; set; }

		public float Position { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabVectorRange> InVectorRangesUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabVectorUnit : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorUnitId { get; set; }

		//[PropLenMax(8)]
		public string Symbol { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabVector> InVectorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabVectorUnitPrefix : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorUnitPrefixId { get; set; }

		//[PropLenMax(8)]
		public string Symbol { get; set; }

		public double Amount { get; set; }

		public FabRoot InRootContains { get; set; }
		public IList<FabVector> InVectorsUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabOauthAccess : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long OauthAccessId { get; set; }

		//[PropIsNullable(True)]
		//[PropIsUnique(True)]
		//[PropLen(32)]
		public string Token { get; set; }

		//[PropIsNullable(True)]
		//[PropLen(32)]
		public string Refresh { get; set; }

		public long ExpiresTimestamp { get; set; }

		public bool IsClientOnly { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp OutUsesApp { get; set; }
		public FabUser OutUsesUser { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabOauthDomain : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long OauthDomainId { get; set; }

		//[PropLenMax(256)]
		public string Domain { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp OutUsesApp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabOauthGrant : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long OauthGrantId { get; set; }

		//[PropLenMax(450)]
		public string RedirectUri { get; set; }

		//[PropIsUnique(True)]
		//[PropLen(32)]
		public string Code { get; set; }

		public long ExpiresTimestamp { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp OutUsesApp { get; set; }
		public FabUser OutUsesUser { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

	/*================================================================================================*/
	public class FabOauthScope : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long OauthScopeId { get; set; }

		public bool Allow { get; set; }

		//[PropIsTimestamp(True)]
		public long CreatedTimestamp { get; set; }

		public FabRoot InRootContains { get; set; }
		public FabApp OutUsesApp { get; set; }
		public FabUser OutUsesUser { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {}

	}

}
