using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Moq;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using RexConnectClient.Core.Transfer;
using Weaver.Core.Query;

namespace Fabric.New.Test.Shared {

	/*================================================================================================*/
	public class MockDataAccess : Mock<IDataAccess> {

		public const string SessionStart = "start";
		public const string SessionClose = "close";
		public const string SessionRollback = "rollback";
		public const string SessionCommit = "commit";

		private static readonly Logger Log = Logger.Build<MockDataAccess>();

		protected IList<MockDataAccessCmd> CmdList { get; private set; }
		public int ExecuteCount { get; private set; }
		public MockDataResult MockResult { get; private set; }

		private bool vAddCommandIds;
		private Action<IDataAccess, RexConnDataAccess> vPreEx;
		private Action<IDataAccess, IResponseResult> vPostEx;
		private Action<IDataAccess, Exception> vPostExErr;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private MockDataAccess(bool pAddCommandIds) {
			vAddCommandIds = pAddCommandIds;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SetupAddQuery() {
			CmdList = new List<MockDataAccessCmd>();

			////

			Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<bool>()))
				.Callback((string s, bool c) => OnAddQuery(s, c))
				.Returns(Object);

			Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>(),
					It.IsAny<bool>()))
				.Callback((string s, IDictionary<string, string> p, bool c) => OnAddQuery(s,p,c))
				.Returns(Object);

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

			Setup(x => x.AddQueries(It.IsAny<IWeaverTransaction>(), It.IsAny<bool>()))
				.Callback((IWeaverTransaction tx, bool c) => OnAddQueries(tx, c))
				.Returns(Object);

			////

			Setup(x => x.AddConditionsToLatestCommand(It.IsAny<string>()))
				.Callback((string c) => { CmdList.Last().ConditionCmdId = c; });

			Setup(x => x.AppendScriptToLatestCommand(It.IsAny<string>()))
				.Callback((string s) => { CmdList.Last().Script += s; });

			Setup(x => x.OmitResultsOfLatestCommand())
				.Callback(() => { CmdList.Last().OmitResults = true; });

			////
			
			Setup(x => x.AddSessionStart())
				.Callback(() => OnAddSession(SessionStart))
				.Returns(Object);

			Setup(x => x.AddSessionClose())
				.Callback(() => OnAddSession(SessionClose))
				.Returns(Object);

			Setup(x => x.AddSessionRollback())
				.Callback(() => OnAddSession(SessionRollback))
				.Returns(Object);

			Setup(x => x.AddSessionCommit())
				.Callback(() => OnAddSession(SessionCommit))
				.Returns(Object);

			////
			
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

				    foreach ( MockDataAccessCmd cmd in CmdList ) {
				        Log.Debug(cmd+"");
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
			AddCommand(new MockDataAccessCmd { Script = pScript, Cache = pCache });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(string pScript, IDictionary<string, string> pParams, bool pCache) {
			var par = new Dictionary<string, IWeaverQueryVal>();

			foreach ( KeyValuePair<string, string> p in pParams ) {
				par.Add(p.Key, new WeaverQueryVal(p.Value));
			}

			AddCommand(new MockDataAccessCmd { Script = pScript, Params = par, Cache = pCache });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(
							string pScript, IDictionary<string, IWeaverQueryVal> pParams, bool pCache) {
			/*var mockWs = new Mock<IWeaverScript>();
			mockWs.SetupGet(x => x.Script).Returns(pScript);
			mockWs.SetupGet(x => x.Params).Returns((Dictionary<string, IWeaverQueryVal>)pParams);*/

			AddCommand(new MockDataAccessCmd { Script = pScript, Params = pParams, Cache = pCache });
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

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQueries(IWeaverTransaction pWeaverTx, bool pCache) {
			foreach ( IWeaverQuery q in pWeaverTx.Queries ) {
				OnAddQuery(q, pCache);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddSession(string pSessionAction) {
			AddCommand(new MockDataAccessCmd { SessionAction = pSessionAction });
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MockDataAccessCmd GetCommand(int pIndex) {
			if ( pIndex >= CmdList.Count ) {
				throw new Exception("Not enough "+typeof(MockDataAccessCmd).Name+" items.");
			}

			return CmdList[pIndex];
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void AddCommand(MockDataAccessCmd pCmd) {
			if ( vAddCommandIds ) {
				pCmd.CommandId = CmdList.Count+"";
			}

			CmdList.Add(pCmd);
			Setup(x => x.GetLatestCommandId()).Returns(pCmd.CommandId);
			//Log.Debug(pCmd+"");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static MockDataAccess Create(Action<MockDataAccess> pExecuteCallback,
																			bool pAddCommandIds=false) {
			var mda = new MockDataAccess(pAddCommandIds);
			mda.SetupAddQuery();
			mda.SetupExecute(pExecuteCallback);
			return mda;
		}

	}

}