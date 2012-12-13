﻿using System;
using System.Collections.Generic;
using Fabric.Api.Paths.Steps;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public class Path {

		public List<PathSegment> Segments { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Path() {
			Segments = new List<PathSegment>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddSegment(IStep pStep, string pScript) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("Script is null or empty.");
			}

			Segments.Add(new PathSegment(pStep, pScript));
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppendToCurrentSegment(string pScript, bool pAddDot=true) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("Script is null or empty.");
			}

			if ( Segments.Count == 0 ) {
				throw new Exception("Path has no segments.");
			}

			Segments[Segments.Count-1].Append(pScript, pAddDot);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string Script {
			get {
				string s = "";

				foreach ( PathSegment seg in Segments ) {
					s += (s == "" ? "" : ".")+seg.Script;
				}

				return s;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static int GetSegmentIndexOfStep(IStep pStep) {
			Path p = pStep.Path;
			int n = p.Segments.Count;

			for ( int i = 0 ; i < n ; ++i ) {
				if ( p.Segments[i].Step != pStep ) { continue; }
				return i;
			}

			return -1;
		}

	}

}