using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateArtifactOperation<TDom, TApi, TCre, TOper> :
										TCreateVertexOperation<TDom, TApi, TCre, TOper>
										where TDom : Artifact, new()
										where TApi : FabArtifact, new()
										where TCre : CreateFabArtifact, new()
										where TOper : CreateArtifactOperation<TDom, TApi, TCre>, new() {

		private long vMemId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpInner() {
			base.SetUpInner();

			vMemId = 123456;

			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(vMemId);
			vMockData.Setup(x => x.GetVertexById<Vertex>(vMemId)).Returns(new Member());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string SetupCommands(string pConditionCmdId) {
			var getMember = AddCommand("getMember", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "v0=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);(v0?{v0=v0.next();1;}:0);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					vMemId
				}),
				Cache = true
			});

			pConditionCmdId = getMember.CommandId;

			AddCommand("addEdgeAcbm", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = "g.addEdge(a,v0,_P);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.ArtifactCreatedByMemberName
				}),
				Cache = true,
				OmitResults = true
			});

			AddCommand("addEdgeMca", new MockDataAccessCmd {
				ConditionCmdId = pConditionCmdId,
				Script = 
					"g.addEdge(v0,a,_P,["+
						DbName.Edge.MemberCreatesArtifact.Timestamp+":_P,"+
						DbName.Edge.MemberCreatesArtifact.VertexType+":_P"+
					"]);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> {
					DbName.Edge.MemberCreatesArtifactName,
					vExpectDomResult.Timestamp,
					(byte)GetVertexTypeId()
				}),
				Cache = true,
				OmitResults = true
			});

			return pConditionCmdId;
		}

	}

}