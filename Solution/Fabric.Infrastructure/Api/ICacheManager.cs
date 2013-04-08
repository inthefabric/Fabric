﻿namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface ICacheManager {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IMemCache Memory { get; }
		IClassDiskCache UniqueClasses { get; }

	}

}