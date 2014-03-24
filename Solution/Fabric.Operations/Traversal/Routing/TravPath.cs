using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Routing {

	/*================================================================================================*/
	public class TravPath : ITravPath {

		private readonly ITravPathData vData;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravPath(ITravPathData pData) {
			vData = pData;
		}

		/*--------------------------------------------------------------------------------------------*/
		public long? MemberId {
			get { return vData.MemberId; }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> GetFirstSteps(int pCount) {
			return vData.Items.GetRange(0, Math.Min(vData.Items.Count, pCount));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public ITravPathItem GetNextStep() {
			return (vData.Items.Count <= vData.CurrIndex ? null : vData.Items[vData.CurrIndex]);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> GetSteps(int pCount) {
			return (vData.Items.Count < vData.CurrIndex+pCount ? 
				null : vData.Items.GetRange(vData.CurrIndex, pCount));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool IsAcceptableType(Type pType, bool pRequiresExact) {
			if ( pRequiresExact ) {
				return (vData.CurrType == pType);
			}

			return TravPathData.IsSameTypeOrSubclass(pType, vData.CurrType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> ConsumeSteps(int pCount, Type pNewType) {
			vData.UpdateCurrentType(pNewType);

			List<ITravPathItem> list = vData.Items.GetRange(vData.CurrIndex, pCount);
			vData.IncrementCurrentIndex(pCount);

			for ( int i = 0 ; i < pCount ; ++i ) {
				vData.Types.Add(vData.CurrType);
			}

			return list;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddScript(string pScript) {
			vData.AddScript(pScript);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string AddParam(object pObject) {
			return vData.AddParam(pObject);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddAlias(string pAlias) {
			vData.Aliases.Add(pAlias, vData.CurrIndex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AddBackToAlias(string pAlias) {
			//Allows multiple Back(X) statements. The value mapped to alias X is updated using the 
			//current index. After this occurs, the "Allow Back" function will use this new value,
			//with a net effect of having a "wider" gap between As(X) and Back(X).

			if ( vData.Backs.ContainsKey(pAlias) ) {
				vData.Backs[pAlias] = vData.CurrIndex;
			}
			else {
				vData.Backs.Add(pAlias, vData.CurrIndex);
			}

			int aliasI = vData.Aliases[pAlias];
			vData.UpdateCurrentType(vData.Types[aliasI]);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool HasAlias(string pAlias) {
			return vData.Aliases.ContainsKey(pAlias);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool DoesBackTouchAs(string pAlias) {
			return (vData.Aliases[pAlias] == vData.CurrIndex-1);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool AllowBackToAlias(string pAlias, out string pConflictingAlias) {
			int targetAliasI = vData.Aliases[pAlias];

			//Do not allow scenarios where the target "As" alias is between a previous "As"/"Back" pair
			//a.b.As(B).c.d.Back(B).c2.d2.As(D).e.f.Back(D) //OKAY
			//a.b.As(B).c.d.As(D).e.f.Back(D).e2.f2.Back(B) //OKAY
			//a.b.As(B).c.d.As(D).e.f.Back(B).c2.d2.Back(D) //BAD

			foreach ( KeyValuePair<string, int> pair in vData.Backs ) {
				int backI = pair.Value;
				int checkAliasI = vData.Aliases[pair.Key];

				if ( checkAliasI < targetAliasI && targetAliasI < backI ) {
					pConflictingAlias = pair.Key;
					return false;
				}
			}

			pConflictingAlias = null;
			return true;
		}

	}

}