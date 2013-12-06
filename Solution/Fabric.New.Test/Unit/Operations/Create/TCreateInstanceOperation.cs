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
	public class TCreateInstanceOperation :
			TCreateArtifactOperation<Instance, FabInstance, CreateFabInstance, CreateInstanceOperation>{

		private static readonly Logger Log = Logger.Build<TCreateInstanceOperation>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vCreateObj.Name = "My Name";
			vCreateObj.Disamb = "My Disamb";
			vCreateObj.Note = "My Note";

			SetupAddVertexResultAt(1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pConditionCmdId) {
			AddCommand("addInstance", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = 
					"a=g.addVertex(["+
						DbName.Vert.Instance.Name+":_P,"+
						DbName.Vert.Instance.Disamb+":_P,"+
						DbName.Vert.Instance.Note+":_P,"+
						DbName.Vert.Vertex.VertexId+":_P,"+
						DbName.Vert.Vertex.Timestamp+":_P,"+
						DbName.Vert.Vertex.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vCreateObj.Name,
					vCreateObj.Disamb,
					vCreateObj.Note,
					vExpectDomResult.VertexId,
					vExpectDomResult.Timestamp,
					(byte)VertexType.Id.Instance
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
			return VertexType.Id.Instance;
		}

	}

}