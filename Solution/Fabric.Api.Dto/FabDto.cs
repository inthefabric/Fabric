﻿using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public abstract class FabDto : IFabDto {

		public string Dto { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabDto() {
			Dto = GetType().Name;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract void Fill(IDbDto pDbDto);

	}

}