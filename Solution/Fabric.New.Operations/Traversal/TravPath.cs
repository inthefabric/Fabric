using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects.Traversal;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravPath : ITravPath {

		//private static readonly Logger Log = Logger.Build<TravPath>();

		public long MemberId { get; private set; }

		private readonly string vRawText;
		private readonly List<ITravPathItem> vItems;
		private readonly IWeaverQuery vQuery;
		private readonly IDictionary<string, int> vAliases;
		private readonly IDictionary<string, int> vBacks;
		private readonly IList<Type> vTypes;

		private int vCurrIndex;
		private Type vCurrType;
		private string vScript;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravPath(string pRawText, long pMemberId=-1) {
			vRawText = pRawText;
			MemberId = pMemberId;

			vItems = new List<ITravPathItem>();
			vQuery = new WeaverQuery();
			vAliases = new Dictionary<string, int>();
			vBacks = new Dictionary<string, int>();

			vCurrIndex = 0;
			vCurrType = typeof(FabTravRoot);
			vScript = "g.V";

			vTypes = new List<Type> { vCurrType };

			string p = vRawText.Replace("%20", " ").TrimEnd(new[] { '/' });
			string[] parts = (p.Length > 0 ? p.Split('/') : new string[0]);

			for ( int i = 0 ; i < parts.Length ; i++ ) {
				vItems.Add(new TravPathItem(i, parts[i]));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery BuildQuery() {
			vQuery.FinalizeQuery(vScript);
			return vQuery;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ITravPathItem GetNextStep() {
			return (vItems.Count <= vCurrIndex ? null : vItems[vCurrIndex]);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> GetSteps(int pCount) {
			return (vItems.Count < vCurrIndex+pCount ? null : vItems.GetRange(vCurrIndex, pCount));
		}

		/*--------------------------------------------------------------------------------------------*/
		public Type GetCurrentType() {
			return vCurrType;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool IsAcceptableType(Type pType, bool pRequiresExact) {
			if ( pRequiresExact ) {
				return (vCurrType == pType);
			}

			return IsSameTypeOrSubclass(pType, vCurrType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> ConsumeSteps(int pCount, Type pNewType) {
			UpdateCurrentType(pNewType);

			List<ITravPathItem> list = vItems.GetRange(vCurrIndex, pCount);
			vCurrIndex += pCount;

			for ( int i = 0 ; i < pCount ; ++i ) {
				vTypes.Add(vCurrType);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void UpdateCurrentType(Type pNewType) {
			if ( !IsSameTypeOrSubclass(pNewType, vCurrType) ) {
				vCurrType = pNewType;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool IsSameTypeOrSubclass(Type pBaseType, Type pSubType) {
			return (pBaseType == pSubType || pBaseType.IsAssignableFrom(pSubType));
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddAlias(string pAlias) {
			vAliases.Add(pAlias, vCurrIndex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AddBackToAlias(string pAlias) {
			//TODO: support duplicate Back alias usage
			vBacks.Add(pAlias, vCurrIndex);

			int aliasI = vAliases[pAlias];
			UpdateCurrentType(vTypes[aliasI]);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool HasAlias(string pAlias) {
			return vAliases.ContainsKey(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool AllowBackToAlias(string pAlias, out string pConflictingAlias) {
			int targetAliasI = vAliases[pAlias];

			//Do not allow scenarios where the target "As" alias is between a previous "As"/"Back" pair
			//a.b.As(B).c.d.Back(B).c2.d2.As(D).e.f.Back(D) //OKAY
			//a.b.As(B).c.d.As(D).e.f.Back(D).e2.f2.Back(B) //OKAY
			//a.b.As(B).c.d.As(D).e.f.Back(B).c2.d2.Back(D) //BAD

			foreach ( KeyValuePair<string, int> pair in vBacks ) {
				int backI = pair.Value;
				int checkAliasI = vAliases[pair.Key];

				if ( backI > targetAliasI && checkAliasI < targetAliasI ) {
					pConflictingAlias = pair.Key;
					return false;
				}
			}

			pConflictingAlias = null;
			return true;
		}

	}

}