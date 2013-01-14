using System;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {
	
	/*================================================================================================*/
	public class TestApiContext : ApiContext {

		public DateTime? TestUtcNow { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiContext() : base(null) {}

		/*--------------------------------------------------------------------------------------------*/
		public override DateTime UtcNow {
			get {
				return (TestUtcNow == null ? base.UtcNow : (DateTime)TestUtcNow);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess NewAccess(IWeaverScript pScripted) {
			Log.Debug("");
			return new TestApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted) {
			Log.Debug("");
			return new TestApiDataAccess<T>(this, pScripted);
		}

	}

}