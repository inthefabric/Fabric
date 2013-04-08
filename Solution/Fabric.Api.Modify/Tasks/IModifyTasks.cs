using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify.Tasks {

	/*================================================================================================*/
	public interface IModifyTasks {

		IDomainValidator Validator { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		Descriptor GetDescriptorMatch(IApiContext pApiCtx, byte pDescTypeId,
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId);

		/*--------------------------------------------------------------------------------------------*/
		Director GetDirectorMatch(IApiContext pApiCtx, byte pDirTypeId, byte pPrimActId,byte pRelActId);

		/*--------------------------------------------------------------------------------------------*/
		Eventor GetEventorMatch(IApiContext pApiCtx, byte pEveTypeId, byte pEvePrecId, long pDateTime);

		/*--------------------------------------------------------------------------------------------*/
		Identor GetIdentorMatch(IApiContext pApiCtx, byte pIdenTypeId, string pValue);

		/*--------------------------------------------------------------------------------------------*/
		Locator GetLocatorMatch(IApiContext pApiCtx, byte pLocTypeId, double pX, double pY, double pZ);

		/*--------------------------------------------------------------------------------------------*/
		Vector GetVectorMatch(IApiContext pApiCtx, byte pVecTypeId, long pValue, long pAxisArtId,
																byte pVecUnitId, byte pVecUnitPrefId);

		/*--------------------------------------------------------------------------------------------*/
		void AttachExistingElement<T, TRel>(IApiContext pApiCtx, Factor pFactor, T pElement)
								where T : class, INode, new() where TRel : IWeaverRel<Factor, T>, new();

		/*--------------------------------------------------------------------------------------------*/
		Factor UpdateFactor(IApiContext pApiCtx, Factor pFactor, bool pCompleted, bool pDeleted);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pAbsoluteUrl, string pName,
									IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Url> pUrlVar);

		/*--------------------------------------------------------------------------------------------*/
		long TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
					string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Instance> pInstVar);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId, long pRelArtId,
											byte pAssertId, bool pIsDefining, string pNote,
											Member pCreator, out IWeaverVarAlias<Factor> pFactorVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDescriptor(IApiContext pApiCtx, TxBuilder pTxBuild, byte pDescTypeId,
						long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId, Factor pFactor,
						out IWeaverVarAlias<Descriptor> pDescVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDirector(IApiContext pApiCtx, TxBuilder pTxBuild, byte pDirTypeId, byte pPrimActId,
								byte pRelActId, Factor pFactor, out IWeaverVarAlias<Director> pDirVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddEventor(IApiContext pApiCtx, TxBuilder pTxBuild, byte pEveTypeId, byte pEvePrecId,
								long pDateTime, Factor pFactor, out IWeaverVarAlias<Eventor> pEveVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddIdentor(IApiContext pApiCtx, TxBuilder pTxBuild, byte pIdenTypeId, string pValue,
												Factor pFactor, out IWeaverVarAlias<Identor> pIdenVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddLocator(IApiContext pApiCtx, TxBuilder pTxBuild, byte pLocTypeId, double pX,
							double pY, double pZ, Factor pFactor, out IWeaverVarAlias<Locator> pLocVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddVector(IApiContext pApiCtx, TxBuilder pTxBuild, byte pVecTypeId, long pValue,
												long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId, 
												Factor pFactor, out IWeaverVarAlias<Vector> pVecVar);

	}

}