using System.IO;
using System.Threading.Tasks;
using Fabric.Api.Modify;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Nancy;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XParallel : IntegTestBase {
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewFactors() {
			Parallel.For(0, 10, BuildNewFactor);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void BuildNewFactor(int pIndex) {
			var apiCtx = new TestApiContext();
			apiCtx.SetAppUserId((long)AppGal, (long)UserZach);

			var req = new Request("POST", "", "UTF-8");
			req.Form.Add(CreateFactor.PrimArtParam, SetupArtifacts.ArtifactId.User_Zach);
			req.Form.Add(CreateFactor.EdgeArtParam, SetupArtifacts.ArtifactId.Thi_Art);
			req.Form.Add(CreateFactor.AssertParam, FactorAssertionId.Fact);
			req.Form.Add(CreateFactor.IsDefParam, false);

			var modFactors = new ModifyController(
				req, apiCtx, new OauthTasks(), ModifyController.Route.Factors);
			modFactors.Execute();

			NewVertexCount += 1; //see XCreateFactor
			NewEdgeCount += 3;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string NancyResponseString(Response pResp) {
			var s = new MemoryStream();
			pResp.Contents.Invoke(s);
			s.Position = 0;
			return new StreamReader(s).ReadToEnd();
		}

	}

}