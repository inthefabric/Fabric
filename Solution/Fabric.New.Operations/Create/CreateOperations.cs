
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
	public class CreateAppOperation : CreateArtifactOperation<App, FabApp, CreateFabApp> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override App ToDomain(CreateFabApp pCreateObj) {
			return ApiToDomain.FromCreateFabApp(pCreateObj);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckForDuplicates() {
			IWeaverVarAlias alias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.NameKey, NewDom.NameKey)
				.ToQueryAsVar("unq", out alias);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+alias.Name+"?0:1);");
			string cmdId = SetupLatestCommand(false, true);

			Checks.Add(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 0 ) {
					throw new FabDuplicateFault(typeof(App), "Name", NewCre.Name);
				}
			}));
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
			AddArtifactCreatedByMember(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddArtifactCreatedByMember(IWeaverVarAlias<Artifact> pAlias) {
			var a =	AddEdge<Artifact, ArtifactCreatedByMember, Member>(
				pAlias, NewCre.CreatedByMemberId);

			var mcaEdge = new MemberCreatesArtifact();
			mcaEdge.Timestamp = NewDom.Timestamp;
			mcaEdge.VertexType = NewDom.VertexType;

			AddReverseEdge(a, mcaEdge, pAlias);
		}

	}


	/*================================================================================================*/
	public partial class CreateClassOperation : CreateArtifactOperation<Class, FabClass, CreateFabClass> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCustom() {
			VerifyCustomClass();
		}

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
		protected override void AddEdges() {
			AddEmailEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddEmailEdges(IWeaverVarAlias<Email> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			AddEmailUsedByArtifact(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddEmailUsedByArtifact(IWeaverVarAlias<Email> pAlias) {
			var a =	AddEdge<Email, EmailUsedByArtifact, Artifact>(
				pAlias, NewCre.UsedByArtifactId);

			var aueEdge = new ArtifactUsesEmail();

			AddReverseEdge(a, aueEdge, pAlias);
		}

	}


	/*================================================================================================*/
	public partial class CreateFactorOperation : CreateVertexOperation<Factor, FabFactor, CreateFabFactor> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCustom() {
			VerifyCustomFactor();
		}

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
		protected override void AddEdges() {
			AddFactorEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorEdges(IWeaverVarAlias<Factor> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			AddFactorCreatedByMember(pAlias);
			AddFactorDescriptorRefinesPrimaryWithArtifact(pAlias);
			AddFactorDescriptorRefinesRelatedWithArtifact(pAlias);
			AddFactorDescriptorRefinesTypeWithArtifact(pAlias);
			AddFactorUsesPrimaryArtifact(pAlias);
			AddFactorUsesRelatedArtifact(pAlias);
			AddFactorVectorUsesAxisArtifact(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorCreatedByMember(IWeaverVarAlias<Factor> pAlias) {
			var a =	AddEdge<Factor, FactorCreatedByMember, Member>(
				pAlias, NewCre.CreatedByMemberId);

			var mcfEdge = new MemberCreatesFactor();
			mcfEdge.Timestamp = NewDom.Timestamp;
			mcfEdge.DescriptorType = NewDom.DescriptorType;
			mcfEdge.PrimaryArtifactId = NewCre.UsesPrimaryArtifactId;
			mcfEdge.RelatedArtifactId = NewCre.UsesRelatedArtifactId;

			AddReverseEdge(a, mcfEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorDescriptorRefinesPrimaryWithArtifact(IWeaverVarAlias<Factor> pAlias) {
			if ( NewCre.Descriptor == null || NewCre.Descriptor.RefinesPrimaryWithArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
				pAlias, NewCre.Descriptor.RefinesPrimaryWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorDescriptorRefinesRelatedWithArtifact(IWeaverVarAlias<Factor> pAlias) {
			if ( NewCre.Descriptor == null || NewCre.Descriptor.RefinesRelatedWithArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
				pAlias, NewCre.Descriptor.RefinesRelatedWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorDescriptorRefinesTypeWithArtifact(IWeaverVarAlias<Factor> pAlias) {
			if ( NewCre.Descriptor == null || NewCre.Descriptor.RefinesTypeWithArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorDescriptorRefinesTypeWithArtifact, Artifact>(
				pAlias, NewCre.Descriptor.RefinesTypeWithArtifactId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorUsesPrimaryArtifact(IWeaverVarAlias<Factor> pAlias) {
			var a =	AddEdge<Factor, FactorUsesPrimaryArtifact, Artifact>(
				pAlias, NewCre.UsesPrimaryArtifactId);

			var apbfEdge = new ArtifactUsedAsPrimaryByFactor();
			apbfEdge.Timestamp = NewDom.Timestamp;
			apbfEdge.DescriptorType = NewDom.DescriptorType;
			apbfEdge.RelatedArtifactId = NewCre.UsesRelatedArtifactId;

			AddReverseEdge(a, apbfEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorUsesRelatedArtifact(IWeaverVarAlias<Factor> pAlias) {
			var a =	AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
				pAlias, NewCre.UsesRelatedArtifactId);

			var arbfEdge = new ArtifactUsedAsRelatedByFactor();
			arbfEdge.Timestamp = NewDom.Timestamp;
			arbfEdge.DescriptorType = NewDom.DescriptorType;
			arbfEdge.PrimaryArtifactId = NewCre.UsesPrimaryArtifactId;

			AddReverseEdge(a, arbfEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddFactorVectorUsesAxisArtifact(IWeaverVarAlias<Factor> pAlias) {
			if ( NewCre.Vector == null || NewCre.Vector.UsesAxisArtifactId == null ) {
				return;
			}

			var a =	AddEdge<Factor, FactorVectorUsesAxisArtifact, Artifact>(
				pAlias, NewCre.Vector.UsesAxisArtifactId);
		}

	}


	/*================================================================================================*/
	public partial class CreateInstanceOperation : CreateArtifactOperation<Instance, FabInstance, CreateFabInstance> {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCustom() {
			VerifyCustomInstance();
		}

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
		protected override void VerifyCustom() {
			VerifyCustomMember();
		}

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
		protected override void AddEdges() {
			AddMemberEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberEdges(IWeaverVarAlias<Member> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			AddMemberDefinedByApp(pAlias);
			AddMemberDefinedByUser(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberDefinedByApp(IWeaverVarAlias<Member> pAlias) {
			var a =	AddEdge<Member, MemberDefinedByApp, App>(
				pAlias, NewCre.DefinedByAppId);

			var pdmEdge = new AppDefinesMember();
			pdmEdge.Timestamp = NewDom.Timestamp;
			pdmEdge.MemberType = NewDom.MemberType;
			pdmEdge.UserId = NewCre.DefinedByUserId;

			AddReverseEdge(a, pdmEdge, pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddMemberDefinedByUser(IWeaverVarAlias<Member> pAlias) {
			var a =	AddEdge<Member, MemberDefinedByUser, User>(
				pAlias, NewCre.DefinedByUserId);

			var udmEdge = new UserDefinesMember();
			udmEdge.Timestamp = NewDom.Timestamp;
			udmEdge.MemberType = NewDom.MemberType;
			udmEdge.AppId = NewCre.DefinedByAppId;

			AddReverseEdge(a, udmEdge, pAlias);
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
		protected override void AddEdges() {
			AddOauthAccessEdges(NewDomAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddOauthAccessEdges(IWeaverVarAlias<OauthAccess> pAlias) {
			AddVertexEdges(new WeaverVarAlias<Vertex>(pAlias.Name));
			AddOauthAccessAuthenticatesMember(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddOauthAccessAuthenticatesMember(IWeaverVarAlias<OauthAccess> pAlias) {
			var a =	AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
				pAlias, NewCre.AuthenticatesMemberId);

			var maboaEdge = new MemberAuthenticatedByOauthAccess();
			maboaEdge.Timestamp = NewDom.Timestamp;

			AddReverseEdge(a, maboaEdge, pAlias);
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
			IWeaverVarAlias alias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Url>(x => x.FullPath, NewDom.FullPath)
				.ToQueryAsVar("unq", out alias);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+alias.Name+"?0:1);");
			string cmdId = SetupLatestCommand(false, true);

			Checks.Add(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 0 ) {
					throw new FabDuplicateFault(typeof(Url), "FullPath", NewCre.FullPath);
				}
			}));
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
			IWeaverVarAlias alias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, NewDom.NameKey)
				.ToQueryAsVar("unq", out alias);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+alias.Name+"?0:1);");
			string cmdId = SetupLatestCommand(false, true);

			Checks.Add(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 0 ) {
					throw new FabDuplicateFault(typeof(User), "Name", NewCre.Name);
				}
			}));
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
