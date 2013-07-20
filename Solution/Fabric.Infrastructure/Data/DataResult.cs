using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;
using RexConnectClient.Core.Result;
using RexConnectClient.Core.Transfer;
using Weaver.Core.Elements;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataResult : IDataResult {

		private readonly IResponseResult vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataResult(IResponseResult pResult) {
			vResult = pResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetSessionId() {
			return vResult.Response.SessId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public int GetCommandCount() {
			return vResult.Response.CmdList.Count;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public int GetCommandResultCount(int pCommandIndex=0) {
			return vResult.Response.CmdList[pCommandIndex].Results.Count;
		}

		/*--------------------------------------------------------------------------------------------*/
		public int GetCommandIndexByCmdId(string pCmdId) {
			IList<ResponseCmd> list = vResult.Response.CmdList;

			for ( int i = 0 ; i < list.Count ; ++i ) {
				if ( list[i].CmdId == pCmdId ) {
					return i;
				}
			}

			return -1;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataDto ToDto() {
			AssertOneCommand();
			IList<IGraphElement> elems = vResult.GetGraphElementsAt(0);

			if ( elems.Count == 0 ) {
				return null;
			}

			if ( elems.Count == 1 ) {
				return DataDto.FromGraphElement(elems[0]);
			}

			throw new Exception("Expected one result, received "+elems.Count);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T ToElement<T>() where T : class, IWeaverElement, IElementWithId, new() {
			IDataDto dto = ToDto();
			return (dto == null ? null : DataDto.ToElement<T>(dto));
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDictionary<string, string> ToMap() {
			AssertOneCommand();
			IList<IDictionary<string, string>> maps = vResult.GetMapResultsAt(0);

			if ( maps.Count == 0 ) {
				return null;
			}

			if ( maps.Count == 1 ) {
				return maps[0];
			}

			throw new Exception("Expected one result, received "+maps.Count);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IList<IDataDto> ToDtoList() {
			AssertOneCommand();
			IList<IGraphElement> elems = vResult.GetGraphElementsAt(0);
			return elems.Select(DataDto.FromGraphElement).ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<IList<IDataDto>> ToDtoLists() {
			return vResult.GetGraphElements()
				.Select(elems => elems
					.Select(DataDto.FromGraphElement).ToList()
				)
				.Cast<IList<IDataDto>>()
				.ToList();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<T> ToElementList<T>() where T : class, IWeaverElement, IElementWithId, new() {
			return ToDtoList().Select(DataDto.ToElement<T>).ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<IList<IDictionary<string, string>>> ToMapLists() {
			return vResult.GetMapResults();
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataDto ToDtoAt(int pCommandIndex, int pResultIndex) {
			IGraphElement e = vResult.GetGraphElementsAt(pCommandIndex)[pResultIndex];
			return DataDto.FromGraphElement(e);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ToElementAt<T>(int pCommandIndex, int pResultIndex)
											where T : class, IWeaverElement, IElementWithId, new() {
			IDataDto dto = ToDtoAt(pCommandIndex, pResultIndex);
			return DataDto.ToElement<T>(dto);
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDictionary<string, string> ToMapAt(int pCommandIndex, int pResultIndex) {
			return vResult.GetMapResultsAt(pCommandIndex)[pResultIndex];
		}

		/*--------------------------------------------------------------------------------------------*/
		public string ToStringAt(int pCommandIndex, int pResultIndex) {
			return vResult.GetTextResultsAt(pCommandIndex).ToString(pResultIndex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public int ToIntAt(int pCommandIndex, int pResultIndex) {
			return vResult.GetTextResultsAt(pCommandIndex).ToInt(pResultIndex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public long ToLongAt(int pCommandIndex, int pResultIndex) {
			return vResult.GetTextResultsAt(pCommandIndex).ToLong(pResultIndex);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AssertOneCommand() {
			if ( GetCommandCount() != 1 ) {
				throw new Exception("Expected one command, received "+GetCommandCount()+".");
			}
		}

	}

}