using System;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabDbData {

	/*================================================================================================*/
	[TestFixture]
	public class TDataRel {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewBadFromNode() {
			TestUtil.CheckThrows<Exception>(true, () => {
				var dr = new DataRel<Member, FactorUsesAxisArtifact, Artifact>(
					new Member(), new FactorUsesAxisArtifact(), new Artifact(), false);
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewBadToNode() {
			TestUtil.CheckThrows<Exception>(true, () => {
				var dr = new DataRel<User, UserUsesEmail, Member>(
					new User(), new UserUsesEmail(), new Member(), false);
			});
		}

	}

}