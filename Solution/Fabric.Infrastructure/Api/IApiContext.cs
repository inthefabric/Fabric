using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public interface IApiContext {

		string GremlinUrl { get; }

		Guid ContextId { get; }
		long UserId { get; }
		long AppId { get; }
		//long MemberId { get; }
		AnalyticsManager Analytics { get; }

		long DbQueryExecutionCount { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetAppUserId(long? pAppId, long? pUserId);
		//void SetMemberId(long pMemberId);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DateTime UtcNow { get; }
		string Code32 { get; }
		long GetSharpflakeId<T>() where T : INode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool AddToCache<T>(string pKey, T pItem, int pExpiresInSec);
		T GetFromCache<T>(string pKey);
		T RemoveFromCache<T>(string pKey);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted);
		
		/*--------------------------------------------------------------------------------------------*/
		T DbSingle<T>(string pQueryName, IWeaverScript pScripted) where T : class, IItemWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted) where T : IItemWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		T DbAddNode<T, TRootRel>(string pQueryName, T pNode, Expression<Func<T,object>> pIndexProp)
												where T : class, INode, IItemWithId, new()
												where TRootRel : WeaverRel<Root, Contains, T>, new();

	}

}