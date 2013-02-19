using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Web.Tasks {

	/*================================================================================================*/
	public interface IWebTasks {

		IDomainValidator Validator { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		User GetUserByName(IApiContext pApiCtx, string pName);

		/*--------------------------------------------------------------------------------------------*/
		User GetUser(IApiContext pApiCtx, long pUserId);

		/*--------------------------------------------------------------------------------------------*/
		App GetAppByName(IApiContext pApiCtx, string pName);

		/*--------------------------------------------------------------------------------------------*/
		User UpdateUserPassword(IApiContext pApiCtx, long pUserId, string pPassword);


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
		void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName,
						IWeaverVarAlias<Root> pRootVar, long pUserId, out IWeaverVarAlias<App> pAppVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild,IWeaverVarAlias<Root> pRootVar, 
					IWeaverVarAlias<App> pAppVar, long pUserId, out IWeaverVarAlias<Member> pMemVar);

	}

}