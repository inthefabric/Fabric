using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateClassOperation : 
					TCreateArtifactOperation<Class, FabClass, CreateFabClass, CreateClassOperation> {

		private static readonly Logger Log = Logger.Build<TCreateClassOperation>();

		private const string UniqueClassNameScript = "g.V('"+DbName.Vert.Class.NameKey+"',_P);";

		private const string CreateClassScript = 
			"_V0=g.addVertex(["+
				DbName.Vert.Class.Name+":_TP,"+
				DbName.Vert.Class.NameKey+":_TP,"+
				DbName.Vert.Class.Disamb+":_TP,"+
				DbName.Vert.Class.Note+":_TP,"+
				DbName.Vert.Vertex.VertexId+":_TP,"+
				DbName.Vert.Vertex.Timestamp+":_TP,"+
				DbName.Vert.Vertex.VertexType+":_TP"+
			"]);"+
			"_V1=g.V('"+DbName.Vert.Vertex.VertexId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"g.addEdge(_V1,_V0,_TP,["+
				DbName.Edge.MemberCreatesArtifact.Timestamp+":_TP,"+
				DbName.Edge.MemberCreatesArtifact.VertexType+":_TP"+
			"]);"+
			"_V0;";

		private Action<IWeaverScript, string> vCheckUniqueClassName;
		private Action<IWeaverScript, string> vCheckCreateClass;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vCreateObj.Name = "My Name";
			vCreateObj.Disamb = "My Disamb";
			vCreateObj.Note = "My Note";

			////

			vCheckUniqueClassName = ((ws, n) => {
				var list = new List<object> {
					vCreateObj.Name.ToLower()
				};

			    CheckScriptAndParams(Log, ws, UniqueClassNameScript, "_P", list);
			});

			vCheckCreateClass = ((ws, n) => {
				var list = new List<object> {
					vCreateObj.Name,
					vCreateObj.Name.ToLower(),
					vCreateObj.Disamb,
					vCreateObj.Note,
					vVertId,
					vVertTime.Ticks,
					(byte)VertexType.Id.Class,
					vMemId,
					DbName.Edge.ArtifactCreatedByMemberName,
					DbName.Edge.MemberCreatesArtifactName,
					vVertTime.Ticks,
					(byte)VertexType.Id.Class,
				};

				CheckScriptAndParams(Log, ws, CreateClassScript, "_TP", list);
			});
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCreate() {
			base.VerifyCreate();

			vMockData.Verify(
				x => x.Get<Class>(It.IsAny<IWeaverQuery>(), "UniqueClassName"),
				Times.Once
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CreateDuplicate() {
			vMockData
				.Setup(x => x.Get<Class>(It.IsAny<IWeaverQuery>(), "UniqueClassName"))
				.Callback(vCheckUniqueClassName)
				.Returns(new Class());

			TestUtil.Throws<FabDuplicateFault>(() => DoCreate());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsInternalGetResult() {
			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Action<IWeaverScript, string> GetCreateScriptCallback() {
			return vCheckCreateClass;
		}

	}

}