
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.Api.Objects;
using Fabric.Domain;
using Weaver.Core.Query;

namespace Fabric.Operations.Create {
	
	/*================================================================================================*/
	public partial class CreateOperationTasks {


		//// Find Duplicate

		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateAppNameKey(ICreateOperationBuilder pCreCtx, App pNewDom) {
			FindDuplicate<App>(pCreCtx, x => x.NameKey, pNewDom.NameKey, "Name");
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateUrlFullPath(ICreateOperationBuilder pCreCtx, Url pNewDom) {
			FindDuplicate<Url>(pCreCtx, x => x.FullPath, pNewDom.FullPath, "FullPath");
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateUserNameKey(ICreateOperationBuilder pCreCtx, User pNewDom) {
			FindDuplicate<User>(pCreCtx, x => x.NameKey, pNewDom.NameKey, "Name");
		}


		//// Add Vertex

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddApp(ICreateOperationBuilder pCreCtx,
										App pNewDom, out IWeaverVarAlias<App> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddClass(ICreateOperationBuilder pCreCtx,
										Class pNewDom, out IWeaverVarAlias<Class> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddEmail(ICreateOperationBuilder pCreCtx,
										Email pNewDom, out IWeaverVarAlias<Email> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactor(ICreateOperationBuilder pCreCtx,
										Factor pNewDom, out IWeaverVarAlias<Factor> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddInstance(ICreateOperationBuilder pCreCtx,
										Instance pNewDom, out IWeaverVarAlias<Instance> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddMember(ICreateOperationBuilder pCreCtx,
										Member pNewDom, out IWeaverVarAlias<Member> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddOauthAccess(ICreateOperationBuilder pCreCtx,
										OauthAccess pNewDom, out IWeaverVarAlias<OauthAccess> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUrl(ICreateOperationBuilder pCreCtx,
										Url pNewDom, out IWeaverVarAlias<Url> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddUser(ICreateOperationBuilder pCreCtx,
										User pNewDom, out IWeaverVarAlias<User> pAlias) {
			AddVertex(pCreCtx, pNewDom, out pAlias);
		}


		//// Add Edge

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddArtifactCreatedByMember(ICreateOperationBuilder pCreCtx,
				Artifact pNewDom, CreateFabArtifact pNewCre, IWeaverVarAlias<Artifact> pAlias) {
			var a =	AddEdge<Artifact, ArtifactCreatedByMember, Member>(
				pCreCtx, pAlias, pNewCre.CreatedByMemberId);

			var mcaEdge = new MemberCreatesArtifact();
			mcaEdge.Timestamp = pNewDom.Timestamp;
			mcaEdge.VertexType = pNewDom.VertexType;

			AddReverseEdge(pCreCtx, a, mcaEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddEmailUsedByArtifact(ICreateOperationBuilder pCreCtx,
				Email pNewDom, CreateFabEmail pNewCre, IWeaverVarAlias<Email> pAlias) {
			var a =	AddEdge<Email, EmailUsedByArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.UsedByArtifactId);

			var aueEdge = new ArtifactUsesEmail();

			AddReverseEdge(pCreCtx, a, aueEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorCreatedByMember(ICreateOperationBuilder pCreCtx,
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
		public virtual void AddFactorDescriptorRefinesPrimaryWithArtifact(ICreateOperationBuilder pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Descriptor == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Descriptor.RefinesPrimaryWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorDescriptorRefinesRelatedWithArtifact(ICreateOperationBuilder pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Descriptor == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Descriptor.RefinesRelatedWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorDescriptorRefinesTypeWithArtifact(ICreateOperationBuilder pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Descriptor == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Descriptor.RefinesTypeWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddFactorUsesPrimaryArtifact(ICreateOperationBuilder pCreCtx,
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
		public virtual void AddFactorUsesRelatedArtifact(ICreateOperationBuilder pCreCtx,
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
		public virtual void AddFactorVectorUsesAxisArtifact(ICreateOperationBuilder pCreCtx,
				Factor pNewDom, CreateFabFactor pNewCre, IWeaverVarAlias<Factor> pAlias) {
			if ( pNewCre.Vector == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
				pCreCtx, pAlias, pNewCre.Vector.UsesAxisArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddMemberDefinedByApp(ICreateOperationBuilder pCreCtx,
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
		public virtual void AddMemberDefinedByUser(ICreateOperationBuilder pCreCtx,
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
		public virtual void AddOauthAccessAuthenticatesMember(ICreateOperationBuilder pCreCtx,
				OauthAccess pNewDom, CreateFabOauthAccess pNewCre, IWeaverVarAlias<OauthAccess> pAlias) {
			var a =	AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
				pCreCtx, pAlias, pNewCre.AuthenticatesMemberId);

			var maboaEdge = new MemberAuthenticatedByOauthAccess();
			maboaEdge.Timestamp = pNewDom.Timestamp;

			AddReverseEdge(pCreCtx, a, maboaEdge, pAlias);
		}

	}

}
