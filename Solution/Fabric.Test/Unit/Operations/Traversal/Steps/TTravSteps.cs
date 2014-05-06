using System.Collections.Generic;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravSteps {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EntryList() {
			CheckList(TravSteps.EntryList);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LinkHasList() {
			CheckList(TravSteps.LinkHasList);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LinkList() {
			CheckList(TravSteps.LinkList);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void LinkTakeList() {
			CheckList(TravSteps.LinkTakeList);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void RootList() {
			CheckList(TravSteps.RootList);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ToTypeList() {
			CheckList(TravSteps.ToTypeList);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VertexHasList() {
			CheckList(TravSteps.VertexHasList);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void CheckList(IList<ITravStep> pList) {
			Assert.NotNull(pList, "List should be filled.");
			Assert.Less(1, pList.Count, "Incorrect list count.");
		}


	}

}