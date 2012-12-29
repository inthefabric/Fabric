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
		public ApiDataAccess DbData(IWeaverQuery pQuery) {
			var a = new ApiDataAccess(this, pQuery);
			return DbDataAccess(a);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T DbSingle<T>(IWeaverQuery pQuery) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pQuery);
			return DbDataAccess(a).TypedResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<T> DbList<T>(IWeaverQuery pQuery) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pQuery);
			return DbDataAccess(a).TypedResultList;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T DbAddNode<T, TRootRel>(T pNode, Expression<Func<T,object>> pIndexProp)
		where T : INode, new() where TRootRel : WeaverRel<Root, Contains, T>, new() {
			T newNode = DbSingle<T>(
				WeaverTasks.AddNode(pNode)
			);
			
			DbData(
				WeaverTasks.AddNodeToIndex(typeof(T).Name, newNode, pIndexProp)
			);
			
			DbData(
				WeaverTasks.AddRel(new Root { Id = 0 }, new TRootRel(), newNode)
			);
			
			return newNode;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess DbDataAccess(ApiDataAccess pDbQuery) {
			Log.Debug("Query "+DbQueryExecutionCount+": "+pDbQuery.Query);
			
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess<T> DbDataAccess<T>(ApiDataAccess<T> pDbQuery) where T : INode, new() {
			Log.Debug("Query<"+typeof(T).Name+"> "+DbQueryExecutionCount+": "+pDbQuery.Query);
			
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

	}

}