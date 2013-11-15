﻿
// GENERATED CODE
// Changes made to this source file will be overwritten

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
		public FabApp GetFabAppResult() {
			return DomainToApi.FromApp(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabAppResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabApp c;
			App d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabApp, out c, out d);
			CreateAppEdges(c, d, vAlias);

			// Enforce unique NameKey
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.NameKey, d.NameKey)
				.ToQuery();

			App dup = pOpCtx
				.NewData()
				.AddQuery(q)
				.Execute("UniqueNameKey")
				.ToElementAt<App>(0, 0);

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
		public FabClass GetFabClassResult() {
			return DomainToApi.FromClass(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabClassResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabClass c;
			Class d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabClass, out c, out d);
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
		public FabEmail GetFabEmailResult() {
			return DomainToApi.FromEmail(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabEmailResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabEmail c;
			Email d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabEmail, out c, out d);
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
		public FabFactor GetFabFactorResult() {
			return DomainToApi.FromFactor(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabFactorResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabFactor c;
			Factor d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabFactor, out c, out d);
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
		public FabInstance GetFabInstanceResult() {
			return DomainToApi.FromInstance(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabInstanceResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabInstance c;
			Instance d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabInstance, out c, out d);
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
		public FabMember GetFabMemberResult() {
			return DomainToApi.FromMember(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabMemberResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabMember c;
			Member d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabMember, out c, out d);
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
		public FabOauthAccess GetFabOauthAccessResult() {
			return DomainToApi.FromOauthAccess(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabOauthAccessResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabOauthAccess c;
			OauthAccess d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabOauthAccess, out c, out d);
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
		public FabUrl GetFabUrlResult() {
			return DomainToApi.FromUrl(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabUrlResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabUrl c;
			Url d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabUrl, out c, out d);
			CreateUrlEdges(c, d, vAlias);

			// Enforce unique FullPath
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Url>(x => x.FullPath, d.FullPath)
				.ToQuery();

			Url dup = pOpCtx
				.NewData()
				.AddQuery(q)
				.Execute("UniqueFullPath")
				.ToElementAt<Url>(0, 0);

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
		public FabUser GetFabUserResult() {
			return DomainToApi.FromUser(ExecuteTx(vAlias));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return GetFabUserResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			CreateFabUser c;
			User d;
			vAlias = CreateInit(pOpCtx, pJson, ApiToDomain.FromCreateFabUser, out c, out d);
			CreateUserEdges(c, d, vAlias);

			// Enforce unique NameKey
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, d.NameKey)
				.ToQuery();

			User dup = pOpCtx
				.NewData()
				.AddQuery(q)
				.Execute("UniqueNameKey")
				.ToElementAt<User>(0, 0);

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
