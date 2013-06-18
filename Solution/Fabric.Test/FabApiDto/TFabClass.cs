using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using ServiceStack.Text;

namespace Fabric.Test.FabApiDto {

	/*================================================================================================*/
	[TestFixture]
	public class TFabClass {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NameDesc() {
			const string name = "Test";
			const string disamb = "Ensure that the Name and Disamb properties are set correctly.";
			const long artId = 13463246;
			const long created = 134632424234623466;

			var dd = new DbDto();
			dd.Id = "x99";
			dd.Data = new JsonObject();
			dd.Data.Add(PropDbName.Class_Name, name);
			dd.Data.Add(PropDbName.Class_Disamb, disamb);
			dd.Data.Add(PropDbName.Artifact_ArtifactId, artId+"");
			dd.Data.Add(PropDbName.Artifact_Created, created+"");

			var dt = new FabClass();
			dt.Fill(dd);

			Assert.AreEqual(name, dt.Name, "Incorrect Name.");
			Assert.AreEqual(disamb, dt.Disamb, "Incorrect Disamb.");
			Assert.AreEqual(artId, dt.ArtifactId, "Incorrect ArtifactId.");
			Assert.AreEqual(created, dt.Created, "Incorrect Created.");
			Assert.AreEqual("FabClass", dt.FabType, "Incorrect FabType.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AvailableProps() {
			var dt = new FabClass();
			Assert.True(dt.HasProperty("VertexId"), "Missing 'VertexId' property.");
			Assert.True(dt.HasProperty("Name"), "Missing 'Name' property.");
			Assert.True(dt.HasProperty("Disamb"), "Missing 'Disamb' property.");
			Assert.True(dt.HasProperty("ArtifactId"), "Missing 'ArtifactId' property.");
			Assert.False(dt.HasProperty("Nam"), "Should not have 'Nam' property.");
			Assert.False(dt.HasProperty("Namee"), "Should not have 'Namee' property.");
		}

	}

}