using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLogout {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Go() {
			//var c = new ApiContext("http://localhost:9001/");
			string token = FabricUtil.Code32;

			var mockCtx = new Mock<IApiContext>();

			FabOauthLogout result = new OauthLogout(token).Go(mockCtx.Object);
			Assert.NotNull(result, "Result should be filled.");
		}

	}

}