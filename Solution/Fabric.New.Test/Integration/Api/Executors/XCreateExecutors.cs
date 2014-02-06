using System;
using System.Configuration;
using Fabric.New.Api;
using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Test.Integration.Shared;
using Nancy.Testing;
using NUnit.Framework;
using RexConnectClient.Core.Cache;
using ServiceStack.Text;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XCreateExecutors : IntegrationTest {

		private static readonly Logger Log = Logger.Build<XCreateExecutors>();

		private string vToken;
		private Browser vBrowser;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			var boot = new ConfigurableBootstrapper(x => x.Module(new ApiModule()));
			vBrowser = new Browser(boot);

			vToken = SetupOauth.TokenFabZach;
			UpdateOauthExpiration();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void UpdateOauthExpiration() {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Token, vToken)
					.SideEffect(
						new WeaverStatementSetProperty<OauthAccess>(x => x.Expires, 
							DateTime.UtcNow.AddMinutes(10).Ticks)
					)
				.ToQuery();

			var dataCtx = new DataContext(
				ConfigurationManager.AppSettings["Dev_NodeIp1"],
				int.Parse(ConfigurationManager.AppSettings["Dev_RexConnPort"]),
				new RexConnCacheProvider()
			);

			var acc = new DataAccess();
			acc.Build(dataCtx);
			acc.SetLoggingHook((a, b ,c) => Log.Debug(a+" / "+b+" / "+c));
			acc.AddQuery(q);
			acc.Execute("Test-UpdateOauthExpiration");
		}

		/*--------------------------------------------------------------------------------------------*/
		private BrowserResponse Request<T>(string pUri, T pObj) where T : CreateFabVertex {
			return vBrowser.Post("mod/"+pUri, x => {
				x.FormValue("Data", pObj.ToJson());
				x.Header("Authorization", "Bearer "+SetupOauth.TokenFabZach);
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabResponse<T> ResponseToFab<T>(BrowserResponse pResp) where T : FabVertex {
			AssertBody(pResp);

			Log.Debug("Response:\n"+
				" - Status: "+pResp.StatusCode+" ("+(int)pResp.StatusCode+")\n"+
				" - Body: "+pResp.Body.AsString()
			);

			FabResponse<T> fab = 
				JsonSerializer.DeserializeFromString<FabResponse<T>>(pResp.Body.AsString());
			
			Assert.NotNull(fab, "The FabResponse<"+typeof(T).Name+"> object should be filled.");
			return fab;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertBody(BrowserResponse pResp) {
			Assert.NotNull(pResp, "Response should not be null.");
			Assert.NotNull(pResp.Body, "Response.Body should not be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private T AssertResult<T>(BrowserResponse pResp) where T : FabVertex {
			FabResponse<T> fr = ResponseToFab<T>(pResp);

			Assert.Null(fr.Error, "FabResponse.Error should be null: "+fr.Error.ToJson());
			Assert.NotNull(fr.Data, "FabResponse.Data should be filled.");
			Assert.AreEqual(1, fr.Data.Count, "Incorrect  FabResponse.Data length.");
			Assert.NotNull(fr.Data[0], "FabResponse.Data[0] should be filled.");

			return fr.Data[0];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Class() {
			var obj = new CreateFabClass();
			obj.Name = "class test";

			BrowserResponse br = Request("classes", obj);
			FabClass result = AssertResult<FabClass>(br);
			Assert.AreEqual(obj.Name, result.Name, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Factor() {
			var obj = new CreateFabFactor();
			obj.UsesPrimaryArtifactId = (long)SetupClassId.Blue;
			obj.UsesRelatedArtifactId = (long)SetupClassId.Beauty;
			obj.AssertionType = (byte)FactorAssertion.Id.Guess;
			obj.Descriptor = new CreateFabDescriptor();
			obj.Descriptor.Type = (byte)DescriptorType.Id.BelongsTo;

			BrowserResponse br = Request("factors", obj);
			FabFactor result = AssertResult<FabFactor>(br);
			Assert.AreEqual(obj.AssertionType, result.AssertionType, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 6;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Instance() {
			var obj = new CreateFabInstance();
			obj.Name = "instance test";

			BrowserResponse br = Request("instances", obj);
			FabInstance result = AssertResult<FabInstance>(br);
			Assert.AreEqual(obj.Name, result.Name, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Member() {
			var obj = new CreateFabMember();
			obj.DefinedByAppId = (long)SetupAppId.Bookmarker;
			obj.DefinedByUserId = (long)SetupUserId.FabData;
			obj.Type = (byte)MemberType.Id.Invite;

			BrowserResponse br = Request("members", obj);
			FabMember result = AssertResult<FabMember>(br);
			Assert.AreEqual(obj.Type, result.Type, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 4;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Url() {
			var obj = new CreateFabUrl();
			obj.Name = "url test";
			obj.FullPath = "http://www.inthefabric.com";

			BrowserResponse br = Request("urls", obj);
			FabUrl result = AssertResult<FabUrl>(br);
			Assert.AreEqual(obj.Name, result.Name, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}
		
	}

}