﻿using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Weaver.Core.Query;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public interface IOperationData {

		int DbQueryExecutionCount { get; }
		int DbQueryMillis { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataAccess Build(string pSessionId=null, bool pSetCmdIds=false, bool pOmitCmdTimers=true);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataResult Execute(IWeaverScript pWeaverScript, string pName);

		/*--------------------------------------------------------------------------------------------*/
		T Get<T>(IWeaverScript pWeaverScript, string pName) where T : class, IElement, new();
		
		/*--------------------------------------------------------------------------------------------*/
		IList<T> GetList<T>(IWeaverScript pWeaverScript, string pName) where T : class, IElement, new();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T GetVertexById<T>(long pVertexId) where T : Vertex, new();

	}

}