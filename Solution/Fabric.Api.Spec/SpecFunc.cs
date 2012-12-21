using System;
using System.Collections.Generic;
using System.Reflection;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Infrastructure.Domain;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public class SpecFunc {

		public string Name { get; set; }
		public string Description { get; set; }
		public Type ReturnType { get; set; }
		public List<SpecFuncParam> ParameterList { get; set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecFunc(Type pFuncType) {
			var fa = (FuncAttribute)pFuncType.GetCustomAttributes(typeof(FuncAttribute), false)[0];

			Name = fa.Name;
			ReturnType = fa.ReturnType;
			string resxKey = (fa.ResxKey ?? Name);
			Description = SpecDoc.GetFuncText(resxKey);
			ParameterList = new List<SpecFuncParam>();

			PropertyInfo[] props = pFuncType.GetProperties();

			foreach ( PropertyInfo pi in props ) {
				object[] fpaList = pi.GetCustomAttributes(typeof(FuncParamAttribute), true);
				if ( fpaList.Length == 0 ) { continue; }
				FuncParamAttribute fpa = (FuncParamAttribute)fpaList[0];
				
				var p = new SpecFuncParam();
				p.Name = pi.Name;
				p.Description = SpecDoc.GetFuncParamText((fpa.FuncResxKey ?? resxKey)+"_"+p.Name);
				p.Index = fpa.ParamIndex;
				p.Type = SchemaHelperProp.GetTypeName(pi.PropertyType);
				p.Min = fpa.Min;
				p.Max = fpa.Max;
				p.IsRequired = fpa.IsRequired;
				p.DisplayName = fpa.DisplayName;
				p.UsesQueryString = fpa.UsesQueryString;
				ParameterList.Add(p);
			}

			ParameterList.Sort((a, b) => (a.Index > b.Index ? 1 : (a.Index == b.Index ? 0 : -1)));
		}

	}

}