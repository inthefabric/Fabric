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
			Register<FuncActiveAppStep>(
				(p => new FuncActiveAppStep(p)), FuncActiveAppStep.AllowedForStep);
			Register<FuncActiveUserStep>(
				(p => new FuncActiveUserStep(p)), FuncActiveUserStep.AllowedForStep);
			Register<FuncActiveMemberStep>(
				(p => new FuncActiveMemberStep(p)), FuncActiveMemberStep.AllowedForStep);

			//Available for most DTOs
			Register<FuncAsStep>((p => new FuncAsStep(p)), FuncAsStep.AllowedForStep);
			Register<FuncBackStep>((p => new FuncBackStep(p)), FuncBackStep.AllowedForStep);
			Register<FuncLimitStep>((p => new FuncLimitStep(p)), FuncLimitStep.AllowedForStep);
			Register<FuncWhereIdStep>((p => new FuncWhereIdStep(p)), FuncWhereIdStep.AllowedForStep);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void Register<T>(Func<Path, IFuncStep> pNew,
														Func<Type, bool> pAllow) where T : IFuncStep {
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
		public static IFuncStep GetFuncStep(string pCommand, Path pPath) {
			if ( !RegItemMap.ContainsKey(pCommand) ) { return null; }
			return RegItemMap[pCommand].New(pPath);
		}

	}

}