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
		ApiDataAccess DbData(IWeaverQuery pQuery);

		/*--------------------------------------------------------------------------------------------*/
		T DbSingle<T>(IWeaverQuery pQuery) where T : INode, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> DbList<T>(IWeaverQuery pQuery) where T : INode, new();

		/*--------------------------------------------------------------------------------------------*/
		T DbAddNode<T, TRootRel>(T pNode, Expression<Func<T,object>> pIndexProp)
			where T : INode, new() where TRootRel : WeaverRel<Root, Contains, T>, new();

	}

}