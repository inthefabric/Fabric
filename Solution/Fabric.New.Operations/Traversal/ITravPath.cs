﻿using System;
using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITravPath {

		long MemberId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IWeaverQuery BuildQuery();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		ITravPathItem GetNextStep();

		/*--------------------------------------------------------------------------------------------*/
		IList<ITravPathItem> GetSteps(int pCount);
		
		/*--------------------------------------------------------------------------------------------*/
		bool IsAcceptableType(Type pType);

		/*--------------------------------------------------------------------------------------------*/
		IList<ITravPathItem> ConsumeSteps(int pCount, Type pCurrentType);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddScript(string pScript);

		/*--------------------------------------------------------------------------------------------*/
		string AddParam(object pObject);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddAlias(string pAlias);
		
		/*--------------------------------------------------------------------------------------------*/
		void AddBackToAlias(string pAlias);

		/*--------------------------------------------------------------------------------------------*/
		bool HasAlias(string pAlias);

		/*--------------------------------------------------------------------------------------------*/
		bool AllowBackToAlias(string pAlias, out string pConflictingAlias);
		
	}

}