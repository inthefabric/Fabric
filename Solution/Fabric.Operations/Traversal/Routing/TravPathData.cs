using System;
using System.Collections.Generic;
using Fabric.Api.Objects.Traversal;
using Weaver.Core.Query;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public class TravPathData : ITravPathData {

		public long? MemberId { get; private set; }

		public int CurrIndex { get; private set; }
		public Type CurrType { get; private set; }

		public List<ITravPathItem> Items { get; private set; }
		public IDictionary<string, int> Aliases { get; private set; }
		public IDictionary<string, int> Backs { get; private set; }
		public IList<Type> Types { get; private set; }

		private readonly IWeaverQuery vQuery;
		private string vScript;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravPathData(string pRawText, long? pMemberId=null) {
			MemberId = pMemberId;

			CurrIndex = 0;
			CurrType = typeof(FabTravRoot);

			Items = new List<ITravPathItem>();
			Aliases = new Dictionary<string, int>();
			Backs = new Dictionary<string, int>();
			Types = new List<Type> { CurrType };

			vQuery = new WeaverQuery();
			vScript = "g.V";

			////

			string p = pRawText.Replace("%20", " ").TrimEnd(new[] { '/' });
			string[] parts = (p.Length > 0 ? p.Split('/') : new string[0]);

			for ( int i = 0 ; i < parts.Length ; i++ ) {
				Items.Add(new TravPathItem(i, parts[i]));
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UpdateCurrentType(Type pNewType) {
			if ( !IsSameTypeOrSubclass(pNewType, CurrType) ) {
				CurrType = pNewType;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public void IncrementCurrentIndex(int pCount) {
			CurrIndex += pCount;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddScript(string pScript) {
			vScript += pScript;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string AddParam(object pObject) {
			return vQuery.AddParam(new WeaverQueryVal(pObject));
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery BuildQuery() {
			vQuery.FinalizeQuery(vScript);
			return vQuery;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool IsSameTypeOrSubclass(Type pBaseType, Type pSubType) {
			return (pBaseType == pSubType || pBaseType.IsAssignableFrom(pSubType));
		}

	}

}