﻿using System.Collections.Generic;
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
		[TestCase("My Disamb")]
		[TestCase(null)]
		public void FindDuplicateClass(string pDisamb) {
			const string name = "My Name";

			string script =
				"c=g.V('"+DbName.Vert.Class.NameKey+"',_P)"+
				(pDisamb == null ? 
					".hasNot('"+DbName.Vert.Class.Disamb+"')" :
					".filter{it.property('"+DbName.Vert.Class.Disamb+"')?.toLowerCase()==_P;}"
				)+
				".property('"+DbName.Vert.Vertex.VertexId+"');";

			const string append = "c?0:1;";

			var param = new List<object>();
			param.Add(name);

			if ( pDisamb != null ) {
				param.Add(pDisamb);
			}

			TCreateOperationTasksDuplicate.TestFindDuplicate(
				vMockCreCtx,
				x => vTasks.FindDuplicateClass(x, name, pDisamb),
				script,
				append,
				param.ToArray()
			);
		}

	}

}