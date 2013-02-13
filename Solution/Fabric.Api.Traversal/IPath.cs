using System.Collections.Generic;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public interface IPath {

		bool StartAtRoot { get; }
		long UserId { get; }
		long AppId { get; }
		string Script { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddSegment(IStep pStep, string pScript);
		void AppendToCurrentSegment(string pScript, bool pAddDot=true);
		int GetSegmentCount();
		IPathSegment GetSegmentAt(int pIndex);
		IPathSegment GetSegmentBeforeLast(int pCount);
		int GetSegmentIndexOfStep(IStep pStep);
		IEnumerable<int> GetSegmentIndexesWithStepType<T>(int pStopAtIndex=int.MaxValue)
																				where T : class, IStep;
		
		/*--------------------------------------------------------------------------------------------*/
		void RegisterAlias(IFuncAsStep pAsStep);
		IFuncAsStep GetAlias(string pAlias);
		
	}

}