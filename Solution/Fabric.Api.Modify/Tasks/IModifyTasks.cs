using Fabric.Api.Modify.Validators;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify.Tasks {

	/*================================================================================================*/
	public interface IModifyTasks {

		IDomainValidator Validator { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		User GetUserByName(IApiContext pApiCtx, string pName);

		/*--------------------------------------------------------------------------------------------*/
		User GetUser(IApiContext pApiCtx, long pUserId);

		/*--------------------------------------------------------------------------------------------*/
		App GetAppByName(IApiContext pApiCtx, string pName);

		/*--------------------------------------------------------------------------------------------*/
		Url GetUrlByAbsoluteUrl(IApiContext pApiCtx, string pAbsoluteUrl);

		/*--------------------------------------------------------------------------------------------*/
		Member GetValidMemberByContext(IApiContext pApiCtx);

		/*--------------------------------------------------------------------------------------------*/
		Class GetClassByNameDisamb(IApiContext pApiCtx, string pName, string pDisamb);

		/*--------------------------------------------------------------------------------------------*/
		Artifact GetArtifact(IApiContext pApiCtx, long pArtifactId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Factor GetActiveFactorFromMember(IApiContext pApiCtx, long pFactorId, long pMemberId);

		/*--------------------------------------------------------------------------------------------*/
		LocatorType GetLocatorType(IApiContext pApiCtx, long pLocTypeId);

		/*--------------------------------------------------------------------------------------------*/
		bool FactorHasDescriptor(IApiContext pApiCtx, Factor pFactor);

		/*--------------------------------------------------------------------------------------------*/
		bool FactorHasDirector(IApiContext pApiCtx, Factor pFactor);

		/*--------------------------------------------------------------------------------------------*/
		bool FactorHasEventor(IApiContext pApiCtx, Factor pFactor);

		/*--------------------------------------------------------------------------------------------*/
		bool FactorHasIdentor(IApiContext pApiCtx, Factor pFactor);

		/*--------------------------------------------------------------------------------------------*/
		bool FactorHasLocator(IApiContext pApiCtx, Factor pFactor);

		/*--------------------------------------------------------------------------------------------*/
		bool FactorHasVector(IApiContext pApiCtx, Factor pFactor);

		/*--------------------------------------------------------------------------------------------*/
		Descriptor GetDescriptorMatch(IApiContext pApiCtx, long pDescTypeId,
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId);

		/*--------------------------------------------------------------------------------------------*/
		Director GetDirectorMatch(IApiContext pApiCtx, long pDirTypeId,long pPrimActId,long pRelActId);

		/*--------------------------------------------------------------------------------------------*/
		Eventor GetEventorMatch(IApiContext pApiCtx, long pEveTypeId, long pEvePrecId, long pDateTime);

		/*--------------------------------------------------------------------------------------------*/
		Identor GetIdentorMatch(IApiContext pApiCtx, long pIdenTypeId, string pValue);

		/*--------------------------------------------------------------------------------------------*/
		Locator GetLocatorMatch(IApiContext pApiCtx, long pLocTypeId, double pX, double pY, double pZ);

		/*--------------------------------------------------------------------------------------------*/
		void AttachExistingElement<T, TRel>(IApiContext pApiCtx, Factor pFactor, T pElement)
								where T : class, INode, new() where TRel : IWeaverRel<Factor, T>, new();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddEmail(IApiContext pApiCtx, TxBuilder pTxBuild, string pAddress,
								IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Email> pEmailVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddUser(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pPassword,
									IWeaverVarAlias<Root> pRootVar, IWeaverVarAlias<Email> pEmailVar,
									out IWeaverVarAlias<User> pUserVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
								IWeaverVarAlias<User> pUserVar, out IWeaverVarAlias<Member> pMemVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddArtifact<TNode, TNodeHasArt>(IApiContext pApiCtx, TxBuilder pTxBuild, 
							ArtifactTypeId pArtTypeId, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<TNode> pNodeVar, IWeaverVarAlias<Member> pMemVar, 
							out IWeaverVarAlias<Artifact> pArtVar)
							where TNode : INode where TNodeHasArt : IWeaverRel<TNode, Artifact>, new();

		/*--------------------------------------------------------------------------------------------*/
		void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName,
						IWeaverVarAlias<Root> pRootVar, long pUserId, out IWeaverVarAlias<App> pAppVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild,IWeaverVarAlias<Root> pRootVar, 
					IWeaverVarAlias<App> pAppVar, long pUserId, out IWeaverVarAlias<Member> pMemVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pAbsoluteUrl, string pName,
									IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Url> pUrlVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
					string pNote, IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Class> pClassVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Instance> pInstVar);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId, long pRelArtId,
											long pAssertId, bool pIsDefining, string pNote,
											Member pCreator, out IWeaverVarAlias<Factor> pFactorVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDescriptor(IApiContext pApiCtx, TxBuilder pTxBuild, long pDescTypeId,
						long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId, Factor pFactor,
						out IWeaverVarAlias<Descriptor> pDescVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDirector(IApiContext pApiCtx, TxBuilder pTxBuild, long pDirTypeId, long pPrimActId,
			long pRelActId, Factor pFactor, out IWeaverVarAlias<Director> pDirVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddEventor(IApiContext pApiCtx, TxBuilder pTxBuild, long pEveTypeId, long pEvePrecId,
								long pDateTime, Factor pFactor, out IWeaverVarAlias<Eventor> pEveVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddIdentor(IApiContext pApiCtx, TxBuilder pTxBuild, long pIdenTypeId, string pValue,
												Factor pFactor, out IWeaverVarAlias<Identor> pIdenVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddLocator(IApiContext pApiCtx, TxBuilder pTxBuild, long pLocTypeId, double pX,
							double pY, double pZ, Factor pFactor, out IWeaverVarAlias<Locator> pLocVar);
		
	}

}