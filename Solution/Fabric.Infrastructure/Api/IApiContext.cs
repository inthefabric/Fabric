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

		DateTime UtcNow { get; }
		long DbQueryExecutionCount { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetUserAppId(long pUserId, long pAppId);
		void SetMemberId(long pMember);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted);
		
		/*--------------------------------------------------------------------------------------------*/
		T DbSingle<T>(string pQueryName, IWeaverScript pScripted) where T : INodeWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted) where T : INodeWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		T DbAddNode<T, TRootRel>(string pQueryName, T pNode, Expression<Func<T,object>> pIndexProp)
			where T : INode, INodeWithId, new() where TRootRel : WeaverRel<Root, Contains, T>, new();

	}

}