using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationsCustom {

		//TODO: make sure all unit tests use MockBehavior.Strict

		private Mock<ICreateOperationBuilder> vMockBuild;
		private Mock<CreateOperationTasks> vMockTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockBuild = new Mock<ICreateOperationBuilder>(MockBehavior.Strict);
			vMockTasks = new Mock<CreateOperationTasks>(MockBehavior.Strict);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("DISamb", "disamb")]
		[TestCase(null, null)]
		public void ClassAfterSessionStart(string pDisamb, string pDisambLow) {
			var c = new Class();
			c.NameKey = "test";
			c.Disamb = pDisamb;

			ICreateOperationBuilder build = vMockBuild.Object;
			vMockTasks.Setup(x => x.FindDuplicateClass(build, c.NameKey, pDisambLow));

			CreateOperationsCustom.ClassAfterSessionStart(vMockTasks.Object, build, c, null);

			vMockTasks.Verify(x => x.FindDuplicateClass(build, c.NameKey, pDisambLow), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, 2, false)]
		[TestCase(1, 1, true)]
		public void FactorAfterSessionStart(long pPrimArtId, long pRelArtId, bool pError) {
			var cre = new CreateFabFactor();
			cre.UsesPrimaryArtifactId = pPrimArtId;
			cre.UsesRelatedArtifactId = pRelArtId;

			TestUtil.CheckThrows<FabPropertyValueFault>(pError, () =>
				CreateOperationsCustom.FactorAfterSessionStart(null, null, null, cre));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("n", "d", false)]
		[TestCase("n", null, false)]
		[TestCase(null, "d", true)]
		[TestCase(null, null, false)]
		public void InstanceAfterSessionStart(string pName, string pDisamb, bool pError) {
			var i = new Instance();
			i.Name = pName;
			i.Disamb = pDisamb;

			TestUtil.CheckThrows<FabPropertyValueFault>(pError, () =>
				CreateOperationsCustom.InstanceAfterSessionStart(null, null, i, null));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberAfterSessionStart() {
			var cre = new CreateFabMember();
			cre.DefinedByAppId = 123461235;
			cre.DefinedByUserId = 34623463;

			ICreateOperationBuilder build = vMockBuild.Object;
			vMockTasks.Setup(x => x.FindDuplicateMember(
				build, cre.DefinedByUserId, cre.DefinedByAppId));

			CreateOperationsCustom.MemberAfterSessionStart(vMockTasks.Object, build, null, cre);

			vMockTasks.Verify(x => x.FindDuplicateMember(
				build, cre.DefinedByUserId, cre.DefinedByAppId), Times.Once);
		}

	}

}