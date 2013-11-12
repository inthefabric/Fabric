using System;
using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravPath : ITravPath {

		public Type CurrentType { get; private set; }

		private readonly string vRawText;
		private readonly List<ITravPathStep> vSteps;
		private readonly IWeaverQuery vQuery;
		private string vScript;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravPath(string pRawText) {
			vRawText = pRawText;
			vSteps = new List<ITravPathStep>();
			vQuery = new WeaverQuery();
			vScript = "";

			string p = vRawText.Replace("%20", " ").TrimEnd(new[] { '/' });
			string[] parts = (p.Length > 0 ? p.Split('/') : new string[0]);

			for ( int i = 0 ; i < parts.Length ; i++ ) {
				vSteps.Add(new TravPathStep(i, parts[i]));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverQuery BuildQuery() {
			vQuery.FinalizeQuery(vScript);
			return vQuery;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathStep> GetSteps(int pSteps) {
			return (vSteps.Count < pSteps ? null : vSteps.GetRange(0, pSteps));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool IsAcceptableType(Type pType) {
			//acceptable if the types are the same, or if pType is a subclass of CurrentType
			return (CurrentType == pType || CurrentType.IsAssignableFrom(pType));
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<ITravPathStep> ConsumeSteps(int pSteps, Type pNewType) {
			//set CurrentType if CurrentType is *not* a subclass of pNewType
			if ( !pNewType.IsAssignableFrom(CurrentType) ) {
				CurrentType = pNewType;
			}

			List<ITravPathStep> list = vSteps.GetRange(0, pSteps);
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