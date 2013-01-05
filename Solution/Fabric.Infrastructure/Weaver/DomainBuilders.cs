// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/5/2013 8:16:32 AM

using System;
using System.Linq.Expressions;
using Weaver.Items;
using Weaver.Interfaces;
using Fabric.Domain;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public class AppBuilder : DomainBuilder<App> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(IWeaverTransaction pTx, App pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(IWeaverTransaction pTx, long pAppId) :
			base(pTx, Node = new App() { AppId = pAppId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesMemberList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthAccessListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthDomainListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthGrantListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthScopeListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> HasArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> UsesEmail { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> DefinesMemberList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> InOauthAccessListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> InOauthDomainListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> InOauthGrantListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<App> InOauthScopeListUses { get; set; }

	}

	/*================================================================================================*/
	public class ArtifactBuilder : DomainBuilder<Artifact> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(IWeaverTransaction pTx, Artifact pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(IWeaverTransaction pTx, long pArtifactId) :
			base(pTx, Node = new Artifact() { ArtifactId = pArtifactId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInThingHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUsesPrimary(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUsesRelated(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDescriptorListRefinesPrimaryWith(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDescriptorListRefinesRelatedWith(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDescriptorListRefinesTypeWith(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorListUsesAxis(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InAppHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> UsesArtifactType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InCrowdHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InLabelHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InMemberCreates { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InThingHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InUrlHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InUserHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InFactorListUsesPrimary { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InFactorListUsesRelated { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InDescriptorListRefinesPrimaryWith { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InDescriptorListRefinesRelatedWith { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InDescriptorListRefinesTypeWith { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Artifact> InVectorListUsesAxis { get; set; }

	}

	/*================================================================================================*/
	public class ArtifactTypeBuilder : DomainBuilder<ArtifactType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeBuilder(IWeaverTransaction pTx, ArtifactType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeBuilder(IWeaverTransaction pTx, long pArtifactTypeId) :
			base(pTx, Node = new ArtifactType() { ArtifactTypeId = pArtifactTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInArtifactListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<ArtifactType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<ArtifactType> InArtifactListUses { get; set; }

	}

	/*================================================================================================*/
	public class CrowdBuilder : DomainBuilder<Crowd> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdBuilder(IWeaverTransaction pTx, Crowd pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdBuilder(IWeaverTransaction pTx, long pCrowdId) :
			base(pTx, Node = new Crowd() { CrowdId = pCrowdId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesCrowdianList(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowd> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowd> HasArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowd> DefinesCrowdianList { get; set; }

	}

	/*================================================================================================*/
	public class CrowdianBuilder : DomainBuilder<Crowdian> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianBuilder(IWeaverTransaction pTx, Crowdian pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianBuilder(IWeaverTransaction pTx, long pCrowdianId) :
			base(pTx, Node = new Crowdian() { CrowdianId = pCrowdianId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasHistoricCrowdianTypeAssignList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowdian> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowdian> InCrowdDefines { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowdian> HasCrowdianTypeAssign { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowdian> HasHistoricCrowdianTypeAssignList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Crowdian> InUserDefines { get; set; }

	}

	/*================================================================================================*/
	public class CrowdianTypeBuilder : DomainBuilder<CrowdianType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeBuilder(IWeaverTransaction pTx, CrowdianType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeBuilder(IWeaverTransaction pTx, long pCrowdianTypeId) :
			base(pTx, Node = new CrowdianType() { CrowdianTypeId = pCrowdianTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianTypeAssignListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianType> InCrowdianTypeAssignListUses { get; set; }

	}

	/*================================================================================================*/
	public class CrowdianTypeAssignBuilder : DomainBuilder<CrowdianTypeAssign> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignBuilder(IWeaverTransaction pTx, CrowdianTypeAssign pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignBuilder(IWeaverTransaction pTx, long pCrowdianTypeAssignId) :
			base(pTx, Node = new CrowdianTypeAssign() { CrowdianTypeAssignId = pCrowdianTypeAssignId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianTypeAssign> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianTypeAssign> InCrowdianHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianTypeAssign> InCrowdianHasHistoric { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianTypeAssign> UsesCrowdianType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<CrowdianTypeAssign> InUserCreates { get; set; }

	}

	/*================================================================================================*/
	public class EmailBuilder : DomainBuilder<Email> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(IWeaverTransaction pTx, Email pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(IWeaverTransaction pTx, long pEmailId) :
			base(pTx, Node = new Email() { EmailId = pEmailId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Email> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Email> InAppUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Email> InUserUses { get; set; }

	}

	/*================================================================================================*/
	public class LabelBuilder : DomainBuilder<Label> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LabelBuilder(IWeaverTransaction pTx, Label pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LabelBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LabelBuilder(IWeaverTransaction pTx, long pLabelId) :
			base(pTx, Node = new Label() { LabelId = pLabelId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Label> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Label> HasArtifact { get; set; }

	}

	/*================================================================================================*/
	public class MemberBuilder : DomainBuilder<Member> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(IWeaverTransaction pTx, Member pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(IWeaverTransaction pTx, long pMemberId) :
			base(pTx, Node = new Member() { MemberId = pMemberId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasHistoricMemberTypeAssignList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetCreatesArtifactList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetCreatesMemberTypeAssignList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetCreatesFactorList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> InAppDefines { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> HasMemberTypeAssign { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> HasHistoricMemberTypeAssignList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> CreatesArtifactList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> CreatesMemberTypeAssignList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> CreatesFactorList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Member> InUserDefines { get; set; }

	}

	/*================================================================================================*/
	public class MemberTypeBuilder : DomainBuilder<MemberType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeBuilder(IWeaverTransaction pTx, MemberType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeBuilder(IWeaverTransaction pTx, long pMemberTypeId) :
			base(pTx, Node = new MemberType() { MemberTypeId = pMemberTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberTypeAssignListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberType> InMemberTypeAssignListUses { get; set; }

	}

	/*================================================================================================*/
	public class MemberTypeAssignBuilder : DomainBuilder<MemberTypeAssign> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(IWeaverTransaction pTx, MemberTypeAssign pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(IWeaverTransaction pTx, long pMemberTypeAssignId) :
			base(pTx, Node = new MemberTypeAssign() { MemberTypeAssignId = pMemberTypeAssignId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberTypeAssign> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberTypeAssign> InMemberHas { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberTypeAssign> InMemberHasHistoric { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberTypeAssign> InMemberCreates { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<MemberTypeAssign> UsesMemberType { get; set; }

	}

	/*================================================================================================*/
	public class ThingBuilder : DomainBuilder<Thing> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ThingBuilder(IWeaverTransaction pTx, Thing pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ThingBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ThingBuilder(IWeaverTransaction pTx, long pThingId) :
			base(pTx, Node = new Thing() { ThingId = pThingId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Thing> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Thing> HasArtifact { get; set; }

	}

	/*================================================================================================*/
	public class UrlBuilder : DomainBuilder<Url> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(IWeaverTransaction pTx, Url pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(IWeaverTransaction pTx, long pUrlId) :
			base(pTx, Node = new Url() { UrlId = pUrlId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Url> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Url> HasArtifact { get; set; }

	}

	/*================================================================================================*/
	public class UserBuilder : DomainBuilder<User> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(IWeaverTransaction pTx, User pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(IWeaverTransaction pTx, long pUserId) :
			base(pTx, Node = new User() { UserId = pUserId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetCreatesCrowdianTypeAssignList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesCrowdianList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesMemberList(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthAccessListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthGrantListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInOauthScopeListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> HasArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> CreatesCrowdianTypeAssignList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> DefinesCrowdianList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> UsesEmail { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> DefinesMemberList { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> InOauthAccessListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> InOauthGrantListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<User> InOauthScopeListUses { get; set; }

	}

	/*================================================================================================*/
	public class FactorBuilder : DomainBuilder<Factor> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(IWeaverTransaction pTx, Factor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(IWeaverTransaction pTx, long pFactorId) :
			base(pTx, Node = new Factor() { FactorId = pFactorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> InMemberCreates { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesPrimaryArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesRelatedArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesFactorAssertion { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> ReplacesFactor { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesDescriptor { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesDirector { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesEventor { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesIdentor { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesLocator { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Factor> UsesVector { get; set; }

	}

	/*================================================================================================*/
	public class FactorAssertionBuilder : DomainBuilder<FactorAssertion> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionBuilder(IWeaverTransaction pTx, FactorAssertion pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionBuilder(IWeaverTransaction pTx, long pFactorAssertionId) :
			base(pTx, Node = new FactorAssertion() { FactorAssertionId = pFactorAssertionId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<FactorAssertion> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<FactorAssertion> InFactorListUses { get; set; }

	}

	/*================================================================================================*/
	public class DescriptorBuilder : DomainBuilder<Descriptor> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorBuilder(IWeaverTransaction pTx, Descriptor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorBuilder(IWeaverTransaction pTx, long pDescriptorId) :
			base(pTx, Node = new Descriptor() { DescriptorId = pDescriptorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Descriptor> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Descriptor> InFactorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Descriptor> UsesDescriptorType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Descriptor> RefinesPrimaryWithArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Descriptor> RefinesRelatedWithArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Descriptor> RefinesTypeWithArtifact { get; set; }

	}

	/*================================================================================================*/
	public class DescriptorTypeBuilder : DomainBuilder<DescriptorType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeBuilder(IWeaverTransaction pTx, DescriptorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeBuilder(IWeaverTransaction pTx, long pDescriptorTypeId) :
			base(pTx, Node = new DescriptorType() { DescriptorTypeId = pDescriptorTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDescriptorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DescriptorType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DescriptorType> InDescriptorListUses { get; set; }

	}

	/*================================================================================================*/
	public class DirectorBuilder : DomainBuilder<Director> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(IWeaverTransaction pTx, Director pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(IWeaverTransaction pTx, long pDirectorId) :
			base(pTx, Node = new Director() { DirectorId = pDirectorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Director> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Director> InFactorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Director> UsesDirectorType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Director> UsesPrimaryDirectorAction { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Director> UsesRelatedDirectorAction { get; set; }

	}

	/*================================================================================================*/
	public class DirectorTypeBuilder : DomainBuilder<DirectorType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeBuilder(IWeaverTransaction pTx, DirectorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeBuilder(IWeaverTransaction pTx, long pDirectorTypeId) :
			base(pTx, Node = new DirectorType() { DirectorTypeId = pDirectorTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDirectorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DirectorType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DirectorType> InDirectorListUses { get; set; }

	}

	/*================================================================================================*/
	public class DirectorActionBuilder : DomainBuilder<DirectorAction> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionBuilder(IWeaverTransaction pTx, DirectorAction pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionBuilder(IWeaverTransaction pTx, long pDirectorActionId) :
			base(pTx, Node = new DirectorAction() { DirectorActionId = pDirectorActionId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDirectorListUsesPrimary(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInDirectorListUsesRelated(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DirectorAction> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DirectorAction> InDirectorListUsesPrimary { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<DirectorAction> InDirectorListUsesRelated { get; set; }

	}

	/*================================================================================================*/
	public class EventorBuilder : DomainBuilder<Eventor> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(IWeaverTransaction pTx, Eventor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(IWeaverTransaction pTx, long pEventorId) :
			base(pTx, Node = new Eventor() { EventorId = pEventorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Eventor> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Eventor> InFactorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Eventor> UsesEventorType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Eventor> UsesEventorPrecision { get; set; }

	}

	/*================================================================================================*/
	public class EventorTypeBuilder : DomainBuilder<EventorType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeBuilder(IWeaverTransaction pTx, EventorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeBuilder(IWeaverTransaction pTx, long pEventorTypeId) :
			base(pTx, Node = new EventorType() { EventorTypeId = pEventorTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInEventorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<EventorType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<EventorType> InEventorListUses { get; set; }

	}

	/*================================================================================================*/
	public class EventorPrecisionBuilder : DomainBuilder<EventorPrecision> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionBuilder(IWeaverTransaction pTx, EventorPrecision pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionBuilder(IWeaverTransaction pTx, long pEventorPrecisionId) :
			base(pTx, Node = new EventorPrecision() { EventorPrecisionId = pEventorPrecisionId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInEventorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<EventorPrecision> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<EventorPrecision> InEventorListUses { get; set; }

	}

	/*================================================================================================*/
	public class IdentorBuilder : DomainBuilder<Identor> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(IWeaverTransaction pTx, Identor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(IWeaverTransaction pTx, long pIdentorId) :
			base(pTx, Node = new Identor() { IdentorId = pIdentorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Identor> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Identor> InFactorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Identor> UsesIdentorType { get; set; }

	}

	/*================================================================================================*/
	public class IdentorTypeBuilder : DomainBuilder<IdentorType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeBuilder(IWeaverTransaction pTx, IdentorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeBuilder(IWeaverTransaction pTx, long pIdentorTypeId) :
			base(pTx, Node = new IdentorType() { IdentorTypeId = pIdentorTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInIdentorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<IdentorType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<IdentorType> InIdentorListUses { get; set; }

	}

	/*================================================================================================*/
	public class LocatorBuilder : DomainBuilder<Locator> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(IWeaverTransaction pTx, Locator pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(IWeaverTransaction pTx, long pLocatorId) :
			base(pTx, Node = new Locator() { LocatorId = pLocatorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Locator> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Locator> InFactorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Locator> UsesLocatorType { get; set; }

	}

	/*================================================================================================*/
	public class LocatorTypeBuilder : DomainBuilder<LocatorType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeBuilder(IWeaverTransaction pTx, LocatorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeBuilder(IWeaverTransaction pTx, long pLocatorTypeId) :
			base(pTx, Node = new LocatorType() { LocatorTypeId = pLocatorTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLocatorListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<LocatorType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<LocatorType> InLocatorListUses { get; set; }

	}

	/*================================================================================================*/
	public class VectorBuilder : DomainBuilder<Vector> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(IWeaverTransaction pTx, Vector pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(IWeaverTransaction pTx, long pVectorId) :
			base(pTx, Node = new Vector() { VectorId = pVectorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInFactorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Vector> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Vector> InFactorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Vector> UsesAxisArtifact { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Vector> UsesVectorType { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Vector> UsesVectorUnit { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<Vector> UsesVectorUnitPrefix { get; set; }

	}

	/*================================================================================================*/
	public class VectorTypeBuilder : DomainBuilder<VectorType> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeBuilder(IWeaverTransaction pTx, VectorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeBuilder(IWeaverTransaction pTx, long pVectorTypeId) :
			base(pTx, Node = new VectorType() { VectorTypeId = pVectorTypeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorType> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorType> InVectorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorType> UsesVectorRange { get; set; }

	}

	/*================================================================================================*/
	public class VectorRangeBuilder : DomainBuilder<VectorRange> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeBuilder(IWeaverTransaction pTx, VectorRange pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeBuilder(IWeaverTransaction pTx, long pVectorRangeId) :
			base(pTx, Node = new VectorRange() { VectorRangeId = pVectorRangeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorTypeListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRangeLevelList(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorRange> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorRange> InVectorTypeListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorRange> UsesVectorRangeLevelList { get; set; }

	}

	/*================================================================================================*/
	public class VectorRangeLevelBuilder : DomainBuilder<VectorRangeLevel> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelBuilder(IWeaverTransaction pTx, VectorRangeLevel pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelBuilder(IWeaverTransaction pTx, long pVectorRangeLevelId) :
			base(pTx, Node = new VectorRangeLevel() { VectorRangeLevelId = pVectorRangeLevelId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorRangeListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorRangeLevel> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorRangeLevel> InVectorRangeListUses { get; set; }

	}

	/*================================================================================================*/
	public class VectorUnitBuilder : DomainBuilder<VectorUnit> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitBuilder(IWeaverTransaction pTx, VectorUnit pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitBuilder(IWeaverTransaction pTx, long pVectorUnitId) :
			base(pTx, Node = new VectorUnit() { VectorUnitId = pVectorUnitId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorUnitDerivedListDefines(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorUnitDerivedListRaisesToExp(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnit> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnit> InVectorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnit> InVectorUnitDerivedListDefines { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnit> InVectorUnitDerivedListRaisesToExp { get; set; }

	}

	/*================================================================================================*/
	public class VectorUnitPrefixBuilder : DomainBuilder<VectorUnitPrefix> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixBuilder(IWeaverTransaction pTx, VectorUnitPrefix pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixBuilder(IWeaverTransaction pTx, long pVectorUnitPrefixId) :
			base(pTx, Node = new VectorUnitPrefix() { VectorUnitPrefixId = pVectorUnitPrefixId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorListUses(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInVectorUnitDerivedListUses(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitPrefix> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitPrefix> InVectorListUses { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitPrefix> InVectorUnitDerivedListUses { get; set; }

	}

	/*================================================================================================*/
	public class VectorUnitDerivedBuilder : DomainBuilder<VectorUnitDerived> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedBuilder(IWeaverTransaction pTx, VectorUnitDerived pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedBuilder(IWeaverTransaction pTx, long pVectorUnitDerivedId) :
			base(pTx, Node = new VectorUnitDerived() { VectorUnitDerivedId = pVectorUnitDerivedId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitDerived> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitDerived> DefinesVectorUnit { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitDerived> RaisesToExpVectorUnit { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<VectorUnitDerived> UsesVectorUnitPrefix { get; set; }

	}

	/*================================================================================================*/
	public class OauthAccessBuilder : DomainBuilder<OauthAccess> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(IWeaverTransaction pTx, OauthAccess pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(IWeaverTransaction pTx, long pOauthAccessId) :
			base(pTx, Node = new OauthAccess() { OauthAccessId = pOauthAccessId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthAccess> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthAccess> UsesApp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthAccess> UsesUser { get; set; }

	}

	/*================================================================================================*/
	public class OauthDomainBuilder : DomainBuilder<OauthDomain> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(IWeaverTransaction pTx, OauthDomain pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(IWeaverTransaction pTx, long pOauthDomainId) :
			base(pTx, Node = new OauthDomain() { OauthDomainId = pOauthDomainId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthDomain> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthDomain> UsesApp { get; set; }

	}

	/*================================================================================================*/
	public class OauthGrantBuilder : DomainBuilder<OauthGrant> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(IWeaverTransaction pTx, OauthGrant pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(IWeaverTransaction pTx, long pOauthGrantId) :
			base(pTx, Node = new OauthGrant() { OauthGrantId = pOauthGrantId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthGrant> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthGrant> UsesApp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthGrant> UsesUser { get; set; }

	}

	/*================================================================================================*/
	public class OauthScopeBuilder : DomainBuilder<OauthScope> {
	
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(IWeaverTransaction pTx, OauthScope pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(IWeaverTransaction pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(IWeaverTransaction pTx, long pOauthScopeId) :
			base(pTx, Node = new OauthScope() { OauthScopeId = pOauthScopeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInRootContains(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pNodeTypeId) {}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pNodeTypeId) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthScope> InRootContains { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthScope> UsesApp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IWeaverVarAlias<OauthScope> UsesUser { get; set; }

	}

}
