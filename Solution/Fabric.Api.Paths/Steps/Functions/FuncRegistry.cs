using System;
using System.Collections.Generic;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	public static class FuncRegistry { //TEST: FuncRegistry

		private static List<FuncRegItem> RegItems;
		private static Dictionary<string, FuncRegItem> RegItemMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void Init() {
			if ( RegItems != null ) { return; }
			RegItems = new List<FuncRegItem>();
			RegItemMap = new Dictionary<string, FuncRegItem>();

			Register<FuncBackStep>("Back", (p => new FuncBackStep(p)), FuncBackStep.AllowedForStep);
			Register<FuncLimitStep>("Limit", (p => new FuncLimitStep(p)), FuncLimitStep.AllowedForStep);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void Register<T>(string pCommand, Func<Path, IFuncStep> pNew,
														Func<IStep, bool> pAllow) where T : IFuncStep {
			Init();
			
			var ri = new FuncRegItem {
				FuncType = typeof(T),
				Uri = "/"+pCommand,
				Command = pCommand.ToLower(),
				New = pNew,
				Allow = pAllow
			};

			RegItems.Add(ri);
			RegItemMap.Add(ri.Command, ri);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static List<string> GetAvailableFuncs(IStep pStep, bool pUri) {
			Init();

			var list = new List<string>();

			foreach ( FuncRegItem ri in RegItems ) {
				if ( !ri.Allow(pStep) ) { continue; }
				list.Add(pUri ? ri.Uri : ri.Command);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IStep GetFuncStep(string pCommand, Path pPath) {
			if ( !RegItemMap.ContainsKey(pCommand) ) { return null; }
			return RegItemMap[pCommand].New(pPath);
		}

	}


	/*================================================================================================*/
	public class FuncRegItem {

		public Type FuncType { get; set; }
		public string Command { get; set; }
		public string Uri { get; set; }
		public Func<Path, IFuncStep> New { get; set; }
		public Func<IStep, bool> Allow { get; set; }

	}

}