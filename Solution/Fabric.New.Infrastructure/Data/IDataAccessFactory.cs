namespace Fabric.New.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataAccessFactory {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataAccess Create(string pResumeSessionId=null, 
			bool pSetCommandIds=false, bool pOmitCommandTimers=true);

	}

}