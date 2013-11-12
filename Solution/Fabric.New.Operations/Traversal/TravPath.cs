using System;
using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravPath : ITravPath {

		public Type CurrentType { get; private set; }
		public long MemberId { get; private set; }

		private readonly string vRawText;
		private readonly List<ITravPathItem> vSteps;
		private readonly IWeaverQuery vQuery;
		private string vScript;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravPath(string pRawText, long pMemberId=-1) {
			MemberId = pMemberId;

			vRawText = pRawText;
			vSteps = new List<ITravPathItem>();
			vQuery = new WeaverQuery();
			vScript = "g.V";

			string p = vRawText.Replace("%20", " ").TrimEnd(new[] { '/' });
			string[] parts = (p.Length > 0 ? p.Split('/') : new string[0]);

			for ( int i = 0 ; i < parts.Length ; i++ ) {
				vSteps.Add(new TravPathItem(i, parts[i]));
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
			return (vSteps.Count < 1 ? null : vSteps[0]);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> GetSteps(int pSteps) {
			return (vSteps.Count < pSteps ? null : vSteps.GetRange(0, pSteps));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool IsAcceptableType(Type pType) {
			//acceptable if the types are the same, or if pType is a subclass of CurrentType
			return (CurrentType == pType || CurrentType.IsAssignableFrom(pType));
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathItem> ConsumeSteps(int pSteps, Type pNewType) {
			//set CurrentType if CurrentType is *not* a subclass of pNewType
			if ( !pNewType.IsAssignableFrom(CurrentType) ) {
				CurrentType = pNewType;
			}

			List<ITravPathItem> list = vSteps.GetRange(0, pSteps);
			vSteps.RemoveRange(0, pSteps);
			return list;
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

	}

}