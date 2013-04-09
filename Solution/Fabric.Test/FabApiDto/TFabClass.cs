using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Db;
using NUnit.Framework;

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
			const long classId = 3642346463;
			const long artId = 13463246;
			const long created = 134632424234623466;

			var dd = new DbDto();
			dd.Id = "x99";
			dd.Data = new Dictionary<string, string>();
			dd.Data.Add("ClassId", classId+"");
			dd.Data.Add("Name", name);
			dd.Data.Add("Disamb", disamb);
			dd.Data.Add("ArtifactId", artId+"");
			dd.Data.Add("Created", created+"");

			var dt = new FabClass();
			dt.Fill(dd);

			Assert.AreEqual(classId, dt.ClassId, "Incorrect ClassId.");
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
			Assert.True(dt.HasProperty("NodeId"), "Missing 'NodeId' property.");
			Assert.True(dt.HasProperty("Name"), "Missing 'Name' property.");
			Assert.True(dt.HasProperty("Disamb"), "Missing 'Disamb' property.");
			Assert.True(dt.HasProperty("ClassId"), "Missing 'ClassId' property.");
			Assert.False(dt.HasProperty("Nam"), "Should not have 'Nam' property.");
			Assert.False(dt.HasProperty("Namee"), "Should not have 'Namee' property.");
		}

	}

}