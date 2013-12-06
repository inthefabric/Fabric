using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateClassOperation :
					TCreateArtifactOperation<Class, FabClass, CreateFabClass, CreateClassOperation> {

		private static readonly Logger Log = Logger.Build<TCreateClassOperation>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Name = "My Name";
			vCreateObj.Disamb = "My Disamb";
			vCreateObj.Note = "My Note";

			SetupDomResultAt(2);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pConditionCmdId) {
			var uniqueClass = AddCommand("uniqueClass", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
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

			pConditionCmdId = uniqueClass.CommandId;

			AddCommand("addClass", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
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

			return base.SetupCommands(pConditionCmdId);
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

	}

}