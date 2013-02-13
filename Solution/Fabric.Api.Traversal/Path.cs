using System;
using System.Collections.Generic;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public class Path : IPath {

		public bool StartAtRoot { get; private set; }
		public long UserId { get; private set; }
		public long AppId { get; private set; }

		private readonly List<PathSegment> vSegments;
		private readonly Dictionary<string, IFuncAsStep> vAliasMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Path() {
			vSegments = new List<PathSegment>();
			vAliasMap = new Dictionary<string, IFuncAsStep>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public Path(bool pStartAtRoot, long pAppId, long pUserId) : this() {
			StartAtRoot = pStartAtRoot;
			AppId = pAppId;
			UserId = pUserId;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddSegment(IStep pStep, string pScript) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("Script is null or empty.");
			}
			
			vSegments.Add(new PathSegment(pStep, pScript));
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppendToCurrentSegment(string pScript, bool pAddDot=true) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("Script is null or empty.");
			}

			if ( vSegments.Count == 0 ) {
				throw new Exception("Path has no segments.");
			}

			vSegments[vSegments.Count-1].Append(pScript, pAddDot);
		}

		/*--------------------------------------------------------------------------------------------*/
		public int GetSegmentCount() { //TEST: Path.GetSegmentCount()
			return vSegments.Count;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IPathSegment GetSegmentAt(int pIndex) { //TEST: Path.GetStepAt()
			return vSegments[pIndex];
		}

		/*--------------------------------------------------------------------------------------------*/
		public IPathSegment GetSegmentBeforeLast(int pCount) { //TEST: Path.GetSegmentBeforeLast()
			return vSegments[vSegments.Count-pCount-1];
		}

		/*--------------------------------------------------------------------------------------------*/
		public int GetSegmentIndexOfStep(IStep pStep) { //TEST: Path.GetSegmentIndexOfStep()
			int n = vSegments.Count;

			for ( int i = 0 ; i < n ; ++i ) {
				if ( vSegments[i].Step != pStep ) { continue; }
				return i;
			}

			return -1;
		}

		/*--------------------------------------------------------------------------------------------*/
		//TEST: Path.GetSegmentIndexesWithStepType()
		public IEnumerable<int> GetSegmentIndexesWithStepType<T>(int pStopAtIndex=int.MaxValue)
																			where T : class, IStep {
			int n = vSegments.Count;
			var list = new List<int>();

			for ( int i = 0 ; i < n ; ++i ) {
				if ( i >= pStopAtIndex ) {
					break;
				}

				T back = (vSegments[i].Step as T);

				if ( back == null ) {
					break;
				}

				list.Add(i);
			}

			return list;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void RegisterAlias(IFuncAsStep pAsStep) { //TEST: Path.RegisterAlias()
			vAliasMap.Add(pAsStep.Alias, pAsStep);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IFuncAsStep GetAlias(string pAlias) { //TEST: Path.GetAlias()
			IFuncAsStep asStep;
			vAliasMap.TryGetValue(pAlias, out asStep);
			return asStep;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string Script {
			get {
				string s = "";
				int startI = 0;

				if ( vSegments.Count >= 3 ) {
					INodeStep node = (vSegments[1].Step as INodeStep);
					IFuncWhereIdStep whereId = (vSegments[2].Step as IFuncWhereIdStep);

					if ( node != null && whereId != null ) {
						s = node.GetKeyIndexScript(whereId.Id);
						startI = 3;
					}
				}

				for ( int i = startI ; i < vSegments.Count ; ++i ) {
					s += (s == "" ? "" : ".")+vSegments[i].Script;
				}

				return s;
			}
		}

	}

}