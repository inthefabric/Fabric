﻿using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess {

		IApiContext ApiCtx { get; }

		string Script { get; }
		IDictionary<string, IWeaverQueryVal> Params { get; }
		RexConnTcpRequest Request { get; }

		string ResponseJson { get; }
		RexConnTcpResponse Response { get; }
		IDbResult Result { get; }
		IList<IDbDto> ResultDtoList { get; }


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