using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver;
using Weaver.Interfaces;

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
			IWeaverQuery q = 
				Weave.Inst.BeginPath<User>(u => u.UserId, 2).BaseNode
				.UsesEmail
				.End();

			ApiCtx.DbList<UserUsesEmail>("test", q);
		}
		
	}

}