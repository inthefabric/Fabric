using System.Configuration;
using Fabric.New.Api;
using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Test.Integration.Shared;
using NUnit.Framework;
using Nancy.Testing;
using ServiceStack.Text;

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BrowserResponse Get(string pUri) {
			return vBrowser.Get(pUri);
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
		protected T AssertResult<T>(BrowserResponse pResp) where T : FabObject {
			AssertBody(pResp);

			Log.Debug("Response:\n"+
				" - Status: "+pResp.StatusCode+" ("+(int)pResp.StatusCode+")\n"+
				" - Body: "+pResp.Body.AsString()
			);

			T obj = JsonSerializer.DeserializeFromString<T>(pResp.Body.AsString());
			Assert.NotNull(obj, "The "+typeof(T).Name+" object should be filled.");
			return obj;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected FabResponse<T> AssertFabResponse<T>(BrowserResponse pResp) where T : FabObject {
			AssertBody(pResp);

			Log.Debug("Response:\n"+
				" - Status: "+pResp.StatusCode+" ("+(int)pResp.StatusCode+")\n"+
				" - Body: "+pResp.Body.AsString()
			);

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
			Assert.AreEqual(1, fr.Data.Count, "Incorrect  FabResponse.Data length.");
			Assert.NotNull(fr.Data[0], "FabResponse.Data[0] should be filled.");
			
			return fr.Data[0];
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertBody(BrowserResponse pResp) {
			Assert.NotNull(pResp, "Response should not be null.");
			Assert.NotNull(pResp.Body, "Response.Body should not be null.");
		}
		
	}

}