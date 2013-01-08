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
		public DateTime UtcNow {
			get { return DateTime.UtcNow; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public string Code32 {
			get { return FabricUtil.Code32; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public long GetSharpflakeId<T>() where T : INode {
			return Sharpflake.GetId<T>();
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted) {
			var a = new ApiDataAccess(this, pScripted);
			return DbDataAccess(pQueryName, a);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T DbSingle<T>(string pQueryName, IWeaverScript pScripted)
																where T : class, INodeWithId, new() {
			var a = new ApiDataAccess<T>(this, pScripted);
			IApiDataAccess<T> da = DbDataAccess(pQueryName, a);

			if ( da.TypedResult != null ) {
				return da.TypedResult;
			}

			if ( da.TypedResultList != null && da.TypedResultList.Count == 1 ) {
				return da.TypedResultList[0];
			}

			return default(T);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted)
																		where T : INodeWithId, new() {
			var a = new ApiDataAccess<T>(this, pScripted);
			return DbDataAccess(pQueryName, a).TypedResultList;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T DbAddNode<T, TRootRel>(string pQueryName, T pNode,
					Expression<Func<T,object>> pIndexProp) where T : class, INode, INodeWithId, new()
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
		private IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			Log.Debug("Query ("+pQueryName+") "+DbQueryExecutionCount+": "+pDbQuery.Query);
			
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess<T> DbDataAccess<T>(string pQueryName, IApiDataAccess<T> pDbQuery)
																		where T : INodeWithId, new() {
			Log.Debug("Query<"+typeof(T).Name+"> ("+pQueryName+") "+
				DbQueryExecutionCount+": "+pDbQuery.Query);
			
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

	}

}