using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public interface IApiContext {

		string DbServerUrl { get; }

		long UserId { get; }
		long AppId { get; }
		long MemberId { get; }

		long DbQueryExecutionCount { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetUserAppId(long pUserId, long pAppId);
		void SetMemberId(long pMember);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		ApiDataAccess ExecuteQuery(string pScript, IDictionary<string, string> pParams=null);
		ApiDataAccess ExecuteQuery(IWeaverQuery pQuery);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T QueryForSingle<T>(string pScript,
									IDictionary<string, string> pParams=null) where T : INode, new();

		/*--------------------------------------------------------------------------------------------*/
		T QueryForSingle<T>(IWeaverQuery pQuery) where T : INode, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> QueryForList<T>(string pScript,
									IDictionary<string, string> pParams=null) where T : INode, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> QueryForList<T>(IWeaverQuery pQuery) where T : INode, new();

			
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T ExecuteAddNodeQuery<T, TRootRel>(T pNode, Expression<Func<T,object>> pIndexProp)
						where T : INode, new() where TRootRel : WeaverRel<Root, Contains, T>, new();

	}

}