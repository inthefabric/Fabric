﻿using System;
using System.Linq.Expressions;
using Fabric.Domain;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public partial class CreateOperationTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void AddVertex<T>(ICreateOperationBuilder pCreCtx, T pVertex,
												out IWeaverVarAlias<T> pAlias) where T : Vertex, new() {
			IWeaverQuery q = Weave.Inst.Graph.AddVertex(pVertex);
			q = WeaverQuery.StoreResultAsVar(pCreCtx.GetNextAliasName(), q, out pAlias);
			pCreCtx.AddQuery(q, true);
			pCreCtx.SetupLatestCommand();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(ICreateOperationBuilder pCreCtx, 
													IWeaverVarAlias<TFrom> pFromVar, long pToVertexId)
													where TFrom : IVertex, new()
													where TTo : Vertex, new()
													where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			IWeaverVarAlias<TTo> toVar = VerifyVertex<TTo>(pCreCtx, pToVertexId);
			AddEdge(pCreCtx, pFromVar, new TEdge(), toVar);
			return toVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverVarAlias<TTo> AddEdge<TFrom, TEdge, TTo>(ICreateOperationBuilder pCreCtx, 
													IWeaverVarAlias<TFrom> pFromVar, long? pToVertexId)
													where TFrom : IVertex, new()
													where TTo : Vertex, new()
													where TEdge : IWeaverEdge<TFrom, TTo>, new() {
			if ( pToVertexId == null ) {
				return null;
			}

			return AddEdge<TFrom, TEdge, TTo>(pCreCtx, pFromVar, (long)pToVertexId);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddReverseEdge<TFrom, TEdge, TTo>(ICreateOperationBuilder pCreCtx, 
							IWeaverVarAlias<TFrom> pFromVar, TEdge pEdge, IWeaverVarAlias<TTo> pToVar)
															where TFrom : IVertex, new()
															where TTo : IVertex, new()
															where TEdge : IWeaverEdge<TFrom, TTo> {
			if ( pFromVar != null ) {
				AddEdge(pCreCtx, pFromVar, pEdge, pToVar);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FindDuplicate<T>(ICreateOperationBuilder pCreCtx,
								Expression<Func<T, object>> pProp, string pValue, string pErrPropName)
								where T : IVertex, new() {
			IWeaverVarAlias alias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pProp, pValue)
				.ToQueryAsVar(pCreCtx.GetNextAliasName(), out alias);

			pCreCtx.AddQuery(q, true, alias.Name+"?0:1;");
			string cmdId = pCreCtx.SetupLatestCommand(false, true);

			pCreCtx.AddCheck(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 1 ) {
					throw new FabDuplicateFault(typeof(T), pErrPropName, pValue);
				}
			}));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IWeaverVarAlias<T> VerifyVertex<T>(ICreateOperationBuilder pCreCtx, 
															long pVertexId) where T : Vertex, new() {
			IWeaverVarAlias<T> alias;
			string var = pCreCtx.GetNextAliasName();

			IWeaverQuery q = Weave.Inst.Graph.V
				.ExactIndex<T>(x => x.VertexId, pVertexId)
				.ToQueryAsVar(var, out alias);

			pCreCtx.AddQuery(q, true, "if("+var+"){"+var+"="+var+".next();1;}else{0;}");
			string cmdId = pCreCtx.SetupLatestCommand(false, true);

			pCreCtx.AddCheck(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 1 ) {
					throw new FabNotFoundFault(typeof(T), "Id="+pVertexId+" // "+i+" / "+cmdId);
				}
			}));

			return alias;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AddEdge<TEdge>(ICreateOperationBuilder pCreCtx, IWeaverVarAlias pFromVar, 
										TEdge pEdge, IWeaverVarAlias pToVar) where TEdge : IWeaverEdge {

			IWeaverQuery q = Weave.Inst.Graph.AddEdge(pFromVar, pEdge, pToVar);
			pCreCtx.AddQuery(q, true);
			pCreCtx.SetupLatestCommand(true);
		}

	}

}