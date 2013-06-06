using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		private Stopwatch vWatch;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabResponse() {
			Count = 0;
			DbMs = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StartEvent() {
			vWatch = new Stopwatch();
			vWatch.Start();

			Timestamp = DateTime.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Complete() {
			TotalMs = (int)vWatch.ElapsedMilliseconds;
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