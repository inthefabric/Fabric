using Fabric.Infrastructure.Data;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public interface IDataResultCheck {

		string CommandId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void PerformCheck(IDataResult pDataRes);

	}

}