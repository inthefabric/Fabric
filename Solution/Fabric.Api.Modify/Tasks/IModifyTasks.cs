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
		void AttachDescriptor(IApiContext pApiCtx, Factor pFactor, byte pDescTypeId,
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId);

		/*--------------------------------------------------------------------------------------------*/
		void AttachDirector(IApiContext pApiCtx, Factor pFactor, byte pDirTypeId, byte pPrimActId,
																						byte pRelActId);

		/*--------------------------------------------------------------------------------------------*/
		void AttachEventor(IApiContext pApiCtx, Factor pFactor, byte pEveTypeId, byte pEvePrecId,
																						long pDateTime);

		/*--------------------------------------------------------------------------------------------*/
		void AttachIdentor(IApiContext pApiCtx, Factor pFactor, byte pIdenTypeId, string pValue);

		/*--------------------------------------------------------------------------------------------*/
		void AttachLocator(IApiContext pApiCtx, Factor pFactor, byte pLocTypeId, double pX,
																				double pY, double pZ);

		/*--------------------------------------------------------------------------------------------*/
		void AttachVector(IApiContext pApiCtx, Factor pFactor, byte pVecTypeId, long pValue,
												long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId);

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

	}

}