using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAttachExistingElement : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Descriptor")]
		[TestCase("Director")]
		[TestCase("Eventor")]
		[TestCase("Identor")]
		[TestCase("Locator")]
		[TestCase("Vector")]
		public void Success(string pElemType) {
			switch ( pElemType ) {
				case "Descriptor":
					var desc = new Descriptor();
					desc.DescriptorId = (long)SetupFactors.DescriptorId.HasA;
					RunTest<Descriptor, FactorUsesDescriptor>(desc);
					break;

				case "Director":
					var dir = new Director();
					dir.DirectorId = (long)SetupFactors.DirectorId.View_Sugg_Learn;
					RunTest<Director, FactorUsesDirector>(dir);
					break;

				case "Eventor":
					var eve = new Eventor();
					eve.EventorId = (long)SetupFactors.EventorId.End_Month_2003_08;
					RunTest<Eventor, FactorUsesEventor>(eve);
					break;

				case "Identor":
					var iden = new Identor();
					iden.IdentorId = (long)SetupFactors.IdentorId.Key_4165;
					RunTest<Identor, FactorUsesIdentor>(iden);
					break;

				case "Locator":
					var loc = new Locator();
					loc.LocatorId = (long)SetupFactors.LocatorId.Silverbow;
					RunTest<Locator, FactorUsesLocator>(loc);
					break;

				case "Vector":
					var vec = new Vector();
					vec.VectorId = (long)SetupFactors.VectorId.Excitement_83_None;
					RunTest<Vector, FactorUsesVector>(vec);
					break;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void RunTest<T, TRel>(T pElement) where T : class, INode, INodeWithId, new()
															where TRel : IWeaverRel<Factor, T>, new() {
			var f = new Factor();
			f.FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete;

			Tasks.AttachExistingElement<T, TRel>(ApiCtx, f, pElement);

			Factor fac = GetNode<Factor>(f.FactorId);

			NodeConnections conn = GetNodeConnections(fac);
			conn.AssertRelCount(2, 4); //has some existing relations
			conn.AssertRel<TRel, T>(true, ((INode)pElement).GetTypeId());

			NewNodeCount = 0;
			NewRelCount = 1;
		}

	}

}