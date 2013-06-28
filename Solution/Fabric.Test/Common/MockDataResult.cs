using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Moq;
using Weaver.Core.Elements;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class MockDataResult : Mock<IDataResult> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public void SetupResults(IList<IList<object>> pLists) {
			int n = pLists.Count;
			Setup(x => x.GetCommandCount()).Returns(n);

			for ( int i = 0 ; i < n ; ++i ) {
				IList<object> objList = pLists[i];
				int m = objList.Count;

				Setup(x => x.GetCommandResultCount(i)).Returns(m);

				for ( int j = 0 ; j < m ; ++j ) {
					object obj = objList[j];
					int cmdI = i;
					int resI = j;

					Setup(x => x.ToStringAt(cmdI, resI)).Returns(obj as string);

					if ( obj is int ) {
						Setup(x => x.ToIntAt(cmdI, resI)).Returns((int)obj);
					}

					if ( obj is long ) {
						Setup(x => x.ToLongAt(cmdI, resI)).Returns((long)obj);
					}
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public MockDataResult SetupToElement<T>(T pElement)
											where T : class, IWeaverElement, IElementWithId, new() {
			Setup(x => x.ToElement<T>()).Returns(() => pElement);
			return this;
		}

	}

}