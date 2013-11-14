﻿using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravStepsCustom { //TODO: TravStepsCustom functions

		public static readonly IList<ITravStep> FuncList = new List<ITravStep> {
			new TravStepTake<FabElement, FabElement>("Take", false),
			new TravStepActiveMember(),
			new TravStepAs(),
			new TravStepBack(),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorYear<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorMonth<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorDay<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorHour<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorMinute<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasFactorEventorSecond<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasVertexTimestamp<TFrom, TType>(string pName, string pPropDb) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasAppDefinesMemberTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasArtifactUsedAsPrimaryByFactorTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasArtifactUsedAsRelatedByFactorTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasMemberCreatesArtifactTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasMemberCreatesFactorTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static ITravStep HasUserDefinesMemberTimestamp<TFrom, TType>(
																		string pName, string pPropDb) {
			return null;
		}

	}

}