using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravStepsCustom { //TODO: TravStepsCustom functions

		public static readonly IList<ITravStep> FuncList = new List<ITravStep> {
			new TravStepTake<FabElement, FabElement>("Take", false),
			new TravStepActive(),
			new TravStepAs(),
			new TravStepBack(),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorYear<TFrom, TType>(string pName, string pPropDb) {
			return new TravStepWhereEventorDateTime();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorMonth<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorDay<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorHour<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorMinute<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep FactorWhereEventorSecond<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep VertexWhereTimestamp<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep AppDefinesMemberWhereTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep ArtifactUsedAsPrimaryByFactorWhereTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep ArtifactUsedAsRelatedByFactorWhereTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep MemberCreatesArtifactWhereTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep MemberCreatesFactorWhereTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep UserDefinesMemberWhereTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

	}

}