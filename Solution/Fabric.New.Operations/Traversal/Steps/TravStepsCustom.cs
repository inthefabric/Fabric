using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Names;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravStepsCustom { //TODO: TravStepsCustom functions

		public static readonly IList<ITravStep> EntryList = new List<ITravStep> {
			new TravStepEntry<FabTravAppRoot, string, FabApp>(
				"Name", DbName.Vert.App.NameKey, true, true),
			new TravStepEntry<FabTravUserRoot, string, FabUser>(
				"Name", DbName.Vert.User.NameKey, true, true),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorYear<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorMonth<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorDay<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorHour<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorMinute<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorSecond<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasVertexTimestamp<TFrom, TType>(string pProp, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasAppDefinesMemberTimestamp<TFrom, TType>(
																		string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasArtifactUsedAsPrimaryByFactorTimestamp<TFrom, TType>(
																		string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasArtifactUsedAsRelatedByFactorTimestamp<TFrom, TType>(
																		string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasMemberCreatesArtifactTimestamp<TFrom, TType>(
																		string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasMemberCreatesFactorTimestamp<TFrom, TType>(
																		string pProp, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasUserDefinesMemberTimestamp<TFrom, TType>(
																		string pProp, string pPropDb) {
			return null;
		}

	}

}