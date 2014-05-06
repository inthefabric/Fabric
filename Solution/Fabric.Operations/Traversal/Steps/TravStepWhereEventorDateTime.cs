using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Conversions;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Spec;
using Fabric.Infrastructure.Util;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("WhereEventorDateTime")]
	public class TravStepWhereEventorDateTime : TravStep<FabFactor, FabFactor> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepWhereEventorDateTime() : base("WhereEventorDateTime") {
			var p = new TravStepParam(0, "Operation", typeof(string));
			p.AcceptedStrings = GremlinUtil.GetOperationCodes();
			Params.Add(p);

			p = new TravStepParam(1, CreateFabEventorValidator.YearName, typeof(long));
			p.Min = -100000000000;
			p.Max = 100000000000;
			Params.Add(p);

			p = new TravStepParam(2, CreateFabEventorValidator.MonthName, typeof(byte));
			p.Min = 1;
			p.Max = 12;
			Params.Add(p);

			p = new TravStepParam(3, CreateFabEventorValidator.DayName, typeof(byte));
			p.Min = 1;
			p.Max = 31;
			Params.Add(p);

			p = new TravStepParam(4, CreateFabEventorValidator.HourName, typeof(byte));
			p.Min = 0;
			p.Max = 23;
			Params.Add(p);

			p = new TravStepParam(5, CreateFabEventorValidator.MinuteName, typeof(byte));
			p.Min = 0;
			p.Max = 59;
			Params.Add(p);

			p = new TravStepParam(6, CreateFabEventorValidator.SecondName, typeof(byte));
			p.Min = 0;
			p.Max = 59;
			Params.Add(p);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);
			string op = ParamAt<string>(item, 0);

			var ev = new CreateFabEventor();
			ev.Type = (byte)EventorType.Id.Start; //to make validator happy
			ev.Year = ParamAt<long>(item, 1);
			ev.Month = ParamAt<byte>(item, 2);
			ev.Day = ParamAt<byte>(item, 3);
			ev.Hour = ParamAt<byte>(item, 4);
			ev.Minute = ParamAt<byte>(item, 5);
			ev.Second = ParamAt<byte>(item, 6);

			var validator = new CreateFabEventorValidator(ev);
			validator.Validate();

			long evDateTime = DataUtil.EventorTimesToLong(
				ev.Year, ev.Month, ev.Day, ev.Hour, ev.Minute, ev.Second);

			pPath.AddScript(
				".has("+
					pPath.AddParam(DbName.Vert.Factor.EventorDateTime)+", "+
					GremlinUtil.GetStandardCompareOperation(op)+", "+
					pPath.AddParam(evDateTime)+
				")"
			);
		}

	}

}