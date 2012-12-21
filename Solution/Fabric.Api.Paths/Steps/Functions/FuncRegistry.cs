using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Paths.Steps.Functions.Oauth;

namespace Fabric.Api.Paths.Steps.Functions {
	
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

			Register<FuncBackStep>((p => new FuncBackStep(p)), FuncBackStep.AllowedForStep);
			Register<FuncLimitStep>((p => new FuncLimitStep(p)), FuncLimitStep.AllowedForStep);

			//TEST: Oauth functions added to FuncRegistry
			Register<FuncOauthStep>((p => new FuncOauthStep(p)), FuncOauthStep.AllowedForStep);
			Register<FuncOauthAtStep>((p => new FuncOauthAtStep(p)), FuncOauthAtStep.AllowedForStep);
			Register<FuncOauthAtacStep>(
				(p => new FuncOauthAtacStep(p)), FuncOauthAtacStep.AllowedForStep);
			Register<FuncOauthAtrStep>(
				(p => new FuncOauthAtrStep(p)), FuncOauthAtrStep.AllowedForStep);
			Register<FuncOauthAtccStep>(
				(p => new FuncOauthAtccStep(p)), FuncOauthAtccStep.AllowedForStep);
			Register<FuncOauthAtcdStep>(
				(p => new FuncOauthAtcdStep(p)), FuncOauthAtcdStep.AllowedForStep);
			Register<FuncOauthLoginStep>(
				(p => new FuncOauthLoginStep(p)), FuncOauthLoginStep.AllowedForStep);
			Register<FuncOauthLogoutStep>(
				(p => new FuncOauthLogoutStep(p)), FuncOauthLogoutStep.AllowedForStep);
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
		public static List<string> GetAvailableFuncs(IStep pStep, bool pUri) {
			return GetAvailableFuncs(pStep.DtoType, pUri);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static List<string> GetAvailableFuncs(Type pDtoType, bool pUri) {
			Init();

			if ( !typeof(IFabDto).IsAssignableFrom(pDtoType) ) {
				throw new Exception("DtoType must implement IFabDto.");
			}

			var list = new List<string>();

			foreach ( FuncRegistryItem ri in RegItems ) {
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