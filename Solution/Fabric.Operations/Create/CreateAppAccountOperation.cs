using System;
using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public class CreateAppAccountOperation { //TEST: CreateAppAccountOperation (unit)

		public enum ResultStatus {
			Success = 1,
			DuplicateAppName,
			NotFoundMemberOrUser,
			UnexpectedError
		};

		public struct Result {
			public ResultStatus Status;
			public App NewApp;
			public Member NewMember;
		};

		private IOperationContext vOpCtx;
		private ICreateOperationBuilder vBuild;
		private CreateOperationTasks vTasks;
		private string vName;
		private long vCreatorMemberId;
		private long vUserId;
		private IDataAccess vDataAcc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Result Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
					CreateOperationTasks pTasks, string pName, long pCreatorMemberId, long pUserId) {
			vOpCtx = pOpCtx;
			vBuild = pBuild;
			vTasks = pTasks;
			
			vDataAcc = vOpCtx.Data.Build(null, true);
			vBuild.SetDataAccess(vDataAcc);

			vName = pName;
			vCreatorMemberId = pCreatorMemberId;
			vUserId = pUserId;

			try {
				return ExecuteSession();
			}
			catch ( FabDuplicateFault ) {
				return new Result {
					Status = ResultStatus.DuplicateAppName
				};
			}
			catch ( FabNotFoundFault ) {
				return new Result {
					Status = ResultStatus.NotFoundMemberOrUser
				};
			}
			catch ( Exception ) {
				return new Result {
					Status = ResultStatus.UnexpectedError
				};
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private Result ExecuteSession() {
			long appId = vOpCtx.GetSharpflakeId<Vertex>();
			long memId = vOpCtx.GetSharpflakeId<Vertex>();

			var appCre = new CreateFabApp();
			appCre.Name = vName;
			appCre.Secret = vOpCtx.Code32;
			appCre.CreatedByMemberId = vCreatorMemberId;

			var memCre = new CreateFabMember();
			memCre.Type = (byte)MemberType.Id.DataProv;
			memCre.DefinedByAppId = appId;
			memCre.DefinedByUserId = vUserId;

			////

			var appOp = new CreateAppOperation();
			appOp.SetExecuteData(vOpCtx, vBuild, vTasks, appCre, appId, vDataAcc, false);

			var memOp = new CreateMemberOperation();
			memOp.SetExecuteData(vOpCtx, vBuild, vTasks, memCre, memId, vDataAcc, false);

			////

			vBuild.StartSession();
			appOp.CheckAndAddVertex();
			memOp.CheckAndAddVertex();
			appOp.AddEdges();
			memOp.AddEdges();
			vBuild.CommitAndCloseSession();

			////
			
			IDataResult res = vDataAcc.Execute(GetType().Name);
			vBuild.PerformChecks(res);

			int appCmdI = res.GetCommandIndexByCmdId(appOp.AddVertexCommandId);
			int memCmdI = res.GetCommandIndexByCmdId(memOp.AddVertexCommandId);

			return new Result {
				Status = ResultStatus.Success,
				NewApp = res.ToElementAt<App>(appCmdI, 0),
				NewMember = res.ToElementAt<Member>(memCmdI, 0)
			};
		}

	}

}