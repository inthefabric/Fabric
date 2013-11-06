
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.New.Api.Operations {
			

	/*================================================================================================*/
	public class CreateAppOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<App> vVertexAlias;
		private CreateFabApp vCreateObj;
		private FabApp vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateAppOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<App>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabApp input;
			App dom = ConvertInput(pJson, ApiToDomain.FromCreateFabApp, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<App> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromApp(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}
			

	/*================================================================================================*/
	public class CreateArtifactOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Artifact> vVertexAlias;
		private CreateFabArtifact vCreateObj;
		private FabArtifact vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateArtifactOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Artifact>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabArtifact input;
			Artifact dom = ConvertInput(pJson, ApiToDomain.FromCreateFabArtifact, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Artifact> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromArtifact(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Member> acbmAlias =
				AddEdge<Artifact, ArtifactCreatedByMember, Member>(
					vVertexAlias, vCreateObj.CreatedByMemberId);

			AddReverseEdge<Member, MemberCreatesArtifact, Artifact>(acbmAlias, vVertexAlias);
			//TODO: add 2 edge prop(s)
		}

	}
			

	/*================================================================================================*/
	public class CreateClassOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Class> vVertexAlias;
		private CreateFabClass vCreateObj;
		private FabClass vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateClassOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Class>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabClass input;
			Class dom = ConvertInput(pJson, ApiToDomain.FromCreateFabClass, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Class> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromClass(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}
			

	/*================================================================================================*/
	public class CreateEmailOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Email> vVertexAlias;
		private CreateFabEmail vCreateObj;
		private FabEmail vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateEmailOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Email>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabEmail input;
			Email dom = ConvertInput(pJson, ApiToDomain.FromCreateFabEmail, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Email> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromEmail(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Artifact> ebaAlias =
				AddEdge<Email, EmailUsedByArtifact, Artifact>(
					vVertexAlias, vCreateObj.UsedByArtifactId);

			AddReverseEdge<Artifact, ArtifactUsesEmail, Email>(ebaAlias, vVertexAlias);
			//TODO: add 0 edge prop(s)
		}

	}
			

	/*================================================================================================*/
	public class CreateFactorOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Factor> vVertexAlias;
		private CreateFabFactor vCreateObj;
		private FabFactor vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFactorOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Factor>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabFactor input;
			Factor dom = ConvertInput(pJson, ApiToDomain.FromCreateFabFactor, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Factor> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromFactor(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Member> fcbmAlias =
				AddEdge<Factor, FactorCreatedByMember, Member>(
					vVertexAlias, vCreateObj.CreatedByMemberId);

			AddReverseEdge<Member, MemberCreatesFactor, Factor>(fcbmAlias, vVertexAlias);
			//TODO: add 4 edge prop(s)

			////

			IWeaverVarAlias<Artifact> frpaAlias =
				AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
					vVertexAlias, vCreateObj.Descriptor.RefinesPrimaryWithArtifactId);

			////

			IWeaverVarAlias<Artifact> frraAlias =
				AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
					vVertexAlias, vCreateObj.Descriptor.RefinesRelatedWithArtifactId);

			////

			IWeaverVarAlias<Artifact> frtaAlias =
				AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
					vVertexAlias, vCreateObj.Descriptor.RefinesTypeWithArtifactId);

			////

			IWeaverVarAlias<Artifact> fpaAlias =
				AddEdge<Factor, FactorUsesPrimaryArtifact, Artifact>(
					vVertexAlias, vCreateObj.UsesPrimaryArtifactId);

			AddReverseEdge<Artifact, ArtifactUsedAsPrimaryByFactor, Factor>(fpaAlias, vVertexAlias);
			//TODO: add 3 edge prop(s)

			////

			IWeaverVarAlias<Artifact> fraAlias =
				AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
					vVertexAlias, vCreateObj.UsesRelatedArtifactId);

			AddReverseEdge<Artifact, ArtifactUsedAsRelatedByFactor, Factor>(fraAlias, vVertexAlias);
			//TODO: add 3 edge prop(s)

			////

			IWeaverVarAlias<Artifact> faaAlias =
				AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
					vVertexAlias, vCreateObj.Vector.UsesAxisArtifactId);
		}

	}
			

	/*================================================================================================*/
	public class CreateInstanceOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Instance> vVertexAlias;
		private CreateFabInstance vCreateObj;
		private FabInstance vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateInstanceOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Instance>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabInstance input;
			Instance dom = ConvertInput(pJson, ApiToDomain.FromCreateFabInstance, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Instance> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromInstance(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}
			

	/*================================================================================================*/
	public class CreateMemberOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Member> vVertexAlias;
		private CreateFabMember vCreateObj;
		private FabMember vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateMemberOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Member>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabMember input;
			Member dom = ConvertInput(pJson, ApiToDomain.FromCreateFabMember, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Member> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromMember(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<App> mdbpAlias =
				AddEdge<Member, MemberDefinedByApp, App>(
					vVertexAlias, vCreateObj.DefinedByAppId);

			AddReverseEdge<App, AppDefinesMember, Member>(mdbpAlias, vVertexAlias);
			//TODO: add 3 edge prop(s)

			////

			IWeaverVarAlias<User> mdbuAlias =
				AddEdge<Member, MemberDefinedByUser, User>(
					vVertexAlias, vCreateObj.DefinedByUserId);

			AddReverseEdge<User, UserDefinesMember, Member>(mdbuAlias, vVertexAlias);
			//TODO: add 3 edge prop(s)
		}

	}
			

	/*================================================================================================*/
	public class CreateOauthAccessOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<OauthAccess> vVertexAlias;
		private CreateFabOauthAccess vCreateObj;
		private FabOauthAccess vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateOauthAccessOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<OauthAccess>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabOauthAccess input;
			OauthAccess dom = ConvertInput(pJson, ApiToDomain.FromCreateFabOauthAccess, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<OauthAccess> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromOauthAccess(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Member> oaamAlias =
				AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
					vVertexAlias, vCreateObj.AuthenticatesMemberId);

			AddReverseEdge<Member, MemberAuthenticatedByOauthAccess, OauthAccess>(oaamAlias, vVertexAlias);
			//TODO: add 1 edge prop(s)
		}

	}
			

	/*================================================================================================*/
	public class CreateUrlOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Url> vVertexAlias;
		private CreateFabUrl vCreateObj;
		private FabUrl vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUrlOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Url>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabUrl input;
			Url dom = ConvertInput(pJson, ApiToDomain.FromCreateFabUrl, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Url> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromUrl(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}
			

	/*================================================================================================*/
	public class CreateUserOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<User> vVertexAlias;
		private CreateFabUser vCreateObj;
		private FabUser vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUserOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<User>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabUser input;
			User dom = ConvertInput(pJson, ApiToDomain.FromCreateFabUser, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<User> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromUser(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}
			

	/*================================================================================================*/
	public class CreateVertexOperation : CreateOperationBase {
		
		private IWeaverVarAlias<Vertex> vVertexAlias;
		private CreateFabVertex vCreateObj;
		private FabVertex vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateVertexOperation(object pApiCtx) : base(pApiCtx) {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Vertex>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(string pJson) {
			CreateFabVertex input;
			Vertex dom = ConvertInput(pJson, ApiToDomain.FromCreateFabVertex, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Vertex> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(dom, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromVertex(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}

}