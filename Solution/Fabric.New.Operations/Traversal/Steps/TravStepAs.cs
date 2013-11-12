using System.Text.RegularExpressions;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepAs : TravStep<FabElement, FabElement> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepAs() : base("As") {
			Params.Add(GetParam());
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathItem item = ConsumeFirstPathItem(pPath);
			string alias = item.ParamAt<string>(0);
			ITravStepParam p = Params[0];

			ValidateAlias(item, p, alias);

			if ( pPath.HasAlias(alias) ) {
				throw item.NewStepFault(FabFault.Code.IncorrectParamValue, 
					p.Name+" '"+alias+"' is already in use.", 0);
			}

			pPath.AddAlias(alias);
			pPath.AddScript(".as("+pPath.AddParam(alias)+")");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static ITravStepParam GetParam() {
			var p = new TravStepParam(0, "Alias", typeof(string));
			p.LenMax = 8;
			p.ValidRegex = "^[a-zA-Z]+[a-zA-Z0-9]*$";
			return p;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal static void ValidateAlias(ITravPathItem pItem, ITravStepParam pParam, string pAlias) {
			if ( pAlias.Length == 0 || pAlias.Length > pParam.LenMax ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					pParam.Name+" cannot exceed "+pParam.LenMax+" characters.", 0);
			}

			if ( !Regex.IsMatch(pAlias, pParam.ValidRegex) ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					"Invalid "+pParam.Name+" format.", 0);
			}
		}

	}

}