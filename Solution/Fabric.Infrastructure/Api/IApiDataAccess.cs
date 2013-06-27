using Fabric.Domain;
using RexConnectClient.Core.Result;
using Weaver.Exec.RexConnect;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess {

		IApiContext ApiCtx { get; }
		WeaverRequest Request { get; }
		IResponseResult Result { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Execute();

		/*--------------------------------------------------------------------------------------------*/
		int GetResultCount();
		T GetResultAt<T>(int pIndex) where T : IItemWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		int GetTextListCount();
		string GetStringResultAt(int pIndex);
		int GetIntResultAt(int pIndex);
		long GetLongResultAt(int pIndex);

	}

}