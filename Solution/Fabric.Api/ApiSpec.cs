using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Fabric.Api.Interfaces;
using Fabric.Api.Lang;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Menu;
using Fabric.Api.Objects.Meta;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Api {

	/*================================================================================================*/
	public static class ApiSpec {

		private static Logger Log = Logger.Build(typeof(ApiSpec));

		public readonly static FabSpec Spec = BuildSpec();

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabSpec BuildSpec() {
			FabMetaVersion v = BaseModule.Version;

			var s = new FabSpec();
			s.BuildVersion = v.Version;
			s.BuildYear = v.Year;
			s.BuildMonth = v.Month;
			s.BuildDay = v.Day;
			s.Services = BuildServices();
			s.Objects = BuildObjects();
			s.Enums = BuildEnums();

			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecService> BuildServices() {
			IList<ApiEntry> entries = new ApiModule().GetApiEntries();

			IDictionary<string, ApiEntry> entryMap = entries
				.ToDictionary(
					x => x.RequestMethod.ToString().ToLower()+" "+x.Path.ToLower(),
					x => x
			);

			Func<string, ApiEntry> getEntry = (x => entryMap[x.ToLower()]);

			var services = new List<FabSpecService>();
			services.Add(BuildService(ApiMenu.Meta, getEntry));
			services.Add(BuildService(ApiMenu.Mod, getEntry));
			services.Add(BuildService(ApiMenu.Oauth, getEntry));
			services.Add(BuildTraversalService(ApiMenu.Trav, getEntry));
			return services;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecService BuildService(FabService pSvc, Func<string, ApiEntry> pGetEntry) {
			var s = new FabSpecService();
			s.Name = pSvc.Name;
			s.Uri = pSvc.Uri;
			s.Summary = ApiLang.Text<ServiceText>(s.Name+"Summ");
			s.Description = ApiLang.Text<ServiceText>(s.Name+"Desc");
			s.Operations = new List<FabSpecServiceOperation>();

			foreach ( FabServiceOperation svcOp in pSvc.Operations ) {
				if ( svcOp == null ) {
					throw new Exception("Missing ServiceOperation for '"+pSvc.Name+"'.");
				}

				string key = svcOp.Method+" "+s.Uri+svcOp.Uri;
				ApiEntry ae;

				try {
					ae = pGetEntry(key);
				}
				catch ( Exception e ) {
					throw new Exception("No ApiEntry for '"+pSvc.Name+"' with key '"+key+"'.", e);
				}

				FabSpecServiceOperation sso = BuildServiceOp(s.Name, svcOp, ae);
				s.Operations.Add(sso);
			}

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecServiceOperation BuildServiceOp(string pSvcName,
														FabServiceOperation pSvcOp, ApiEntry pEntry) {
			var so = new FabSpecServiceOperation();
			so.Name = pSvcOp.Name;
			so.Uri = pSvcOp.Uri;
			so.Method = pSvcOp.Method;
			so.Return = ApiLang.TypeName(pEntry.ResponseType);
			so.Description = ApiLang.Text<ServiceOpText>(pSvcName+"_"+so.Name+"_"+so.Method);
			so.Auth = (pEntry.MemberAuth ? "Member" : "None");
			so.Parameters = new List<FabSpecServiceParam>();

			for ( int i = 0 ; i < pEntry.Params.Count ; i++ ) {
				ApiEntryParam aep = pEntry.Params[i];

				var sop = new FabSpecServiceParam();
				sop.Index = i;
				sop.Name = aep.Name;
				sop.Type = ApiLang.TypeName(aep.ParamType);
				so.Parameters.Add(sop);

				string langKey = (aep.LangKey ?? pSvcName+"_"+so.Name+"_"+sop.Name);
				sop.Description = ApiLang.Text<ServiceOpParamText>(langKey);
			}

			return so;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecService BuildTraversalService(FabService pSvc, 
																	Func<string, ApiEntry> pGetEntry) {
			IList<ITravRule> rules = TraversalUtil.GetTravRules();
			var map = new Dictionary<SpecStepAttribute, IList<ITravRule>>();

			foreach ( ITravRule rule in rules ) {
				SpecStepAttribute ssa = GetAttribute<SpecStepAttribute>(rule.Step.GetType());

				if ( !map.ContainsKey(ssa) ) {
					map.Add(ssa, new List<ITravRule>());
				}

				map[ssa].Add(rule);
			}

			////

			FabSpecService svc = BuildService(pSvc, pGetEntry);
			svc.Steps = new List<FabSpecServiceStep>();

			foreach ( SpecStepAttribute ssa in map.Keys ) {
				if ( ssa.IsRoot ) {
					continue;
				}

				svc.Steps.Add(BuildTraversalServiceStep(ssa, map[ssa]));
			}

			return svc;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecServiceStep BuildTraversalServiceStep(SpecStepAttribute pStepAttr,
																			IList<ITravRule> pRules) {
			var s = new FabSpecServiceStep();
			s.Name = pStepAttr.Name;
			s.Description = ApiLang.Text<StepText>(s.Name);
			s.Parameters = new List<FabSpecServiceParam>();
			s.Rules = new List<FabSpecServiceStepRule>();

			ITravStep ts0 = pRules[0].Step;

			foreach ( ITravStepParam tsp in ts0.Params ) {
				var p = new FabSpecServiceParam();
				p.Index = tsp.ParamIndex;
				p.Name = tsp.Name;
				p.Description = ApiLang.Text<StepParamText>(s.Name+"_"+p.Name);
				p.Type = ApiLang.TypeName(tsp.DataType);
				p.Min = tsp.Min;
				p.Max = tsp.Max;
				p.LenMax = tsp.LenMax;
				p.ValidRegex = tsp.ValidRegex;
				s.Parameters.Add(p);

				if ( tsp.IsGenericDataType ) {
					p.Type = "T";
				}

				if ( tsp.AcceptedStrings != null ) {
					p.AcceptedStrings = tsp.AcceptedStrings.ToArray();
				}
			}

			foreach ( ITravRule rule in pRules ) {
				ITravStep ts = rule.Step;

				var r = new FabSpecServiceStepRule();
				r.Name = ts.Command;
				r.Uri = "/"+ts.Command;
				r.Entry = ApiLang.TypeName(rule.FromType);
				s.Rules.Add(r);

				if ( rule.ToType != null ) {
					r.Return = ApiLang.TypeName(rule.ToType);
				}

				if ( ts.ToAliasType ) {
					r.ReturnsAliasType = true;
				}

				if ( ts.ParamValueType != null ) {
					r.T = ApiLang.TypeName(ts.ParamValueType);
				}
			}

			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObject> BuildObjects() {
			var objects = new List<FabSpecObject>();
			var types = typeof(FabObject).Assembly.GetTypes().OrderBy(x => x.Name);
			
			FabSpecObject frObj = BuildObject(typeof(FabResponse));
			FabSpecObject frObjT = BuildObject(typeof(FabResponse<FabObject>));
			FabSpecObjectProp frDataProp = frObjT.Properties[0];
			frDataProp.Description = 
				ApiLang.Text<DtoPropText>(frObj.Name.Substring(3)+"_"+frDataProp.Name);
			frObj.Properties.Add(frDataProp);
			objects.Add(frObj);

			foreach ( Type t in types ) {
				if ( !typeof(FabObject).IsAssignableFrom(t) ) {
					continue;
				}

				if ( HasAttribute<SpecInternalAttribute>(t, false) ) {
					continue;
				}

				objects.Add(BuildObject(t));
			}

			return objects;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecObject BuildObject(Type pType) {
			var o = new FabSpecObject();
			o.Name = pType.Name;
			o.Extends = pType.BaseType.Name;

			if ( o.Name.IndexOf("CreateFab") == 0 ) {
				o.Description = ApiLang.Text<DtoText>(o.Name);
			}
			else if ( o.Name.IndexOf("FabSpec") == 0 ) {
				o.Description = null;
			}
			else {
				o.Description = ApiLang.Text<DtoText>(o.Name.Substring(3)); //remove "Fab"
			}

			o.Properties = BuildObjectProps(o.Name, pType, (o.Description == null));
			return o;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObjectProp> BuildObjectProps(
														string pObjName, Type pType, bool pSkipText) {
			var objProps = new List<FabSpecObjectProp>();

			PropertyInfo[] props = pType.GetProperties(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

			foreach ( PropertyInfo pi in props ) {
				if ( HasAttribute<SpecInternalAttribute>(pi) ) {
					continue;
				}

				objProps.Add(BuildObjectProp(pObjName, pi, pSkipText));
			}

			return objProps;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecObjectProp BuildObjectProp(
												string pObjName, PropertyInfo pProp, bool pSkipText) {
			DataMemberAttribute dataMem = GetAttribute<DataMemberAttribute>(pProp);
			
			var p = new FabSpecObjectProp();
			p.Name = (dataMem == null ? pProp.Name : dataMem.Name);
			p.Type = ApiLang.TypeName(pProp.PropertyType);

			if ( !pSkipText ) {
				string key = pObjName.Substring(3)+"_"+pProp.Name;
				
				if ( pObjName.IndexOf("CreateFab") == 0 ) {
					key = pObjName.Replace("CreateFab", "Create")+"_"+pProp.Name;
				}

				p.Description = ApiLang.Text<DtoPropText>(key);
			}

			////

			SpecLenAttribute specLen = GetAttribute<SpecLenAttribute>(pProp);
			SpecRangeAttribute specRange = GetAttribute<SpecRangeAttribute>(pProp);
			SpecRegexAttribute specReg = GetAttribute<SpecRegexAttribute>(pProp);
			SpecUniqueAttribute specUni = GetAttribute<SpecUniqueAttribute>(pProp);
			SpecToLowerCaseAttribute specLow = GetAttribute<SpecToLowerCaseAttribute>(pProp);
			SpecFromEnumAttribute specEnum = GetAttribute<SpecFromEnumAttribute>(pProp);

			if ( HasAttribute<SpecOptionalAttribute>(pProp) ) {
				p.IsOptional = true;
			}

			if ( specLen != null ) {
				p.LenMin = specLen.Min;
				p.LenMax = specLen.Max;
			}

			if ( specRange != null ) {
				p.Min = specRange.Min;
				p.Max = specRange.Max;
			}

			if ( specReg != null ) {
				p.ValidRegex = specReg.Pattern;
			}

			if ( specUni != null ) {
				p.IsUnique = true;
			}

			if ( specLow != null ) {
				p.ToLowerCase = true;
			}

			if ( specEnum != null ) {
				p.Enum = specEnum.Name;
			}

			return p;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecEnum> BuildEnums() {
			var enums = new List<FabSpecEnum>();
			var types = typeof(VertexType).Assembly.GetTypes().OrderBy(x => x.Name);

			foreach ( Type t in types ) {
				if ( typeof(EnumObject).IsAssignableFrom(t) ) {
					enums.Add(BuildEnum(t));
				}
			}

			return enums;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabSpecEnum BuildEnum(Type pType) {
			EnumObject obj = (EnumObject)Activator.CreateInstance(pType);
			IList<EnumItem> items = (obj.ToList() ?? new List<EnumItem>());

			var e = new FabSpecEnum();
			e.Name = pType.Name;
			e.Description = ApiLang.Text<EnumText>(e.Name);
			e.Properties = BuildEnumProps(e.Name, items.FirstOrDefault());

			if ( pType != typeof(EnumObject) ) {
				e.Extends = pType.BaseType.Name;
				e.Items = new List<Dictionary<string, object>>();

				foreach ( EnumItem item in items ) {
					e.Items.Add(BuildEnumItem(item));
				}
			}

			return e;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static List<FabSpecObjectProp> BuildEnumProps(string pEnumName, EnumItem pItem) {
			var enumProps = new List<FabSpecObjectProp>();

			if ( pItem == null ) {
				pItem = new EnumItem();
			}

			PropertyInfo[] props = pItem.GetType().GetProperties(
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

			foreach ( PropertyInfo pi in props ) {
				var p = new FabSpecObjectProp();
				p.Name = pi.Name;
				p.Description = ApiLang.Text<EnumPropText>(pEnumName+"_"+p.Name);
				p.Type = ApiLang.TypeName(pi.PropertyType);
				enumProps.Add(p);
			}

			return enumProps;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Dictionary<string, object> BuildEnumItem(EnumItem pItem) {
			PropertyInfo[] props = pItem.GetType().GetProperties();
			var map = new Dictionary<string, object>();

			foreach ( PropertyInfo pi in props ) {
				object val = pi.GetValue(pItem, null);

				if ( val == null || (val as string) == "" ) {
					continue;
				}

				map.Add(pi.Name, val);
			}

			return map;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool HasAttribute<T>(MemberInfo pType, bool pInherit=true) where T : Attribute {
			return (GetAttribute<T>(pType, pInherit) != null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static T GetAttribute<T>(MemberInfo pType, bool pInherit=true) where T : Attribute {
			object[] atts = pType.GetCustomAttributes(typeof(T), pInherit);
			return (atts.Length == 0 ? default(T) : (T)atts[0]);
		}

	}

}