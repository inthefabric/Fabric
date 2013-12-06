
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {
			

	/*================================================================================================*/
	public class CreateAppOperation : CreateArtifactOperation<App, FabApp, CreateFabApp> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabApp, null);

			IWeaverVarAlias uniNameKeyVar;
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.NameKey, NewDom.NameKey)
				.ToQueryAsVar("unq", out uniNameKeyVar);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+uniNameKeyVar.Name+"?0:1);");
			SetupLatestCommand(false, true);
			//throw new FabDuplicateFault(typeof(App), "Name", dup.Name);

			AddVertex();
			CreateAppEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateAppEdges(IWeaverVarAlias<App> pAlias) {
			CreateArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public abstract class CreateArtifactOperation<TDom, TApi, TCre> : 
								CreateVertexOperation<TDom, TApi, TCre> where TDom : Artifact, new()
								where TApi : FabArtifact where TCre : CreateFabArtifact {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void CreateArtifactEdges(IWeaverVarAlias<Artifact> pAlias) {
			CreateVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));

			////
			
			IWeaverVarAlias<Member> acbmAlias =
				AddEdge<Artifact, ArtifactCreatedByMember, Member>(
					pAlias, NewCre.CreatedByMemberId);

			var mcaEdge = new MemberCreatesArtifact();
			mcaEdge.Timestamp = NewDom.Timestamp;
			mcaEdge.VertexType = NewDom.VertexType;

			AddReverseEdge(acbmAlias, mcaEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public partial class CreateClassOperation : CreateArtifactOperation<Class, FabClass, CreateFabClass> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			InitCustomClass();
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabClass, DomainToApi.FromClass);

			AddVertex();
			CreateClassEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateClassEdges(IWeaverVarAlias<Class> pAlias) {
			CreateArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}
			

	/*================================================================================================*/
	public class CreateEmailOperation : CreateVertexOperation<Email, FabVertex, CreateFabEmail> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabEmail, null);

			AddVertex();
			CreateEmailEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateEmailEdges(IWeaverVarAlias<Email> pAlias) {
			CreateVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));

			////
			
			IWeaverVarAlias<Artifact> ebaAlias =
				AddEdge<Email, EmailUsedByArtifact, Artifact>(
					pAlias, NewCre.UsedByArtifactId);

			var aueEdge = new ArtifactUsesEmail();

			AddReverseEdge(ebaAlias, aueEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public partial class CreateFactorOperation : CreateVertexOperation<Factor, FabFactor, CreateFabFactor> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			InitCustomFactor();
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabFactor, DomainToApi.FromFactor);

			AddVertex();
			CreateFactorEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateFactorEdges(IWeaverVarAlias<Factor> pAlias) {
			CreateVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));

			////
			
			IWeaverVarAlias<Member> fcbmAlias =
				AddEdge<Factor, FactorCreatedByMember, Member>(
					pAlias, NewCre.CreatedByMemberId);

			var mcfEdge = new MemberCreatesFactor();
			mcfEdge.Timestamp = NewDom.Timestamp;
			mcfEdge.DescriptorType = NewDom.DescriptorType;
			mcfEdge.PrimaryArtifactId = NewCre.UsesPrimaryArtifactId;
			mcfEdge.RelatedArtifactId = NewCre.UsesRelatedArtifactId;

			AddReverseEdge(fcbmAlias, mcfEdge, pAlias);

			////
			
			IWeaverVarAlias<Artifact> frpaAlias =
				AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
					pAlias, NewCre.Descriptor.RefinesPrimaryWithArtifactId);

			////
			
			IWeaverVarAlias<Artifact> frraAlias =
				AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
					pAlias, NewCre.Descriptor.RefinesRelatedWithArtifactId);

			////
			
			IWeaverVarAlias<Artifact> frtaAlias =
				AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
					pAlias, NewCre.Descriptor.RefinesTypeWithArtifactId);

			////
			
			IWeaverVarAlias<Artifact> fpaAlias =
				AddEdge<Factor, FactorUsesPrimaryArtifact, Artifact>(
					pAlias, NewCre.UsesPrimaryArtifactId);

			var apbfEdge = new ArtifactUsedAsPrimaryByFactor();
			apbfEdge.Timestamp = NewDom.Timestamp;
			apbfEdge.DescriptorType = NewDom.DescriptorType;
			apbfEdge.RelatedArtifactId = NewCre.UsesRelatedArtifactId;

			AddReverseEdge(fpaAlias, apbfEdge, pAlias);

			////
			
			IWeaverVarAlias<Artifact> fraAlias =
				AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
					pAlias, NewCre.UsesRelatedArtifactId);

			var arbfEdge = new ArtifactUsedAsRelatedByFactor();
			arbfEdge.Timestamp = NewDom.Timestamp;
			arbfEdge.DescriptorType = NewDom.DescriptorType;
			arbfEdge.PrimaryArtifactId = NewCre.UsesPrimaryArtifactId;

			AddReverseEdge(fraAlias, arbfEdge, pAlias);

			////
			
			IWeaverVarAlias<Artifact> faaAlias =
				AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
					pAlias, NewCre.Vector.UsesAxisArtifactId);
		}

	}
			

	/*================================================================================================*/
	public partial class CreateInstanceOperation : CreateArtifactOperation<Instance, FabInstance, CreateFabInstance> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			InitCustomInstance();
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabInstance, DomainToApi.FromInstance);

			AddVertex();
			CreateInstanceEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateInstanceEdges(IWeaverVarAlias<Instance> pAlias) {
			CreateArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}
			

	/*================================================================================================*/
	public partial class CreateMemberOperation : CreateVertexOperation<Member, FabMember, CreateFabMember> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			InitCustomMember();
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabMember, DomainToApi.FromMember);

			AddVertex();
			CreateMemberEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateMemberEdges(IWeaverVarAlias<Member> pAlias) {
			CreateVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));

			////
			
			IWeaverVarAlias<App> mdbpAlias =
				AddEdge<Member, MemberDefinedByApp, App>(
					pAlias, NewCre.DefinedByAppId);

			var pdmEdge = new AppDefinesMember();
			pdmEdge.Timestamp = NewDom.Timestamp;
			pdmEdge.MemberType = NewDom.MemberType;
			pdmEdge.UserId = NewCre.DefinedByUserId;

			AddReverseEdge(mdbpAlias, pdmEdge, pAlias);

			////
			
			IWeaverVarAlias<User> mdbuAlias =
				AddEdge<Member, MemberDefinedByUser, User>(
					pAlias, NewCre.DefinedByUserId);

			var udmEdge = new UserDefinesMember();
			udmEdge.Timestamp = NewDom.Timestamp;
			udmEdge.MemberType = NewDom.MemberType;
			udmEdge.AppId = NewCre.DefinedByAppId;

			AddReverseEdge(mdbuAlias, udmEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateOauthAccessOperation : CreateVertexOperation<OauthAccess, FabVertex, CreateFabOauthAccess> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabOauthAccess, null);

			AddVertex();
			CreateOauthAccessEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateOauthAccessEdges(IWeaverVarAlias<OauthAccess> pAlias) {
			CreateVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));

			////
			
			IWeaverVarAlias<Member> oaamAlias =
				AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
					pAlias, NewCre.AuthenticatesMemberId);

			var maboaEdge = new MemberAuthenticatedByOauthAccess();
			maboaEdge.Timestamp = NewDom.Timestamp;

			AddReverseEdge(oaamAlias, maboaEdge, pAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateUrlOperation : CreateArtifactOperation<Url, FabUrl, CreateFabUrl> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabUrl, DomainToApi.FromUrl);

			IWeaverVarAlias uniFullPathVar;
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Url>(x => x.FullPath, NewDom.FullPath)
				.ToQueryAsVar("unq", out uniFullPathVar);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+uniFullPathVar.Name+"?0:1);");
			SetupLatestCommand(false, true);
			//throw new FabDuplicateFault(typeof(Url), "FullPath", dup.FullPath);

			AddVertex();
			CreateUrlEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateUrlEdges(IWeaverVarAlias<Url> pAlias) {
			CreateArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}
			

	/*================================================================================================*/
	public class CreateUserOperation : CreateArtifactOperation<User, FabUser, CreateFabUser> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			Init(pOpCtx, pJson, ApiToDomain.FromCreateFabUser, null);

			IWeaverVarAlias uniNameKeyVar;
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, NewDom.NameKey)
				.ToQueryAsVar("unq", out uniNameKeyVar);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+uniNameKeyVar.Name+"?0:1);");
			SetupLatestCommand(false, true);
			//throw new FabDuplicateFault(typeof(User), "Name", dup.Name);

			AddVertex();
			CreateUserEdges(NewDomAlias);
			Finish();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateUserEdges(IWeaverVarAlias<User> pAlias) {
			CreateArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public abstract class CreateVertexOperation<TDom, TApi, TCre> : 
								CreateOperationBase<TDom, TApi, TCre> where TDom : Vertex, new()
								where TApi : FabVertex where TCre : CreateFabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void CreateVertexEdges(IWeaverVarAlias<Vertex> pAlias) {
		}

	}

}
