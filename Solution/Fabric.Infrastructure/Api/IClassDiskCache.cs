namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IClassDiskCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddClass(long pClassId, string pName, string pDisamb);
		long? FindClassId(string pName, string pDisamb);
		void Dispose();

	}

}