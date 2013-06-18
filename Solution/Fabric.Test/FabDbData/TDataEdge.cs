using System;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabDbData {

	/*================================================================================================*/
	[TestFixture]
	public class TDataEdge {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewBadOutVertex() {
			TestUtil.CheckThrows<Exception>(true, () => {
				var dr = new DataEdge<Member, FactorVectorUsesAxisArtifact, Artifact>(
					new Member(), new FactorVectorUsesAxisArtifact(), new Artifact(), false);
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewBadInVertex() {
			TestUtil.CheckThrows<Exception>(true, () => {
				var dr = new DataEdge<User, UserUsesEmail, Member>(
					new User(), new UserUsesEmail(), new Member(), false);
			});
		}

	}

}