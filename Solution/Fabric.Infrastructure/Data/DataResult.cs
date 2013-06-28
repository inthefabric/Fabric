using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;
using RexConnectClient.Core.Result;
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
		public int GetCommandCount() {
			return vResult.Response.CmdList.Count;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public int GetCommandResultCount(int pCommandIndex=0) {
			return vResult.Response.CmdList[pCommandIndex].Results.Count;
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


		////////////////////////////////////////////////////////////////////////////////////////////////
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