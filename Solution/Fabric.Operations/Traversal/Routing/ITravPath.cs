﻿using System;
using System.Collections.Generic;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravPath {

		long? MemberId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IList<ITravPathItem> GetFirstSteps(int pCount);

		/*--------------------------------------------------------------------------------------------*/
		ITravPathItem GetNextStep();

		/*--------------------------------------------------------------------------------------------*/
		IList<ITravPathItem> GetSteps(int pCount);
		
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