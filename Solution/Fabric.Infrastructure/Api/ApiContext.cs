using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public class ApiContext : IApiContext {

		public string DbServerUrl { get; private set; }

		public long UserId { get; private set; }
		public long AppId { get; private set; }
		public long MemberId { get; private set; }

		public DateTime UtcNow { get { return DateTime.UtcNow; } }
		public long DbQueryExecutionCount { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pDbServerUrl) {
			DbServerUrl = pDbServerUrl;
			UserId = -1;
			AppId = -1;
			MemberId = -1;
			DbQueryExecutionCount = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetUserAppId(long pUserId, long pAppId) {
			if ( UserId != -1 ) { throw new Exception("UserId and AppId are already set."); }
			UserId = pUserId;
			AppId = pAppId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetMemberId(long pMember) {
			if ( MemberId != -1 ) { throw new Exception("MemberId is already set."); }
			MemberId = MemberId;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess DbData(string pQueryName, IWeaverQuery pQuery) {
			var a = new ApiDataAccess(this, pQuery);
			return DbDataAccess(pQueryName, a);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T DbSingle<T>(string pQueryName, IWeaverQuery pQuery) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pQuery);
			return DbDataAccess(pQueryName, a).TypedResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<T> DbList<T>(string pQueryName, IWeaverQuery pQuery) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pQuery);
			return DbDataAccess(pQueryName, a).TypedResultList;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T DbAddNode<T, TRootRel>(string pQueryName, T pNode,
			                  	        Expression<Func<T,object>> pIndexProp) where T : INode, new()
										where TRootRel : WeaverRel<Root, Contains, T>, new() {
			T newNode = DbSingle<T>(
				pQueryName,
				WeaverTasks.AddNode(pNode)
			);
			
			DbData(
				pQueryName,
				WeaverTasks.AddNodeToIndex(typeof(T).Name, newNode, pIndexProp)
			);
			
			DbData(
				pQueryName,
				WeaverTasks.AddRel(new Root { Id = 0 }, new TRootRel(), newNode)
			);
			
			return newNode;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess DbDataAccess(string pQueryName, ApiDataAccess pDbQuery) {
			Log.Debug("Query ("+pQueryName+") "+DbQueryExecutionCount+": "+pDbQuery.Query);
			
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess<T> DbDataAccess<T>(string pQueryName, ApiDataAccess<T> pDbQuery)
																			where T : INode, new() {
			Log.Debug("Query<"+typeof(T).Name+"> ("+pQueryName+") "+
				DbQueryExecutionCount+": "+pDbQuery.Query);
			
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

	}

}