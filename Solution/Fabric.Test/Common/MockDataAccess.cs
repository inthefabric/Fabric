using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Data;
using Fabric.Test.Util;
using Moq;
using Weaver.Core.Query;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class MockDataAccess : Mock<IDataAccess> {

		protected IList<MockDataAccessCmd> CmdList;
		public int ExecuteCount;
		public Mock<IDataResult> MockResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetupAddQuery() {
			CmdList = new List<MockDataAccessCmd>();

			Setup(x => x.AddQuery(It.IsAny<string>()))
				.Callback((string s) => OnAddQuery(s))
				.Returns(Object);

			/*Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
				.Callback((string s, IDictionary<string, string> p) => OnAddQuery(s,p))
				.Returns(Object);*/

			Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<IDictionary<string, IWeaverQueryVal>>()))
				.Callback((string s, IDictionary<string, IWeaverQueryVal> p) => OnAddQuery(s, p))
				.Returns(Object);

			Setup(x => x.AddQuery(It.IsAny<IWeaverScript>()))
				.Callback((IWeaverScript s) => OnAddQuery(s))
				.Returns(Object);

			Setup(x => x.AddQueries(It.IsAny<IEnumerable<IWeaverScript>>()))
				.Callback((IEnumerable<IWeaverScript> s) => OnAddQueries(s))
				.Returns(Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetupExecute(Action<MockDataAccess> pExecuteCallback, Mock<IDataResult> pResult) {
			ExecuteCount = 0;
			MockResult = pResult;

			Setup(x => x.Execute())
				.Callback(() => {
					ExecuteCount++;
					pExecuteCallback(this);
				})
				.Returns(MockResult.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(string pScript) {
			TestUtil.LogWeaverScript(pScript, "");
			CmdList.Add(new MockDataAccessCmd { Script = pScript });
		}

		/*--------------------------------------------------------------------------------------------* /
		private void OnAddQuery(string pScript, IDictionary<string, string> pParams) {
			TestUtil.LogWeaverScript(pScript, JsonSerializer.SerializeToString(pParams));
			CmdList.Add(new MockDataAccessCmd { Script = pScript, StringParams = pParams });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams) {
			var mockWs = new Mock<IWeaverScript>();
			mockWs.SetupGet(x => x.Script).Returns(pScript);
			mockWs.SetupGet(x => x.Params).Returns((Dictionary<string, IWeaverQueryVal>)pParams);
			TestUtil.LogWeaverScript(mockWs.Object);

			CmdList.Add(new MockDataAccessCmd { Script = pScript, Params = pParams });
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQuery(IWeaverScript pWeaverScript) {
			OnAddQuery(pWeaverScript.Script, pWeaverScript.Params);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnAddQueries(IEnumerable<IWeaverScript> pWeaverScripts) {
			foreach ( IWeaverScript ws in pWeaverScripts ) {
				OnAddQuery(ws);
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
		
		/*--------------------------------------------------------------------------------------------* /
		public string GetScriptAt(int pIndex) {
			return GetCommand(pIndex).Script;
		}

		/*--------------------------------------------------------------------------------------------* /
		public IDictionary<string, IWeaverQueryVal> GetWeaverParamsAt(int pIndex) {
			return GetCommand(pIndex).Params;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static MockDataAccess Create(Action<MockDataAccess> pExecuteCallback,
																			Mock<IDataResult> pResult) {
			var mda = new MockDataAccess();
			mda.SetupAddQuery();
			mda.SetupExecute(pExecuteCallback, pResult);
			return mda;
		}

	}

}