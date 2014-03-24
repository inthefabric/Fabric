using System;
using Fabric.New.Api;
using Fabric.New.Api.Objects.Meta;
using NUnit.Framework;
using Nancy.Testing;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XMetaExecutors : XExecutorBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Spec() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("meta/spec");
			FabSpec result = AssertFabResponseData<FabSpec>(br);
			Assert.AreEqual(ApiModule.Version.Version, result.BuildVersion, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Version() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("meta/version");
			FabMetaVersion result = AssertFabResponseData<FabMetaVersion>(br);
			Assert.AreEqual(ApiModule.Version.Version, result.Version, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Time() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("meta/time");
			FabMetaTime result = AssertFabResponseData<FabMetaTime>(br);
			Assert.AreEqual(DateTime.UtcNow.Year, result.Year, "Incorrect result.");
		}
		
	}

}