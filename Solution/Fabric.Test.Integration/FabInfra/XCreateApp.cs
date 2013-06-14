﻿using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XDbDto : IntegTestBase {
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Edge() {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(u => u.ArtifactId, 2)
				.UsesEmail
				.ToQuery();

			ApiCtx.DbList<UserUsesEmail>("test", q);
		}
		
	}

}