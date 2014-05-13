using System.Collections.Generic;
using Fabric.Database.Init;
using Fabric.Domain;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Operations.Internal {

	/*================================================================================================*/
	public class InternalRemoveMemberOperation {

		private static readonly Logger Log = Logger.Build<InternalRemoveMemberOperation>();

		private IOperationContext vOpCtx { get; set; }
		private DataSet vDataSet;
		private object vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPass, string pMemId, string pDelete) {
			vOpCtx = pOpCtx;

#if LIVE && !DEBUG
			vResult = new {
				Error = "Not allowed in Release mode."
			};

			return;
#endif

			if ( pPass != "internalFab030" ) {
				vResult = new {
					Error = "Password required."
				};

				return;
			}

			long memId = long.Parse(pMemId);
			bool delete = (pDelete == "1");

			Member mem = pOpCtx.Data.GetVertexById<Member>(memId);

			if ( mem == null ) {
				vResult = new {
					Error = "Member "+memId+" not found."
				};
				return;
			}

			const string qName = "Internal-RemoveMember-";
			
			IWeaverQuery getUser = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, memId)
				.DefinedByUser.ToUser
				.ToQuery();

			IWeaverQuery getApp = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, memId)
				.DefinedByApp.ToApp
				.ToQuery();

			User user = pOpCtx.Data.Get<User>(getUser, qName+"GetUser");
			App app = pOpCtx.Data.Get<App>(getApp, qName+"GetApp");
			
			if ( user == null || app == null ) {

				vResult = new {
					Member = new {
						VertexId = mem.VertexId+"",
					},
					NullUser = (user == null),
					NullApp = (app == null),
				};

				return;
			};

			IWeaverQuery getUserEdge = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, user.VertexId)
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, app.VertexId)
				.ToQuery();

			IWeaverQuery getAppEdge = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, app.VertexId)
				.DefinesMembers
					.Has(x => x.UserId, WeaverStepHasOp.EqualTo, user.VertexId)
				.ToQuery();

			IDataResult userEdge = pOpCtx.Data.Execute(getUserEdge, qName+"GetUserEdge");
			IDataResult appEdge = pOpCtx.Data.Execute(getAppEdge, qName+"GetAppEdge");

			IList<UserDefinesMember> userDefs = userEdge.ToElementList<UserDefinesMember>();
			IList<AppDefinesMember> appDefs = appEdge.ToElementList<AppDefinesMember>();

			if ( userDefs.Count != 1 && appDefs.Count != 1 ) {
				delete = false;
			}

			UserDefinesMember remUserDef = null;
			AppDefinesMember remAppDef = null;
			Member remMem = null;

			if ( delete ) {
				IWeaverQuery removeUserDefQ = Weave.Inst.Graph
					.E.Id<UserDefinesMember>(userDefs[0].Id)
						.Remove()
					.ToQuery();

				IWeaverQuery removeAppDefQ = Weave.Inst.Graph
					.E.Id<AppDefinesMember>(appDefs[0].Id)
						.Remove()
					.ToQuery();

				IWeaverQuery removeMemQ = Weave.Inst.Graph
					.V.ExactIndex<Member>(x => x.VertexId, memId)
						.Remove()
					.ToQuery();

				remUserDef = pOpCtx.Data.Get<UserDefinesMember>(removeUserDefQ, qName+"RemUserDef");
				remAppDef = pOpCtx.Data.Get<AppDefinesMember>(removeAppDefQ, qName+"RemAppDef");
				remMem = pOpCtx.Data.Get<Member>(removeMemQ, qName+"RemMem");
			}

			vResult = new {
				Member = new {
					VertexId = mem.VertexId+"",
					Type = mem.MemberType,
					OauthGrantCode = mem.OauthGrantCode,
					OauthGrantExpires = mem.OauthGrantExpires,
					OauthGrantRedirectUri = mem.OauthGrantRedirectUri,
					OauthScopeAllow = mem.OauthScopeAllow
				},
				User = new {
					VertexId = user.VertexId+"",
					Name = user.Name
				},
				App = new {
					VertexId = app.VertexId+"",
					Name = app.Name
				},
				UserEdges = userEdge.ToMap(),
				AppEdges = appEdge.ToMap(),
				RemUserDef = (remUserDef == null ? null : new {
					Id = remUserDef.Id
				}),
				RemAppDef = (remAppDef == null ? null : new {
					Id = remAppDef.Id
				}),
				RemMem = (remMem == null ? null : new {
					Id = remMem.VertexId+""
				}),
				Delete = delete
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		public object GetResult() {
			return vResult;
		}

	}

}