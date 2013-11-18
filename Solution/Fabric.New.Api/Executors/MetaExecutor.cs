﻿using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class MetaExecutor<TObj> : FabResponseExecutor<TObj> where TObj : FabObject {

		private readonly TObj vObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetaExecutor(IApiRequest pApiReq, TObj pObject) : base(pApiReq) {
			vObj = pObject;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<TObj> GetResponse() {
			return new List<TObj> { vObj };
		}

	}

}