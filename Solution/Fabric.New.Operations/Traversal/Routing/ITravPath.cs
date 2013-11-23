﻿using System;
using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravPath {

		long? MemberId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IWeaverQuery BuildQuery();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IList<ITravPathItem> GetFirstSteps(int pCount);

		/*--------------------------------------------------------------------------------------------*/
		ITravPathItem GetNextStep();

		/*--------------------------------------------------------------------------------------------*/
		IList<ITravPathItem> GetSteps(int pCount);
		
		/*--------------------------------------------------------------------------------------------*/
		Type GetCurrentType();

		/*--------------------------------------------------------------------------------------------*/
		bool IsAcceptableType(Type pType, bool pRequiresExact);

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
		bool DoesBackTouchAs(string pAlias);

		/*--------------------------------------------------------------------------------------------*/
		bool AllowBackToAlias(string pAlias, out string pConflictingAlias);
		
	}

}