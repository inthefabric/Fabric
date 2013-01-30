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

	}

}