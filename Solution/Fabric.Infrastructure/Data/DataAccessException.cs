using System;

namespace Fabric.New.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccessException : Exception {
	
		public IDataAccess Access { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataAccessException(IDataAccess pAccess, string pMessage) : base(pMessage) {
			Access = pAccess;
		}

	}

}