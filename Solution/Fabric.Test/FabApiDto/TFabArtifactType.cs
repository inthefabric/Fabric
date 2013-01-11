using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;
using NUnit.Framework;

namespace Fabric.Test.FabApiDto {

	/*================================================================================================*/
	[TestFixture]
	public class TFabArtifactType {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NameDesc() {
			const string name = "Test";
			const string desc = "Ensure that the Name and Description properties are set correctly.";

			var dd = new DbDto();
			dd.NodeId = 99;
			dd.Data = new Dictionary<string, string>();
			dd.Data.Add("Name", name);
			dd.Data.Add("Description", desc);
			dd.Data.Add("ArtifactTypeId", "1");

			var at = new FabArtifactType();
			at.Fill(dd);

			Assert.AreEqual(name, at.Name, "Incorrect Name.");
			Assert.AreEqual(desc, at.Description, "Incorrect Description.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AvailableProps() {
			var at = new FabArtifactType();
			Assert.True(at.HasProperty("NodeId"), "Missing 'NodeId' property.");
			Assert.True(at.HasProperty("Name"), "Missing 'Name' property.");
			Assert.True(at.HasProperty("Description"), "Missing 'Description' property.");
			Assert.True(at.HasProperty("ArtifactTypeId"), "Missing 'ArtifactTypeId' property.");
			Assert.False(at.HasProperty("Nam"), "Should not have 'Nam' property.");
			Assert.False(at.HasProperty("Namee"), "Should not have 'Namee' property.");
		}

	}

}