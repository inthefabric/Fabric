using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Modify.Tasks {

	/*================================================================================================*/
	public interface IModifyTasks {

		IDomainValidator Validator { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Url GetUrlByPath(IApiContext pApiCtx, string pPath);

		/*--------------------------------------------------------------------------------------------*/
		Member GetValidMemberByContext(IApiContext pApiCtx);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Factor GetActiveFactorFromMember(IApiContext pApiCtx, long pFactorId, long pMemberId);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateFactorDescriptor(IApiContext pApiCtx, Factor pFactor, byte pDescTypeId,
										long? pPrimArtRefId, long? pEdgeArtRefId, long? pDescTypeRefId);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateFactorDirector(IApiContext pApiCtx, Factor pFactor, byte pDirTypeId, byte pPrimActId,
																						byte pEdgeActId);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateFactorEventor(IApiContext pApiCtx, Factor pFactor, byte pEveTypeId, byte pEvePrecId,
																						long pDateTime);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateFactorIdentor(IApiContext pApiCtx, Factor pFactor, byte pIdenTypeId, string pValue);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateFactorLocator(IApiContext pApiCtx, Factor pFactor, byte pLocTypeId, double pX,
																				double pY, double pZ);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateFactorVector(IApiContext pApiCtx, Factor pFactor, byte pVecTypeId, long pValue,
												long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId);

		/*--------------------------------------------------------------------------------------------*/
		Factor UpdateFactor(IApiContext pApiCtx, Factor pFactor, bool pCompleted, bool pDeleted);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pPath, string pName,
									IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Url> pUrlVar);

		/*--------------------------------------------------------------------------------------------*/
		long TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
					string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Instance> pInstVar);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId, long pEdgeArtId,
											byte pAssertId, bool pIsDefining, string pNote,
											Member pCreator, out IWeaverVarAlias<Factor> pFactorVar);

	}

}