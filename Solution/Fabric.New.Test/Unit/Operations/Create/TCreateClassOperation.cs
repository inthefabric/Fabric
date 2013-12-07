using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateClassOperation :
					TCreateArtifactOperation<Class, FabClass, CreateFabClass, CreateClassOperation> {

		private static readonly Logger Log = Logger.Build<TCreateClassOperation>();

		private const int GetDuplicateCmdI = 1;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Name = "My Name";
			vCreateObj.Disamb = "My Disamb";
			vCreateObj.Note = "My Note";

			SetupAddVertexResultAt(2);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pCondCmdId) {
			var uniqueClass = AddCommand("uniqueClass", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"c=g.V('"+DbName.Vert.Class.NameKey+"',_P)"+
						".filter{"+
							"it.property('"+DbName.Vert.Class.Disamb+"')?.toLowerCase()==_P;"+
						"}"+
						".property('"+DbName.Vert.Vertex.VertexId+"');"+
						"c?1:0;",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name.ToLower(),
					vCreateObj.Disamb.ToLower()
				}),
				Cache = true
			});

			pCondCmdId = uniqueClass.CommandId;

			AddCommand("addClass", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.Class.Name+":_P,"+
						DbName.Vert.Class.NameKey+":_P,"+
						DbName.Vert.Class.Disamb+":_P,"+
						DbName.Vert.Class.Note+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name,
					vCreateObj.Name.ToLower(),
					vCreateObj.Disamb,
					vCreateObj.Note,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.Class
				}),
				Cache = true
			});

			return base.SetupCommands(pCondCmdId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Logger GetLogger() {
			return Log;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsInternalGetResult() {
			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexType.Id GetVertexTypeId() {
			return VertexType.Id.Class;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteFailDuplicate() {
			vMockDataAcc.MockResult.Setup(x => x.ToIntAt(GetDuplicateCmdI, 0)).Returns(1);
			CreateClassOperation c = BuildCreateVerify();
			TestUtil.Throws<FabDuplicateFault>(() => c.Execute());
		}

	}

}