namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public interface IDiskCache<in TKey, TVal> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool ContainsKey(TKey pKey);
		void Add(TKey pKey, TVal pVal);
		void AddOrUpdate(TKey pKey, TVal pVal);
		TVal Get(TKey pKey);
		bool Remove(TKey pKey);

	}

}