// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:15 PM

using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public abstract class NodeForActionBuilder<T> : DomainBuilder<T> where T : INode, new() {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NodeForActionBuilder(TxBuilder pTx, T pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public NodeForActionBuilder(TxBuilder pTx) : base(pTx) {}


	}

	/*================================================================================================*/
	public abstract class ArtifactBuilder<T> : DomainBuilder<T> where T : INode, new() {

		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUsesPrimary { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUsesRelated { get; private set; }
		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListRefinesPrimaryWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListRefinesRelatedWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Descriptor>> InDescriptorListRefinesTypeWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Vector>> InVectorListUsesAxis { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx, T pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx) : base(pTx) {}

		
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
		public virtual void AddToInFactorListUsesPrimary(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesPrimaryArtifact>(pTargetNodeVar, NodeVar);
			InFactorListUsesPrimary = (InFactorListUsesPrimary ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesPrimary.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUsesPrimary(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUsesPrimary(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUsesPrimary(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUsesPrimary(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesRelatedArtifact>(pTargetNodeVar, NodeVar);
			InFactorListUsesRelated = (InFactorListUsesRelated ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesRelated.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUsesRelated(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUsesRelated(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUsesRelated(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUsesRelated(pFactorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesPrimaryWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesPrimaryWithArtifact>(pTargetNodeVar, NodeVar);
			InDescriptorListRefinesPrimaryWith = (InDescriptorListRefinesPrimaryWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesPrimaryWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesPrimaryWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddToInDescriptorListRefinesPrimaryWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesPrimaryWith(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddToInDescriptorListRefinesPrimaryWith(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesPrimaryWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddToInDescriptorListRefinesPrimaryWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesPrimaryWith(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddToInDescriptorListRefinesPrimaryWith(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesRelatedWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesRelatedWithArtifact>(pTargetNodeVar, NodeVar);
			InDescriptorListRefinesRelatedWith = (InDescriptorListRefinesRelatedWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesRelatedWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesRelatedWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddToInDescriptorListRefinesRelatedWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesRelatedWith(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddToInDescriptorListRefinesRelatedWith(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesRelatedWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddToInDescriptorListRefinesRelatedWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesRelatedWith(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddToInDescriptorListRefinesRelatedWith(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesTypeWith(IWeaverVarAlias<Descriptor> pTargetNodeVar) {
			TxBuild.AddRel<DescriptorRefinesTypeWithArtifact>(pTargetNodeVar, NodeVar);
			InDescriptorListRefinesTypeWith = (InDescriptorListRefinesTypeWith ?? new List<IWeaverVarAlias<Descriptor>>());
			InDescriptorListRefinesTypeWith.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesTypeWith(Descriptor pDescriptor, out IWeaverVarAlias<Descriptor> pNodeVar) {
			TxBuild.GetNode(pDescriptor, out pNodeVar);
			AddToInDescriptorListRefinesTypeWith(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesTypeWith(Descriptor pDescriptor) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddToInDescriptorListRefinesTypeWith(pDescriptor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesTypeWith(long pDescriptorId, out IWeaverVarAlias<Descriptor> pNodeVar) {
			AddToInDescriptorListRefinesTypeWith(new Descriptor { DescriptorId = pDescriptorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInDescriptorListRefinesTypeWith(long pDescriptorId) {
			IWeaverVarAlias<Descriptor> nodeVar;
			AddToInDescriptorListRefinesTypeWith(pDescriptorId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInVectorListUsesAxis(IWeaverVarAlias<Vector> pTargetNodeVar) {
			TxBuild.AddRel<VectorUsesAxisArtifact>(pTargetNodeVar, NodeVar);
			InVectorListUsesAxis = (InVectorListUsesAxis ?? new List<IWeaverVarAlias<Vector>>());
			InVectorListUsesAxis.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInVectorListUsesAxis(Vector pVector, out IWeaverVarAlias<Vector> pNodeVar) {
			TxBuild.GetNode(pVector, out pNodeVar);
			AddToInVectorListUsesAxis(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInVectorListUsesAxis(Vector pVector) {
			IWeaverVarAlias<Vector> nodeVar;
			AddToInVectorListUsesAxis(pVector, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInVectorListUsesAxis(long pVectorId, out IWeaverVarAlias<Vector> pNodeVar) {
			AddToInVectorListUsesAxis(new Vector { VectorId = pVectorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInVectorListUsesAxis(long pVectorId) {
			IWeaverVarAlias<Vector> nodeVar;
			AddToInVectorListUsesAxis(pVectorId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class AppBuilder : ArtifactBuilder<App> {

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
			base(pTx, new App { AppId = pAppId }) {}
		
		
		
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
		public virtual void AddToDefinesMemberList(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<AppDefinesMember>(NodeVar, pTargetNodeVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			AddToDefinesMemberList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			AddToDefinesMemberList(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			AddToDefinesMemberList(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			AddToDefinesMemberList(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesApp>(pTargetNodeVar, NodeVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			TxBuild.GetNode(pOauthAccess, out pNodeVar);
			AddToInOauthAccessListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddToInOauthAccessListUses(pOauthAccess, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			AddToInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddToInOauthAccessListUses(pOauthAccessId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(IWeaverVarAlias<OauthDomain> pTargetNodeVar) {
			TxBuild.AddRel<OauthDomainUsesApp>(pTargetNodeVar, NodeVar);
			InOauthDomainListUses = (InOauthDomainListUses ?? new List<IWeaverVarAlias<OauthDomain>>());
			InOauthDomainListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(OauthDomain pOauthDomain, out IWeaverVarAlias<OauthDomain> pNodeVar) {
			TxBuild.GetNode(pOauthDomain, out pNodeVar);
			AddToInOauthDomainListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(OauthDomain pOauthDomain) {
			IWeaverVarAlias<OauthDomain> nodeVar;
			AddToInOauthDomainListUses(pOauthDomain, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(long pOauthDomainId, out IWeaverVarAlias<OauthDomain> pNodeVar) {
			AddToInOauthDomainListUses(new OauthDomain { OauthDomainId = pOauthDomainId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(long pOauthDomainId) {
			IWeaverVarAlias<OauthDomain> nodeVar;
			AddToInOauthDomainListUses(pOauthDomainId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesApp>(pTargetNodeVar, NodeVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			TxBuild.GetNode(pOauthGrant, out pNodeVar);
			AddToInOauthGrantListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddToInOauthGrantListUses(pOauthGrant, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			AddToInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddToInOauthGrantListUses(pOauthGrantId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesApp>(pTargetNodeVar, NodeVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pNodeVar) {
			TxBuild.GetNode(pOauthScope, out pNodeVar);
			AddToInOauthScopeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddToInOauthScopeListUses(pOauthScope, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pNodeVar) {
			AddToInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddToInOauthScopeListUses(pOauthScopeId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class ClassBuilder : ArtifactBuilder<Class> {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx, Class pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx, long pClassId) : 
			base(pTx, new Class { ClassId = pClassId }) {}
		
		

	}

	/*================================================================================================*/
	public class EmailBuilder : DomainBuilder<Email> {

		public virtual IWeaverVarAlias<App> InAppUses { get; private set; }
		public virtual IWeaverVarAlias<User> InUserUses { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx, Email pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx, long pEmailId) : 
			base(pTx, new Email { EmailId = pEmailId }) {}
		
		
		
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
	public class InstanceBuilder : ArtifactBuilder<Instance> {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx, Instance pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx, long pInstanceId) : 
			base(pTx, new Instance { InstanceId = pInstanceId }) {}
		
		

	}

	/*================================================================================================*/
	public class MemberBuilder : DomainBuilder<Member> {

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
			base(pTx, new Member { MemberId = pMemberId }) {}
		
		
		
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
		public virtual void AddToHasHistoricMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberHasHistoricMemberTypeAssign>(NodeVar, pTargetNodeVar);
			HasHistoricMemberTypeAssignList = (HasHistoricMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			HasHistoricMemberTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddToHasHistoricMemberTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddToHasHistoricMemberTypeAssignList(pMemberTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddToHasHistoricMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddToHasHistoricMemberTypeAssignList(pMemberTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(IWeaverVarAlias<Artifact> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesArtifact>(NodeVar, pTargetNodeVar);
			CreatesArtifactList = (CreatesArtifactList ?? new List<IWeaverVarAlias<Artifact>>());
			CreatesArtifactList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(Artifact pArtifact, out IWeaverVarAlias<Artifact> pNodeVar) {
			TxBuild.GetNode(pArtifact, out pNodeVar);
			AddToCreatesArtifactList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> nodeVar;
			AddToCreatesArtifactList(pArtifact, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(long pArtifactId, out IWeaverVarAlias<Artifact> pNodeVar) {
			AddToCreatesArtifactList(new Artifact { ArtifactId = pArtifactId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(long pArtifactId) {
			IWeaverVarAlias<Artifact> nodeVar;
			AddToCreatesArtifactList(pArtifactId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesMemberTypeAssign>(NodeVar, pTargetNodeVar);
			CreatesMemberTypeAssignList = (CreatesMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			CreatesMemberTypeAssignList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			TxBuild.GetNode(pMemberTypeAssign, out pNodeVar);
			AddToCreatesMemberTypeAssignList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddToCreatesMemberTypeAssignList(pMemberTypeAssign, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pNodeVar) {
			AddToCreatesMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> nodeVar;
			AddToCreatesMemberTypeAssignList(pMemberTypeAssignId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<MemberCreatesFactor>(NodeVar, pTargetNodeVar);
			CreatesFactorList = (CreatesFactorList ?? new List<IWeaverVarAlias<Factor>>());
			CreatesFactorList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToCreatesFactorList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToCreatesFactorList(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToCreatesFactorList(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToCreatesFactorList(pFactorId, out nodeVar);
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
	public class MemberTypeAssignBuilder : NodeForActionBuilder<MemberTypeAssign> {

		public virtual IWeaverVarAlias<Member> InMemberHas { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberHasHistoric { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx, MemberTypeAssign pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx, long pMemberTypeAssignId) : 
			base(pTx, new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }) {}
		
		
		
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
		

	}

	/*================================================================================================*/
	public class UrlBuilder : ArtifactBuilder<Url> {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx, Url pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx, long pUrlId) : 
			base(pTx, new Url { UrlId = pUrlId }) {}
		
		

	}

	/*================================================================================================*/
	public class UserBuilder : ArtifactBuilder<User> {

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
			base(pTx, new User { UserId = pUserId }) {}
		
		
		
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
		public virtual void AddToDefinesMemberList(IWeaverVarAlias<Member> pTargetNodeVar) {
			TxBuild.AddRel<UserDefinesMember>(NodeVar, pTargetNodeVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pNodeVar) {
			TxBuild.GetNode(pMember, out pNodeVar);
			AddToDefinesMemberList(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember) {
			IWeaverVarAlias<Member> nodeVar;
			AddToDefinesMemberList(pMember, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pNodeVar) {
			AddToDefinesMemberList(new Member { MemberId = pMemberId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(long pMemberId) {
			IWeaverVarAlias<Member> nodeVar;
			AddToDefinesMemberList(pMemberId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetNodeVar) {
			TxBuild.AddRel<OauthAccessUsesUser>(pTargetNodeVar, NodeVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			TxBuild.GetNode(pOauthAccess, out pNodeVar);
			AddToInOauthAccessListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddToInOauthAccessListUses(pOauthAccess, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pNodeVar) {
			AddToInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId) {
			IWeaverVarAlias<OauthAccess> nodeVar;
			AddToInOauthAccessListUses(pOauthAccessId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetNodeVar) {
			TxBuild.AddRel<OauthGrantUsesUser>(pTargetNodeVar, NodeVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			TxBuild.GetNode(pOauthGrant, out pNodeVar);
			AddToInOauthGrantListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddToInOauthGrantListUses(pOauthGrant, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pNodeVar) {
			AddToInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId) {
			IWeaverVarAlias<OauthGrant> nodeVar;
			AddToInOauthGrantListUses(pOauthGrantId, out nodeVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetNodeVar) {
			TxBuild.AddRel<OauthScopeUsesUser>(pTargetNodeVar, NodeVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pNodeVar) {
			TxBuild.GetNode(pOauthScope, out pNodeVar);
			AddToInOauthScopeListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddToInOauthScopeListUses(pOauthScope, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pNodeVar) {
			AddToInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId) {
			IWeaverVarAlias<OauthScope> nodeVar;
			AddToInOauthScopeListUses(pOauthScopeId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class FactorBuilder : DomainBuilder<Factor> {

		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesPrimaryArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesRelatedArtifact { get; private set; }
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
			base(pTx, new Factor { FactorId = pFactorId }) {}
		
		
		
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
	public abstract class FactorElementNodeBuilder<T> : DomainBuilder<T> where T : INode, new() {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorElementNodeBuilder(TxBuilder pTx, T pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorElementNodeBuilder(TxBuilder pTx) : base(pTx) {}


	}

	/*================================================================================================*/
	public class DescriptorBuilder : FactorElementNodeBuilder<Descriptor> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
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
			base(pTx, new Descriptor { DescriptorId = pDescriptorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDescriptor>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactorId, out nodeVar);
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
	public class DirectorBuilder : FactorElementNodeBuilder<Director> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(TxBuilder pTx, Director pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public DirectorBuilder(TxBuilder pTx, long pDirectorId) : 
			base(pTx, new Director { DirectorId = pDirectorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesDirector>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactorId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class EventorBuilder : FactorElementNodeBuilder<Eventor> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(TxBuilder pTx, Eventor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public EventorBuilder(TxBuilder pTx, long pEventorId) : 
			base(pTx, new Eventor { EventorId = pEventorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesEventor>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactorId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class IdentorBuilder : FactorElementNodeBuilder<Identor> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(TxBuilder pTx, Identor pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public IdentorBuilder(TxBuilder pTx, long pIdentorId) : 
			base(pTx, new Identor { IdentorId = pIdentorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesIdentor>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactorId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class LocatorBuilder : FactorElementNodeBuilder<Locator> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(TxBuilder pTx, Locator pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public LocatorBuilder(TxBuilder pTx, long pLocatorId) : 
			base(pTx, new Locator { LocatorId = pLocatorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesLocator>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactorId, out nodeVar);
		}
		

	}

	/*================================================================================================*/
	public class VectorBuilder : FactorElementNodeBuilder<Vector> {

		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUses { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesAxisArtifact { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(TxBuilder pTx, Vector pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public VectorBuilder(TxBuilder pTx, long pVectorId) : 
			base(pTx, new Vector { VectorId = pVectorId }) {}
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(IWeaverVarAlias<Factor> pTargetNodeVar) {
			TxBuild.AddRel<FactorUsesVector>(pTargetNodeVar, NodeVar);
			InFactorListUses = (InFactorListUses ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUses.Add(pTargetNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor, out IWeaverVarAlias<Factor> pNodeVar) {
			TxBuild.GetNode(pFactor, out pNodeVar);
			AddToInFactorListUses(pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(Factor pFactor) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactor, out nodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId, out IWeaverVarAlias<Factor> pNodeVar) {
			AddToInFactorListUses(new Factor { FactorId = pFactorId }, out pNodeVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUses(long pFactorId) {
			IWeaverVarAlias<Factor> nodeVar;
			AddToInFactorListUses(pFactorId, out nodeVar);
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
		

	}

	/*================================================================================================*/
	public class OauthAccessBuilder : DomainBuilder<OauthAccess> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx, OauthAccess pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx, long pOauthAccessId) : 
			base(pTx, new OauthAccess { OauthAccessId = pOauthAccessId }) {}
		
		
		
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
	public class OauthDomainBuilder : DomainBuilder<OauthDomain> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx, OauthDomain pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx, long pOauthDomainId) : 
			base(pTx, new OauthDomain { OauthDomainId = pOauthDomainId }) {}
		
		
		
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
	public class OauthGrantBuilder : DomainBuilder<OauthGrant> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx, OauthGrant pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx, long pOauthGrantId) : 
			base(pTx, new OauthGrant { OauthGrantId = pOauthGrantId }) {}
		
		
		
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
	public class OauthScopeBuilder : DomainBuilder<OauthScope> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx, OauthScope pNode) : base(pTx, pNode) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx, long pOauthScopeId) : 
			base(pTx, new OauthScope { OauthScopeId = pOauthScopeId }) {}
		
		
		
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
