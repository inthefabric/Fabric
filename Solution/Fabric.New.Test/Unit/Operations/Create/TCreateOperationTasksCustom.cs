using Fabric.New.Domain.Names;
using Fabric.New.Operations.Create;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksCustom {

		private Mock<ICreateOperationContext> vMockCreCtx;
		private CreateOperationTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockCreCtx = new Mock<ICreateOperationContext>();
			vTasks = new CreateOperationTasks();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FindDuplicateMember() {
			const long userId = 362346236;
			const long appId = 362346236;

			const string script = 
				"m=g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
				".outE('"+DbName.Edge.UserDefinesMemberName+"')"+
					".has('"+DbName.Edge.UserDefinesMember.AppId+"',Tokens.T.eq,_P);";
			const string append = "m?0:1;";

			TCreateOperationTasksDuplicate.TestFindDuplicate(
				vMockCreCtx,
				x => vTasks.FindDuplicateMember(x, userId, appId),
				script,
				append,
				new object[] {
					userId,
					appId
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FindDuplicateClass() {
			const string name = "My Name";
			const string disamb = "My Disamb";

			const string script =
				"c=g.V('"+DbName.Vert.Class.NameKey+"',_P)"+
				".filter{"+
					"it.property('"+DbName.Vert.Class.Disamb+"')?.toLowerCase()==_P;"+
				"}"+
				".property('"+DbName.Vert.Vertex.VertexId+"');";
			const string append = "c?0:1;";

			TCreateOperationTasksDuplicate.TestFindDuplicate(
				vMockCreCtx,
				x => vTasks.FindDuplicateClass(x, name, disamb),
				script,
				append,
				new object[] {
					name,
					disamb
				}
			);
		}

	}

}