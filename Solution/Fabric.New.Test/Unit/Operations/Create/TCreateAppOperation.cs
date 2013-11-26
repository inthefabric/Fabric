using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Moq;
using NUnit.Framework;
using ServiceStack.Text;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateAppOperation {

		private static readonly Logger Log = Logger.Build<TCreateAppOperation>();

		private const string MemberForOauthToken =
			"g.V('"+DbName.Vert.OauthAccess.Token+"',_P)"+
				".has('"+DbName.Vert.OauthAccess.Expires+"',Tokens.T.gt,_P)"+
			".outE('oaam').inV;";

		private long vMemId;
		private Mock<IOperationContext> vMockCtx;
		private CreateFabApp vCreateApp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMemId = 123456;

			var mockOpAcc = new Mock<IOperationAccess>();
			mockOpAcc.SetupGet(x => x.ActiveMemberId).Returns(vMemId);

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.Setup(x => x.Access).Returns(mockOpAcc.Object);
			vMockCtx.Setup(x => x.GetVertexById<Member>(vMemId)).Returns(new Member());

			vCreateApp = new CreateFabApp();
			vCreateApp.Name = "MyApp";
			vCreateApp.Secret = "abcdefghijklmnopQRSTUVWXYZ012345";
			vCreateApp.OauthDomains = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string ToJson() {
			return vCreateApp.ToJson();
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Create() {
			var c = new CreateAppOperation();
			c.Create(vMockCtx.Object, ToJson());
		}

	}

}