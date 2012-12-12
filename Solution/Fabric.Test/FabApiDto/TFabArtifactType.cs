using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Infrastructure;
using NUnit.Framework;

namespace Fabric.Test.FabApiDto {

	/*================================================================================================*/
	[TestFixture]
	public class TFabArtifactType {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NameDesc() {
			string name = "Test";
			string desc = "Ensure that the Name and Description properties are set correctly.";

			var dd = new DbDto();
			dd.Id = 99;
			dd.Data = new Dictionary<string, string>();
			dd.Data.Add("Name", name);
			dd.Data.Add("Description", desc);
			dd.Data.Add("ArtifactTypeId", "1");

			var at = new FabArtifactType();
			at.Fill(dd);

			Assert.AreEqual(name, at.Name, "Incorrect Name.");
			Assert.AreEqual(desc, at.Description, "Incorrect Description.");
		}

	}

}