﻿using System;
using System.Collections.Generic;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Moq;
using NUnit.Framework;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using RexConnectClient.Core.Transfer;
using Weaver.Core.Query;

namespace Fabric.New.Test.Shared {

	/*================================================================================================*/
	public class MockDataAccess : Mock<IDataAccess> {

		private static readonly Logger Log = Logger.Build<MockDataAccess>();

		protected IList<MockDataAccessCmd> CmdList;
		public int ExecuteCount;
		public MockDataResult MockResult;

		private Action<IDataAccess, RexConnDataAccess> vPreEx;
		private Action<IDataAccess, IResponseResult> vPostEx;
		private Action<IDataAccess, Exception> vPostExErr;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private MockDataAccess() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SetupAddQuery() {
			CmdList = new List<MockDataAccessCmd>();

			Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<bool>()))
				.Callback((string s, bool c) => OnAddQuery(s, c))
				.Returns(Object);

			/*Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
				.Callback((string s, IDictionary<string, string> p) => OnAddQuery(s,p))
				.Returns(Object);*/

			Setup(x => x.AddQuery(It.IsAny<string>(), 
					It.IsAny<IDictionary<string, IWeaverQueryVal>>(), It.IsAny<bool>()))
				.Callback((string s, IDictionary<string, IWeaverQueryVal> p, bool c) => 
					OnAddQuery(s, p, c))
				.Returns(Object);

			Setup(x => x.AddQuery(It.IsAny<IWeaverScript>(), It.IsAny<bool>()))
				.Callback((IWeaverScript s, bool c) => OnAddQuery(s, c))
				.Returns(Object);

			Setup(x => x.AddQueries(It.IsAny<IEnumerable<IWeaverScript>>(), It.IsAny<bool>()))
				.Callback((IEnumerable<IWeaverScript> s, bool c) => OnAddQueries(s, c))
				.Returns(Object);

			
			Setup(x => x.SetExecuteHooks(
					It.IsAny<Action<IDataAccess, RexConnDataAccess>>(),
					It.IsAny<Action<IDataAccess, IResponseResult>>(),
					It.IsAny<Action<IDataAccess, Exception>>()
				))
				.Callback((
						Action<IDataAccess, RexConnDataAccess> preEx,
						Action<IDataAccess, IResponseResult> postEx,
						Action<IDataAccess, Exception> postExErr
					) => {
					vPreEx = preEx;
					vPostEx = postEx;
					vPostExErr = postExErr;
				});
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SetupExecute(Action<MockDataAccess> pExecuteCallback) {
			ExecuteCount = 0;
			MockResult = new MockDataResult();

			Setup(x => x.Execute(It.IsAny<string>()))
				.Callback((string name) => {
					SetupGet(x => x.ExecuteName).Returns(name);

					if ( vPreEx != null ) {
						vPreEx(Object, null);
					}

					ExecuteCount++;
					pExecuteCallback(this);

					if ( vPostEx != null ) {
						var resp = new Response();
						resp.Timer = 100;

						var mockRespRes = new Mock<IResponseResult>();
						mockRespRes.SetupGet(x => x.Response).Returns(resp);
						mockRespRes.SetupGet(x => x.ResponseJson).Returns("{}");
						vPostEx(Object, mockRespRes.Object);
					}
				})
				.Returns(MockResult.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(string pScript, bool pCache) {
			TestUtil.LogWeaverScript(Log, pScript, "");
			CmdList.Add(new MockDataAccessCmd { Script = pScript, Cache = pCache});
		}

		/*--------------------------------------------------------------------------------------------* /
		private void OnAddQuery(string pScript, IDictionary<string, string> pParams) {
			TestUtil.LogWeaverScript(pScript, JsonSerializer.SerializeToString(pParams));
			CmdList.Add(new MockDataAccessCmd { Script = pScript, StringParams = pParams });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(
							string pScript, IDictionary<string, IWeaverQueryVal> pParams, bool pCache) {
			var mockWs = new Mock<IWeaverScript>();
			mockWs.SetupGet(x => x.Script).Returns(pScript);
			mockWs.SetupGet(x => x.Params).Returns((Dictionary<string, IWeaverQueryVal>)pParams);
			TestUtil.LogWeaverScript(Log, mockWs.Object);

			CmdList.Add(new MockDataAccessCmd { Script = pScript, Params = pParams, Cache = pCache });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(IWeaverScript pWeaverScript, bool pCache) {
			OnAddQuery(pWeaverScript.Script, pWeaverScript.Params, pCache);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQueries(IEnumerable<IWeaverScript> pWeaverScripts, bool pCache) {
			foreach ( IWeaverScript ws in pWeaverScripts ) {
				OnAddQuery(ws, pCache);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MockDataAccessCmd GetCommand(int pIndex) {
			if ( pIndex >= CmdList.Count ) {
				throw new Exception("Not enough MockDataAccessCmd items.");
			}

			return CmdList[pIndex];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static MockDataAccess Create(Action<MockDataAccess> pExecuteCallback) {
			var mda = new MockDataAccess();
			mda.SetupAddQuery();
			mda.SetupExecute(pExecuteCallback);
			return mda;
		}

	}

}