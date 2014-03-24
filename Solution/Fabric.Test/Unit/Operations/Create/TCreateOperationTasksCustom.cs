using System.Collections.Generic;
using Fabric.Domain.Names;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksCustom {

		private Mock<ICreateOperationBuilder> vMockBuild;
		private CreateOperationTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockBuild = new Mock<ICreateOperationBuilder>(MockBehavior.Strict);
			vTasks = new CreateOperationTasks();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FindDuplicateMember() {
			const long userId = 362346236;
			const long appId = 757345745;

			const string script = 
				"m=g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
				".outE('"+DbName.Edge.UserDefinesMemberName+"')"+
					".has('"+DbName.Edge.UserDefinesMember.AppId+"',Tokens.T.eq,_P);";
			const string append = "m?0:1;";

			TCreateOperationTasksDuplicate.TestFindDuplicate(
				vMockBuild,
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
		[TestCase("My Disamb")]
		[TestCase(null)]
		public void FindDuplicateClass(string pDisamb) {
			const string name = "My Name";

			string script = "c=g.V('"+DbName.Vert.Class.NameKey+"',_P)";

			if ( pDisamb == null ) {
				script += ".hasNot('"+DbName.Vert.Class.Disamb+"')";
			}
			else {
				script += ".has('"+DbName.Vert.Class.Disamb+"')"+
					".filter{"+
						"it.property('"+DbName.Vert.Class.Disamb+"').next().toLowerCase()==_P"+
					"}";
			}

			script += ".property('"+DbName.Vert.Vertex.VertexId+"');";

			const string append = "c?0:1;";

			var param = new List<object>();
			param.Add(name);

			if ( pDisamb != null ) {
				param.Add(pDisamb);
			}

			TCreateOperationTasksDuplicate.TestFindDuplicate(
				vMockBuild,
				x => vTasks.FindDuplicateClass(x, name, pDisamb),
				script,
				append,
				param.ToArray()
			);
		}

	}

}