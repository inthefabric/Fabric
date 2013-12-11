using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksVertex {

		private static readonly Logger Log = Logger.Build<TCreateOperationTasksVertex>();
		private const string Prefix = "_P";

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
		private T FillVertexProps<T>(T pVert) where T : IVertex {
			pVert.VertexId = 123;
			pVert.Timestamp = 987865;
			return pVert;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestAddVertex(
							Action<ICreateOperationContext> pAdd, string[] pProps, object[] pParams) {
			string script = "a=g.addVertex(["+String.Join(",", pProps.Select(x => x+":"+Prefix))+"]);";
			const string cmdId = "1234";
			const bool cache = true;
			const bool omit = false;
			const bool cond = false;

			vMockCreCtx
				.Setup(x => x.AddQuery(It.IsAny<IWeaverQuery>(), cache, null))
				.Callback((IWeaverQuery q, bool c, string a) => {
					TestUtil.LogWeaverScript(Log, q);
					string s = TestUtil.InsertParamIndexes(script, Prefix);
					Assert.AreEqual(s, q.Script, "Incorrect script.");
					TestUtil.CheckParams(q.Params, Prefix, pParams);
				});

			vMockCreCtx
				.Setup(x => x.SetupLatestCommand(omit, cond))
				.Returns(cmdId);

			pAdd(vMockCreCtx.Object);

			vMockCreCtx
				.Verify(x => x.AddQuery(
				It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Once);

			vMockCreCtx
				.Verify(x => x.SetupLatestCommand(It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddApp() {
			var app = FillVertexProps(new App {
				Name = "App Name",
				NameKey = "app name",
				Secret = "my secret"
			});

			IWeaverVarAlias<App> alias;

			TestAddVertex(
				x => vTasks.AddApp(x, app, out alias),
				new[] {
					DbName.Vert.App.Name,
					DbName.Vert.App.NameKey,
					DbName.Vert.App.Secret,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					app.Name,
					app.NameKey,
					app.Secret,
					app.VertexId,
					app.Timestamp,
					(byte)VertexType.Id.App
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddClass() {
			var cla = FillVertexProps(new Class {
				Name = "Class Name",
				NameKey = "class name",
				Disamb = "Class Disamb",
				Note = "Class Note"
			});

			IWeaverVarAlias<Class> alias;

			TestAddVertex(
				x => vTasks.AddClass(x, cla, out alias),
				new[] {
					DbName.Vert.Class.Name,
					DbName.Vert.Class.NameKey,
					DbName.Vert.Class.Disamb,
					DbName.Vert.Class.Note,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					cla.Name,
					cla.NameKey,
					cla.Disamb,
					cla.Note,
					cla.VertexId,
					cla.Timestamp,
					(byte)VertexType.Id.Class
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddEmail() {
			var em = FillVertexProps(new Email {
				Address = "zach@email.COM",
				Code = "asdlkguasdgs",
				Verified = true
			});

			IWeaverVarAlias<Email> alias;

			TestAddVertex(
				x => vTasks.AddEmail(x, em, out alias),
				new[] {
					DbName.Vert.Email.Address,
					DbName.Vert.Email.Code,
					DbName.Vert.Email.Verified,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					em.Address,
					em.Code,
					em.Verified,
					em.VertexId,
					em.Timestamp,
					(byte)VertexType.Id.Email
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void AddFactor(bool pMax) {
			var fac = new Factor {
				AssertionType = (byte)FactorAssertion.Id.Opinion,
				IsDefining = true,
				Note = "Factor Note",
				DescriptorType = (byte)DescriptorType.Id.Consumes
			};

			if ( pMax ) {
				fac.DirectorType = 9;
				fac.DirectorPrimaryAction = 8;
				fac.DirectorRelatedAction = 7;

				fac.EventorType = 6;
				fac.EventorDateTime = 87269834764236;

				fac.IdentorType = 13;
				fac.IdentorValue = "MyIdentorVal";

				fac.LocatorType = 22;
				fac.LocatorValueX = 1.234;
				fac.LocatorValueY = 12.3456;
				fac.LocatorValueZ = 123.4567;

				fac.VectorType = 2;
				fac.VectorUnit = 3;
				fac.VectorUnitPrefix = 4;
				fac.VectorValue = 21464;
			}

			fac = FillVertexProps(fac);

			////

			var props = new List<string> {
				DbName.Vert.Factor.AssertionType,
				DbName.Vert.Factor.IsDefining,
				DbName.Vert.Factor.Note,
				DbName.Vert.Factor.DescriptorType,
			};

			var param = new List<object> {
				fac.AssertionType,
				fac.IsDefining,
				fac.Note,
				fac.DescriptorType
			};

			if ( pMax ) {
				props.AddRange(new List<string> {
					DbName.Vert.Factor.DirectorType,
					DbName.Vert.Factor.DirectorPrimaryAction,
					DbName.Vert.Factor.DirectorRelatedAction,

					DbName.Vert.Factor.EventorType,
					DbName.Vert.Factor.EventorDateTime,

					DbName.Vert.Factor.IdentorType,
					DbName.Vert.Factor.IdentorValue,

					DbName.Vert.Factor.LocatorType,
					DbName.Vert.Factor.LocatorValueX,
					DbName.Vert.Factor.LocatorValueY,
					DbName.Vert.Factor.LocatorValueZ,

					DbName.Vert.Factor.VectorType,
					DbName.Vert.Factor.VectorUnit,
					DbName.Vert.Factor.VectorUnitPrefix,
					DbName.Vert.Factor.VectorValue
				});

				param.AddRange(new List<object> {
					fac.DirectorType,
					fac.DirectorPrimaryAction,
					fac.DirectorRelatedAction,

					fac.EventorType,
					fac.EventorDateTime,

					fac.IdentorType,
					fac.IdentorValue,

					fac.LocatorType,
					fac.LocatorValueX,
					fac.LocatorValueY,
					fac.LocatorValueZ,

					fac.VectorType,
					fac.VectorUnit,
					fac.VectorUnitPrefix,
					fac.VectorValue
				});
			}

			props.AddRange(new List<string> {
				DbName.Vert.Vertex.VertexId,
				DbName.Vert.Vertex.Timestamp,
				DbName.Vert.Vertex.VertexType
			});

			param.AddRange(new List<object> {
				fac.VertexId,
				fac.Timestamp,
				(byte)VertexType.Id.Factor
			});

			////

			IWeaverVarAlias<Factor> alias;

			TestAddVertex(
				x => vTasks.AddFactor(x, fac, out alias),
				props.ToArray(),
				param.ToArray()
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddInstance() {
			var ins = FillVertexProps(new Instance {
				Name = "Instance Name",
				Disamb = "Instance Disamb",
				Note = "Instance Note"
			});

			IWeaverVarAlias<Instance> alias;

			TestAddVertex(
				x => vTasks.AddInstance(x, ins, out alias),
				new[] {
					DbName.Vert.Instance.Name,
					DbName.Vert.Instance.Disamb,
					DbName.Vert.Instance.Note,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					ins.Name,
					ins.Disamb,
					ins.Note,
					ins.VertexId,
					ins.Timestamp,
					(byte)VertexType.Id.Instance
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddMember() {
			var em = FillVertexProps(new Member {
				MemberType = (byte)MemberType.Id.Staff
			});

			IWeaverVarAlias<Member> alias;

			TestAddVertex(
				x => vTasks.AddMember(x, em, out alias),
				new[] {
					DbName.Vert.Member.MemberType,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					em.MemberType,
					em.VertexId,
					em.Timestamp,
					(byte)VertexType.Id.Member
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddOauthAccess() {
			var oa = FillVertexProps(new OauthAccess {
				Token = "asdgsdgasdlg",
				Refresh = "rgqregzsdfggdsgee",
				Expires = 346234623463,
				IsDataProv = true
			});

			IWeaverVarAlias<OauthAccess> alias;

			TestAddVertex(
				x => vTasks.AddOauthAccess(x, oa, out alias),
				new[] {
					DbName.Vert.OauthAccess.Token,
					DbName.Vert.OauthAccess.Refresh,
					DbName.Vert.OauthAccess.Expires,
					DbName.Vert.OauthAccess.IsDataProv,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					oa.Token,
					oa.Refresh,
					oa.Expires,
					oa.IsDataProv,
					oa.VertexId,
					oa.Timestamp,
					(byte)VertexType.Id.OauthAccess
				}
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddUrl() {
			var em = FillVertexProps(new Url {
				Name = "Url Name",
				FullPath = "http://www.fullPath.com"
			});

			IWeaverVarAlias<Url> alias;

			TestAddVertex(
				x => vTasks.AddUrl(x, em, out alias),
				new[] {
					DbName.Vert.Url.Name,
					DbName.Vert.Url.FullPath,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					em.Name,
					em.FullPath,
					em.VertexId,
					em.Timestamp,
					(byte)VertexType.Id.Url
				}
			);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddUser() {
			var user = FillVertexProps(new User {
				Name = "User Name",
				NameKey = "User name",
				Password = DataUtil.HashPassword("my passWORD")
			});

			IWeaverVarAlias<User> alias;

			TestAddVertex(
				x => vTasks.AddUser(x, user, out alias),
				new[] {
					DbName.Vert.User.Name,
					DbName.Vert.User.NameKey,
					DbName.Vert.User.Password,
					DbName.Vert.Vertex.VertexId,
					DbName.Vert.Vertex.Timestamp,
					DbName.Vert.Vertex.VertexType
				},
				new object[] {
					user.Name,
					user.NameKey,
					user.Password,
					user.VertexId,
					user.Timestamp,
					(byte)VertexType.Id.User
				}
			);
		}

	}

}