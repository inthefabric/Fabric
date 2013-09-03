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
		public MockDataResult MockResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private MockDataAccess() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SetupAddQuery() {
			CmdList = new List<MockDataAccessCmd>();

			Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<bool>()))
				.Callback((string s) => OnAddQuery(s))
				.Returns(Object);

			/*Setup(x => x.AddQuery(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()))
				.Callback((string s, IDictionary<string, string> p) => OnAddQuery(s,p))
				.Returns(Object);*/

			Setup(x => x.AddQuery(It.IsAny<string>(), 
					It.IsAny<IDictionary<string, IWeaverQueryVal>>(), It.IsAny<bool>()))
				.Callback((string s, IDictionary<string, IWeaverQueryVal> p) => OnAddQuery(s, p))
				.Returns(Object);

			Setup(x => x.AddQuery(It.IsAny<IWeaverScript>(), It.IsAny<bool>()))
				.Callback((IWeaverScript s) => OnAddQuery(s))
				.Returns(Object);

			Setup(x => x.AddQueries(It.IsAny<IEnumerable<IWeaverScript>>(), It.IsAny<bool>()))
				.Callback((IEnumerable<IWeaverScript> s) => OnAddQueries(s))
				.Returns(Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SetupExecute(Action<MockDataAccess> pExecuteCallback) {
			ExecuteCount = 0;
			MockResult = new MockDataResult();

			Setup(x => x.Execute(It.IsAny<string>()))
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