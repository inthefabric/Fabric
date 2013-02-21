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

		public Guid ContextId { get; private set; }
		public long UserId { get; private set; }
		public long AppId { get; private set; }
		//public long MemberId { get; private set; }

		public long DbQueryExecutionCount { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pDbServerUrl) {
			ContextId = Guid.NewGuid();
			DbServerUrl = pDbServerUrl;
			UserId = -1;
			AppId = -1;
			//MemberId = -1;
			DbQueryExecutionCount = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetAppUserId(long? pAppId, long? pUserId) {
			if ( AppId != -1 ) { throw new Exception("UserId and AppId are already set."); }
			AppId = (pAppId ?? 0);
			UserId = (pUserId ?? 0);
		}

		/*--------------------------------------------------------------------------------------------* /
		public void SetMemberId(long pMemberId) {
			if ( MemberId != -1 ) { throw new Exception("MemberId is already set."); }
			MemberId = MemberId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual DateTime UtcNow {
			get { return DateTime.UtcNow; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual string Code32 {
			get { return FabricUtil.Code32; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual long GetSharpflakeId<T>() where T : INode {
			return Sharpflake.GetId<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted) {
			var a = NewAccess(pScripted);
			return DbDataAccess(pQueryName, a);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T DbSingle<T>(string pQueryName, IWeaverScript pScripted)
																where T : class, IItemWithId, new() {
			var a = NewAccess<T>(pScripted);
			IApiDataAccess<T> da = DbDataAccess(pQueryName, a);

			if ( da.TypedResultList == null || da.TypedResultList.Count == 0 ) {
				return default(T);
			}
			
			if ( da.TypedResultList.Count > 1 ) {
				throw new Exception("DbSingle<"+typeof(T).Name+"> expects 1 result, but received "+
					da.TypedResultList.Count);
			}

			return da.TypedResultList[0];
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted)
																		where T : IItemWithId, new() {
			var a = NewAccess<T>(pScripted);
			return DbDataAccess(pQueryName, a).TypedResultList;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T DbAddNode<T, TRootRel>(string pQueryName, T pNode,
															Expression<Func<T, object>> pIndexProp)
												where T : class, INode, IItemWithId, new()
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
		protected virtual IApiDataAccess NewAccess(IWeaverScript pScripted) {
			return new ApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted)
																		where T : IItemWithId, new() {
			return new ApiDataAccess<T>(this, pScripted);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess<T> DbDataAccess<T>(string pQueryName,
											IApiDataAccess<T> pDbQuery) where T : IItemWithId, new() {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

	}

}