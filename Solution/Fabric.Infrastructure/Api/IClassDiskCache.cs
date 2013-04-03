namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IClassDiskCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddClass(long pClassId, string pName, string pDisamb);
		long GetClassId(string pName, string pDisamb);
		bool ContainsClass(string pName, string pDisamb);

	}

}