
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.New.Api.Operations {

	/*================================================================================================*/
	public static class CreateOperations {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabApp CreateApp(object pApiCtx, string pJson) {
			CreateFabApp input;
			App dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabApp, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<App> domVar;
			txb.AddVertex(dom, out domVar);

			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromApp(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabArtifact CreateArtifact(object pApiCtx, string pJson) {
			CreateFabArtifact input;
			Artifact dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabArtifact, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Artifact> domVar;
			txb.AddVertex(dom, out domVar);

			CreateOperationsUtil.AddEdge<Artifact, ArtifactCreatedByMember, Member>(
				txb, pApiCtx, domVar, input.CreatedByMemberId);
			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromArtifact(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabClass CreateClass(object pApiCtx, string pJson) {
			CreateFabClass input;
			Class dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabClass, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Class> domVar;
			txb.AddVertex(dom, out domVar);

			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromClass(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabEmail CreateEmail(object pApiCtx, string pJson) {
			CreateFabEmail input;
			Email dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabEmail, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Email> domVar;
			txb.AddVertex(dom, out domVar);

			CreateOperationsUtil.AddEdge<Email, EmailUsedByArtifact, Artifact>(
				txb, pApiCtx, domVar, input.UsedByArtifactId);
			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromEmail(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabFactor CreateFactor(object pApiCtx, string pJson) {
			CreateFabFactor input;
			Factor dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabFactor, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Factor> domVar;
			txb.AddVertex(dom, out domVar);

			CreateOperationsUtil.AddEdge<Factor, FactorCreatedByMember, Member>(
				txb, pApiCtx, domVar, input.CreatedByMemberId);
			CreateOperationsUtil.AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
				txb, pApiCtx, domVar, input.Descriptor.RefinesPrimaryWithArtifactId);
			CreateOperationsUtil.AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
				txb, pApiCtx, domVar, input.Descriptor.RefinesRelatedWithArtifactId);
			CreateOperationsUtil.AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
				txb, pApiCtx, domVar, input.Descriptor.RefinesTypeWithArtifactId);
			CreateOperationsUtil.AddEdge<Factor, FactorUsesPrimaryArtifact, Artifact>(
				txb, pApiCtx, domVar, input.UsesPrimaryArtifactId);
			CreateOperationsUtil.AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
				txb, pApiCtx, domVar, input.UsesRelatedArtifactId);
			CreateOperationsUtil.AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
				txb, pApiCtx, domVar, input.Vector.UsesAxisArtifactId);
			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromFactor(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabInstance CreateInstance(object pApiCtx, string pJson) {
			CreateFabInstance input;
			Instance dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabInstance, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Instance> domVar;
			txb.AddVertex(dom, out domVar);

			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromInstance(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabMember CreateMember(object pApiCtx, string pJson) {
			CreateFabMember input;
			Member dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabMember, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Member> domVar;
			txb.AddVertex(dom, out domVar);

			CreateOperationsUtil.AddEdge<Member, MemberDefinedByApp, App>(
				txb, pApiCtx, domVar, input.DefinedByAppId);
			CreateOperationsUtil.AddEdge<Member, MemberDefinedByUser, User>(
				txb, pApiCtx, domVar, input.DefinedByUserId);
			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromMember(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthAccess CreateOauthAccess(object pApiCtx, string pJson) {
			CreateFabOauthAccess input;
			OauthAccess dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabOauthAccess, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<OauthAccess> domVar;
			txb.AddVertex(dom, out domVar);

			CreateOperationsUtil.AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
				txb, pApiCtx, domVar, input.AuthenticatesMemberId);
			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromOauthAccess(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabUrl CreateUrl(object pApiCtx, string pJson) {
			CreateFabUrl input;
			Url dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabUrl, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Url> domVar;
			txb.AddVertex(dom, out domVar);

			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromUrl(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabUser CreateUser(object pApiCtx, string pJson) {
			CreateFabUser input;
			User dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabUser, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<User> domVar;
			txb.AddVertex(dom, out domVar);

			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromUser(dom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabVertex CreateVertex(object pApiCtx, string pJson) {
			CreateFabVertex input;
			Vertex dom = CreateOperationsUtil.ConvertInput(
				pJson, ApiToDomain.FromCreateFabVertex, out input);
			
			var txb = new TxBuilder();
			IWeaverVarAlias<Vertex> domVar;
			txb.AddVertex(dom, out domVar);

			//TODO: Add reverse edges
			//TODO: Add edge properties

			return DomainToApi.FromVertex(dom);
		}

	}

}