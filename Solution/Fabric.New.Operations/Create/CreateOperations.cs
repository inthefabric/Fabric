
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {


	/*================================================================================================*/
	public class CreateAppOperation : CreateArtifactOperation<App, FabApp, CreateFabApp> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override App ToDomain(CreateFabApp pCreateObj) {
			return ApiToDomain.FromCreateFabApp(pCreateObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckForDuplicates() {
			Tasks.FindDuplicateAppNameKey(CreCtx, NewDom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<App> pAlias) {
			Tasks.AddApp(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddAppEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddAppEdges(IWeaverVarAlias<App> pAlias) {
			AddArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public abstract class CreateArtifactOperation<TDom, TApi, TCre> : 
								CreateVertexOperation<TDom, TApi, TCre> where TDom : Artifact, new()
								where TApi : FabArtifact where TCre : CreateFabArtifact {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void AddArtifactEdges(IWeaverVarAlias<Artifact> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			Tasks.AddArtifactCreatedByMember(CreCtx, NewDom, NewCre, pAlias);
		}

	}


	/*================================================================================================*/
	public partial class CreateClassOperation : CreateArtifactOperation<Class, FabClass, CreateFabClass> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Class ToDomain(CreateFabClass pCreateObj) {
			return ApiToDomain.FromCreateFabClass(pCreateObj);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabClass ToApi(Class pDomainObj) {
			return DomainToApi.FromClass(pDomainObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			CreateOperationsCustom.ClassAfterSessionStart(Tasks, CreCtx, NewDom, NewCre);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<Class> pAlias) {
			Tasks.AddClass(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddClassEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddClassEdges(IWeaverVarAlias<Class> pAlias) {
			AddArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public class CreateEmailOperation : CreateVertexOperation<Email, FabVertex, CreateFabEmail> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Email ToDomain(CreateFabEmail pCreateObj) {
			return ApiToDomain.FromCreateFabEmail(pCreateObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<Email> pAlias) {
			Tasks.AddEmail(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddEmailEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddEmailEdges(IWeaverVarAlias<Email> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			Tasks.AddEmailUsedByArtifact(CreCtx, NewDom, NewCre, pAlias);
		}

	}


	/*================================================================================================*/
	public partial class CreateFactorOperation : CreateVertexOperation<Factor, FabFactor, CreateFabFactor> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Factor ToDomain(CreateFabFactor pCreateObj) {
			return ApiToDomain.FromCreateFabFactor(pCreateObj);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabFactor ToApi(Factor pDomainObj) {
			return DomainToApi.FromFactor(pDomainObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			CreateOperationsCustom.FactorAfterSessionStart(Tasks, CreCtx, NewDom, NewCre);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<Factor> pAlias) {
			Tasks.AddFactor(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddFactorEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorEdges(IWeaverVarAlias<Factor> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			Tasks.AddFactorCreatedByMember(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddFactorDescriptorRefinesPrimaryWithArtifact(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddFactorDescriptorRefinesRelatedWithArtifact(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddFactorDescriptorRefinesTypeWithArtifact(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddFactorUsesPrimaryArtifact(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddFactorUsesRelatedArtifact(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddFactorVectorUsesAxisArtifact(CreCtx, NewDom, NewCre, pAlias);
		}

	}


	/*================================================================================================*/
	public partial class CreateInstanceOperation : CreateArtifactOperation<Instance, FabInstance, CreateFabInstance> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Instance ToDomain(CreateFabInstance pCreateObj) {
			return ApiToDomain.FromCreateFabInstance(pCreateObj);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabInstance ToApi(Instance pDomainObj) {
			return DomainToApi.FromInstance(pDomainObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			CreateOperationsCustom.InstanceAfterSessionStart(Tasks, CreCtx, NewDom, NewCre);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<Instance> pAlias) {
			Tasks.AddInstance(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddInstanceEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddInstanceEdges(IWeaverVarAlias<Instance> pAlias) {
			AddArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public partial class CreateMemberOperation : CreateVertexOperation<Member, FabMember, CreateFabMember> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Member ToDomain(CreateFabMember pCreateObj) {
			return ApiToDomain.FromCreateFabMember(pCreateObj);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabMember ToApi(Member pDomainObj) {
			return DomainToApi.FromMember(pDomainObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			CreateOperationsCustom.MemberAfterSessionStart(Tasks, CreCtx, NewDom, NewCre);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<Member> pAlias) {
			Tasks.AddMember(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddMemberEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberEdges(IWeaverVarAlias<Member> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			Tasks.AddMemberDefinedByApp(CreCtx, NewDom, NewCre, pAlias);
			Tasks.AddMemberDefinedByUser(CreCtx, NewDom, NewCre, pAlias);
		}

	}


	/*================================================================================================*/
	public class CreateOauthAccessOperation : CreateVertexOperation<OauthAccess, FabVertex, CreateFabOauthAccess> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override OauthAccess ToDomain(CreateFabOauthAccess pCreateObj) {
			return ApiToDomain.FromCreateFabOauthAccess(pCreateObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<OauthAccess> pAlias) {
			Tasks.AddOauthAccess(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddOauthAccessEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddOauthAccessEdges(IWeaverVarAlias<OauthAccess> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			Tasks.AddOauthAccessAuthenticatesMember(CreCtx, NewDom, NewCre, pAlias);
		}

	}


	/*================================================================================================*/
	public class CreateUrlOperation : CreateArtifactOperation<Url, FabUrl, CreateFabUrl> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Url ToDomain(CreateFabUrl pCreateObj) {
			return ApiToDomain.FromCreateFabUrl(pCreateObj);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabUrl ToApi(Url pDomainObj) {
			return DomainToApi.FromUrl(pDomainObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckForDuplicates() {
			Tasks.FindDuplicateUrlFullPath(CreCtx, NewDom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<Url> pAlias) {
			Tasks.AddUrl(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddUrlEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddUrlEdges(IWeaverVarAlias<Url> pAlias) {
			AddArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public class CreateUserOperation : CreateArtifactOperation<User, FabUser, CreateFabUser> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override User ToDomain(CreateFabUser pCreateObj) {
			return ApiToDomain.FromCreateFabUser(pCreateObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckForDuplicates() {
			Tasks.FindDuplicateUserNameKey(CreCtx, NewDom);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddVertex(out IWeaverVarAlias<User> pAlias) {
			Tasks.AddUser(CreCtx, NewDom, out pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AddEdges() {
			AddUserEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddUserEdges(IWeaverVarAlias<User> pAlias) {
			AddArtifactEdges(new WeaverVarAlias<Artifact>(pAlias.Name));
		}

	}


	/*================================================================================================*/
	public abstract class CreateVertexOperation<TDom, TApi, TCre> : 
								CreateOperationBase<TDom, TApi, TCre> where TDom : Vertex, new()
								where TApi : FabVertex where TCre : CreateFabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void AddVertexEdges(IWeaverVarAlias<Vertex> pAlias) {
		}

	}

}
