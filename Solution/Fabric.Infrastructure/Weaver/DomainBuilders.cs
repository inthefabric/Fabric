// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/25/2013 2:43:15 PM

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
			TxBuild.AddRel<AppHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(IWeaverVarAlias<Email> pTargetNodeVar) {
			TxBuild.AddRel<AppUsesEmail>(NodeVar, pTargetNodeVar);
			UsesEmail = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail, out IWeaverVarAlias<Email> pNodeVar) {
			TxBuild.GetNode(pEmail, out pNodeVar);
			SetUsesEmail(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail) {
			IWeaverVarAlias<Email> nodeVar;
			SetUsesEmail(pEmail, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId, out IWeaverVarAlias<Email> pNodeVar) {
			SetUsesEmail(new Email { EmailId = pEmailId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId) {
			IWeaverVarAlias<Email> nodeVar;
			SetUsesEmail(pEmailId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<AppDefinesMember>(NodeVar, pTargetNodeVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			AddDefinesMemberList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			AddDefinesMemberList(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			AddDefinesMemberList(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			AddDefinesMemberList(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesApp>(pTargetNodeVar, NodeVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			TxBuild.GetNode(pOauthAccess, out pNodeVar);
			AddInOauthAccessListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(OauthAccess pOauthAccess) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddInOauthAccessListUses(pOauthAccess, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			AddInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(long pOauthAccessId) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddInOauthAccessListUses(pOauthAccessId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(IWeaverVarAlias<OauthDomain> pTargetNodeVar) {
			TxBuild.AddRel<OauthDomainUsesApp>(pTargetNodeVar, NodeVar);
			InOauthDomainListUses = (InOauthDomainListUses ?? new List<IWeaverVarAlias<OauthDomain>>());
			InOauthDomainListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(OauthDomain pOauthDomain, out IWeaverVarAlias<OauthDomain> pNodeVar) {
			TxBuild.GetNode(pOauthDomain, out pNodeVar);
			AddInOauthDomainListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(OauthDomain pOauthDomain) {
			IWeaverVarAlias<OauthDomain> nodeVar;
			AddInOauthDomainListUses(pOauthDomain, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(long pOauthDomainId, out IWeaverVarAlias<OauthDomain> pNodeVar) {
			AddInOauthDomainListUses(new OauthDomain { OauthDomainId = pOauthDomainId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthDomainListUses(long pOauthDomainId) {
			IWeaverVarAlias<OauthDomain> nodeVar;
			AddInOauthDomainListUses(pOauthDomainId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesApp>(pTargetNodeVar, NodeVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			TxBuild.GetNode(pOauthGrant, out pNodeVar);
			AddInOauthGrantListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(OauthGrant pOauthGrant) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddInOauthGrantListUses(pOauthGrant, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			AddInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(long pOauthGrantId) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddInOauthGrantListUses(pOauthGrantId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesApp>(pTargetNodeVar, NodeVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pNodeVar) {
			TxBuild.GetNode(pOauthScope, out pNodeVar);
			AddInOauthScopeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(OauthScope pOauthScope) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddInOauthScopeListUses(pOauthScope, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pNodeVar) {
			AddInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(long pOauthScopeId) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddInOauthScopeListUses(pOauthScopeId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class ArtifactBuilder : DomainBuilder<Artifact, RootContainsArtifact> {

		public virtual IWeaverVarAlias<App> InAppHas { get; private set; }
		public virtual IWeaverVarAlias<ArtifactType> UsesArtifactType { get; private set; }
		public virtual IWeaverVarAlias<Class> InClassHas { get; private set; }
		public virtual IWeaverVarAlias<Crowd> InCrowdHas { get; private set; }
		public virtual IWeaverVarAlias<Instance> InInstanceHas { get; private set; }
		public virtual IWeaverVarAlias<Label> InLabelHas { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
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
			TxBuild.AddRel<AppHasArtifact>(pTargetNodeVar, NodeVar);
			InAppHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetInAppHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetInAppHas(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetInAppHas(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppHas(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetInAppHas(pAppId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(IWeaverVarAlias<ArtifactType> pTargetNodeVar) {
			TxBuild.AddRel<ArtifactUsesArtifactType>(NodeVar, pTargetNodeVar);
			UsesArtifactType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(ArtifactType pArtifactType, out IWeaverVarAlias<ArtifactType> pNodeVar) {
			TxBuild.GetNode(pArtifactType, out pNodeVar);
			SetUsesArtifactType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(ArtifactType pArtifactType) {
			IWeaverVarAlias<ArtifactType> nodeVar;
			SetUsesArtifactType(pArtifactType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(long pArtifactTypeId, out IWeaverVarAlias<ArtifactType> pNodeVar) {
			SetUsesArtifactType(new ArtifactType { ArtifactTypeId = pArtifactTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesArtifactType(long pArtifactTypeId) {
			IWeaverVarAlias<ArtifactType> nodeVar;
			SetUsesArtifactType(pArtifactTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInClassHas(IWeaverVarAlias<Class> pTargetNodeVar) {
			TxBuild.AddRel<ClassHasArtifact>(pTargetNodeVar, NodeVar);
			InClassHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInClassHas(Class pClass, out IWeaverVarAlias<Class> pNodeVar) {
			TxBuild.GetNode(pClass, out pNodeVar);
			SetInClassHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInClassHas(Class pClass) {
			IWeaverVarAlias<Class> nodeVar;
			SetInClassHas(pClass, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInClassHas(long pClassId, out IWeaverVarAlias<Class> pNodeVar) {
			SetInClassHas(new Class { ClassId = pClassId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInClassHas(long pClassId) {
			IWeaverVarAlias<Class> nodeVar;
			SetInClassHas(pClassId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(IWeaverVarAlias<Crowd> pTargetNodeVar) {
			TxBuild.AddRel<CrowdHasArtifact>(pTargetNodeVar, NodeVar);
			InCrowdHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(Crowd pCrowd, out IWeaverVarAlias<Crowd> pNodeVar) {
			TxBuild.GetNode(pCrowd, out pNodeVar);
			SetInCrowdHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(Crowd pCrowd) {
			IWeaverVarAlias<Crowd> nodeVar;
			SetInCrowdHas(pCrowd, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(long pCrowdId, out IWeaverVarAlias<Crowd> pNodeVar) {
			SetInCrowdHas(new Crowd { CrowdId = pCrowdId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdHas(long pCrowdId) {
			IWeaverVarAlias<Crowd> nodeVar;
			SetInCrowdHas(pCrowdId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInInstanceHas(IWeaverVarAlias<Instance> pTargetNodeVar) {
			TxBuild.AddRel<InstanceHasArtifact>(pTargetNodeVar, NodeVar);
			InInstanceHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInInstanceHas(Instance pInstance, out IWeaverVarAlias<Instance> pNodeVar) {
			TxBuild.GetNode(pInstance, out pNodeVar);
			SetInInstanceHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInInstanceHas(Instance pInstance) {
			IWeaverVarAlias<Instance> nodeVar;
			SetInInstanceHas(pInstance, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInInstanceHas(long pInstanceId, out IWeaverVarAlias<Instance> pNodeVar) {
			SetInInstanceHas(new Instance { InstanceId = pInstanceId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInInstanceHas(long pInstanceId) {
			IWeaverVarAlias<Instance> nodeVar;
			SetInInstanceHas(pInstanceId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(IWeaverVarAlias<Label> pTargetNodeVar) {
			TxBuild.AddRel<LabelHasArtifact>(pTargetNodeVar, NodeVar);
			InLabelHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(Label pLabel, out IWeaverVarAlias<Label> pNodeVar) {
			TxBuild.GetNode(pLabel, out pNodeVar);
			SetInLabelHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(Label pLabel) {
			IWeaverVarAlias<Label> nodeVar;
			SetInLabelHas(pLabel, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(long pLabelId, out IWeaverVarAlias<Label> pNodeVar) {
			SetInLabelHas(new Label { LabelId = pLabelId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInLabelHas(long pLabelId) {
			IWeaverVarAlias<Label> nodeVar;
			SetInLabelHas(pLabelId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesArtifact>(pTargetNodeVar, NodeVar);
			InMemberCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberCreates(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberCreates(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(IWeaverVarAlias<Url> pTargetNodeVar) {
			TxBuild.AddRel<UrlHasArtifact>(pTargetNodeVar, NodeVar);
			InUrlHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(Url pUrl, out IWeaverVarAlias<Url> pNodeVar) {
			TxBuild.GetNode(pUrl, out pNodeVar);
			SetInUrlHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(Url pUrl) {
			IWeaverVarAlias<Url> nodeVar;
			SetInUrlHas(pUrl, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(long pUrlId, out IWeaverVarAlias<Url> pNodeVar) {
			SetInUrlHas(new Url { UrlId = pUrlId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUrlHas(long pUrlId) {
			IWeaverVarAlias<Url> nodeVar;
			SetInUrlHas(pUrlId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserHasArtifact>(pTargetNodeVar, NodeVar);
			InUserHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserHas(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserHas(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserHas(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserHas(pUserId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesPrimaryArtifact>(pTargetNodeVar, NodeVar);
			InFactorListUsesPrimary = (InFactorListUsesPrimary ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesPrimary.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUsesPrimary(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUsesPrimary(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUsesPrimary(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesPrimary(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUsesPrimary(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesRelatedArtifact>(pTargetNodeVar, NodeVar);
			InFactorListUsesRelated = (InFactorListUsesRelated ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesRelated.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUsesRelated(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUsesRelated(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUsesRelated(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUsesRelated(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUsesRelated(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesPrimaryWithArtifact>(pTargetNodeVar, NodeVar);
			InDescriptorListRefinesPrimaryWith = (InDescriptorListRefinesPrimaryWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesPrimaryWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListRefinesPrimaryWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListRefinesPrimaryWith(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListRefinesPrimaryWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesPrimaryWith(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListRefinesPrimaryWith(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesRelatedWithArtifact>(pTargetNodeVar, NodeVar);
			InDescriptorListRefinesRelatedWith = (InDescriptorListRefinesRelatedWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesRelatedWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListRefinesRelatedWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListRefinesRelatedWith(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListRefinesRelatedWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesRelatedWith(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListRefinesRelatedWith(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesTypeWithArtifact>(pTargetNodeVar, NodeVar);
			InDescriptorListRefinesTypeWith = (InDescriptorListRefinesTypeWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesTypeWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListRefinesTypeWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListRefinesTypeWith(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListRefinesTypeWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListRefinesTypeWith(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListRefinesTypeWith(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesAxisArtifact>(pTargetNodeVar, NodeVar);
			InVectorListUsesAxis = (InVectorListUsesAxis ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUsesAxis.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUsesAxis(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(Vector pVector) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUsesAxis(pVector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUsesAxis(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUsesAxis(long pVectorId) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUsesAxis(pVectorId, out nodeVar);
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
		public ArtifactTypeBuilder(TxBuilder pTx, long pArtifactTypeId) : 
			base(pTx, new ArtifactType() { ArtifactTypeId = pArtifactTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<ArtifactUsesArtifactType>(pTargetNodeVar, NodeVar);
			InArtifactListUses = (InArtifactListUses ?? new List<IWeaverVarAlias<Artifact>>());
			InArtifactListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			AddInArtifactListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			AddInArtifactListUses(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			AddInArtifactListUses(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInArtifactListUses(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			AddInArtifactListUses(pArtifactId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class ClassBuilder : DomainBuilder<Class, RootContainsClass> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx, Class pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx, long pClassId) : 
			base(pTx, new Class() { ClassId = pClassId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<ClassHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
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
			TxBuild.AddRel<CrowdHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<CrowdDefinesCrowdian>(NodeVar, pTargetNodeVar);
			DefinesCrowdianList = (DefinesCrowdianList ?? new List<IWeaverVarAlias<Crowdian>>());
			DefinesCrowdianList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			AddDefinesCrowdianList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(Crowdian pCrowdian) {
			IWeaverVarAlias<Crowdian> nodeVar;
			AddDefinesCrowdianList(pCrowdian, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			AddDefinesCrowdianList(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(long pCrowdianId) {
			IWeaverVarAlias<Crowdian> nodeVar;
			AddDefinesCrowdianList(pCrowdianId, out nodeVar);
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
			TxBuild.AddRel<CrowdDefinesCrowdian>(pTargetNodeVar, NodeVar);
			InCrowdDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(Crowd pCrowd, out IWeaverVarAlias<Crowd> pNodeVar) {
			TxBuild.GetNode(pCrowd, out pNodeVar);
			SetInCrowdDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(Crowd pCrowd) {
			IWeaverVarAlias<Crowd> nodeVar;
			SetInCrowdDefines(pCrowd, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(long pCrowdId, out IWeaverVarAlias<Crowd> pNodeVar) {
			SetInCrowdDefines(new Crowd { CrowdId = pCrowdId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdDefines(long pCrowdId) {
			IWeaverVarAlias<Crowd> nodeVar;
			SetInCrowdDefines(pCrowdId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasCrowdianTypeAssign>(NodeVar, pTargetNodeVar);
			HasCrowdianTypeAssign = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			SetHasCrowdianTypeAssign(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(CrowdianTypeAssign pCrowdianTypeAssign) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			SetHasCrowdianTypeAssign(pCrowdianTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			SetHasCrowdianTypeAssign(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasCrowdianTypeAssign(long pCrowdianTypeAssignId) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			SetHasCrowdianTypeAssign(pCrowdianTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasHistoricCrowdianTypeAssign>(NodeVar, pTargetNodeVar);
			HasHistoricCrowdianTypeAssignList = (HasHistoricCrowdianTypeAssignList ?? new List<IWeaverVarAlias<CrowdianTypeAssign>>());
			HasHistoricCrowdianTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			AddHasHistoricCrowdianTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(CrowdianTypeAssign pCrowdianTypeAssign) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			AddHasHistoricCrowdianTypeAssignList(pCrowdianTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			AddHasHistoricCrowdianTypeAssignList(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricCrowdianTypeAssignList(long pCrowdianTypeAssignId) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			AddHasHistoricCrowdianTypeAssignList(pCrowdianTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesCrowdian>(pTargetNodeVar, NodeVar);
			InUserDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserDefines(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserDefines(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserDefines(pUserId, out nodeVar);
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
		public CrowdianTypeBuilder(TxBuilder pTx, long pCrowdianTypeId) : 
			base(pTx, new CrowdianType() { CrowdianTypeId = pCrowdianTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianTypeAssignUsesCrowdianType>(pTargetNodeVar, NodeVar);
			InCrowdianTypeAssignListUses = (InCrowdianTypeAssignListUses ?? new List<IWeaverVarAlias<CrowdianTypeAssign>>());
			InCrowdianTypeAssignListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			AddInCrowdianTypeAssignListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(CrowdianTypeAssign pCrowdianTypeAssign) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			AddInCrowdianTypeAssignListUses(pCrowdianTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			AddInCrowdianTypeAssignListUses(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInCrowdianTypeAssignListUses(long pCrowdianTypeAssignId) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			AddInCrowdianTypeAssignListUses(pCrowdianTypeAssignId, out nodeVar);
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
			TxBuild.AddRel<CrowdianHasCrowdianTypeAssign>(pTargetNodeVar, NodeVar);
			InCrowdianHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			SetInCrowdianHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(Crowdian pCrowdian) {
			IWeaverVarAlias<Crowdian> nodeVar;
			SetInCrowdianHas(pCrowdian, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			SetInCrowdianHas(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHas(long pCrowdianId) {
			IWeaverVarAlias<Crowdian> nodeVar;
			SetInCrowdianHas(pCrowdianId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianHasHistoricCrowdianTypeAssign>(pTargetNodeVar, NodeVar);
			InCrowdianHasHistoric = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			SetInCrowdianHasHistoric(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(Crowdian pCrowdian) {
			IWeaverVarAlias<Crowdian> nodeVar;
			SetInCrowdianHasHistoric(pCrowdian, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			SetInCrowdianHasHistoric(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInCrowdianHasHistoric(long pCrowdianId) {
			IWeaverVarAlias<Crowdian> nodeVar;
			SetInCrowdianHasHistoric(pCrowdianId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(IWeaverVarAlias<CrowdianType> pTargetNodeVar) {
			TxBuild.AddRel<CrowdianTypeAssignUsesCrowdianType>(NodeVar, pTargetNodeVar);
			UsesCrowdianType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(CrowdianType pCrowdianType, out IWeaverVarAlias<CrowdianType> pNodeVar) {
			TxBuild.GetNode(pCrowdianType, out pNodeVar);
			SetUsesCrowdianType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(CrowdianType pCrowdianType) {
			IWeaverVarAlias<CrowdianType> nodeVar;
			SetUsesCrowdianType(pCrowdianType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(long pCrowdianTypeId, out IWeaverVarAlias<CrowdianType> pNodeVar) {
			SetUsesCrowdianType(new CrowdianType { CrowdianTypeId = pCrowdianTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesCrowdianType(long pCrowdianTypeId) {
			IWeaverVarAlias<CrowdianType> nodeVar;
			SetUsesCrowdianType(pCrowdianTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserCreatesCrowdianTypeAssign>(pTargetNodeVar, NodeVar);
			InUserCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserCreates(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserCreates(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserCreates(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserCreates(pUserId, out nodeVar);
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
			TxBuild.AddRel<AppUsesEmail>(pTargetNodeVar, NodeVar);
			InAppUses = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetInAppUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetInAppUses(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetInAppUses(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppUses(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetInAppUses(pAppId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserUsesEmail>(pTargetNodeVar, NodeVar);
			InUserUses = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserUses(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserUses(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserUses(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserUses(pUserId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class InstanceBuilder : DomainBuilder<Instance, RootContainsInstance> {

		public virtual IWeaverVarAlias<Artifact> HasArtifact { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx, Instance pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx) : base(pTx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx, long pInstanceId) : 
			base(pTx, new Instance() { InstanceId = pInstanceId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<InstanceHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
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
			TxBuild.AddRel<LabelHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
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
			TxBuild.AddRel<AppDefinesMember>(pTargetNodeVar, NodeVar);
			InAppDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetInAppDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetInAppDefines(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetInAppDefines(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetInAppDefines(pAppId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasMemberTypeAssign>(NodeVar, pTargetNodeVar);
			HasMemberTypeAssign = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			SetHasMemberTypeAssign(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			SetHasMemberTypeAssign(pMemberTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			SetHasMemberTypeAssign(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			SetHasMemberTypeAssign(pMemberTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasHistoricMemberTypeAssign>(NodeVar, pTargetNodeVar);
			HasHistoricMemberTypeAssignList = (HasHistoricMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			HasHistoricMemberTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddHasHistoricMemberTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddHasHistoricMemberTypeAssignList(pMemberTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddHasHistoricMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddHasHistoricMemberTypeAssignList(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddHasHistoricMemberTypeAssignList(pMemberTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesArtifact>(NodeVar, pTargetNodeVar);
			CreatesArtifactList = (CreatesArtifactList ?? new List<IWeaverVarAlias<Artifact>>());
			CreatesArtifactList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			AddCreatesArtifactList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			AddCreatesArtifactList(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			AddCreatesArtifactList(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesArtifactList(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			AddCreatesArtifactList(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesMemberTypeAssign>(NodeVar, pTargetNodeVar);
			CreatesMemberTypeAssignList = (CreatesMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			CreatesMemberTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddCreatesMemberTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddCreatesMemberTypeAssignList(pMemberTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddCreatesMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesMemberTypeAssignList(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddCreatesMemberTypeAssignList(pMemberTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesFactor>(NodeVar, pTargetNodeVar);
			CreatesFactorList = (CreatesFactorList ?? new List<IWeaverVarAlias<Factor>>());
			CreatesFactorList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddCreatesFactorList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddCreatesFactorList(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddCreatesFactorList(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesFactorList(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddCreatesFactorList(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesMember>(pTargetNodeVar, NodeVar);
			InUserDefines = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetInUserDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserDefines(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetInUserDefines(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetInUserDefines(pUserId, out nodeVar);
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
		public MemberTypeBuilder(TxBuilder pTx, long pMemberTypeId) : 
			base(pTx, new MemberType() { MemberTypeId = pMemberTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberTypeAssignUsesMemberType>(pTargetNodeVar, NodeVar);
			InMemberTypeAssignListUses = (InMemberTypeAssignListUses ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			InMemberTypeAssignListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddInMemberTypeAssignListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddInMemberTypeAssignListUses(pMemberTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddInMemberTypeAssignListUses(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInMemberTypeAssignListUses(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddInMemberTypeAssignListUses(pMemberTypeAssignId, out nodeVar);
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
			TxBuild.AddRel<MemberHasMemberTypeAssign>(pTargetNodeVar, NodeVar);
			InMemberHas = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberHas(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberHas(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberHas(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberHas(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasHistoricMemberTypeAssign>(pTargetNodeVar, NodeVar);
			InMemberHasHistoric = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberHasHistoric(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberHasHistoric(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberHasHistoric(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberHasHistoric(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesMemberTypeAssign>(pTargetNodeVar, NodeVar);
			InMemberCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberCreates(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberCreates(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(IWeaverVarAlias<MemberType> pTargetNodeVar) {
			TxBuild.AddRel<MemberTypeAssignUsesMemberType>(NodeVar, pTargetNodeVar);
			UsesMemberType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(MemberType pMemberType, out IWeaverVarAlias<MemberType> pNodeVar) {
			TxBuild.GetNode(pMemberType, out pNodeVar);
			SetUsesMemberType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(MemberType pMemberType) {
			IWeaverVarAlias<MemberType> nodeVar;
			SetUsesMemberType(pMemberType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(long pMemberTypeId, out IWeaverVarAlias<MemberType> pNodeVar) {
			SetUsesMemberType(new MemberType { MemberTypeId = pMemberTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesMemberType(long pMemberTypeId) {
			IWeaverVarAlias<MemberType> nodeVar;
			SetUsesMemberType(pMemberTypeId, out nodeVar);
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
			TxBuild.AddRel<UrlHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
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
			TxBuild.AddRel<UserHasArtifact>(NodeVar, pTargetNodeVar);
			HasArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetHasArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetHasArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetHasArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(IWeaverVarAlias<CrowdianTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<UserCreatesCrowdianTypeAssign>(NodeVar, pTargetNodeVar);
			CreatesCrowdianTypeAssignList = (CreatesCrowdianTypeAssignList ?? new List<IWeaverVarAlias<CrowdianTypeAssign>>());
			CreatesCrowdianTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(CrowdianTypeAssign pCrowdianTypeAssign, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			TxBuild.GetNode(pCrowdianTypeAssign, out pNodeVar);
			AddCreatesCrowdianTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(CrowdianTypeAssign pCrowdianTypeAssign) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			AddCreatesCrowdianTypeAssignList(pCrowdianTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(long pCrowdianTypeAssignId, out IWeaverVarAlias<CrowdianTypeAssign> pNodeVar) {
			AddCreatesCrowdianTypeAssignList(new CrowdianTypeAssign { CrowdianTypeAssignId = pCrowdianTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddCreatesCrowdianTypeAssignList(long pCrowdianTypeAssignId) {
			IWeaverVarAlias<CrowdianTypeAssign> nodeVar;
			AddCreatesCrowdianTypeAssignList(pCrowdianTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(IWeaverVarAlias<Crowdian> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesCrowdian>(NodeVar, pTargetNodeVar);
			DefinesCrowdianList = (DefinesCrowdianList ?? new List<IWeaverVarAlias<Crowdian>>());
			DefinesCrowdianList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(Crowdian pCrowdian, out IWeaverVarAlias<Crowdian> pNodeVar) {
			TxBuild.GetNode(pCrowdian, out pNodeVar);
			AddDefinesCrowdianList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(Crowdian pCrowdian) {
			IWeaverVarAlias<Crowdian> nodeVar;
			AddDefinesCrowdianList(pCrowdian, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(long pCrowdianId, out IWeaverVarAlias<Crowdian> pNodeVar) {
			AddDefinesCrowdianList(new Crowdian { CrowdianId = pCrowdianId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesCrowdianList(long pCrowdianId) {
			IWeaverVarAlias<Crowdian> nodeVar;
			AddDefinesCrowdianList(pCrowdianId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(IWeaverVarAlias<Email> pTargetNodeVar) {
			TxBuild.AddRel<UserUsesEmail>(NodeVar, pTargetNodeVar);
			UsesEmail = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail, out IWeaverVarAlias<Email> pNodeVar) {
			TxBuild.GetNode(pEmail, out pNodeVar);
			SetUsesEmail(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail) {
			IWeaverVarAlias<Email> nodeVar;
			SetUsesEmail(pEmail, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId, out IWeaverVarAlias<Email> pNodeVar) {
			SetUsesEmail(new Email { EmailId = pEmailId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId) {
			IWeaverVarAlias<Email> nodeVar;
			SetUsesEmail(pEmailId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesMember>(NodeVar, pTargetNodeVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			AddDefinesMemberList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			AddDefinesMemberList(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			AddDefinesMemberList(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddDefinesMemberList(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			AddDefinesMemberList(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesUser>(pTargetNodeVar, NodeVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			TxBuild.GetNode(pOauthAccess, out pNodeVar);
			AddInOauthAccessListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(OauthAccess pOauthAccess) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddInOauthAccessListUses(pOauthAccess, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			AddInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthAccessListUses(long pOauthAccessId) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddInOauthAccessListUses(pOauthAccessId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesUser>(pTargetNodeVar, NodeVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			TxBuild.GetNode(pOauthGrant, out pNodeVar);
			AddInOauthGrantListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(OauthGrant pOauthGrant) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddInOauthGrantListUses(pOauthGrant, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			AddInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthGrantListUses(long pOauthGrantId) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddInOauthGrantListUses(pOauthGrantId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesUser>(pTargetNodeVar, NodeVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pNodeVar) {
			TxBuild.GetNode(pOauthScope, out pNodeVar);
			AddInOauthScopeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(OauthScope pOauthScope) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddInOauthScopeListUses(pOauthScope, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pNodeVar) {
			AddInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInOauthScopeListUses(long pOauthScopeId) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddInOauthScopeListUses(pOauthScopeId, out nodeVar);
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
			TxBuild.AddRel<MemberCreatesFactor>(pTargetNodeVar, NodeVar);
			InMemberCreates = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			SetInMemberCreates(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberCreates(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			SetInMemberCreates(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesPrimaryArtifact>(NodeVar, pTargetNodeVar);
			UsesPrimaryArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetUsesPrimaryArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetUsesPrimaryArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetUsesPrimaryArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetUsesPrimaryArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesRelatedArtifact>(NodeVar, pTargetNodeVar);
			UsesRelatedArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetUsesRelatedArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetUsesRelatedArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetUsesRelatedArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetUsesRelatedArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(IWeaverVarAlias<FactorAssertion> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesFactorAssertion>(NodeVar, pTargetNodeVar);
			UsesFactorAssertion = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(FactorAssertion pFactorAssertion, out IWeaverVarAlias<FactorAssertion> pNodeVar) {
			TxBuild.GetNode(pFactorAssertion, out pNodeVar);
			SetUsesFactorAssertion(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(FactorAssertion pFactorAssertion) {
			IWeaverVarAlias<FactorAssertion> nodeVar;
			SetUsesFactorAssertion(pFactorAssertion, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(long pFactorAssertionId, out IWeaverVarAlias<FactorAssertion> pNodeVar) {
			SetUsesFactorAssertion(new FactorAssertion { FactorAssertionId = pFactorAssertionId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesFactorAssertion(long pFactorAssertionId) {
			IWeaverVarAlias<FactorAssertion> nodeVar;
			SetUsesFactorAssertion(pFactorAssertionId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorReplacesFactor>(NodeVar, pTargetNodeVar);
			ReplacesFactor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			SetReplacesFactor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			SetReplacesFactor(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			SetReplacesFactor(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetReplacesFactor(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			SetReplacesFactor(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDescriptor>(NodeVar, pTargetNodeVar);
			UsesDescriptor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			SetUsesDescriptor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			SetUsesDescriptor(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			SetUsesDescriptor(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptor(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			SetUsesDescriptor(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDirector>(NodeVar, pTargetNodeVar);
			UsesDirector = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			SetUsesDirector(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(Director pDirector) {
			IWeaverVarAlias<Director> nodeVar;
			SetUsesDirector(pDirector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			SetUsesDirector(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirector(long pDirectorId) {
			IWeaverVarAlias<Director> nodeVar;
			SetUsesDirector(pDirectorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(IWeaverVarAlias<Eventor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesEventor>(NodeVar, pTargetNodeVar);
			UsesEventor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(Eventor pEventor, out IWeaverVarAlias<Eventor> pNodeVar) {
			TxBuild.GetNode(pEventor, out pNodeVar);
			SetUsesEventor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(Eventor pEventor) {
			IWeaverVarAlias<Eventor> nodeVar;
			SetUsesEventor(pEventor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(long pEventorId, out IWeaverVarAlias<Eventor> pNodeVar) {
			SetUsesEventor(new Eventor { EventorId = pEventorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventor(long pEventorId) {
			IWeaverVarAlias<Eventor> nodeVar;
			SetUsesEventor(pEventorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(IWeaverVarAlias<Identor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesIdentor>(NodeVar, pTargetNodeVar);
			UsesIdentor = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(Identor pIdentor, out IWeaverVarAlias<Identor> pNodeVar) {
			TxBuild.GetNode(pIdentor, out pNodeVar);
			SetUsesIdentor(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(Identor pIdentor) {
			IWeaverVarAlias<Identor> nodeVar;
			SetUsesIdentor(pIdentor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(long pIdentorId, out IWeaverVarAlias<Identor> pNodeVar) {
			SetUsesIdentor(new Identor { IdentorId = pIdentorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentor(long pIdentorId) {
			IWeaverVarAlias<Identor> nodeVar;
			SetUsesIdentor(pIdentorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(IWeaverVarAlias<Locator> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesLocator>(NodeVar, pTargetNodeVar);
			UsesLocator = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(Locator pLocator, out IWeaverVarAlias<Locator> pNodeVar) {
			TxBuild.GetNode(pLocator, out pNodeVar);
			SetUsesLocator(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(Locator pLocator) {
			IWeaverVarAlias<Locator> nodeVar;
			SetUsesLocator(pLocator, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(long pLocatorId, out IWeaverVarAlias<Locator> pNodeVar) {
			SetUsesLocator(new Locator { LocatorId = pLocatorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocator(long pLocatorId) {
			IWeaverVarAlias<Locator> nodeVar;
			SetUsesLocator(pLocatorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesVector>(NodeVar, pTargetNodeVar);
			UsesVector = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			SetUsesVector(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(Vector pVector) {
			IWeaverVarAlias<Vector> nodeVar;
			SetUsesVector(pVector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			SetUsesVector(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVector(long pVectorId) {
			IWeaverVarAlias<Vector> nodeVar;
			SetUsesVector(pVectorId, out nodeVar);
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
		public FactorAssertionBuilder(TxBuilder pTx, long pFactorAssertionId) : 
			base(pTx, new FactorAssertion() { FactorAssertionId = pFactorAssertionId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesFactorAssertion>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
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
			TxBuild.AddRel<FactorUsesDescriptor>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(IWeaverVarAlias<DescriptorType> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorUsesDescriptorType>(NodeVar, pTargetNodeVar);
			UsesDescriptorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(DescriptorType pDescriptorType, out IWeaverVarAlias<DescriptorType> pNodeVar) {
			TxBuild.GetNode(pDescriptorType, out pNodeVar);
			SetUsesDescriptorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(DescriptorType pDescriptorType) {
			IWeaverVarAlias<DescriptorType> nodeVar;
			SetUsesDescriptorType(pDescriptorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(long pDescriptorTypeId, out IWeaverVarAlias<DescriptorType> pNodeVar) {
			SetUsesDescriptorType(new DescriptorType { DescriptorTypeId = pDescriptorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDescriptorType(long pDescriptorTypeId) {
			IWeaverVarAlias<DescriptorType> nodeVar;
			SetUsesDescriptorType(pDescriptorTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesPrimaryWithArtifact>(NodeVar, pTargetNodeVar);
			RefinesPrimaryWithArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetRefinesPrimaryWithArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetRefinesPrimaryWithArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetRefinesPrimaryWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesPrimaryWithArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetRefinesPrimaryWithArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesRelatedWithArtifact>(NodeVar, pTargetNodeVar);
			RefinesRelatedWithArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetRefinesRelatedWithArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetRefinesRelatedWithArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetRefinesRelatedWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesRelatedWithArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetRefinesRelatedWithArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesTypeWithArtifact>(NodeVar, pTargetNodeVar);
			RefinesTypeWithArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetRefinesTypeWithArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetRefinesTypeWithArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetRefinesTypeWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRefinesTypeWithArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetRefinesTypeWithArtifact(pArtifactId, out nodeVar);
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
		public DescriptorTypeBuilder(TxBuilder pTx, long pDescriptorTypeId) : 
			base(pTx, new DescriptorType() { DescriptorTypeId = pDescriptorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorUsesDescriptorType>(pTargetNodeVar, NodeVar);
			InDescriptorListUses = (InDescriptorListUses ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddInDescriptorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListUses(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddInDescriptorListUses(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDescriptorListUses(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddInDescriptorListUses(pDescriptorId, out nodeVar);
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
			TxBuild.AddRel<FactorUsesDirector>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(IWeaverVarAlias<DirectorType> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesDirectorType>(NodeVar, pTargetNodeVar);
			UsesDirectorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(DirectorType pDirectorType, out IWeaverVarAlias<DirectorType> pNodeVar) {
			TxBuild.GetNode(pDirectorType, out pNodeVar);
			SetUsesDirectorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(DirectorType pDirectorType) {
			IWeaverVarAlias<DirectorType> nodeVar;
			SetUsesDirectorType(pDirectorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(long pDirectorTypeId, out IWeaverVarAlias<DirectorType> pNodeVar) {
			SetUsesDirectorType(new DirectorType { DirectorTypeId = pDirectorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesDirectorType(long pDirectorTypeId) {
			IWeaverVarAlias<DirectorType> nodeVar;
			SetUsesDirectorType(pDirectorTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(IWeaverVarAlias<DirectorAction> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesPrimaryDirectorAction>(NodeVar, pTargetNodeVar);
			UsesPrimaryDirectorAction = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(DirectorAction pDirectorAction, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			TxBuild.GetNode(pDirectorAction, out pNodeVar);
			SetUsesPrimaryDirectorAction(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(DirectorAction pDirectorAction) {
			IWeaverVarAlias<DirectorAction> nodeVar;
			SetUsesPrimaryDirectorAction(pDirectorAction, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(long pDirectorActionId, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			SetUsesPrimaryDirectorAction(new DirectorAction { DirectorActionId = pDirectorActionId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryDirectorAction(long pDirectorActionId) {
			IWeaverVarAlias<DirectorAction> nodeVar;
			SetUsesPrimaryDirectorAction(pDirectorActionId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(IWeaverVarAlias<DirectorAction> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesRelatedDirectorAction>(NodeVar, pTargetNodeVar);
			UsesRelatedDirectorAction = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(DirectorAction pDirectorAction, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			TxBuild.GetNode(pDirectorAction, out pNodeVar);
			SetUsesRelatedDirectorAction(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(DirectorAction pDirectorAction) {
			IWeaverVarAlias<DirectorAction> nodeVar;
			SetUsesRelatedDirectorAction(pDirectorAction, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(long pDirectorActionId, out IWeaverVarAlias<DirectorAction> pNodeVar) {
			SetUsesRelatedDirectorAction(new DirectorAction { DirectorActionId = pDirectorActionId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedDirectorAction(long pDirectorActionId) {
			IWeaverVarAlias<DirectorAction> nodeVar;
			SetUsesRelatedDirectorAction(pDirectorActionId, out nodeVar);
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
		public DirectorTypeBuilder(TxBuilder pTx, long pDirectorTypeId) : 
			base(pTx, new DirectorType() { DirectorTypeId = pDirectorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesDirectorType>(pTargetNodeVar, NodeVar);
			InDirectorListUses = (InDirectorListUses ?? new List<IWeaverVarAlias<Director>>());
			InDirectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			AddInDirectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(Director pDirector) {
			IWeaverVarAlias<Director> nodeVar;
			AddInDirectorListUses(pDirector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			AddInDirectorListUses(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUses(long pDirectorId) {
			IWeaverVarAlias<Director> nodeVar;
			AddInDirectorListUses(pDirectorId, out nodeVar);
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
		public DirectorActionBuilder(TxBuilder pTx, long pDirectorActionId) : 
			base(pTx, new DirectorAction() { DirectorActionId = pDirectorActionId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesPrimaryDirectorAction>(pTargetNodeVar, NodeVar);
			InDirectorListUsesPrimary = (InDirectorListUsesPrimary ?? new List<IWeaverVarAlias<Director>>());
			InDirectorListUsesPrimary.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			AddInDirectorListUsesPrimary(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(Director pDirector) {
			IWeaverVarAlias<Director> nodeVar;
			AddInDirectorListUsesPrimary(pDirector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			AddInDirectorListUsesPrimary(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesPrimary(long pDirectorId) {
			IWeaverVarAlias<Director> nodeVar;
			AddInDirectorListUsesPrimary(pDirectorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(IWeaverVarAlias<Director> pTargetNodeVar) {
			TxBuild.AddRel<DirectorUsesRelatedDirectorAction>(pTargetNodeVar, NodeVar);
			InDirectorListUsesRelated = (InDirectorListUsesRelated ?? new List<IWeaverVarAlias<Director>>());
			InDirectorListUsesRelated.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(Director pDirector, out IWeaverVarAlias<Director> pNodeVar) {
			TxBuild.GetNode(pDirector, out pNodeVar);
			AddInDirectorListUsesRelated(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(Director pDirector) {
			IWeaverVarAlias<Director> nodeVar;
			AddInDirectorListUsesRelated(pDirector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(long pDirectorId, out IWeaverVarAlias<Director> pNodeVar) {
			AddInDirectorListUsesRelated(new Director { DirectorId = pDirectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInDirectorListUsesRelated(long pDirectorId) {
			IWeaverVarAlias<Director> nodeVar;
			AddInDirectorListUsesRelated(pDirectorId, out nodeVar);
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
			TxBuild.AddRel<FactorUsesEventor>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(IWeaverVarAlias<EventorType> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorType>(NodeVar, pTargetNodeVar);
			UsesEventorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(EventorType pEventorType, out IWeaverVarAlias<EventorType> pNodeVar) {
			TxBuild.GetNode(pEventorType, out pNodeVar);
			SetUsesEventorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(EventorType pEventorType) {
			IWeaverVarAlias<EventorType> nodeVar;
			SetUsesEventorType(pEventorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(long pEventorTypeId, out IWeaverVarAlias<EventorType> pNodeVar) {
			SetUsesEventorType(new EventorType { EventorTypeId = pEventorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorType(long pEventorTypeId) {
			IWeaverVarAlias<EventorType> nodeVar;
			SetUsesEventorType(pEventorTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(IWeaverVarAlias<EventorPrecision> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorPrecision>(NodeVar, pTargetNodeVar);
			UsesEventorPrecision = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(EventorPrecision pEventorPrecision, out IWeaverVarAlias<EventorPrecision> pNodeVar) {
			TxBuild.GetNode(pEventorPrecision, out pNodeVar);
			SetUsesEventorPrecision(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(EventorPrecision pEventorPrecision) {
			IWeaverVarAlias<EventorPrecision> nodeVar;
			SetUsesEventorPrecision(pEventorPrecision, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(long pEventorPrecisionId, out IWeaverVarAlias<EventorPrecision> pNodeVar) {
			SetUsesEventorPrecision(new EventorPrecision { EventorPrecisionId = pEventorPrecisionId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEventorPrecision(long pEventorPrecisionId) {
			IWeaverVarAlias<EventorPrecision> nodeVar;
			SetUsesEventorPrecision(pEventorPrecisionId, out nodeVar);
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
		public EventorTypeBuilder(TxBuilder pTx, long pEventorTypeId) : 
			base(pTx, new EventorType() { EventorTypeId = pEventorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(IWeaverVarAlias<Eventor> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorType>(pTargetNodeVar, NodeVar);
			InEventorListUses = (InEventorListUses ?? new List<IWeaverVarAlias<Eventor>>());
			InEventorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(Eventor pEventor, out IWeaverVarAlias<Eventor> pNodeVar) {
			TxBuild.GetNode(pEventor, out pNodeVar);
			AddInEventorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(Eventor pEventor) {
			IWeaverVarAlias<Eventor> nodeVar;
			AddInEventorListUses(pEventor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(long pEventorId, out IWeaverVarAlias<Eventor> pNodeVar) {
			AddInEventorListUses(new Eventor { EventorId = pEventorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(long pEventorId) {
			IWeaverVarAlias<Eventor> nodeVar;
			AddInEventorListUses(pEventorId, out nodeVar);
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
		public EventorPrecisionBuilder(TxBuilder pTx, long pEventorPrecisionId) : 
			base(pTx, new EventorPrecision() { EventorPrecisionId = pEventorPrecisionId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(IWeaverVarAlias<Eventor> pTargetNodeVar) {
			TxBuild.AddRel<EventorUsesEventorPrecision>(pTargetNodeVar, NodeVar);
			InEventorListUses = (InEventorListUses ?? new List<IWeaverVarAlias<Eventor>>());
			InEventorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(Eventor pEventor, out IWeaverVarAlias<Eventor> pNodeVar) {
			TxBuild.GetNode(pEventor, out pNodeVar);
			AddInEventorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(Eventor pEventor) {
			IWeaverVarAlias<Eventor> nodeVar;
			AddInEventorListUses(pEventor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(long pEventorId, out IWeaverVarAlias<Eventor> pNodeVar) {
			AddInEventorListUses(new Eventor { EventorId = pEventorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInEventorListUses(long pEventorId) {
			IWeaverVarAlias<Eventor> nodeVar;
			AddInEventorListUses(pEventorId, out nodeVar);
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
			TxBuild.AddRel<FactorUsesIdentor>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(IWeaverVarAlias<IdentorType> pTargetNodeVar) {
			TxBuild.AddRel<IdentorUsesIdentorType>(NodeVar, pTargetNodeVar);
			UsesIdentorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(IdentorType pIdentorType, out IWeaverVarAlias<IdentorType> pNodeVar) {
			TxBuild.GetNode(pIdentorType, out pNodeVar);
			SetUsesIdentorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(IdentorType pIdentorType) {
			IWeaverVarAlias<IdentorType> nodeVar;
			SetUsesIdentorType(pIdentorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(long pIdentorTypeId, out IWeaverVarAlias<IdentorType> pNodeVar) {
			SetUsesIdentorType(new IdentorType { IdentorTypeId = pIdentorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesIdentorType(long pIdentorTypeId) {
			IWeaverVarAlias<IdentorType> nodeVar;
			SetUsesIdentorType(pIdentorTypeId, out nodeVar);
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
		public IdentorTypeBuilder(TxBuilder pTx, long pIdentorTypeId) : 
			base(pTx, new IdentorType() { IdentorTypeId = pIdentorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(IWeaverVarAlias<Identor> pTargetNodeVar) {
			TxBuild.AddRel<IdentorUsesIdentorType>(pTargetNodeVar, NodeVar);
			InIdentorListUses = (InIdentorListUses ?? new List<IWeaverVarAlias<Identor>>());
			InIdentorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(Identor pIdentor, out IWeaverVarAlias<Identor> pNodeVar) {
			TxBuild.GetNode(pIdentor, out pNodeVar);
			AddInIdentorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(Identor pIdentor) {
			IWeaverVarAlias<Identor> nodeVar;
			AddInIdentorListUses(pIdentor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(long pIdentorId, out IWeaverVarAlias<Identor> pNodeVar) {
			AddInIdentorListUses(new Identor { IdentorId = pIdentorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInIdentorListUses(long pIdentorId) {
			IWeaverVarAlias<Identor> nodeVar;
			AddInIdentorListUses(pIdentorId, out nodeVar);
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
			TxBuild.AddRel<FactorUsesLocator>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(IWeaverVarAlias<LocatorType> pTargetNodeVar) {
			TxBuild.AddRel<LocatorUsesLocatorType>(NodeVar, pTargetNodeVar);
			UsesLocatorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(LocatorType pLocatorType, out IWeaverVarAlias<LocatorType> pNodeVar) {
			TxBuild.GetNode(pLocatorType, out pNodeVar);
			SetUsesLocatorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(LocatorType pLocatorType) {
			IWeaverVarAlias<LocatorType> nodeVar;
			SetUsesLocatorType(pLocatorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(long pLocatorTypeId, out IWeaverVarAlias<LocatorType> pNodeVar) {
			SetUsesLocatorType(new LocatorType { LocatorTypeId = pLocatorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesLocatorType(long pLocatorTypeId) {
			IWeaverVarAlias<LocatorType> nodeVar;
			SetUsesLocatorType(pLocatorTypeId, out nodeVar);
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
		public LocatorTypeBuilder(TxBuilder pTx, long pLocatorTypeId) : 
			base(pTx, new LocatorType() { LocatorTypeId = pLocatorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(IWeaverVarAlias<Locator> pTargetNodeVar) {
			TxBuild.AddRel<LocatorUsesLocatorType>(pTargetNodeVar, NodeVar);
			InLocatorListUses = (InLocatorListUses ?? new List<IWeaverVarAlias<Locator>>());
			InLocatorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(Locator pLocator, out IWeaverVarAlias<Locator> pNodeVar) {
			TxBuild.GetNode(pLocator, out pNodeVar);
			AddInLocatorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(Locator pLocator) {
			IWeaverVarAlias<Locator> nodeVar;
			AddInLocatorListUses(pLocator, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(long pLocatorId, out IWeaverVarAlias<Locator> pNodeVar) {
			AddInLocatorListUses(new Locator { LocatorId = pLocatorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInLocatorListUses(long pLocatorId) {
			IWeaverVarAlias<Locator> nodeVar;
			AddInLocatorListUses(pLocatorId, out nodeVar);
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
			TxBuild.AddRel<FactorUsesVector>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddInFactorListUses(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesAxisArtifact>(NodeVar, pTargetNodeVar);
			UsesAxisArtifact = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			SetUsesAxisArtifact(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetUsesAxisArtifact(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			SetUsesAxisArtifact(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesAxisArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			SetUsesAxisArtifact(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(IWeaverVarAlias<VectorType> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorType>(NodeVar, pTargetNodeVar);
			UsesVectorType = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(VectorType pVectorType, out IWeaverVarAlias<VectorType> pNodeVar) {
			TxBuild.GetNode(pVectorType, out pNodeVar);
			SetUsesVectorType(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(VectorType pVectorType) {
			IWeaverVarAlias<VectorType> nodeVar;
			SetUsesVectorType(pVectorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(long pVectorTypeId, out IWeaverVarAlias<VectorType> pNodeVar) {
			SetUsesVectorType(new VectorType { VectorTypeId = pVectorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorType(long pVectorTypeId) {
			IWeaverVarAlias<VectorType> nodeVar;
			SetUsesVectorType(pVectorTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(IWeaverVarAlias<VectorUnit> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnit>(NodeVar, pTargetNodeVar);
			UsesVectorUnit = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(VectorUnit pVectorUnit, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			TxBuild.GetNode(pVectorUnit, out pNodeVar);
			SetUsesVectorUnit(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(VectorUnit pVectorUnit) {
			IWeaverVarAlias<VectorUnit> nodeVar;
			SetUsesVectorUnit(pVectorUnit, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(long pVectorUnitId, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			SetUsesVectorUnit(new VectorUnit { VectorUnitId = pVectorUnitId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnit(long pVectorUnitId) {
			IWeaverVarAlias<VectorUnit> nodeVar;
			SetUsesVectorUnit(pVectorUnitId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(IWeaverVarAlias<VectorUnitPrefix> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnitPrefix>(NodeVar, pTargetNodeVar);
			UsesVectorUnitPrefix = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(VectorUnitPrefix pVectorUnitPrefix, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			TxBuild.GetNode(pVectorUnitPrefix, out pNodeVar);
			SetUsesVectorUnitPrefix(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(VectorUnitPrefix pVectorUnitPrefix) {
			IWeaverVarAlias<VectorUnitPrefix> nodeVar;
			SetUsesVectorUnitPrefix(pVectorUnitPrefix, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(long pVectorUnitPrefixId, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			SetUsesVectorUnitPrefix(new VectorUnitPrefix { VectorUnitPrefixId = pVectorUnitPrefixId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(long pVectorUnitPrefixId) {
			IWeaverVarAlias<VectorUnitPrefix> nodeVar;
			SetUsesVectorUnitPrefix(pVectorUnitPrefixId, out nodeVar);
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
		public VectorTypeBuilder(TxBuilder pTx, long pVectorTypeId) : 
			base(pTx, new VectorType() { VectorTypeId = pVectorTypeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorType>(pTargetNodeVar, NodeVar);
			InVectorListUses = (InVectorListUses ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUses(pVector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUses(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUses(pVectorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(IWeaverVarAlias<VectorRange> pTargetNodeVar) {
			TxBuild.AddRel<VectorTypeUsesVectorRange>(NodeVar, pTargetNodeVar);
			UsesVectorRange = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(VectorRange pVectorRange, out IWeaverVarAlias<VectorRange> pNodeVar) {
			TxBuild.GetNode(pVectorRange, out pNodeVar);
			SetUsesVectorRange(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(VectorRange pVectorRange) {
			IWeaverVarAlias<VectorRange> nodeVar;
			SetUsesVectorRange(pVectorRange, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(long pVectorRangeId, out IWeaverVarAlias<VectorRange> pNodeVar) {
			SetUsesVectorRange(new VectorRange { VectorRangeId = pVectorRangeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorRange(long pVectorRangeId) {
			IWeaverVarAlias<VectorRange> nodeVar;
			SetUsesVectorRange(pVectorRangeId, out nodeVar);
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
		public VectorRangeBuilder(TxBuilder pTx, long pVectorRangeId) : 
			base(pTx, new VectorRange() { VectorRangeId = pVectorRangeId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(IWeaverVarAlias<VectorType> pTargetNodeVar) {
			TxBuild.AddRel<VectorTypeUsesVectorRange>(pTargetNodeVar, NodeVar);
			InVectorTypeListUses = (InVectorTypeListUses ?? new List<IWeaverVarAlias<VectorType>>());
			InVectorTypeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(VectorType pVectorType, out IWeaverVarAlias<VectorType> pNodeVar) {
			TxBuild.GetNode(pVectorType, out pNodeVar);
			AddInVectorTypeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(VectorType pVectorType) {
			IWeaverVarAlias<VectorType> nodeVar;
			AddInVectorTypeListUses(pVectorType, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(long pVectorTypeId, out IWeaverVarAlias<VectorType> pNodeVar) {
			AddInVectorTypeListUses(new VectorType { VectorTypeId = pVectorTypeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorTypeListUses(long pVectorTypeId) {
			IWeaverVarAlias<VectorType> nodeVar;
			AddInVectorTypeListUses(pVectorTypeId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(IWeaverVarAlias<VectorRangeLevel> pTargetNodeVar) {
			TxBuild.AddRel<VectorRangeUsesVectorRangeLevel>(NodeVar, pTargetNodeVar);
			UsesVectorRangeLevelList = (UsesVectorRangeLevelList ?? new List<IWeaverVarAlias<VectorRangeLevel>>());
			UsesVectorRangeLevelList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(VectorRangeLevel pVectorRangeLevel, out IWeaverVarAlias<VectorRangeLevel> pNodeVar) {
			TxBuild.GetNode(pVectorRangeLevel, out pNodeVar);
			AddUsesVectorRangeLevelList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(VectorRangeLevel pVectorRangeLevel) {
			IWeaverVarAlias<VectorRangeLevel> nodeVar;
			AddUsesVectorRangeLevelList(pVectorRangeLevel, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(long pVectorRangeLevelId, out IWeaverVarAlias<VectorRangeLevel> pNodeVar) {
			AddUsesVectorRangeLevelList(new VectorRangeLevel { VectorRangeLevelId = pVectorRangeLevelId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUsesVectorRangeLevelList(long pVectorRangeLevelId) {
			IWeaverVarAlias<VectorRangeLevel> nodeVar;
			AddUsesVectorRangeLevelList(pVectorRangeLevelId, out nodeVar);
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
		public VectorRangeLevelBuilder(TxBuilder pTx, long pVectorRangeLevelId) : 
			base(pTx, new VectorRangeLevel() { VectorRangeLevelId = pVectorRangeLevelId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(IWeaverVarAlias<VectorRange> pTargetNodeVar) {
			TxBuild.AddRel<VectorRangeUsesVectorRangeLevel>(pTargetNodeVar, NodeVar);
			InVectorRangeListUses = (InVectorRangeListUses ?? new List<IWeaverVarAlias<VectorRange>>());
			InVectorRangeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(VectorRange pVectorRange, out IWeaverVarAlias<VectorRange> pNodeVar) {
			TxBuild.GetNode(pVectorRange, out pNodeVar);
			AddInVectorRangeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(VectorRange pVectorRange) {
			IWeaverVarAlias<VectorRange> nodeVar;
			AddInVectorRangeListUses(pVectorRange, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(long pVectorRangeId, out IWeaverVarAlias<VectorRange> pNodeVar) {
			AddInVectorRangeListUses(new VectorRange { VectorRangeId = pVectorRangeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorRangeListUses(long pVectorRangeId) {
			IWeaverVarAlias<VectorRange> nodeVar;
			AddInVectorRangeListUses(pVectorRangeId, out nodeVar);
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
		public VectorUnitBuilder(TxBuilder pTx, long pVectorUnitId) : 
			base(pTx, new VectorUnit() { VectorUnitId = pVectorUnitId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnit>(pTargetNodeVar, NodeVar);
			InVectorListUses = (InVectorListUses ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUses(pVector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUses(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUses(pVectorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(IWeaverVarAlias<VectorUnitDerived> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedDefinesVectorUnit>(pTargetNodeVar, NodeVar);
			InVectorUnitDerivedListDefines = (InVectorUnitDerivedListDefines ?? new List<IWeaverVarAlias<VectorUnitDerived>>());
			InVectorUnitDerivedListDefines.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(VectorUnitDerived pVectorUnitDerived, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			TxBuild.GetNode(pVectorUnitDerived, out pNodeVar);
			AddInVectorUnitDerivedListDefines(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(VectorUnitDerived pVectorUnitDerived) {
			IWeaverVarAlias<VectorUnitDerived> nodeVar;
			AddInVectorUnitDerivedListDefines(pVectorUnitDerived, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(long pVectorUnitDerivedId, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			AddInVectorUnitDerivedListDefines(new VectorUnitDerived { VectorUnitDerivedId = pVectorUnitDerivedId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListDefines(long pVectorUnitDerivedId) {
			IWeaverVarAlias<VectorUnitDerived> nodeVar;
			AddInVectorUnitDerivedListDefines(pVectorUnitDerivedId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(IWeaverVarAlias<VectorUnitDerived> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedRaisesToExpVectorUnit>(pTargetNodeVar, NodeVar);
			InVectorUnitDerivedListRaisesToExp = (InVectorUnitDerivedListRaisesToExp ?? new List<IWeaverVarAlias<VectorUnitDerived>>());
			InVectorUnitDerivedListRaisesToExp.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(VectorUnitDerived pVectorUnitDerived, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			TxBuild.GetNode(pVectorUnitDerived, out pNodeVar);
			AddInVectorUnitDerivedListRaisesToExp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(VectorUnitDerived pVectorUnitDerived) {
			IWeaverVarAlias<VectorUnitDerived> nodeVar;
			AddInVectorUnitDerivedListRaisesToExp(pVectorUnitDerived, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(long pVectorUnitDerivedId, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			AddInVectorUnitDerivedListRaisesToExp(new VectorUnitDerived { VectorUnitDerivedId = pVectorUnitDerivedId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListRaisesToExp(long pVectorUnitDerivedId) {
			IWeaverVarAlias<VectorUnitDerived> nodeVar;
			AddInVectorUnitDerivedListRaisesToExp(pVectorUnitDerivedId, out nodeVar);
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
		public VectorUnitPrefixBuilder(TxBuilder pTx, long pVectorUnitPrefixId) : 
			base(pTx, new VectorUnitPrefix() { VectorUnitPrefixId = pVectorUnitPrefixId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesVectorUnitPrefix>(pTargetNodeVar, NodeVar);
			InVectorListUses = (InVectorListUses ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddInVectorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(Vector pVector) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUses(pVector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddInVectorListUses(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorListUses(long pVectorId) {
			IWeaverVarAlias<Vector> nodeVar;
			AddInVectorListUses(pVectorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(IWeaverVarAlias<VectorUnitDerived> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedUsesVectorUnitPrefix>(pTargetNodeVar, NodeVar);
			InVectorUnitDerivedListUses = (InVectorUnitDerivedListUses ?? new List<IWeaverVarAlias<VectorUnitDerived>>());
			InVectorUnitDerivedListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(VectorUnitDerived pVectorUnitDerived, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			TxBuild.GetNode(pVectorUnitDerived, out pNodeVar);
			AddInVectorUnitDerivedListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(VectorUnitDerived pVectorUnitDerived) {
			IWeaverVarAlias<VectorUnitDerived> nodeVar;
			AddInVectorUnitDerivedListUses(pVectorUnitDerived, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(long pVectorUnitDerivedId, out IWeaverVarAlias<VectorUnitDerived> pNodeVar) {
			AddInVectorUnitDerivedListUses(new VectorUnitDerived { VectorUnitDerivedId = pVectorUnitDerivedId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInVectorUnitDerivedListUses(long pVectorUnitDerivedId) {
			IWeaverVarAlias<VectorUnitDerived> nodeVar;
			AddInVectorUnitDerivedListUses(pVectorUnitDerivedId, out nodeVar);
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
		public VectorUnitDerivedBuilder(TxBuilder pTx, long pVectorUnitDerivedId) : 
			base(pTx, new VectorUnitDerived() { VectorUnitDerivedId = pVectorUnitDerivedId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(IWeaverVarAlias<VectorUnit> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedDefinesVectorUnit>(NodeVar, pTargetNodeVar);
			DefinesVectorUnit = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(VectorUnit pVectorUnit, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			TxBuild.GetNode(pVectorUnit, out pNodeVar);
			SetDefinesVectorUnit(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(VectorUnit pVectorUnit) {
			IWeaverVarAlias<VectorUnit> nodeVar;
			SetDefinesVectorUnit(pVectorUnit, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(long pVectorUnitId, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			SetDefinesVectorUnit(new VectorUnit { VectorUnitId = pVectorUnitId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDefinesVectorUnit(long pVectorUnitId) {
			IWeaverVarAlias<VectorUnit> nodeVar;
			SetDefinesVectorUnit(pVectorUnitId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(IWeaverVarAlias<VectorUnit> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedRaisesToExpVectorUnit>(NodeVar, pTargetNodeVar);
			RaisesToExpVectorUnit = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(VectorUnit pVectorUnit, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			TxBuild.GetNode(pVectorUnit, out pNodeVar);
			SetRaisesToExpVectorUnit(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(VectorUnit pVectorUnit) {
			IWeaverVarAlias<VectorUnit> nodeVar;
			SetRaisesToExpVectorUnit(pVectorUnit, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(long pVectorUnitId, out IWeaverVarAlias<VectorUnit> pNodeVar) {
			SetRaisesToExpVectorUnit(new VectorUnit { VectorUnitId = pVectorUnitId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetRaisesToExpVectorUnit(long pVectorUnitId) {
			IWeaverVarAlias<VectorUnit> nodeVar;
			SetRaisesToExpVectorUnit(pVectorUnitId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(IWeaverVarAlias<VectorUnitPrefix> pTargetNodeVar) {
			TxBuild.AddRel<VectorUnitDerivedUsesVectorUnitPrefix>(NodeVar, pTargetNodeVar);
			UsesVectorUnitPrefix = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(VectorUnitPrefix pVectorUnitPrefix, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			TxBuild.GetNode(pVectorUnitPrefix, out pNodeVar);
			SetUsesVectorUnitPrefix(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(VectorUnitPrefix pVectorUnitPrefix) {
			IWeaverVarAlias<VectorUnitPrefix> nodeVar;
			SetUsesVectorUnitPrefix(pVectorUnitPrefix, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(long pVectorUnitPrefixId, out IWeaverVarAlias<VectorUnitPrefix> pNodeVar) {
			SetUsesVectorUnitPrefix(new VectorUnitPrefix { VectorUnitPrefixId = pVectorUnitPrefixId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesVectorUnitPrefix(long pVectorUnitPrefixId) {
			IWeaverVarAlias<VectorUnitPrefix> nodeVar;
			SetUsesVectorUnitPrefix(pVectorUnitPrefixId, out nodeVar);
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
			TxBuild.AddRel<OauthAccessUsesApp>(NodeVar, pTargetNodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pAppId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesUser>(NodeVar, pTargetNodeVar);
			UsesUser = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetUsesUser(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetUsesUser(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetUsesUser(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetUsesUser(pUserId, out nodeVar);
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
			TxBuild.AddRel<OauthDomainUsesApp>(NodeVar, pTargetNodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pAppId, out nodeVar);
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
			TxBuild.AddRel<OauthGrantUsesApp>(NodeVar, pTargetNodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pAppId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesUser>(NodeVar, pTargetNodeVar);
			UsesUser = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetUsesUser(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetUsesUser(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetUsesUser(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetUsesUser(pUserId, out nodeVar);
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
			TxBuild.AddRel<OauthScopeUsesApp>(NodeVar, pTargetNodeVar);
			UsesApp = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pNodeVar) {
			TxBuild.GetNode(pApp, out pNodeVar);
			SetUsesApp(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pApp, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId, out IWeaverVarAlias<App> pNodeVar) {
			SetUsesApp(new App { AppId = pAppId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> nodeVar;
			SetUsesApp(pAppId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesUser>(NodeVar, pTargetNodeVar);
			UsesUser = pTargetNodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pNodeVar) {
			TxBuild.GetNode(pUser, out pNodeVar);
			SetUsesUser(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser) {
			IWeaverVarAlias<User> nodeVar;
			SetUsesUser(pUser, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId, out IWeaverVarAlias<User> pNodeVar) {
			SetUsesUser(new User { UserId = pUserId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId) {
			IWeaverVarAlias<User> nodeVar;
			SetUsesUser(pUserId, out nodeVar);
		}
		

	}

}
