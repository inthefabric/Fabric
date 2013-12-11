
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {
	
	/*================================================================================================*/
	public partial class CreateOperationTasks {


		//// Find Duplicate

		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateAppNameKey(ICreateOperationContext pCreCtx, App pNewDom) {
			FindDuplicate<App>(pCreCtx, x => x.NameKey, pNewDom.NameKey, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateUrlFullPath(ICreateOperationContext pCreCtx, Url pNewDom) {
			FindDuplicate<Url>(pCreCtx, x => x.FullPath, pNewDom.FullPath, "FullPath");
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateUserNameKey(ICreateOperationContext pCreCtx, User pNewDom) {
			FindDuplicate<User>(pCreCtx, x => x.NameKey, pNewDom.NameKey, "Name");
		}


		//// Add Vertex

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddApp(ICreateOperationContext pCreCtx,
										App pNewDom, out IWeaverVarAlias<App> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddClass(ICreateOperationContext pCreCtx,
										Class pNewDom, out IWeaverVarAlias<Class> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddEmail(ICreateOperationContext pCreCtx,
										Email pNewDom, out IWeaverVarAlias<Email> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactor(ICreateOperationContext pCreCtx,
										Factor pNewDom, out IWeaverVarAlias<Factor> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInstance(ICreateOperationContext pCreCtx,
										Instance pNewDom, out IWeaverVarAlias<Instance> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddMember(ICreateOperationContext pCreCtx,
										Member pNewDom, out IWeaverVarAlias<Member> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddOauthAccess(ICreateOperationContext pCreCtx,
										OauthAccess pNewDom, out IWeaverVarAlias<OauthAccess> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUrl(ICreateOperationContext pCreCtx,
										Url pNewDom, out IWeaverVarAlias<Url> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUser(ICreateOperationContext pCreCtx,
										User pNewDom, out IWeaverVarAlias<User> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}


		//// Add Edge

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddArtifactCreatedByMember(ICreateOperationContext pCreCtx,
				Artifact pNewDom, CreateFabArtifact pNewCre, IWeaverVarAlias<Artifact> pAlias) {
			var a =	AddEdge<Artifact, ArtifactCreatedByMember, Member>(
				pCreCtx, pAlias, pNewCre.CreatedByMemberId);

			var mcaEdge = new MemberCreatesArtifact();
			mcaEdge.Timestamp = pNewDom.Timestamp;
			mcaEdge.VertexType = pNewDom.VertexType;

			AddReverseEdge(pCreCtx, a, mcaEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddEmailUsedByArtifact(ICreateOperationContext pCreCtx,
				Email pNewDom, CreateFabEmail pNewCre, IWeaverVarAlias<Email> pAlias) {
			var a =	AddEdge<Email, EmailUsedByArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.UsedByArtifactId);

			var aueEdge = new ArtifactUsesEmail();

			AddReverseEdge(pCreCtx, a, aueEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorCreatedByMember(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			var a =	AddEdge<Factor, FactorCreatedByMember, Member>(
				pCreCtx, pAlias, pNewCre.CreatedByMemberId);

			var mcfEdge = new MemberCreatesFactor();
			mcfEdge.Timestamp = pNewDom.Timestamp;
			mcfEdge.DescriptorType = pNewDom.DescriptorType;
			mcfEdge.PrimaryArtifactId = pNewCre.UsesPrimaryArtifactId;
			mcfEdge.RelatedArtifactId = pNewCre.UsesRelatedArtifactId;

			AddReverseEdge(pCreCtx, a, mcfEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorDescriptorRefinesPrimaryWithArtifact(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Descriptor == null || pNewCre.Descriptor.RefinesPrimaryWithArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Descriptor.RefinesPrimaryWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorDescriptorRefinesRelatedWithArtifact(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Descriptor == null || pNewCre.Descriptor.RefinesRelatedWithArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Descriptor.RefinesRelatedWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorDescriptorRefinesTypeWithArtifact(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Descriptor == null || pNewCre.Descriptor.RefinesTypeWithArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Descriptor.RefinesTypeWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorUsesPrimaryArtifact(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			var a =	AddEdge<Factor, FactorUsesPrimaryArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.UsesPrimaryArtifactId);

			var apbfEdge = new ArtifactUsedAsPrimaryByFactor();
			apbfEdge.Timestamp = pNewDom.Timestamp;
			apbfEdge.DescriptorType = pNewDom.DescriptorType;
			apbfEdge.RelatedArtifactId = pNewCre.UsesRelatedArtifactId;

			AddReverseEdge(pCreCtx, a, apbfEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorUsesRelatedArtifact(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			var a =	AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.UsesRelatedArtifactId);

			var arbfEdge = new ArtifactUsedAsRelatedByFactor();
			arbfEdge.Timestamp = pNewDom.Timestamp;
			arbfEdge.DescriptorType = pNewDom.DescriptorType;
			arbfEdge.PrimaryArtifactId = pNewCre.UsesPrimaryArtifactId;

			AddReverseEdge(pCreCtx, a, arbfEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorVectorUsesAxisArtifact(ICreateOperationContext pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Vector == null || pNewCre.Vector.UsesAxisArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Vector.UsesAxisArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddMemberDefinedByApp(ICreateOperationContext pCreCtx,
				Member pNewDom, CreateFabMember pNewCre, IWeaverVarAlias<Member> pAlias) {
			var a =	AddEdge<Member, MemberDefinedByApp, App>(
				pCreCtx, pAlias, pNewCre.DefinedByAppId);

			var pdmEdge = new AppDefinesMember();
			pdmEdge.Timestamp = pNewDom.Timestamp;
			pdmEdge.MemberType = pNewDom.MemberType;
			pdmEdge.UserId = pNewCre.DefinedByUserId;

			AddReverseEdge(pCreCtx, a, pdmEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddMemberDefinedByUser(ICreateOperationContext pCreCtx,
				Member pNewDom, CreateFabMember pNewCre, IWeaverVarAlias<Member> pAlias) {
			var a =	AddEdge<Member, MemberDefinedByUser, User>(
				pCreCtx, pAlias, pNewCre.DefinedByUserId);

			var udmEdge = new UserDefinesMember();
			udmEdge.Timestamp = pNewDom.Timestamp;
			udmEdge.MemberType = pNewDom.MemberType;
			udmEdge.AppId = pNewCre.DefinedByAppId;

			AddReverseEdge(pCreCtx, a, udmEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddOauthAccessAuthenticatesMember(ICreateOperationContext pCreCtx,
				OauthAccess pNewDom, CreateFabOauthAccess pNewCre, IWeaverVarAlias<OauthAccess> pAlias) {
			var a =	AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
				pCreCtx, pAlias, pNewCre.AuthenticatesMemberId);

			var maboaEdge = new MemberAuthenticatedByOauthAccess();
			maboaEdge.Timestamp = pNewDom.Timestamp;

			AddReverseEdge(pCreCtx, a, maboaEdge, pAlias);
		}

	}

}
