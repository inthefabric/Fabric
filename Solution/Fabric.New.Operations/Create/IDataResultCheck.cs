using Fabric.New.Infrastructure.Data;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public interface IDataResultCheck {

		string CommandId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void PerformCheck(IDataResult pDataRes);

	}

}