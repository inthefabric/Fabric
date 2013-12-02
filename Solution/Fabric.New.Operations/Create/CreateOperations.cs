
// GENERATED CODE
// Changes made to this source file will be overwritten

using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {
			

	/*================================================================================================*/
	public class CreateAppOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<App> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			throw new NotSupportedException("Internal access only; use GetAppResult() instead.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public App GetAppResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabApp c;
			App d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabApp, out c, out d);
			CreateAppEdges(c, d, vAlias);

			// Enforce unique NameKey
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.NameKey, d.NameKey)
				.ToQuery();

			App dup = pOpCtx.Data.Get<App>(q, "UniqueAppName");

			if ( dup != null ) {
				throw new FabDuplicateFault(typeof(App), "Name", dup.Name);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateAppEdges(CreateFabApp pCre, App pDom,
															IWeaverVarAlias<App> pAlias) {
			var va = new WeaverVarAlias<Artifact>(pAlias.Name);
			CreateArtifactEdges(pCre, pDom, va);
		}

	}


	/*================================================================================================*/
	public abstract class CreateArtifactOperation : CreateVertexOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void CreateArtifactEdges(CreateFabArtifact pCre, Artifact pDom,
															IWeaverVarAlias<Artifact> pAlias) {
			var va = new WeaverVarAlias<Vertex>(pAlias.Name);
			CreateVertexEdges(pCre, pDom, va);

			////
			
			IWeaverVarAlias<Member> acbmAlias =
				AddEdge<Artifact, ArtifactCreatedByMember, Member>(
					pAlias, pCre.CreatedByMemberId);

			var mcaEdge = new MemberCreatesArtifact();
			mcaEdge.Timestamp = pDom.Timestamp;
			mcaEdge.VertexType = pDom.VertexType;

			AddReverseEdge(acbmAlias, mcaEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateClassOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Class> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabClassResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabClass GetFabClassResult() {
			return DomainToApi.FromClass(GetClassResult());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Class GetClassResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabClass c;
			Class d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabClass, out c, out d);
			CreateClassEdges(c, d, vAlias);
			CreateOperationsCustom.CreateClass(pOpCtx, TxBuild, c, d);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateClassEdges(CreateFabClass pCre, Class pDom,
															IWeaverVarAlias<Class> pAlias) {
			var va = new WeaverVarAlias<Artifact>(pAlias.Name);
			CreateArtifactEdges(pCre, pDom, va);
		}

	}
			

	/*================================================================================================*/
	public class CreateEmailOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Email> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			throw new NotSupportedException("Internal access only; use GetEmailResult() instead.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public Email GetEmailResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabEmail c;
			Email d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabEmail, out c, out d);
			CreateEmailEdges(c, d, vAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateEmailEdges(CreateFabEmail pCre, Email pDom,
															IWeaverVarAlias<Email> pAlias) {
			var va = new WeaverVarAlias<Vertex>(pAlias.Name);
			CreateVertexEdges(pCre, pDom, va);

			////
			
			IWeaverVarAlias<Artifact> ebaAlias =
				AddEdge<Email, EmailUsedByArtifact, Artifact>(
					pAlias, pCre.UsedByArtifactId);

			var aueEdge = new ArtifactUsesEmail();

			AddReverseEdge(ebaAlias, aueEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateFactorOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Factor> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabFactorResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabFactor GetFabFactorResult() {
			return DomainToApi.FromFactor(GetFactorResult());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Factor GetFactorResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabFactor c;
			Factor d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabFactor, out c, out d);
			CreateFactorEdges(c, d, vAlias);
			CreateOperationsCustom.CreateFactor(pOpCtx, TxBuild, c, d);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateFactorEdges(CreateFabFactor pCre, Factor pDom,
															IWeaverVarAlias<Factor> pAlias) {
			var va = new WeaverVarAlias<Vertex>(pAlias.Name);
			CreateVertexEdges(pCre, pDom, va);

			////
			
			IWeaverVarAlias<Member> fcbmAlias =
				AddEdge<Factor, FactorCreatedByMember, Member>(
					pAlias, pCre.CreatedByMemberId);

			var mcfEdge = new MemberCreatesFactor();
			mcfEdge.Timestamp = pDom.Timestamp;
			mcfEdge.DescriptorType = pDom.DescriptorType;
			mcfEdge.PrimaryArtifactId = pCre.UsesPrimaryArtifactId;
			mcfEdge.RelatedArtifactId = pCre.UsesRelatedArtifactId;

			AddReverseEdge(fcbmAlias, mcfEdge, pAlias);

			////
			
			IWeaverVarAlias<Artifact> frpaAlias =
				AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
					pAlias, pCre.Descriptor.RefinesPrimaryWithArtifactId);

			////
			
			IWeaverVarAlias<Artifact> frraAlias =
				AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
					pAlias, pCre.Descriptor.RefinesRelatedWithArtifactId);

			////
			
			IWeaverVarAlias<Artifact> frtaAlias =
				AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
					pAlias, pCre.Descriptor.RefinesTypeWithArtifactId);

			////
			
			IWeaverVarAlias<Artifact> fpaAlias =
				AddEdge<Factor, FactorUsesPrimaryArtifact, Artifact>(
					pAlias, pCre.UsesPrimaryArtifactId);

			var apbfEdge = new ArtifactUsedAsPrimaryByFactor();
			apbfEdge.Timestamp = pDom.Timestamp;
			apbfEdge.DescriptorType = pDom.DescriptorType;
			apbfEdge.RelatedArtifactId = pCre.UsesRelatedArtifactId;

			AddReverseEdge(fpaAlias, apbfEdge, pAlias);

			////
			
			IWeaverVarAlias<Artifact> fraAlias =
				AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
					pAlias, pCre.UsesRelatedArtifactId);

			var arbfEdge = new ArtifactUsedAsRelatedByFactor();
			arbfEdge.Timestamp = pDom.Timestamp;
			arbfEdge.DescriptorType = pDom.DescriptorType;
			arbfEdge.PrimaryArtifactId = pCre.UsesPrimaryArtifactId;

			AddReverseEdge(fraAlias, arbfEdge, pAlias);

			////
			
			IWeaverVarAlias<Artifact> faaAlias =
				AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
					pAlias, pCre.Vector.UsesAxisArtifactId);
		}

	}
			

	/*================================================================================================*/
	public class CreateInstanceOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Instance> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabInstanceResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabInstance GetFabInstanceResult() {
			return DomainToApi.FromInstance(GetInstanceResult());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Instance GetInstanceResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabInstance c;
			Instance d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabInstance, out c, out d);
			CreateInstanceEdges(c, d, vAlias);
			CreateOperationsCustom.CreateInstance(pOpCtx, TxBuild, c, d);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateInstanceEdges(CreateFabInstance pCre, Instance pDom,
															IWeaverVarAlias<Instance> pAlias) {
			var va = new WeaverVarAlias<Artifact>(pAlias.Name);
			CreateArtifactEdges(pCre, pDom, va);
		}

	}
			

	/*================================================================================================*/
	public class CreateMemberOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Member> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabMemberResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabMember GetFabMemberResult() {
			return DomainToApi.FromMember(GetMemberResult());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetMemberResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabMember c;
			Member d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabMember, out c, out d);
			CreateMemberEdges(c, d, vAlias);
			CreateOperationsCustom.CreateMember(pOpCtx, TxBuild, c, d);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateMemberEdges(CreateFabMember pCre, Member pDom,
															IWeaverVarAlias<Member> pAlias) {
			var va = new WeaverVarAlias<Vertex>(pAlias.Name);
			CreateVertexEdges(pCre, pDom, va);

			////
			
			IWeaverVarAlias<App> mdbpAlias =
				AddEdge<Member, MemberDefinedByApp, App>(
					pAlias, pCre.DefinedByAppId);

			var pdmEdge = new AppDefinesMember();
			pdmEdge.Timestamp = pDom.Timestamp;
			pdmEdge.MemberType = pDom.MemberType;
			pdmEdge.UserId = pCre.DefinedByUserId;

			AddReverseEdge(mdbpAlias, pdmEdge, pAlias);

			////
			
			IWeaverVarAlias<User> mdbuAlias =
				AddEdge<Member, MemberDefinedByUser, User>(
					pAlias, pCre.DefinedByUserId);

			var udmEdge = new UserDefinesMember();
			udmEdge.Timestamp = pDom.Timestamp;
			udmEdge.MemberType = pDom.MemberType;
			udmEdge.AppId = pCre.DefinedByAppId;

			AddReverseEdge(mdbuAlias, udmEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateOauthAccessOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<OauthAccess> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			throw new NotSupportedException("Internal access only; use GetOauthAccessResult() instead.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess GetOauthAccessResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabOauthAccess c;
			OauthAccess d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabOauthAccess, out c, out d);
			CreateOauthAccessEdges(c, d, vAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateOauthAccessEdges(CreateFabOauthAccess pCre, OauthAccess pDom,
															IWeaverVarAlias<OauthAccess> pAlias) {
			var va = new WeaverVarAlias<Vertex>(pAlias.Name);
			CreateVertexEdges(pCre, pDom, va);

			////
			
			IWeaverVarAlias<Member> oaamAlias =
				AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
					pAlias, pCre.AuthenticatesMemberId);

			var maboaEdge = new MemberAuthenticatedByOauthAccess();
			maboaEdge.Timestamp = pDom.Timestamp;

			AddReverseEdge(oaamAlias, maboaEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateUrlOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Url> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabUrlResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabUrl GetFabUrlResult() {
			return DomainToApi.FromUrl(GetUrlResult());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Url GetUrlResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabUrl c;
			Url d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabUrl, out c, out d);
			CreateUrlEdges(c, d, vAlias);

			// Enforce unique FullPath
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Url>(x => x.FullPath, d.FullPath)
				.ToQuery();

			Url dup = pOpCtx.Data.Get<Url>(q, "UniqueUrlFullPath");

			if ( dup != null ) {
				throw new FabDuplicateFault(typeof(Url), "FullPath", dup.FullPath);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateUrlEdges(CreateFabUrl pCre, Url pDom,
															IWeaverVarAlias<Url> pAlias) {
			var va = new WeaverVarAlias<Artifact>(pAlias.Name);
			CreateArtifactEdges(pCre, pDom, va);
		}

	}
			

	/*================================================================================================*/
	public class CreateUserOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<User> vAlias;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			throw new NotSupportedException("Internal access only; use GetUserResult() instead.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUserResult() {
			return ExecuteTx(vAlias);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson) {
			CreateFabUser c;
			User d;
			vAlias = CreateInit(pOpCtx, pTxBuild, pJson, ApiToDomain.FromCreateFabUser, out c, out d);
			CreateUserEdges(c, d, vAlias);

			// Enforce unique NameKey
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, d.NameKey)
				.ToQuery();

			User dup = pOpCtx.Data.Get<User>(q, "UniqueUserName");

			if ( dup != null ) {
				throw new FabDuplicateFault(typeof(User), "Name", dup.Name);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateUserEdges(CreateFabUser pCre, User pDom,
															IWeaverVarAlias<User> pAlias) {
			var va = new WeaverVarAlias<Artifact>(pAlias.Name);
			CreateArtifactEdges(pCre, pDom, va);
		}

	}


	/*================================================================================================*/
	public abstract class CreateVertexOperation : CreateOperationBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void CreateVertexEdges(CreateFabVertex pCre, Vertex pDom,
															IWeaverVarAlias<Vertex> pAlias) {
		}

	}

}
