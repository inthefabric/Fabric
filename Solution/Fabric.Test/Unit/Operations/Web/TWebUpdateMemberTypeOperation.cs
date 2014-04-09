using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Operations;
using Fabric.Operations.Web;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Web {

	/*================================================================================================*/
	[TestFixture]
	public class TWebUpdateMemberTypeOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private Member vMem;
		private MemberType.Id vNewMemTypeId;
		private WebUpdateMemberTypeOperation vOper;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMem = new Member();
			vMem.VertexId = 1234125;

			vNewMemTypeId = MemberType.Id.Owner;

			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vOper = new WebUpdateMemberTypeOperation();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const long userId = 1342653246;
			const long appId = 4634634;

			var mockDataAcc = MockDataAccess.Create(mda => {
				Assert.AreEqual(MockDataAccess.SessionStart, mda.GetCommand(0).SessionAction,
					"Incorrect Command 0 SessionAction.");

				string expectScript = "m=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);";
				var expectParam = new List<object> { vMem.VertexId };
				TestUtil.CheckWeaverScript(mda.GetCommand(1), expectScript, "_P", expectParam);

				expectScript = "m.outE('"+DbName.Edge.MemberDefinedByUserName+"')"+
					".inV.property('"+DbName.Vert.Vertex.VertexId+"');";
				expectParam = new List<object>();
				TestUtil.CheckWeaverScript(mda.GetCommand(2), expectScript, "_P", expectParam);

				expectScript = "m.outE('"+DbName.Edge.MemberDefinedByAppName+"')"+
					".inV.property('"+DbName.Vert.Vertex.VertexId+"');";
				expectParam = new List<object>();
				TestUtil.CheckWeaverScript(mda.GetCommand(3), expectScript, "_P", expectParam);

				Assert.AreEqual(MockDataAccess.SessionClose, mda.GetCommand(4).SessionAction,
					"Incorrect Command 4 SessionAction.");

				Assert.AreEqual("Web-GetMemberDetails",
					mda.Object.ExecuteName, "Incorrect ExecuteName.");
			});

			mockDataAcc.MockResult
				.Setup(x => x.ToLongAt(2, 0))
				.Returns(userId);

			mockDataAcc.MockResult
				.Setup(x => x.ToLongAt(3, 0))
				.Returns(appId);

			vMockData
				.Setup(x => x.Build(null, false, true))
				.Returns(mockDataAcc.Object);

			////

			const string expectUpdateScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{it.setProperty('"+DbName.Vert.Member.MemberType+"',_P);}"+
				".outE('"+DbName.Edge.MemberDefinedByUserName+"').inV"+
				".outE('"+DbName.Edge.UserDefinesMemberName+"')"+
					".has('"+DbName.Edge.UserDefinesMember.AppId+"',Tokens.T.eq,_P)"+
					".sideEffect{it.setProperty('"+DbName.Edge.UserDefinesMember.MemberType+"',_P);}"+
					".inV"+
				".outE('"+DbName.Edge.MemberDefinedByAppName+"').inV"+
				".outE('"+DbName.Edge.AppDefinesMemberName+"')"+
					".has('"+DbName.Edge.AppDefinesMember.UserId+"',Tokens.T.eq,_P)"+
					".sideEffect{it.setProperty('"+DbName.Edge.AppDefinesMember.MemberType+"',_P);}"+
					".inV;";

			var expectUpdateParams = new List<object> {
				vMem.VertexId,
				(byte)vNewMemTypeId,
				appId,
				(byte)vNewMemTypeId,
				userId,
				(byte)vNewMemTypeId
			};

			vMockData
				.Setup(x => x.Get<Member>(It.IsAny<IWeaverQuery>(), "Web-UpdateMemberType"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectUpdateScript, "_P", expectUpdateParams))
				.Returns(vMem);

			////

			Member result = vOper.Execute(vMockOpCtx.Object, vMem.VertexId, vNewMemTypeId);

			Assert.AreEqual(vMem, result, "Incorrect result.");
		}

	}

}