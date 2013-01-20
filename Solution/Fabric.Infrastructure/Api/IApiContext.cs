﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public interface IApiContext {

		string DbServerUrl { get; }

		Guid ContextId { get; }
		long UserId { get; }
		long AppId { get; }
		//long MemberId { get; }

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
		IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted);
		
		/*--------------------------------------------------------------------------------------------*/
		T DbSingle<T>(string pQueryName, IWeaverScript pScripted) where T : class, INodeWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted) where T : INodeWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		T DbAddNode<T, TRootRel>(string pQueryName, T pNode, Expression<Func<T,object>> pIndexProp)
												where T : class, INode, INodeWithId, new()
												where TRootRel : WeaverRel<Root, Contains, T>, new();

	}

}