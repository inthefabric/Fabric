using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksEdge {

		private static readonly Logger Log = Logger.Build<TCreateOperationTasksVertex>();
		private const string Prefix = "_P";
		private const string AddVertVar = "a";
		private const string VerifyVertVar = "vv";
		private const string VerifyCmdId = "verif";

		private Mock<ICreateOperationContext> vMockCreCtx;
		private CreateOperationTasks vTasks;
		private Queue<Action<IWeaverQuery, bool, string>> vAddQueryCallbacks;
		private Queue<Action<bool, bool>> vSetupLatestCallbacks;
		private Queue<string> vSetupLatestReturns;


			////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockCreCtx = new Mock<ICreateOperationContext>();
			vTasks = new CreateOperationTasks();
			vAddQueryCallbacks = new Queue<Action<IWeaverQuery, bool, string>>();
			vSetupLatestCallbacks = new Queue<Action<bool, bool>>();
			vSetupLatestReturns = new Queue<string>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SetupVerifyVertex(long pToVertId) {
			const string script = VerifyVertVar+"=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);";
			const string append = VerifyVertVar+"?{"+VerifyVertVar+"="+VerifyVertVar+".next();1;}:0;";
			const bool cache = true;
			const bool omit = false;
			const bool cond = true;

			var param = new List<object> { pToVertId };

			vAddQueryCallbacks.Enqueue((q, c, a) => {
				TestUtil.LogWeaverScript(Log, q);
				string s = TestUtil.InsertParamIndexes(script, Prefix);

				Assert.AreEqual(cache, c, "Incorrect cache.");
				Assert.AreEqual(s, q.Script, "Incorrect script.");
				Assert.AreEqual(append, a, "Incorrect append script.");
				TestUtil.CheckParams(q.Params, Prefix, param);
			});

			vSetupLatestCallbacks.Enqueue((o, c) => {
				Assert.AreEqual(omit, o, "Incorrect omit.");
				Assert.AreEqual(cond, c, "Incorrect cond.");
			});

			vSetupLatestReturns.Enqueue(VerifyCmdId);

			vMockCreCtx
				.Setup(x => x.AddCheck(It.IsAny<DataResultCheck>()))
				.Callback((DataResultCheck c) => {
					Assert.AreEqual(VerifyCmdId, c.CommandId, "Incorrect DataResultCheck.CommandId.");

					const int i = 999;

					var mockRes = new Mock<IDataResult>();
					mockRes.Setup(x => x.GetCommandIndexByCmdId(c.CommandId)).Returns(i);

					Log.Debug("Append passing DataResultCheck...");
					mockRes.Setup(x => x.ToIntAt(i, 0)).Returns(1);
					TestUtil.CheckThrows<FabNotFoundFault>(false,
						() => c.PerformCheck(mockRes.Object));

					Log.Debug("Append failing DataResultCheck...");
					mockRes.Setup(x => x.ToIntAt(i, 0)).Returns(0);
					TestUtil.CheckThrows<FabNotFoundFault>(true,
						() => c.PerformCheck(mockRes.Object));
				});
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SetupPrimaryEdge(string pEdgeName) {
			const string script = "g.addEdge(a,"+VerifyVertVar+",_P);";
			const bool cache = true;
			const bool omit = true;
			const bool cond = false;

			var param = new List<object> { pEdgeName };

			vAddQueryCallbacks.Enqueue((q, c, a) => {
				TestUtil.LogWeaverScript(Log, q);
				string s = TestUtil.InsertParamIndexes(script, Prefix);

				Assert.AreEqual(cache, c, "Incorrect cache.");
				Assert.AreEqual(s, q.Script, "Incorrect script.");
				Assert.Null(a, "Append script should be null.");
				TestUtil.CheckParams(q.Params, Prefix, param);
			});

			vSetupLatestCallbacks.Enqueue((o, c) => {
				Assert.AreEqual(omit, o, "Incorrect omit.");
				Assert.AreEqual(cond, c, "Incorrect cond.");
			});

			vSetupLatestReturns.Enqueue(null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SetupReverseEdge(string pEdgeName1, string[] pProps, object[] pParams) {
			const bool cache = true;
			const bool omit = true;
			const bool cond = false;

			string script = "g.addEdge("+VerifyVertVar+",a,_P";
			var param = new List<object> { pEdgeName1 };

			if ( pProps.Length > 0 ) {
				script += ",["+String.Join(",", pProps.Select(x => x+":"+Prefix))+"]";
				param.AddRange(pParams);
			}

			script += ");";

			vAddQueryCallbacks.Enqueue((q, c, a) => {
				TestUtil.LogWeaverScript(Log, q);
				string s = TestUtil.InsertParamIndexes(script, Prefix);

				Assert.AreEqual(cache, c, "Incorrect cache.");
				Assert.AreEqual(s, q.Script, "Incorrect script.");
				Assert.Null(a, "Append script should be null.");
				TestUtil.CheckParams(q.Params, Prefix, param);
			});

			vSetupLatestCallbacks.Enqueue((o, c) => {
				Assert.AreEqual(omit, o, "Incorrect omit.");
				Assert.AreEqual(cond, c, "Incorrect cond.");
			});

			vSetupLatestReturns.Enqueue(null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ExecuteAddEdge(Action<ICreateOperationContext> pAdd, int pQueryCount) {
			vMockCreCtx
				.Setup(x => x.AddQuery(It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()))
				.Callback((IWeaverQuery q, bool c, string a) => vAddQueryCallbacks.Dequeue()(q, c, a));

			vMockCreCtx
				.Setup(x => x.SetupLatestCommand(It.IsAny<bool>(), It.IsAny<bool>()))
				.Callback((bool o, bool c) => vSetupLatestCallbacks.Dequeue()(o, c))
				.Returns(() => vSetupLatestReturns.Dequeue());

			pAdd(vMockCreCtx.Object);

			vMockCreCtx
				.Verify(x => x.AddQuery(
					It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()),
					Times.Exactly(pQueryCount)
				);

			vMockCreCtx
				.Verify(x => x.SetupLatestCommand(
					It.IsAny<bool>(), It.IsAny<bool>()),
					Times.Exactly(pQueryCount)
				);

			vMockCreCtx
				.Verify(x => x.AddCheck(It.IsAny<DataResultCheck>()), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestAddEdgeSingle(
							Action<ICreateOperationContext> pAdd, long pToVertId, string pEdgeName) {
			SetupVerifyVertex(pToVertId);
			SetupPrimaryEdge(pEdgeName);
			ExecuteAddEdge(pAdd, 2);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestAddEdge(Action<ICreateOperationContext> pAdd, long pToVertId, 
							string pEdgeName0, string pEdgeName1, string[] pProps, object[] pParams) {
			SetupVerifyVertex(pToVertId);
			SetupPrimaryEdge(pEdgeName0);
			SetupReverseEdge(pEdgeName1, pProps, pParams);
			ExecuteAddEdge(pAdd, 3);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorCreatedByMember() {
			var dom = new Factor {
				Timestamp = 32462346,
				DescriptorType = (byte)DescriptorType.Id.BelongsTo
			};

			var cre = new CreateFabFactor {
				CreatedByMemberId = 452346234,
				UsesPrimaryArtifactId = 3462346,
				UsesRelatedArtifactId = 6532754
			};

			var alias = new WeaverVarAlias<Factor>(AddVertVar);

			TestAddEdge(
				x => vTasks.AddFactorCreatedByMember(x, dom, cre, alias),
				cre.CreatedByMemberId,
				DbName.Edge.FactorCreatedByMemberName,
				DbName.Edge.MemberCreatesFactorName,
				new[] {
					DbName.Edge.MemberCreatesFactor.Timestamp,
					DbName.Edge.MemberCreatesFactor.DescriptorType,
					DbName.Edge.MemberCreatesFactor.PrimaryArtifactId,
					DbName.Edge.MemberCreatesFactor.RelatedArtifactId
				},
				new object[] {
					dom.Timestamp,
					dom.DescriptorType,
					cre.UsesPrimaryArtifactId,
					cre.UsesRelatedArtifactId
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorDescriptorRefinesPrimaryWithArtifact() {
			const long toVertId = 3465234643;

			var dom = new Factor();

			var cre = new CreateFabFactor {
				Descriptor = new CreateFabDescriptor {
					RefinesTypeWithArtifactId = toVertId
				}
			};

			var alias = new WeaverVarAlias<Factor>(AddVertVar);

			TestAddEdgeSingle(
				x => vTasks.AddFactorDescriptorRefinesTypeWithArtifact(x, dom, cre, alias),
				toVertId,
				DbName.Edge.FactorDescriptorRefinesTypeWithArtifactName
			);
		}

	}

}