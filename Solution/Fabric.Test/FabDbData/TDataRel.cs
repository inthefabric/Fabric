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
		public void NewBadOutVertex() {
			TestUtil.CheckThrows<Exception>(true, () => {
				var dr = new DataRel<Member, FactorVectorUsesAxisArtifact, Artifact>(
					new Member(), new FactorVectorUsesAxisArtifact(), new Artifact(), false);
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewBadInVertex() {
			TestUtil.CheckThrows<Exception>(true, () => {
				var dr = new DataRel<User, UserUsesEmail, Member>(
					new User(), new UserUsesEmail(), new Member(), false);
			});
		}

	}

}