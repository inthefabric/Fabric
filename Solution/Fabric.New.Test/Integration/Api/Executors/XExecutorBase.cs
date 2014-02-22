using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Fabric.New.Api;
using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Test.Integration.Shared;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using RexConnectClient.Core.Cache;
using ServiceStack.Text;
using Weaver.Core.Query;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public abstract class XExecutorBase : IntegrationTest {

		private static readonly Logger Log = Logger.Build<XExecutorBase>();

		private Browser vBrowser;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			var boot = new ConfigurableBootstrapper(x => x.Module(new ApiModule()));
			vBrowser = new Browser(boot);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ExecuteTestQuery(IWeaverQuery pQuery, string pName) {
			var dataCtx = new DataContext(
				ConfigurationManager.AppSettings["Dev_NodeIp1"],
				int.Parse(ConfigurationManager.AppSettings["Dev_RexConnPort"]),
				new RexConnCacheProvider()
			);

			var acc = new DataAccess();
			acc.Build(dataCtx);
			acc.SetLoggingHook((a, b, c) => Log.Debug(a+" / "+b+" / "+c));
			acc.AddQuery(pQuery);
			acc.Execute("Test-"+pName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BrowserResponse Get(string pUri, IDictionary<string, string> pQuery=null, 
															IDictionary<string, string> pCookies=null) {
			return vBrowser.Get(pUri, x => {
				if ( pQuery == null ) {
					return;
				}

			    foreach ( KeyValuePair<string, string> pair in pQuery ) {
			        x.Query(pair.Key, pair.Value);
			    }

				if ( pCookies != null ) {
					x.Cookie(pCookies);
				}
			});
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected BrowserResponse Post<T>(string pUri, T pForm) where T : FabObject {
			return vBrowser.Post(pUri, x => {
				x.FormValue("Data", pForm.ToJson());
				x.Header("Authorization", "Bearer "+SetupOauth.TokenFabZach);
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void AssertBody(BrowserResponse pResp) {
			Assert.NotNull(pResp, "Response should not be null.");
			Assert.NotNull(pResp.Body, "Response.Body should not be null.");

			string s = "Response:\n"+
				" - Status: "+pResp.StatusCode+" ("+(int)pResp.StatusCode+")\n"+
				" - Body: "+pResp.Body.AsString()+"\n"+
				" - Headers: ";

			foreach ( KeyValuePair<string, string> pair in pResp.Headers ) {
				s += "\n   * "+pair.Key+" = "+pair.Value;
			}

			Log.Debug(s);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T AssertFabObject<T>(BrowserResponse pResp) where T : FabObject {
			AssertBody(pResp);

			T obj = JsonSerializer.DeserializeFromString<T>(pResp.Body.AsString());
			Assert.NotNull(obj, "The "+typeof(T).Name+" object should be filled.");
			return obj;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected FabResponse<T> AssertFabResponse<T>(BrowserResponse pResp) where T : FabObject {
			AssertBody(pResp);

			FabResponse<T> fr =
				JsonSerializer.DeserializeFromString<FabResponse<T>>(pResp.Body.AsString());

			Assert.NotNull(fr, "The FabResponse<"+typeof(T).Name+"> object should be filled.");

			return fr;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T AssertFabResponseData<T>(BrowserResponse pResp) where T : FabObject {
			FabResponse<T> fr = AssertFabResponse<T>(pResp);

			Assert.Null(fr.Error, "FabResponse.Error should be null: "+fr.Error.ToJson());
			Assert.NotNull(fr.Data, "FabResponse.Data should be filled.");
			Assert.AreEqual(1, fr.Data.Count, "Incorrect FabResponse.Data length.");
			Assert.NotNull(fr.Data[0], "FabResponse.Data[0] should be filled.");
			
			return fr.Data[0];
		}

		/*--------------------------------------------------------------------------------------------*/
		protected IDictionary<string, string> AssertRedirect(BrowserResponse pResp, string pUrl) {
			AssertBody(pResp);

			Assert.AreEqual(HttpStatusCode.SeeOther, pResp.StatusCode,"Incorrect StatusCode.");

			string loc;
			pResp.Headers.TryGetValue("Location", out loc);

			Assert.NotNull(loc, "Location should be filled.");

			int qi = loc.IndexOf('?');
			var query = new Dictionary<string, string>();

			if ( qi != -1 ) {
				string queryText = loc.Substring(qi+1);
				loc = loc.Substring(0, qi);

				query = queryText.Split('&').ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1]);
			}

			Assert.AreEqual(pUrl, loc, "Incorrect Location.");
			return query;
		}
		
	}

}