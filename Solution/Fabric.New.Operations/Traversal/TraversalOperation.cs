﻿using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Util;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TraversalOperation : ITraversalOperation {

		private static readonly Logger Log = Logger.Build<TraversalOperation>();

		private IOperationContext vOpCtx;
		private ITravPath vPath;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			vOpCtx = pOpCtx;
			vPath = new TravPath(pPath, vOpCtx.MemberId);

			ITravPathItem tps = vPath.GetNextStep();

			while ( tps != null ) {
				IList<TravRule> rules = TraversalUtil.GetTravRules(vPath.GetCurrentType());
				TravRule rule = null;

				foreach ( TravRule r in rules ) {
					if ( r.Step.AcceptsPath(vPath) ) {
						rule = r;
						break;
					}
				}

				if ( rule == null ) {
					throw tps.NewStepFault(FabFault.Code.InvalidStep,
						"Step '"+tps.Command+"' is not valid.");
				}

				rule.Step.ConsumePath(vPath, rule.ToType);
				tps = vPath.GetNextStep();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabObject> GetResult() {
			Type t = vPath.GetCurrentType();

			//TODO: execute the query generated by traversal path
			IWeaverQuery q = vPath.BuildQuery();
			Log.Debug("QUERY: "+q.Script);

			foreach ( KeyValuePair<string, IWeaverQueryVal> pair in q.Params ) {
				Log.Debug(" * "+pair.Key+": "+pair.Value.Original);
			}

			var list = new List<FabObject>();
			list.Add((FabObject)Activator.CreateInstance(t, false));
			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabTravStep> GetResultSteps() {
			return TraversalUtil.GetFabTravSteps(vPath.GetCurrentType());
		}

	}

}