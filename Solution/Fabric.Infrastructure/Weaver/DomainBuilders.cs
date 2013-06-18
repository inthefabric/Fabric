// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/17/2013 10:59:23 PM

using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public abstract class VertexBuilder<T> : DomainBuilder<T> where T : class, IVertex, new() {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexBuilder(TxBuilder pTx, T pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VertexBuilder(TxBuilder pTx) : base(pTx) {}


	}

	/*================================================================================================*/
	public abstract class VertexForActionBuilder<T> : DomainBuilder<T> where T : class, IVertex, new() {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexForActionBuilder(TxBuilder pTx, T pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public VertexForActionBuilder(TxBuilder pTx) : base(pTx) {}


	}

	/*================================================================================================*/
	public abstract class ArtifactBuilder<T> : DomainBuilder<T> where T : class, IVertex, new() {

		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUsesPrimary { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListUsesRelated { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListDescriptorRefinesPrimaryWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListDescriptorRefinesRelatedWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListDescriptorRefinesTypeWith { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> InFactorListVectorUsesAxis { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx, T pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactBuilder(TxBuilder pTx) : base(pTx) {}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<MemberCreatesArtifact>(pTargetVertexVar, VertexVar);
			InMemberCreates = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			SetInMemberCreates(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberCreates(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberCreates(pMemberId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<FactorUsesPrimaryArtifact>(pTargetVertexVar, VertexVar);
			InFactorListUsesPrimary = (InFactorListUsesPrimary ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesPrimary.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToInFactorListUsesPrimary(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListUsesPrimary(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToInFactorListUsesPrimary(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToInFactorListUsesPrimary(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesPrimary(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListUsesPrimary(pFactorId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<FactorUsesRelatedArtifact>(pTargetVertexVar, VertexVar);
			InFactorListUsesRelated = (InFactorListUsesRelated ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListUsesRelated.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToInFactorListUsesRelated(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListUsesRelated(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToInFactorListUsesRelated(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToInFactorListUsesRelated(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListUsesRelated(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListUsesRelated(pFactorId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesPrimaryWith(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<FactorDescriptorRefinesPrimaryWithArtifact>(pTargetVertexVar, VertexVar);
			InFactorListDescriptorRefinesPrimaryWith = (InFactorListDescriptorRefinesPrimaryWith ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListDescriptorRefinesPrimaryWith.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesPrimaryWith(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToInFactorListDescriptorRefinesPrimaryWith(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesPrimaryWith(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListDescriptorRefinesPrimaryWith(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToInFactorListDescriptorRefinesPrimaryWith(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToInFactorListDescriptorRefinesPrimaryWith(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesPrimaryWith(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListDescriptorRefinesPrimaryWith(pFactorId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesRelatedWith(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<FactorDescriptorRefinesRelatedWithArtifact>(pTargetVertexVar, VertexVar);
			InFactorListDescriptorRefinesRelatedWith = (InFactorListDescriptorRefinesRelatedWith ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListDescriptorRefinesRelatedWith.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesRelatedWith(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToInFactorListDescriptorRefinesRelatedWith(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesRelatedWith(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListDescriptorRefinesRelatedWith(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToInFactorListDescriptorRefinesRelatedWith(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToInFactorListDescriptorRefinesRelatedWith(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesRelatedWith(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListDescriptorRefinesRelatedWith(pFactorId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesTypeWith(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<FactorDescriptorRefinesTypeWithArtifact>(pTargetVertexVar, VertexVar);
			InFactorListDescriptorRefinesTypeWith = (InFactorListDescriptorRefinesTypeWith ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListDescriptorRefinesTypeWith.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesTypeWith(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToInFactorListDescriptorRefinesTypeWith(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesTypeWith(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListDescriptorRefinesTypeWith(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToInFactorListDescriptorRefinesTypeWith(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToInFactorListDescriptorRefinesTypeWith(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListDescriptorRefinesTypeWith(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListDescriptorRefinesTypeWith(pFactorId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListVectorUsesAxis(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<FactorVectorUsesAxisArtifact>(pTargetVertexVar, VertexVar);
			InFactorListVectorUsesAxis = (InFactorListVectorUsesAxis ?? new List<IWeaverVarAlias<Factor>>());
			InFactorListVectorUsesAxis.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListVectorUsesAxis(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToInFactorListVectorUsesAxis(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListVectorUsesAxis(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListVectorUsesAxis(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToInFactorListVectorUsesAxis(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToInFactorListVectorUsesAxis(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInFactorListVectorUsesAxis(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToInFactorListVectorUsesAxis(pFactorId, out vertexVar);
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
		public AppBuilder(TxBuilder pTx, App pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public AppBuilder(TxBuilder pTx, long pArtifactId) : 
			base(pTx, new App { ArtifactId = pArtifactId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(IWeaverVarAlias<Email> pTargetVertexVar) {
			TxBuild.AddEdge<AppUsesEmail>(VertexVar, pTargetVertexVar);
			UsesEmail = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail, out IWeaverVarAlias<Email> pVertexVar) {
			TxBuild.GetVertex(pEmail, out pVertexVar);
			SetUsesEmail(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail) {
			IWeaverVarAlias<Email> vertexVar;
			SetUsesEmail(pEmail, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//EmailId
		public virtual void SetUsesEmail(long pEmailId, out IWeaverVarAlias<Email> pVertexVar) {
			SetUsesEmail(new Email { EmailId = pEmailId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId) {
			IWeaverVarAlias<Email> vertexVar;
			SetUsesEmail(pEmailId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<AppDefinesMember>(VertexVar, pTargetVertexVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			AddToDefinesMemberList(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			AddToDefinesMemberList(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void AddToDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			AddToDefinesMemberList(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			AddToDefinesMemberList(pMemberId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetVertexVar) {
			TxBuild.AddEdge<OauthAccessUsesApp>(pTargetVertexVar, VertexVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pVertexVar) {
			TxBuild.GetVertex(pOauthAccess, out pVertexVar);
			AddToInOauthAccessListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess) {
			IWeaverVarAlias<OauthAccess> vertexVar;
			AddToInOauthAccessListUses(pOauthAccess, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthAccessId
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pVertexVar) {
			AddToInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId) {
			IWeaverVarAlias<OauthAccess> vertexVar;
			AddToInOauthAccessListUses(pOauthAccessId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(IWeaverVarAlias<OauthDomain> pTargetVertexVar) {
			TxBuild.AddEdge<OauthDomainUsesApp>(pTargetVertexVar, VertexVar);
			InOauthDomainListUses = (InOauthDomainListUses ?? new List<IWeaverVarAlias<OauthDomain>>());
			InOauthDomainListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(OauthDomain pOauthDomain, out IWeaverVarAlias<OauthDomain> pVertexVar) {
			TxBuild.GetVertex(pOauthDomain, out pVertexVar);
			AddToInOauthDomainListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(OauthDomain pOauthDomain) {
			IWeaverVarAlias<OauthDomain> vertexVar;
			AddToInOauthDomainListUses(pOauthDomain, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthDomainId
		public virtual void AddToInOauthDomainListUses(long pOauthDomainId, out IWeaverVarAlias<OauthDomain> pVertexVar) {
			AddToInOauthDomainListUses(new OauthDomain { OauthDomainId = pOauthDomainId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthDomainListUses(long pOauthDomainId) {
			IWeaverVarAlias<OauthDomain> vertexVar;
			AddToInOauthDomainListUses(pOauthDomainId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetVertexVar) {
			TxBuild.AddEdge<OauthGrantUsesApp>(pTargetVertexVar, VertexVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pVertexVar) {
			TxBuild.GetVertex(pOauthGrant, out pVertexVar);
			AddToInOauthGrantListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant) {
			IWeaverVarAlias<OauthGrant> vertexVar;
			AddToInOauthGrantListUses(pOauthGrant, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthGrantId
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pVertexVar) {
			AddToInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId) {
			IWeaverVarAlias<OauthGrant> vertexVar;
			AddToInOauthGrantListUses(pOauthGrantId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetVertexVar) {
			TxBuild.AddEdge<OauthScopeUsesApp>(pTargetVertexVar, VertexVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pVertexVar) {
			TxBuild.GetVertex(pOauthScope, out pVertexVar);
			AddToInOauthScopeListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope) {
			IWeaverVarAlias<OauthScope> vertexVar;
			AddToInOauthScopeListUses(pOauthScope, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthScopeId
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pVertexVar) {
			AddToInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId) {
			IWeaverVarAlias<OauthScope> vertexVar;
			AddToInOauthScopeListUses(pOauthScopeId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class ClassBuilder : ArtifactBuilder<Class> {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx, Class pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public ClassBuilder(TxBuilder pTx, long pArtifactId) : 
			base(pTx, new Class { ArtifactId = pArtifactId }) {}
		

	}

	/*================================================================================================*/
	public class EmailBuilder : VertexBuilder<Email> {

		public virtual IList<IWeaverVarAlias<App>> InAppListUses { get; private set; }
		public virtual IList<IWeaverVarAlias<User>> InUserListUses { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx, Email pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public EmailBuilder(TxBuilder pTx, long pEmailId) : 
			base(pTx, new Email { EmailId = pEmailId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInAppListUses(IWeaverVarAlias<App> pTargetVertexVar) {
			TxBuild.AddEdge<AppUsesEmail>(pTargetVertexVar, VertexVar);
			InAppListUses = (InAppListUses ?? new List<IWeaverVarAlias<App>>());
			InAppListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInAppListUses(App pApp, out IWeaverVarAlias<App> pVertexVar) {
			TxBuild.GetVertex(pApp, out pVertexVar);
			AddToInAppListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInAppListUses(App pApp) {
			IWeaverVarAlias<App> vertexVar;
			AddToInAppListUses(pApp, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void AddToInAppListUses(long pArtifactId, out IWeaverVarAlias<App> pVertexVar) {
			AddToInAppListUses(new App { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInAppListUses(long pAppId) {
			IWeaverVarAlias<App> vertexVar;
			AddToInAppListUses(pAppId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInUserListUses(IWeaverVarAlias<User> pTargetVertexVar) {
			TxBuild.AddEdge<UserUsesEmail>(pTargetVertexVar, VertexVar);
			InUserListUses = (InUserListUses ?? new List<IWeaverVarAlias<User>>());
			InUserListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInUserListUses(User pUser, out IWeaverVarAlias<User> pVertexVar) {
			TxBuild.GetVertex(pUser, out pVertexVar);
			AddToInUserListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInUserListUses(User pUser) {
			IWeaverVarAlias<User> vertexVar;
			AddToInUserListUses(pUser, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void AddToInUserListUses(long pArtifactId, out IWeaverVarAlias<User> pVertexVar) {
			AddToInUserListUses(new User { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInUserListUses(long pUserId) {
			IWeaverVarAlias<User> vertexVar;
			AddToInUserListUses(pUserId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class InstanceBuilder : ArtifactBuilder<Instance> {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx, Instance pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public InstanceBuilder(TxBuilder pTx, long pArtifactId) : 
			base(pTx, new Instance { ArtifactId = pArtifactId }) {}
		

	}

	/*================================================================================================*/
	public class MemberBuilder : VertexBuilder<Member> {

		public virtual IWeaverVarAlias<App> InAppDefines { get; private set; }
		public virtual IWeaverVarAlias<MemberTypeAssign> HasMemberTypeAssign { get; private set; }
		public virtual IList<IWeaverVarAlias<MemberTypeAssign>> HasHistoricMemberTypeAssignList { get; private set; }
		public virtual IList<IWeaverVarAlias<Artifact>> CreatesArtifactList { get; private set; }
		public virtual IList<IWeaverVarAlias<MemberTypeAssign>> CreatesMemberTypeAssignList { get; private set; }
		public virtual IList<IWeaverVarAlias<Factor>> CreatesFactorList { get; private set; }
		public virtual IWeaverVarAlias<User> InUserDefines { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(TxBuilder pTx, Member pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public MemberBuilder(TxBuilder pTx, long pMemberId) : 
			base(pTx, new Member { MemberId = pMemberId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(IWeaverVarAlias<App> pTargetVertexVar) {
			TxBuild.AddEdge<AppDefinesMember>(pTargetVertexVar, VertexVar);
			InAppDefines = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(App pApp, out IWeaverVarAlias<App> pVertexVar) {
			TxBuild.GetVertex(pApp, out pVertexVar);
			SetInAppDefines(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(App pApp) {
			IWeaverVarAlias<App> vertexVar;
			SetInAppDefines(pApp, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetInAppDefines(long pArtifactId, out IWeaverVarAlias<App> pVertexVar) {
			SetInAppDefines(new App { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInAppDefines(long pAppId) {
			IWeaverVarAlias<App> vertexVar;
			SetInAppDefines(pAppId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(IWeaverVarAlias<MemberTypeAssign> pTargetVertexVar) {
			TxBuild.AddEdge<MemberHasMemberTypeAssign>(VertexVar, pTargetVertexVar);
			HasMemberTypeAssign = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pVertexVar) {
			TxBuild.GetVertex(pMemberTypeAssign, out pVertexVar);
			SetHasMemberTypeAssign(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> vertexVar;
			SetHasMemberTypeAssign(pMemberTypeAssign, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberTypeAssignId
		public virtual void SetHasMemberTypeAssign(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pVertexVar) {
			SetHasMemberTypeAssign(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetHasMemberTypeAssign(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> vertexVar;
			SetHasMemberTypeAssign(pMemberTypeAssignId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetVertexVar) {
			TxBuild.AddEdge<MemberHasHistoricMemberTypeAssign>(VertexVar, pTargetVertexVar);
			HasHistoricMemberTypeAssignList = (HasHistoricMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			HasHistoricMemberTypeAssignList.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pVertexVar) {
			TxBuild.GetVertex(pMemberTypeAssign, out pVertexVar);
			AddToHasHistoricMemberTypeAssignList(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> vertexVar;
			AddToHasHistoricMemberTypeAssignList(pMemberTypeAssign, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberTypeAssignId
		public virtual void AddToHasHistoricMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pVertexVar) {
			AddToHasHistoricMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToHasHistoricMemberTypeAssignList(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> vertexVar;
			AddToHasHistoricMemberTypeAssignList(pMemberTypeAssignId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<MemberCreatesArtifact>(VertexVar, pTargetVertexVar);
			CreatesArtifactList = (CreatesArtifactList ?? new List<IWeaverVarAlias<Artifact>>());
			CreatesArtifactList.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			AddToCreatesArtifactList(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			AddToCreatesArtifactList(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void AddToCreatesArtifactList(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			AddToCreatesArtifactList(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesArtifactList(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			AddToCreatesArtifactList(pArtifactId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(IWeaverVarAlias<MemberTypeAssign> pTargetVertexVar) {
			TxBuild.AddEdge<MemberCreatesMemberTypeAssign>(VertexVar, pTargetVertexVar);
			CreatesMemberTypeAssignList = (CreatesMemberTypeAssignList ?? new List<IWeaverVarAlias<MemberTypeAssign>>());
			CreatesMemberTypeAssignList.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign, out IWeaverVarAlias<MemberTypeAssign> pVertexVar) {
			TxBuild.GetVertex(pMemberTypeAssign, out pVertexVar);
			AddToCreatesMemberTypeAssignList(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(MemberTypeAssign pMemberTypeAssign) {
			IWeaverVarAlias<MemberTypeAssign> vertexVar;
			AddToCreatesMemberTypeAssignList(pMemberTypeAssign, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberTypeAssignId
		public virtual void AddToCreatesMemberTypeAssignList(long pMemberTypeAssignId, out IWeaverVarAlias<MemberTypeAssign> pVertexVar) {
			AddToCreatesMemberTypeAssignList(new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesMemberTypeAssignList(long pMemberTypeAssignId) {
			IWeaverVarAlias<MemberTypeAssign> vertexVar;
			AddToCreatesMemberTypeAssignList(pMemberTypeAssignId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(IWeaverVarAlias<Factor> pTargetVertexVar) {
			TxBuild.AddEdge<MemberCreatesFactor>(VertexVar, pTargetVertexVar);
			CreatesFactorList = (CreatesFactorList ?? new List<IWeaverVarAlias<Factor>>());
			CreatesFactorList.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(Factor pFactor, out IWeaverVarAlias<Factor> pVertexVar) {
			TxBuild.GetVertex(pFactor, out pVertexVar);
			AddToCreatesFactorList(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(Factor pFactor) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToCreatesFactorList(pFactor, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//FactorId
		public virtual void AddToCreatesFactorList(long pFactorId, out IWeaverVarAlias<Factor> pVertexVar) {
			AddToCreatesFactorList(new Factor { FactorId = pFactorId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToCreatesFactorList(long pFactorId) {
			IWeaverVarAlias<Factor> vertexVar;
			AddToCreatesFactorList(pFactorId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(IWeaverVarAlias<User> pTargetVertexVar) {
			TxBuild.AddEdge<UserDefinesMember>(pTargetVertexVar, VertexVar);
			InUserDefines = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser, out IWeaverVarAlias<User> pVertexVar) {
			TxBuild.GetVertex(pUser, out pVertexVar);
			SetInUserDefines(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(User pUser) {
			IWeaverVarAlias<User> vertexVar;
			SetInUserDefines(pUser, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetInUserDefines(long pArtifactId, out IWeaverVarAlias<User> pVertexVar) {
			SetInUserDefines(new User { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInUserDefines(long pUserId) {
			IWeaverVarAlias<User> vertexVar;
			SetInUserDefines(pUserId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class MemberTypeAssignBuilder : VertexForActionBuilder<MemberTypeAssign> {

		public virtual IWeaverVarAlias<Member> InMemberHas { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberHasHistoric { get; private set; }
		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx, MemberTypeAssign pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignBuilder(TxBuilder pTx, long pMemberTypeAssignId) : 
			base(pTx, new MemberTypeAssign { MemberTypeAssignId = pMemberTypeAssignId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<MemberHasMemberTypeAssign>(pTargetVertexVar, VertexVar);
			InMemberHas = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			SetInMemberHas(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberHas(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void SetInMemberHas(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			SetInMemberHas(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHas(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberHas(pMemberId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<MemberHasHistoricMemberTypeAssign>(pTargetVertexVar, VertexVar);
			InMemberHasHistoric = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			SetInMemberHasHistoric(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberHasHistoric(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void SetInMemberHasHistoric(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			SetInMemberHasHistoric(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberHasHistoric(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberHasHistoric(pMemberId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<MemberCreatesMemberTypeAssign>(pTargetVertexVar, VertexVar);
			InMemberCreates = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			SetInMemberCreates(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberCreates(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberCreates(pMemberId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class UrlBuilder : ArtifactBuilder<Url> {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx, Url pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public UrlBuilder(TxBuilder pTx, long pArtifactId) : 
			base(pTx, new Url { ArtifactId = pArtifactId }) {}
		

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
		public UserBuilder(TxBuilder pTx, User pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public UserBuilder(TxBuilder pTx, long pArtifactId) : 
			base(pTx, new User { ArtifactId = pArtifactId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(IWeaverVarAlias<Email> pTargetVertexVar) {
			TxBuild.AddEdge<UserUsesEmail>(VertexVar, pTargetVertexVar);
			UsesEmail = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail, out IWeaverVarAlias<Email> pVertexVar) {
			TxBuild.GetVertex(pEmail, out pVertexVar);
			SetUsesEmail(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(Email pEmail) {
			IWeaverVarAlias<Email> vertexVar;
			SetUsesEmail(pEmail, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//EmailId
		public virtual void SetUsesEmail(long pEmailId, out IWeaverVarAlias<Email> pVertexVar) {
			SetUsesEmail(new Email { EmailId = pEmailId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesEmail(long pEmailId) {
			IWeaverVarAlias<Email> vertexVar;
			SetUsesEmail(pEmailId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<UserDefinesMember>(VertexVar, pTargetVertexVar);
			DefinesMemberList = (DefinesMemberList ?? new List<IWeaverVarAlias<Member>>());
			DefinesMemberList.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			AddToDefinesMemberList(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			AddToDefinesMemberList(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void AddToDefinesMemberList(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			AddToDefinesMemberList(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToDefinesMemberList(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			AddToDefinesMemberList(pMemberId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(IWeaverVarAlias<OauthAccess> pTargetVertexVar) {
			TxBuild.AddEdge<OauthAccessUsesUser>(pTargetVertexVar, VertexVar);
			InOauthAccessListUses = (InOauthAccessListUses ?? new List<IWeaverVarAlias<OauthAccess>>());
			InOauthAccessListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess, out IWeaverVarAlias<OauthAccess> pVertexVar) {
			TxBuild.GetVertex(pOauthAccess, out pVertexVar);
			AddToInOauthAccessListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(OauthAccess pOauthAccess) {
			IWeaverVarAlias<OauthAccess> vertexVar;
			AddToInOauthAccessListUses(pOauthAccess, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthAccessId
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId, out IWeaverVarAlias<OauthAccess> pVertexVar) {
			AddToInOauthAccessListUses(new OauthAccess { OauthAccessId = pOauthAccessId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthAccessListUses(long pOauthAccessId) {
			IWeaverVarAlias<OauthAccess> vertexVar;
			AddToInOauthAccessListUses(pOauthAccessId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(IWeaverVarAlias<OauthGrant> pTargetVertexVar) {
			TxBuild.AddEdge<OauthGrantUsesUser>(pTargetVertexVar, VertexVar);
			InOauthGrantListUses = (InOauthGrantListUses ?? new List<IWeaverVarAlias<OauthGrant>>());
			InOauthGrantListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant, out IWeaverVarAlias<OauthGrant> pVertexVar) {
			TxBuild.GetVertex(pOauthGrant, out pVertexVar);
			AddToInOauthGrantListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(OauthGrant pOauthGrant) {
			IWeaverVarAlias<OauthGrant> vertexVar;
			AddToInOauthGrantListUses(pOauthGrant, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthGrantId
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId, out IWeaverVarAlias<OauthGrant> pVertexVar) {
			AddToInOauthGrantListUses(new OauthGrant { OauthGrantId = pOauthGrantId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthGrantListUses(long pOauthGrantId) {
			IWeaverVarAlias<OauthGrant> vertexVar;
			AddToInOauthGrantListUses(pOauthGrantId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(IWeaverVarAlias<OauthScope> pTargetVertexVar) {
			TxBuild.AddEdge<OauthScopeUsesUser>(pTargetVertexVar, VertexVar);
			InOauthScopeListUses = (InOauthScopeListUses ?? new List<IWeaverVarAlias<OauthScope>>());
			InOauthScopeListUses.Add(pTargetVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope, out IWeaverVarAlias<OauthScope> pVertexVar) {
			TxBuild.GetVertex(pOauthScope, out pVertexVar);
			AddToInOauthScopeListUses(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(OauthScope pOauthScope) {
			IWeaverVarAlias<OauthScope> vertexVar;
			AddToInOauthScopeListUses(pOauthScope, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//OauthScopeId
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId, out IWeaverVarAlias<OauthScope> pVertexVar) {
			AddToInOauthScopeListUses(new OauthScope { OauthScopeId = pOauthScopeId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToInOauthScopeListUses(long pOauthScopeId) {
			IWeaverVarAlias<OauthScope> vertexVar;
			AddToInOauthScopeListUses(pOauthScopeId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class FactorBuilder : VertexBuilder<Factor> {

		public virtual IWeaverVarAlias<Member> InMemberCreates { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesPrimaryArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> UsesRelatedArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> DescriptorRefinesPrimaryWithArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> DescriptorRefinesRelatedWithArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> DescriptorRefinesTypeWithArtifact { get; private set; }
		public virtual IWeaverVarAlias<Artifact> VectorUsesAxisArtifact { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(TxBuilder pTx, Factor pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public FactorBuilder(TxBuilder pTx, long pFactorId) : 
			base(pTx, new Factor { FactorId = pFactorId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(IWeaverVarAlias<Member> pTargetVertexVar) {
			TxBuild.AddEdge<MemberCreatesFactor>(pTargetVertexVar, VertexVar);
			InMemberCreates = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember, out IWeaverVarAlias<Member> pVertexVar) {
			TxBuild.GetVertex(pMember, out pVertexVar);
			SetInMemberCreates(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(Member pMember) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberCreates(pMember, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//MemberId
		public virtual void SetInMemberCreates(long pMemberId, out IWeaverVarAlias<Member> pVertexVar) {
			SetInMemberCreates(new Member { MemberId = pMemberId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetInMemberCreates(long pMemberId) {
			IWeaverVarAlias<Member> vertexVar;
			SetInMemberCreates(pMemberId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<FactorUsesPrimaryArtifact>(VertexVar, pTargetVertexVar);
			UsesPrimaryArtifact = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			SetUsesPrimaryArtifact(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetUsesPrimaryArtifact(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesPrimaryArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			SetUsesPrimaryArtifact(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesPrimaryArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetUsesPrimaryArtifact(pArtifactId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<FactorUsesRelatedArtifact>(VertexVar, pTargetVertexVar);
			UsesRelatedArtifact = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			SetUsesRelatedArtifact(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetUsesRelatedArtifact(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesRelatedArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			SetUsesRelatedArtifact(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesRelatedArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetUsesRelatedArtifact(pArtifactId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesPrimaryWithArtifact(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<FactorDescriptorRefinesPrimaryWithArtifact>(VertexVar, pTargetVertexVar);
			DescriptorRefinesPrimaryWithArtifact = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesPrimaryWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			SetDescriptorRefinesPrimaryWithArtifact(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesPrimaryWithArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetDescriptorRefinesPrimaryWithArtifact(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetDescriptorRefinesPrimaryWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			SetDescriptorRefinesPrimaryWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesPrimaryWithArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetDescriptorRefinesPrimaryWithArtifact(pArtifactId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesRelatedWithArtifact(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<FactorDescriptorRefinesRelatedWithArtifact>(VertexVar, pTargetVertexVar);
			DescriptorRefinesRelatedWithArtifact = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesRelatedWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			SetDescriptorRefinesRelatedWithArtifact(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesRelatedWithArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetDescriptorRefinesRelatedWithArtifact(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetDescriptorRefinesRelatedWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			SetDescriptorRefinesRelatedWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesRelatedWithArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetDescriptorRefinesRelatedWithArtifact(pArtifactId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesTypeWithArtifact(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<FactorDescriptorRefinesTypeWithArtifact>(VertexVar, pTargetVertexVar);
			DescriptorRefinesTypeWithArtifact = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesTypeWithArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			SetDescriptorRefinesTypeWithArtifact(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesTypeWithArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetDescriptorRefinesTypeWithArtifact(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetDescriptorRefinesTypeWithArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			SetDescriptorRefinesTypeWithArtifact(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDescriptorRefinesTypeWithArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetDescriptorRefinesTypeWithArtifact(pArtifactId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetVectorUsesAxisArtifact(IWeaverVarAlias<Artifact> pTargetVertexVar) {
			TxBuild.AddEdge<FactorVectorUsesAxisArtifact>(VertexVar, pTargetVertexVar);
			VectorUsesAxisArtifact = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetVectorUsesAxisArtifact(Artifact pArtifact, out IWeaverVarAlias<Artifact> pVertexVar) {
			TxBuild.GetVertex(pArtifact, out pVertexVar);
			SetVectorUsesAxisArtifact(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetVectorUsesAxisArtifact(Artifact pArtifact) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetVectorUsesAxisArtifact(pArtifact, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetVectorUsesAxisArtifact(long pArtifactId, out IWeaverVarAlias<Artifact> pVertexVar) {
			SetVectorUsesAxisArtifact(new Artifact { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetVectorUsesAxisArtifact(long pArtifactId) {
			IWeaverVarAlias<Artifact> vertexVar;
			SetVectorUsesAxisArtifact(pArtifactId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthAccessBuilder : VertexBuilder<OauthAccess> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx, OauthAccess pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessBuilder(TxBuilder pTx, long pOauthAccessId) : 
			base(pTx, new OauthAccess { OauthAccessId = pOauthAccessId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetVertexVar) {
			TxBuild.AddEdge<OauthAccessUsesApp>(VertexVar, pTargetVertexVar);
			UsesApp = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pVertexVar) {
			TxBuild.GetVertex(pApp, out pVertexVar);
			SetUsesApp(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pApp, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesApp(long pArtifactId, out IWeaverVarAlias<App> pVertexVar) {
			SetUsesApp(new App { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pAppId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetVertexVar) {
			TxBuild.AddEdge<OauthAccessUsesUser>(VertexVar, pTargetVertexVar);
			UsesUser = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pVertexVar) {
			TxBuild.GetVertex(pUser, out pVertexVar);
			SetUsesUser(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser) {
			IWeaverVarAlias<User> vertexVar;
			SetUsesUser(pUser, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesUser(long pArtifactId, out IWeaverVarAlias<User> pVertexVar) {
			SetUsesUser(new User { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId) {
			IWeaverVarAlias<User> vertexVar;
			SetUsesUser(pUserId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthDomainBuilder : VertexBuilder<OauthDomain> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx, OauthDomain pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainBuilder(TxBuilder pTx, long pOauthDomainId) : 
			base(pTx, new OauthDomain { OauthDomainId = pOauthDomainId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetVertexVar) {
			TxBuild.AddEdge<OauthDomainUsesApp>(VertexVar, pTargetVertexVar);
			UsesApp = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pVertexVar) {
			TxBuild.GetVertex(pApp, out pVertexVar);
			SetUsesApp(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pApp, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesApp(long pArtifactId, out IWeaverVarAlias<App> pVertexVar) {
			SetUsesApp(new App { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pAppId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthGrantBuilder : VertexBuilder<OauthGrant> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx, OauthGrant pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantBuilder(TxBuilder pTx, long pOauthGrantId) : 
			base(pTx, new OauthGrant { OauthGrantId = pOauthGrantId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetVertexVar) {
			TxBuild.AddEdge<OauthGrantUsesApp>(VertexVar, pTargetVertexVar);
			UsesApp = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pVertexVar) {
			TxBuild.GetVertex(pApp, out pVertexVar);
			SetUsesApp(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pApp, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesApp(long pArtifactId, out IWeaverVarAlias<App> pVertexVar) {
			SetUsesApp(new App { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pAppId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetVertexVar) {
			TxBuild.AddEdge<OauthGrantUsesUser>(VertexVar, pTargetVertexVar);
			UsesUser = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pVertexVar) {
			TxBuild.GetVertex(pUser, out pVertexVar);
			SetUsesUser(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser) {
			IWeaverVarAlias<User> vertexVar;
			SetUsesUser(pUser, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesUser(long pArtifactId, out IWeaverVarAlias<User> pVertexVar) {
			SetUsesUser(new User { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId) {
			IWeaverVarAlias<User> vertexVar;
			SetUsesUser(pUserId, out vertexVar);
		}
		

	}

	/*================================================================================================*/
	public class OauthScopeBuilder : VertexBuilder<OauthScope> {

		public virtual IWeaverVarAlias<App> UsesApp { get; private set; }
		public virtual IWeaverVarAlias<User> UsesUser { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx, OauthScope pVertex) : base(pTx, pVertex) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx) : base(pTx) {}

		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeBuilder(TxBuilder pTx, long pOauthScopeId) : 
			base(pTx, new OauthScope { OauthScopeId = pOauthScopeId }) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(IWeaverVarAlias<App> pTargetVertexVar) {
			TxBuild.AddEdge<OauthScopeUsesApp>(VertexVar, pTargetVertexVar);
			UsesApp = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp, out IWeaverVarAlias<App> pVertexVar) {
			TxBuild.GetVertex(pApp, out pVertexVar);
			SetUsesApp(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(App pApp) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pApp, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesApp(long pArtifactId, out IWeaverVarAlias<App> pVertexVar) {
			SetUsesApp(new App { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesApp(long pAppId) {
			IWeaverVarAlias<App> vertexVar;
			SetUsesApp(pAppId, out vertexVar);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(IWeaverVarAlias<User> pTargetVertexVar) {
			TxBuild.AddEdge<OauthScopeUsesUser>(VertexVar, pTargetVertexVar);
			UsesUser = pTargetVertexVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser, out IWeaverVarAlias<User> pVertexVar) {
			TxBuild.GetVertex(pUser, out pVertexVar);
			SetUsesUser(pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(User pUser) {
			IWeaverVarAlias<User> vertexVar;
			SetUsesUser(pUser, out vertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		//ArtifactId
		public virtual void SetUsesUser(long pArtifactId, out IWeaverVarAlias<User> pVertexVar) {
			SetUsesUser(new User { ArtifactId = pArtifactId }, out pVertexVar);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetUsesUser(long pUserId) {
			IWeaverVarAlias<User> vertexVar;
			SetUsesUser(pUserId, out vertexVar);
		}
		

	}

}
