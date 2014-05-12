using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Create;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Elements;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksEdge {

		private static readonly Logger Log = Logger.Build<TCreateOperationTasksVertex>();
		private const string Prefix = "_P";
		private const string AddVertVar = "a";
		private const string VerifyVertVar = "vv";
		private const string VerifyCmdId = "verif";

		private Mock<ICreateOperationBuilder> vMockBuild;
		private CreateOperationTasks vTasks;
		private Queue<Action<IWeaverQuery, bool, string>> vAddQueryCallbacks;
		private Queue<Action<bool, bool>> vSetupLatestCallbacks;
		private Queue<string> vSetupLatestReturns;


			////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockBuild = new Mock<ICreateOperationBuilder>(MockBehavior.Strict);
			vMockBuild.Setup(x => x.GetNextAliasName()).Returns(VerifyVertVar);

			vTasks = new CreateOperationTasks();
			vAddQueryCallbacks = new Queue<Action<IWeaverQuery, bool, string>>();
			vSetupLatestCallbacks = new Queue<Action<bool, bool>>();
			vSetupLatestReturns = new Queue<string>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private IWeaverVarAlias<T> GetAddVertexAlias<T>() where T : IWeaverElement {
			return new WeaverVarAlias<T>(AddVertVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SetupVerifyVertex(long pToVertId) {
			const string script = VerifyVertVar+"=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);";
			const string append = "if("+VerifyVertVar+"){"+
				VerifyVertVar+"="+VerifyVertVar+".next();1;}else{0;}";
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

			vMockBuild
				.Setup(x => x.AddCheck(It.IsAny<IDataResultCheck>()))
				.Callback((IDataResultCheck c) => {
					Assert.AreEqual(VerifyCmdId, c.CommandId, "Incorrect DataResultCheck.CommandId.");

					const int i = 999;

					var mockRes = new Mock<IDataResult>(MockBehavior.Strict);
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
			const string script = "g.addEdge("+AddVertVar+","+VerifyVertVar+",_P);";
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

			string script = "g.addEdge("+VerifyVertVar+","+AddVertVar+",_P";
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
		private void ExecuteAddEdge(Action<ICreateOperationBuilder> pAdd, int pQueryCount) {
			vMockBuild
				.Setup(x => x.AddQuery(It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()))
				.Callback((IWeaverQuery q, bool c, string a) => vAddQueryCallbacks.Dequeue()(q, c, a));

			vMockBuild
				.Setup(x => x.SetupLatestCommand(It.IsAny<bool>(), It.IsAny<bool>()))
				.Callback((bool o, bool c) => vSetupLatestCallbacks.Dequeue()(o, c))
				.Returns(() => vSetupLatestReturns.Dequeue());

			pAdd(vMockBuild.Object);

			vMockBuild
				.Verify(x => x.AddQuery(
					It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()),
					Times.Exactly(pQueryCount)
				);

			vMockBuild
				.Verify(x => x.SetupLatestCommand(
					It.IsAny<bool>(), It.IsAny<bool>()),
					Times.Exactly(pQueryCount)
				);

			vMockBuild
				.Verify(x => x.AddCheck(It.IsAny<DataResultCheck>()), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestAddEdgeSingle(
							Action<ICreateOperationBuilder> pAdd, long pToVertId, string pEdgeName) {
			SetupVerifyVertex(pToVertId);
			SetupPrimaryEdge(pEdgeName);
			ExecuteAddEdge(pAdd, 2);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestAddEdge(Action<ICreateOperationBuilder> pAdd, long pToVertId, 
							string pEdgeName0, string pEdgeName1, string[] pProps, object[] pParams) {
			SetupVerifyVertex(pToVertId);
			SetupPrimaryEdge(pEdgeName0);
			SetupReverseEdge(pEdgeName1, pProps, pParams);
			ExecuteAddEdge(pAdd, 3);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestAddEdgeNull(Action<ICreateOperationBuilder> pAdd) {
			pAdd(vMockBuild.Object);

			vMockBuild
				.Verify(x => x.AddQuery(
					It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Never);

			vMockBuild
				.Verify(x => x.SetupLatestCommand(It.IsAny<bool>(), It.IsAny<bool>()), Times.Never);

			vMockBuild
				.Verify(x => x.AddCheck(It.IsAny<DataResultCheck>()), Times.Never);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddArtifactCreatedByMember() {
			var dom = new Artifact {
				Timestamp = 32462346,
				VertexType = (byte)VertexType.Id.Class
			};

			var cre = new CreateFabArtifact {
				CreatedByMemberId = 452346234
			};

			TestAddEdge(
				x => vTasks.AddArtifactCreatedByMember(x, dom, cre, GetAddVertexAlias<Artifact>()),
				cre.CreatedByMemberId,
				DbName.Edge.ArtifactCreatedByMemberName,
				DbName.Edge.MemberCreatesArtifactName,
				new[] {
					DbName.Edge.MemberCreatesArtifact.Timestamp,
					DbName.Edge.MemberCreatesArtifact.VertexType
				},
				new object[] {
					dom.Timestamp,
					dom.VertexType
				}
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddEmailUsedByArtifact() {
			var dom = new Email();

			var cre = new CreateFabEmail {
				UsedByArtifactId = 433622
			};

			TestAddEdge(
				x => vTasks.AddEmailUsedByArtifact(x, dom, cre, GetAddVertexAlias<Email>()),
				cre.UsedByArtifactId,
				DbName.Edge.EmailUsedByArtifactName,
				DbName.Edge.ArtifactUsesEmailName,
				new string[0], 
				new object[0]
			);
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

			TestAddEdge(
				x => vTasks.AddFactorCreatedByMember(x, dom, cre, GetAddVertexAlias<Factor>()),
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorDescriptorRefinesPrimaryWithArtifact() {
			const long toVertId = 3465234643;

			var dom = new Factor();

			var cre = new CreateFabFactor {
				Descriptor = new CreateFabDescriptor {
					RefinesPrimaryWithArtifactId = toVertId
				}
			};

			TestAddEdgeSingle(
				x => vTasks.AddFactorDescriptorRefinesPrimaryWithArtifact(
					x, dom, cre, GetAddVertexAlias<Factor>()),
				toVertId,
				DbName.Edge.FactorDescriptorRefinesPrimaryWithArtifactName
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void AddFactorDescriptorRefinesPrimaryWithArtifactNull(bool pType) {
			var dom = new Factor();
			var cre = new CreateFabFactor();

			if ( pType ) {
				cre.Descriptor = new CreateFabDescriptor();
			}

			TestAddEdgeNull(
				x => vTasks.AddFactorDescriptorRefinesPrimaryWithArtifact(
					x, dom, cre, GetAddVertexAlias<Factor>())
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorDescriptorRefinesRelatedWithArtifact() {
			const long toVertId = 3465234643;

			var dom = new Factor();

			var cre = new CreateFabFactor {
				Descriptor = new CreateFabDescriptor {
					RefinesRelatedWithArtifactId = toVertId
				}
			};

			TestAddEdgeSingle(
				x => vTasks.AddFactorDescriptorRefinesRelatedWithArtifact(
					x, dom, cre, GetAddVertexAlias<Factor>()),
				toVertId,
				DbName.Edge.FactorDescriptorRefinesRelatedWithArtifactName
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void AddFactorDescriptorRefinesRelatedWithArtifactNull(bool pType) {
			var dom = new Factor();
			var cre = new CreateFabFactor();

			if ( pType ) {
				cre.Descriptor = new CreateFabDescriptor();
			}

			TestAddEdgeNull(
				x => vTasks.AddFactorDescriptorRefinesRelatedWithArtifact(
					x, dom, cre, GetAddVertexAlias<Factor>())
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorDescriptorRefinesTypeWithArtifact() {
			const long toVertId = 3465234643;

			var dom = new Factor();

			var cre = new CreateFabFactor {
				Descriptor = new CreateFabDescriptor {
					RefinesTypeWithArtifactId = toVertId
				}
			};

			TestAddEdgeSingle(
				x => vTasks.AddFactorDescriptorRefinesTypeWithArtifact(
					x, dom, cre, GetAddVertexAlias<Factor>()),
				toVertId,
				DbName.Edge.FactorDescriptorRefinesTypeWithArtifactName
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void AddFactorDescriptorRefinesTypeWithArtifactNull(bool pType) {
			var dom = new Factor();
			var cre = new CreateFabFactor();

			if ( pType ) {
				cre.Descriptor = new CreateFabDescriptor();
			}

			TestAddEdgeNull(
				x => vTasks.AddFactorDescriptorRefinesTypeWithArtifact(
					x, dom, cre, GetAddVertexAlias<Factor>())
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorUsesPrimaryArtifact() {
			var dom = new Factor {
				Timestamp = 9439439349,
				DescriptorType = (byte)DescriptorType.Id.IsCreatedBy
			};

			var cre = new CreateFabFactor { 
				UsesPrimaryArtifactId = 5436236234,
				UsesRelatedArtifactId = 236234623
			};

			TestAddEdge(
				x => vTasks.AddFactorUsesPrimaryArtifact(x, dom, cre, GetAddVertexAlias<Factor>()),
				cre.UsesPrimaryArtifactId,
				DbName.Edge.FactorUsesPrimaryArtifactName,
				DbName.Edge.ArtifactUsedAsPrimaryByFactorName,
				new[] {
					DbName.Edge.ArtifactUsedAsPrimaryByFactor.Timestamp,
					DbName.Edge.ArtifactUsedAsPrimaryByFactor.DescriptorType,
					DbName.Edge.ArtifactUsedAsPrimaryByFactor.RelatedArtifactId
				},
				new object[] {
					dom.Timestamp,
					dom.DescriptorType,
					cre.UsesRelatedArtifactId
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorUsesRelatedArtifact() {
			var dom = new Factor {
				Timestamp = 94394393349,
				DescriptorType = (byte)DescriptorType.Id.IsCreatedBy
			};

			var cre = new CreateFabFactor {
				UsesRelatedArtifactId = 36236234,
				UsesPrimaryArtifactId = 1236234623
			};

			TestAddEdge(
				x => vTasks.AddFactorUsesRelatedArtifact(x, dom, cre, GetAddVertexAlias<Factor>()),
				cre.UsesRelatedArtifactId,
				DbName.Edge.FactorUsesRelatedArtifactName,
				DbName.Edge.ArtifactUsedAsRelatedByFactorName,
				new[] {
					DbName.Edge.ArtifactUsedAsRelatedByFactor.Timestamp,
					DbName.Edge.ArtifactUsedAsRelatedByFactor.DescriptorType,
					DbName.Edge.ArtifactUsedAsRelatedByFactor.PrimaryArtifactId
				},
				new object[] {
					dom.Timestamp,
					dom.DescriptorType,
					cre.UsesPrimaryArtifactId
				}
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddFactorVectorUsesAxisArtifact() {
			const long toVertId = 3465234643;

			var dom = new Factor();

			var cre = new CreateFabFactor {
				Vector= new CreateFabVector {
					UsesAxisArtifactId = toVertId
				}
			};

			TestAddEdgeSingle(
				x => vTasks.AddFactorVectorUsesAxisArtifact(x, dom, cre, GetAddVertexAlias<Factor>()),
				toVertId,
				DbName.Edge.FactorVectorUsesAxisArtifactName
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void AddFactorVectorUsesAxisArtifactNull(bool pType) {
			var dom = new Factor();
			var cre = new CreateFabFactor();

			if ( pType ) {
				cre.Vector = new CreateFabVector();
			}

			TestAddEdgeNull(
				x => vTasks.AddFactorVectorUsesAxisArtifact(x, dom, cre, GetAddVertexAlias<Factor>())
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddMemberDefinedByApp() {
			var dom = new Member {
				MemberType = (byte)MemberType.Id.Staff,
				Timestamp = 9439439349
			};

			var cre = new CreateFabMember {
				DefinedByAppId = 5436236234,
				DefinedByUserId = 236234623
			};

			TestAddEdge(
				x => vTasks.AddMemberDefinedByApp(x, dom, cre, GetAddVertexAlias<Member>()),
				cre.DefinedByAppId,
				DbName.Edge.MemberDefinedByAppName,
				DbName.Edge.AppDefinesMemberName,
				new[] {
					DbName.Edge.AppDefinesMember.Timestamp,
					DbName.Edge.AppDefinesMember.MemberType,
					DbName.Edge.AppDefinesMember.UserId
				},
				new object[] {
					dom.Timestamp,
					dom.MemberType,
					cre.DefinedByUserId
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddMemberDefinedByUser() {
			var dom = new Member {
				MemberType = (byte)MemberType.Id.Staff,
				Timestamp = 94394393349,
			};

			var cre = new CreateFabMember {
				DefinedByUserId = 36236234,
				DefinedByAppId = 1236234623
			};

			TestAddEdge(
				x => vTasks.AddMemberDefinedByUser(x, dom, cre, GetAddVertexAlias<Member>()),
				cre.DefinedByUserId,
				DbName.Edge.MemberDefinedByUserName,
				DbName.Edge.UserDefinesMemberName,
				new[] {
					DbName.Edge.UserDefinesMember.Timestamp,
					DbName.Edge.UserDefinesMember.MemberType,
					DbName.Edge.UserDefinesMember.AppId
				},
				new object[] {
					dom.Timestamp,
					dom.MemberType,
					cre.DefinedByAppId
				}
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddOauthAccessAuthenticatesMember() {
			var dom = new OauthAccess {
				Timestamp = 9439439349
			};

			var cre = new CreateFabOauthAccess {
				AuthenticatesMemberId = 7272727
			};

			TestAddEdge(
				x => vTasks.AddOauthAccessAuthenticatesMember(
					x, dom, cre, GetAddVertexAlias<OauthAccess>()),
				cre.AuthenticatesMemberId,
				DbName.Edge.OauthAccessAuthenticatesMemberName,
				DbName.Edge.MemberAuthenticatedByOauthAccessName,
				new[] {
					DbName.Edge.MemberAuthenticatedByOauthAccess.Timestamp
				},
				new object[] {
					dom.Timestamp
				}
			);
		}

	}

}