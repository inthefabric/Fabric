using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabResponse {

		public object Data { get; set; }
		public string BaseUri { get; set; }
		public string RequestUri { get; set; }
		public FabStepLink[] Links { get; set; }
		public string[] Functions { get; set; }
		public int DbMs { get; set; }
		public int TotalMs { get; set; }
		public int DataLen { get; set; }
		public long StartIndex { get; set; }
		public int Count { get; set; }
		public bool HasMore { get; set; }
		public long AppId { get; set; }
		public long UserId { get; set; }
		public long Timestamp { get; set; }
		public int HttpStatus { get; set; }
		public FabError Error { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabResponse() {
			Count = 0;
			DbMs = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StartEvent() {
			Timestamp = DateTime.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Complete() {
			TotalMs = (int)((DateTime.UtcNow.Ticks-Timestamp)/10000);

			if ( TotalMs < DbMs ) { //sometimes Total is 1 millisecond less than Db
				TotalMs = DbMs;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetLinks(List<IStepLink> pLinks) {
			int n = pLinks.Count;
			Links = new FabStepLink[n];

			for ( int i = 0 ; i < n ; ++i ) {
				Links[i] = new FabStepLink(pLinks[i]);
			}
		}

	}

}