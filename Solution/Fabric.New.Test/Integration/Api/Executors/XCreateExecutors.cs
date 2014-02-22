using System;
using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Query;
using Nancy.Testing;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XCreateExecutors : XExecutorBase {

		private static readonly Logger Log = Logger.Build<XCreateExecutors>();

		private string vToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vToken = SetupOauth.TokenFabZach;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Token, vToken)
					.SideEffect(
						new WeaverStatementSetProperty<OauthAccess>(x => x.Expires, 
							DateTime.UtcNow.AddMinutes(10).Ticks)
					)
				.ToQuery();

			ExecuteTestQuery(q, "UpdateAccessExpiration");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Class() {
			var obj = new CreateFabClass();
			obj.Name = "class test";

			BrowserResponse br = Post("mod/classes", obj);
			FabClass result = AssertFabResponseData<FabClass>(br);
			Assert.AreEqual(obj.Name, result.Name, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Factor() {
			var obj = new CreateFabFactor();
			obj.UsesPrimaryArtifactId = (long)SetupClassId.Blue;
			obj.UsesRelatedArtifactId = (long)SetupClassId.Beauty;
			obj.AssertionType = (byte)FactorAssertion.Id.Guess;
			obj.Descriptor = new CreateFabDescriptor();
			obj.Descriptor.Type = (byte)DescriptorType.Id.BelongsTo;

			BrowserResponse br = Post("mod/factors", obj);
			FabFactor result = AssertFabResponseData<FabFactor>(br);
			Assert.AreEqual(obj.AssertionType, result.AssertionType, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 6;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Instance() {
			var obj = new CreateFabInstance();
			obj.Name = "instance test";

			BrowserResponse br = Post("mod/instances", obj);
			FabInstance result = AssertFabResponseData<FabInstance>(br);
			Assert.AreEqual(obj.Name, result.Name, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Member() {
			var obj = new CreateFabMember();
			obj.DefinedByAppId = (long)SetupAppId.Bookmarker;
			obj.DefinedByUserId = (long)SetupUserId.FabData;
			obj.Type = (byte)MemberType.Id.Invite;

			BrowserResponse br = Post("mod/members", obj);
			FabMember result = AssertFabResponseData<FabMember>(br);
			Assert.AreEqual(obj.Type, result.Type, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 4;
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Url() {
			var obj = new CreateFabUrl();
			obj.Name = "url test";
			obj.FullPath = "http://www.inthefabric.com";

			BrowserResponse br = Post("mod/urls", obj);
			FabUrl result = AssertFabResponseData<FabUrl>(br);
			Assert.AreEqual(obj.Name, result.Name, "Incorrect result.");

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}
		
	}

}