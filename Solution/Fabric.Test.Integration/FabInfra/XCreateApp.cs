using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Infrastructure.Data;

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

			ApiCtx.GetList<UserUsesEmail>(q);
		}
		
	}

}