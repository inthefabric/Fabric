
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {
			

	/*================================================================================================*/
	public class CreateAppOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<App> vAlias;
		private App vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabApp GetFabAppResult() {
			//return DomainToApi.FromApp(ExecuteTx<App>(vAlias));
			return DomainToApi.FromApp(vDom);
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
			vDom = d; //for testing
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
		private Class vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabClass GetFabClassResult() {
			//return DomainToApi.FromClass(ExecuteTx<Class>(vAlias));
			return DomainToApi.FromClass(vDom);
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
			vDom = d; //for testing
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
		private Email vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabEmail GetFabEmailResult() {
			//return DomainToApi.FromEmail(ExecuteTx<Email>(vAlias));
			return DomainToApi.FromEmail(vDom);
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
			vDom = d; //for testing
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
		private Factor vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFactor GetFabFactorResult() {
			//return DomainToApi.FromFactor(ExecuteTx<Factor>(vAlias));
			return DomainToApi.FromFactor(vDom);
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
			vDom = d; //for testing
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
		private Instance vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabInstance GetFabInstanceResult() {
			//return DomainToApi.FromInstance(ExecuteTx<Instance>(vAlias));
			return DomainToApi.FromInstance(vDom);
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
			vDom = d; //for testing
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
		private Member vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMember GetFabMemberResult() {
			//return DomainToApi.FromMember(ExecuteTx<Member>(vAlias));
			return DomainToApi.FromMember(vDom);
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
			vDom = d; //for testing
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
		private OauthAccess vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess GetFabOauthAccessResult() {
			//return DomainToApi.FromOauthAccess(ExecuteTx<OauthAccess>(vAlias));
			return DomainToApi.FromOauthAccess(vDom);
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
			vDom = d; //for testing
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
		private Url vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUrl GetFabUrlResult() {
			//return DomainToApi.FromUrl(ExecuteTx<Url>(vAlias));
			return DomainToApi.FromUrl(vDom);
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
			vDom = d; //for testing
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
		private User vDom;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUser GetFabUserResult() {
			//return DomainToApi.FromUser(ExecuteTx<User>(vAlias));
			return DomainToApi.FromUser(vDom);
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
			vDom = d; //for testing
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
