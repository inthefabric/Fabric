using System.Collections.Generic;
using Fabric.New.Domain;

namespace Fabric.New.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataResult {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetSessionId();
		int GetCommandCount();
		int GetCommandResultCount(int pCommandIndex=0);
		int GetCommandIndexByCmdId(string pCmdId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataDto ToDto();
		T ToElement<T>() where T : class, IElement, new();
		IDictionary<string, string> ToMap();
		IList<IDataDto> ToDtoList();
		IList<IList<IDataDto>> ToDtoLists();
		IList<T> ToElementList<T>() where T : class, IElement, new();
		IList<IList<IDictionary<string, string>>> ToMapLists();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataDto ToDtoAt(int pCommandIndex, int pResultIndex);
		T ToElementAt<T>(int pCommandIndex, int pResultIndex) where T : class, IElement, new();
		IDictionary<string, string> ToMapAt(int pCommandIndex, int pResultIndex);
		string ToStringAt(int pCommandIndex, int pResultIndex);
		int ToIntAt(int pCommandIndex, int pResultIndex);
		long ToLongAt(int pCommandIndex, int pResultIndex);

	}

}