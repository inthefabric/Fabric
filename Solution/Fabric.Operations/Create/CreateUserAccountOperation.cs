using System;
using Fabric.Api.Objects;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Weaver.Core.Query;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public class CreateUserAccountOperation { //TEST: CreateUserAccountOperation (unit)

		public enum ResultStatus {
			Success = 1,
			DuplicateEmail,
			DuplicateUsername,
			UnexpectedError
		};

		public struct Result {
			public ResultStatus Status;
			public User NewUser;
			public Member NewMember;
			public Email NewEmail;
		};

		private IOperationContext vOpCtx;
		private ICreateOperationBuilder vBuild;
		private CreateOperationTasks vTasks;
		private string vEmail;
		private string vUsername;
		private string vPassword;
		private IDataAccess vDataAcc;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Result Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
					CreateOperationTasks pTasks, string pEmail, string pUsername, string pPassword) {
			vOpCtx = pOpCtx;
			vBuild = pBuild;
			vTasks = pTasks;

			vDataAcc = vOpCtx.Data.Build(null, true);
			vBuild.SetDataAccess(vDataAcc);

			vEmail = pEmail;
			vUsername = pUsername;
			vPassword = pPassword;

			try {
				if ( FindDuplicateEmail() ) {
					return new Result {
						Status = ResultStatus.DuplicateEmail
					};
				}

				return ExecuteSession();
			}
			catch ( FabDuplicateFault ) {
				return new Result {
					Status = ResultStatus.DuplicateUsername
				};
			}
			catch ( Exception ) {
				return new Result {
					Status = ResultStatus.UnexpectedError
				};
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private bool FindDuplicateEmail() {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Email>(x => x.Address, vEmail)
				.ToQuery();

			Email e = vOpCtx.Data.Get<Email>(q, GetType().Name+"-FindDuplicateEmail");
			return (e != null);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private Result ExecuteSession() {
			long userId = vOpCtx.GetSharpflakeId<Vertex>();
			long memId = vOpCtx.GetSharpflakeId<Vertex>();
			long emailId = vOpCtx.GetSharpflakeId<Vertex>();

			var userCre = new CreateFabUser();
			userCre.Name = vUsername;
			userCre.Password = vPassword;
			userCre.CreatedByMemberId = memId;

			var memCre = new CreateFabMember();
			memCre.Type = (byte)MemberType.Id.Member;
			memCre.DefinedByAppId = (long)SetupAppId.FabSys;
			memCre.DefinedByUserId = userId;

			var emailCre = new CreateFabEmail();
			emailCre.Address = vEmail;
			emailCre.Code = vOpCtx.Code32;
			emailCre.UsedByArtifactId = userId;

			////

			var userOp = new CreateUserOperation();
			userOp.SetExecuteData(vOpCtx, vBuild, vTasks, userCre, userId, vDataAcc, false);

			var memOp = new CreateMemberOperation();
			memOp.SetExecuteData(vOpCtx, vBuild, vTasks, memCre, memId, vDataAcc, false);

			var emailOp = new CreateEmailOperation();
			emailOp.SetExecuteData(vOpCtx, vBuild, vTasks, emailCre, emailId, vDataAcc, false);

			////

			vBuild.StartSession();
			userOp.CheckAndAddVertex();
			memOp.CheckAndAddVertex();
			emailOp.CheckAndAddVertex();
			userOp.AddEdges();
			memOp.AddEdges();
			emailOp.AddEdges();
			vBuild.CommitAndCloseSession();

			////
			
			IDataResult res = vDataAcc.Execute(GetType().Name);
			vBuild.PerformChecks(res);

			int userCmdI = res.GetCommandIndexByCmdId(userOp.AddVertexCommandId);
			int memCmdI = res.GetCommandIndexByCmdId(memOp.AddVertexCommandId);
			int emailCmdI = res.GetCommandIndexByCmdId(emailOp.AddVertexCommandId);

			return new Result {
				Status = ResultStatus.Success,
				NewUser = res.ToElementAt<User>(userCmdI, 0),
				NewMember = res.ToElementAt<Member>(memCmdI, 0),
				NewEmail = res.ToElementAt<Email>(emailCmdI, 0)
			};
		}

	}

}