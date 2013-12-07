using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravStepsCustom {

		public static readonly IList<ITravStep> FuncList = new List<ITravStep> {
			new TravStepTake<FabElement, FabElement>("Take", false),
			new TravStepActive(),
			new TravStepAs(),
			new TravStepBack(),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorYear<TFrom, TType, TTo>(string pCmd, string pPropDb) {
			return new TravStepWhereEventorDateTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorMonth<TFrom, TType, TTo>(string pCmd, string pPropDb){
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorDay<TFrom, TType, TTo>(string pCmd, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorHour<TFrom, TType, TTo>(string pCmd, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorMinute<TFrom, TType, TTo>(string pCmd,string pPropDb){
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorSecond<TFrom, TType, TTo>(string pCmd,string pPropDb){
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep VertexWhereTimestamp<TFrom, TType, TTo>(string pCmd, string pPropDb)
														where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep VertexEntryWhereTimestamp<TFrom, TType, TTo>(string pCmd, 
								string pPropDb) where TFrom : FabTravTypedRoot where TTo : FabVertex {
			var ew = new TravStepEntryWhere<TFrom, TType, TTo>(pCmd, pPropDb);
			ew.UpdateValue = (val => (TType)(object)FabMetaTime.GetTicks((long)(object)val));
			return ew;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep AppDefinesMemberWhereTimestamp<TFrom, TType, TTo>(
						string pCmd, string pPropDb) where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep ArtifactUsedAsPrimaryByFactorWhereTimestamp<TFrom, TType, TTo>(
						string pCmd, string pPropDb) where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep ArtifactUsedAsRelatedByFactorWhereTimestamp<TFrom, TType, TTo>(
						string pCmd, string pPropDb) where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep MemberCreatesArtifactWhereTimestamp<TFrom, TType, TTo>(
						string pCmd, string pPropDb) where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep MemberCreatesFactorWhereTimestamp<TFrom, TType, TTo>(
						string pCmd, string pPropDb) where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep UserDefinesMemberWhereTimestamp<TFrom, TType, TTo>(
						string pCmd, string pPropDb) where TFrom : FabObject where TTo : FabElement {
			return WhereTimestamp<TFrom, TType, TTo>(pCmd, pPropDb);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static ITravStep WhereTimestamp<TFrom, TType, TTo>(string pCmd, string pPropDb)
														where TFrom : FabObject where TTo : FabElement {
			var w = new TravStepWhere<TFrom, TType, TTo>(pCmd, pPropDb);
			w.UpdateValue = (val => (TType)(object)FabMetaTime.GetTicks((long)(object)val));
			return w;
		}

	}

}