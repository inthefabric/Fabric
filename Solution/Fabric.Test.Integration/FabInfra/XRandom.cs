using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;
using Weaver.Titan;
using Weaver.Titan.Steps.Parameters;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XRandom : IntegTestBase {
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			UsesElasticSearch = true;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Edge() {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(u => u.ArtifactId, 2)
				.UsesEmail
				.ToQuery();

			ApiCtx.GetList<UserUsesEmail>(q);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MultipleElasticParams() {
			var elasticParams = new IWeaverParamElastic<App>[] {
				new WeaverParamElastic<App>(x => x.Name, WeaverParamElasticOp.Contains, "KINSTNER"), 
				new WeaverParamElastic<App>(x => x.Name, WeaverParamElasticOp.Contains, "gallery"), 
				new WeaverParamElastic<App>(x => x.Name, WeaverParamElasticOp.Contains, "photo")
			};

			IWeaverQuery q = Weave.Inst.TitanGraph()
				.QueryV().ElasticIndex(elasticParams)
				.InMemberCreates.FromMember
				.ToQuery();

			Member mem = ApiCtx.ExecuteForTest(q).ToElement<Member>();
			Assert.AreEqual((byte)SetupUsers.MemberId.FabGalData, mem.MemberId, "Incorrect MemberId.");
		}
		
	}

}