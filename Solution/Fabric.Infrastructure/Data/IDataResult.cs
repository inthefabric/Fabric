using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Core.Elements;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataResult {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetSessionId();
		int GetCommandCount();
		int GetCommandResultCount(int pCommandIndex=0);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataDto ToDto();
		T ToElement<T>() where T : class, IWeaverElement, IElementWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<IDataDto> ToDtoList();
		IList<IList<IDataDto>> ToDtoLists();
		IList<T> ToElementList<T>() where T : class, IWeaverElement, IElementWithId, new();
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataDto ToDtoAt(int pCommandIndex, int pResultIndex);
		T ToElementAt<T>(int pCommandIndex, int pResultIndex) 
												where T : class, IWeaverElement, IElementWithId, new();
		string ToStringAt(int pCommandIndex, int pResultIndex);
		int ToIntAt(int pCommandIndex, int pResultIndex);
		long ToLongAt(int pCommandIndex, int pResultIndex);

	}

}