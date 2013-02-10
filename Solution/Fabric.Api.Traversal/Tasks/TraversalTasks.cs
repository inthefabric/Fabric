using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Api.Dto.Traversal;
using Weaver;
using Weaver.Interfaces;
using Fabric.Domain;
using Weaver.Functions;
using Fabric.Db.Data;
using Fabric.Api.Dto;

namespace Fabric.Api.Traversal.Tasks {
	
	/*================================================================================================*/
	public class TraversalTasks : ITraversalTasks { //TEST: TraversalTasks
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUser GetUserByContext(IApiContext pApiCtx) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(new User { UserId = pApiCtx.UserId }).End();
			IApiDataAccess data = pApiCtx.DbData("GetUserByContext", q);
			return BuildFabObject<FabUser>(data);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabApp GetAppByContext(IApiContext pApiCtx) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(new App { AppId = pApiCtx.AppId }).End();
			IApiDataAccess data = pApiCtx.DbData("GetAppByContext", q);
			return BuildFabObject<FabApp>(data);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabMember GetMemberByContext(IApiContext pApiCtx) {
			IWeaverFuncAs<Member> memAlias;
			
			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new User { UserId = pApiCtx.UserId })
					.DefinesMemberList.ToMember
					.As(out memAlias)
					.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, pApiCtx.AppId)
					.Back(memAlias)
					.End();
			
			IApiDataAccess data = pApiCtx.DbData("GetMemberByContext", q);
			return BuildFabObject<FabMember>(data);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private T BuildFabObject<T>(IApiDataAccess pData) where T : IFabObject, new() {
			if ( pData.ResultDtoList.Count == 0 ) {
				return default(T);
			}
			
			var obj = new T();
			obj.Fill(pData.ResultDtoList[1]);
			return obj;
		}
		
	}
	
}