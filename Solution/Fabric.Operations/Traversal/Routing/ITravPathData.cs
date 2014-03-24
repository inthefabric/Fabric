using System;
using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravPathData {

		long? MemberId { get; }

		List<ITravPathItem> Items { get; }
		IDictionary<string, int> Aliases { get; }
		IDictionary<string, int> Backs { get; }
		IList<Type> Types { get; }

		int CurrIndex { get; }
		Type CurrType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void UpdateCurrentType(Type pNewType);

		/*--------------------------------------------------------------------------------------------*/
		void IncrementCurrentIndex(int pCount);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddScript(string pScript);

		/*--------------------------------------------------------------------------------------------*/
		string AddParam(object pObject);

		/*--------------------------------------------------------------------------------------------*/
		IWeaverQuery BuildQuery();

	}

}