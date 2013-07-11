using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public static class FuncRegistry {

		private static List<FuncRegistryItem> RegItems;
		private static Dictionary<string, FuncRegistryItem> RegItemMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void Init() {
			if ( RegItems != null ) { return; }
			RegItems = new List<FuncRegistryItem>();
			RegItemMap = new Dictionary<string, FuncRegistryItem>();

			//Available for FabRoot
			RootTypeFunc.RegisterAllFunctions();
			Register<ActiveAppFunc>(p => new ActiveAppFunc(p), ActiveAppFunc.AllowedForStep);
			Register<ActiveUserFunc>(p => new ActiveUserFunc(p), ActiveUserFunc.AllowedForStep);
			Register<ActiveMemberFunc>(p => new ActiveMemberFunc(p), ActiveMemberFunc.AllowedForStep);

			//Available for RootTypes
			IdIndexFunc.RegisterAllFunctions();
			ExactIndexFunc.RegisterAllFunctions();

			//Available for most DTOs
			Register<AsFunc>(p => new AsFunc(p), AsFunc.AllowedForStep);
			Register<BackFunc>(p => new BackFunc(p), BackFunc.AllowedForStep);
			Register<LimitFunc>(p => new LimitFunc(p), LimitFunc.AllowedForStep);
			Register<WhereIdFunc>(p => new WhereIdFunc(p), WhereIdFunc.AllowedForStep);

			//Available for Artifact
			Register<WhereAppFunc>(p => new WhereAppFunc(p), WhereAppFunc.AllowedForStep);
			Register<WhereClassFunc>(p => new WhereClassFunc(p), WhereClassFunc.AllowedForStep);
			Register<WhereInstanceFunc>(p => new WhereInstanceFunc(p), WhereInstanceFunc.AllowedForStep);
			Register<WhereUrlFunc>(p => new WhereUrlFunc(p), WhereUrlFunc.AllowedForStep);
			Register<WhereUserFunc>(p => new WhereUserFunc(p), WhereUserFunc.AllowedForStep);
		}

		/*--------------------------------------------------------------------------------------------*/
		internal static void Register<T>(Func<IPath, IFunc> pNew,
														Func<Type, bool> pAllow) where T : IFunc {
			Init();

			FuncAttribute fa = (FuncAttribute)typeof(T)
				.GetCustomAttributes(typeof(FuncAttribute), false)[0];
			string command = fa.Name;
			
			var ri = new FuncRegistryItem {
				FuncType = typeof(T),
				IsInternal = fa.IsInternal,
				Uri = "/"+command,
				Command = command.ToLower(),
				New = pNew,
				Allow = pAllow
			};

			RegItems.Add(ri);
			RegItemMap.Add(ri.Command, ri);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static List<string> GetAvailableFuncs(IStep pStep, bool pUri, bool pIncludeInternal) {
			return GetAvailableFuncs(pStep.DtoType, pUri, pIncludeInternal);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static List<string> GetAvailableFuncs(Type pDtoType, bool pUri, bool pIncludeInternal) {
			Init();

			if ( !typeof(IFabObject).IsAssignableFrom(pDtoType) ) {
				throw new Exception("DtoType must implement IFabDto.");
			}

			var list = new List<string>();

			foreach ( FuncRegistryItem ri in RegItems ) {
				if ( ri.IsInternal && !pIncludeInternal ) { continue; }
				if ( !ri.Allow(pDtoType) ) { continue; }
				list.Add(pUri ? ri.Uri : ri.Command);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IFunc GetFuncStep(string pCommand, IPath pPath) {
			if ( !RegItemMap.ContainsKey(pCommand) ) { return null; }
			return RegItemMap[pCommand].New(pPath);
		}

	}

}