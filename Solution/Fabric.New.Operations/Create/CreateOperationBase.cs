using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using ServiceStack.Text;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public abstract class CreateOperationBase<TDom, TApi, TCre> : ICreateOperation<TDom, TApi>
						where TDom : Vertex, new() where TApi : FabVertex where TCre : CreateFabVertex {

		protected IOperationContext OpCtx { get; private set; }
		protected TDom NewDom { get; private set; }
		protected TApi NewApi { get; private set; }
		protected TCre NewCre { get; private set; }
		protected IWeaverVarAlias<TDom> NewDomAlias { get; private set; }
		protected Func<TDom, TApi> DomToApi { get; private set; }

		protected string CmdAddVertex { get; private set; }
		protected IList<string> CmdVerifyVertex { get; private set; }
		protected IList<string> CmdAddEdge { get; private set; }
		protected IList<string> CmdAll { get; private set; }
		protected string LatestConditionCmdId { get; private set; }
		protected IDataAccess DataAcc { get; private set; }
		protected IDataResult DataRes { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract void Create(IOperationContext pOpCtx, string pJson);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void Init(IOperationContext pOpCtx, string pJson, Func<TCre, TDom> pCreToDom,
																		Func<TDom, TApi> pDomToApi) {
			OpCtx = pOpCtx;
			DomToApi = pDomToApi;

			NewCre = JsonSerializer.DeserializeFromString<TCre>(pJson);
			BeforeValidation();
			NewCre.Validate();

			NewDom = pCreToDom(NewCre);
			NewDom.VertexId = OpCtx.GetSharpflakeId<Vertex>();
			NewDom.Timestamp = OpCtx.UtcNow.Ticks;

			CmdVerifyVertex = new List<string>();
			CmdAddEdge = new List<string>();
			CmdAll = new List<string>();

			DataAcc = OpCtx.Data.Build(null, true);
			DataAcc.AddSessionStart();
			SetupLatestCommand();
			AfterSessionStart();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void AddVertex() {
			IWeaverVarAlias<TDom> alias;
			IWeaverQuery q = Weave.Inst.Graph.AddVertex(NewDom);
			q = WeaverQuery.StoreResultAsVar("a", q, out alias);
			NewDomAlias = alias;
			DataAcc.AddQuery(q, true);
			CmdAddVertex = SetupLatestCommand();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void Finish() {
			BeforeSessionCommit();
			DataAcc.AddSessionCommit();
			SetupLatestCommand();

			LatestConditionCmdId = null; //ensure session closes
			DataAcc.AddSessionClose();
			SetupLatestCommand();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TDom Execute() {
			DataRes = DataAcc.Execute(GetType().Name);
			AfterExecute();
			int addVertId = DataRes.GetCommandIndexByCmdId(CmdAddVertex);

			NewDom = DataRes.ToElementAt<TDom>(addVertId, 0);
			NewApi = (DomToApi == null ? null : DomToApi(NewDom));
			return NewDom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TApi GetResult() {
			if ( DomToApi == null ) {
				throw new NotSupportedException("Internal: no DomainToApi conversion for "+
					typeof(TDom).Name+".");
			}

			return NewApi;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(
													IWeaverVarAlias<TFrom> pFromVar, long pToVertexId)
													where TFrom : IVertex, new()
													where TTo : Vertex, new()
													where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			IWeaverVarAlias<TTo> toVar = VerifyVertex<TTo>(pToVertexId);
			AddEdge(pFromVar, new TEdge(), toVar);
			return toVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(
													IWeaverVarAlias<TFrom> pFromVar, long? pToVertexId)
													where TFrom : IVertex, new()
													where TTo : Vertex, new()
													where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			if ( pToVertexId == null ) {
				return null;
			}

			return AddEdge<TFrom, TEdge, TTo>(pFromVar, (long)pToVertexId);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddReverseEdge<TFrom, TEdge, TTo>(
							IWeaverVarAlias<TFrom> pFromVar, TEdge pEdge, IWeaverVarAlias<TTo> pToVar)
															where TFrom : IVertex, new()
															where TTo : IVertex, new()
															where TEdge : IWeaverEdge<TFrom, TTo> {
			if ( pFromVar != null ) {
				AddEdge(pFromVar, pEdge, pToVar);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void BeforeValidation() {
			CreateFabArtifact art = (NewCre as CreateFabArtifact);
			CreateFabFactor fac = (NewCre as CreateFabFactor);

			if ( art != null ) {
				art.CreatedByMemberId = (OpCtx.Auth.ActiveMemberId ?? 0);
			}

			if ( fac != null ) {
				fac.CreatedByMemberId = (OpCtx.Auth.ActiveMemberId ?? 0);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AfterSessionStart() {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void BeforeSessionCommit() {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AfterExecute() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private IWeaverVarAlias<T> VerifyVertex<T>(long pVertexId) where T : Vertex, new() {
			IWeaverVarAlias<T> alias;
			string varName = "v"+CmdVerifyVertex.Count;
			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex<T>(x => x.VertexId, pVertexId).ToQuery();
			q = WeaverQuery.StoreResultAsVar(varName, q, out alias);

			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand(
				"("+varName+"?{"+varName+"="+varName+".next();1;}:0);");
			CmdVerifyVertex.Add(SetupLatestCommand(false, true));
			return alias;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddEdge<TEdge>(IWeaverVarAlias pFromVar, TEdge pEdge, IWeaverVarAlias pToVar)
																	where TEdge : IWeaverEdge {

			IWeaverQuery q = Weave.Inst.Graph.AddEdge(pFromVar, pEdge, pToVar);
			DataAcc.AddQuery(q, true);
			CmdAddEdge.Add(SetupLatestCommand(true));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected string SetupLatestCommand(bool pOmitResults=false, bool pNewCondition=false) {
			if ( CmdAll.Count > 0 && LatestConditionCmdId != null ) {
				DataAcc.AddConditionsToLatestCommand(LatestConditionCmdId);
			}

			if ( pOmitResults ) {
				DataAcc.OmitResultsOfLatestCommand();
			}

			string cmdId = DataAcc.GetLatestCommandId();

			if ( pNewCondition ) {
				LatestConditionCmdId = cmdId;
			}

			CmdAll.Add(cmdId);
			return cmdId;
		}

	}

}