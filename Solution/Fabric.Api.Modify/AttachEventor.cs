using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModEventorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachEventor : AttachFactorElement {

		public const string EveTypeParam = "EventorTypeId";
		public const string YearParam = "Year";
		public const string MonthParam = "Month";
		public const string DayParam = "Day";
		public const string HourParam = "Hour";
		public const string MinuteParam = "Minute";
		public const string SecondParam = "Second";

		[ServiceOpParam(ServiceOpParamType.Form, EveTypeParam, 1, typeof(Factor))]
		private readonly byte vEveTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, YearParam, 2, typeof(Factor))]
		private readonly long vYear;

		[ServiceOpParam(ServiceOpParamType.Form, MonthParam, 3, typeof(Factor))]
		private readonly byte? vMonth;

		[ServiceOpParam(ServiceOpParamType.Form, DayParam, 4, typeof(Factor))]
		private readonly byte? vDay;

		[ServiceOpParam(ServiceOpParamType.Form, HourParam, 5, typeof(Factor))]
		private readonly byte? vHour;

		[ServiceOpParam(ServiceOpParamType.Form, MinuteParam, 6, typeof(Factor))]
		private readonly byte? vMinute;

		[ServiceOpParam(ServiceOpParamType.Form, SecondParam, 7, typeof(Factor))]
		private readonly byte? vSecond;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachEventor(IModifyTasks pTasks, long pFactorId, byte pEveTypeId, long pYear,
												byte? pMonth, byte? pDay, byte? pHour, byte? pMinute,
												byte? pSecond) : base(pTasks, pFactorId) {
			vEveTypeId = pEveTypeId;
			vYear = pYear;
			vMonth = pMonth;
			vDay = pDay;
			vHour = pHour;
			vMinute = pMinute;
			vSecond = pSecond;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorEventor_TypeId(vEveTypeId, EveTypeParam);

			if ( vYear == 0 ) {
				throw new FabArgumentValueFault(YearParam, 0);
			}

			ValidateRange(YearParam, vYear, -100000000000, 100000000000); // +/- 100 billion
			ValidateRange(MonthParam, vMonth, 1, 12);
			ValidateRange(DayParam, vDay, 1, 31);
			ValidateRange(HourParam, vHour, 0, 23);
			ValidateRange(MinuteParam, vMinute, 0, 59);
			ValidateRange(SecondParam, vSecond, 0, 59);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateRange(string pName, long? pValue, long pMin, long pMax) {
			if ( pValue == null ) {
				return;
			}

			DomainValidator.LongBetween(pName, (long)pValue, pMin, pMax);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Dictionary<string, long> GetRequiredArtifactIds() { return null; }

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor) {
			Tasks.UpdateFactorEventor(ApiCtx, pFactor, vEveTypeId,
				vYear, vMonth, vDay, vHour, vMinute, vSecond);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetElementName() {
			return "Eventor";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return (pFactor.Eventor_TypeId != null);
		}

	}

}