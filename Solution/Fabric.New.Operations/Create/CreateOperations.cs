﻿
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {
			

	/*================================================================================================*/
	public class CreateAppOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<App> vVertexAlias;
		private CreateFabApp vCreateObj;
		private App vDomObj;
		private FabApp vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<App>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabApp GetFabAppResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabApp input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabApp, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<App> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromApp(ExecuteTx<App>()); //vDomObj
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}


	/*================================================================================================*/
	public abstract class CreateArtifactOperation : CreateVertexOperation {}
			

	/*================================================================================================*/
	public class CreateClassOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Class> vVertexAlias;
		private CreateFabClass vCreateObj;
		private Class vDomObj;
		private FabClass vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Class>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabClass GetFabClassResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabClass input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabClass, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Class> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromClass(ExecuteTx<Class>()); //vDomObj
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
		private Email vDomObj;
		private FabEmail vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Email>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabEmail GetFabEmailResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabEmail input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabEmail, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Email> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromEmail(ExecuteTx<Email>()); //vDomObj
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Artifact> ebaAlias =
				AddEdge<Email, EmailUsedByArtifact, Artifact>(
					vVertexAlias, vCreateObj.UsedByArtifactId);

			var aueEdge = new ArtifactUsesEmail();

			AddReverseEdge(ebaAlias, aueEdge, vVertexAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateFactorOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<Factor> vVertexAlias;
		private CreateFabFactor vCreateObj;
		private Factor vDomObj;
		private FabFactor vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Factor>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabFactor GetFabFactorResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabFactor input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabFactor, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Factor> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromFactor(ExecuteTx<Factor>()); //vDomObj
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Member> fcbmAlias =
				AddEdge<Factor, FactorCreatedByMember, Member>(
					vVertexAlias, vCreateObj.CreatedByMemberId);

			var mcfEdge = new MemberCreatesFactor();
			mcfEdge.Timestamp = vDomObj.Timestamp;
			mcfEdge.DescriptorType = vDomObj.DescriptorType;
			mcfEdge.PrimaryArtifactId = vCreateObj.UsesPrimaryArtifactId;
			mcfEdge.RelatedArtifactId = vCreateObj.UsesRelatedArtifactId;

			AddReverseEdge(fcbmAlias, mcfEdge, vVertexAlias);

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

			var apbfEdge = new ArtifactUsedAsPrimaryByFactor();
			apbfEdge.Timestamp = vDomObj.Timestamp;
			apbfEdge.DescriptorType = vDomObj.DescriptorType;
			apbfEdge.RelatedArtifactId = vCreateObj.UsesRelatedArtifactId;

			AddReverseEdge(fpaAlias, apbfEdge, vVertexAlias);

			////

			IWeaverVarAlias<Artifact> fraAlias =
				AddEdge<Factor, FactorUsesRelatedArtifact, Artifact>(
					vVertexAlias, vCreateObj.UsesRelatedArtifactId);

			var arbfEdge = new ArtifactUsedAsRelatedByFactor();
			arbfEdge.Timestamp = vDomObj.Timestamp;
			arbfEdge.DescriptorType = vDomObj.DescriptorType;
			arbfEdge.PrimaryArtifactId = vCreateObj.UsesPrimaryArtifactId;

			AddReverseEdge(fraAlias, arbfEdge, vVertexAlias);

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
		private Instance vDomObj;
		private FabInstance vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Instance>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabInstance GetFabInstanceResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabInstance input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabInstance, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Instance> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromInstance(ExecuteTx<Instance>()); //vDomObj
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
		private Member vDomObj;
		private FabMember vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Member>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabMember GetFabMemberResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabMember input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabMember, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Member> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromMember(ExecuteTx<Member>()); //vDomObj
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<App> mdbpAlias =
				AddEdge<Member, MemberDefinedByApp, App>(
					vVertexAlias, vCreateObj.DefinedByAppId);

			var pdmEdge = new AppDefinesMember();
			pdmEdge.Timestamp = vDomObj.Timestamp;
			pdmEdge.MemberType = vDomObj.MemberType;
			pdmEdge.UserId = vCreateObj.DefinedByUserId;

			AddReverseEdge(mdbpAlias, pdmEdge, vVertexAlias);

			////

			IWeaverVarAlias<User> mdbuAlias =
				AddEdge<Member, MemberDefinedByUser, User>(
					vVertexAlias, vCreateObj.DefinedByUserId);

			var udmEdge = new UserDefinesMember();
			udmEdge.Timestamp = vDomObj.Timestamp;
			udmEdge.MemberType = vDomObj.MemberType;
			udmEdge.AppId = vCreateObj.DefinedByAppId;

			AddReverseEdge(mdbuAlias, udmEdge, vVertexAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateOauthAccessOperation : CreateVertexOperation {
		
		private IWeaverVarAlias<OauthAccess> vVertexAlias;
		private CreateFabOauthAccess vCreateObj;
		private OauthAccess vDomObj;
		private FabOauthAccess vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<OauthAccess>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess GetFabOauthAccessResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabOauthAccess input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabOauthAccess, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<OauthAccess> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromOauthAccess(ExecuteTx<OauthAccess>()); //vDomObj
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);

			////

			IWeaverVarAlias<Member> oaamAlias =
				AddEdge<OauthAccess, OauthAccessAuthenticatesMember, Member>(
					vVertexAlias, vCreateObj.AuthenticatesMemberId);

			var maboaEdge = new MemberAuthenticatedByOauthAccess();
			maboaEdge.Timestamp = vDomObj.Timestamp;

			AddReverseEdge(oaamAlias, maboaEdge, vVertexAlias);
		}

	}
			

	/*================================================================================================*/
	public class CreateUrlOperation : CreateArtifactOperation {
		
		private IWeaverVarAlias<Url> vVertexAlias;
		private CreateFabUrl vCreateObj;
		private Url vDomObj;
		private FabUrl vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<Url>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabUrl GetFabUrlResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabUrl input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabUrl, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<Url> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromUrl(ExecuteTx<Url>()); //vDomObj
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
		private User vDomObj;
		private FabUser vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetVertexAlias<T>(IWeaverVarAlias<T> pAlias) {
			base.SetVertexAlias(pAlias);
			vVertexAlias = (IWeaverVarAlias<User>)pAlias;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabUser GetFabUserResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override FabObject GetResult() {
			return vResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Create(IOperationContext pOpCtx, string pJson) {
			OpCtx = pOpCtx;
			
			CreateFabUser input;
			vDomObj = ConvertInput(pJson, ApiToDomain.FromCreateFabUser, out input);
			vCreateObj = input;
		
			IWeaverVarAlias<User> domVar;
			TxBuild = new TxBuilder();
			TxBuild.AddVertex(vDomObj, out domVar);
			SetVertexAlias(domVar);
			CreateEdges(input);

			vResult = DomainToApi.FromUser(ExecuteTx<User>()); //vDomObj
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CreateEdges<T>(T pCreateObj) {
			base.CreateEdges(pCreateObj);
		}

	}


	/*================================================================================================*/
	public abstract class CreateVertexOperation : CreateOperationBase {}

}