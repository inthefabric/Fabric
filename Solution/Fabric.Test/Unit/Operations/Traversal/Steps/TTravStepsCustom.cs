using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Meta;
using Fabric.Api.Objects.Traversal;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepsCustom {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorWhereEventorYear() {
			var step = TravStepsCustom.FactorWhereEventorYear<FabFactor, long, FabFactor>("c", "db");
			Assert.NotNull(step, "Step should be filled.");
			Assert.AreEqual(typeof(TravStepWhereEventorDateTime), step.GetType(), "Incorrect type.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorWhereEventorMonth() {
			var step = TravStepsCustom.FactorWhereEventorMonth<FabFactor, long, FabFactor>("c", "db");
			Assert.Null(step, "Step should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorWhereEventorDay() {
			var step = TravStepsCustom.FactorWhereEventorDay<FabFactor, long, FabFactor>("c", "db");
			Assert.Null(step, "Step should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorWhereEventorHour() {
			var step = TravStepsCustom.FactorWhereEventorHour<FabFactor, long, FabFactor>("c", "db");
			Assert.Null(step, "Step should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorWhereEventorMinute() {
			var step = TravStepsCustom.FactorWhereEventorMinute<FabFactor, long, FabFactor>("c", "db");
			Assert.Null(step, "Step should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FactorWhereEventorSecond() {
			var step = TravStepsCustom.FactorWhereEventorSecond<FabFactor, long, FabFactor>("c", "db");
			Assert.Null(step, "Step should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VertexWhereTimestamp() {
			var step = TravStepsCustom.VertexWhereTimestamp<FabFactor, long, FabFactor>("c", "db");
			CheckWhereTimestamp<FabFactor, FabFactor>(step);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void VertexEntryWhereTimestamp() {
			var step = TravStepsCustom
				.VertexEntryWhereTimestamp<FabTravFactorRoot, long, FabFactor>("c", "db");

			Assert.NotNull(step, "Step should be filled.");

			Assert.AreEqual(typeof(TravStepEntryWhere<FabTravFactorRoot, long, FabFactor>),
				step.GetType(), "Incorrect type.");

			var whereStep = (step as TravStepEntryWhere<FabTravFactorRoot, long, FabFactor>);
			Assert.NotNull(whereStep, "Step could not be casted properly.");
			CheckWhereTimestampValue(whereStep.UpdateValue);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppDefinesMemberWhereTimestamp() {
			var step = TravStepsCustom
				.AppDefinesMemberWhereTimestamp<FabApp, long, FabApp>("c", "db");
			CheckWhereTimestamp<FabApp, FabApp>(step);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactUsedAsPrimaryByFactorWhereTimestamp() {
			var step = TravStepsCustom
				.ArtifactUsedAsPrimaryByFactorWhereTimestamp<FabArtifact, long, FabArtifact>("c", "db");
			CheckWhereTimestamp<FabArtifact, FabArtifact>(step);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ArtifactUsedAsRelatedByFactorWhereTimestamp() {
			var step = TravStepsCustom
				.ArtifactUsedAsRelatedByFactorWhereTimestamp<FabArtifact, long, FabArtifact>("c", "db");
			CheckWhereTimestamp<FabArtifact, FabArtifact>(step);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberCreatesArtifactWhereTimestamp() {
			var step = TravStepsCustom
				.MemberCreatesArtifactWhereTimestamp<FabMember, long, FabMember>("c", "db");
			CheckWhereTimestamp<FabMember, FabMember>(step);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void MemberCreatesFactorWhereTimestamp() {
			var step = TravStepsCustom
				.MemberCreatesFactorWhereTimestamp<FabMember, long, FabMember>("c", "db");
			CheckWhereTimestamp<FabMember, FabMember>(step);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void UserDefinesMemberWhereTimestamp() {
			var step = TravStepsCustom
				.UserDefinesMemberWhereTimestamp<FabUser, long, FabUser>("c", "db");
			CheckWhereTimestamp<FabUser, FabUser>(step);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckWhereTimestamp<TFrom, TTo>(ITravStep pStep)
													where TFrom : FabObject where TTo : FabElement {
			Assert.NotNull(pStep, "Step should be filled.");
			Assert.AreEqual(typeof(TravStepWhere<TFrom, long, TTo>),
				pStep.GetType(), "Incorrect type.");
			CheckWhereTimestampValue(((TravStepWhere<TFrom, long, TTo>)pStep).UpdateValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckWhereTimestampValue(Func<long, long> pUpdateValue) {
			const long fromVal = 1236513461346;
			long toVal = FabMetaTime.GetTicks(fromVal);

			Assert.NotNull(pUpdateValue, "UpdateValue must be customized.");
			long result = pUpdateValue(fromVal);
			Assert.AreEqual(toVal, result, "Incorrect UpdateValue result.");
		}

	}

}