// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/5/2013 11:59:20 AM

using System;
using System.Linq.Expressions;
using Weaver.Items;
using Weaver.Interfaces;
using Fabric.Domain;
using System.Collections.Generic;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public class AppBuilder : DomainBuilder<App, RootContainsApp> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		public virtual IWeaverVarAlias<Email> UsesEmail { get; private set; }
		public virtual IList<IWeaverVarAlias<Member>> DefinesMemberList { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthAccess>> InOauthAccessListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthDomain>> InOauthDomainListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthGrant>> InOauthGrantListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthScope>> InOauthScopeListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(TxBuilder pTx, App pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(TxBuilder pTx, long pAppId) : 
			base(pTx, new App() { AppId = pAppId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<AppHasArtifact>(pTargetNodeVar, NodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(IWeaverVarAlias<Email> pTargetNodeVar) {
			TxBuild.AddRel<AppUsesEmail>(pTargetNodeVar, NodeVar);
			UsesEmail = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail, out IWeaverVarAlias<Email> pNodeVar) {
			TxBuild.GetNode(pEmail, out pNodeVar);
			SetUsesEmail(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId, out IWeaverVarAlias<Email> pNodeVar) {
			SetUsesEmail(new Email { EmailId = pEmailId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<AppDefinesMember>(pTargetNodeVar, NodeVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			AddDefinesMemberList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			AddDefinesMemberList(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesApp>(NodeVar, pTargetNodeVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			TxBuild.GetNode(pOauthAccess, out pNodeVar);
			AddInOauthAccessListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			AddInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(IWeaverVarAlias<OauthDomain> pTargetNodeVar) {
			TxBuild.AddRel<OauthDomainUsesApp>(NodeVar, pTargetNodeVar);
			InOauthDomainListUses = (InOauthDomainListUses ?? new List<IWeaverVarAlias<OauthDomain>>());
			InOauthDomainListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(OauthDomain pOauthDomain, out IWeaverVarAlias<OauthDomain> pNodeVar) {
			TxBuild.GetNode(pOauthDomain, out pNodeVar);
			AddInOauthDomainListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(long pOauthDomainId, out IWeaverVarAlias<OauthDomain> pNodeVar) {
			AddInOauthDomainListUses(new OauthDomain { OauthDomainId = pOauthDomainId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesApp>(NodeVar, pTargetNodeVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			TxBuild.GetNode(pOauthGrant, out pNodeVar);
			AddInOauthGrantListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			AddInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesApp>(NodeVar, pTargetNodeVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pNodeVar) {
			TxBuild.GetNode(pOauthScope, out pNodeVar);
			AddInOauthScopeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pNodeVar) {
			AddInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class ArtifactBuilder : DomainBuilder<Artifact, RootContainsArtifact> {

		public virtual IWeaverVarAlias<App> InAppHas { get; private set; }
		public virtual IWeaverVarAlias<ArtifactType> UsesArtifactType { get; private set; }
		public virtual IWeaverVarAlias<Crowd> InCrowdHas { get; private set; }
		public virtual IWeaverVarAlias<Label> InLabelHas { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IWeaverVarAlias<Thing> InThingHas { get; private set; }
		public virtual IWeaverVarAlias<Url> InUrlHas { get; private set; }
		public virtual IWeaverVarAlias<User> InUserHas { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUsesPrimary { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUsesRelated { get; private set; }
		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListRefinesPrimaryWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListRefinesRelatedWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListRefinesTypeWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Vector>> InVectorListUsesAxis { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx, Artifact pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx, long pArtifactId) : 
			base(pTx, new Artifact() { ArtifactId = pArtifactId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<AppHasArtifact>(NodeVar, pTargetNodeVar);
			InAppHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetInAppHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetInAppHas(new App { AppId = pAppId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(IWeaverVarAlias<ArtifactType> pTargetNodeVar) {
			TxBuild.AddRel<ArtifactUsesArtifactType>(pTargetNodeVar, NodeVar);
			UsesArtifactType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(ArtifactType pArtifactType, out IWeaverVarAlias<ArtifactType> pNodeVar) {
			TxBuild.GetNode(pArtifactType, out pNodeVar);
			SetUsesArtifactType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(byte pArtifactTypeId, out IWeaverVarAlias<ArtifactType> pNodeVar) {
			SetUsesArtifactType(new ArtifactType { ArtifactTypeId = pArtifactTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(IWeaverVarAlias<Crowd> pTargetNodeVar) {
			TxBuild.AddRel<CrowdHasArtifact>(NodeVar, pTargetNodeVar);
			InCrowdHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(Crowd pCrowd, out IWeaverVarAlias<Crowd> pNodeVar) {
			TxBuild.GetNode(pCrowd, out pNodeVar);
			SetInCrowdHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(long pCrowdId, out IWeaverVarAlias<Crowd> pNodeVar) {
			SetInCrowdHas(new Crowd { CrowdId = pCrowdId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(IWeaverVarAlias<Label> pTargetNodeVar) {
			TxBuild.AddRel<LabelHasArtifact>(NodeVar, pTargetNodeVar);
			InLabelHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(Label pLabel, out IWeaverVarAlias<Label> pNodeVar) {
			TxBuild.GetNode(pLabel, out pNodeVar);
			SetInLabelHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(long pLabelId, out IWeaverVarAlias<Label> pNodeVar) {
			SetInLabelHas(new Label { LabelId = pLabelId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesArtifact>(NodeVar, pTargetNodeVar);
			InMemberCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInThingHas(IWeaverVarAlias<Thing> pTargetNodeVar) {
			TxBuild.AddRel<ThingHasArtifact>(NodeVar, pTargetNodeVar);
			InThingHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInThingHas(Thing pThing, out IWeaverVarAlias<Thing> pNodeVar) {
			TxBuild.GetNode(pThing, out pNodeVar);
			SetInThingHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInThingHas(long pThingId, out IWeaverVarAlias<Thing> pNodeVar) {
			SetInThingHas(new Thing { ThingId = pThingId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(IWeaverVarAlias<Url> pTargetNodeVar) {
			TxBuild.AddRel<UrlHasArtifact>(NodeVar, pTargetNodeVar);
			InUrlHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(Url pUrl, out IWeaverVarAlias<Url> pNodeVar) {
			TxBuild.GetNode(pUrl, out pNodeVar);
			SetInUrlHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(long pUrlId, out IWeaverVarAlias<Url> pNodeVar) {
			SetInUrlHas(new Url { UrlId = pUrlId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserHasArtifact>(NodeVar, pTargetNodeVar);
			InUserHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserHas(new User { UserId = pUserId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesPrimaryArtifact>(NodeVar, pTargetNodeVar);
			InFactorListUsesPrimary = (InFactorListUsesPrimary ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesPrimary.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUsesPrimary(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUsesPrimary(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesRelatedArtifact>(NodeVar, pTargetNodeVar);
			InFactorListUsesRelated = (InFactorListUsesRelated ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesRelated.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUsesRelated(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUsesRelated(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesPrimaryWithArtifact>(NodeVar, pTargetNodeVar);
			InDescriptorListRefinesPrimaryWith = (InDescriptorListRefinesPrimaryWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesPrimaryWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListRefinesPrimaryWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListRefinesPrimaryWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesRelatedWithArtifact>(NodeVar, pTargetNodeVar);
			InDescriptorListRefinesRelatedWith = (InDescriptorListRefinesRelatedWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesRelatedWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListRefinesRelatedWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListRefinesRelatedWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesTypeWithArtifact>(NodeVar, pTargetNodeVar);
			InDescriptorListRefinesTypeWith = (InDescriptorListRefinesTypeWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesTypeWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListRefinesTypeWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListRefinesTypeWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesAxisArtifact>(NodeVar, pTargetNodeVar);
			InVectorListUsesAxis = (InVectorListUsesAxis ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUsesAxis.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUsesAxis(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUsesAxis(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class ArtifactTypeBuilder : DomainBuilder<ArtifactType, RootContainsArtifactType> {

		public virtual IList<IWeaverVarAlias<Artifact>> InArtifactListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeBuilder(TxBuilder pTx, ArtifactType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactTypeBuilder(TxBuilder pTx, byte pArtifactTypeId) : 
			base(pTx, new ArtifactType() { ArtifactTypeId = pArtifactTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<ArtifactUsesArtifactType>(NodeVar, pTargetNodeVar);
			InArtifactListUses = (InArtifactListUses ?? new List<IWeaverVarAlias<Artifact>>());
			InArtifactListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			AddInArtifactListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			AddInArtifactListUses(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class CrowdBuilder : DomainBuilder<Crowd, RootContainsCrowd> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		public virtual IList<IWeaverVarAlias<Crowdian>> DefinesCrowdianList { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdBuilder(TxBuilder pTx, Crowd pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdBuilder(TxBuilder pTx, long pCrowdId) : 
			base(pTx, new Crowd() { CrowdId = pCrowdId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<CrowdHasArtifact>(pTargetNodeVar, NodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<CrowdDefinesCrowdian>(pTargetNodeVar, NodeVar);
			DefinesCrowdianList = (DefinesCrowdianList ?? new List<IWeaverVarAlias<Crowdian>>());
			DefinesCrowdianList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			AddDefinesCrowdianList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			AddDefinesCrowdianList(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class CrowdianBuilder : DomainBuilder<Crowdian, RootContainsCrowdian> {

		public virtual IWeaverVarAlias<Crowd> InCrowdDefines { get; private set; }
		public virtual IWeaverVarAlias<CrowdianTypeAssign> HasCrowdianTypeAssign { get; private set; }
		public virtual IList<IWeaverVarAlias<CrowdianTypeAssign>> HasHistoricCrowdianTypeAssignList { get; private set; }
		public virtual IWeaverVarAlias<User> InUserDefines { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianBuilder(TxBuilder pTx, Crowdian pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianBuilder(TxBuilder pTx, long pCrowdianId) : 
			base(pTx, new Crowdian() { CrowdianId = pCrowdianId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(IWeaverVarAlias<Crowd> pTargetNodeVar) {
			TxBuild.AddRel<CrowdDefinesCrowdian>(NodeVar, pTargetNodeVar);
			InCrowdDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(Crowd pCrowd, out IWeaverVarAlias<Crowd> pNodeVar) {
			TxBuild.GetNode(pCrowd, out pNodeVar);
			SetInCrowdDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(long pCrowdId, out IWeaverVarAlias<Crowd> pNodeVar) {
			SetInCrowdDefines(new Crowd { CrowdId = pCrowdId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasCrowdianTypeAssign>(pTargetNodeVar, NodeVar);
			HasCrowdianTypeAssign = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			SetHasCrowdianTypeAssign(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			SetHasCrowdianTypeAssign(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasHistoricCrowdianTypeAssign>(pTargetNodeVar, NodeVar);
			HasHistoricCrowdianTypeAssignList = (HasHistoricCrowdianTypeAssignList ?? new List<IWeaverVarAlias<CrowdianTypeAssign>>());
			HasHistoricCrowdianTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			AddHasHistoricCrowdianTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			AddHasHistoricCrowdianTypeAssignList(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesCrowdian>(NodeVar, pTargetNodeVar);
			InUserDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserDefines(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class CrowdianTypeBuilder : DomainBuilder<CrowdianType, RootContainsCrowdianType> {

		public virtual IList<IWeaverVarAlias<CrowdianTypeAssign>> InCrowdianTypeAssignListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeBuilder(TxBuilder pTx, CrowdianType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeBuilder(TxBuilder pTx, byte pCrowdianTypeId) : 
			base(pTx, new CrowdianType() { CrowdianTypeId = pCrowdianTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianTypeAssignUsesCrowdianType>(NodeVar, pTargetNodeVar);
			InCrowdianTypeAssignListUses = (InCrowdianTypeAssignListUses ?? new List<IWeaverVarAlias<CrowdianTypeAssign>>());
			InCrowdianTypeAssignListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			AddInCrowdianTypeAssignListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			AddInCrowdianTypeAssignListUses(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class CrowdianTypeAssignBuilder : DomainBuilder<CrowdianTypeAssign, RootContainsCrowdianTypeAssign> {

		public virtual IWeaverVarAlias<Crowdian> InCrowdianHas { get; private set; }
		public virtual IWeaverVarAlias<Crowdian> InCrowdianHasHistoric { get; private set; }
		public virtual IWeaverVarAlias<CrowdianType> UsesCrowdianType { get; private set; }
		public virtual IWeaverVarAlias<User> InUserCreates { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignBuilder(TxBuilder pTx, CrowdianTypeAssign pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public CrowdianTypeAssignBuilder(TxBuilder pTx, long pCrowdianTypeAssignId) : 
			base(pTx, new CrowdianTypeAssign() { CrowdianTypeAssignId = pCrowdianTypeAssignId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasCrowdianTypeAssign>(NodeVar, pTargetNodeVar);
			InCrowdianHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			SetInCrowdianHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			SetInCrowdianHas(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasHistoricCrowdianTypeAssign>(NodeVar, pTargetNodeVar);
			InCrowdianHasHistoric = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			SetInCrowdianHasHistoric(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			SetInCrowdianHasHistoric(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(IWeaverVarAlias<CrowdianType> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianTypeAssignUsesCrowdianType>(pTargetNodeVar, NodeVar);
			UsesCrowdianType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(CrowdianType pCrowdianType, out IWeaverVarAlias<CrowdianType> pNodeVar) {
			TxBuild.GetNode(pCrowdianType, out pNodeVar);
			SetUsesCrowdianType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(byte pCrowdianTypeId, out IWeaverVarAlias<CrowdianType> pNodeVar) {
			SetUsesCrowdianType(new CrowdianType { CrowdianTypeId = pCrowdianTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserCreatesCrowdianTypeAssign>(NodeVar, pTargetNodeVar);
			InUserCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserCreates(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class EmailBuilder : DomainBuilder<Email, RootContainsEmail> {

		public virtual IWeaverVarAlias<App> InAppUses { get; private set; }
		public virtual IWeaverVarAlias<User> InUserUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx, Email pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx, long pEmailId) : 
			base(pTx, new Email() { EmailId = pEmailId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<AppUsesEmail>(NodeVar, pTargetNodeVar);
			InAppUses = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetInAppUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetInAppUses(new App { AppId = pAppId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserUsesEmail>(NodeVar, pTargetNodeVar);
			InUserUses = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserUses(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class LabelBuilder : DomainBuilder<Label, RootContainsLabel> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LabelBuilder(TxBuilder pTx, Label pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LabelBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LabelBuilder(TxBuilder pTx, long pLabelId) : 
			base(pTx, new Label() { LabelId = pLabelId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<LabelHasArtifact>(pTargetNodeVar, NodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class MemberBuilder : DomainBuilder<Member, RootContainsMember> {

		public virtual IWeaverVarAlias<App> InAppDefines { get; private set; }
		public virtual IWeaverVarAlias<MemberTypeAssign> HasMemberTypeAssign { get; private set; }
		public virtual IList<IWeaverVarAlias<MemberTypeAssign>> HasHistoricMemberTypeAssignList { get; private set; }
		public virtual IList<IWeaverVarAlias<Artifact>> CreatesArtifactList { get; private set; }
		public virtual IList<IWeaverVarAlias<MemberTypeAssign>> CreatesMemberTypeAssignList { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> CreatesFactorList { get; private set; }
		public virtual IWeaverVarAlias<User> InUserDefines { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(TxBuilder pTx, Member pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(TxBuilder pTx, long pMemberId) : 
			base(pTx, new Member() { MemberId = pMemberId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<AppDefinesMember>(NodeVar, pTargetNodeVar);
			InAppDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetInAppDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetInAppDefines(new App { AppId = pAppId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasMemberTypeAssign>(pTargetNodeVar, NodeVar);
			HasMemberTypeAssign = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			SetHasMemberTypeAssign(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			SetHasMemberTypeAssign(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasHistoricMemberTypeAssign>(pTargetNodeVar, NodeVar);
			HasHistoricMemberTypeAssignList = (HasHistoricMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			HasHistoricMemberTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddHasHistoricMemberTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddHasHistoricMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesArtifact>(pTargetNodeVar, NodeVar);
			CreatesArtifactList = (CreatesArtifactList ?? new List<IWeaverVarAlias<Artifact>>());
			CreatesArtifactList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			AddCreatesArtifactList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			AddCreatesArtifactList(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesMemberTypeAssign>(pTargetNodeVar, NodeVar);
			CreatesMemberTypeAssignList = (CreatesMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			CreatesMemberTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddCreatesMemberTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddCreatesMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesFactor>(pTargetNodeVar, NodeVar);
			CreatesFactorList = (CreatesFactorList ?? new List<IWeaverVarAlias<Factor>>());
			CreatesFactorList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddCreatesFactorList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddCreatesFactorList(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesMember>(NodeVar, pTargetNodeVar);
			InUserDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserDefines(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class MemberTypeBuilder : DomainBuilder<MemberType, RootContainsMemberType> {

		public virtual IList<IWeaverVarAlias<MemberTypeAssign>> InMemberTypeAssignListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeBuilder(TxBuilder pTx, MemberType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeBuilder(TxBuilder pTx, byte pMemberTypeId) : 
			base(pTx, new MemberType() { MemberTypeId = pMemberTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberTypeAssignUsesMemberType>(NodeVar, pTargetNodeVar);
			InMemberTypeAssignListUses = (InMemberTypeAssignListUses ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			InMemberTypeAssignListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddInMemberTypeAssignListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddInMemberTypeAssignListUses(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class MemberTypeAssignBuilder : DomainBuilder<MemberTypeAssign, RootContainsMemberTypeAssign> {

		public virtual IWeaverVarAlias<Member> InMemberHas { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberHasHistoric { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IWeaverVarAlias<MemberType> UsesMemberType { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx, MemberTypeAssign pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx, long pMemberTypeAssignId) : 
			base(pTx, new MemberTypeAssign() { MemberTypeAssignId = pMemberTypeAssignId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasMemberTypeAssign>(NodeVar, pTargetNodeVar);
			InMemberHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberHas(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasHistoricMemberTypeAssign>(NodeVar, pTargetNodeVar);
			InMemberHasHistoric = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberHasHistoric(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberHasHistoric(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesMemberTypeAssign>(NodeVar, pTargetNodeVar);
			InMemberCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(IWeaverVarAlias<MemberType> pTargetNodeVar) {
			TxBuild.AddRel<MemberTypeAssignUsesMemberType>(pTargetNodeVar, NodeVar);
			UsesMemberType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(MemberType pMemberType, out IWeaverVarAlias<MemberType> pNodeVar) {
			TxBuild.GetNode(pMemberType, out pNodeVar);
			SetUsesMemberType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(byte pMemberTypeId, out IWeaverVarAlias<MemberType> pNodeVar) {
			SetUsesMemberType(new MemberType { MemberTypeId = pMemberTypeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class ThingBuilder : DomainBuilder<Thing, RootContainsThing> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ThingBuilder(TxBuilder pTx, Thing pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ThingBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ThingBuilder(TxBuilder pTx, long pThingId) : 
			base(pTx, new Thing() { ThingId = pThingId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<ThingHasArtifact>(pTargetNodeVar, NodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class UrlBuilder : DomainBuilder<Url, RootContainsUrl> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx, Url pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx, long pUrlId) : 
			base(pTx, new Url() { UrlId = pUrlId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<UrlHasArtifact>(pTargetNodeVar, NodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class UserBuilder : DomainBuilder<User, RootContainsUser> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		public virtual IList<IWeaverVarAlias<CrowdianTypeAssign>> CreatesCrowdianTypeAssignList { get; private set; }
		public virtual IList<IWeaverVarAlias<Crowdian>> DefinesCrowdianList { get; private set; }
		public virtual IWeaverVarAlias<Email> UsesEmail { get; private set; }
		public virtual IList<IWeaverVarAlias<Member>> DefinesMemberList { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthAccess>> InOauthAccessListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthGrant>> InOauthGrantListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<OauthScope>> InOauthScopeListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(TxBuilder pTx, User pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(TxBuilder pTx, long pUserId) : 
			base(pTx, new User() { UserId = pUserId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<UserHasArtifact>(pTargetNodeVar, NodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<UserCreatesCrowdianTypeAssign>(pTargetNodeVar, NodeVar);
			CreatesCrowdianTypeAssignList = (CreatesCrowdianTypeAssignList ?? new List<IWeaverVarAlias<CrowdianTypeAssign>>());
			CreatesCrowdianTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			AddCreatesCrowdianTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			AddCreatesCrowdianTypeAssignList(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesCrowdian>(pTargetNodeVar, NodeVar);
			DefinesCrowdianList = (DefinesCrowdianList ?? new List<IWeaverVarAlias<Crowdian>>());
			DefinesCrowdianList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			AddDefinesCrowdianList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			AddDefinesCrowdianList(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(IWeaverVarAlias<Email> pTargetNodeVar) {
			TxBuild.AddRel<UserUsesEmail>(pTargetNodeVar, NodeVar);
			UsesEmail = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail, out IWeaverVarAlias<Email> pNodeVar) {
			TxBuild.GetNode(pEmail, out pNodeVar);
			SetUsesEmail(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId, out IWeaverVarAlias<Email> pNodeVar) {
			SetUsesEmail(new Email { EmailId = pEmailId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesMember>(pTargetNodeVar, NodeVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			AddDefinesMemberList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			AddDefinesMemberList(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesUser>(NodeVar, pTargetNodeVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			TxBuild.GetNode(pOauthAccess, out pNodeVar);
			AddInOauthAccessListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			AddInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesUser>(NodeVar, pTargetNodeVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			TxBuild.GetNode(pOauthGrant, out pNodeVar);
			AddInOauthGrantListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			AddInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesUser>(NodeVar, pTargetNodeVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pNodeVar) {
			TxBuild.GetNode(pOauthScope, out pNodeVar);
			AddInOauthScopeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pNodeVar) {
			AddInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class FactorBuilder : DomainBuilder<Factor, RootContainsFactor> {

		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesPrimaryArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesRelatedArtifact { get; private set; }
		public virtual IWeaverVarAlias<FactorAssertion> UsesFactorAssertion { get; private set; }
		public virtual IWeaverVarAlias<Factor> ReplacesFactor { get; private set; }
		public virtual IWeaverVarAlias<Descriptor> UsesDescriptor { get; private set; }
		public virtual IWeaverVarAlias<Director> UsesDirector { get; private set; }
		public virtual IWeaverVarAlias<Eventor> UsesEventor { get; private set; }
		public virtual IWeaverVarAlias<Identor> UsesIdentor { get; private set; }
		public virtual IWeaverVarAlias<Locator> UsesLocator { get; private set; }
		public virtual IWeaverVarAlias<Vector> UsesVector { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(TxBuilder pTx, Factor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(TxBuilder pTx, long pFactorId) : 
			base(pTx, new Factor() { FactorId = pFactorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesFactor>(NodeVar, pTargetNodeVar);
			InMemberCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesPrimaryArtifact>(pTargetNodeVar, NodeVar);
			UsesPrimaryArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetUsesPrimaryArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetUsesPrimaryArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesRelatedArtifact>(pTargetNodeVar, NodeVar);
			UsesRelatedArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetUsesRelatedArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetUsesRelatedArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(IWeaverVarAlias<FactorAssertion> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesFactorAssertion>(pTargetNodeVar, NodeVar);
			UsesFactorAssertion = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(FactorAssertion pFactorAssertion, out IWeaverVarAlias<FactorAssertion> pNodeVar) {
			TxBuild.GetNode(pFactorAssertion, out pNodeVar);
			SetUsesFactorAssertion(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(byte pFactorAssertionId, out IWeaverVarAlias<FactorAssertion> pNodeVar) {
			SetUsesFactorAssertion(new FactorAssertion { FactorAssertionId = pFactorAssertionId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorReplacesFactor>(pTargetNodeVar, NodeVar);
			ReplacesFactor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			SetReplacesFactor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			SetReplacesFactor(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDescriptor>(pTargetNodeVar, NodeVar);
			UsesDescriptor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			SetUsesDescriptor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			SetUsesDescriptor(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDirector>(pTargetNodeVar, NodeVar);
			UsesDirector = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			SetUsesDirector(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			SetUsesDirector(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(IWeaverVarAlias<Eventor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesEventor>(pTargetNodeVar, NodeVar);
			UsesEventor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(Eventor pEventor, out IWeaverVarAlias<Eventor> pNodeVar) {
			TxBuild.GetNode(pEventor, out pNodeVar);
			SetUsesEventor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(long pEventorId, out IWeaverVarAlias<Eventor> pNodeVar) {
			SetUsesEventor(new Eventor { EventorId = pEventorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(IWeaverVarAlias<Identor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesIdentor>(pTargetNodeVar, NodeVar);
			UsesIdentor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(Identor pIdentor, out IWeaverVarAlias<Identor> pNodeVar) {
			TxBuild.GetNode(pIdentor, out pNodeVar);
			SetUsesIdentor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(long pIdentorId, out IWeaverVarAlias<Identor> pNodeVar) {
			SetUsesIdentor(new Identor { IdentorId = pIdentorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(IWeaverVarAlias<Locator> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesLocator>(pTargetNodeVar, NodeVar);
			UsesLocator = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(Locator pLocator, out IWeaverVarAlias<Locator> pNodeVar) {
			TxBuild.GetNode(pLocator, out pNodeVar);
			SetUsesLocator(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(long pLocatorId, out IWeaverVarAlias<Locator> pNodeVar) {
			SetUsesLocator(new Locator { LocatorId = pLocatorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesVector>(pTargetNodeVar, NodeVar);
			UsesVector = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			SetUsesVector(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			SetUsesVector(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class FactorAssertionBuilder : DomainBuilder<FactorAssertion, RootContainsFactorAssertion> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionBuilder(TxBuilder pTx, FactorAssertion pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionBuilder(TxBuilder pTx, byte pFactorAssertionId) : 
			base(pTx, new FactorAssertion() { FactorAssertionId = pFactorAssertionId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesFactorAssertion>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class DescriptorBuilder : DomainBuilder<Descriptor, RootContainsDescriptor> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<DescriptorType> UsesDescriptorType { get; private set; }
		public virtual IWeaverVarAlias<Artifact> RefinesPrimaryWithArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> RefinesRelatedWithArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> RefinesTypeWithArtifact { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorBuilder(TxBuilder pTx, Descriptor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorBuilder(TxBuilder pTx, long pDescriptorId) : 
			base(pTx, new Descriptor() { DescriptorId = pDescriptorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDescriptor>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(IWeaverVarAlias<DescriptorType> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorUsesDescriptorType>(pTargetNodeVar, NodeVar);
			UsesDescriptorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(DescriptorType pDescriptorType, out IWeaverVarAlias<DescriptorType> pNodeVar) {
			TxBuild.GetNode(pDescriptorType, out pNodeVar);
			SetUsesDescriptorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(byte pDescriptorTypeId, out IWeaverVarAlias<DescriptorType> pNodeVar) {
			SetUsesDescriptorType(new DescriptorType { DescriptorTypeId = pDescriptorTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesPrimaryWithArtifact>(pTargetNodeVar, NodeVar);
			RefinesPrimaryWithArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetRefinesPrimaryWithArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetRefinesPrimaryWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesRelatedWithArtifact>(pTargetNodeVar, NodeVar);
			RefinesRelatedWithArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetRefinesRelatedWithArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetRefinesRelatedWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesTypeWithArtifact>(pTargetNodeVar, NodeVar);
			RefinesTypeWithArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetRefinesTypeWithArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetRefinesTypeWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class DescriptorTypeBuilder : DomainBuilder<DescriptorType, RootContainsDescriptorType> {

		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeBuilder(TxBuilder pTx, DescriptorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeBuilder(TxBuilder pTx, byte pDescriptorTypeId) : 
			base(pTx, new DescriptorType() { DescriptorTypeId = pDescriptorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorUsesDescriptorType>(NodeVar, pTargetNodeVar);
			InDescriptorListUses = (InDescriptorListUses ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListUses(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class DirectorBuilder : DomainBuilder<Director, RootContainsDirector> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<DirectorType> UsesDirectorType { get; private set; }
		public virtual IWeaverVarAlias<DirectorAction> UsesPrimaryDirectorAction { get; private set; }
		public virtual IWeaverVarAlias<DirectorAction> UsesRelatedDirectorAction { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(TxBuilder pTx, Director pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(TxBuilder pTx, long pDirectorId) : 
			base(pTx, new Director() { DirectorId = pDirectorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDirector>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(IWeaverVarAlias<DirectorType> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesDirectorType>(pTargetNodeVar, NodeVar);
			UsesDirectorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(DirectorType pDirectorType, out IWeaverVarAlias<DirectorType> pNodeVar) {
			TxBuild.GetNode(pDirectorType, out pNodeVar);
			SetUsesDirectorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(byte pDirectorTypeId, out IWeaverVarAlias<DirectorType> pNodeVar) {
			SetUsesDirectorType(new DirectorType { DirectorTypeId = pDirectorTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(IWeaverVarAlias<DirectorAction> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesPrimaryDirectorAction>(pTargetNodeVar, NodeVar);
			UsesPrimaryDirectorAction = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(DirectorAction pDirectorAction, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			TxBuild.GetNode(pDirectorAction, out pNodeVar);
			SetUsesPrimaryDirectorAction(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(byte pDirectorActionId, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			SetUsesPrimaryDirectorAction(new DirectorAction { DirectorActionId = pDirectorActionId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(IWeaverVarAlias<DirectorAction> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesRelatedDirectorAction>(pTargetNodeVar, NodeVar);
			UsesRelatedDirectorAction = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(DirectorAction pDirectorAction, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			TxBuild.GetNode(pDirectorAction, out pNodeVar);
			SetUsesRelatedDirectorAction(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(byte pDirectorActionId, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			SetUsesRelatedDirectorAction(new DirectorAction { DirectorActionId = pDirectorActionId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class DirectorTypeBuilder : DomainBuilder<DirectorType, RootContainsDirectorType> {

		public virtual IList<IWeaverVarAlias<Director>> InDirectorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeBuilder(TxBuilder pTx, DirectorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeBuilder(TxBuilder pTx, byte pDirectorTypeId) : 
			base(pTx, new DirectorType() { DirectorTypeId = pDirectorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesDirectorType>(NodeVar, pTargetNodeVar);
			InDirectorListUses = (InDirectorListUses ?? new List<IWeaverVarAlias<Director>>());
			InDirectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			AddInDirectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			AddInDirectorListUses(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class DirectorActionBuilder : DomainBuilder<DirectorAction, RootContainsDirectorAction> {

		public virtual IList<IWeaverVarAlias<Director>> InDirectorListUsesPrimary { get; private set; }
		public virtual IList<IWeaverVarAlias<Director>> InDirectorListUsesRelated { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionBuilder(TxBuilder pTx, DirectorAction pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionBuilder(TxBuilder pTx, byte pDirectorActionId) : 
			base(pTx, new DirectorAction() { DirectorActionId = pDirectorActionId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesPrimaryDirectorAction>(NodeVar, pTargetNodeVar);
			InDirectorListUsesPrimary = (InDirectorListUsesPrimary ?? new List<IWeaverVarAlias<Director>>());
			InDirectorListUsesPrimary.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			AddInDirectorListUsesPrimary(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			AddInDirectorListUsesPrimary(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesRelatedDirectorAction>(NodeVar, pTargetNodeVar);
			InDirectorListUsesRelated = (InDirectorListUsesRelated ?? new List<IWeaverVarAlias<Director>>());
			InDirectorListUsesRelated.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			AddInDirectorListUsesRelated(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			AddInDirectorListUsesRelated(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class EventorBuilder : DomainBuilder<Eventor, RootContainsEventor> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<EventorType> UsesEventorType { get; private set; }
		public virtual IWeaverVarAlias<EventorPrecision> UsesEventorPrecision { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(TxBuilder pTx, Eventor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(TxBuilder pTx, long pEventorId) : 
			base(pTx, new Eventor() { EventorId = pEventorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesEventor>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(IWeaverVarAlias<EventorType> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorType>(pTargetNodeVar, NodeVar);
			UsesEventorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(EventorType pEventorType, out IWeaverVarAlias<EventorType> pNodeVar) {
			TxBuild.GetNode(pEventorType, out pNodeVar);
			SetUsesEventorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(byte pEventorTypeId, out IWeaverVarAlias<EventorType> pNodeVar) {
			SetUsesEventorType(new EventorType { EventorTypeId = pEventorTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(IWeaverVarAlias<EventorPrecision> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorPrecision>(pTargetNodeVar, NodeVar);
			UsesEventorPrecision = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(EventorPrecision pEventorPrecision, out IWeaverVarAlias<EventorPrecision> pNodeVar) {
			TxBuild.GetNode(pEventorPrecision, out pNodeVar);
			SetUsesEventorPrecision(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(byte pEventorPrecisionId, out IWeaverVarAlias<EventorPrecision> pNodeVar) {
			SetUsesEventorPrecision(new EventorPrecision { EventorPrecisionId = pEventorPrecisionId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class EventorTypeBuilder : DomainBuilder<EventorType, RootContainsEventorType> {

		public virtual IList<IWeaverVarAlias<Eventor>> InEventorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeBuilder(TxBuilder pTx, EventorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeBuilder(TxBuilder pTx, byte pEventorTypeId) : 
			base(pTx, new EventorType() { EventorTypeId = pEventorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(IWeaverVarAlias<Eventor> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorType>(NodeVar, pTargetNodeVar);
			InEventorListUses = (InEventorListUses ?? new List<IWeaverVarAlias<Eventor>>());
			InEventorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(Eventor pEventor, out IWeaverVarAlias<Eventor> pNodeVar) {
			TxBuild.GetNode(pEventor, out pNodeVar);
			AddInEventorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(long pEventorId, out IWeaverVarAlias<Eventor> pNodeVar) {
			AddInEventorListUses(new Eventor { EventorId = pEventorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class EventorPrecisionBuilder : DomainBuilder<EventorPrecision, RootContainsEventorPrecision> {

		public virtual IList<IWeaverVarAlias<Eventor>> InEventorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionBuilder(TxBuilder pTx, EventorPrecision pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorPrecisionBuilder(TxBuilder pTx, byte pEventorPrecisionId) : 
			base(pTx, new EventorPrecision() { EventorPrecisionId = pEventorPrecisionId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(IWeaverVarAlias<Eventor> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorPrecision>(NodeVar, pTargetNodeVar);
			InEventorListUses = (InEventorListUses ?? new List<IWeaverVarAlias<Eventor>>());
			InEventorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(Eventor pEventor, out IWeaverVarAlias<Eventor> pNodeVar) {
			TxBuild.GetNode(pEventor, out pNodeVar);
			AddInEventorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(long pEventorId, out IWeaverVarAlias<Eventor> pNodeVar) {
			AddInEventorListUses(new Eventor { EventorId = pEventorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class IdentorBuilder : DomainBuilder<Identor, RootContainsIdentor> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<IdentorType> UsesIdentorType { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(TxBuilder pTx, Identor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(TxBuilder pTx, long pIdentorId) : 
			base(pTx, new Identor() { IdentorId = pIdentorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesIdentor>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(IWeaverVarAlias<IdentorType> pTargetNodeVar) {
			TxBuild.AddRel<IdentorUsesIdentorType>(pTargetNodeVar, NodeVar);
			UsesIdentorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(IdentorType pIdentorType, out IWeaverVarAlias<IdentorType> pNodeVar) {
			TxBuild.GetNode(pIdentorType, out pNodeVar);
			SetUsesIdentorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(byte pIdentorTypeId, out IWeaverVarAlias<IdentorType> pNodeVar) {
			SetUsesIdentorType(new IdentorType { IdentorTypeId = pIdentorTypeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class IdentorTypeBuilder : DomainBuilder<IdentorType, RootContainsIdentorType> {

		public virtual IList<IWeaverVarAlias<Identor>> InIdentorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeBuilder(TxBuilder pTx, IdentorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeBuilder(TxBuilder pTx, byte pIdentorTypeId) : 
			base(pTx, new IdentorType() { IdentorTypeId = pIdentorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(IWeaverVarAlias<Identor> pTargetNodeVar) {
			TxBuild.AddRel<IdentorUsesIdentorType>(NodeVar, pTargetNodeVar);
			InIdentorListUses = (InIdentorListUses ?? new List<IWeaverVarAlias<Identor>>());
			InIdentorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(Identor pIdentor, out IWeaverVarAlias<Identor> pNodeVar) {
			TxBuild.GetNode(pIdentor, out pNodeVar);
			AddInIdentorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(long pIdentorId, out IWeaverVarAlias<Identor> pNodeVar) {
			AddInIdentorListUses(new Identor { IdentorId = pIdentorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class LocatorBuilder : DomainBuilder<Locator, RootContainsLocator> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<LocatorType> UsesLocatorType { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(TxBuilder pTx, Locator pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(TxBuilder pTx, long pLocatorId) : 
			base(pTx, new Locator() { LocatorId = pLocatorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesLocator>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(IWeaverVarAlias<LocatorType> pTargetNodeVar) {
			TxBuild.AddRel<LocatorUsesLocatorType>(pTargetNodeVar, NodeVar);
			UsesLocatorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(LocatorType pLocatorType, out IWeaverVarAlias<LocatorType> pNodeVar) {
			TxBuild.GetNode(pLocatorType, out pNodeVar);
			SetUsesLocatorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(byte pLocatorTypeId, out IWeaverVarAlias<LocatorType> pNodeVar) {
			SetUsesLocatorType(new LocatorType { LocatorTypeId = pLocatorTypeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class LocatorTypeBuilder : DomainBuilder<LocatorType, RootContainsLocatorType> {

		public virtual IList<IWeaverVarAlias<Locator>> InLocatorListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeBuilder(TxBuilder pTx, LocatorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorTypeBuilder(TxBuilder pTx, byte pLocatorTypeId) : 
			base(pTx, new LocatorType() { LocatorTypeId = pLocatorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(IWeaverVarAlias<Locator> pTargetNodeVar) {
			TxBuild.AddRel<LocatorUsesLocatorType>(NodeVar, pTargetNodeVar);
			InLocatorListUses = (InLocatorListUses ?? new List<IWeaverVarAlias<Locator>>());
			InLocatorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(Locator pLocator, out IWeaverVarAlias<Locator> pNodeVar) {
			TxBuild.GetNode(pLocator, out pNodeVar);
			AddInLocatorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(long pLocatorId, out IWeaverVarAlias<Locator> pNodeVar) {
			AddInLocatorListUses(new Locator { LocatorId = pLocatorId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorBuilder : DomainBuilder<Vector, RootContainsVector> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesAxisArtifact { get; private set; }
		public virtual IWeaverVarAlias<VectorType> UsesVectorType { get; private set; }
		public virtual IWeaverVarAlias<VectorUnit> UsesVectorUnit { get; private set; }
		public virtual IWeaverVarAlias<VectorUnitPrefix> UsesVectorUnitPrefix { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(TxBuilder pTx, Vector pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(TxBuilder pTx, long pVectorId) : 
			base(pTx, new Vector() { VectorId = pVectorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesVector>(NodeVar, pTargetNodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesAxisArtifact>(pTargetNodeVar, NodeVar);
			UsesAxisArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetUsesAxisArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetUsesAxisArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(IWeaverVarAlias<VectorType> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorType>(pTargetNodeVar, NodeVar);
			UsesVectorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(VectorType pVectorType, out IWeaverVarAlias<VectorType> pNodeVar) {
			TxBuild.GetNode(pVectorType, out pNodeVar);
			SetUsesVectorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(byte pVectorTypeId, out IWeaverVarAlias<VectorType> pNodeVar) {
			SetUsesVectorType(new VectorType { VectorTypeId = pVectorTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(IWeaverVarAlias<VectorUnit> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnit>(pTargetNodeVar, NodeVar);
			UsesVectorUnit = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(VectorUnit pVectorUnit, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			TxBuild.GetNode(pVectorUnit, out pNodeVar);
			SetUsesVectorUnit(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(byte pVectorUnitId, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			SetUsesVectorUnit(new VectorUnit { VectorUnitId = pVectorUnitId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(IWeaverVarAlias<VectorUnitPrefix> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnitPrefix>(pTargetNodeVar, NodeVar);
			UsesVectorUnitPrefix = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(VectorUnitPrefix pVectorUnitPrefix, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			TxBuild.GetNode(pVectorUnitPrefix, out pNodeVar);
			SetUsesVectorUnitPrefix(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(byte pVectorUnitPrefixId, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			SetUsesVectorUnitPrefix(new VectorUnitPrefix { VectorUnitPrefixId = pVectorUnitPrefixId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorTypeBuilder : DomainBuilder<VectorType, RootContainsVectorType> {

		public virtual IList<IWeaverVarAlias<Vector>> InVectorListUses { get; private set; }
		public virtual IWeaverVarAlias<VectorRange> UsesVectorRange { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeBuilder(TxBuilder pTx, VectorType pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorTypeBuilder(TxBuilder pTx, byte pVectorTypeId) : 
			base(pTx, new VectorType() { VectorTypeId = pVectorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorType>(NodeVar, pTargetNodeVar);
			InVectorListUses = (InVectorListUses ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUses(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(IWeaverVarAlias<VectorRange> pTargetNodeVar) {
			TxBuild.AddRel<VectorTypeUsesVectorRange>(pTargetNodeVar, NodeVar);
			UsesVectorRange = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(VectorRange pVectorRange, out IWeaverVarAlias<VectorRange> pNodeVar) {
			TxBuild.GetNode(pVectorRange, out pNodeVar);
			SetUsesVectorRange(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(byte pVectorRangeId, out IWeaverVarAlias<VectorRange> pNodeVar) {
			SetUsesVectorRange(new VectorRange { VectorRangeId = pVectorRangeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorRangeBuilder : DomainBuilder<VectorRange, RootContainsVectorRange> {

		public virtual IList<IWeaverVarAlias<VectorType>> InVectorTypeListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<VectorRangeLevel>> UsesVectorRangeLevelList { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeBuilder(TxBuilder pTx, VectorRange pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeBuilder(TxBuilder pTx, byte pVectorRangeId) : 
			base(pTx, new VectorRange() { VectorRangeId = pVectorRangeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(IWeaverVarAlias<VectorType> pTargetNodeVar) {
			TxBuild.AddRel<VectorTypeUsesVectorRange>(NodeVar, pTargetNodeVar);
			InVectorTypeListUses = (InVectorTypeListUses ?? new List<IWeaverVarAlias<VectorType>>());
			InVectorTypeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(VectorType pVectorType, out IWeaverVarAlias<VectorType> pNodeVar) {
			TxBuild.GetNode(pVectorType, out pNodeVar);
			AddInVectorTypeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(byte pVectorTypeId, out IWeaverVarAlias<VectorType> pNodeVar) {
			AddInVectorTypeListUses(new VectorType { VectorTypeId = pVectorTypeId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(IWeaverVarAlias<VectorRangeLevel> pTargetNodeVar) {
			TxBuild.AddRel<VectorRangeUsesVectorRangeLevel>(pTargetNodeVar, NodeVar);
			UsesVectorRangeLevelList = (UsesVectorRangeLevelList ?? new List<IWeaverVarAlias<VectorRangeLevel>>());
			UsesVectorRangeLevelList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(VectorRangeLevel pVectorRangeLevel, out IWeaverVarAlias<VectorRangeLevel> pNodeVar) {
			TxBuild.GetNode(pVectorRangeLevel, out pNodeVar);
			AddUsesVectorRangeLevelList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(byte pVectorRangeLevelId, out IWeaverVarAlias<VectorRangeLevel> pNodeVar) {
			AddUsesVectorRangeLevelList(new VectorRangeLevel { VectorRangeLevelId = pVectorRangeLevelId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorRangeLevelBuilder : DomainBuilder<VectorRangeLevel, RootContainsVectorRangeLevel> {

		public virtual IList<IWeaverVarAlias<VectorRange>> InVectorRangeListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelBuilder(TxBuilder pTx, VectorRangeLevel pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelBuilder(TxBuilder pTx, byte pVectorRangeLevelId) : 
			base(pTx, new VectorRangeLevel() { VectorRangeLevelId = pVectorRangeLevelId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(IWeaverVarAlias<VectorRange> pTargetNodeVar) {
			TxBuild.AddRel<VectorRangeUsesVectorRangeLevel>(NodeVar, pTargetNodeVar);
			InVectorRangeListUses = (InVectorRangeListUses ?? new List<IWeaverVarAlias<VectorRange>>());
			InVectorRangeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(VectorRange pVectorRange, out IWeaverVarAlias<VectorRange> pNodeVar) {
			TxBuild.GetNode(pVectorRange, out pNodeVar);
			AddInVectorRangeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(byte pVectorRangeId, out IWeaverVarAlias<VectorRange> pNodeVar) {
			AddInVectorRangeListUses(new VectorRange { VectorRangeId = pVectorRangeId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorUnitBuilder : DomainBuilder<VectorUnit, RootContainsVectorUnit> {

		public virtual IList<IWeaverVarAlias<Vector>> InVectorListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<VectorUnitDerived>> InVectorUnitDerivedListDefines { get; private set; }
		public virtual IList<IWeaverVarAlias<VectorUnitDerived>> InVectorUnitDerivedListRaisesToExp { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitBuilder(TxBuilder pTx, VectorUnit pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitBuilder(TxBuilder pTx, byte pVectorUnitId) : 
			base(pTx, new VectorUnit() { VectorUnitId = pVectorUnitId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnit>(NodeVar, pTargetNodeVar);
			InVectorListUses = (InVectorListUses ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUses(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(IWeaverVarAlias<VectorUnitDerived> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedDefinesVectorUnit>(NodeVar, pTargetNodeVar);
			InVectorUnitDerivedListDefines = (InVectorUnitDerivedListDefines ?? new List<IWeaverVarAlias<VectorUnitDerived>>());
			InVectorUnitDerivedListDefines.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(VectorUnitDerived pVectorUnitDerived, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			TxBuild.GetNode(pVectorUnitDerived, out pNodeVar);
			AddInVectorUnitDerivedListDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(byte pVectorUnitDerivedId, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			AddInVectorUnitDerivedListDefines(new VectorUnitDerived { VectorUnitDerivedId = pVectorUnitDerivedId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(IWeaverVarAlias<VectorUnitDerived> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedRaisesToExpVectorUnit>(NodeVar, pTargetNodeVar);
			InVectorUnitDerivedListRaisesToExp = (InVectorUnitDerivedListRaisesToExp ?? new List<IWeaverVarAlias<VectorUnitDerived>>());
			InVectorUnitDerivedListRaisesToExp.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(VectorUnitDerived pVectorUnitDerived, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			TxBuild.GetNode(pVectorUnitDerived, out pNodeVar);
			AddInVectorUnitDerivedListRaisesToExp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(byte pVectorUnitDerivedId, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			AddInVectorUnitDerivedListRaisesToExp(new VectorUnitDerived { VectorUnitDerivedId = pVectorUnitDerivedId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorUnitPrefixBuilder : DomainBuilder<VectorUnitPrefix, RootContainsVectorUnitPrefix> {

		public virtual IList<IWeaverVarAlias<Vector>> InVectorListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<VectorUnitDerived>> InVectorUnitDerivedListUses { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixBuilder(TxBuilder pTx, VectorUnitPrefix pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitPrefixBuilder(TxBuilder pTx, byte pVectorUnitPrefixId) : 
			base(pTx, new VectorUnitPrefix() { VectorUnitPrefixId = pVectorUnitPrefixId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnitPrefix>(NodeVar, pTargetNodeVar);
			InVectorListUses = (InVectorListUses ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUses(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(IWeaverVarAlias<VectorUnitDerived> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedUsesVectorUnitPrefix>(NodeVar, pTargetNodeVar);
			InVectorUnitDerivedListUses = (InVectorUnitDerivedListUses ?? new List<IWeaverVarAlias<VectorUnitDerived>>());
			InVectorUnitDerivedListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(VectorUnitDerived pVectorUnitDerived, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			TxBuild.GetNode(pVectorUnitDerived, out pNodeVar);
			AddInVectorUnitDerivedListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(byte pVectorUnitDerivedId, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			AddInVectorUnitDerivedListUses(new VectorUnitDerived { VectorUnitDerivedId = pVectorUnitDerivedId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorUnitDerivedBuilder : DomainBuilder<VectorUnitDerived, RootContainsVectorUnitDerived> {

		public virtual IWeaverVarAlias<VectorUnit> DefinesVectorUnit { get; private set; }
		public virtual IWeaverVarAlias<VectorUnit> RaisesToExpVectorUnit { get; private set; }
		public virtual IWeaverVarAlias<VectorUnitPrefix> UsesVectorUnitPrefix { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedBuilder(TxBuilder pTx, VectorUnitDerived pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorUnitDerivedBuilder(TxBuilder pTx, byte pVectorUnitDerivedId) : 
			base(pTx, new VectorUnitDerived() { VectorUnitDerivedId = pVectorUnitDerivedId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(IWeaverVarAlias<VectorUnit> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedDefinesVectorUnit>(pTargetNodeVar, NodeVar);
			DefinesVectorUnit = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(VectorUnit pVectorUnit, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			TxBuild.GetNode(pVectorUnit, out pNodeVar);
			SetDefinesVectorUnit(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(byte pVectorUnitId, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			SetDefinesVectorUnit(new VectorUnit { VectorUnitId = pVectorUnitId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(IWeaverVarAlias<VectorUnit> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedRaisesToExpVectorUnit>(pTargetNodeVar, NodeVar);
			RaisesToExpVectorUnit = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(VectorUnit pVectorUnit, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			TxBuild.GetNode(pVectorUnit, out pNodeVar);
			SetRaisesToExpVectorUnit(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(byte pVectorUnitId, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			SetRaisesToExpVectorUnit(new VectorUnit { VectorUnitId = pVectorUnitId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(IWeaverVarAlias<VectorUnitPrefix> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedUsesVectorUnitPrefix>(pTargetNodeVar, NodeVar);
			UsesVectorUnitPrefix = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(VectorUnitPrefix pVectorUnitPrefix, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			TxBuild.GetNode(pVectorUnitPrefix, out pNodeVar);
			SetUsesVectorUnitPrefix(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(byte pVectorUnitPrefixId, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			SetUsesVectorUnitPrefix(new VectorUnitPrefix { VectorUnitPrefixId = pVectorUnitPrefixId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthAccessBuilder : DomainBuilder<OauthAccess, RootContainsOauthAccess> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx, OauthAccess pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx, long pOauthAccessId) : 
			base(pTx, new OauthAccess() { OauthAccessId = pOauthAccessId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesApp>(pTargetNodeVar, NodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesUser>(pTargetNodeVar, NodeVar);
			UsesUser = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetUsesUser(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetUsesUser(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthDomainBuilder : DomainBuilder<OauthDomain, RootContainsOauthDomain> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx, OauthDomain pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx, long pOauthDomainId) : 
			base(pTx, new OauthDomain() { OauthDomainId = pOauthDomainId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<OauthDomainUsesApp>(pTargetNodeVar, NodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthGrantBuilder : DomainBuilder<OauthGrant, RootContainsOauthGrant> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx, OauthGrant pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx, long pOauthGrantId) : 
			base(pTx, new OauthGrant() { OauthGrantId = pOauthGrantId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesApp>(pTargetNodeVar, NodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesUser>(pTargetNodeVar, NodeVar);
			UsesUser = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetUsesUser(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetUsesUser(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthScopeBuilder : DomainBuilder<OauthScope, RootContainsOauthScope> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx, OauthScope pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx, long pOauthScopeId) : 
			base(pTx, new OauthScope() { OauthScopeId = pOauthScopeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesApp>(pTargetNodeVar, NodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesUser>(pTargetNodeVar, NodeVar);
			UsesUser = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetUsesUser(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetUsesUser(new User { UserId = pUserId }, out pNodeVar);
		}
		

	}

}
