using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
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
			dd.Id = 99;
			dd.Data = new Dictionary<string, string>();
			dd.Data.Add("Name", name);
			dd.Data.Add("Description", desc);
			dd.Data.Add("DescriptorTypeId", "1");

			var dt = new FabDescriptorType();
			dt.Fill(dd);

			Assert.AreEqual(name, dt.Name, "Incorrect Name.");
			Assert.AreEqual(desc, dt.Description, "Incorrect Description.");
			Assert.AreEqual(1, dt.DescriptorTypeId, "Incorrect DescriptorTypeId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AvailableProps() {
			var dt = new FabDescriptorType();
			Assert.True(dt.HasProperty("NodeId"), "Missing 'NodeId' property.");
			Assert.True(dt.HasProperty("Name"), "Missing 'Name' property.");
			Assert.True(dt.HasProperty("Description"), "Missing 'Description' property.");
			Assert.True(dt.HasProperty("DescriptorTypeId"), "Missing 'DescriptorTypeId' property.");
			Assert.False(dt.HasProperty("Nam"), "Should not have 'Nam' property.");
			Assert.False(dt.HasProperty("Namee"), "Should not have 'Namee' property.");
		}

	}

}