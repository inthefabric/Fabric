using Fabric.Infrastructure.Api;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {
	
	/*================================================================================================*/
	public class TestApiContext : ApiContext {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiContext() : base(null) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess NewAccess(IWeaverScript pScripted) {
			return new TestApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted) {
			return new TestApiDataAccess<T>(this, pScripted);
		}

	}

}